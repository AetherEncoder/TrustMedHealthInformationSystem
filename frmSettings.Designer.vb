<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.grpUsername = New System.Windows.Forms.GroupBox()
        Me.btnSaveUsername = New System.Windows.Forms.Button()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.grpPassword = New System.Windows.Forms.GroupBox()
        Me.btnSavePassword = New System.Windows.Forms.Button()
        Me.txtRetypePassword = New System.Windows.Forms.TextBox()
        Me.lblRetypePassword = New System.Windows.Forms.Label()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.grpDanger = New System.Windows.Forms.GroupBox()
        Me.btnDeleteAccount = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpUsername.SuspendLayout()
        Me.grpPassword.SuspendLayout()
        Me.grpDanger.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpUsername
        '
        Me.grpUsername.Controls.Add(Me.btnSaveUsername)
        Me.grpUsername.Controls.Add(Me.txtUsername)
        Me.grpUsername.Controls.Add(Me.lblUsername)
        Me.grpUsername.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.grpUsername.Location = New System.Drawing.Point(16, 14)
        Me.grpUsername.Name = "grpUsername"
        Me.grpUsername.Size = New System.Drawing.Size(488, 104)
        Me.grpUsername.TabIndex = 0
        Me.grpUsername.TabStop = False
        Me.grpUsername.Text = "Update Username"
        '
        'btnSaveUsername
        '
        Me.btnSaveUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnSaveUsername.FlatAppearance.BorderSize = 0
        Me.btnSaveUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveUsername.ForeColor = System.Drawing.Color.White
        Me.btnSaveUsername.Location = New System.Drawing.Point(336, 60)
        Me.btnSaveUsername.Name = "btnSaveUsername"
        Me.btnSaveUsername.Size = New System.Drawing.Size(136, 30)
        Me.btnSaveUsername.TabIndex = 2
        Me.btnSaveUsername.Text = "Save Username"
        Me.btnSaveUsername.UseVisualStyleBackColor = False
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(120, 28)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(352, 23)
        Me.txtUsername.TabIndex = 1
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.ForeColor = System.Drawing.Color.Black
        Me.lblUsername.Location = New System.Drawing.Point(16, 31)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(64, 15)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username"
        '
        'grpPassword
        '
        Me.grpPassword.Controls.Add(Me.btnSavePassword)
        Me.grpPassword.Controls.Add(Me.txtRetypePassword)
        Me.grpPassword.Controls.Add(Me.lblRetypePassword)
        Me.grpPassword.Controls.Add(Me.txtNewPassword)
        Me.grpPassword.Controls.Add(Me.lblNewPassword)
        Me.grpPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.grpPassword.Location = New System.Drawing.Point(16, 126)
        Me.grpPassword.Name = "grpPassword"
        Me.grpPassword.Size = New System.Drawing.Size(488, 146)
        Me.grpPassword.TabIndex = 1
        Me.grpPassword.TabStop = False
        Me.grpPassword.Text = "Change Password"
        '
        'btnSavePassword
        '
        Me.btnSavePassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnSavePassword.FlatAppearance.BorderSize = 0
        Me.btnSavePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSavePassword.ForeColor = System.Drawing.Color.White
        Me.btnSavePassword.Location = New System.Drawing.Point(336, 106)
        Me.btnSavePassword.Name = "btnSavePassword"
        Me.btnSavePassword.Size = New System.Drawing.Size(136, 30)
        Me.btnSavePassword.TabIndex = 4
        Me.btnSavePassword.Text = "Save Password"
        Me.btnSavePassword.UseVisualStyleBackColor = False
        '
        'txtRetypePassword
        '
        Me.txtRetypePassword.Location = New System.Drawing.Point(120, 66)
        Me.txtRetypePassword.Name = "txtRetypePassword"
        Me.txtRetypePassword.Size = New System.Drawing.Size(352, 23)
        Me.txtRetypePassword.TabIndex = 3
        Me.txtRetypePassword.UseSystemPasswordChar = True
        '
        'lblRetypePassword
        '
        Me.lblRetypePassword.AutoSize = True
        Me.lblRetypePassword.ForeColor = System.Drawing.Color.Black
        Me.lblRetypePassword.Location = New System.Drawing.Point(16, 69)
        Me.lblRetypePassword.Name = "lblRetypePassword"
        Me.lblRetypePassword.Size = New System.Drawing.Size(102, 15)
        Me.lblRetypePassword.TabIndex = 2
        Me.lblRetypePassword.Text = "Retype Password"
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Location = New System.Drawing.Point(120, 28)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.Size = New System.Drawing.Size(352, 23)
        Me.txtNewPassword.TabIndex = 1
        Me.txtNewPassword.UseSystemPasswordChar = True
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.ForeColor = System.Drawing.Color.Black
        Me.lblNewPassword.Location = New System.Drawing.Point(16, 31)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(88, 15)
        Me.lblNewPassword.TabIndex = 0
        Me.lblNewPassword.Text = "New Password"
        '
        'grpDanger
        '
        Me.grpDanger.Controls.Add(Me.btnDeleteAccount)
        Me.grpDanger.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpDanger.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.grpDanger.Location = New System.Drawing.Point(16, 280)
        Me.grpDanger.Name = "grpDanger"
        Me.grpDanger.Size = New System.Drawing.Size(488, 76)
        Me.grpDanger.TabIndex = 2
        Me.grpDanger.TabStop = False
        Me.grpDanger.Text = "Delete Account"
        '
        'btnDeleteAccount
        '
        Me.btnDeleteAccount.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnDeleteAccount.FlatAppearance.BorderSize = 0
        Me.btnDeleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteAccount.ForeColor = System.Drawing.Color.White
        Me.btnDeleteAccount.Location = New System.Drawing.Point(336, 28)
        Me.btnDeleteAccount.Name = "btnDeleteAccount"
        Me.btnDeleteAccount.Size = New System.Drawing.Size(136, 30)
        Me.btnDeleteAccount.TabIndex = 0
        Me.btnDeleteAccount.Text = "Delete Account"
        Me.btnDeleteAccount.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(400, 364)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 30)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(520, 406)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpDanger)
        Me.Controls.Add(Me.grpPassword)
        Me.Controls.Add(Me.grpUsername)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Account Settings"
        Me.grpUsername.ResumeLayout(False)
        Me.grpUsername.PerformLayout()
        Me.grpPassword.ResumeLayout(False)
        Me.grpPassword.PerformLayout()
        Me.grpDanger.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpUsername As GroupBox
    Friend WithEvents btnSaveUsername As Button
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents grpPassword As GroupBox
    Friend WithEvents btnSavePassword As Button
    Friend WithEvents txtRetypePassword As TextBox
    Friend WithEvents lblRetypePassword As Label
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents grpDanger As GroupBox
    Friend WithEvents btnDeleteAccount As Button
    Friend WithEvents btnClose As Button
End Class

