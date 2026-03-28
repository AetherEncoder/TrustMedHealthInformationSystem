<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDiagnosisEntry
    Inherits System.Windows.Forms.Form

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
        Me.lblDiagnosisID = New System.Windows.Forms.Label()
        Me.txtDiagnosisID = New System.Windows.Forms.TextBox()
        Me.lblPatient = New System.Windows.Forms.Label()
        Me.cboPatient = New System.Windows.Forms.ComboBox()
        Me.lblPhysician = New System.Windows.Forms.Label()
        Me.cboPhysician = New System.Windows.Forms.ComboBox()
        Me.lblDiagnosisName = New System.Windows.Forms.Label()
        Me.txtDiagnosisName = New System.Windows.Forms.TextBox()
        Me.lblDiagnosisDescription = New System.Windows.Forms.Label()
        Me.txtDiagnosisDescription = New System.Windows.Forms.TextBox()
        Me.lblDiagnosisDate = New System.Windows.Forms.Label()
        Me.dtpDiagnosisDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblDiagnosisID
        '
        Me.lblDiagnosisID.Location = New System.Drawing.Point(20, 24)
        Me.lblDiagnosisID.Name = "lblDiagnosisID"
        Me.lblDiagnosisID.Size = New System.Drawing.Size(130, 24)
        Me.lblDiagnosisID.TabIndex = 0
        Me.lblDiagnosisID.Text = "Diagnosis ID *:"
        '
        'txtDiagnosisID
        '
        Me.txtDiagnosisID.Location = New System.Drawing.Point(160, 20)
        Me.txtDiagnosisID.Name = "txtDiagnosisID"
        Me.txtDiagnosisID.ReadOnly = True
        Me.txtDiagnosisID.Size = New System.Drawing.Size(330, 20)
        Me.txtDiagnosisID.TabIndex = 1
        Me.txtDiagnosisID.TabStop = False
        '
        'lblPatient
        '
        Me.lblPatient.Location = New System.Drawing.Point(20, 62)
        Me.lblPatient.Name = "lblPatient"
        Me.lblPatient.Size = New System.Drawing.Size(130, 24)
        Me.lblPatient.TabIndex = 2
        Me.lblPatient.Text = "Patient *:"
        '
        'cboPatient
        '
        Me.cboPatient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPatient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboPatient.FormattingEnabled = True
        Me.cboPatient.Location = New System.Drawing.Point(160, 58)
        Me.cboPatient.Name = "cboPatient"
        Me.cboPatient.Size = New System.Drawing.Size(330, 21)
        Me.cboPatient.TabIndex = 3
        '
        'lblPhysician
        '
        Me.lblPhysician.Location = New System.Drawing.Point(20, 100)
        Me.lblPhysician.Name = "lblPhysician"
        Me.lblPhysician.Size = New System.Drawing.Size(130, 24)
        Me.lblPhysician.TabIndex = 4
        Me.lblPhysician.Text = "Physician *:"
        '
        'cboPhysician
        '
        Me.cboPhysician.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPhysician.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPhysician.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboPhysician.FormattingEnabled = True
        Me.cboPhysician.Location = New System.Drawing.Point(160, 96)
        Me.cboPhysician.Name = "cboPhysician"
        Me.cboPhysician.Size = New System.Drawing.Size(330, 21)
        Me.cboPhysician.TabIndex = 5
        '
        'lblDiagnosisName
        '
        Me.lblDiagnosisName.Location = New System.Drawing.Point(20, 138)
        Me.lblDiagnosisName.Name = "lblDiagnosisName"
        Me.lblDiagnosisName.Size = New System.Drawing.Size(130, 24)
        Me.lblDiagnosisName.TabIndex = 6
        Me.lblDiagnosisName.Text = "Diagnosis Name *:"
        '
        'txtDiagnosisName
        '
        Me.txtDiagnosisName.Location = New System.Drawing.Point(160, 134)
        Me.txtDiagnosisName.Name = "txtDiagnosisName"
        Me.txtDiagnosisName.Size = New System.Drawing.Size(330, 20)
        Me.txtDiagnosisName.TabIndex = 7
        '
        'lblDiagnosisDescription
        '
        Me.lblDiagnosisDescription.Location = New System.Drawing.Point(20, 172)
        Me.lblDiagnosisDescription.Name = "lblDiagnosisDescription"
        Me.lblDiagnosisDescription.Size = New System.Drawing.Size(130, 24)
        Me.lblDiagnosisDescription.TabIndex = 8
        Me.lblDiagnosisDescription.Text = "Description *:"
        '
        'txtDiagnosisDescription
        '
        Me.txtDiagnosisDescription.Location = New System.Drawing.Point(160, 168)
        Me.txtDiagnosisDescription.Multiline = True
        Me.txtDiagnosisDescription.Name = "txtDiagnosisDescription"
        Me.txtDiagnosisDescription.Size = New System.Drawing.Size(330, 92)
        Me.txtDiagnosisDescription.TabIndex = 9
        '
        'lblDiagnosisDate
        '
        Me.lblDiagnosisDate.Location = New System.Drawing.Point(20, 276)
        Me.lblDiagnosisDate.Name = "lblDiagnosisDate"
        Me.lblDiagnosisDate.Size = New System.Drawing.Size(130, 24)
        Me.lblDiagnosisDate.TabIndex = 10
        Me.lblDiagnosisDate.Text = "Diagnosis Date *:"
        '
        'dtpDiagnosisDate
        '
        Me.dtpDiagnosisDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDiagnosisDate.Location = New System.Drawing.Point(160, 272)
        Me.dtpDiagnosisDate.Name = "dtpDiagnosisDate"
        Me.dtpDiagnosisDate.Size = New System.Drawing.Size(330, 20)
        Me.dtpDiagnosisDate.TabIndex = 11
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkBlue
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(300, 316)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 34)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(400, 316)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 34)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmDiagnosisEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 370)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dtpDiagnosisDate)
        Me.Controls.Add(Me.lblDiagnosisDate)
        Me.Controls.Add(Me.txtDiagnosisDescription)
        Me.Controls.Add(Me.lblDiagnosisDescription)
        Me.Controls.Add(Me.txtDiagnosisName)
        Me.Controls.Add(Me.lblDiagnosisName)
        Me.Controls.Add(Me.cboPhysician)
        Me.Controls.Add(Me.lblPhysician)
        Me.Controls.Add(Me.cboPatient)
        Me.Controls.Add(Me.lblPatient)
        Me.Controls.Add(Me.txtDiagnosisID)
        Me.Controls.Add(Me.lblDiagnosisID)
        Me.Name = "frmDiagnosisEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Diagnosis"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDiagnosisID As Label
    Friend WithEvents txtDiagnosisID As TextBox
    Friend WithEvents lblPatient As Label
    Friend WithEvents cboPatient As ComboBox
    Friend WithEvents lblPhysician As Label
    Friend WithEvents cboPhysician As ComboBox
    Friend WithEvents lblDiagnosisName As Label
    Friend WithEvents txtDiagnosisName As TextBox
    Friend WithEvents lblDiagnosisDescription As Label
    Friend WithEvents txtDiagnosisDescription As TextBox
    Friend WithEvents lblDiagnosisDate As Label
    Friend WithEvents dtpDiagnosisDate As DateTimePicker
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
