<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLabOrderEntry
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLabOrderEntry))
        Me.lblOrderID = New System.Windows.Forms.Label()
        Me.txtOrderID = New System.Windows.Forms.TextBox()
        Me.lblPhysician = New System.Windows.Forms.Label()
        Me.cboPhysician = New System.Windows.Forms.ComboBox()
        Me.lblPatient = New System.Windows.Forms.Label()
        Me.cboPatient = New System.Windows.Forms.ComboBox()
        Me.lblOrderDate = New System.Windows.Forms.Label()
        Me.dtpOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.lblMedicalTest = New System.Windows.Forms.Label()
        Me.cboMedicalTest = New System.Windows.Forms.ComboBox()
        Me.btnAddMedicalTest = New System.Windows.Forms.Button()
        Me.btnRemoveMedicalTest = New System.Windows.Forms.Button()
        Me.lblSelectedTests = New System.Windows.Forms.Label()
        Me.lstSelectedTests = New System.Windows.Forms.ListBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblOrderID
        '
        Me.lblOrderID.Location = New System.Drawing.Point(20, 24)
        Me.lblOrderID.Name = "lblOrderID"
        Me.lblOrderID.Size = New System.Drawing.Size(130, 24)
        Me.lblOrderID.TabIndex = 0
        Me.lblOrderID.Text = "Order ID *:"
        '
        'txtOrderID
        '
        Me.txtOrderID.Location = New System.Drawing.Point(160, 20)
        Me.txtOrderID.Name = "txtOrderID"
        Me.txtOrderID.ReadOnly = True
        Me.txtOrderID.Size = New System.Drawing.Size(330, 20)
        Me.txtOrderID.TabIndex = 1
        Me.txtOrderID.TabStop = False
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
        'lblOrderDate
        '
        Me.lblOrderDate.Location = New System.Drawing.Point(20, 138)
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Size = New System.Drawing.Size(130, 24)
        Me.lblOrderDate.TabIndex = 6
        Me.lblOrderDate.Text = "Order Date *:"
        '
        'dtpOrderDate
        '
        Me.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpOrderDate.Location = New System.Drawing.Point(160, 134)
        Me.dtpOrderDate.Name = "dtpOrderDate"
        Me.dtpOrderDate.Size = New System.Drawing.Size(330, 20)
        Me.dtpOrderDate.TabIndex = 7
        '
        'lblMedicalTest
        '
        Me.lblMedicalTest.Location = New System.Drawing.Point(20, 172)
        Me.lblMedicalTest.Name = "lblMedicalTest"
        Me.lblMedicalTest.Size = New System.Drawing.Size(130, 24)
        Me.lblMedicalTest.TabIndex = 8
        Me.lblMedicalTest.Text = "Medical Test *:"
        '
        'cboMedicalTest
        '
        Me.cboMedicalTest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMedicalTest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMedicalTest.FormattingEnabled = True
        Me.cboMedicalTest.Location = New System.Drawing.Point(160, 168)
        Me.cboMedicalTest.Name = "cboMedicalTest"
        Me.cboMedicalTest.Size = New System.Drawing.Size(230, 21)
        Me.cboMedicalTest.TabIndex = 9
        '
        'btnAddMedicalTest
        '
        Me.btnAddMedicalTest.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnAddMedicalTest.FlatAppearance.BorderSize = 0
        Me.btnAddMedicalTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddMedicalTest.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMedicalTest.ForeColor = System.Drawing.Color.White
        Me.btnAddMedicalTest.Location = New System.Drawing.Point(396, 166)
        Me.btnAddMedicalTest.Name = "btnAddMedicalTest"
        Me.btnAddMedicalTest.Size = New System.Drawing.Size(94, 24)
        Me.btnAddMedicalTest.TabIndex = 10
        Me.btnAddMedicalTest.Text = "Add Test"
        Me.btnAddMedicalTest.UseVisualStyleBackColor = False
        '
        'btnRemoveMedicalTest
        '
        Me.btnRemoveMedicalTest.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnRemoveMedicalTest.FlatAppearance.BorderSize = 0
        Me.btnRemoveMedicalTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveMedicalTest.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveMedicalTest.ForeColor = System.Drawing.Color.White
        Me.btnRemoveMedicalTest.Location = New System.Drawing.Point(396, 199)
        Me.btnRemoveMedicalTest.Name = "btnRemoveMedicalTest"
        Me.btnRemoveMedicalTest.Size = New System.Drawing.Size(94, 24)
        Me.btnRemoveMedicalTest.TabIndex = 11
        Me.btnRemoveMedicalTest.Text = "Remove"
        Me.btnRemoveMedicalTest.UseVisualStyleBackColor = False
        '
        'lblSelectedTests
        '
        Me.lblSelectedTests.Location = New System.Drawing.Point(20, 201)
        Me.lblSelectedTests.Name = "lblSelectedTests"
        Me.lblSelectedTests.Size = New System.Drawing.Size(130, 24)
        Me.lblSelectedTests.TabIndex = 12
        Me.lblSelectedTests.Text = "Selected Tests *:"
        '
        'lstSelectedTests
        '
        Me.lstSelectedTests.FormattingEnabled = True
        Me.lstSelectedTests.Location = New System.Drawing.Point(160, 199)
        Me.lstSelectedTests.Name = "lstSelectedTests"
        Me.lstSelectedTests.Size = New System.Drawing.Size(230, 95)
        Me.lstSelectedTests.TabIndex = 13
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(300, 314)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 34)
        Me.btnSave.TabIndex = 14
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
        Me.btnCancel.Location = New System.Drawing.Point(400, 314)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 34)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmLabOrderEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(520, 370)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lstSelectedTests)
        Me.Controls.Add(Me.lblSelectedTests)
        Me.Controls.Add(Me.btnRemoveMedicalTest)
        Me.Controls.Add(Me.btnAddMedicalTest)
        Me.Controls.Add(Me.cboMedicalTest)
        Me.Controls.Add(Me.lblMedicalTest)
        Me.Controls.Add(Me.dtpOrderDate)
        Me.Controls.Add(Me.lblOrderDate)
        Me.Controls.Add(Me.cboPatient)
        Me.Controls.Add(Me.lblPatient)
        Me.Controls.Add(Me.cboPhysician)
        Me.Controls.Add(Me.lblPhysician)
        Me.Controls.Add(Me.txtOrderID)
        Me.Controls.Add(Me.lblOrderID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLabOrderEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Lab Order"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblOrderID As Label
    Friend WithEvents txtOrderID As TextBox
    Friend WithEvents lblPhysician As Label
    Friend WithEvents cboPhysician As ComboBox
    Friend WithEvents lblPatient As Label
    Friend WithEvents cboPatient As ComboBox
    Friend WithEvents lblOrderDate As Label
    Friend WithEvents dtpOrderDate As DateTimePicker
    Friend WithEvents lblMedicalTest As Label
    Friend WithEvents cboMedicalTest As ComboBox
    Friend WithEvents btnAddMedicalTest As Button
    Friend WithEvents btnRemoveMedicalTest As Button
    Friend WithEvents lblSelectedTests As Label
    Friend WithEvents lstSelectedTests As ListBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class





