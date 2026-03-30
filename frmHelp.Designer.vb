<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHelp
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.lblUsernameTitle = New System.Windows.Forms.Label()
        Me.lblPasswordTitle = New System.Windows.Forms.Label()
        Me.lblUsernameValue = New System.Windows.Forms.Label()
        Me.lblPasswordValue = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(12, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(460, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Login Help"
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblInfo.Location = New System.Drawing.Point(14, 52)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(458, 38)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "Sample Credentials"
        '
        'lblUsernameTitle
        '
        Me.lblUsernameTitle.AutoSize = True
        Me.lblUsernameTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsernameTitle.Location = New System.Drawing.Point(16, 108)
        Me.lblUsernameTitle.Name = "lblUsernameTitle"
        Me.lblUsernameTitle.Size = New System.Drawing.Size(80, 19)
        Me.lblUsernameTitle.TabIndex = 2
        Me.lblUsernameTitle.Text = "Username:"
        '
        'lblPasswordTitle
        '
        Me.lblPasswordTitle.AutoSize = True
        Me.lblPasswordTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPasswordTitle.Location = New System.Drawing.Point(16, 144)
        Me.lblPasswordTitle.Name = "lblPasswordTitle"
        Me.lblPasswordTitle.Size = New System.Drawing.Size(77, 19)
        Me.lblPasswordTitle.TabIndex = 3
        Me.lblPasswordTitle.Text = "Password:"
        '
        'lblUsernameValue
        '
        Me.lblUsernameValue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblUsernameValue.Location = New System.Drawing.Point(116, 108)
        Me.lblUsernameValue.Name = "lblUsernameValue"
        Me.lblUsernameValue.Size = New System.Drawing.Size(356, 19)
        Me.lblUsernameValue.TabIndex = 4
        Me.lblUsernameValue.Text = "-"
        '
        'lblPasswordValue
        '
        Me.lblPasswordValue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPasswordValue.Location = New System.Drawing.Point(116, 144)
        Me.lblPasswordValue.Name = "lblPasswordValue"
        Me.lblPasswordValue.Size = New System.Drawing.Size(356, 19)
        Me.lblPasswordValue.TabIndex = 5
        Me.lblPasswordValue.Text = "-"
        '
        'frmHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 201)
        Me.Controls.Add(Me.lblPasswordValue)
        Me.Controls.Add(Me.lblUsernameValue)
        Me.Controls.Add(Me.lblPasswordTitle)
        Me.Controls.Add(Me.lblUsernameTitle)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHelp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblInfo As Label
    Friend WithEvents lblUsernameTitle As Label
    Friend WithEvents lblPasswordTitle As Label
    Friend WithEvents lblUsernameValue As Label
    Friend WithEvents lblPasswordValue As Label
End Class
