<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDateIssue = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCounterNo = New System.Windows.Forms.TextBox()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbPaymentType = New System.Windows.Forms.ComboBox()
        Me.gpPaid = New System.Windows.Forms.GroupBox()
        Me.rPaidNo = New System.Windows.Forms.RadioButton()
        Me.rPaidYes = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpPaid = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBankDetails = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpCheckDate = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbLedgerType = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbFloatingYes = New System.Windows.Forms.RadioButton()
        Me.rbFloatingNo = New System.Windows.Forms.RadioButton()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gpCheck = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbTerms = New System.Windows.Forms.ComboBox()
        Me.btnSaveAndPrint = New System.Windows.Forms.Button()
        Me.btnAddCustomer = New System.Windows.Forms.Button()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbDisable = New System.Windows.Forms.CheckBox()
        Me.gpPaid.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gpCheck.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer"
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(103, 21)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(200, 21)
        Me.cbCustomer.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date Issue"
        '
        'dtpDateIssue
        '
        Me.dtpDateIssue.Location = New System.Drawing.Point(103, 55)
        Me.dtpDateIssue.Name = "dtpDateIssue"
        Me.dtpDateIssue.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateIssue.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Counter No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Invoice Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Amount"
        '
        'txtCounterNo
        '
        Me.txtCounterNo.Location = New System.Drawing.Point(103, 93)
        Me.txtCounterNo.MaxLength = 5
        Me.txtCounterNo.Name = "txtCounterNo"
        Me.txtCounterNo.Size = New System.Drawing.Size(200, 20)
        Me.txtCounterNo.TabIndex = 7
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(103, 127)
        Me.txtInvoiceNo.MaxLength = 5
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(200, 20)
        Me.txtInvoiceNo.TabIndex = 8
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(103, 161)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtAmount.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Payment Type"
        '
        'cbPaymentType
        '
        Me.cbPaymentType.FormattingEnabled = True
        Me.cbPaymentType.Location = New System.Drawing.Point(103, 203)
        Me.cbPaymentType.Name = "cbPaymentType"
        Me.cbPaymentType.Size = New System.Drawing.Size(200, 21)
        Me.cbPaymentType.TabIndex = 11
        '
        'gpPaid
        '
        Me.gpPaid.Controls.Add(Me.rPaidNo)
        Me.gpPaid.Controls.Add(Me.rPaidYes)
        Me.gpPaid.Location = New System.Drawing.Point(15, 240)
        Me.gpPaid.Name = "gpPaid"
        Me.gpPaid.Size = New System.Drawing.Size(154, 52)
        Me.gpPaid.TabIndex = 13
        Me.gpPaid.TabStop = False
        Me.gpPaid.Text = "Is paid ?"
        '
        'rPaidNo
        '
        Me.rPaidNo.AutoSize = True
        Me.rPaidNo.Location = New System.Drawing.Point(88, 19)
        Me.rPaidNo.Name = "rPaidNo"
        Me.rPaidNo.Size = New System.Drawing.Size(39, 17)
        Me.rPaidNo.TabIndex = 1
        Me.rPaidNo.TabStop = True
        Me.rPaidNo.Text = "No"
        Me.rPaidNo.UseVisualStyleBackColor = True
        '
        'rPaidYes
        '
        Me.rPaidYes.AutoSize = True
        Me.rPaidYes.Location = New System.Drawing.Point(21, 19)
        Me.rPaidYes.Name = "rPaidYes"
        Me.rPaidYes.Size = New System.Drawing.Size(43, 17)
        Me.rPaidYes.TabIndex = 0
        Me.rPaidYes.TabStop = True
        Me.rPaidYes.Text = "Yes"
        Me.rPaidYes.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 304)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Date paid"
        '
        'dtpPaid
        '
        Me.dtpPaid.Location = New System.Drawing.Point(103, 304)
        Me.dtpPaid.Name = "dtpPaid"
        Me.dtpPaid.Size = New System.Drawing.Size(200, 20)
        Me.dtpPaid.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Bank details"
        '
        'txtBankDetails
        '
        Me.txtBankDetails.Location = New System.Drawing.Point(10, 37)
        Me.txtBankDetails.Multiline = True
        Me.txtBankDetails.Name = "txtBankDetails"
        Me.txtBankDetails.Size = New System.Drawing.Size(268, 114)
        Me.txtBankDetails.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Check date"
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.Location = New System.Drawing.Point(78, 169)
        Me.dtpCheckDate.Name = "dtpCheckDate"
        Me.dtpCheckDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpCheckDate.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(418, 313)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Ledger Type"
        '
        'cbLedgerType
        '
        Me.cbLedgerType.Enabled = False
        Me.cbLedgerType.FormattingEnabled = True
        Me.cbLedgerType.Location = New System.Drawing.Point(510, 307)
        Me.cbLedgerType.Name = "cbLedgerType"
        Me.cbLedgerType.Size = New System.Drawing.Size(200, 21)
        Me.cbLedgerType.TabIndex = 21
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbFloatingYes)
        Me.GroupBox2.Controls.Add(Me.rbFloatingNo)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(154, 52)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Is floating ?"
        '
        'rbFloatingYes
        '
        Me.rbFloatingYes.AutoSize = True
        Me.rbFloatingYes.Location = New System.Drawing.Point(20, 22)
        Me.rbFloatingYes.Name = "rbFloatingYes"
        Me.rbFloatingYes.Size = New System.Drawing.Size(43, 17)
        Me.rbFloatingYes.TabIndex = 1
        Me.rbFloatingYes.TabStop = True
        Me.rbFloatingYes.Text = "Yes"
        Me.rbFloatingYes.UseVisualStyleBackColor = True
        '
        'rbFloatingNo
        '
        Me.rbFloatingNo.AutoSize = True
        Me.rbFloatingNo.Location = New System.Drawing.Point(97, 22)
        Me.rbFloatingNo.Name = "rbFloatingNo"
        Me.rbFloatingNo.Size = New System.Drawing.Size(39, 17)
        Me.rbFloatingNo.TabIndex = 0
        Me.rbFloatingNo.TabStop = True
        Me.rbFloatingNo.Text = "No"
        Me.rbFloatingNo.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(906, 249)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(97, 37)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gpCheck
        '
        Me.gpCheck.Controls.Add(Me.Label9)
        Me.gpCheck.Controls.Add(Me.dtpCheckDate)
        Me.gpCheck.Controls.Add(Me.GroupBox2)
        Me.gpCheck.Controls.Add(Me.txtBankDetails)
        Me.gpCheck.Controls.Add(Me.Label8)
        Me.gpCheck.Enabled = False
        Me.gpCheck.Location = New System.Drawing.Point(421, 12)
        Me.gpCheck.Name = "gpCheck"
        Me.gpCheck.Size = New System.Drawing.Size(289, 259)
        Me.gpCheck.TabIndex = 23
        Me.gpCheck.TabStop = False
        Me.gpCheck.Text = "Check"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(418, 279)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Terms"
        '
        'cbTerms
        '
        Me.cbTerms.FormattingEnabled = True
        Me.cbTerms.Location = New System.Drawing.Point(510, 276)
        Me.cbTerms.Name = "cbTerms"
        Me.cbTerms.Size = New System.Drawing.Size(200, 21)
        Me.cbTerms.TabIndex = 20
        '
        'btnSaveAndPrint
        '
        Me.btnSaveAndPrint.Location = New System.Drawing.Point(906, 302)
        Me.btnSaveAndPrint.Name = "btnSaveAndPrint"
        Me.btnSaveAndPrint.Size = New System.Drawing.Size(97, 37)
        Me.btnSaveAndPrint.TabIndex = 24
        Me.btnSaveAndPrint.Text = "Save and Print"
        Me.btnSaveAndPrint.UseVisualStyleBackColor = True
        '
        'btnAddCustomer
        '
        Me.btnAddCustomer.Location = New System.Drawing.Point(309, 19)
        Me.btnAddCustomer.Name = "btnAddCustomer"
        Me.btnAddCustomer.Size = New System.Drawing.Size(88, 23)
        Me.btnAddCustomer.TabIndex = 25
        Me.btnAddCustomer.Text = "Add Customer"
        Me.btnAddCustomer.UseVisualStyleBackColor = True
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(735, 43)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(268, 126)
        Me.txtRemarks.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(732, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Remarks"
        '
        'cbDisable
        '
        Me.cbDisable.AutoSize = True
        Me.cbDisable.Location = New System.Drawing.Point(309, 96)
        Me.cbDisable.Name = "cbDisable"
        Me.cbDisable.Size = New System.Drawing.Size(61, 17)
        Me.cbDisable.TabIndex = 26
        Me.cbDisable.Text = "Disable"
        Me.cbDisable.UseVisualStyleBackColor = True
        '
        'LedgerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 387)
        Me.Controls.Add(Me.cbDisable)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cbTerms)
        Me.Controls.Add(Me.btnAddCustomer)
        Me.Controls.Add(Me.btnSaveAndPrint)
        Me.Controls.Add(Me.gpCheck)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbLedgerType)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dtpPaid)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.gpPaid)
        Me.Controls.Add(Me.cbPaymentType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtInvoiceNo)
        Me.Controls.Add(Me.txtCounterNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpDateIssue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbCustomer)
        Me.Controls.Add(Me.Label1)
        Me.Name = "LedgerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger Form"
        Me.gpPaid.ResumeLayout(False)
        Me.gpPaid.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gpCheck.ResumeLayout(False)
        Me.gpCheck.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDateIssue As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCounterNo As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents gpPaid As System.Windows.Forms.GroupBox
    Friend WithEvents rPaidNo As System.Windows.Forms.RadioButton
    Friend WithEvents rPaidYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpPaid As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBankDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpCheckDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbLedgerType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbFloatingYes As System.Windows.Forms.RadioButton
    Friend WithEvents rbFloatingNo As System.Windows.Forms.RadioButton
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents gpCheck As System.Windows.Forms.GroupBox
    Friend WithEvents btnSaveAndPrint As System.Windows.Forms.Button
    Friend WithEvents btnAddCustomer As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbTerms As System.Windows.Forms.ComboBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbDisable As System.Windows.Forms.CheckBox

End Class
