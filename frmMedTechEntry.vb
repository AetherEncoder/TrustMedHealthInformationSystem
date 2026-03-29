Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class frmMedTechEntry
    Private ReadOnly _connectionString As String
    Private ReadOnly _isUpdateMode As Boolean
    Private ReadOnly _existingMedTechId As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String)
        _connectionString = connectionString
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String, medTechId As Integer)
        _connectionString = connectionString
        _isUpdateMode = True
        _existingMedTechId = medTechId
        InitializeComponent()
    End Sub

    Private Sub frmMedTechEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _isUpdateMode Then
            Me.Text = "Update MedTech"
            btnSave.Text = "Update"
            btnSave.BackColor = Color.FromArgb(217, 92, 128)
            LoadMedTechForUpdate()
        Else
            Me.Text = "Add New MedTech"
            btnSave.Text = "Save"
            btnSave.BackColor = Color.FromArgb(184, 19, 66)
            LoadNextMedTechId()
        End If

    End Sub

    Private Sub txtPhoneNumber_Leave(sender As Object, e As EventArgs) Handles txtPhoneNumber.Leave
        txtPhoneNumber.Text = FormatPhoneNumber(txtPhoneNumber.Text)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then Return

        Dim medTechId As Integer
        If Not Integer.TryParse(txtMedTechID.Text, medTechId) Then
            MessageBox.Show("Invalid MedTech ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        txtPhoneNumber.Text = FormatPhoneNumber(txtPhoneNumber.Text)

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim sql As String
                If _isUpdateMode Then
                    sql = "UPDATE medtech SET FirstName = @FirstName, LastName = @LastName, LicenseNo = @LicenseNo, PhoneNumber = @PhoneNumber WHERE MedtechID = @MedtechID"
                Else
                    sql = "INSERT INTO medtech (MedtechID, FirstName, LastName, LicenseNo, PhoneNumber) VALUES (@MedtechID, @FirstName, @LastName, @LicenseNo, @PhoneNumber)"
                End If

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@MedtechID", medTechId)
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim())
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim())
                    cmd.Parameters.AddWithValue("@LicenseNo", txtLicenseNo.Text.Trim())
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("MedTech " & If(_isUpdateMode, "updated", "added") & " successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Unable to save MedTech: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMedTechForUpdate()
        If String.IsNullOrWhiteSpace(_connectionString) OrElse _existingMedTechId <= 0 Then
            MessageBox.Show("Unable to load selected MedTech.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim sql As String = "SELECT MedtechID, FirstName, LastName, LicenseNo, PhoneNumber FROM medtech WHERE MedtechID = @MedtechID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@MedtechID", _existingMedTechId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            MessageBox.Show("Selected MedTech was not found.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.DialogResult = DialogResult.Cancel
                            Me.Close()
                            Return
                        End If

                        txtMedTechID.Text = Convert.ToInt32(reader("MedtechID")).ToString()
                        txtFirstName.Text = reader("FirstName").ToString()
                        txtLastName.Text = reader("LastName").ToString()
                        txtLicenseNo.Text = reader("LicenseNo").ToString()
                        txtPhoneNumber.Text = reader("PhoneNumber").ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to load selected MedTech: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

    Private Sub LoadNextMedTechId()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            txtMedTechID.Text = ""
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim newId As Integer = GetNextAvailableMedTechId(conn)
                If newId = -1 Then
                    txtMedTechID.Text = ""
                    MessageBox.Show("No available MedtechID in range 60001 to 69999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                txtMedTechID.Text = newId.ToString()
            End Using
        Catch ex As Exception
            txtMedTechID.Text = ""
            MessageBox.Show("Unable to generate MedTech ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(_connectionString) Then
            MessageBox.Show("Connection string is not set.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtMedTechID.Text) Then
            MessageBox.Show("MedTech ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("First name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MessageBox.Show("Last name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLastName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtLicenseNo.Text) Then
            MessageBox.Show("License number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLicenseNo.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPhoneNumber.Text) Then
            MessageBox.Show("Phone number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhoneNumber.Focus()
            Return False
        End If

        If Not IsValidName(txtFirstName.Text) Then
            MessageBox.Show("First name must not contain numbers.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            Return False
        End If

        If Not IsValidName(txtLastName.Text) Then
            MessageBox.Show("Last name must not contain numbers.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLastName.Focus()
            Return False
        End If

        Dim formattedPhone As String = FormatPhoneNumber(txtPhoneNumber.Text)
        If Not IsValidPhoneNumber(formattedPhone) Then
            MessageBox.Show("Phone number must be in format 0999-999-9999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhoneNumber.Focus()
            Return False
        End If

        txtPhoneNumber.Text = formattedPhone
        Return True
    End Function

    Private Function FormatPhoneNumber(value As String) As String
        Dim digitsOnly As String = New String(value.Where(Function(c) Char.IsDigit(c)).ToArray())
        If digitsOnly = "" Then Return ""

        If digitsOnly.Length > 11 Then digitsOnly = digitsOnly.Substring(0, 11)

        If digitsOnly.Length >= 8 Then
            Return String.Format("{0}-{1}-{2}",
                                 digitsOnly.Substring(0, Math.Min(4, digitsOnly.Length)),
                                 digitsOnly.Substring(4, Math.Min(3, Math.Max(0, digitsOnly.Length - 4))),
                                 digitsOnly.Substring(7, Math.Max(0, digitsOnly.Length - 7)))
        ElseIf digitsOnly.Length >= 5 Then
            Return String.Format("{0}-{1}", digitsOnly.Substring(0, 4), digitsOnly.Substring(4))
        End If

        Return digitsOnly
    End Function

    Private Function IsValidPhoneNumber(value As String) As Boolean
        Return Regex.IsMatch(value, "^0\d{3}-\d{3}-\d{4}$")
    End Function

    Private Function IsValidName(value As String) As Boolean
        Return Regex.IsMatch(value.Trim(), "^[A-Za-z\s'\-]+$")
    End Function

    Private Function GetNextAvailableMedTechId(conn As MySqlConnection) As Integer
        Const minId As Integer = 60001
        Const maxId As Integer = 69999

        Dim candidate As Integer = minId
        Dim sql As String = "SELECT MedtechID FROM medtech WHERE MedtechID BETWEEN @minId AND @maxId ORDER BY MedtechID"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@minId", minId)
            cmd.Parameters.AddWithValue("@maxId", maxId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim usedId As Integer = Convert.ToInt32(reader("MedtechID"))

                    If usedId < candidate Then Continue While

                    If usedId = candidate Then
                        candidate += 1
                        If candidate > maxId Then Return -1
                    ElseIf usedId > candidate Then
                        Exit While
                    End If
                End While
            End Using
        End Using

        If candidate > maxId Then Return -1
        Return candidate
    End Function
End Class
