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
        Me.btnTogglePassword = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblUsernameError = New System.Windows.Forms.Label()
        Me.lblPasswordError = New System.Windows.Forms.Label()
        Me.pnlLoginContainer = New System.Windows.Forms.Panel()
        Me.pnlLoginCard = New System.Windows.Forms.Panel()
        Me.pbLoginLogo = New System.Windows.Forms.PictureBox()
        Me.lblLoginError = New System.Windows.Forms.Label()
        Me.pnlDashboard = New System.Windows.Forms.Panel()
        Me.grpQuickActions = New System.Windows.Forms.GroupBox()
        Me.btnNewPatient = New System.Windows.Forms.Button()
        Me.btnNewDiagnosis = New System.Windows.Forms.Button()
        Me.btnNewConsultation = New System.Windows.Forms.Button()
        Me.btnNewLabOrder = New System.Windows.Forms.Button()
        Me.btnNewPrescription = New System.Windows.Forms.Button()
        Me.pnlSummaryCards = New System.Windows.Forms.Panel()
        Me.pnlBranding = New System.Windows.Forms.Panel()
        Me.pbTrustMedLogo = New System.Windows.Forms.PictureBox()
        Me.lblBrandingTitle = New System.Windows.Forms.Label()
        Me.pnlLabOrders = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLabOrdersValue = New System.Windows.Forms.Label()
        Me.lblLabOrdersTitle = New System.Windows.Forms.Label()
        Me.pnlTotalPatients = New System.Windows.Forms.Panel()
        Me.lblTotalPatientsValue = New System.Windows.Forms.Label()
        Me.lblTotalPatientsTitle = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
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
        Me.pnlLoginCard.SuspendLayout()
        CType(Me.pbLoginLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDashboard.SuspendLayout()
        Me.grpQuickActions.SuspendLayout()
        Me.pnlSummaryCards.SuspendLayout()
        Me.pnlBranding.SuspendLayout()
        CType(Me.pbTrustMedLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLabOrders.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlTotalPatients.SuspendLayout()
        Me.msDashboardMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblHeader.Location = New System.Drawing.Point(30, 124)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(460, 42)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "TrustMed Health Information System"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.Location = New System.Drawing.Point(60, 210)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(84, 19)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username: *"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(60, 292)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(80, 19)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password: *"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(60, 236)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(400, 27)
        Me.txtUsername.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(60, 318)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(370, 27)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'btnTogglePassword
        '
        Me.btnTogglePassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnTogglePassword.FlatAppearance.BorderSize = 0
        Me.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTogglePassword.Location = New System.Drawing.Point(432, 318)
        Me.btnTogglePassword.Name = "btnTogglePassword"
        Me.btnTogglePassword.Size = New System.Drawing.Size(28, 27)
        Me.btnTogglePassword.TabIndex = 5
        Me.btnTogglePassword.UseVisualStyleBackColor = False
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(170, 420)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(100, 40)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnClose.Location = New System.Drawing.Point(280, 420)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 40)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblUsernameError
        '
        Me.lblUsernameError.AutoSize = True
        Me.lblUsernameError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsernameError.ForeColor = System.Drawing.Color.Red
        Me.lblUsernameError.Location = New System.Drawing.Point(60, 269)
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
        Me.lblPasswordError.Location = New System.Drawing.Point(60, 351)
        Me.lblPasswordError.Name = "lblPasswordError"
        Me.lblPasswordError.Size = New System.Drawing.Size(0, 15)
        Me.lblPasswordError.TabIndex = 8
        Me.lblPasswordError.Visible = False
        '
        'pnlLoginContainer
        '
        Me.pnlLoginContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlLoginContainer.Controls.Add(Me.pnlLoginCard)
        Me.pnlLoginContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLoginContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlLoginContainer.Name = "pnlLoginContainer"
        Me.pnlLoginContainer.Size = New System.Drawing.Size(1348, 729)
        Me.pnlLoginContainer.TabIndex = 10
        '
        'pnlLoginCard
        '
        Me.pnlLoginCard.BackColor = System.Drawing.Color.White
        Me.pnlLoginCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLoginCard.Controls.Add(Me.pbLoginLogo)
        Me.pnlLoginCard.Controls.Add(Me.lblLoginError)
        Me.pnlLoginCard.Controls.Add(Me.lblPasswordError)
        Me.pnlLoginCard.Controls.Add(Me.lblUsernameError)
        Me.pnlLoginCard.Controls.Add(Me.btnClose)
        Me.pnlLoginCard.Controls.Add(Me.btnLogin)
        Me.pnlLoginCard.Controls.Add(Me.txtPassword)
        Me.pnlLoginCard.Controls.Add(Me.btnTogglePassword)
        Me.pnlLoginCard.Controls.Add(Me.txtUsername)
        Me.pnlLoginCard.Controls.Add(Me.lblPassword)
        Me.pnlLoginCard.Controls.Add(Me.lblUsername)
        Me.pnlLoginCard.Controls.Add(Me.lblHeader)
        Me.pnlLoginCard.Location = New System.Drawing.Point(414, 92)
        Me.pnlLoginCard.Name = "pnlLoginCard"
        Me.pnlLoginCard.Size = New System.Drawing.Size(520, 540)
        Me.pnlLoginCard.TabIndex = 11
        '
        'pbLoginLogo
        '
        Me.pbLoginLogo.BackColor = System.Drawing.Color.Transparent
        Me.pbLoginLogo.Location = New System.Drawing.Point(190, 26)
        Me.pbLoginLogo.Name = "pbLoginLogo"
        Me.pbLoginLogo.Size = New System.Drawing.Size(140, 90)
        Me.pbLoginLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLoginLogo.TabIndex = 10
        Me.pbLoginLogo.TabStop = False
        '
        'lblLoginError
        '
        Me.lblLoginError.AutoSize = True
        Me.lblLoginError.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginError.ForeColor = System.Drawing.Color.Red
        Me.lblLoginError.Location = New System.Drawing.Point(60, 378)
        Me.lblLoginError.Name = "lblLoginError"
        Me.lblLoginError.Size = New System.Drawing.Size(0, 17)
        Me.lblLoginError.TabIndex = 9
        Me.lblLoginError.Visible = False
        '
        'pnlDashboard
        '
        Me.pnlDashboard.Controls.Add(Me.grpQuickActions)
        Me.pnlDashboard.Controls.Add(Me.pnlSummaryCards)
        Me.pnlDashboard.Controls.Add(Me.msDashboardMenu)
        Me.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDashboard.Location = New System.Drawing.Point(0, 0)
        Me.pnlDashboard.Name = "pnlDashboard"
        Me.pnlDashboard.Size = New System.Drawing.Size(1348, 729)
        Me.pnlDashboard.TabIndex = 11
        Me.pnlDashboard.Visible = False
        '
        'grpQuickActions
        '
        Me.grpQuickActions.Controls.Add(Me.btnNewPatient)
        Me.grpQuickActions.Controls.Add(Me.btnNewDiagnosis)
        Me.grpQuickActions.Controls.Add(Me.btnNewConsultation)
        Me.grpQuickActions.Controls.Add(Me.btnNewLabOrder)
        Me.grpQuickActions.Controls.Add(Me.btnNewPrescription)
        Me.grpQuickActions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpQuickActions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.grpQuickActions.Location = New System.Drawing.Point(12, 239)
        Me.grpQuickActions.Name = "grpQuickActions"
        Me.grpQuickActions.Size = New System.Drawing.Size(1324, 94)
        Me.grpQuickActions.TabIndex = 5
        Me.grpQuickActions.TabStop = False
        Me.grpQuickActions.Text = "Quick Actions"
        '
        'btnNewPatient
        '
        Me.btnNewPatient.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnNewPatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNewPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewPatient.ForeColor = System.Drawing.Color.White
        Me.btnNewPatient.Image = CType(resources.GetObject("btnNewPatient.Image"), System.Drawing.Image)
        Me.btnNewPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewPatient.Location = New System.Drawing.Point(14, 36)
        Me.btnNewPatient.Name = "btnNewPatient"
        Me.btnNewPatient.Padding = New System.Windows.Forms.Padding(80, 0, 0, 0)
        Me.btnNewPatient.Size = New System.Drawing.Size(250, 42)
        Me.btnNewPatient.TabIndex = 0
        Me.btnNewPatient.Text = "New Patient"
        Me.btnNewPatient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNewPatient.UseVisualStyleBackColor = False
        '
        'btnNewDiagnosis
        '
        Me.btnNewDiagnosis.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnNewDiagnosis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewDiagnosis.ForeColor = System.Drawing.Color.White
        Me.btnNewDiagnosis.Image = CType(resources.GetObject("btnNewDiagnosis.Image"), System.Drawing.Image)
        Me.btnNewDiagnosis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewDiagnosis.Location = New System.Drawing.Point(274, 36)
        Me.btnNewDiagnosis.Name = "btnNewDiagnosis"
        Me.btnNewDiagnosis.Padding = New System.Windows.Forms.Padding(60, 0, 0, 0)
        Me.btnNewDiagnosis.Size = New System.Drawing.Size(250, 42)
        Me.btnNewDiagnosis.TabIndex = 1
        Me.btnNewDiagnosis.Text = "New Diagnosis"
        Me.btnNewDiagnosis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNewDiagnosis.UseVisualStyleBackColor = False
        '
        'btnNewConsultation
        '
        Me.btnNewConsultation.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnNewConsultation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewConsultation.ForeColor = System.Drawing.Color.White
        Me.btnNewConsultation.Image = CType(resources.GetObject("btnNewConsultation.Image"), System.Drawing.Image)
        Me.btnNewConsultation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewConsultation.Location = New System.Drawing.Point(534, 36)
        Me.btnNewConsultation.Name = "btnNewConsultation"
        Me.btnNewConsultation.Padding = New System.Windows.Forms.Padding(55, 0, 0, 0)
        Me.btnNewConsultation.Size = New System.Drawing.Size(250, 42)
        Me.btnNewConsultation.TabIndex = 2
        Me.btnNewConsultation.Text = "New Consultation"
        Me.btnNewConsultation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNewConsultation.UseVisualStyleBackColor = False
        '
        'btnNewLabOrder
        '
        Me.btnNewLabOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnNewLabOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewLabOrder.ForeColor = System.Drawing.Color.White
        Me.btnNewLabOrder.Image = CType(resources.GetObject("btnNewLabOrder.Image"), System.Drawing.Image)
        Me.btnNewLabOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewLabOrder.Location = New System.Drawing.Point(794, 36)
        Me.btnNewLabOrder.Name = "btnNewLabOrder"
        Me.btnNewLabOrder.Padding = New System.Windows.Forms.Padding(60, 0, 0, 0)
        Me.btnNewLabOrder.Size = New System.Drawing.Size(250, 42)
        Me.btnNewLabOrder.TabIndex = 3
        Me.btnNewLabOrder.Text = "New Lab Order"
        Me.btnNewLabOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNewLabOrder.UseVisualStyleBackColor = False
        '
        'btnNewPrescription
        '
        Me.btnNewPrescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnNewPrescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewPrescription.ForeColor = System.Drawing.Color.White
        Me.btnNewPrescription.Image = CType(resources.GetObject("btnNewPrescription.Image"), System.Drawing.Image)
        Me.btnNewPrescription.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewPrescription.Location = New System.Drawing.Point(1054, 36)
        Me.btnNewPrescription.Name = "btnNewPrescription"
        Me.btnNewPrescription.Padding = New System.Windows.Forms.Padding(60, 0, 0, 0)
        Me.btnNewPrescription.Size = New System.Drawing.Size(250, 42)
        Me.btnNewPrescription.TabIndex = 4
        Me.btnNewPrescription.Text = "New Prescription"
        Me.btnNewPrescription.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNewPrescription.UseVisualStyleBackColor = False
        '
        'pnlSummaryCards
        '
        Me.pnlSummaryCards.Controls.Add(Me.pnlBranding)
        Me.pnlSummaryCards.Controls.Add(Me.pnlLabOrders)
        Me.pnlSummaryCards.Controls.Add(Me.pnlTotalPatients)
        Me.pnlSummaryCards.Location = New System.Drawing.Point(12, 39)
        Me.pnlSummaryCards.Name = "pnlSummaryCards"
        Me.pnlSummaryCards.Size = New System.Drawing.Size(1324, 190)
        Me.pnlSummaryCards.TabIndex = 4
        '
        'pnlBranding
        '
        Me.pnlBranding.BackColor = System.Drawing.Color.White
        Me.pnlBranding.Controls.Add(Me.pbTrustMedLogo)
        Me.pnlBranding.Controls.Add(Me.lblBrandingTitle)
        Me.pnlBranding.Location = New System.Drawing.Point(3, 15)
        Me.pnlBranding.Name = "pnlBranding"
        Me.pnlBranding.Size = New System.Drawing.Size(424, 160)
        Me.pnlBranding.TabIndex = 2
        '
        'pbTrustMedLogo
        '
        Me.pbTrustMedLogo.BackColor = System.Drawing.Color.Transparent
        Me.pbTrustMedLogo.Image = CType(resources.GetObject("pbTrustMedLogo.Image"), System.Drawing.Image)
        Me.pbTrustMedLogo.Location = New System.Drawing.Point(142, 58)
        Me.pbTrustMedLogo.Name = "pbTrustMedLogo"
        Me.pbTrustMedLogo.Size = New System.Drawing.Size(140, 90)
        Me.pbTrustMedLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbTrustMedLogo.TabIndex = 1
        Me.pbTrustMedLogo.TabStop = False
        '
        'lblBrandingTitle
        '
        Me.lblBrandingTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBrandingTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblBrandingTitle.Location = New System.Drawing.Point(3, 8)
        Me.lblBrandingTitle.Name = "lblBrandingTitle"
        Me.lblBrandingTitle.Size = New System.Drawing.Size(418, 44)
        Me.lblBrandingTitle.TabIndex = 0
        Me.lblBrandingTitle.Text = "TrustMed Health Information System"
        Me.lblBrandingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlLabOrders
        '
        Me.pnlLabOrders.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlLabOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLabOrders.Controls.Add(Me.Panel1)
        Me.pnlLabOrders.Controls.Add(Me.lblLabOrdersValue)
        Me.pnlLabOrders.Controls.Add(Me.lblLabOrdersTitle)
        Me.pnlLabOrders.Location = New System.Drawing.Point(433, 15)
        Me.pnlLabOrders.Name = "pnlLabOrders"
        Me.pnlLabOrders.Size = New System.Drawing.Size(438, 160)
        Me.pnlLabOrders.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(438, 160)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Location = New System.Drawing.Point(-1, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(438, 160)
        Me.Panel2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(3, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(430, 72)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "0"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(3, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(430, 44)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total Lab Orders"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(82, 62)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(50, 0, 0, 0)
        Me.Button1.Size = New System.Drawing.Size(250, 42)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "New Consultation"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(430, 72)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "0"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(3, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(430, 44)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Total Lab Orders"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLabOrdersValue
        '
        Me.lblLabOrdersValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabOrdersValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblLabOrdersValue.Location = New System.Drawing.Point(3, 62)
        Me.lblLabOrdersValue.Name = "lblLabOrdersValue"
        Me.lblLabOrdersValue.Size = New System.Drawing.Size(430, 72)
        Me.lblLabOrdersValue.TabIndex = 1
        Me.lblLabOrdersValue.Text = "0"
        Me.lblLabOrdersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLabOrdersTitle
        '
        Me.lblLabOrdersTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblLabOrdersTitle.Location = New System.Drawing.Point(3, 14)
        Me.lblLabOrdersTitle.Name = "lblLabOrdersTitle"
        Me.lblLabOrdersTitle.Size = New System.Drawing.Size(430, 44)
        Me.lblLabOrdersTitle.TabIndex = 0
        Me.lblLabOrdersTitle.Text = "Total Lab Orders"
        Me.lblLabOrdersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTotalPatients
        '
        Me.pnlTotalPatients.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlTotalPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTotalPatients.Controls.Add(Me.lblTotalPatientsValue)
        Me.pnlTotalPatients.Controls.Add(Me.lblTotalPatientsTitle)
        Me.pnlTotalPatients.Controls.Add(Me.Button2)
        Me.pnlTotalPatients.Location = New System.Drawing.Point(877, 15)
        Me.pnlTotalPatients.Name = "pnlTotalPatients"
        Me.pnlTotalPatients.Size = New System.Drawing.Size(438, 160)
        Me.pnlTotalPatients.TabIndex = 0
        '
        'lblTotalPatientsValue
        '
        Me.lblTotalPatientsValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalPatientsValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTotalPatientsValue.Location = New System.Drawing.Point(3, 62)
        Me.lblTotalPatientsValue.Name = "lblTotalPatientsValue"
        Me.lblTotalPatientsValue.Size = New System.Drawing.Size(430, 72)
        Me.lblTotalPatientsValue.TabIndex = 1
        Me.lblTotalPatientsValue.Text = "0"
        Me.lblTotalPatientsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalPatientsTitle
        '
        Me.lblTotalPatientsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalPatientsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTotalPatientsTitle.Location = New System.Drawing.Point(3, 14)
        Me.lblTotalPatientsTitle.Name = "lblTotalPatientsTitle"
        Me.lblTotalPatientsTitle.Size = New System.Drawing.Size(430, 44)
        Me.lblTotalPatientsTitle.TabIndex = 0
        Me.lblTotalPatientsTitle.Text = "Total Patients"
        Me.lblTotalPatientsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(84, 64)
        Me.Button2.Name = "Button2"
        Me.Button2.Padding = New System.Windows.Forms.Padding(50, 0, 0, 0)
        Me.Button2.Size = New System.Drawing.Size(250, 42)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "New Consultation"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'msDashboardMenu
        '
        Me.msDashboardMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miDashboard, Me.miPatients, Me.miClinical, Me.miLaboratory, Me.miPharmacy, Me.miAdministration, Me.miAccount})
        Me.msDashboardMenu.Location = New System.Drawing.Point(0, 0)
        Me.msDashboardMenu.Name = "msDashboardMenu"
        Me.msDashboardMenu.Size = New System.Drawing.Size(1348, 24)
        Me.msDashboardMenu.TabIndex = 3
        Me.msDashboardMenu.Text = "msDashboardMenu"
        '
        'miDashboard
        '
        Me.miDashboard.Name = "miDashboard"
        Me.miDashboard.Size = New System.Drawing.Size(76, 20)
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
        Me.miClinical.Size = New System.Drawing.Size(58, 20)
        Me.miClinical.Text = "Clinical"
        '
        'miConsultation
        '
        Me.miConsultation.Name = "miConsultation"
        Me.miConsultation.Size = New System.Drawing.Size(147, 22)
        Me.miConsultation.Text = "Consultations"
        '
        'miDiagnosis
        '
        Me.miDiagnosis.Name = "miDiagnosis"
        Me.miDiagnosis.Size = New System.Drawing.Size(147, 22)
        Me.miDiagnosis.Text = "Diagnoses"
        '
        'miLaboratory
        '
        Me.miLaboratory.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miLabOrders, Me.miExamination, Me.miMedicalTest})
        Me.miLaboratory.Name = "miLaboratory"
        Me.miLaboratory.Size = New System.Drawing.Size(76, 20)
        Me.miLaboratory.Text = "Laboratory"
        '
        'miLabOrders
        '
        Me.miLabOrders.Name = "miLabOrders"
        Me.miLabOrders.Size = New System.Drawing.Size(145, 22)
        Me.miLabOrders.Text = "Lab Orders"
        '
        'miExamination
        '
        Me.miExamination.Name = "miExamination"
        Me.miExamination.Size = New System.Drawing.Size(145, 22)
        Me.miExamination.Text = "Examinations"
        '
        'miMedicalTest
        '
        Me.miMedicalTest.Name = "miMedicalTest"
        Me.miMedicalTest.Size = New System.Drawing.Size(145, 22)
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
        Me.miPrescription.Size = New System.Drawing.Size(142, 22)
        Me.miPrescription.Text = "Prescriptions"
        '
        'miMedicine
        '
        Me.miMedicine.Name = "miMedicine"
        Me.miMedicine.Size = New System.Drawing.Size(142, 22)
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
        Me.miStaff.Size = New System.Drawing.Size(114, 22)
        Me.miStaff.Text = "Staff"
        '
        'miPhysician
        '
        Me.miPhysician.Name = "miPhysician"
        Me.miPhysician.Size = New System.Drawing.Size(124, 22)
        Me.miPhysician.Text = "Physician"
        '
        'miMedTech
        '
        Me.miMedTech.Name = "miMedTech"
        Me.miMedTech.Size = New System.Drawing.Size(124, 22)
        Me.miMedTech.Text = "MedTech"
        '
        'miReports
        '
        Me.miReports.Name = "miReports"
        Me.miReports.Size = New System.Drawing.Size(114, 22)
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
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1348, 729)
        Me.Controls.Add(Me.pnlDashboard)
        Me.Controls.Add(Me.pnlLoginContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.msDashboardMenu
        Me.MaximizeBox = False
        Me.Name = "frmDashboard"
        Me.Text = "TrustMed Health Information System"
        Me.pnlLoginContainer.ResumeLayout(False)
        Me.pnlLoginCard.ResumeLayout(False)
        Me.pnlLoginCard.PerformLayout()
        CType(Me.pbLoginLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDashboard.ResumeLayout(False)
        Me.pnlDashboard.PerformLayout()
        Me.grpQuickActions.ResumeLayout(False)
        Me.pnlSummaryCards.ResumeLayout(False)
        Me.pnlBranding.ResumeLayout(False)
        CType(Me.pbTrustMedLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLabOrders.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlTotalPatients.ResumeLayout(False)
        Me.msDashboardMenu.ResumeLayout(False)
        Me.msDashboardMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLoginCard As Panel
    Friend WithEvents pbLoginLogo As PictureBox
    Friend WithEvents lblHeader As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnTogglePassword As Button
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
    Friend WithEvents pnlTotalPatients As Panel
    Friend WithEvents lblTotalPatientsValue As Label
    Friend WithEvents lblTotalPatientsTitle As Label
    Friend WithEvents pnlLabOrders As Panel
    Friend WithEvents lblLabOrdersValue As Label
    Friend WithEvents lblLabOrdersTitle As Label
    Friend WithEvents pnlBranding As Panel
    Friend WithEvents lblBrandingTitle As Label
    Friend WithEvents pbTrustMedLogo As PictureBox
    Friend WithEvents grpQuickActions As GroupBox
    Friend WithEvents btnNewPatient As Button
    Friend WithEvents btnNewDiagnosis As Button
    Friend WithEvents btnNewConsultation As Button
    Friend WithEvents btnNewLabOrder As Button
    Friend WithEvents btnNewPrescription As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
