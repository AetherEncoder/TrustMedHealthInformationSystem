Imports MySql.Data.MySqlClient

Partial Class frmLabOrderEntry
    Private ReadOnly _connectionString As String
    Private ReadOnly _selectedTests As New List(Of LabTestSelectionItem)()

    Private Class LabTestSelectionItem
        Public Property TestID As Integer
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

    Private Sub frmLabOrderEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadNextOrderId()
        LoadPhysicianAndPatientOptions()
        LoadMedicalTestOptions()
        RefreshSelectedTestsList()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAddMedicalTest_Click(sender As Object, e As EventArgs) Handles btnAddMedicalTest.Click
        If cboMedicalTest.SelectedIndex < 0 OrElse cboMedicalTest.SelectedValue Is Nothing OrElse TypeOf cboMedicalTest.SelectedValue Is DataRowView Then
            MessageBox.Show("Select a medical test to add.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMedicalTest.Focus()
            Return
        End If

        Dim testId As Integer = Convert.ToInt32(cboMedicalTest.SelectedValue)
        If IsTestSelected(testId) Then
            MessageBox.Show("Medical test is already added.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        _selectedTests.Add(New LabTestSelectionItem With {
            .TestID = testId,
            .DisplayName = cboMedicalTest.Text.Trim()
        })

        RefreshSelectedTestsList()
        cboMedicalTest.SelectedIndex = -1
        cboMedicalTest.Focus()
    End Sub

    Private Sub btnRemoveMedicalTest_Click(sender As Object, e As EventArgs) Handles btnRemoveMedicalTest.Click
        If lstSelectedTests.SelectedItem Is Nothing Then
            MessageBox.Show("Select a medical test from the list to remove.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lstSelectedTests.Focus()
            Return
        End If

        Dim selectedItem As LabTestSelectionItem = TryCast(lstSelectedTests.SelectedItem, LabTestSelectionItem)
        If selectedItem Is Nothing Then Return

        For i As Integer = _selectedTests.Count - 1 To 0 Step -1
            If _selectedTests(i).TestID = selectedItem.TestID Then
                _selectedTests.RemoveAt(i)
                Exit For
            End If
        Next

        RefreshSelectedTestsList()
    End Sub

    Private Function IsTestSelected(testId As Integer) As Boolean
        For Each item As LabTestSelectionItem In _selectedTests
            If item.TestID = testId Then Return True
        Next

        Return False
    End Function

    Private Sub RefreshSelectedTestsList()
        lstSelectedTests.Items.Clear()

        For Each item As LabTestSelectionItem In _selectedTests
            lstSelectedTests.Items.Add(item)
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then
            Return
        End If

        Dim orderId As Integer

        If Not Integer.TryParse(txtOrderID.Text.Trim(), orderId) Then
            MessageBox.Show("Invalid Order ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim physicianId As Integer = Convert.ToInt32(cboPhysician.SelectedValue)
        Dim patientId As Integer = Convert.ToInt32(cboPatient.SelectedValue)

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim sql As String = "INSERT INTO lab_order (OrderID, PhysicianID, PatientID, OrderDate) VALUES (@OrderID, @PhysicianID, @PatientID, @OrderDate)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@OrderID", orderId)
                    cmd.Parameters.AddWithValue("@PhysicianID", physicianId)
                    cmd.Parameters.AddWithValue("@PatientID", patientId)
                    cmd.Parameters.AddWithValue("@OrderDate", dtpOrderDate.Value.Date)
                    cmd.ExecuteNonQuery()
                End Using

                Dim inclusionSql As String = "INSERT INTO lab_order_inclusion (TestID, OrderID) VALUES (@TestID, @OrderID)"
                For Each testItem As LabTestSelectionItem In _selectedTests
                    Using inclusionCmd As New MySqlCommand(inclusionSql, conn)
                        inclusionCmd.Parameters.AddWithValue("@TestID", testItem.TestID)
                        inclusionCmd.Parameters.AddWithValue("@OrderID", orderId)
                        inclusionCmd.ExecuteNonQuery()
                    End Using
                Next
            End Using

            MessageBox.Show("Lab order added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Unable to save lab order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(_connectionString) Then
            MessageBox.Show("Connection string is not set.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtOrderID.Text) Then
            MessageBox.Show("Order ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        If _selectedTests.Count = 0 Then
            MessageBox.Show("Add at least one medical test.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMedicalTest.Focus()
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

    Private Sub LoadNextOrderId()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            txtOrderID.Text = ""
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim newOrderId As Integer = GetNextAvailableOrderId(conn)
                If newOrderId = -1 Then
                    txtOrderID.Text = ""
                    MessageBox.Show("No available OrderID in range 70001 to 79999.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                txtOrderID.Text = newOrderId.ToString()
            End Using
        Catch ex As Exception
            txtOrderID.Text = ""
            MessageBox.Show("Unable to generate lab order ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetNextAvailableOrderId(conn As MySqlConnection) As Integer
        Const minId As Integer = 70001
        Const maxId As Integer = 79999

        Dim candidate As Integer = minId
        Dim sql As String = "SELECT OrderID FROM lab_order WHERE OrderID BETWEEN @minId AND @maxId ORDER BY OrderID"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@minId", minId)
            cmd.Parameters.AddWithValue("@maxId", maxId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim usedId As Integer = Convert.ToInt32(reader("OrderID"))

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

    Private Sub LoadMedicalTestOptions()
        If String.IsNullOrWhiteSpace(_connectionString) Then
            cboMedicalTest.DataSource = Nothing
            Return
        End If

        Try
            Using conn As New MySqlConnection(_connectionString)
                conn.Open()

                Dim testTable As New DataTable()
                Dim testSql As String = "SELECT TestID, CONCAT(TestName, ' (', TestID, ')') AS FullName FROM medical_test ORDER BY TestName"
                Using testCmd As New MySqlCommand(testSql, conn)
                    Using testAdapter As New MySqlDataAdapter(testCmd)
                        testAdapter.Fill(testTable)
                    End Using
                End Using

                cboMedicalTest.DataSource = testTable
                cboMedicalTest.DisplayMember = "FullName"
                cboMedicalTest.ValueMember = "TestID"
                cboMedicalTest.SelectedIndex = -1
            End Using
        Catch ex As Exception
            cboMedicalTest.DataSource = Nothing
            MessageBox.Show("Unable to load medical tests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class