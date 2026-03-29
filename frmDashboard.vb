Imports System.Data
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmDashboard
    'Create connection variable/object named "MyConnection" 
    Dim MyConnection As Common.DbConnection

    'Create a Data Adapter variable/object
    '---A Data Adapter is the go-between for the connection object (MyConnection)
    'and the Dataset (borrowerDA)
    Dim userDA As New MySqlDataAdapter

    'Create a Dataset variable/object
    '---A Data Set is a place holder for the table in your database
    '---There should be one data set for each table in your database
    Dim userDS As New DataSet()

    'Declare the connection string and query variables/objects
    Dim MyConnectionString As String
    Dim userSQLQuery As String

    'We will use this later in the update and delete modules
    Dim row As Integer
    Private currentSectionName As String = "Patients"
    Private currentSectionSingular As String = "Patient"
    Private currentSectionKey As String = "patients"

    Private patientsSectionInitialized As Boolean = False
    Private pnlPatientsSection As Panel
    Private grpPatientOptions As GroupBox
    Private grpPatientList As GroupBox
    Private dgvPatients As DataGridView
    Private btnAddPatient As Button
    Private btnDeletePatient As Button
    Private btnUpdatePatient As Button

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyConnectionString = "datasource=localhost;username=root;password=;database=trustmed"

        Dim logoCandidates As String() = {
            Path.Combine(Application.StartupPath, "src\TrustMed.png"),
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\src\TrustMed.png")),
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\src\TrustMed.png"))
        }

        For Each logoPath As String In logoCandidates
            If File.Exists(logoPath) Then
                pbTrustMedLogo.Image = Image.FromFile(logoPath)
                Exit For
            End If
        Next

        If pbTrustMedLogo.Image Is Nothing AndAlso Me.Icon IsNot Nothing Then
            pbTrustMedLogo.Image = Me.Icon.ToBitmap()
        End If

        InitializePatientsSectionUi()
        ClearErrorMessages()
        ApplyGridWrapping(Me)
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ClearErrorMessages()

        Dim isValid As Boolean = True

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            lblUsernameError.Text = "Username is required"
            lblUsernameError.Visible = True
            txtUsername.Focus()
            isValid = False
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            lblPasswordError.Text = "Password is required"
            lblPasswordError.Visible = True
            If isValid Then
                txtPassword.Focus()
            End If
            isValid = False
        End If

        If isValid Then
            userSQLQuery = "SELECT * FROM USER WHERE username = @username AND password = @password"
            MyConnection = New MySqlConnection(MyConnectionString)

            Try
                MyConnection.Open()
                Dim cmd As New MySqlCommand(userSQLQuery, CType(MyConnection, MySqlConnection))
                cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                cmd.Parameters.AddWithValue("@password", txtPassword.Text)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.HasRows Then
                    reader.Close()
                    ShowDashboard()
                Else
                    lblLoginError.Text = "Invalid username or password."
                    lblLoginError.Visible = True
                End If

                reader.Close()

            Catch ex As MySqlException
                lblLoginError.Text = "Database error: " & ex.Message
                lblLoginError.Visible = True
            Catch ex As Exception
                lblLoginError.Text = "An unexpected error occurred: " & ex.Message
                lblLoginError.Visible = True
            Finally
                If MyConnection IsNot Nothing AndAlso MyConnection.State = ConnectionState.Open Then
                    MyConnection.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub miAccountLogout_Click(sender As Object, e As EventArgs) Handles miAccountLogout.Click
        ShowLoginPage()
    End Sub

    Private Sub btnNewPatient_Click(sender As Object, e As EventArgs) Handles btnNewPatient.Click
        OpenPatientEntryDialog()
    End Sub

    Private Sub btnNewDiagnosis_Click(sender As Object, e As EventArgs) Handles btnNewDiagnosis.Click
        OpenDiagnosisEntryDialog()
    End Sub

    Private Sub btnNewConsultation_Click(sender As Object, e As EventArgs) Handles btnNewConsultation.Click
        OpenConsultationEntryDialog()
    End Sub

    Private Sub btnNewLabOrder_Click(sender As Object, e As EventArgs) Handles btnNewLabOrder.Click
        OpenLabOrderEntryDialog()
    End Sub

    Private Sub btnNewPrescription_Click(sender As Object, e As EventArgs) Handles btnNewPrescription.Click
        OpenPrescriptionEntryDialog()
    End Sub

    Private Sub ShowQuickActionPlaceholder(actionName As String)
        MessageBox.Show(actionName & " form will be connected in the next module.", "Quick Action", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ShowDashboard()
        pnlLoginContainer.Visible = False
        pnlDashboard.Visible = True

        txtUsername.Text = ""
        txtPassword.Text = ""
        ClearErrorMessages()

        ShowDashboardHome()
        LoadDashboardOverview()
    End Sub

    Private Sub ShowLoginPage()
        pnlDashboard.Visible = False
        pnlLoginContainer.Visible = True

        txtUsername.Text = ""
        txtPassword.Text = ""
        ClearErrorMessages()

        txtUsername.Focus()
    End Sub

    Private Sub ClearErrorMessages()
        lblUsernameError.Visible = False
        lblUsernameError.Text = ""
        lblPasswordError.Visible = False
        lblPasswordError.Text = ""
        lblLoginError.Visible = False
        lblLoginError.Text = ""
    End Sub

    Private Sub LoadDashboardOverview()
        Try
            MyConnection = New MySqlConnection(MyConnectionString)
            MyConnection.Open()

            userSQLQuery = "SELECT COUNT(*) FROM patient"
            Dim cmd As New MySqlCommand(userSQLQuery, CType(MyConnection, MySqlConnection))
            lblTotalPatientsValue.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString()

            userSQLQuery = "SELECT COUNT(*) FROM lab_order"
            cmd = New MySqlCommand(userSQLQuery, CType(MyConnection, MySqlConnection))
            lblLabOrdersValue.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString()

        Catch ex As MySqlException
            lblTotalPatientsValue.Text = "0"
            lblLabOrdersValue.Text = "0"
        Catch ex As Exception
            lblTotalPatientsValue.Text = "0"
            lblLabOrdersValue.Text = "0"
        Finally
            If MyConnection IsNot Nothing AndAlso MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
            End If
        End Try
    End Sub

    Private Function ExecuteCountQuerySafe(primaryQuery As String, Optional fallbackQuery As String = "") As Integer
        Try
            userSQLQuery = primaryQuery
            Dim cmd As New MySqlCommand(userSQLQuery, CType(MyConnection, MySqlConnection))
            Return Convert.ToInt32(cmd.ExecuteScalar())
        Catch
            If fallbackQuery <> "" Then
                Try
                    userSQLQuery = fallbackQuery
                    Dim cmd As New MySqlCommand(userSQLQuery, CType(MyConnection, MySqlConnection))
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                Catch
                    Return 0
                End Try
            End If

            Return 0
        End Try
    End Function

    Private Function ExecuteTableQuerySafe(query As String, emptyMessage As String) As DataTable
        Try
            Dim dt As New DataTable()
            userDA = New MySqlDataAdapter(query, CType(MyConnection, MySqlConnection))
            userDA.Fill(dt)

            If dt.Rows.Count = 0 Then
                Return CreateInfoTable(emptyMessage)
            End If

            Return dt
        Catch
            Return CreateInfoTable(emptyMessage)
        End Try
    End Function

    Private Function CreateInfoTable(message As String) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Info", GetType(String))
        dt.Rows.Add(message)
        Return dt
    End Function

    Private Function TableExists(tableName As String) As Boolean
        userSQLQuery = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = DATABASE() AND table_name = @tableName"
        Using cmd As New MySqlCommand(userSQLQuery, CType(MyConnection, MySqlConnection))
            cmd.Parameters.AddWithValue("@tableName", tableName)
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Private Function GetFirstExistingColumn(tableName As String, candidates As String()) As String
        For Each columnName As String In candidates
            userSQLQuery = "SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = DATABASE() AND table_name = @tableName AND column_name = @columnName"
            Using cmd As New MySqlCommand(userSQLQuery, CType(MyConnection, MySqlConnection))
                cmd.Parameters.AddWithValue("@tableName", tableName)
                cmd.Parameters.AddWithValue("@columnName", columnName)
                If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                    Return columnName
                End If
            End Using
        Next

        Return ""
    End Function

    Private Sub pbTrustMedLogo_Click(sender As Object, e As EventArgs) Handles pbTrustMedLogo.Click

    End Sub

    Private Sub ShowDashboardHome()
        pnlSummaryCards.Visible = True
        grpQuickActions.Visible = True
        If pnlPatientsSection IsNot Nothing Then
            pnlPatientsSection.Visible = False
        End If
    End Sub

    Private Sub miDashboard_Click(sender As Object, e As EventArgs) Handles miDashboard.Click
        ShowDashboardHome()
    End Sub

    Private Sub miPatients_Click(sender As Object, e As EventArgs) Handles miPatients.Click
        ShowEntitySection("patients")
    End Sub

    Private Sub InitializePatientsSectionUi()
        If patientsSectionInitialized Then Return

        pnlPatientsSection = New Panel()
        pnlPatientsSection.Location = New Point(12, 39)
        pnlPatientsSection.Size = New Size(1324, 678)
        pnlPatientsSection.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlPatientsSection.Visible = False

        grpPatientOptions = New GroupBox()
        grpPatientOptions.Text = "Patient Options"
        grpPatientOptions.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Bold)
        grpPatientOptions.ForeColor = Color.DarkBlue
        grpPatientOptions.Location = New Point(0, 0)
        grpPatientOptions.Size = New Size(260, 678)

        btnAddPatient = New Button()
        btnAddPatient.Text = "Add New Patient"
        btnAddPatient.BackColor = Color.DarkBlue
        btnAddPatient.ForeColor = Color.White
        btnAddPatient.Size = New Size(224, 48)
        btnAddPatient.Location = New Point(18, 44)
        AddHandler btnAddPatient.Click, AddressOf BtnAddPatient_Click

        btnDeletePatient = New Button()
        btnDeletePatient.Text = "Delete Patient"
        btnDeletePatient.BackColor = Color.Gray
        btnDeletePatient.ForeColor = Color.White
        btnDeletePatient.Size = New Size(224, 48)
        btnDeletePatient.Location = New Point(18, 104)
        AddHandler btnDeletePatient.Click, AddressOf BtnDeletePatient_Click

        btnUpdatePatient = New Button()
        btnUpdatePatient.Text = "Update Patient"
        btnUpdatePatient.BackColor = Color.SteelBlue
        btnUpdatePatient.ForeColor = Color.White
        btnUpdatePatient.Size = New Size(224, 48)
        btnUpdatePatient.Location = New Point(18, 164)
        AddHandler btnUpdatePatient.Click, AddressOf BtnUpdatePatient_Click

        grpPatientOptions.Controls.Add(btnAddPatient)
        grpPatientOptions.Controls.Add(btnDeletePatient)
        grpPatientOptions.Controls.Add(btnUpdatePatient)

        grpPatientList = New GroupBox()
        grpPatientList.Text = "Patients"
        grpPatientList.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Bold)
        grpPatientList.ForeColor = Color.DarkBlue
        grpPatientList.Location = New Point(268, 0)
        grpPatientList.Size = New Size(1056, 678)
        grpPatientList.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

        dgvPatients = New DataGridView()
        dgvPatients.Location = New Point(10, 24)
        dgvPatients.Size = New Size(1036, 644)
        dgvPatients.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvPatients.AllowUserToAddRows = False
        dgvPatients.AllowUserToDeleteRows = False
        dgvPatients.ReadOnly = True
        dgvPatients.RowHeadersVisible = False
        dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPatients.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvPatients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        grpPatientList.Controls.Add(dgvPatients)

        pnlPatientsSection.Controls.Add(grpPatientList)
        pnlPatientsSection.Controls.Add(grpPatientOptions)

        pnlDashboard.Controls.Add(pnlPatientsSection)
        pnlPatientsSection.BringToFront()

        patientsSectionInitialized = True
    End Sub

    Private Sub ShowEntitySection(sectionKey As String)
        InitializePatientsSectionUi()

        Dim sectionTitle As String = ""
        Dim sectionSingular As String = ""
        Dim sectionQuery As String = ""
        GetSectionConfig(sectionKey, sectionTitle, sectionSingular, sectionQuery)

        currentSectionKey = sectionKey.ToLowerInvariant()
        currentSectionName = sectionTitle
        currentSectionSingular = sectionSingular

        grpPatientList.Text = sectionTitle
        grpPatientOptions.Text = sectionTitle & " Options"
        btnAddPatient.Text = "Add New " & sectionSingular
        btnDeletePatient.Text = "Delete " & sectionSingular
        btnUpdatePatient.Text = "Update " & sectionSingular

        pnlSummaryCards.Visible = False
        grpQuickActions.Visible = False
        pnlPatientsSection.Visible = True

        LoadSectionData(sectionKey, sectionQuery)
    End Sub

    Private Sub GetSectionConfig(sectionKey As String, ByRef sectionTitle As String, ByRef sectionSingular As String, ByRef sectionQuery As String)
        Select Case sectionKey.ToLowerInvariant()
            Case "patients"
                sectionTitle = "Patients"
                sectionSingular = "Patient"
                sectionQuery = "SELECT PatientID, FirstName, LastName, Sex, DateOfBirth, PhoneNumber, " &
                               "CONCAT(HouseNumber, ', ', Street, ', ', City, ', ', Province) AS Address " &
                               "FROM patient ORDER BY PatientID DESC"
            Case "consultations"
                sectionTitle = "Consultations"
                sectionSingular = "Consultation"
                sectionQuery = "SELECT c.ConsultationID, " &
                               "CONCAT(pa.FirstName, ' ', pa.LastName) AS Patient, " &
                               "CONCAT(ph.FirstName, ' ', ph.LastName) AS Physician, " &
                               "c.Complaint, c.Notes, c.ConsultationDate " &
                               "FROM consultation c " &
                               "INNER JOIN patient pa ON pa.PatientID = c.PatientID " &
                               "INNER JOIN physician ph ON ph.PhysicianID = c.PhysicianID " &
                               "ORDER BY c.ConsultationID DESC"
            Case "diagnoses"
                sectionTitle = "Diagnoses"
                sectionSingular = "Diagnosis"
                sectionQuery = "SELECT d.DiagnosisID, " &
                               "CONCAT(pa.FirstName, ' ', pa.LastName) AS Patient, " &
                               "CONCAT(ph.FirstName, ' ', ph.LastName) AS Physician, " &
                               "d.DiagnosisName, d.DiagnosisDescription, d.DiagnosisDate " &
                               "FROM diagnosis d " &
                               "INNER JOIN patient pa ON pa.PatientID = d.PatientID " &
                               "INNER JOIN physician ph ON ph.PhysicianID = d.PhysicianID " &
                               "ORDER BY d.DiagnosisID DESC"
            Case "laborders"
                sectionTitle = "Lab Orders"
                sectionSingular = "Lab Order"
                sectionQuery = "SELECT lo.OrderID, " &
                               "CONCAT(ph.FirstName, ' ', ph.LastName) AS Physician, " &
                               "CONCAT(pa.FirstName, ' ', pa.LastName) AS Patient, " &
                               "lo.OrderDate, " &
                               "COALESCE(GROUP_CONCAT(mt.TestName ORDER BY mt.TestName SEPARATOR ', '), 'No tests added') AS MedicalTests " &
                               "FROM lab_order lo " &
                               "INNER JOIN physician ph ON ph.PhysicianID = lo.PhysicianID " &
                               "INNER JOIN patient pa ON pa.PatientID = lo.PatientID " &
                               "LEFT JOIN lab_order_inclusion loi ON loi.OrderID = lo.OrderID " &
                               "LEFT JOIN medical_test mt ON mt.TestID = loi.TestID " &
                               "GROUP BY lo.OrderID, ph.FirstName, ph.LastName, pa.FirstName, pa.LastName, lo.OrderDate " &
                               "ORDER BY lo.OrderID DESC"
            Case "examinations"
                sectionTitle = "Examinations"
                sectionSingular = "Examination"
                sectionQuery = "SELECT ex.ExaminationID, " &
                               "CONCAT(pa.FirstName, ' ', pa.LastName) AS Patient, " &
                               "ex.Result, " &
                               "ex.DatePerformed, " &
                               "COALESCE(tests.LaboratoryTests, 'No tests added') AS LaboratoryTests, " &
                               "COALESCE(medtechs.MedTechs, 'No MedTechs added') AS MedTechs " &
                               "FROM examination ex " &
                               "INNER JOIN patient pa ON pa.PatientID = ex.PatientID " &
                               "LEFT JOIN (" &
                               "    SELECT ei.ExaminationID, GROUP_CONCAT(mt.TestName ORDER BY mt.TestName SEPARATOR ', ') AS LaboratoryTests " &
                               "    FROM exam_inclusion ei " &
                               "    INNER JOIN medical_test mt ON mt.TestID = ei.TestID " &
                               "    GROUP BY ei.ExaminationID" &
                               ") tests ON tests.ExaminationID = ex.ExaminationID " &
                               "LEFT JOIN (" &
                               "    SELECT pf.ExaminationID, GROUP_CONCAT(CONCAT(md.FirstName, ' ', md.LastName) ORDER BY md.FirstName, md.LastName SEPARATOR ', ') AS MedTechs " &
                               "    FROM performance pf " &
                               "    INNER JOIN medtech md ON md.MedtechID = pf.MedtechID " &
                               "    GROUP BY pf.ExaminationID" &
                               ") medtechs ON medtechs.ExaminationID = ex.ExaminationID " &
                               "ORDER BY ex.ExaminationID DESC"
            Case "medicaltests"
                sectionTitle = "Medical Tests"
                sectionSingular = "Medical Test"
                sectionQuery = "SELECT * FROM medical_test ORDER BY TestID DESC"
            Case "medicines"
                sectionTitle = "Medicines"
                sectionSingular = "Medicine"
                sectionQuery = "SELECT * FROM medicine ORDER BY MedicineID DESC"
            Case "prescriptions"
                sectionTitle = "Prescriptions"
                sectionSingular = "Prescription"
                sectionQuery = "SELECT pr.PrescriptionID, " &
                               "CONCAT(ph.FirstName, ' ', ph.LastName) AS Physician, " &
                               "CONCAT(pa.FirstName, ' ', pa.LastName) AS Patient, " &
                               "pr.Instruction, pr.PrescriptionDate " &
                               "FROM prescription pr " &
                               "INNER JOIN physician ph ON ph.PhysicianID = pr.PhysicianID " &
                               "INNER JOIN patient pa ON pa.PatientID = pr.PatientID " &
                               "ORDER BY pr.PrescriptionID DESC"
            Case "physicians"
                sectionTitle = "Physicians"
                sectionSingular = "Physician"
                sectionQuery = "SELECT * FROM physician ORDER BY PhysicianID DESC"
            Case "medtechs"
                sectionTitle = "MedTechs"
                sectionSingular = "MedTech"
                sectionQuery = "SELECT * FROM medtech ORDER BY MedtechID DESC"
            Case Else
                sectionTitle = "Patients"
                sectionSingular = "Patient"
                sectionQuery = "SELECT PatientID, FirstName, LastName, Sex, DateOfBirth, PhoneNumber, " &
                               "CONCAT(HouseNumber, ', ', Street, ', ', City, ', ', Province) AS Address " &
                               "FROM patient ORDER BY PatientID DESC"
        End Select
    End Sub

    Private Sub LoadSectionData(sectionKey As String, query As String)
        Dim dt As New DataTable()
        If dgvPatients Is Nothing Then Return

        Try
            MyConnection = New MySqlConnection(MyConnectionString)
            MyConnection.Open()

            userDA = New MySqlDataAdapter(query, CType(MyConnection, MySqlConnection))
            userDA.Fill(dt)

            If dt.Rows.Count = 0 Then
                dt = CreateInfoTable("No " & currentSectionName.ToLowerInvariant() & " found.")
            End If

            dgvPatients.DataSource = dt
            dgvPatients.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            dgvPatients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            If sectionKey.ToLowerInvariant() = "patients" Then
                If dgvPatients.Columns.Contains("PatientID") Then dgvPatients.Columns("PatientID").Width = 90
                If dgvPatients.Columns.Contains("FirstName") Then dgvPatients.Columns("FirstName").Width = 140
                If dgvPatients.Columns.Contains("LastName") Then dgvPatients.Columns("LastName").Width = 140
                If dgvPatients.Columns.Contains("Sex") Then dgvPatients.Columns("Sex").Width = 70
                If dgvPatients.Columns.Contains("DateOfBirth") Then dgvPatients.Columns("DateOfBirth").Width = 105
                If dgvPatients.Columns.Contains("PhoneNumber") Then dgvPatients.Columns("PhoneNumber").Width = 140
                If dgvPatients.Columns.Contains("Address") Then
                    dgvPatients.Columns("Address").AutoSizeMode = DataGridViewAutoSizeColumnsMode.Fill
                    dgvPatients.Columns("Address").MinimumWidth = 420
                End If
            End If
        Catch
            dgvPatients.DataSource = CreateInfoTable("Unable to load " & currentSectionName.ToLowerInvariant() & ".")
        Finally
            If MyConnection IsNot Nothing AndAlso MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
            End If
        End Try
    End Sub

    Private Sub BtnAddPatient_Click(sender As Object, e As EventArgs)
        Dim sectionName As String = If(currentSectionName, "").ToLowerInvariant()
        Dim singular As String = If(currentSectionSingular, "").ToLowerInvariant()

        If sectionName = "physicians" OrElse singular = "physician" Then
            OpenPhysicianEntryDialog()
            Return
        End If

        If sectionName = "patients" OrElse singular = "patient" Then
            OpenPatientEntryDialog()
            Return
        End If

        If sectionName = "consultations" OrElse singular = "consultation" Then
            OpenConsultationEntryDialog()
            Return
        End If

        If sectionName = "diagnoses" OrElse singular = "diagnosis" Then
            OpenDiagnosisEntryDialog()
            Return
        End If

        If sectionName = "medtechs" OrElse singular = "medtech" Then
            OpenMedTechEntryDialog()
            Return
        End If

        If sectionName = "prescriptions" OrElse singular = "prescription" Then
            OpenPrescriptionEntryDialog()
            Return
        End If

        If sectionName = "medicines" OrElse singular = "medicine" Then
            OpenMedicineEntryDialog()
            Return
        End If

        If sectionName = "medical tests" OrElse singular = "medical test" Then
            OpenMedicalTestEntryDialog()
            Return
        End If

        If sectionName = "examinations" OrElse singular = "examination" Then
            OpenExaminationEntryDialog()
            Return
        End If

        If sectionName = "lab orders" OrElse singular = "lab order" Then
            OpenLabOrderEntryDialog()
            Return
        End If

        ShowQuickActionPlaceholder("Add New " & currentSectionSingular)
    End Sub

    Private Sub OpenPatientEntryDialog()
        Using patientEntry As New frmPatientEntry(MyConnectionString)
            If patientEntry.ShowDialog(Me) = DialogResult.OK Then
                LoadDashboardOverview()

                If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
                    Dim sectionTitle As String = ""
                    Dim sectionSingular As String = ""
                    Dim sectionQuery As String = ""
                    GetSectionConfig("patients", sectionTitle, sectionSingular, sectionQuery)
                    LoadSectionData("patients", sectionQuery)
                End If
            End If
        End Using
    End Sub

    Private Sub OpenPhysicianEntryDialog()
        Using physicianEntry As New frmPhysicianEntry(MyConnectionString)
            If physicianEntry.ShowDialog(Me) = DialogResult.OK Then
                LoadDashboardOverview()

                If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
                    Dim sectionTitle As String = ""
                    Dim sectionSingular As String = ""
                    Dim sectionQuery As String = ""
                    GetSectionConfig("physicians", sectionTitle, sectionSingular, sectionQuery)
                    LoadSectionData("physicians", sectionQuery)
                End If
            End If
        End Using
    End Sub

    Private Sub OpenConsultationEntryDialog()
        Using consultationEntry As New frmConsultationEntry(MyConnectionString)
            If consultationEntry.ShowDialog(Me) = DialogResult.OK Then
                LoadDashboardOverview()

                If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
                    Dim sectionTitle As String = ""
                    Dim sectionSingular As String = ""
                    Dim sectionQuery As String = ""
                    GetSectionConfig("consultations", sectionTitle, sectionSingular, sectionQuery)
                    LoadSectionData("consultations", sectionQuery)
                End If
            End If
        End Using
    End Sub

    Private Sub OpenDiagnosisEntryDialog()
        Using diagnosisEntry As New frmDiagnosisEntry(MyConnectionString)
            If diagnosisEntry.ShowDialog(Me) = DialogResult.OK Then
                LoadDashboardOverview()

                If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
                    Dim sectionTitle As String = ""
                    Dim sectionSingular As String = ""
                    Dim sectionQuery As String = ""
                    GetSectionConfig("diagnoses", sectionTitle, sectionSingular, sectionQuery)
                    LoadSectionData("diagnoses", sectionQuery)
                End If
            End If
        End Using
    End Sub

    Private Sub OpenMedTechEntryDialog()
        Using medTechEntry As New frmMedTechEntry(MyConnectionString)
            If medTechEntry.ShowDialog(Me) = DialogResult.OK Then
                LoadDashboardOverview()

                If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
                    Dim sectionTitle As String = ""
                    Dim sectionSingular As String = ""
                    Dim sectionQuery As String = ""
                    GetSectionConfig("medtechs", sectionTitle, sectionSingular, sectionQuery)
                    LoadSectionData("medtechs", sectionQuery)
                End If
            End If
        End Using
    End Sub

    Private Sub OpenPrescriptionEntryDialog()
        Using prescriptionEntry As New frmPrescriptionEntry(MyConnectionString)
            If prescriptionEntry.ShowDialog(Me) = DialogResult.OK Then
                LoadDashboardOverview()

                If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
                    Dim sectionTitle As String = ""
                    Dim sectionSingular As String = ""
                    Dim sectionQuery As String = ""
                    GetSectionConfig("prescriptions", sectionTitle, sectionSingular, sectionQuery)
                    LoadSectionData("prescriptions", sectionQuery)
                End If
            End If
        End Using
    End Sub

    Private Sub OpenMedicineEntryDialog()
        Using medicineEntry As New frmMedicineEntry(MyConnectionString)
            If medicineEntry.ShowDialog(Me) = DialogResult.OK Then
                LoadDashboardOverview()

                If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
                    Dim sectionTitle As String = ""
                    Dim sectionSingular As String = ""
                    Dim sectionQuery As String = ""
                    GetSectionConfig("medicines", sectionTitle, sectionSingular, sectionQuery)
                    LoadSectionData("medicines", sectionQuery)
                End If
            End If
        End Using
    End Sub

    Private Sub OpenMedicalTestEntryDialog()
        Using medicalTestEntry As New frmMedicalTestEntry(MyConnectionString)
            If medicalTestEntry.ShowDialog(Me) = DialogResult.OK Then
                LoadDashboardOverview()

                If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
                    Dim sectionTitle As String = ""
                    Dim sectionSingular As String = ""
                    Dim sectionQuery As String = ""
                    GetSectionConfig("medicaltests", sectionTitle, sectionSingular, sectionQuery)
                    LoadSectionData("medicaltests", sectionQuery)
                End If
            End If
        End Using
    End Sub

    Private Sub OpenExaminationEntryDialog()
        Using examinationEntry As New frmExaminationEntry(MyConnectionString)
            If examinationEntry.ShowDialog(Me) = DialogResult.OK Then
                LoadDashboardOverview()

                If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
                    Dim sectionTitle As String = ""
                    Dim sectionSingular As String = ""
                    Dim sectionQuery As String = ""
                    GetSectionConfig("examinations", sectionTitle, sectionSingular, sectionQuery)
                    LoadSectionData("examinations", sectionQuery)
                End If
            End If
        End Using
    End Sub

    Private Sub OpenLabOrderEntryDialog()
        Using labOrderEntry As New frmLabOrderEntry(MyConnectionString)
            If labOrderEntry.ShowDialog(Me) = DialogResult.OK Then
                LoadDashboardOverview()

                If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
                    Dim sectionTitle As String = ""
                    Dim sectionSingular As String = ""
                    Dim sectionQuery As String = ""
                    GetSectionConfig("laborders", sectionTitle, sectionSingular, sectionQuery)
                    LoadSectionData("laborders", sectionQuery)
                End If
            End If
        End Using
    End Sub

    Private Sub BtnUpdatePatient_Click(sender As Object, e As EventArgs)
        Dim idColumn As String = ""

        Select Case currentSectionKey
            Case "patients" : idColumn = "PatientID"
            Case "consultations" : idColumn = "ConsultationID"
            Case "diagnoses" : idColumn = "DiagnosisID"
            Case "laborders" : idColumn = "OrderID"
            Case "examinations" : idColumn = "ExaminationID"
            Case "medicaltests" : idColumn = "TestID"
            Case "prescriptions" : idColumn = "PrescriptionID"
            Case "medicines" : idColumn = "MedicineID"
            Case "physicians" : idColumn = "PhysicianID"
            Case "medtechs" : idColumn = "MedtechID"
            Case Else
                ShowQuickActionPlaceholder("Update " & currentSectionSingular)
                Return
        End Select

        If dgvPatients Is Nothing OrElse dgvPatients.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a row to update.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not dgvPatients.Columns.Contains(idColumn) Then
            MessageBox.Show("Unable to resolve selected record ID.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvPatients.SelectedRows(0)
        Dim idValue As Object = selectedRow.Cells(idColumn).Value
        If idValue Is Nothing OrElse idValue Is DBNull.Value Then
            MessageBox.Show("Unable to resolve selected record ID.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedId As Integer
        If Not Integer.TryParse(idValue.ToString(), selectedId) Then
            MessageBox.Show("Invalid selected record ID.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sectionTitle As String = ""
        Dim sectionSingular As String = ""
        Dim sectionQuery As String = ""

        Select Case currentSectionKey
            Case "patients"
                Using entry As New frmPatientEntry(MyConnectionString, selectedId)
                    If entry.ShowDialog(Me) <> DialogResult.OK Then Return
                End Using
            Case "consultations"
                Using entry As New frmConsultationEntry(MyConnectionString, selectedId)
                    If entry.ShowDialog(Me) <> DialogResult.OK Then Return
                End Using
            Case "diagnoses"
                Using entry As New frmDiagnosisEntry(MyConnectionString, selectedId)
                    If entry.ShowDialog(Me) <> DialogResult.OK Then Return
                End Using
            Case "laborders"
                Using entry As New frmLabOrderEntry(MyConnectionString, selectedId)
                    If entry.ShowDialog(Me) <> DialogResult.OK Then Return
                End Using
            Case "examinations"
                Using entry As New frmExaminationEntry(MyConnectionString, selectedId)
                    If entry.ShowDialog(Me) <> DialogResult.OK Then Return
                End Using
            Case "medicaltests"
                Using entry As New frmMedicalTestEntry(MyConnectionString, selectedId)
                    If entry.ShowDialog(Me) <> DialogResult.OK Then Return
                End Using
            Case "prescriptions"
                Using entry As New frmPrescriptionEntry(MyConnectionString, selectedId)
                    If entry.ShowDialog(Me) <> DialogResult.OK Then Return
                End Using
            Case "medicines"
                Using entry As New frmMedicineEntry(MyConnectionString, selectedId)
                    If entry.ShowDialog(Me) <> DialogResult.OK Then Return
                End Using
            Case "physicians"
                Using entry As New frmPhysicianEntry(MyConnectionString, selectedId)
                    If entry.ShowDialog(Me) <> DialogResult.OK Then Return
                End Using
            Case "medtechs"
                Using entry As New frmMedTechEntry(MyConnectionString, selectedId)
                    If entry.ShowDialog(Me) <> DialogResult.OK Then Return
                End Using
        End Select

        LoadDashboardOverview()
        If pnlPatientsSection IsNot Nothing AndAlso pnlPatientsSection.Visible Then
            GetSectionConfig(currentSectionKey, sectionTitle, sectionSingular, sectionQuery)
            LoadSectionData(currentSectionKey, sectionQuery)
        End If
    End Sub

    Private Sub BtnDeletePatient_Click(sender As Object, e As EventArgs)
        If dgvPatients Is Nothing OrElse dgvPatients.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a row to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim tableName As String = ""
        Dim keyColumn As String = ""
        If Not TryGetDeleteConfig(currentSectionKey, tableName, keyColumn) Then
            ShowQuickActionPlaceholder("Delete " & currentSectionSingular)
            Return
        End If

        If Not dgvPatients.Columns.Contains(keyColumn) Then
            MessageBox.Show("Unable to delete selected row from this view.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvPatients.SelectedRows(0)
        Dim keyValue As Object = selectedRow.Cells(keyColumn).Value
        If keyValue Is Nothing OrElse keyValue Is DBNull.Value Then
            MessageBox.Show("Unable to resolve selected row ID.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmMessage As String = "Are you sure you want to delete this " & currentSectionSingular.ToLowerInvariant() & "?"
        If MessageBox.Show(confirmMessage, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As New MySqlConnection(MyConnectionString)
                conn.Open()

                Dim sql As String = "DELETE FROM " & tableName & " WHERE " & keyColumn & " = @id"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", keyValue)
                    Dim affectedRows As Integer = cmd.ExecuteNonQuery()

                    If affectedRows = 0 Then
                        MessageBox.Show("No record was deleted. It may have already been removed.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End Using
            End Using

            MessageBox.Show(currentSectionSingular & " deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDashboardOverview()

            Dim sectionTitle As String = ""
            Dim sectionSingular As String = ""
            Dim sectionQuery As String = ""
            GetSectionConfig(currentSectionKey, sectionTitle, sectionSingular, sectionQuery)
            LoadSectionData(currentSectionKey, sectionQuery)
        Catch ex As Exception
            MessageBox.Show("Unable to delete " & currentSectionSingular.ToLowerInvariant() & ": " & ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function TryGetDeleteConfig(sectionKey As String, ByRef tableName As String, ByRef keyColumn As String) As Boolean
        Select Case sectionKey.ToLowerInvariant()
            Case "patients"
                tableName = "patient"
                keyColumn = "PatientID"
            Case "consultations"
                tableName = "consultation"
                keyColumn = "ConsultationID"
            Case "diagnoses"
                tableName = "diagnosis"
                keyColumn = "DiagnosisID"
            Case "laborders"
                tableName = "lab_order"
                keyColumn = "OrderID"
            Case "examinations"
                tableName = "examination"
                keyColumn = "ExaminationID"
            Case "medicaltests"
                tableName = "medical_test"
                keyColumn = "TestID"
            Case "medicines"
                tableName = "medicine"
                keyColumn = "MedicineID"
            Case "prescriptions"
                tableName = "prescription"
                keyColumn = "PrescriptionID"
            Case "physicians"
                tableName = "physician"
                keyColumn = "PhysicianID"
            Case "medtechs"
                tableName = "medtech"
                keyColumn = "MedtechID"
            Case Else
                Return False
        End Select

        Return True
    End Function

    Private Sub miConsultation_Click(sender As Object, e As EventArgs) Handles miConsultation.Click
        ShowEntitySection("consultations")
    End Sub

    Private Sub miDiagnosis_Click(sender As Object, e As EventArgs) Handles miDiagnosis.Click
        ShowEntitySection("diagnoses")
    End Sub

    Private Sub miLabOrders_Click(sender As Object, e As EventArgs) Handles miLabOrders.Click
        ShowEntitySection("laborders")
    End Sub

    Private Sub miExamination_Click(sender As Object, e As EventArgs) Handles miExamination.Click
        ShowEntitySection("examinations")
    End Sub

    Private Sub miMedicalTest_Click(sender As Object, e As EventArgs) Handles miMedicalTest.Click
        ShowEntitySection("medicaltests")
    End Sub

    Private Sub miMedicine_Click(sender As Object, e As EventArgs) Handles miMedicine.Click
        ShowEntitySection("medicines")
    End Sub

    Private Sub miPrescription_Click(sender As Object, e As EventArgs) Handles miPrescription.Click
        ShowEntitySection("prescriptions")
    End Sub

    Private Sub miPhysician_Click(sender As Object, e As EventArgs) Handles miPhysician.Click
        ShowEntitySection("physicians")
    End Sub

    Private Sub miMedTech_Click(sender As Object, e As EventArgs) Handles miMedTech.Click
        ShowEntitySection("medtechs")
    End Sub

    Private Sub ApplyGridWrapping(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is DataGridView Then
                Dim grid As DataGridView = CType(ctrl, DataGridView)
                grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            End If

            If ctrl.HasChildren Then
                ApplyGridWrapping(ctrl)
            End If
        Next
    End Sub

    Private Sub lblLabOrdersValue_Click(sender As Object, e As EventArgs) Handles lblLabOrdersValue.Click

    End Sub
End Class
