Imports MySql.Data.MySqlClient

Partial Class frmPrescriptionEntry
    Private ReadOnly _connectionString As String
    Private ReadOnly _selectedMedicines As New List(Of MedicineSelectionItem)()
    Private ReadOnly _isUpdateMode As Boolean
    Private ReadOnly _existingPrescriptionId As Integer

    Private Class MedicineSelectionItem
        Public Property MedicineID As Integer
        Public Property DisplayName As String

        Public Overrides Function ToString() As String
            Return DisplayName
        End Function
    End Class

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String)
        _connectionString = connectionString
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String, prescriptionId As Integer)
        _connectionString = connectionString
        _isUpdateMode = True
        _existingPrescriptionId = prescriptionId
        InitializeComponent()
    End Sub

    Private Sub frmPrescriptionEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPhysicianAndPatientOptions()
        LoadMedicineOptions()
        RefreshSelectedMedicinesList()

        If _isUpdateMode Then
            Me.Text = "Update Prescription"
            btnSave.Text = "Update"
            btnSave.BackColor = Color.FromArgb(184, 19, 66)
            LoadPrescriptionForUpdate()
        Else
            Me.Text = "Add New Prescription"
            btnSave.Text = "Save"
            btnSave.BackColor = Color.FromArgb(184, 19, 66)
            LoadNextPrescriptionId()
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAddMedicine_Click(sender As Object, e As EventArgs) Handles btnAddMedicine.Click
        If cboMedicine.SelectedIndex < 0 OrElse cboMedicine.SelectedValue Is Nothing OrElse TypeOf cboMedicine.SelectedValue Is DataRowView Then
            MessageBox.Show("Select a medicine to add.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMedicine.Focus()
            Return
        End If

        Dim medicineId As Integer = Convert.ToInt32(cboMedicine.SelectedValue)
        If IsMedicineAlreadySelected(medicineId) Then
            MessageBox.Show("Medicine is already added to this prescription.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        _selectedMedicines.Add(New MedicineSelectionItem With {
            .MedicineID = medicineId,
            .DisplayName = cboMedicine.Text.Trim()
        })

        RefreshSelectedMedicinesList()
        cboMedicine.SelectedIndex = -1
    End Sub

    Private Sub btnRemoveMedicine_Click(sender As Object, e As EventArgs) Handles btnRemoveMedicine.Click
        If lstSelectedMedicines.SelectedItem Is Nothing Then
            MessageBox.Show("Select a medicine from the list to remove.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lstSelectedMedicines.Focus()
            Return
        End If

        Dim selectedItem As MedicineSelectionItem = TryCast(lstSelectedMedicines.SelectedItem, MedicineSelectionItem)
        If selectedItem Is Nothing Then Return

        For i As Integer = _selectedMedicines.Count - 1 To 0 Step -1
            If _selectedMedicines(i).MedicineID = selectedItem.MedicineID Then
                _selectedMedicines.RemoveAt(i)
                Exit For
            End If
        Next

        RefreshSelectedMedicinesList()
    End Sub

    Private Function IsMedicineAlreadySelected(medicineId As Integer) As Boolean
        For Each item As MedicineSelectionItem In _selectedMedicines
            If item.MedicineID = medicineId Then Return True
        Next

        Return False
    End Function

    Private Sub RefreshSelectedMedicinesList()
        lstSelectedMedicines.Items.Clear()

        For Each item As MedicineSelectionItem In _selectedMedicines
            lstSelectedMedicines.Items.Add(item)
        Next
    End Sub

    Private Sub LoadPrescriptionForUpdate()
        If String.IsNullOrWhiteSpace(_connectionString) OrElse _existingPrescriptionId <= 0 Then
            MessageBox.Show("Unable to load selected prescription.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim prescriptionSql As String = "SELECT PrescriptionID, PhysicianID, PatientID, Instruction, PrescriptionDate FROM prescription WHERE PrescriptionID = @PrescriptionID"
                Using prescriptionCmd As New MySqlCommand(prescriptionSql, conn)
                    prescriptionCmd.Parameters.AddWithValue("@PrescriptionID", _existingPrescriptionId)

                    Using reader As MySqlDataReader = prescriptionCmd.ExecuteReader()
                        If Not reader.Read() Then
                            MessageBox.Show("Selected prescription was not found.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.DialogResult = DialogResult.Cancel
                            Me.Close()
                            Return
                        End If

                        txtPrescriptionID.Text = Convert.ToInt32(reader("PrescriptionID")).ToString()
                        cboPhysician.SelectedValue = Convert.ToInt32(reader("PhysicianID"))
                        cboPatient.SelectedValue = Convert.ToInt32(reader("PatientID"))
                        txtInstruction.Text = reader("Instruction").ToString()

                        If Not Convert.IsDBNull(reader("PrescriptionDate")) Then
                            dtpPrescriptionDate.Value = Convert.ToDateTime(reader("PrescriptionDate"))
                        End If
                    End Using
                End Using

                _selectedMedicines.Clear()
                Dim medsSql As String = "SELECT m.MedicineID, CONCAT(m.MedicineName, ' (', m.MedicineID, ')') AS FullName FROM prescription_inclusion pi INNER JOIN medicine m ON m.MedicineID = pi.MedicineID WHERE pi.PrescriptionID = @PrescriptionID ORDER BY m.MedicineName"
                Using medsCmd As New MySqlCommand(medsSql, conn)
                    medsCmd.Parameters.AddWithValue("@PrescriptionID", _existingPrescriptionId)

                    Using reader As MySqlDataReader = medsCmd.ExecuteReader()
                        While reader.Read()
                            _selectedMedicines.Add(New MedicineSelectionItem With {
                                .MedicineID = Convert.ToInt32(reader("MedicineID")),
                                .DisplayName = reader("FullName").ToString()
                            })
                        End While
                    End Using
                End Using

                RefreshSelectedMedicinesList()
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to load selected prescription: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then
            Return
        End If

        Dim prescriptionId As Integer
        If Not Integer.TryParse(txtPrescriptionID.Text.Trim(), prescriptionId) Then
            MessageBox.Show("Invalid Prescription ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim physicianId As Integer = Convert.ToInt32(cboPhysician.SelectedValue)
        Dim patientId As Integer = Convert.ToInt32(cboPatient.SelectedValue)

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim sql As String
                        If _isUpdateMode Then
                            sql = "UPDATE prescription SET PhysicianID = @PhysicianID, PatientID = @PatientID, Instruction = @Instruction, PrescriptionDate = @PrescriptionDate WHERE PrescriptionID = @PrescriptionID"
                        Else
                            sql = "INSERT INTO prescription (PrescriptionID, PhysicianID, PatientID, Instruction, PrescriptionDate) VALUES (@PrescriptionID, @PhysicianID, @PatientID, @Instruction, @PrescriptionDate)"
                        End If

                        Using cmd As New MySqlCommand(sql, conn, tx)
                            cmd.Parameters.AddWithValue("@PrescriptionID", prescriptionId)
                            cmd.Parameters.AddWithValue("@PhysicianID", physicianId)
                            cmd.Parameters.AddWithValue("@PatientID", patientId)
                            cmd.Parameters.AddWithValue("@Instruction", txtInstruction.Text.Trim())
                            cmd.Parameters.AddWithValue("@PrescriptionDate", dtpPrescriptionDate.Value.Date)
                            cmd.ExecuteNonQuery()
                        End Using

                        If _isUpdateMode Then
                            Using deleteCmd As New MySqlCommand("DELETE FROM prescription_inclusion WHERE PrescriptionID = @PrescriptionID", conn, tx)
                                deleteCmd.Parameters.AddWithValue("@PrescriptionID", prescriptionId)
                                deleteCmd.ExecuteNonQuery()
                            End Using
                        End If

                        Dim inclusionSql As String = "INSERT INTO prescription_inclusion (MedicineID, PrescriptionID) VALUES (@MedicineID, @PrescriptionID)"
                        For Each medicine As MedicineSelectionItem In _selectedMedicines
                            Using inclusionCmd As New MySqlCommand(inclusionSql, conn, tx)
                                inclusionCmd.Parameters.AddWithValue("@MedicineID", medicine.MedicineID)
                                inclusionCmd.Parameters.AddWithValue("@PrescriptionID", prescriptionId)
                                inclusionCmd.ExecuteNonQuery()
                            End Using
                        Next

                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            If _isUpdateMode Then
                MessageBox.Show("Prescription updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Prescription added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Unable to save prescription: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(_connectionString) Then
            MessageBox.Show("Connection string is not set.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPrescriptionID.Text) Then
            MessageBox.Show("Prescription ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cboPhysician.SelectedIndex < 0 OrElse cboPhysician.SelectedValue Is Nothing OrElse TypeOf cboPhysician.SelectedValue Is DataRowView Then
            MessageBox.Show("Physician is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPhysician.Focus()
            Return False
        End If

        If cboPatient.SelectedIndex < 0 OrElse cboPatient.SelectedValue Is Nothing OrElse TypeOf cboPatient.SelectedValue Is DataRowView Then
            MessageBox.Show("Patient is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPatient.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtInstruction.Text) Then
            MessageBox.Show("Instruction is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInstruction.Focus()
            Return False
        End If

        If _selectedMedicines.Count = 0 Then
            MessageBox.Show("Add at least one medicine to the prescription.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMedicine.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub LoadPhysicianAndPatientOptions()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            cboPhysician.DataSource = Nothing
            cboPatient.DataSource = Nothing
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim physicianTable As New DataTable()
                Dim physicianSql As String = "SELECT PhysicianID, CONCAT(FirstName, ' ', LastName, ' (', PhysicianID, ')') AS FullName FROM physician ORDER BY FirstName, LastName"
                Using physicianCmd As New MySqlCommand(physicianSql, conn)
                    Using physicianAdapter As New MySqlDataAdapter(physicianCmd)
                        physicianAdapter.Fill(physicianTable)
                    End Using
                End Using

                cboPhysician.DataSource = physicianTable
                cboPhysician.DisplayMember = "FullName"
                cboPhysician.ValueMember = "PhysicianID"
                cboPhysician.SelectedIndex = -1

                Dim patientTable As New DataTable()
                Dim patientSql As String = "SELECT PatientID, CONCAT(FirstName, ' ', LastName, ' (', PatientID, ')') AS FullName FROM patient ORDER BY FirstName, LastName"
                Using patientCmd As New MySqlCommand(patientSql, conn)
                    Using patientAdapter As New MySqlDataAdapter(patientCmd)
                        patientAdapter.Fill(patientTable)
                    End Using
                End Using

                cboPatient.DataSource = patientTable
                cboPatient.DisplayMember = "FullName"
                cboPatient.ValueMember = "PatientID"
                cboPatient.SelectedIndex = -1
            End Using
        Catch ex As Exception
            cboPhysician.DataSource = Nothing
            cboPatient.DataSource = Nothing
            MessageBox.Show("Unable to load patient and physician names: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMedicineOptions()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            cboMedicine.DataSource = Nothing
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim medicineTable As New DataTable()
                Dim medicineSql As String = "SELECT MedicineID, CONCAT(MedicineName, ' (', MedicineID, ')') AS FullName FROM medicine ORDER BY MedicineName"
                Using medicineCmd As New MySqlCommand(medicineSql, conn)
                    Using medicineAdapter As New MySqlDataAdapter(medicineCmd)
                        medicineAdapter.Fill(medicineTable)
                    End Using
                End Using

                cboMedicine.DataSource = medicineTable
                cboMedicine.DisplayMember = "FullName"
                cboMedicine.ValueMember = "MedicineID"
                cboMedicine.SelectedIndex = -1
            End Using
        Catch ex As Exception
            cboMedicine.DataSource = Nothing
            MessageBox.Show("Unable to load medicines: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadNextPrescriptionId()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            txtPrescriptionID.Text = ""
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim newPrescriptionId As Integer = GetNextAvailablePrescriptionId(conn)
                If newPrescriptionId = -1 Then
                    txtPrescriptionID.Text = ""
                    MessageBox.Show("No available PrescriptionID in range 90001 to 99999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                txtPrescriptionID.Text = newPrescriptionId.ToString()
            End Using
        Catch ex As Exception
            txtPrescriptionID.Text = ""
            MessageBox.Show("Unable to generate prescription ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetNextAvailablePrescriptionId(conn As MySqlConnection) As Integer
        Const minId As Integer = 90001
        Const maxId As Integer = 99999

        Dim candidate As Integer = minId
        Dim sql As String = "SELECT PrescriptionID FROM prescription WHERE PrescriptionID BETWEEN @minId AND @maxId ORDER BY PrescriptionID"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@minId", minId)
            cmd.Parameters.AddWithValue("@maxId", maxId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim usedId As Integer = Convert.ToInt32(reader("PrescriptionID"))

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


