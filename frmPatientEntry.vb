Imports MySql.Data.MySqlClient

Public Class frmPatientEntry
    Private ReadOnly _connectionString As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String)
        _connectionString = connectionString
        InitializeComponent()
    End Sub

    Private Sub frmPatientEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If cboSex.Items.Count > 0 AndAlso cboSex.SelectedIndex < 0 Then
            cboSex.SelectedIndex = 0
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
        If String.IsNullOrWhiteSpace(_connectionString) Then
            MessageBox.Show("Connection string is not set.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
           cboSex.SelectedIndex < 0 Then
            MessageBox.Show("First name, last name, and sex are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim formattedPhone As String = FormatPhoneNumber(txtPhoneNumber.Text)
        If formattedPhone <> "" AndAlso Not IsValidPhoneNumber(formattedPhone) Then
            MessageBox.Show("Phone number must be in format 0999-999-9999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhoneNumber.Focus()
            Return
        End If

        txtPhoneNumber.Text = formattedPhone

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim newPatientId As Integer = GetNextAvailablePatientId(conn)
                If newPatientId = -1 Then
                    MessageBox.Show("No available PatientID in range 20001 to 29999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim sql As String = "INSERT INTO patient (PatientID, FirstName, LastName, Sex, DateOfBirth, PhoneNumber, HouseNumber, Street, City, Province) " &
                                    "VALUES (@PatientID, @FirstName, @LastName, @Sex, @DateOfBirth, @PhoneNumber, @HouseNumber, @Street, @City, @Province)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@PatientID", newPatientId)
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim())
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Sex", cboSex.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@DateOfBirth", dtpDateOfBirth.Value.Date)
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim())
                    cmd.Parameters.AddWithValue("@HouseNumber", txtHouseNumber.Text.Trim())
                    cmd.Parameters.AddWithValue("@Street", txtStreet.Text.Trim())
                    cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim())
                    cmd.Parameters.AddWithValue("@Province", txtProvince.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Patient added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Unable to save patient: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function FormatPhoneNumber(value As String) As String
        Dim digitsOnly As String = New String(value.Where(Function(c) Char.IsDigit(c)).ToArray())
        If digitsOnly = "" Then Return ""

        If digitsOnly.Length > 11 Then
            digitsOnly = digitsOnly.Substring(0, 11)
        End If

        If digitsOnly.Length >= 8 Then
            Return String.Format("{0}-{1}-{2}",
                                 digitsOnly.Substring(0, Math.Min(4, digitsOnly.Length)),
                                 digitsOnly.Substring(4, Math.Min(3, Math.Max(0, digitsOnly.Length - 4))),
                                 digitsOnly.Substring(7, Math.Max(0, digitsOnly.Length - 7)))
        ElseIf digitsOnly.Length >= 5 Then
            Return String.Format("{0}-{1}",
                                 digitsOnly.Substring(0, 4),
                                 digitsOnly.Substring(4))
        Else
            Return digitsOnly
        End If
    End Function

    Private Function IsValidPhoneNumber(value As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^0\d{3}-\d{3}-\d{4}$")
    End Function

    Private Function GetNextAvailablePatientId(conn As MySqlConnection) As Integer
        Const minId As Integer = 20001
        Const maxId As Integer = 29999

        Dim candidate As Integer = minId
        Dim sql As String = "SELECT PatientID FROM patient WHERE PatientID BETWEEN @minId AND @maxId ORDER BY PatientID"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@minId", minId)
            cmd.Parameters.AddWithValue("@maxId", maxId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim usedId As Integer = Convert.ToInt32(reader("PatientID"))

                    If usedId < candidate Then
                        Continue While
                    End If

                    If usedId = candidate Then
                        candidate += 1
                        If candidate > maxId Then
                            Return -1
                        End If
                    ElseIf usedId > candidate Then
                        Exit While
                    End If
                End While
            End Using
        End Using

        If candidate > maxId Then
            Return -1
        End If

        Return candidate
    End Function
End Class