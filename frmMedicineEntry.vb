Imports MySql.Data.MySqlClient

Public Class frmMedicineEntry
    Private ReadOnly _connectionString As String
    Private ReadOnly _isUpdateMode As Boolean
    Private ReadOnly _existingMedicineId As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String)
        _connectionString = connectionString
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String, medicineId As Integer)
        _connectionString = connectionString
        _isUpdateMode = True
        _existingMedicineId = medicineId
        InitializeComponent()
    End Sub

    Private Sub frmMedicineEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _isUpdateMode Then
            Me.Text = "Update Medicine"
            btnSave.Text = "Update"
            btnSave.BackColor = Color.FromArgb(217, 92, 128)
            LoadMedicineForUpdate()
        Else
            Me.Text = "Add New Medicine"
            btnSave.Text = "Save"
            btnSave.BackColor = Color.FromArgb(184, 19, 66)
            LoadNextMedicineId()
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then
            Return
        End If

        Dim medicineId As Integer
        If Not Integer.TryParse(txtMedicineID.Text.Trim(), medicineId) Then
            MessageBox.Show("Invalid Medicine ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim priceValue As Decimal
        If Not Decimal.TryParse(txtPrice.Text.Trim(), priceValue) OrElse priceValue < 0D Then
            MessageBox.Show("Price must be a valid non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim sql As String
                If _isUpdateMode Then
                    sql = "UPDATE medicine SET MedicineName = @MedicineName, Price = @Price, MedicineDescription = @MedicineDescription WHERE MedicineID = @MedicineID"
                Else
                    sql = "INSERT INTO medicine (MedicineID, MedicineName, Price, MedicineDescription) VALUES (@MedicineID, @MedicineName, @Price, @MedicineDescription)"
                End If

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@MedicineID", medicineId)
                    cmd.Parameters.AddWithValue("@MedicineName", txtMedicineName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Price", priceValue)
                    cmd.Parameters.AddWithValue("@MedicineDescription", txtMedicineDescription.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            If _isUpdateMode Then
                MessageBox.Show("Medicine updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Medicine added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Unable to save medicine: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMedicineForUpdate()
        If String.IsNullOrWhiteSpace(_connectionString) OrElse _existingMedicineId <= 0 Then
            MessageBox.Show("Unable to load selected medicine.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim sql As String = "SELECT MedicineID, MedicineName, Price, MedicineDescription FROM medicine WHERE MedicineID = @MedicineID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@MedicineID", _existingMedicineId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            MessageBox.Show("Selected medicine was not found.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.DialogResult = DialogResult.Cancel
                            Me.Close()
                            Return
                        End If

                        txtMedicineID.Text = Convert.ToInt32(reader("MedicineID")).ToString()
                        txtMedicineName.Text = reader("MedicineName").ToString()
                        txtPrice.Text = Convert.ToDecimal(reader("Price")).ToString("0.##")
                        txtMedicineDescription.Text = reader("MedicineDescription").ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to load selected medicine: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(_connectionString) Then
            MessageBox.Show("Connection string is not set.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtMedicineID.Text) Then
            MessageBox.Show("Medicine ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtMedicineName.Text) Then
            MessageBox.Show("Medicine name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMedicineName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPrice.Text) Then
            MessageBox.Show("Price is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return False
        End If

        Dim priceValue As Decimal
        If Not Decimal.TryParse(txtPrice.Text.Trim(), priceValue) OrElse priceValue < 0D Then
            MessageBox.Show("Price must be a valid non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtMedicineDescription.Text) Then
            MessageBox.Show("Description is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMedicineDescription.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub LoadNextMedicineId()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            txtMedicineID.Text = ""
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim newMedicineId As Integer = GetNextAvailableMedicineId(conn)
                If newMedicineId = -1 Then
                    txtMedicineID.Text = ""
                    MessageBox.Show("No available MedicineID in range 50001 to 59999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                txtMedicineID.Text = newMedicineId.ToString()
            End Using
        Catch ex As Exception
            txtMedicineID.Text = ""
            MessageBox.Show("Unable to generate medicine ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetNextAvailableMedicineId(conn As MySqlConnection) As Integer
        Const minId As Integer = 50001
        Const maxId As Integer = 59999

        Dim candidate As Integer = minId
        Dim sql As String = "SELECT MedicineID FROM medicine WHERE MedicineID BETWEEN @minId AND @maxId ORDER BY MedicineID"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@minId", minId)
            cmd.Parameters.AddWithValue("@maxId", maxId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim usedId As Integer = Convert.ToInt32(reader("MedicineID"))

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
