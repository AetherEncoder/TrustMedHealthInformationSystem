<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboard))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblUsernameError = New System.Windows.Forms.Label()
        Me.lblPasswordError = New System.Windows.Forms.Label()
        Me.pnlLoginContainer = New System.Windows.Forms.Panel()
        Me.lblLoginError = New System.Windows.Forms.Label()
        Me.pnlDashboard = New System.Windows.Forms.Panel()
        Me.grpTodaysWork = New System.Windows.Forms.GroupBox()
        Me.dgvTodaysWork = New System.Windows.Forms.DataGridView()
        Me.grpRecentActivity = New System.Windows.Forms.GroupBox()
        Me.dgvRecentActivity = New System.Windows.Forms.DataGridView()
        Me.grpQuickActions = New System.Windows.Forms.GroupBox()
        Me.btnNewPatient = New System.Windows.Forms.Button()
        Me.btnNewDiagnosis = New System.Windows.Forms.Button()
        Me.btnNewConsultation = New System.Windows.Forms.Button()
        Me.btnNewLabOrder = New System.Windows.Forms.Button()
        Me.btnNewPrescription = New System.Windows.Forms.Button()
        Me.pnlSummaryCards = New System.Windows.Forms.Panel()
        Me.pnlCompletedExaminations = New System.Windows.Forms.Panel()
        Me.lblCompletedExaminationsValue = New System.Windows.Forms.Label()
        Me.lblCompletedExaminationsTitle = New System.Windows.Forms.Label()
        Me.pnlPendingLabOrders = New System.Windows.Forms.Panel()
        Me.lblPendingLabOrdersValue = New System.Windows.Forms.Label()
        Me.lblPendingLabOrdersTitle = New System.Windows.Forms.Label()
        Me.pnlConsultationsToday = New System.Windows.Forms.Panel()
        Me.lblConsultationsTodayValue = New System.Windows.Forms.Label()
        Me.lblConsultationsTodayTitle = New System.Windows.Forms.Label()
        Me.pnlTotalPatients = New System.Windows.Forms.Panel()
        Me.lblTotalPatientsValue = New System.Windows.Forms.Label()
        Me.lblTotalPatientsTitle = New System.Windows.Forms.Label()
        Me.msDashboardMenu = New System.Windows.Forms.MenuStrip()
        Me.miDashboard = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPatients = New System.Windows.Forms.ToolStripMenuItem()
        Me.miClinical = New System.Windows.Forms.ToolStripMenuItem()
        Me.miConsultation = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDiagnosis = New System.Windows.Forms.ToolStripMenuItem()
        Me.miLaboratory = New System.Windows.Forms.ToolStripMenuItem()
        Me.miLabOrders = New System.Windows.Forms.ToolStripMenuItem()
        Me.miExamination = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMedicalTest = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPharmacy = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPrescription = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMedicine = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAdministration = New System.Windows.Forms.ToolStripMenuItem()
        Me.miStaff = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPhysician = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMedTech = New System.Windows.Forms.ToolStripMenuItem()
        Me.miReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAccount = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAccountLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAccountSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlLoginContainer.SuspendLayout()
        Me.pnlDashboard.SuspendLayout()
        Me.grpTodaysWork.SuspendLayout()
        CType(Me.dgvTodaysWork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRecentActivity.SuspendLayout()
        CType(Me.dgvRecentActivity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpQuickActions.SuspendLayout()
        Me.pnlSummaryCards.SuspendLayout()
        Me.pnlCompletedExaminations.SuspendLayout()
        Me.pnlPendingLabOrders.SuspendLayout()
        Me.pnlConsultationsToday.SuspendLayout()
        Me.pnlTotalPatients.SuspendLayout()
        Me.msDashboardMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblHeader.Location = New System.Drawing.Point(250, 50)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(571, 37)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "TrustMed Health Information System"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.Location = New System.Drawing.Point(300, 200)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(97, 20)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username: *"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(300, 280)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(92, 20)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password: *"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(300, 230)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(400, 26)
        Me.txtUsername.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(300, 310)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(400, 26)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.DarkBlue
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(350, 420)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(100, 40)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Gray
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(550, 420)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 40)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblUsernameError
        '
        Me.lblUsernameError.AutoSize = True
        Me.lblUsernameError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsernameError.ForeColor = System.Drawing.Color.Red
        Me.lblUsernameError.Location = New System.Drawing.Point(300, 260)
        Me.lblUsernameError.Name = "lblUsernameError"
        Me.lblUsernameError.Size = New System.Drawing.Size(0, 15)
        Me.lblUsernameError.TabIndex = 7
        Me.lblUsernameError.Visible = False
        '
        'lblPasswordError
        '
        Me.lblPasswordError.AutoSize = True
        Me.lblPasswordError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordError.ForeColor = System.Drawing.Color.Red
        Me.lblPasswordError.Location = New System.Drawing.Point(300, 340)
        Me.lblPasswordError.Name = "lblPasswordError"
        Me.lblPasswordError.Size = New System.Drawing.Size(0, 15)
        Me.lblPasswordError.TabIndex = 8
        Me.lblPasswordError.Visible = False
        '
        'pnlLoginContainer
        '
        Me.pnlLoginContainer.Controls.Add(Me.lblLoginError)
        Me.pnlLoginContainer.Controls.Add(Me.lblPasswordError)
        Me.pnlLoginContainer.Controls.Add(Me.lblUsernameError)
        Me.pnlLoginContainer.Controls.Add(Me.btnClose)
        Me.pnlLoginContainer.Controls.Add(Me.btnLogin)
        Me.pnlLoginContainer.Controls.Add(Me.txtPassword)
        Me.pnlLoginContainer.Controls.Add(Me.txtUsername)
        Me.pnlLoginContainer.Controls.Add(Me.lblPassword)
        Me.pnlLoginContainer.Controls.Add(Me.lblUsername)
        Me.pnlLoginContainer.Controls.Add(Me.lblHeader)
        Me.pnlLoginContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLoginContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlLoginContainer.Name = "pnlLoginContainer"
        Me.pnlLoginContainer.Size = New System.Drawing.Size(1008, 729)
        Me.pnlLoginContainer.TabIndex = 10
        '
        'lblLoginError
        '
        Me.lblLoginError.AutoSize = True
        Me.lblLoginError.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginError.ForeColor = System.Drawing.Color.Red
        Me.lblLoginError.Location = New System.Drawing.Point(300, 365)
        Me.lblLoginError.Name = "lblLoginError"
        Me.lblLoginError.Size = New System.Drawing.Size(0, 17)
        Me.lblLoginError.TabIndex = 9
        Me.lblLoginError.Visible = False
        '
        'pnlDashboard
        '
        Me.pnlDashboard.Controls.Add(Me.grpTodaysWork)
        Me.pnlDashboard.Controls.Add(Me.grpRecentActivity)
        Me.pnlDashboard.Controls.Add(Me.grpQuickActions)
        Me.pnlDashboard.Controls.Add(Me.pnlSummaryCards)
        Me.pnlDashboard.Controls.Add(Me.msDashboardMenu)
        Me.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDashboard.Location = New System.Drawing.Point(0, 0)
        Me.pnlDashboard.Name = "pnlDashboard"
        Me.pnlDashboard.Size = New System.Drawing.Size(1008, 729)
        Me.pnlDashboard.TabIndex = 11
        Me.pnlDashboard.Visible = False
        '
        'grpTodaysWork
        '
        Me.grpTodaysWork.Controls.Add(Me.dgvTodaysWork)
        Me.grpTodaysWork.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTodaysWork.ForeColor = System.Drawing.Color.DarkBlue
        Me.grpTodaysWork.Location = New System.Drawing.Point(514, 334)
        Me.grpTodaysWork.Name = "grpTodaysWork"
        Me.grpTodaysWork.Size = New System.Drawing.Size(482, 383)
        Me.grpTodaysWork.TabIndex = 7
        Me.grpTodaysWork.TabStop = False
        Me.grpTodaysWork.Text = "Today's Work"
        '
        'dgvTodaysWork
        '
        Me.dgvTodaysWork.AllowUserToAddRows = False
        Me.dgvTodaysWork.AllowUserToDeleteRows = False
        Me.dgvTodaysWork.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTodaysWork.BackgroundColor = System.Drawing.Color.White
        Me.dgvTodaysWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTodaysWork.Location = New System.Drawing.Point(10, 24)
        Me.dgvTodaysWork.Name = "dgvTodaysWork"
        Me.dgvTodaysWork.ReadOnly = True
        Me.dgvTodaysWork.RowHeadersVisible = False
        Me.dgvTodaysWork.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTodaysWork.Size = New System.Drawing.Size(462, 349)
        Me.dgvTodaysWork.TabIndex = 0
        '
        'grpRecentActivity
        '
        Me.grpRecentActivity.Controls.Add(Me.dgvRecentActivity)
        Me.grpRecentActivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRecentActivity.ForeColor = System.Drawing.Color.DarkBlue
        Me.grpRecentActivity.Location = New System.Drawing.Point(12, 334)
        Me.grpRecentActivity.Name = "grpRecentActivity"
        Me.grpRecentActivity.Size = New System.Drawing.Size(496, 383)
        Me.grpRecentActivity.TabIndex = 6
        Me.grpRecentActivity.TabStop = False
        Me.grpRecentActivity.Text = "Recent Activity"
        '
        'dgvRecentActivity
        '
        Me.dgvRecentActivity.AllowUserToAddRows = False
        Me.dgvRecentActivity.AllowUserToDeleteRows = False
        Me.dgvRecentActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRecentActivity.BackgroundColor = System.Drawing.Color.White
        Me.dgvRecentActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecentActivity.Location = New System.Drawing.Point(10, 24)
        Me.dgvRecentActivity.Name = "dgvRecentActivity"
        Me.dgvRecentActivity.ReadOnly = True
        Me.dgvRecentActivity.RowHeadersVisible = False
        Me.dgvRecentActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecentActivity.Size = New System.Drawing.Size(476, 349)
        Me.dgvRecentActivity.TabIndex = 0
        '
        'grpQuickActions
        '
        Me.grpQuickActions.Controls.Add(Me.btnNewPrescription)
        Me.grpQuickActions.Controls.Add(Me.btnNewLabOrder)
        Me.grpQuickActions.Controls.Add(Me.btnNewConsultation)
        Me.grpQuickActions.Controls.Add(Me.btnNewDiagnosis)
        Me.grpQuickActions.Controls.Add(Me.btnNewPatient)
        Me.grpQuickActions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpQuickActions.ForeColor = System.Drawing.Color.DarkBlue
        Me.grpQuickActions.Location = New System.Drawing.Point(12, 265)
        Me.grpQuickActions.Name = "grpQuickActions"
        Me.grpQuickActions.Size = New System.Drawing.Size(984, 63)
        Me.grpQuickActions.TabIndex = 5
        Me.grpQuickActions.TabStop = False
        Me.grpQuickActions.Text = "Quick Actions"
        '
        'btnNewPatient
        '
        Me.btnNewPatient.BackColor = System.Drawing.Color.DarkBlue
        Me.btnNewPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewPatient.ForeColor = System.Drawing.Color.White
        Me.btnNewPatient.Location = New System.Drawing.Point(10, 23)
        Me.btnNewPatient.Name = "btnNewPatient"
        Me.btnNewPatient.Size = New System.Drawing.Size(186, 30)
        Me.btnNewPatient.TabIndex = 0
        Me.btnNewPatient.Text = "New Patient"
        Me.btnNewPatient.UseVisualStyleBackColor = False
        '
        'btnNewDiagnosis
        '
        Me.btnNewDiagnosis.BackColor = System.Drawing.Color.DarkBlue
        Me.btnNewDiagnosis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewDiagnosis.ForeColor = System.Drawing.Color.White
        Me.btnNewDiagnosis.Location = New System.Drawing.Point(204, 23)
        Me.btnNewDiagnosis.Name = "btnNewDiagnosis"
        Me.btnNewDiagnosis.Size = New System.Drawing.Size(186, 30)
        Me.btnNewDiagnosis.TabIndex = 1
        Me.btnNewDiagnosis.Text = "New Diagnosis"
        Me.btnNewDiagnosis.UseVisualStyleBackColor = False
        '
        'btnNewConsultation
        '
        Me.btnNewConsultation.BackColor = System.Drawing.Color.DarkBlue
        Me.btnNewConsultation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewConsultation.ForeColor = System.Drawing.Color.White
        Me.btnNewConsultation.Location = New System.Drawing.Point(398, 23)
        Me.btnNewConsultation.Name = "btnNewConsultation"
        Me.btnNewConsultation.Size = New System.Drawing.Size(186, 30)
        Me.btnNewConsultation.TabIndex = 2
        Me.btnNewConsultation.Text = "New Consultation"
        Me.btnNewConsultation.UseVisualStyleBackColor = False
        '
        'btnNewLabOrder
        '
        Me.btnNewLabOrder.BackColor = System.Drawing.Color.DarkBlue
        Me.btnNewLabOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewLabOrder.ForeColor = System.Drawing.Color.White
        Me.btnNewLabOrder.Location = New System.Drawing.Point(592, 23)
        Me.btnNewLabOrder.Name = "btnNewLabOrder"
        Me.btnNewLabOrder.Size = New System.Drawing.Size(186, 30)
        Me.btnNewLabOrder.TabIndex = 3
        Me.btnNewLabOrder.Text = "New Lab Order"
        Me.btnNewLabOrder.UseVisualStyleBackColor = False
        '
        'btnNewPrescription
        '
        Me.btnNewPrescription.BackColor = System.Drawing.Color.DarkBlue
        Me.btnNewPrescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewPrescription.ForeColor = System.Drawing.Color.White
        Me.btnNewPrescription.Location = New System.Drawing.Point(786, 23)
        Me.btnNewPrescription.Name = "btnNewPrescription"
        Me.btnNewPrescription.Size = New System.Drawing.Size(186, 30)
        Me.btnNewPrescription.TabIndex = 4
        Me.btnNewPrescription.Text = "New Prescription"
        Me.btnNewPrescription.UseVisualStyleBackColor = False
        '
        'pnlSummaryCards
        '
        Me.pnlSummaryCards.Controls.Add(Me.pnlCompletedExaminations)
        Me.pnlSummaryCards.Controls.Add(Me.pnlPendingLabOrders)
        Me.pnlSummaryCards.Controls.Add(Me.pnlConsultationsToday)
        Me.pnlSummaryCards.Controls.Add(Me.pnlTotalPatients)
        Me.pnlSummaryCards.Location = New System.Drawing.Point(12, 39)
        Me.pnlSummaryCards.Name = "pnlSummaryCards"
        Me.pnlSummaryCards.Size = New System.Drawing.Size(984, 220)
        Me.pnlSummaryCards.TabIndex = 4
        '
        'pnlCompletedExaminations
        '
        Me.pnlCompletedExaminations.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlCompletedExaminations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCompletedExaminations.Controls.Add(Me.lblCompletedExaminationsValue)
        Me.pnlCompletedExaminations.Controls.Add(Me.lblCompletedExaminationsTitle)
        Me.pnlCompletedExaminations.Location = New System.Drawing.Point(744, 15)
        Me.pnlCompletedExaminations.Name = "pnlCompletedExaminations"
        Me.pnlCompletedExaminations.Size = New System.Drawing.Size(230, 190)
        Me.pnlCompletedExaminations.TabIndex = 3
        '
        'lblCompletedExaminationsValue
        '
        Me.lblCompletedExaminationsValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompletedExaminationsValue.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblCompletedExaminationsValue.Location = New System.Drawing.Point(3, 68)
        Me.lblCompletedExaminationsValue.Name = "lblCompletedExaminationsValue"
        Me.lblCompletedExaminationsValue.Size = New System.Drawing.Size(222, 80)
        Me.lblCompletedExaminationsValue.TabIndex = 1
        Me.lblCompletedExaminationsValue.Text = "0"
        Me.lblCompletedExaminationsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCompletedExaminationsTitle
        '
        Me.lblCompletedExaminationsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompletedExaminationsTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCompletedExaminationsTitle.Location = New System.Drawing.Point(3, 16)
        Me.lblCompletedExaminationsTitle.Name = "lblCompletedExaminationsTitle"
        Me.lblCompletedExaminationsTitle.Size = New System.Drawing.Size(222, 52)
        Me.lblCompletedExaminationsTitle.TabIndex = 0
        Me.lblCompletedExaminationsTitle.Text = "Completed Examinations"
        Me.lblCompletedExaminationsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPendingLabOrders
        '
        Me.pnlPendingLabOrders.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlPendingLabOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPendingLabOrders.Controls.Add(Me.lblPendingLabOrdersValue)
        Me.pnlPendingLabOrders.Controls.Add(Me.lblPendingLabOrdersTitle)
        Me.pnlPendingLabOrders.Location = New System.Drawing.Point(498, 15)
        Me.pnlPendingLabOrders.Name = "pnlPendingLabOrders"
        Me.pnlPendingLabOrders.Size = New System.Drawing.Size(230, 190)
        Me.pnlPendingLabOrders.TabIndex = 2
        '
        'lblPendingLabOrdersValue
        '
        Me.lblPendingLabOrdersValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingLabOrdersValue.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblPendingLabOrdersValue.Location = New System.Drawing.Point(3, 68)
        Me.lblPendingLabOrdersValue.Name = "lblPendingLabOrdersValue"
        Me.lblPendingLabOrdersValue.Size = New System.Drawing.Size(222, 80)
        Me.lblPendingLabOrdersValue.TabIndex = 1
        Me.lblPendingLabOrdersValue.Text = "0"
        Me.lblPendingLabOrdersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPendingLabOrdersTitle
        '
        Me.lblPendingLabOrdersTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingLabOrdersTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPendingLabOrdersTitle.Location = New System.Drawing.Point(3, 16)
        Me.lblPendingLabOrdersTitle.Name = "lblPendingLabOrdersTitle"
        Me.lblPendingLabOrdersTitle.Size = New System.Drawing.Size(222, 52)
        Me.lblPendingLabOrdersTitle.TabIndex = 0
        Me.lblPendingLabOrdersTitle.Text = "Pending Lab Orders"
        Me.lblPendingLabOrdersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlConsultationsToday
        '
        Me.pnlConsultationsToday.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlConsultationsToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlConsultationsToday.Controls.Add(Me.lblConsultationsTodayValue)
        Me.pnlConsultationsToday.Controls.Add(Me.lblConsultationsTodayTitle)
        Me.pnlConsultationsToday.Location = New System.Drawing.Point(252, 15)
        Me.pnlConsultationsToday.Name = "pnlConsultationsToday"
        Me.pnlConsultationsToday.Size = New System.Drawing.Size(230, 190)
        Me.pnlConsultationsToday.TabIndex = 1
        '
        'lblConsultationsTodayValue
        '
        Me.lblConsultationsTodayValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsultationsTodayValue.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblConsultationsTodayValue.Location = New System.Drawing.Point(3, 68)
        Me.lblConsultationsTodayValue.Name = "lblConsultationsTodayValue"
        Me.lblConsultationsTodayValue.Size = New System.Drawing.Size(222, 80)
        Me.lblConsultationsTodayValue.TabIndex = 1
        Me.lblConsultationsTodayValue.Text = "0"
        Me.lblConsultationsTodayValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblConsultationsTodayTitle
        '
        Me.lblConsultationsTodayTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsultationsTodayTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblConsultationsTodayTitle.Location = New System.Drawing.Point(3, 16)
        Me.lblConsultationsTodayTitle.Name = "lblConsultationsTodayTitle"
        Me.lblConsultationsTodayTitle.Size = New System.Drawing.Size(222, 52)
        Me.lblConsultationsTodayTitle.TabIndex = 0
        Me.lblConsultationsTodayTitle.Text = "Consultations Today"
        Me.lblConsultationsTodayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTotalPatients
        '
        Me.pnlTotalPatients.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlTotalPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTotalPatients.Controls.Add(Me.lblTotalPatientsValue)
        Me.pnlTotalPatients.Controls.Add(Me.lblTotalPatientsTitle)
        Me.pnlTotalPatients.Location = New System.Drawing.Point(6, 15)
        Me.pnlTotalPatients.Name = "pnlTotalPatients"
        Me.pnlTotalPatients.Size = New System.Drawing.Size(230, 190)
        Me.pnlTotalPatients.TabIndex = 0
        '
        'lblTotalPatientsValue
        '
        Me.lblTotalPatientsValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPatientsValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalPatientsValue.Location = New System.Drawing.Point(3, 68)
        Me.lblTotalPatientsValue.Name = "lblTotalPatientsValue"
        Me.lblTotalPatientsValue.Size = New System.Drawing.Size(222, 80)
        Me.lblTotalPatientsValue.TabIndex = 1
        Me.lblTotalPatientsValue.Text = "0"
        Me.lblTotalPatientsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalPatientsTitle
        '
        Me.lblTotalPatientsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPatientsTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalPatientsTitle.Location = New System.Drawing.Point(3, 16)
        Me.lblTotalPatientsTitle.Name = "lblTotalPatientsTitle"
        Me.lblTotalPatientsTitle.Size = New System.Drawing.Size(222, 52)
        Me.lblTotalPatientsTitle.TabIndex = 0
        Me.lblTotalPatientsTitle.Text = "Total Patients"
        Me.lblTotalPatientsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msDashboardMenu
        '
        Me.msDashboardMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miDashboard, Me.miPatients, Me.miClinical, Me.miLaboratory, Me.miPharmacy, Me.miAdministration, Me.miAccount})
        Me.msDashboardMenu.Location = New System.Drawing.Point(0, 0)
        Me.msDashboardMenu.Name = "msDashboardMenu"
        Me.msDashboardMenu.Size = New System.Drawing.Size(1008, 24)
        Me.msDashboardMenu.TabIndex = 3
        Me.msDashboardMenu.Text = "msDashboardMenu"
        '
        'miDashboard
        '
        Me.miDashboard.Name = "miDashboard"
        Me.miDashboard.Size = New System.Drawing.Size(78, 20)
        Me.miDashboard.Text = "Dashboard"
        '
        'miPatients
        '
        Me.miPatients.Name = "miPatients"
        Me.miPatients.Size = New System.Drawing.Size(61, 20)
        Me.miPatients.Text = "Patients"
        '
        'miClinical
        '
        Me.miClinical.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miConsultation, Me.miDiagnosis})
        Me.miClinical.Name = "miClinical"
        Me.miClinical.Size = New System.Drawing.Size(55, 20)
        Me.miClinical.Text = "Clinical"
        '
        'miConsultation
        '
        Me.miConsultation.Name = "miConsultation"
        Me.miConsultation.Size = New System.Drawing.Size(180, 22)
        Me.miConsultation.Text = "Consultations"
        '
        'miDiagnosis
        '
        Me.miDiagnosis.Name = "miDiagnosis"
        Me.miDiagnosis.Size = New System.Drawing.Size(180, 22)
        Me.miDiagnosis.Text = "Diagnoses"
        '
        'miLaboratory
        '
        Me.miLaboratory.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miLabOrders, Me.miExamination, Me.miMedicalTest})
        Me.miLaboratory.Name = "miLaboratory"
        Me.miLaboratory.Size = New System.Drawing.Size(78, 20)
        Me.miLaboratory.Text = "Laboratory"
        '
        'miLabOrders
        '
        Me.miLabOrders.Name = "miLabOrders"
        Me.miLabOrders.Size = New System.Drawing.Size(180, 22)
        Me.miLabOrders.Text = "Lab Orders"
        '
        'miExamination
        '
        Me.miExamination.Name = "miExamination"
        Me.miExamination.Size = New System.Drawing.Size(180, 22)
        Me.miExamination.Text = "Examinations"
        '
        'miMedicalTest
        '
        Me.miMedicalTest.Name = "miMedicalTest"
        Me.miMedicalTest.Size = New System.Drawing.Size(180, 22)
        Me.miMedicalTest.Text = "Medical Tests"
        '
        'miPharmacy
        '
        Me.miPharmacy.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miPrescription, Me.miMedicine})
        Me.miPharmacy.Name = "miPharmacy"
        Me.miPharmacy.Size = New System.Drawing.Size(72, 20)
        Me.miPharmacy.Text = "Pharmacy"
        '
        'miPrescription
        '
        Me.miPrescription.Name = "miPrescription"
        Me.miPrescription.Size = New System.Drawing.Size(180, 22)
        Me.miPrescription.Text = "Prescriptions"
        '
        'miMedicine
        '
        Me.miMedicine.Name = "miMedicine"
        Me.miMedicine.Size = New System.Drawing.Size(180, 22)
        Me.miMedicine.Text = "Medicines"
        '
        'miAdministration
        '
        Me.miAdministration.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miStaff, Me.miReports})
        Me.miAdministration.Name = "miAdministration"
        Me.miAdministration.Size = New System.Drawing.Size(98, 20)
        Me.miAdministration.Text = "Administration"
        '
        'miStaff
        '
        Me.miStaff.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miPhysician, Me.miMedTech})
        Me.miStaff.Name = "miStaff"
        Me.miStaff.Size = New System.Drawing.Size(180, 22)
        Me.miStaff.Text = "Staff"
        '
        'miPhysician
        '
        Me.miPhysician.Name = "miPhysician"
        Me.miPhysician.Size = New System.Drawing.Size(122, 22)
        Me.miPhysician.Text = "Physician"
        '
        'miMedTech
        '
        Me.miMedTech.Name = "miMedTech"
        Me.miMedTech.Size = New System.Drawing.Size(122, 22)
        Me.miMedTech.Text = "MedTech"
        '
        'miReports
        '
        Me.miReports.Name = "miReports"
        Me.miReports.Size = New System.Drawing.Size(180, 22)
        Me.miReports.Text = "Reports"
        '
        'miAccount
        '
        Me.miAccount.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAccountLogout, Me.miAccountSettings})
        Me.miAccount.Name = "miAccount"
        Me.miAccount.Size = New System.Drawing.Size(64, 20)
        Me.miAccount.Text = "Account"
        '
        'miAccountLogout
        '
        Me.miAccountLogout.Name = "miAccountLogout"
        Me.miAccountLogout.Size = New System.Drawing.Size(116, 22)
        Me.miAccountLogout.Text = "Logout"
        '
        'miAccountSettings
        '
        Me.miAccountSettings.Name = "miAccountSettings"
        Me.miAccountSettings.Size = New System.Drawing.Size(116, 22)
        Me.miAccountSettings.Text = "Settings"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.pnlDashboard)
        Me.Controls.Add(Me.pnlLoginContainer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.msDashboardMenu
        Me.Name = "frmLogin"
        Me.Text = "TrustMed Health Information System"
        Me.pnlLoginContainer.ResumeLayout(False)
        Me.pnlLoginContainer.PerformLayout()
        Me.pnlDashboard.ResumeLayout(False)
        Me.pnlDashboard.PerformLayout()
        Me.grpTodaysWork.ResumeLayout(False)
        CType(Me.dgvTodaysWork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRecentActivity.ResumeLayout(False)
        CType(Me.dgvRecentActivity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpQuickActions.ResumeLayout(False)
        Me.pnlSummaryCards.ResumeLayout(False)
        Me.pnlCompletedExaminations.ResumeLayout(False)
        Me.pnlPendingLabOrders.ResumeLayout(False)
        Me.pnlConsultationsToday.ResumeLayout(False)
        Me.pnlTotalPatients.ResumeLayout(False)
        Me.msDashboardMenu.ResumeLayout(False)
        Me.msDashboardMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblHeader As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents lblUsernameError As Label
    Friend WithEvents lblPasswordError As Label
    Friend WithEvents pnlLoginContainer As Panel
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents lblLoginError As Label
    Friend WithEvents msDashboardMenu As MenuStrip
    Friend WithEvents miDashboard As ToolStripMenuItem
    Friend WithEvents miPatients As ToolStripMenuItem
    Friend WithEvents miClinical As ToolStripMenuItem
    Friend WithEvents miConsultation As ToolStripMenuItem
    Friend WithEvents miDiagnosis As ToolStripMenuItem
    Friend WithEvents miLaboratory As ToolStripMenuItem
    Friend WithEvents miLabOrders As ToolStripMenuItem
    Friend WithEvents miExamination As ToolStripMenuItem
    Friend WithEvents miMedicalTest As ToolStripMenuItem
    Friend WithEvents miPharmacy As ToolStripMenuItem
    Friend WithEvents miPrescription As ToolStripMenuItem
    Friend WithEvents miMedicine As ToolStripMenuItem
    Friend WithEvents miAdministration As ToolStripMenuItem
    Friend WithEvents miStaff As ToolStripMenuItem
    Friend WithEvents miPhysician As ToolStripMenuItem
    Friend WithEvents miMedTech As ToolStripMenuItem
    Friend WithEvents miReports As ToolStripMenuItem
    Friend WithEvents miAccount As ToolStripMenuItem
    Friend WithEvents miAccountLogout As ToolStripMenuItem
    Friend WithEvents miAccountSettings As ToolStripMenuItem
    Friend WithEvents pnlSummaryCards As Panel
    Friend WithEvents grpQuickActions As GroupBox
    Friend WithEvents btnNewPatient As Button
    Friend WithEvents btnNewDiagnosis As Button
    Friend WithEvents btnNewConsultation As Button
    Friend WithEvents btnNewLabOrder As Button
    Friend WithEvents btnNewPrescription As Button
    Friend WithEvents pnlTotalPatients As Panel
    Friend WithEvents lblTotalPatientsTitle As Label
    Friend WithEvents lblTotalPatientsValue As Label
    Friend WithEvents pnlConsultationsToday As Panel
    Friend WithEvents lblConsultationsTodayValue As Label
    Friend WithEvents lblConsultationsTodayTitle As Label
    Friend WithEvents pnlPendingLabOrders As Panel
    Friend WithEvents lblPendingLabOrdersValue As Label
    Friend WithEvents lblPendingLabOrdersTitle As Label
    Friend WithEvents pnlCompletedExaminations As Panel
    Friend WithEvents lblCompletedExaminationsValue As Label
    Friend WithEvents lblCompletedExaminationsTitle As Label
    Friend WithEvents grpRecentActivity As GroupBox
    Friend WithEvents dgvRecentActivity As DataGridView
    Friend WithEvents grpTodaysWork As GroupBox
    Friend WithEvents dgvTodaysWork As DataGridView
End Class
