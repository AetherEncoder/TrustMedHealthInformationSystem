Imports MySql.Data.MySqlClient

Public Class frmExaminationEntry
    Private ReadOnly _connectionString As String
    Private ReadOnly _selectedLabTests As New List(Of LabTestSelectionItem)()
    Private ReadOnly _selectedMedTechs As New List(Of MedTechSelectionItem)()
    Private ReadOnly _isUpdateMode As Boolean
    Private ReadOnly _existingExaminationId As Integer

    Private Class LabTestSelectionItem
        Public Property TestID As Integer
        Public Property DisplayName As String

        Public Overrides Function ToString() As String
            Return DisplayName
        End Function
    End Class

    Private Class MedTechSelectionItem
        Public Property MedTechID As Integer
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

    Public Sub New(connectionString As String, examinationId As Integer)
        _connectionString = connectionString
        _isUpdateMode = True
        _existingExaminationId = examinationId
        InitializeComponent()
    End Sub

    Private Sub frmExaminationEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPatientOptions()
        LoadLabTestOptions()
        LoadMedTechOptions()
        RefreshSelectedLabTestsList()
        RefreshSelectedMedTechsList()

        If _isUpdateMode Then
            Me.Text = "Update Examination"
            btnSave.Text = "Update"
            btnSave.BackColor = Color.FromArgb(217, 92, 128)
            LoadExaminationForUpdate()
        Else
            Me.Text = "Add New Examination"
            btnSave.Text = "Save"
            btnSave.BackColor = Color.FromArgb(184, 19, 66)
            LoadNextExaminationId()
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAddLabTest_Click(sender As Object, e As EventArgs) Handles btnAddLabTest.Click
        If cboLabTest.SelectedIndex < 0 OrElse cboLabTest.SelectedValue Is Nothing OrElse TypeOf cboLabTest.SelectedValue Is DataRowView Then
            MessageBox.Show("Select a laboratory test to add.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLabTest.Focus()
            Return
        End If

        Dim testId As Integer = Convert.ToInt32(cboLabTest.SelectedValue)
        If IsLabTestAlreadySelected(testId) Then
            MessageBox.Show("Laboratory test is already added.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        _selectedLabTests.Add(New LabTestSelectionItem With {
            .TestID = testId,
            .DisplayName = cboLabTest.Text.Trim()
        })

        RefreshSelectedLabTestsList()
        cboLabTest.SelectedIndex = -1
        cboLabTest.Focus()
    End Sub

    Private Sub btnRemoveLabTest_Click(sender As Object, e As EventArgs) Handles btnRemoveLabTest.Click
        If lstSelectedLabTests.SelectedItem Is Nothing Then
            MessageBox.Show("Select a laboratory test from the list to remove.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lstSelectedLabTests.Focus()
            Return
        End If

        Dim selectedItem As LabTestSelectionItem = TryCast(lstSelectedLabTests.SelectedItem, LabTestSelectionItem)
        If selectedItem Is Nothing Then Return

        For i As Integer = _selectedLabTests.Count - 1 To 0 Step -1
            If _selectedLabTests(i).TestID = selectedItem.TestID Then
                _selectedLabTests.RemoveAt(i)
                Exit For
            End If
        Next

        RefreshSelectedLabTestsList()
    End Sub

    Private Sub btnAddMedTech_Click(sender As Object, e As EventArgs) Handles btnAddMedTech.Click
        If cboMedTech.SelectedIndex < 0 OrElse cboMedTech.SelectedValue Is Nothing OrElse TypeOf cboMedTech.SelectedValue Is DataRowView Then
            MessageBox.Show("Select a MedTech to add.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMedTech.Focus()
            Return
        End If

        Dim medTechId As Integer = Convert.ToInt32(cboMedTech.SelectedValue)
        If IsMedTechAlreadySelected(medTechId) Then
            MessageBox.Show("MedTech is already added.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        _selectedMedTechs.Add(New MedTechSelectionItem With {
            .MedTechID = medTechId,
            .DisplayName = cboMedTech.Text.Trim()
        })

        RefreshSelectedMedTechsList()
        cboMedTech.SelectedIndex = -1
        cboMedTech.Focus()
    End Sub

    Private Sub btnRemoveMedTech_Click(sender As Object, e As EventArgs) Handles btnRemoveMedTech.Click
        If lstSelectedMedTechs.SelectedItem Is Nothing Then
            MessageBox.Show("Select a MedTech from the list to remove.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lstSelectedMedTechs.Focus()
            Return
        End If

        Dim selectedItem As MedTechSelectionItem = TryCast(lstSelectedMedTechs.SelectedItem, MedTechSelectionItem)
        If selectedItem Is Nothing Then Return

        For i As Integer = _selectedMedTechs.Count - 1 To 0 Step -1
            If _selectedMedTechs(i).MedTechID = selectedItem.MedTechID Then
                _selectedMedTechs.RemoveAt(i)
                Exit For
            End If
        Next

        RefreshSelectedMedTechsList()
    End Sub

    Private Function IsLabTestAlreadySelected(testId As Integer) As Boolean
        For Each item As LabTestSelectionItem In _selectedLabTests
            If item.TestID = testId Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function IsMedTechAlreadySelected(medTechId As Integer) As Boolean
        For Each item As MedTechSelectionItem In _selectedMedTechs
            If item.MedTechID = medTechId Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub RefreshSelectedLabTestsList()
        lstSelectedLabTests.Items.Clear()

        For Each item As LabTestSelectionItem In _selectedLabTests
            lstSelectedLabTests.Items.Add(item)
        Next
    End Sub

    Private Sub RefreshSelectedMedTechsList()
        lstSelectedMedTechs.Items.Clear()

        For Each item As MedTechSelectionItem In _selectedMedTechs
            lstSelectedMedTechs.Items.Add(item)
        Next
    End Sub

    Private Sub LoadExaminationForUpdate()
        If String.IsNullOrWhiteSpace(_connectionString) OrElse _existingExaminationId <= 0 Then
            MessageBox.Show("Unable to load selected examination.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim examSql As String = "SELECT ExaminationID, PatientID, Result, DatePerformed FROM examination WHERE ExaminationID = @ExaminationID"
                Using examCmd As New MySqlCommand(examSql, conn)
                    examCmd.Parameters.AddWithValue("@ExaminationID", _existingExaminationId)

                    Using reader As MySqlDataReader = examCmd.ExecuteReader()
                        If Not reader.Read() Then
                            MessageBox.Show("Selected examination was not found.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.DialogResult = DialogResult.Cancel
                            Me.Close()
                            Return
                        End If

                        txtExaminationID.Text = Convert.ToInt32(reader("ExaminationID")).ToString()
                        txtResult.Text = reader("Result").ToString()
                        cboPatient.SelectedValue = Convert.ToInt32(reader("PatientID"))

                        If Not Convert.IsDBNull(reader("DatePerformed")) Then
                            dtpDatePerformed.Value = Convert.ToDateTime(reader("DatePerformed"))
                        End If
                    End Using
                End Using

                _selectedLabTests.Clear()
                Dim testsSql As String = "SELECT mt.TestID, CONCAT(mt.TestName, ' (', mt.TestID, ')') AS FullName FROM exam_inclusion ei INNER JOIN medical_test mt ON mt.TestID = ei.TestID WHERE ei.ExaminationID = @ExaminationID ORDER BY mt.TestName"
                Using testsCmd As New MySqlCommand(testsSql, conn)
                    testsCmd.Parameters.AddWithValue("@ExaminationID", _existingExaminationId)

                    Using reader As MySqlDataReader = testsCmd.ExecuteReader()
                        While reader.Read()
                            _selectedLabTests.Add(New LabTestSelectionItem With {
                                .TestID = Convert.ToInt32(reader("TestID")),
                                .DisplayName = reader("FullName").ToString()
                            })
                        End While
                    End Using
                End Using

                _selectedMedTechs.Clear()
                Dim medTechSql As String = "SELECT md.MedtechID, CONCAT(md.FirstName, ' ', md.LastName, ' (', md.MedtechID, ')') AS FullName FROM performance pf INNER JOIN medtech md ON md.MedtechID = pf.MedtechID WHERE pf.ExaminationID = @ExaminationID ORDER BY md.FirstName, md.LastName"
                Using medTechCmd As New MySqlCommand(medTechSql, conn)
                    medTechCmd.Parameters.AddWithValue("@ExaminationID", _existingExaminationId)

                    Using reader As MySqlDataReader = medTechCmd.ExecuteReader()
                        While reader.Read()
                            _selectedMedTechs.Add(New MedTechSelectionItem With {
                                .MedTechID = Convert.ToInt32(reader("MedtechID")),
                                .DisplayName = reader("FullName").ToString()
                            })
                        End While
                    End Using
                End Using

                RefreshSelectedLabTestsList()
                RefreshSelectedMedTechsList()
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to load selected examination: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then
            Return
        End If

        Dim examinationId As Integer
        If Not Integer.TryParse(txtExaminationID.Text.Trim(), examinationId) Then
            MessageBox.Show("Invalid Examination ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim patientId As Integer = Convert.ToInt32(cboPatient.SelectedValue)

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                If _isUpdateMode Then
                    Dim updateSql As String = "UPDATE examination SET PatientID = @PatientID, Result = @Result, DatePerformed = @DatePerformed WHERE ExaminationID = @ExaminationID"
                    Using updateCmd As New MySqlCommand(updateSql, conn)
                        updateCmd.Parameters.AddWithValue("@ExaminationID", _existingExaminationId)
                        updateCmd.Parameters.AddWithValue("@PatientID", patientId)
                        updateCmd.Parameters.AddWithValue("@Result", txtResult.Text.Trim())
                        updateCmd.Parameters.AddWithValue("@DatePerformed", dtpDatePerformed.Value.Date)
                        updateCmd.ExecuteNonQuery()
                    End Using

                    Dim deleteInclusionSql As String = "DELETE FROM exam_inclusion WHERE ExaminationID = @ExaminationID"
                    Using deleteInclusionCmd As New MySqlCommand(deleteInclusionSql, conn)
                        deleteInclusionCmd.Parameters.AddWithValue("@ExaminationID", _existingExaminationId)
                        deleteInclusionCmd.ExecuteNonQuery()
                    End Using

                    Dim deletePerformanceSql As String = "DELETE FROM performance WHERE ExaminationID = @ExaminationID"
                    Using deletePerformanceCmd As New MySqlCommand(deletePerformanceSql, conn)
                        deletePerformanceCmd.Parameters.AddWithValue("@ExaminationID", _existingExaminationId)
                        deletePerformanceCmd.ExecuteNonQuery()
                    End Using
                Else
                    Dim examSql As String = "INSERT INTO examination (ExaminationID, PatientID, Result, DatePerformed) VALUES (@ExaminationID, @PatientID, @Result, @DatePerformed)"
                    Using examCmd As New MySqlCommand(examSql, conn)
                        examCmd.Parameters.AddWithValue("@ExaminationID", examinationId)
                        examCmd.Parameters.AddWithValue("@PatientID", patientId)
                        examCmd.Parameters.AddWithValue("@Result", txtResult.Text.Trim())
                        examCmd.Parameters.AddWithValue("@DatePerformed", dtpDatePerformed.Value.Date)
                        examCmd.ExecuteNonQuery()
                    End Using
                End If

                Dim inclusionSql As String = "INSERT INTO exam_inclusion (TestID, ExaminationID) VALUES (@TestID, @ExaminationID)"
                For Each labTest As LabTestSelectionItem In _selectedLabTests
                    Using inclusionCmd As New MySqlCommand(inclusionSql, conn)
                        inclusionCmd.Parameters.AddWithValue("@TestID", labTest.TestID)
                        inclusionCmd.Parameters.AddWithValue("@ExaminationID", examinationId)
                        inclusionCmd.ExecuteNonQuery()
                    End Using
                Next

                Dim performanceSql As String = "INSERT INTO performance (MedtechID, ExaminationID) VALUES (@MedtechID, @ExaminationID)"
                For Each medTech As MedTechSelectionItem In _selectedMedTechs
                    Using performanceCmd As New MySqlCommand(performanceSql, conn)
                        performanceCmd.Parameters.AddWithValue("@MedtechID", medTech.MedTechID)
                        performanceCmd.Parameters.AddWithValue("@ExaminationID", examinationId)
                        performanceCmd.ExecuteNonQuery()
                    End Using
                Next
            End Using

            MessageBox.Show("Examination " & If(_isUpdateMode, "updated", "added") & " successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Unable to save examination: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(_connectionString) Then
            MessageBox.Show("Connection string is not set.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtExaminationID.Text) Then
            MessageBox.Show("Examination ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cboPatient.SelectedIndex < 0 OrElse cboPatient.SelectedValue Is Nothing OrElse TypeOf cboPatient.SelectedValue Is DataRowView Then
            MessageBox.Show("Patient is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPatient.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtResult.Text) Then
            MessageBox.Show("Result is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtResult.Focus()
            Return False
        End If

        If _selectedLabTests.Count = 0 Then
            MessageBox.Show("Add at least one laboratory test.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLabTest.Focus()
            Return False
        End If

        If _selectedMedTechs.Count = 0 Then
            MessageBox.Show("Add at least one MedTech performer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMedTech.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub LoadPatientOptions()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            cboPatient.DataSource = Nothing
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim patientTable As New DataTable()
                Dim patientSql As String = "SELECT PatientID, CONCAT(FirstName, ' ', LastName, ' (', PatientID, ')') AS FullName FROM patient ORDER BY FirstName, LastName"
                Using cmd As New MySqlCommand(patientSql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(patientTable)
                    End Using
                End Using

                cboPatient.DataSource = patientTable
                cboPatient.DisplayMember = "FullName"
                cboPatient.ValueMember = "PatientID"
                cboPatient.SelectedIndex = -1
            End Using
        Catch ex As Exception
            cboPatient.DataSource = Nothing
            MessageBox.Show("Unable to load patients: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadLabTestOptions()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            cboLabTest.DataSource = Nothing
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim labTestTable As New DataTable()
                Dim labTestSql As String = "SELECT TestID, CONCAT(TestName, ' (', TestID, ')') AS FullName FROM medical_test ORDER BY TestName"
                Using cmd As New MySqlCommand(labTestSql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(labTestTable)
                    End Using
                End Using

                cboLabTest.DataSource = labTestTable
                cboLabTest.DisplayMember = "FullName"
                cboLabTest.ValueMember = "TestID"
                cboLabTest.SelectedIndex = -1
            End Using
        Catch ex As Exception
            cboLabTest.DataSource = Nothing
            MessageBox.Show("Unable to load laboratory tests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMedTechOptions()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            cboMedTech.DataSource = Nothing
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim medTechTable As New DataTable()
                Dim medTechSql As String = "SELECT MedtechID, CONCAT(FirstName, ' ', LastName, ' (', MedtechID, ')') AS FullName FROM medtech ORDER BY FirstName, LastName"
                Using cmd As New MySqlCommand(medTechSql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(medTechTable)
                    End Using
                End Using

                cboMedTech.DataSource = medTechTable
                cboMedTech.DisplayMember = "FullName"
                cboMedTech.ValueMember = "MedtechID"
                cboMedTech.SelectedIndex = -1
            End Using
        Catch ex As Exception
            cboMedTech.DataSource = Nothing
            MessageBox.Show("Unable to load MedTechs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadNextExaminationId()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            txtExaminationID.Text = ""
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim newExaminationId As Integer = GetNextAvailableExaminationId(conn)
                If newExaminationId = -1 Then
                    txtExaminationID.Text = ""
                    MessageBox.Show("No available ExaminationID in range 80001 to 89999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                txtExaminationID.Text = newExaminationId.ToString()
            End Using
        Catch ex As Exception
            txtExaminationID.Text = ""
            MessageBox.Show("Unable to generate examination ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetNextAvailableExaminationId(conn As MySqlConnection) As Integer
        Const minId As Integer = 80001
        Const maxId As Integer = 89999

        Dim candidate As Integer = minId
        Dim sql As String = "SELECT ExaminationID FROM examination WHERE ExaminationID BETWEEN @minId AND @maxId ORDER BY ExaminationID"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@minId", minId)
            cmd.Parameters.AddWithValue("@maxId", maxId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim usedId As Integer = Convert.ToInt32(reader("ExaminationID"))
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
