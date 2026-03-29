<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExaminationEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExaminationEntry))
        Me.lblExaminationID = New System.Windows.Forms.Label()
        Me.txtExaminationID = New System.Windows.Forms.TextBox()
        Me.lblPatient = New System.Windows.Forms.Label()
        Me.cboPatient = New System.Windows.Forms.ComboBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.lblDatePerformed = New System.Windows.Forms.Label()
        Me.dtpDatePerformed = New System.Windows.Forms.DateTimePicker()
        Me.lblLabTest = New System.Windows.Forms.Label()
        Me.cboLabTest = New System.Windows.Forms.ComboBox()
        Me.btnAddLabTest = New System.Windows.Forms.Button()
        Me.btnRemoveLabTest = New System.Windows.Forms.Button()
        Me.lblSelectedLabTests = New System.Windows.Forms.Label()
        Me.lstSelectedLabTests = New System.Windows.Forms.ListBox()
        Me.lblMedTech = New System.Windows.Forms.Label()
        Me.cboMedTech = New System.Windows.Forms.ComboBox()
        Me.btnAddMedTech = New System.Windows.Forms.Button()
        Me.btnRemoveMedTech = New System.Windows.Forms.Button()
        Me.lblSelectedMedTechs = New System.Windows.Forms.Label()
        Me.lstSelectedMedTechs = New System.Windows.Forms.ListBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblExaminationID
        '
        Me.lblExaminationID.Location = New System.Drawing.Point(20, 24)
        Me.lblExaminationID.Name = "lblExaminationID"
        Me.lblExaminationID.Size = New System.Drawing.Size(130, 24)
        Me.lblExaminationID.TabIndex = 0
        Me.lblExaminationID.Text = "Examination ID *:"
        '
        'txtExaminationID
        '
        Me.txtExaminationID.Location = New System.Drawing.Point(160, 20)
        Me.txtExaminationID.Name = "txtExaminationID"
        Me.txtExaminationID.ReadOnly = True
        Me.txtExaminationID.Size = New System.Drawing.Size(330, 20)
        Me.txtExaminationID.TabIndex = 1
        Me.txtExaminationID.TabStop = False
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
        Me.cboPatient.FormattingEnabled = True
        Me.cboPatient.Location = New System.Drawing.Point(160, 58)
        Me.cboPatient.Name = "cboPatient"
        Me.cboPatient.Size = New System.Drawing.Size(330, 21)
        Me.cboPatient.TabIndex = 3
        '
        'lblResult
        '
        Me.lblResult.Location = New System.Drawing.Point(20, 100)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(130, 24)
        Me.lblResult.TabIndex = 4
        Me.lblResult.Text = "Result *:"
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(160, 96)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(330, 92)
        Me.txtResult.TabIndex = 5
        '
        'lblDatePerformed
        '
        Me.lblDatePerformed.Location = New System.Drawing.Point(20, 204)
        Me.lblDatePerformed.Name = "lblDatePerformed"
        Me.lblDatePerformed.Size = New System.Drawing.Size(130, 24)
        Me.lblDatePerformed.TabIndex = 6
        Me.lblDatePerformed.Text = "Date Performed *:"
        '
        'dtpDatePerformed
        '
        Me.dtpDatePerformed.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDatePerformed.Location = New System.Drawing.Point(160, 200)
        Me.dtpDatePerformed.Name = "dtpDatePerformed"
        Me.dtpDatePerformed.Size = New System.Drawing.Size(330, 20)
        Me.dtpDatePerformed.TabIndex = 7
        '
        'lblLabTest
        '
        Me.lblLabTest.Location = New System.Drawing.Point(20, 240)
        Me.lblLabTest.Name = "lblLabTest"
        Me.lblLabTest.Size = New System.Drawing.Size(130, 24)
        Me.lblLabTest.TabIndex = 8
        Me.lblLabTest.Text = "Laboratory Test *:"
        '
        'cboLabTest
        '
        Me.cboLabTest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLabTest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLabTest.FormattingEnabled = True
        Me.cboLabTest.Location = New System.Drawing.Point(160, 236)
        Me.cboLabTest.Name = "cboLabTest"
        Me.cboLabTest.Size = New System.Drawing.Size(230, 21)
        Me.cboLabTest.TabIndex = 9
        '
        'btnAddLabTest
        '
        Me.btnAddLabTest.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnAddLabTest.FlatAppearance.BorderSize = 0
        Me.btnAddLabTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddLabTest.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddLabTest.ForeColor = System.Drawing.Color.White
        Me.btnAddLabTest.Location = New System.Drawing.Point(396, 234)
        Me.btnAddLabTest.Name = "btnAddLabTest"
        Me.btnAddLabTest.Size = New System.Drawing.Size(94, 24)
        Me.btnAddLabTest.TabIndex = 10
        Me.btnAddLabTest.Text = "Add Test"
        Me.btnAddLabTest.UseVisualStyleBackColor = False
        '
        'btnRemoveLabTest
        '
        Me.btnRemoveLabTest.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnRemoveLabTest.FlatAppearance.BorderSize = 0
        Me.btnRemoveLabTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveLabTest.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveLabTest.ForeColor = System.Drawing.Color.White
        Me.btnRemoveLabTest.Location = New System.Drawing.Point(396, 267)
        Me.btnRemoveLabTest.Name = "btnRemoveLabTest"
        Me.btnRemoveLabTest.Size = New System.Drawing.Size(94, 24)
        Me.btnRemoveLabTest.TabIndex = 11
        Me.btnRemoveLabTest.Text = "Remove"
        Me.btnRemoveLabTest.UseVisualStyleBackColor = False
        '
        'lblSelectedLabTests
        '
        Me.lblSelectedLabTests.Location = New System.Drawing.Point(20, 269)
        Me.lblSelectedLabTests.Name = "lblSelectedLabTests"
        Me.lblSelectedLabTests.Size = New System.Drawing.Size(130, 24)
        Me.lblSelectedLabTests.TabIndex = 12
        Me.lblSelectedLabTests.Text = "Selected Tests *:"
        '
        'lstSelectedLabTests
        '
        Me.lstSelectedLabTests.FormattingEnabled = True
        Me.lstSelectedLabTests.Location = New System.Drawing.Point(160, 267)
        Me.lstSelectedLabTests.Name = "lstSelectedLabTests"
        Me.lstSelectedLabTests.Size = New System.Drawing.Size(230, 95)
        Me.lstSelectedLabTests.TabIndex = 13
        '
        'lblMedTech
        '
        Me.lblMedTech.Location = New System.Drawing.Point(20, 381)
        Me.lblMedTech.Name = "lblMedTech"
        Me.lblMedTech.Size = New System.Drawing.Size(130, 24)
        Me.lblMedTech.TabIndex = 14
        Me.lblMedTech.Text = "MedTech *:"
        '
        'cboMedTech
        '
        Me.cboMedTech.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMedTech.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMedTech.FormattingEnabled = True
        Me.cboMedTech.Location = New System.Drawing.Point(160, 377)
        Me.cboMedTech.Name = "cboMedTech"
        Me.cboMedTech.Size = New System.Drawing.Size(230, 21)
        Me.cboMedTech.TabIndex = 15
        '
        'btnAddMedTech
        '
        Me.btnAddMedTech.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnAddMedTech.FlatAppearance.BorderSize = 0
        Me.btnAddMedTech.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddMedTech.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMedTech.ForeColor = System.Drawing.Color.White
        Me.btnAddMedTech.Location = New System.Drawing.Point(396, 375)
        Me.btnAddMedTech.Name = "btnAddMedTech"
        Me.btnAddMedTech.Size = New System.Drawing.Size(94, 24)
        Me.btnAddMedTech.TabIndex = 16
        Me.btnAddMedTech.Text = "Add MedTech"
        Me.btnAddMedTech.UseVisualStyleBackColor = False
        '
        'btnRemoveMedTech
        '
        Me.btnRemoveMedTech.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnRemoveMedTech.FlatAppearance.BorderSize = 0
        Me.btnRemoveMedTech.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveMedTech.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveMedTech.ForeColor = System.Drawing.Color.White
        Me.btnRemoveMedTech.Location = New System.Drawing.Point(396, 408)
        Me.btnRemoveMedTech.Name = "btnRemoveMedTech"
        Me.btnRemoveMedTech.Size = New System.Drawing.Size(94, 24)
        Me.btnRemoveMedTech.TabIndex = 17
        Me.btnRemoveMedTech.Text = "Remove"
        Me.btnRemoveMedTech.UseVisualStyleBackColor = False
        '
        'lblSelectedMedTechs
        '
        Me.lblSelectedMedTechs.Location = New System.Drawing.Point(20, 410)
        Me.lblSelectedMedTechs.Name = "lblSelectedMedTechs"
        Me.lblSelectedMedTechs.Size = New System.Drawing.Size(130, 24)
        Me.lblSelectedMedTechs.TabIndex = 18
        Me.lblSelectedMedTechs.Text = "Selected MedTechs *:"
        '
        'lstSelectedMedTechs
        '
        Me.lstSelectedMedTechs.FormattingEnabled = True
        Me.lstSelectedMedTechs.Location = New System.Drawing.Point(160, 408)
        Me.lstSelectedMedTechs.Name = "lstSelectedMedTechs"
        Me.lstSelectedMedTechs.Size = New System.Drawing.Size(230, 95)
        Me.lstSelectedMedTechs.TabIndex = 19
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(300, 523)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 34)
        Me.btnSave.TabIndex = 20
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
        Me.btnCancel.Location = New System.Drawing.Point(400, 523)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 34)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmExaminationEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(520, 580)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lstSelectedMedTechs)
        Me.Controls.Add(Me.lblSelectedMedTechs)
        Me.Controls.Add(Me.btnRemoveMedTech)
        Me.Controls.Add(Me.btnAddMedTech)
        Me.Controls.Add(Me.cboMedTech)
        Me.Controls.Add(Me.lblMedTech)
        Me.Controls.Add(Me.lstSelectedLabTests)
        Me.Controls.Add(Me.lblSelectedLabTests)
        Me.Controls.Add(Me.btnRemoveLabTest)
        Me.Controls.Add(Me.btnAddLabTest)
        Me.Controls.Add(Me.cboLabTest)
        Me.Controls.Add(Me.lblLabTest)
        Me.Controls.Add(Me.dtpDatePerformed)
        Me.Controls.Add(Me.lblDatePerformed)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.cboPatient)
        Me.Controls.Add(Me.lblPatient)
        Me.Controls.Add(Me.txtExaminationID)
        Me.Controls.Add(Me.lblExaminationID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmExaminationEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Examination"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblExaminationID As Label
    Friend WithEvents txtExaminationID As TextBox
    Friend WithEvents lblPatient As Label
    Friend WithEvents cboPatient As ComboBox
    Friend WithEvents lblResult As Label
    Friend WithEvents txtResult As TextBox
    Friend WithEvents lblDatePerformed As Label
    Friend WithEvents dtpDatePerformed As DateTimePicker
    Friend WithEvents lblLabTest As Label
    Friend WithEvents cboLabTest As ComboBox
    Friend WithEvents btnAddLabTest As Button
    Friend WithEvents btnRemoveLabTest As Button
    Friend WithEvents lblSelectedLabTests As Label
    Friend WithEvents lstSelectedLabTests As ListBox
    Friend WithEvents lblMedTech As Label
    Friend WithEvents cboMedTech As ComboBox
    Friend WithEvents btnAddMedTech As Button
    Friend WithEvents btnRemoveMedTech As Button
    Friend WithEvents lblSelectedMedTechs As Label
    Friend WithEvents lstSelectedMedTechs As ListBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class





