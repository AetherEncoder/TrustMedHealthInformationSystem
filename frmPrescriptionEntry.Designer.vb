<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrescriptionEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrescriptionEntry))
        Me.lblPrescriptionID = New System.Windows.Forms.Label()
        Me.txtPrescriptionID = New System.Windows.Forms.TextBox()
        Me.lblPhysician = New System.Windows.Forms.Label()
        Me.cboPhysician = New System.Windows.Forms.ComboBox()
        Me.lblPatient = New System.Windows.Forms.Label()
        Me.cboPatient = New System.Windows.Forms.ComboBox()
        Me.lblInstruction = New System.Windows.Forms.Label()
        Me.txtInstruction = New System.Windows.Forms.TextBox()
        Me.lblPrescriptionDate = New System.Windows.Forms.Label()
        Me.dtpPrescriptionDate = New System.Windows.Forms.DateTimePicker()
        Me.lblMedicine = New System.Windows.Forms.Label()
        Me.cboMedicine = New System.Windows.Forms.ComboBox()
        Me.btnAddMedicine = New System.Windows.Forms.Button()
        Me.btnRemoveMedicine = New System.Windows.Forms.Button()
        Me.lblSelectedMedicines = New System.Windows.Forms.Label()
        Me.lstSelectedMedicines = New System.Windows.Forms.ListBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPrescriptionID
        '
        Me.lblPrescriptionID.Location = New System.Drawing.Point(20, 24)
        Me.lblPrescriptionID.Name = "lblPrescriptionID"
        Me.lblPrescriptionID.Size = New System.Drawing.Size(130, 24)
        Me.lblPrescriptionID.TabIndex = 0
        Me.lblPrescriptionID.Text = "Prescription ID *:"
        '
        'txtPrescriptionID
        '
        Me.txtPrescriptionID.Location = New System.Drawing.Point(160, 20)
        Me.txtPrescriptionID.Name = "txtPrescriptionID"
        Me.txtPrescriptionID.ReadOnly = True
        Me.txtPrescriptionID.Size = New System.Drawing.Size(330, 20)
        Me.txtPrescriptionID.TabIndex = 1
        Me.txtPrescriptionID.TabStop = False
        '
        'lblPhysician
        '
        Me.lblPhysician.Location = New System.Drawing.Point(20, 62)
        Me.lblPhysician.Name = "lblPhysician"
        Me.lblPhysician.Size = New System.Drawing.Size(130, 24)
        Me.lblPhysician.TabIndex = 2
        Me.lblPhysician.Text = "Physician *:"
        '
        'cboPhysician
        '
        Me.cboPhysician.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPhysician.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPhysician.FormattingEnabled = True
        Me.cboPhysician.Location = New System.Drawing.Point(160, 58)
        Me.cboPhysician.Name = "cboPhysician"
        Me.cboPhysician.Size = New System.Drawing.Size(330, 21)
        Me.cboPhysician.TabIndex = 3
        '
        'lblPatient
        '
        Me.lblPatient.Location = New System.Drawing.Point(20, 100)
        Me.lblPatient.Name = "lblPatient"
        Me.lblPatient.Size = New System.Drawing.Size(130, 24)
        Me.lblPatient.TabIndex = 4
        Me.lblPatient.Text = "Patient *:"
        '
        'cboPatient
        '
        Me.cboPatient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPatient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPatient.FormattingEnabled = True
        Me.cboPatient.Location = New System.Drawing.Point(160, 96)
        Me.cboPatient.Name = "cboPatient"
        Me.cboPatient.Size = New System.Drawing.Size(330, 21)
        Me.cboPatient.TabIndex = 5
        '
        'lblInstruction
        '
        Me.lblInstruction.Location = New System.Drawing.Point(20, 138)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.Size = New System.Drawing.Size(130, 24)
        Me.lblInstruction.TabIndex = 6
        Me.lblInstruction.Text = "Instruction *:"
        '
        'txtInstruction
        '
        Me.txtInstruction.Location = New System.Drawing.Point(160, 134)
        Me.txtInstruction.Multiline = True
        Me.txtInstruction.Name = "txtInstruction"
        Me.txtInstruction.Size = New System.Drawing.Size(330, 92)
        Me.txtInstruction.TabIndex = 7
        '
        'lblPrescriptionDate
        '
        Me.lblPrescriptionDate.Location = New System.Drawing.Point(20, 242)
        Me.lblPrescriptionDate.Name = "lblPrescriptionDate"
        Me.lblPrescriptionDate.Size = New System.Drawing.Size(130, 24)
        Me.lblPrescriptionDate.TabIndex = 8
        Me.lblPrescriptionDate.Text = "Prescription Date *:"
        '
        'dtpPrescriptionDate
        '
        Me.dtpPrescriptionDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPrescriptionDate.Location = New System.Drawing.Point(160, 238)
        Me.dtpPrescriptionDate.Name = "dtpPrescriptionDate"
        Me.dtpPrescriptionDate.Size = New System.Drawing.Size(330, 20)
        Me.dtpPrescriptionDate.TabIndex = 9
        '
        'lblMedicine
        '
        Me.lblMedicine.Location = New System.Drawing.Point(20, 278)
        Me.lblMedicine.Name = "lblMedicine"
        Me.lblMedicine.Size = New System.Drawing.Size(130, 24)
        Me.lblMedicine.TabIndex = 10
        Me.lblMedicine.Text = "Medicine *:"
        '
        'cboMedicine
        '
        Me.cboMedicine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMedicine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMedicine.FormattingEnabled = True
        Me.cboMedicine.Location = New System.Drawing.Point(160, 274)
        Me.cboMedicine.Name = "cboMedicine"
        Me.cboMedicine.Size = New System.Drawing.Size(230, 21)
        Me.cboMedicine.TabIndex = 11
        '
        'btnAddMedicine
        '
        Me.btnAddMedicine.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnAddMedicine.FlatAppearance.BorderSize = 0
        Me.btnAddMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddMedicine.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMedicine.ForeColor = System.Drawing.Color.White
        Me.btnAddMedicine.Location = New System.Drawing.Point(396, 272)
        Me.btnAddMedicine.Name = "btnAddMedicine"
        Me.btnAddMedicine.Size = New System.Drawing.Size(94, 24)
        Me.btnAddMedicine.TabIndex = 12
        Me.btnAddMedicine.Text = "Add Medicine"
        Me.btnAddMedicine.UseVisualStyleBackColor = False
        '
        'btnRemoveMedicine
        '
        Me.btnRemoveMedicine.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnRemoveMedicine.FlatAppearance.BorderSize = 0
        Me.btnRemoveMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveMedicine.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveMedicine.ForeColor = System.Drawing.Color.White
        Me.btnRemoveMedicine.Location = New System.Drawing.Point(396, 305)
        Me.btnRemoveMedicine.Name = "btnRemoveMedicine"
        Me.btnRemoveMedicine.Size = New System.Drawing.Size(94, 24)
        Me.btnRemoveMedicine.TabIndex = 13
        Me.btnRemoveMedicine.Text = "Remove"
        Me.btnRemoveMedicine.UseVisualStyleBackColor = False
        '
        'lblSelectedMedicines
        '
        Me.lblSelectedMedicines.Location = New System.Drawing.Point(20, 307)
        Me.lblSelectedMedicines.Name = "lblSelectedMedicines"
        Me.lblSelectedMedicines.Size = New System.Drawing.Size(130, 24)
        Me.lblSelectedMedicines.TabIndex = 14
        Me.lblSelectedMedicines.Text = "Selected Medicines *:"
        '
        'lstSelectedMedicines
        '
        Me.lstSelectedMedicines.FormattingEnabled = True
        Me.lstSelectedMedicines.Location = New System.Drawing.Point(160, 305)
        Me.lstSelectedMedicines.Name = "lstSelectedMedicines"
        Me.lstSelectedMedicines.Size = New System.Drawing.Size(230, 95)
        Me.lstSelectedMedicines.TabIndex = 15
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(300, 418)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 34)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnCancel.Location = New System.Drawing.Point(400, 418)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 34)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmPrescriptionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(520, 470)
        Me.Controls.Add(Me.lstSelectedMedicines)
        Me.Controls.Add(Me.lblSelectedMedicines)
        Me.Controls.Add(Me.btnRemoveMedicine)
        Me.Controls.Add(Me.btnAddMedicine)
        Me.Controls.Add(Me.cboMedicine)
        Me.Controls.Add(Me.lblMedicine)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dtpPrescriptionDate)
        Me.Controls.Add(Me.lblPrescriptionDate)
        Me.Controls.Add(Me.txtInstruction)
        Me.Controls.Add(Me.lblInstruction)
        Me.Controls.Add(Me.cboPatient)
        Me.Controls.Add(Me.lblPatient)
        Me.Controls.Add(Me.cboPhysician)
        Me.Controls.Add(Me.lblPhysician)
        Me.Controls.Add(Me.txtPrescriptionID)
        Me.Controls.Add(Me.lblPrescriptionID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrescriptionEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Prescription"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPrescriptionID As Label
    Friend WithEvents txtPrescriptionID As TextBox
    Friend WithEvents lblPhysician As Label
    Friend WithEvents cboPhysician As ComboBox
    Friend WithEvents lblPatient As Label
    Friend WithEvents cboPatient As ComboBox
    Friend WithEvents lblInstruction As Label
    Friend WithEvents txtInstruction As TextBox
    Friend WithEvents lblPrescriptionDate As Label
    Friend WithEvents dtpPrescriptionDate As DateTimePicker
    Friend WithEvents lblMedicine As Label
    Friend WithEvents cboMedicine As ComboBox
    Friend WithEvents btnAddMedicine As Button
    Friend WithEvents btnRemoveMedicine As Button
    Friend WithEvents lblSelectedMedicines As Label
    Friend WithEvents lstSelectedMedicines As ListBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class





