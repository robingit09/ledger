<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerFilterReports
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
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.cbpayment_mode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbLedgerType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPrint2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbRemaining = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbPaid = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbBusinessType = New System.Windows.Forms.ComboBox()
        Me.cbSalesType = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(107, 36)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(262, 21)
        Me.cbCustomer.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 313)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "By Month:"
        '
        'cbMonth
        '
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(107, 310)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(97, 21)
        Me.cbMonth.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(210, 313)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "By Year:"
        '
        'cbYear
        '
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(263, 310)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(106, 21)
        Me.cbYear.TabIndex = 8
        '
        'cbpayment_mode
        '
        Me.cbpayment_mode.FormattingEnabled = True
        Me.cbpayment_mode.Location = New System.Drawing.Point(107, 77)
        Me.cbpayment_mode.Name = "cbpayment_mode"
        Me.cbpayment_mode.Size = New System.Drawing.Size(262, 21)
        Me.cbpayment_mode.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Payment Type:"
        '
        'cbLedgerType
        '
        Me.cbLedgerType.FormattingEnabled = True
        Me.cbLedgerType.Location = New System.Drawing.Point(107, 113)
        Me.cbLedgerType.Name = "cbLedgerType"
        Me.cbLedgerType.Size = New System.Drawing.Size(262, 21)
        Me.cbLedgerType.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Ledger Type:"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(263, 399)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(106, 23)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Print as Crystal"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPrint2
        '
        Me.btnPrint2.Location = New System.Drawing.Point(263, 354)
        Me.btnPrint2.Name = "btnPrint2"
        Me.btnPrint2.Size = New System.Drawing.Size(106, 23)
        Me.btnPrint2.TabIndex = 14
        Me.btnPrint2.Text = "Print as Html"
        Me.btnPrint2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Remaining:"
        '
        'cbRemaining
        '
        Me.cbRemaining.FormattingEnabled = True
        Me.cbRemaining.Location = New System.Drawing.Point(107, 267)
        Me.cbRemaining.Name = "cbRemaining"
        Me.cbRemaining.Size = New System.Drawing.Size(262, 21)
        Me.cbRemaining.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Paid: "
        '
        'cbPaid
        '
        Me.cbPaid.FormattingEnabled = True
        Me.cbPaid.Location = New System.Drawing.Point(107, 150)
        Me.cbPaid.Name = "cbPaid"
        Me.cbPaid.Size = New System.Drawing.Size(262, 21)
        Me.cbPaid.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 234)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Business Type: "
        '
        'cbBusinessType
        '
        Me.cbBusinessType.FormattingEnabled = True
        Me.cbBusinessType.Location = New System.Drawing.Point(107, 231)
        Me.cbBusinessType.Name = "cbBusinessType"
        Me.cbBusinessType.Size = New System.Drawing.Size(262, 21)
        Me.cbBusinessType.TabIndex = 20
        '
        'cbSalesType
        '
        Me.cbSalesType.FormattingEnabled = True
        Me.cbSalesType.Location = New System.Drawing.Point(107, 192)
        Me.cbSalesType.Name = "cbSalesType"
        Me.cbSalesType.Size = New System.Drawing.Size(262, 21)
        Me.cbSalesType.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 195)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Sales Type:"
        '
        'LedgerFilterReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 452)
        Me.Controls.Add(Me.cbSalesType)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbBusinessType)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbPaid)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbRemaining)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnPrint2)
        Me.Controls.Add(Me.cbLedgerType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbpayment_mode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbYear)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbMonth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbCustomer)
        Me.Name = "LedgerFilterReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger Reports"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cbpayment_mode As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbLedgerType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnPrint2 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents cbRemaining As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbPaid As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbBusinessType As ComboBox
    Friend WithEvents cbSalesType As ComboBox
    Friend WithEvents Label9 As Label
End Class
