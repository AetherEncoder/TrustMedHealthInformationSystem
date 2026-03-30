Imports System.Data
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmDashboard
    Public Sub New()
        InitializeComponent()

        If IsDesignTimeMode() Then
            PreviewPatientSectionInDesigner()
        End If
    End Sub

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
    Private currentLoggedInUsername As String = ""
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
    Private lblPatientSearch As Label
    Private txtPatientSearch As TextBox
    Private currentSectionTable As DataTable

    Private reportsSectionInitialized As Boolean = False
    Private pnlReportsSection As Panel
    Private grpReportsList As GroupBox
    Private grpReportView As GroupBox
    Private lstReports As ListBox
    Private lblReportDescription As Label
    Private dgvReports As DataGridView
    Private lblReportSearch As Label
    Private txtReportSearch As TextBox
    Private currentReportTable As DataTable
    Private reportDefinitions As New Dictionary(Of String, ReportDefinition)
    Private reportOrder As New List(Of String)
    Private loginEyeIcon As Image
    Private loginEyeSlashIcon As Image

    Private Class ReportDefinition
        Public Property Title As String
        Public Property Description As String
        Public Property Query As String
        Public Property EmptyMessage As String
        Public Property RequiredTables As String()
    End Class

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyConnectionString = "datasource=localhost;username=root;password=;database=trustmed"

        Dim logoCandidates As String() = {
            Path.Combine(Application.StartupPath, "src\TrustMed.png"),
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\src\TrustMed.png")),
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\src\TrustMed.png"))
        }

        Dim loadedLogo As Image = Nothing
        For Each logoPath As String In logoCandidates
            If File.Exists(logoPath) Then
                loadedLogo = Image.FromFile(logoPath)
                Exit For
            End If
        Next

        If loadedLogo Is Nothing AndAlso Me.Icon IsNot Nothing Then
            loadedLogo = Me.Icon.ToBitmap()
        End If

        If pbLoginLogo IsNot Nothing Then
            pbLoginLogo.Image = loadedLogo
        End If

        LoadPasswordToggleIcons()
        txtPassword.UseSystemPasswordChar = True
        btnTogglePassword.Image = loginEyeIcon

        InitializePatientsSectionUi()
        InitializeReportsSectionUi()
        ApplySmallButtonIcons()
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
                    currentLoggedInUsername = txtUsername.Text.Trim()
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

        currentLoggedInUsername = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtPassword.UseSystemPasswordChar = True
        btnTogglePassword.Image = loginEyeIcon
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

    Private Sub pbTrustMedLogo_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ShowDashboardHome()
        pnlSummaryCards.Visible = True
        grpQuickActions.Visible = True
        If pnlPatientsSection IsNot Nothing Then
            pnlPatientsSection.Visible = False
        End If
        If pnlReportsSection IsNot Nothing Then
            pnlReportsSection.Visible = False
        End If
    End Sub

    Private Sub miDashboard_Click(sender As Object, e As EventArgs) Handles miDashboard.Click
        ShowDashboardHome()
    End Sub

    Private Sub miPatients_Click(sender As Object, e As EventArgs) Handles miPatients.Click
        ShowEntitySection("patients")
    End Sub

    Private Sub InitializePatientsSectionUi()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboard))
        If patientsSectionInitialized Then Return

        pnlPatientsSection = New Panel()
        pnlPatientsSection.Location = New Point(12, 39)
        pnlPatientsSection.Size = New Size(1324, 678)
        pnlPatientsSection.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlPatientsSection.Visible = False

        grpPatientOptions = New GroupBox()
        grpPatientOptions.Text = "Patient Options"
        grpPatientOptions.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Bold)
        grpPatientOptions.ForeColor = Color.FromArgb(184, 19, 66)
        grpPatientOptions.Location = New Point(0, 0)
        grpPatientOptions.Size = New Size(260, 678)

        btnAddPatient = New Button()
        btnAddPatient.Text = "Add New Patient"
        btnAddPatient.BackColor = Color.FromArgb(184, 19, 66)
        btnAddPatient.ForeColor = Color.White
        btnAddPatient.Size = New Size(224, 48)
        btnAddPatient.Location = New Point(18, 44)
        btnAddPatient.Image = CType(resources.GetObject("btnNewPatient.Image"), System.Drawing.Image)
        btnAddPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        btnAddPatient.Padding = New System.Windows.Forms.Padding(30, 0, 0, 0)
        btnAddPatient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        AddHandler btnAddPatient.Click, AddressOf BtnAddPatient_Click

        btnDeletePatient = New Button()
        btnDeletePatient.Text = "Delete Patient"
        btnDeletePatient.BackColor = Color.FromArgb(184, 19, 66)
        btnDeletePatient.ForeColor = Color.White
        btnDeletePatient.Size = New Size(224, 48)
        btnDeletePatient.Location = New Point(18, 164)
        btnDeletePatient.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        btnDeletePatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        btnDeletePatient.Padding = New System.Windows.Forms.Padding(30, 0, 0, 0)
        btnDeletePatient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        AddHandler btnDeletePatient.Click, AddressOf BtnDeletePatient_Click

        btnUpdatePatient = New Button()
        btnUpdatePatient.Text = "Update Patient"
        btnUpdatePatient.BackColor = Color.FromArgb(184, 19, 66)
        btnUpdatePatient.ForeColor = Color.White
        btnUpdatePatient.Size = New Size(224, 48)
        btnUpdatePatient.Location = New Point(18, 104)
        btnUpdatePatient.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        btnUpdatePatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        btnUpdatePatient.Padding = New System.Windows.Forms.Padding(30, 0, 0, 0)
        btnUpdatePatient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        AddHandler btnUpdatePatient.Click, AddressOf BtnUpdatePatient_Click

        grpPatientOptions.Controls.Add(btnAddPatient)
        grpPatientOptions.Controls.Add(btnUpdatePatient)
        grpPatientOptions.Controls.Add(btnDeletePatient)

        grpPatientList = New GroupBox()
        grpPatientList.Text = "Patients"
        grpPatientList.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Bold)
        grpPatientList.ForeColor = Color.FromArgb(184, 19, 66)
        grpPatientList.Location = New Point(268, 0)
        grpPatientList.Size = New Size(1056, 678)
        grpPatientList.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

        lblPatientSearch = New Label()
        lblPatientSearch.Text = "Search:"
        lblPatientSearch.AutoSize = True
        lblPatientSearch.Location = New Point(674, 31)
        lblPatientSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        txtPatientSearch = New TextBox()
        txtPatientSearch.Location = New Point(736, 27)
        txtPatientSearch.Size = New Size(310, 23)
        txtPatientSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AddHandler txtPatientSearch.TextChanged, AddressOf TxtPatientSearch_TextChanged

        dgvPatients = New DataGridView()
        dgvPatients.Location = New Point(10, 58)
        dgvPatients.Size = New Size(1036, 610)
        dgvPatients.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvPatients.AllowUserToAddRows = False
        dgvPatients.AllowUserToDeleteRows = False
        dgvPatients.ReadOnly = True
        dgvPatients.RowHeadersVisible = False
        dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPatients.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvPatients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        grpPatientList.Controls.Add(lblPatientSearch)
        grpPatientList.Controls.Add(txtPatientSearch)
        grpPatientList.Controls.Add(dgvPatients)

        pnlPatientsSection.Controls.Add(grpPatientList)
        pnlPatientsSection.Controls.Add(grpPatientOptions)

        pnlDashboard.Controls.Add(pnlPatientsSection)
        pnlPatientsSection.BringToFront()

        patientsSectionInitialized = True
    End Sub

    Private Sub InitializeReportsSectionUi()
        If reportsSectionInitialized Then Return

        InitializeReportDefinitions()

        pnlReportsSection = New Panel()
        pnlReportsSection.Location = New Point(12, 39)
        pnlReportsSection.Size = New Size(1324, 678)
        pnlReportsSection.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlReportsSection.Visible = False

        grpReportsList = New GroupBox()
        grpReportsList.Text = "Reports"
        grpReportsList.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Bold)
        grpReportsList.ForeColor = Color.FromArgb(184, 19, 66)
        grpReportsList.Location = New Point(0, 0)
        grpReportsList.Size = New Size(320, 678)

        lstReports = New ListBox()
        lstReports.Location = New Point(14, 28)
        lstReports.Size = New Size(292, 550)
        lstReports.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lstReports.Font = New Font("Microsoft Sans Serif", 9.0!, FontStyle.Regular)
        AddHandler lstReports.SelectedIndexChanged, AddressOf LstReports_SelectedIndexChanged

        lblReportDescription = New Label()
        lblReportDescription.Location = New Point(14, 588)
        lblReportDescription.Size = New Size(292, 80)
        lblReportDescription.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblReportDescription.Font = New Font("Microsoft Sans Serif", 8.5!, FontStyle.Regular)
        lblReportDescription.ForeColor = Color.DimGray

        grpReportsList.Controls.Add(lstReports)
        grpReportsList.Controls.Add(lblReportDescription)

        grpReportView = New GroupBox()
        grpReportView.Text = "Report View"
        grpReportView.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Bold)
        grpReportView.ForeColor = Color.FromArgb(184, 19, 66)
        grpReportView.Location = New Point(328, 0)
        grpReportView.Size = New Size(996, 678)
        grpReportView.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

        lblReportSearch = New Label()
        lblReportSearch.Text = "Search:"
        lblReportSearch.AutoSize = True
        lblReportSearch.Location = New Point(616, 31)
        lblReportSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        txtReportSearch = New TextBox()
        txtReportSearch.Location = New Point(676, 27)
        txtReportSearch.Size = New Size(310, 23)
        txtReportSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AddHandler txtReportSearch.TextChanged, AddressOf TxtReportSearch_TextChanged

        dgvReports = New DataGridView()
        dgvReports.Location = New Point(10, 58)
        dgvReports.Size = New Size(976, 610)
        dgvReports.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvReports.AllowUserToAddRows = False
        dgvReports.AllowUserToDeleteRows = False
        dgvReports.ReadOnly = True
        dgvReports.RowHeadersVisible = False
        dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReports.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvReports.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        grpReportView.Controls.Add(lblReportSearch)
        grpReportView.Controls.Add(txtReportSearch)
        grpReportView.Controls.Add(dgvReports)

        pnlReportsSection.Controls.Add(grpReportsList)
        pnlReportsSection.Controls.Add(grpReportView)

        pnlDashboard.Controls.Add(pnlReportsSection)
        pnlReportsSection.BringToFront()

        For Each reportKey As String In reportOrder
            If reportDefinitions.ContainsKey(reportKey) Then
                lstReports.Items.Add(reportDefinitions(reportKey).Title)
            End If
        Next

        reportsSectionInitialized = True
    End Sub

    Private Sub InitializeReportDefinitions()
        If reportDefinitions.Count > 0 Then Return

        reportDefinitions("patient_medical_history") = New ReportDefinition With {
            .Title = "Patient Medical History Timeline",
            .Description = "Unified timeline of consultations, diagnoses, examinations, and prescriptions per patient.",
            .Query = "SELECT p.PatientID, CONCAT(p.FirstName, ' ', p.LastName) AS Patient, e.EventDate, e.EventType, e.ReferenceID, e.Provider, e.Details " &
                     "FROM (" &
                     " SELECT c.PatientID, c.ConsultationDate AS EventDate, 'Consultation' AS EventType, c.ConsultationID AS ReferenceID, " &
                     "        CONCAT(ph.FirstName, ' ', ph.LastName) AS Provider, CONCAT('Complaint: ', c.Complaint, ' | Notes: ', c.Notes) AS Details " &
                     " FROM consultation c " &
                     " INNER JOIN physician ph ON ph.PhysicianID = c.PhysicianID " &
                     " UNION ALL " &
                     " SELECT d.PatientID, d.DiagnosisDate AS EventDate, 'Diagnosis' AS EventType, d.DiagnosisID AS ReferenceID, " &
                     "        CONCAT(ph.FirstName, ' ', ph.LastName) AS Provider, CONCAT(d.DiagnosisName, ' - ', d.DiagnosisDescription) AS Details " &
                     " FROM diagnosis d " &
                     " INNER JOIN physician ph ON ph.PhysicianID = d.PhysicianID " &
                     " UNION ALL " &
                     " SELECT ex.PatientID, ex.DatePerformed AS EventDate, 'Examination' AS EventType, ex.ExaminationID AS ReferenceID, " &
                     "        COALESCE(medtechs.MedTechs, 'No MedTech Assigned') AS Provider, CONCAT('Result: ', ex.Result) AS Details " &
                     " FROM examination ex " &
                     " LEFT JOIN (" &
                     "    SELECT pf.ExaminationID, GROUP_CONCAT(CONCAT(md.FirstName, ' ', md.LastName) ORDER BY md.FirstName, md.LastName SEPARATOR ', ') AS MedTechs " &
                     "    FROM performance pf " &
                     "    INNER JOIN medtech md ON md.MedtechID = pf.MedtechID " &
                     "    GROUP BY pf.ExaminationID" &
                     " ) medtechs ON medtechs.ExaminationID = ex.ExaminationID " &
                     " UNION ALL " &
                     " SELECT pr.PatientID, pr.PrescriptionDate AS EventDate, 'Prescription' AS EventType, pr.PrescriptionID AS ReferenceID, " &
                     "        CONCAT(ph.FirstName, ' ', ph.LastName) AS Provider, CONCAT('Instruction: ', pr.Instruction) AS Details " &
                     " FROM prescription pr " &
                     " INNER JOIN physician ph ON ph.PhysicianID = pr.PhysicianID " &
                     ") e " &
                     "INNER JOIN patient p ON p.PatientID = e.PatientID " &
                     "ORDER BY p.PatientID, e.EventDate DESC, e.EventType",
            .EmptyMessage = "No patient medical history records found.",
            .RequiredTables = New String() {"patient", "consultation", "diagnosis", "examination", "prescription", "physician", "performance", "medtech"}
        }

        reportDefinitions("consultations_per_physician") = New ReportDefinition With {
            .Title = "Consultations per Physician",
            .Description = "Total consultations handled by each physician.",
            .Query = "SELECT ph.PhysicianID, CONCAT(ph.FirstName, ' ', ph.LastName) AS Physician, COUNT(c.ConsultationID) AS TotalConsultations " &
                     "FROM physician ph " &
                     "LEFT JOIN consultation c ON c.PhysicianID = ph.PhysicianID " &
                     "GROUP BY ph.PhysicianID, ph.FirstName, ph.LastName " &
                     "ORDER BY TotalConsultations DESC, Physician",
            .EmptyMessage = "No consultation records found.",
            .RequiredTables = New String() {"physician", "consultation"}
        }

        reportDefinitions("common_diagnoses") = New ReportDefinition With {
            .Title = "Most Common Diagnoses",
            .Description = "Most frequently recorded diagnosis names in clinic records.",
            .Query = "SELECT DiagnosisName, COUNT(*) AS CaseCount FROM diagnosis GROUP BY DiagnosisName ORDER BY CaseCount DESC, DiagnosisName",
            .EmptyMessage = "No diagnosis records found.",
            .RequiredTables = New String() {"diagnosis"}
        }

        reportDefinitions("total_lab_orders") = New ReportDefinition With {
            .Title = "Total Lab Orders",
            .Description = "Overall number of laboratory orders.",
            .Query = "SELECT COUNT(*) AS TotalLabOrders FROM lab_order",
            .EmptyMessage = "No lab order records found.",
            .RequiredTables = New String() {"lab_order"}
        }

        reportDefinitions("most_requested_tests") = New ReportDefinition With {
            .Title = "Most Requested Medical Tests",
            .Description = "Medical tests most frequently included in lab orders.",
            .Query = "SELECT mt.TestID, mt.TestName, COUNT(*) AS TimesRequested FROM lab_order_inclusion loi INNER JOIN medical_test mt ON mt.TestID = loi.TestID GROUP BY mt.TestID, mt.TestName ORDER BY TimesRequested DESC, mt.TestName",
            .EmptyMessage = "No requested medical tests found.",
            .RequiredTables = New String() {"lab_order_inclusion", "medical_test"}
        }

        reportDefinitions("completed_examinations") = New ReportDefinition With {
            .Title = "Completed Examinations with Results",
            .Description = "Performed examinations, patients, included tests, and encoded results.",
            .Query = "SELECT ex.ExaminationID, CONCAT(pa.FirstName, ' ', pa.LastName) AS Patient, ex.DatePerformed, ex.Result, " &
                     "COALESCE(GROUP_CONCAT(mt.TestName ORDER BY mt.TestName SEPARATOR ', '), 'No tests added') AS Tests " &
                     "FROM examination ex " &
                     "INNER JOIN patient pa ON pa.PatientID = ex.PatientID " &
                     "LEFT JOIN exam_inclusion ei ON ei.ExaminationID = ex.ExaminationID " &
                     "LEFT JOIN medical_test mt ON mt.TestID = ei.TestID " &
                     "GROUP BY ex.ExaminationID, pa.FirstName, pa.LastName, ex.DatePerformed, ex.Result " &
                     "ORDER BY ex.DatePerformed DESC, ex.ExaminationID DESC",
            .EmptyMessage = "No completed examinations found.",
            .RequiredTables = New String() {"examination", "patient", "exam_inclusion", "medical_test"}
        }

        reportDefinitions("test_usage_frequency") = New ReportDefinition With {
            .Title = "Test Usage Frequency",
            .Description = "Combined frequency of each medical test across lab orders and examinations.",
            .Query = "SELECT mt.TestID, mt.TestName, COALESCE(ord.OrderUsage, 0) AS OrderedCount, COALESCE(exm.ExamUsage, 0) AS ExaminationCount, " &
                     "(COALESCE(ord.OrderUsage, 0) + COALESCE(exm.ExamUsage, 0)) AS TotalUsage " &
                     "FROM medical_test mt " &
                     "LEFT JOIN (SELECT TestID, COUNT(*) AS OrderUsage FROM lab_order_inclusion GROUP BY TestID) ord ON ord.TestID = mt.TestID " &
                     "LEFT JOIN (SELECT TestID, COUNT(*) AS ExamUsage FROM exam_inclusion GROUP BY TestID) exm ON exm.TestID = mt.TestID " &
                     "ORDER BY TotalUsage DESC, mt.TestName",
            .EmptyMessage = "No test usage records found.",
            .RequiredTables = New String() {"medical_test", "lab_order_inclusion", "exam_inclusion"}
        }

        reportDefinitions("most_prescribed_medicines") = New ReportDefinition With {
            .Title = "Most Prescribed Medicines",
            .Description = "Medicines prescribed most frequently from prescription inclusions.",
            .Query = "SELECT m.MedicineID, m.MedicineName, COUNT(*) AS TimesPrescribed " &
                     "FROM prescription_inclusion pi " &
                     "INNER JOIN medicine m ON m.MedicineID = pi.MedicineID " &
                     "GROUP BY m.MedicineID, m.MedicineName " &
                     "ORDER BY TimesPrescribed DESC, m.MedicineName",
            .EmptyMessage = "No prescribed medicine records found.",
            .RequiredTables = New String() {"prescription_inclusion", "medicine"}
        }

        reportDefinitions("prescriptions_per_physician") = New ReportDefinition With {
            .Title = "Prescriptions per Physician",
            .Description = "Total prescriptions issued by each physician.",
            .Query = "SELECT ph.PhysicianID, CONCAT(ph.FirstName, ' ', ph.LastName) AS Physician, COUNT(pr.PrescriptionID) AS TotalPrescriptions " &
                     "FROM physician ph " &
                     "LEFT JOIN prescription pr ON pr.PhysicianID = ph.PhysicianID " &
                     "GROUP BY ph.PhysicianID, ph.FirstName, ph.LastName " &
                     "ORDER BY TotalPrescriptions DESC, Physician",
            .EmptyMessage = "No prescription records found.",
            .RequiredTables = New String() {"physician", "prescription"}
        }

        reportDefinitions("prescription_counts") = New ReportDefinition With {
            .Title = "Prescription Counts Overview",
            .Description = "Overall prescription count with number of distinct physicians and patients involved.",
            .Query = "SELECT COUNT(*) AS TotalPrescriptions, COUNT(DISTINCT PhysicianID) AS PhysiciansInvolved, COUNT(DISTINCT PatientID) AS PatientsWithPrescriptions FROM prescription",
            .EmptyMessage = "No prescription records found.",
            .RequiredTables = New String() {"prescription"}
        }

        reportDefinitions("examinations_per_medtech") = New ReportDefinition With {
            .Title = "Examinations per MedTech",
            .Description = "Number of examinations performed by each medtech.",
            .Query = "SELECT md.MedtechID, CONCAT(md.FirstName, ' ', md.LastName) AS MedTech, COUNT(pf.ExaminationID) AS TotalExaminations " &
                     "FROM medtech md " &
                     "LEFT JOIN performance pf ON pf.MedtechID = md.MedtechID " &
                     "GROUP BY md.MedtechID, md.FirstName, md.LastName " &
                     "ORDER BY TotalExaminations DESC, MedTech",
            .EmptyMessage = "No medtech performance records found.",
            .RequiredTables = New String() {"medtech", "performance"}
        }

        reportDefinitions("financial_summary") = New ReportDefinition With {
            .Title = "Financial Summary Estimate",
            .Description = "Estimated operational revenue based on ordered lab tests and prescribed medicines.",
            .Query = "SELECT " &
                     "COALESCE((SELECT SUM(mt.Cost) FROM lab_order_inclusion loi INNER JOIN medical_test mt ON mt.TestID = loi.TestID), 0) AS LabRevenueEstimate, " &
                     "COALESCE((SELECT SUM(m.Price) FROM prescription_inclusion pi INNER JOIN medicine m ON m.MedicineID = pi.MedicineID), 0) AS MedicineRevenueEstimate, " &
                     "COALESCE((SELECT SUM(mt.Cost) FROM lab_order_inclusion loi INNER JOIN medical_test mt ON mt.TestID = loi.TestID), 0) + " &
                     "COALESCE((SELECT SUM(m.Price) FROM prescription_inclusion pi INNER JOIN medicine m ON m.MedicineID = pi.MedicineID), 0) AS TotalRevenueEstimate",
            .EmptyMessage = "No financial summary data found.",
            .RequiredTables = New String() {"lab_order_inclusion", "medical_test", "prescription_inclusion", "medicine"}
        }

        reportOrder.AddRange(New String() {
            "patient_medical_history",
            "consultations_per_physician",
            "common_diagnoses",
            "total_lab_orders",
            "most_requested_tests",
            "completed_examinations",
            "test_usage_frequency",
            "most_prescribed_medicines",
            "prescriptions_per_physician",
            "prescription_counts",
            "examinations_per_medtech",
            "financial_summary"
        })
    End Sub

    Private Sub ShowReportsSection()
        InitializeReportsSectionUi()

        pnlSummaryCards.Visible = False
        grpQuickActions.Visible = False
        If pnlPatientsSection IsNot Nothing Then
            pnlPatientsSection.Visible = False
        End If

        pnlReportsSection.Visible = True
        pnlReportsSection.BringToFront()

        If lstReports.Items.Count > 0 AndAlso lstReports.SelectedIndex < 0 Then
            lstReports.SelectedIndex = 0
        ElseIf lstReports.SelectedIndex >= 0 Then
            LoadSelectedReport(lstReports.SelectedIndex)
        End If
    End Sub

    Private Sub LstReports_SelectedIndexChanged(sender As Object, e As EventArgs)
        If lstReports Is Nothing OrElse lstReports.SelectedIndex < 0 Then Return
        LoadSelectedReport(lstReports.SelectedIndex)
    End Sub

    Private Sub LoadSelectedReport(selectedIndex As Integer)
        If selectedIndex < 0 OrElse selectedIndex >= reportOrder.Count Then Return

        Dim reportKey As String = reportOrder(selectedIndex)
        If Not reportDefinitions.ContainsKey(reportKey) Then Return

        Dim definition As ReportDefinition = reportDefinitions(reportKey)
        grpReportView.Text = definition.Title
        lblReportDescription.Text = definition.Description
        LoadReportData(definition)
    End Sub

    Private Sub LoadReportData(definition As ReportDefinition)
        If dgvReports Is Nothing Then Return

        Try
            MyConnection = New MySqlConnection(MyConnectionString)
            MyConnection.Open()

            If definition.RequiredTables IsNot Nothing Then
                For Each tableName As String In definition.RequiredTables
                    If Not TableExists(tableName) Then
                        currentReportTable = CreateInfoTable("Unable to load report. Missing table: " & tableName)
                        dgvReports.DataSource = currentReportTable
                        Return
                    End If
                Next
            End If

            currentReportTable = ExecuteTableQuerySafe(definition.Query, definition.EmptyMessage)
            ApplyReportSearchFilter()
            dgvReports.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            dgvReports.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Catch
            currentReportTable = CreateInfoTable("Unable to load selected report.")
            dgvReports.DataSource = currentReportTable
        Finally
            If MyConnection IsNot Nothing AndAlso MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
            End If
        End Try
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
        If pnlReportsSection IsNot Nothing Then
            pnlReportsSection.Visible = False
        End If
        pnlPatientsSection.Visible = True

        If txtPatientSearch IsNot Nothing Then
            txtPatientSearch.Text = ""
        End If

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

            currentSectionTable = dt
            ApplyPatientSearchFilter()
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
            currentSectionTable = CreateInfoTable("Unable to load " & currentSectionName.ToLowerInvariant() & ".")
            dgvPatients.DataSource = currentSectionTable
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

    Private Sub miReports_Click(sender As Object, e As EventArgs) Handles miReports.Click
        ShowReportsSection()
    End Sub

    Private Sub miAccountSettings_Click(sender As Object, e As EventArgs) Handles miAccountSettings.Click
        ShowAccountSettingsDialog()
    End Sub

    Private Sub ShowAccountSettingsDialog()
        If String.IsNullOrWhiteSpace(currentLoggedInUsername) Then
            MessageBox.Show("No active account session found.", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using settingsForm As New frmSettings(MyConnectionString, currentLoggedInUsername)
            Dim dialogResultValue As DialogResult = settingsForm.ShowDialog(Me)

            If settingsForm.AccountDeleted Then
                MessageBox.Show("Account deleted successfully.", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ShowLoginPage()
                Return
            End If

            If dialogResultValue = DialogResult.OK OrElse dialogResultValue = DialogResult.Cancel Then
                currentLoggedInUsername = settingsForm.UpdatedUsername
            End If
        End Using
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

    Private Function IsDesignTimeMode() As Boolean
        Return System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime
    End Function

    Private Sub PreviewPatientSectionInDesigner()
        Try
            InitializePatientsSectionUi()
            ApplySmallButtonIcons()
            pnlDashboard.Visible = True
            pnlLoginContainer.Visible = False
            pnlSummaryCards.Visible = False
            grpQuickActions.Visible = False
            If pnlReportsSection IsNot Nothing Then
                pnlReportsSection.Visible = False
            End If
            If pnlPatientsSection IsNot Nothing Then
                pnlPatientsSection.Visible = True
                pnlPatientsSection.BringToFront()
            End If
        Catch
            ' Design-time preview only; ignore designer-time exceptions.
        End Try
    End Sub

    Private Sub ApplySmallButtonIcons()
        ApplySmallButtonIcon(btnNewPatient)
        ApplySmallButtonIcon(btnNewDiagnosis)
        ApplySmallButtonIcon(btnNewConsultation)
        ApplySmallButtonIcon(btnNewLabOrder)
        ApplySmallButtonIcon(btnNewPrescription)

        ApplySmallButtonIcon(btnAddPatient)
        ApplySmallButtonIcon(btnUpdatePatient)
        ApplySmallButtonIcon(btnDeletePatient)
    End Sub

    Private Sub ApplySmallButtonIcon(targetButton As Button)
        If targetButton Is Nothing OrElse targetButton.Image Is Nothing Then Return
        targetButton.Image = ResizeImage(targetButton.Image, 14, 14)
    End Sub

    Private Function ResizeImage(source As Image, width As Integer, height As Integer) As Image
        Dim bmp As New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(source, New Rectangle(0, 0, width, height))
        End Using

        Return bmp
    End Function

    Private Sub LoadPasswordToggleIcons()
        Dim eyeCandidates As String() = {
            Path.Combine(Application.StartupPath, "src\eye-fill.png"),
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\src\eye-fill.png")),
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\src\eye-fill.png"))
        }

        Dim eyeSlashCandidates As String() = {
            Path.Combine(Application.StartupPath, "src\eye-slash-fill.png"),
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\src\eye-slash-fill.png")),
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\src\eye-slash-fill.png"))
        }

        For Each iconPath As String In eyeCandidates
            If File.Exists(iconPath) Then
                loginEyeIcon = ResizeImage(Image.FromFile(iconPath), 14, 14)
                Exit For
            End If
        Next

        For Each iconPath As String In eyeSlashCandidates
            If File.Exists(iconPath) Then
                loginEyeSlashIcon = ResizeImage(Image.FromFile(iconPath), 14, 14)
                Exit For
            End If
        Next
    End Sub

    Private Sub btnTogglePassword_Click(sender As Object, e As EventArgs) Handles btnTogglePassword.Click
        txtPassword.UseSystemPasswordChar = Not txtPassword.UseSystemPasswordChar
        btnTogglePassword.Image = If(txtPassword.UseSystemPasswordChar, loginEyeIcon, loginEyeSlashIcon)
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub lblLabOrdersValue_Click(sender As Object, e As EventArgs) Handles lblLabOrdersValue.Click

    End Sub

    Private Sub lblBrandingTitle_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblTotalPatientsTitle_Click(sender As Object, e As EventArgs) Handles lblTotalPatientsTitle.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtPatientSearch_TextChanged(sender As Object, e As EventArgs)
        ApplyPatientSearchFilter()
    End Sub

    Private Sub TxtReportSearch_TextChanged(sender As Object, e As EventArgs)
        ApplyReportSearchFilter()
    End Sub

    Private Sub ApplyPatientSearchFilter()
        If dgvPatients Is Nothing OrElse currentSectionTable Is Nothing Then Return

        Dim searchText As String = String.Empty
        If txtPatientSearch IsNot Nothing Then
            searchText = txtPatientSearch.Text
        End If

        dgvPatients.DataSource = GetFilteredTable(currentSectionTable, searchText)
    End Sub

    Private Sub ApplyReportSearchFilter()
        If dgvReports Is Nothing OrElse currentReportTable Is Nothing Then Return

        Dim searchText As String = String.Empty
        If txtReportSearch IsNot Nothing Then
            searchText = txtReportSearch.Text
        End If

        dgvReports.DataSource = GetFilteredTable(currentReportTable, searchText)
    End Sub

    Private Function GetFilteredTable(source As DataTable, rawSearch As String) As DataTable
        If source Is Nothing Then Return Nothing

        Dim searchText As String = If(rawSearch, String.Empty).Trim()
        If searchText = String.Empty Then
            Return source
        End If

        Dim escapedSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]")
        Dim filterParts As New List(Of String)()

        For Each col As DataColumn In source.Columns
            Dim safeColumnName As String = col.ColumnName.Replace("]", "]]")
            filterParts.Add("CONVERT([" & safeColumnName & "], 'System.String') LIKE '%" & escapedSearch & "%'")
        Next

        If filterParts.Count = 0 Then
            Return source
        End If

        Dim view As New DataView(source)
        view.RowFilter = String.Join(" OR ", filterParts)
        Return view.ToTable()
    End Function
End Class


