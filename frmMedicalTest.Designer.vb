<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMedicalTest
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTestID = New System.Windows.Forms.Label()
        Me.txtTestID = New System.Windows.Forms.TextBox()
        Me.lblTestName = New System.Windows.Forms.Label()
        Me.txtTestName = New System.Windows.Forms.TextBox()
        Me.lblCost = New System.Windows.Forms.Label()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.lblTestDescription = New System.Windows.Forms.Label()
        Me.txtTestDescription = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTestID
        '
        Me.lblTestID.Location = New System.Drawing.Point(20, 24)
        Me.lblTestID.Name = "lblTestID"
        Me.lblTestID.Size = New System.Drawing.Size(130, 24)
        Me.lblTestID.TabIndex = 0
        Me.lblTestID.Text = "Test ID *:"
        '
        'txtTestID
        '
        Me.txtTestID.Location = New System.Drawing.Point(160, 20)
        Me.txtTestID.Name = "txtTestID"
        Me.txtTestID.ReadOnly = True
        Me.txtTestID.Size = New System.Drawing.Size(330, 20)
        Me.txtTestID.TabIndex = 1
        Me.txtTestID.TabStop = False
        '
        'lblTestName
        '
        Me.lblTestName.Location = New System.Drawing.Point(20, 62)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(130, 24)
        Me.lblTestName.TabIndex = 2
        Me.lblTestName.Text = "Test Name *:"
        '
        'txtTestName
        '
        Me.txtTestName.Location = New System.Drawing.Point(160, 58)
        Me.txtTestName.Name = "txtTestName"
        Me.txtTestName.Size = New System.Drawing.Size(330, 20)
        Me.txtTestName.TabIndex = 3
        '
        'lblCost
        '
        Me.lblCost.Location = New System.Drawing.Point(20, 100)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(130, 24)
        Me.lblCost.TabIndex = 4
        Me.lblCost.Text = "Cost *:"
        '
        'txtCost
        '
        Me.txtCost.Location = New System.Drawing.Point(160, 96)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(330, 20)
        Me.txtCost.TabIndex = 5
        '
        'lblTestDescription
        '
        Me.lblTestDescription.Location = New System.Drawing.Point(20, 138)
        Me.lblTestDescription.Name = "lblTestDescription"
        Me.lblTestDescription.Size = New System.Drawing.Size(130, 24)
        Me.lblTestDescription.TabIndex = 6
        Me.lblTestDescription.Text = "Description *:"
        '
        'txtTestDescription
        '
        Me.txtTestDescription.Location = New System.Drawing.Point(160, 134)
        Me.txtTestDescription.Multiline = True
        Me.txtTestDescription.Name = "txtTestDescription"
        Me.txtTestDescription.Size = New System.Drawing.Size(330, 92)
        Me.txtTestDescription.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkBlue
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(300, 244)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 34)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(400, 244)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 34)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmMedicalTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 295)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtTestDescription)
        Me.Controls.Add(Me.lblTestDescription)
        Me.Controls.Add(Me.txtCost)
        Me.Controls.Add(Me.lblCost)
        Me.Controls.Add(Me.txtTestName)
        Me.Controls.Add(Me.lblTestName)
        Me.Controls.Add(Me.txtTestID)
        Me.Controls.Add(Me.lblTestID)
        Me.Name = "frmMedicalTest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Medical Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTestID As Label
    Friend WithEvents txtTestID As TextBox
    Friend WithEvents lblTestName As Label
    Friend WithEvents txtTestName As TextBox
    Friend WithEvents lblCost As Label
    Friend WithEvents txtCost As TextBox
    Friend WithEvents lblTestDescription As Label
    Friend WithEvents txtTestDescription As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
