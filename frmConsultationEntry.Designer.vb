<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultationEntry
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
        Me.lblConsultationID = New System.Windows.Forms.Label()
        Me.txtConsultationID = New System.Windows.Forms.TextBox()
        Me.lblPatient = New System.Windows.Forms.Label()
        Me.cboPatient = New System.Windows.Forms.ComboBox()
        Me.lblPhysician = New System.Windows.Forms.Label()
        Me.cboPhysician = New System.Windows.Forms.ComboBox()
        Me.lblComplaint = New System.Windows.Forms.Label()
        Me.txtComplaint = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblConsultationDate = New System.Windows.Forms.Label()
        Me.dtpConsultationDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblConsultationID
        '
        Me.lblConsultationID.Location = New System.Drawing.Point(20, 24)
        Me.lblConsultationID.Name = "lblConsultationID"
        Me.lblConsultationID.Size = New System.Drawing.Size(130, 24)
        Me.lblConsultationID.TabIndex = 0
        Me.lblConsultationID.Text = "Consultation ID *:"
        '
        'txtConsultationID
        '
        Me.txtConsultationID.Location = New System.Drawing.Point(160, 20)
        Me.txtConsultationID.Name = "txtConsultationID"
        Me.txtConsultationID.ReadOnly = True
        Me.txtConsultationID.Size = New System.Drawing.Size(330, 20)
        Me.txtConsultationID.TabIndex = 1
        Me.txtConsultationID.TabStop = False
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
        'lblComplaint
        '
        Me.lblComplaint.Location = New System.Drawing.Point(20, 138)
        Me.lblComplaint.Name = "lblComplaint"
        Me.lblComplaint.Size = New System.Drawing.Size(130, 24)
        Me.lblComplaint.TabIndex = 6
        Me.lblComplaint.Text = "Complaint *:"
        '
        'txtComplaint
        '
        Me.txtComplaint.Location = New System.Drawing.Point(160, 134)
        Me.txtComplaint.Multiline = True
        Me.txtComplaint.Name = "txtComplaint"
        Me.txtComplaint.Size = New System.Drawing.Size(330, 78)
        Me.txtComplaint.TabIndex = 7
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(20, 224)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(130, 24)
        Me.lblNotes.TabIndex = 8
        Me.lblNotes.Text = "Notes *:"
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(160, 220)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(330, 78)
        Me.txtNotes.TabIndex = 9
        '
        'lblConsultationDate
        '
        Me.lblConsultationDate.Location = New System.Drawing.Point(20, 312)
        Me.lblConsultationDate.Name = "lblConsultationDate"
        Me.lblConsultationDate.Size = New System.Drawing.Size(130, 24)
        Me.lblConsultationDate.TabIndex = 10
        Me.lblConsultationDate.Text = "Consultation Date *:"
        '
        'dtpConsultationDate
        '
        Me.dtpConsultationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpConsultationDate.Location = New System.Drawing.Point(160, 308)
        Me.dtpConsultationDate.Name = "dtpConsultationDate"
        Me.dtpConsultationDate.Size = New System.Drawing.Size(330, 20)
        Me.dtpConsultationDate.TabIndex = 11
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkBlue
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(300, 348)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 34)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(400, 348)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 34)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmConsultationEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 400)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dtpConsultationDate)
        Me.Controls.Add(Me.lblConsultationDate)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtComplaint)
        Me.Controls.Add(Me.lblComplaint)
        Me.Controls.Add(Me.cboPhysician)
        Me.Controls.Add(Me.lblPhysician)
        Me.Controls.Add(Me.cboPatient)
        Me.Controls.Add(Me.lblPatient)
        Me.Controls.Add(Me.txtConsultationID)
        Me.Controls.Add(Me.lblConsultationID)
        Me.Name = "frmConsultationEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Consultation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblConsultationID As Label
    Friend WithEvents txtConsultationID As TextBox
    Friend WithEvents lblPatient As Label
    Friend WithEvents cboPatient As ComboBox
    Friend WithEvents lblPhysician As Label
    Friend WithEvents cboPhysician As ComboBox
    Friend WithEvents lblComplaint As Label
    Friend WithEvents txtComplaint As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblConsultationDate As Label
    Friend WithEvents dtpConsultationDate As DateTimePicker
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
