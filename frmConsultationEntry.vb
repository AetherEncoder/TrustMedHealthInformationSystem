Imports MySql.Data.MySqlClient

Public Class frmConsultationEntry
    Private ReadOnly _connectionString As String
    Private ReadOnly _isUpdateMode As Boolean
    Private ReadOnly _existingConsultationId As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String)
        _connectionString = connectionString
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String, consultationId As Integer)
        _connectionString = connectionString
        _isUpdateMode = True
        _existingConsultationId = consultationId
        InitializeComponent()
    End Sub

    Private Sub frmConsultationEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPatientAndPhysicianOptions()

        If _isUpdateMode Then
            Me.Text = "Update Consultation"
            btnSave.Text = "Update"
            LoadConsultationForUpdate()
        Else
            Me.Text = "Add New Consultation"
            btnSave.Text = "Save"
            LoadNextConsultationId()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then Return

        Dim consultationId As Integer
        If Not Integer.TryParse(txtConsultationID.Text.Trim(), consultationId) Then
            MessageBox.Show("Invalid Consultation ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim patientId As Integer = Convert.ToInt32(cboPatient.SelectedValue)
        Dim physicianId As Integer = Convert.ToInt32(cboPhysician.SelectedValue)

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim sql As String
                If _isUpdateMode Then
                    sql = "UPDATE consultation SET PatientID = @PatientID, PhysicianID = @PhysicianID, Complaint = @Complaint, Notes = @Notes, ConsultationDate = @ConsultationDate WHERE ConsultationID = @ConsultationID"
                Else
                    sql = "INSERT INTO consultation (ConsultationID, PatientID, PhysicianID, Complaint, Notes, ConsultationDate) VALUES (@ConsultationID, @PatientID, @PhysicianID, @Complaint, @Notes, @ConsultationDate)"
                End If

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ConsultationID", consultationId)
                    cmd.Parameters.AddWithValue("@PatientID", patientId)
                    cmd.Parameters.AddWithValue("@PhysicianID", physicianId)
                    cmd.Parameters.AddWithValue("@Complaint", txtComplaint.Text.Trim())
                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
                    cmd.Parameters.AddWithValue("@ConsultationDate", dtpConsultationDate.Value.Date)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            If _isUpdateMode Then
                MessageBox.Show("Consultation updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Consultation added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Unable to save consultation: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadConsultationForUpdate()
        If String.IsNullOrWhiteSpace(_connectionString) OrElse _existingConsultationId <= 0 Then
            MessageBox.Show("Unable to load selected consultation.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim sql As String = "SELECT ConsultationID, PatientID, PhysicianID, Complaint, Notes, ConsultationDate FROM consultation WHERE ConsultationID = @ConsultationID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ConsultationID", _existingConsultationId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            MessageBox.Show("Selected consultation was not found.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.DialogResult = DialogResult.Cancel
                            Me.Close()
                            Return
                        End If

                        txtConsultationID.Text = Convert.ToInt32(reader("ConsultationID")).ToString()
                        txtComplaint.Text = reader("Complaint").ToString()
                        txtNotes.Text = reader("Notes").ToString()

                        If Not Convert.IsDBNull(reader("ConsultationDate")) Then
                            dtpConsultationDate.Value = Convert.ToDateTime(reader("ConsultationDate"))
                        End If

                        cboPatient.SelectedValue = Convert.ToInt32(reader("PatientID"))
                        cboPhysician.SelectedValue = Convert.ToInt32(reader("PhysicianID"))
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to load selected consultation: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(_connectionString) Then
            MessageBox.Show("Connection string is not set.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtConsultationID.Text) Then
            MessageBox.Show("Consultation ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cboPatient.SelectedIndex < 0 OrElse cboPatient.SelectedValue Is Nothing OrElse TypeOf cboPatient.SelectedValue Is DataRowView Then
            MessageBox.Show("Patient is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPatient.Focus()
            Return False
        End If

        If cboPhysician.SelectedIndex < 0 OrElse cboPhysician.SelectedValue Is Nothing OrElse TypeOf cboPhysician.SelectedValue Is DataRowView Then
            MessageBox.Show("Physician is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPhysician.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtComplaint.Text) Then
            MessageBox.Show("Complaint is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtComplaint.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtNotes.Text) Then
            MessageBox.Show("Notes are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNotes.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub LoadPatientAndPhysicianOptions()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            cboPatient.DataSource = Nothing
            cboPhysician.DataSource = Nothing
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

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
            End Using
        Catch ex As Exception
            cboPatient.DataSource = Nothing
            cboPhysician.DataSource = Nothing
            MessageBox.Show("Unable to load patient and physician names: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadNextConsultationId()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            txtConsultationID.Text = ""
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim newConsultationId As Integer = GetNextAvailableConsultationId(conn)
                If newConsultationId = -1 Then
                    txtConsultationID.Text = ""
                    MessageBox.Show("No available ConsultationID in range 30001 to 39999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                txtConsultationID.Text = newConsultationId.ToString()
            End Using
        Catch ex As Exception
            txtConsultationID.Text = ""
            MessageBox.Show("Unable to generate consultation ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetNextAvailableConsultationId(conn As MySqlConnection) As Integer
        Const minId As Integer = 30001
        Const maxId As Integer = 39999

        Dim candidate As Integer = minId
        Dim sql As String = "SELECT ConsultationID FROM consultation WHERE ConsultationID BETWEEN @minId AND @maxId ORDER BY ConsultationID"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@minId", minId)
            cmd.Parameters.AddWithValue("@maxId", maxId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim usedId As Integer = Convert.ToInt32(reader("ConsultationID"))

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