Imports MySql.Data.MySqlClient

Public Class frmDiagnosisEntry
    Private ReadOnly _connectionString As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(connectionString As String)
        _connectionString = connectionString
        InitializeComponent()
    End Sub

    Private Sub frmDiagnosisEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadNextDiagnosisId()
        LoadPatientAndPhysicianOptions()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then Return

        Dim diagnosisId As Integer
        If Not Integer.TryParse(txtDiagnosisID.Text.Trim(), diagnosisId) Then
            MessageBox.Show("Invalid Diagnosis ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim patientId As Integer = Convert.ToInt32(cboPatient.SelectedValue)
        Dim physicianId As Integer = Convert.ToInt32(cboPhysician.SelectedValue)

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim sql As String = "INSERT INTO diagnosis (DiagnosisID, PatientID, PhysicianID, DiagnosisName, DiagnosisDescription, DiagnosisDate) " &
                                    "VALUES (@DiagnosisID, @PatientID, @PhysicianID, @DiagnosisName, @DiagnosisDescription, @DiagnosisDate)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@DiagnosisID", diagnosisId)
                    cmd.Parameters.AddWithValue("@PatientID", patientId)
                    cmd.Parameters.AddWithValue("@PhysicianID", physicianId)
                    cmd.Parameters.AddWithValue("@DiagnosisName", txtDiagnosisName.Text.Trim())
                    cmd.Parameters.AddWithValue("@DiagnosisDescription", txtDiagnosisDescription.Text.Trim())
                    cmd.Parameters.AddWithValue("@DiagnosisDate", dtpDiagnosisDate.Value.Date)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Diagnosis added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Unable to save diagnosis: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(_connectionString) Then
            MessageBox.Show("Connection string is not set.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtDiagnosisID.Text) Then
            MessageBox.Show("Diagnosis ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        If String.IsNullOrWhiteSpace(txtDiagnosisName.Text) Then
            MessageBox.Show("Diagnosis name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDiagnosisName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtDiagnosisDescription.Text) Then
            MessageBox.Show("Diagnosis description is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDiagnosisDescription.Focus()
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

    Private Sub LoadNextDiagnosisId()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            txtDiagnosisID.Text = ""
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim newDiagnosisId As Integer = GetNextAvailableDiagnosisId(conn)
                If newDiagnosisId = -1 Then
                    txtDiagnosisID.Text = ""
                    MessageBox.Show("No available DiagnosisID in range 20001 to 29999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                txtDiagnosisID.Text = newDiagnosisId.ToString()
            End Using
        Catch ex As Exception
            txtDiagnosisID.Text = ""
            MessageBox.Show("Unable to generate diagnosis ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetNextAvailableDiagnosisId(conn As MySqlConnection) As Integer
        Const minId As Integer = 20001
        Const maxId As Integer = 29999

        Dim candidate As Integer = minId
        Dim sql As String = "SELECT DiagnosisID FROM diagnosis WHERE DiagnosisID BETWEEN @minId AND @maxId ORDER BY DiagnosisID"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@minId", minId)
            cmd.Parameters.AddWithValue("@maxId", maxId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim usedId As Integer = Convert.ToInt32(reader("DiagnosisID"))

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