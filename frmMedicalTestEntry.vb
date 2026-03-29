Imports MySql.Data.MySqlClient

Public Class frmMedicalTestEntry
    Private ReadOnly _connectionString As String
    Private ReadOnly _isUpdateMode As Boolean
    Private ReadOnly _existingTestId As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String)
        _connectionString = connectionString
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String, testId As Integer)
        _connectionString = connectionString
        _isUpdateMode = True
        _existingTestId = testId
        InitializeComponent()
    End Sub

    Private Sub frmMedicalTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _isUpdateMode Then
            Me.Text = "Update Medical Test"
            btnSave.Text = "Update"
            btnSave.BackColor = Color.FromArgb(217, 92, 128)
            LoadMedicalTestForUpdate()
        Else
            Me.Text = "Add New Medical Test"
            btnSave.Text = "Save"
            btnSave.BackColor = Color.FromArgb(184, 19, 66)
            LoadNextTestId()
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then Return

        Dim testId As Integer
        If Not Integer.TryParse(txtTestID.Text.Trim(), testId) Then
            MessageBox.Show("Invalid Test ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If testId < 40001 OrElse testId > 49999 Then
            MessageBox.Show("Test ID must be between 40001 and 49999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim costValue As Decimal
        If Not Decimal.TryParse(txtCost.Text.Trim(), costValue) OrElse costValue < 0D Then
            MessageBox.Show("Cost must be a valid non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCost.Focus()
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim sql As String
                If _isUpdateMode Then
                    sql = "UPDATE medical_test SET TestName = @TestName, TestDescription = @TestDescription, Cost = @Cost WHERE TestID = @TestID"
                Else
                    sql = "INSERT INTO medical_test (TestID, TestName, TestDescription, Cost) VALUES (@TestID, @TestName, @TestDescription, @Cost)"
                End If

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@TestID", testId)
                    cmd.Parameters.AddWithValue("@TestName", txtTestName.Text.Trim())
                    cmd.Parameters.AddWithValue("@TestDescription", txtTestDescription.Text.Trim())
                    cmd.Parameters.AddWithValue("@Cost", costValue)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            If _isUpdateMode Then
                MessageBox.Show("Medical test updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Medical test added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Unable to save medical test: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMedicalTestForUpdate()
        If String.IsNullOrWhiteSpace(_connectionString) OrElse _existingTestId <= 0 Then
            MessageBox.Show("Unable to load selected medical test.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim sql As String = "SELECT TestID, TestName, TestDescription, Cost FROM medical_test WHERE TestID = @TestID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@TestID", _existingTestId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            MessageBox.Show("Selected medical test was not found.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.DialogResult = DialogResult.Cancel
                            Me.Close()
                            Return
                        End If

                        txtTestID.Text = Convert.ToInt32(reader("TestID")).ToString()
                        txtTestName.Text = reader("TestName").ToString()
                        txtTestDescription.Text = reader("TestDescription").ToString()
                        txtCost.Text = Convert.ToDecimal(reader("Cost")).ToString("0.##")
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to load selected medical test: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(_connectionString) Then
            MessageBox.Show("Connection string is not set.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtTestID.Text) Then
            MessageBox.Show("Test ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtTestName.Text) Then
            MessageBox.Show("Test name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTestName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtCost.Text) Then
            MessageBox.Show("Cost is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCost.Focus()
            Return False
        End If

        Dim costValue As Decimal
        If Not Decimal.TryParse(txtCost.Text.Trim(), costValue) OrElse costValue < 0D Then
            MessageBox.Show("Cost must be a valid non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCost.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtTestDescription.Text) Then
            MessageBox.Show("Description is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTestDescription.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub LoadNextTestId()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            txtTestID.Text = ""
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim newTestId As Integer = GetNextAvailableTestId(conn)
                If newTestId = -1 Then
                    txtTestID.Text = ""
                    MessageBox.Show("No available TestID in range 40001 to 49999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                txtTestID.Text = newTestId.ToString()
            End Using
        Catch ex As Exception
            txtTestID.Text = ""
            MessageBox.Show("Unable to generate test ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetNextAvailableTestId(conn As MySqlConnection) As Integer
        Const minId As Integer = 40001
        Const maxId As Integer = 49999

        Dim candidate As Integer = minId
        Dim sql As String = "SELECT TestID FROM medical_test WHERE TestID BETWEEN @minId AND @maxId ORDER BY TestID"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@minId", minId)
            cmd.Parameters.AddWithValue("@maxId", maxId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim usedId As Integer = Convert.ToInt32(reader("TestID"))

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
