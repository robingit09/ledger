<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterCheckReports
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
        Me.btnPrintCheckDate = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbCheckYear = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCheckMonth = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbLedgerType2 = New System.Windows.Forms.ComboBox()
        Me.cbCustomer2 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbRemaining2 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbInvoiceYear = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbInvoiceMonth = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbLedgerType = New System.Windows.Forms.ComboBox()
        Me.btnPrintDateInvoice = New System.Windows.Forms.Button()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbRemaining = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbCheckFloating = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrintCheckDate
        '
        Me.btnPrintCheckDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintCheckDate.Location = New System.Drawing.Point(293, 245)
        Me.btnPrintCheckDate.Name = "btnPrintCheckDate"
        Me.btnPrintCheckDate.Size = New System.Drawing.Size(97, 32)
        Me.btnPrintCheckDate.TabIndex = 0
        Me.btnPrintCheckDate.Text = "Print"
        Me.btnPrintCheckDate.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(223, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "By Year:"
        '
        'cbCheckYear
        '
        Me.cbCheckYear.FormattingEnabled = True
        Me.cbCheckYear.Location = New System.Drawing.Point(287, 145)
        Me.cbCheckYear.Name = "cbCheckYear"
        Me.cbCheckYear.Size = New System.Drawing.Size(104, 21)
        Me.cbCheckYear.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "By Month:"
        '
        'cbCheckMonth
        '
        Me.cbCheckMonth.FormattingEnabled = True
        Me.cbCheckMonth.Location = New System.Drawing.Point(112, 145)
        Me.cbCheckMonth.Name = "cbCheckMonth"
        Me.cbCheckMonth.Size = New System.Drawing.Size(105, 21)
        Me.cbCheckMonth.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbCheckFloating)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnPrintCheckDate)
        Me.GroupBox1.Controls.Add(Me.cbLedgerType2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbCustomer2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbRemaining2)
        Me.GroupBox1.Controls.Add(Me.cbCheckYear)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cbCheckMonth)
        Me.GroupBox1.Location = New System.Drawing.Point(500, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 301)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter by Check Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Ledger Type:"
        '
        'cbLedgerType2
        '
        Me.cbLedgerType2.FormattingEnabled = True
        Me.cbLedgerType2.Location = New System.Drawing.Point(111, 104)
        Me.cbLedgerType2.Name = "cbLedgerType2"
        Me.cbLedgerType2.Size = New System.Drawing.Size(106, 21)
        Me.cbLedgerType2.TabIndex = 35
        '
        'cbCustomer2
        '
        Me.cbCustomer2.FormattingEnabled = True
        Me.cbCustomer2.Location = New System.Drawing.Point(112, 26)
        Me.cbCustomer2.Name = "cbCustomer2"
        Me.cbCustomer2.Size = New System.Drawing.Size(279, 21)
        Me.cbCustomer2.TabIndex = 34
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Customer:"
        '
        'cbRemaining2
        '
        Me.cbRemaining2.FormattingEnabled = True
        Me.cbRemaining2.Location = New System.Drawing.Point(112, 64)
        Me.cbRemaining2.Name = "cbRemaining2"
        Me.cbRemaining2.Size = New System.Drawing.Size(279, 21)
        Me.cbRemaining2.TabIndex = 32
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Remaining:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(242, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "By Year:"
        '
        'cbInvoiceYear
        '
        Me.cbInvoiceYear.FormattingEnabled = True
        Me.cbInvoiceYear.Location = New System.Drawing.Point(295, 155)
        Me.cbInvoiceYear.Name = "cbInvoiceYear"
        Me.cbInvoiceYear.Size = New System.Drawing.Size(97, 21)
        Me.cbInvoiceYear.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "By Month:"
        '
        'cbInvoiceMonth
        '
        Me.cbInvoiceMonth.FormattingEnabled = True
        Me.cbInvoiceMonth.Location = New System.Drawing.Point(130, 155)
        Me.cbInvoiceMonth.Name = "cbInvoiceMonth"
        Me.cbInvoiceMonth.Size = New System.Drawing.Size(97, 21)
        Me.cbInvoiceMonth.TabIndex = 20
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbLedgerType)
        Me.GroupBox2.Controls.Add(Me.btnPrintDateInvoice)
        Me.GroupBox2.Controls.Add(Me.cbCustomer)
        Me.GroupBox2.Controls.Add(Me.cbInvoiceYear)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbRemaining)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cbInvoiceMonth)
        Me.GroupBox2.Location = New System.Drawing.Point(52, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(417, 306)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter by Date Invoice"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Ledger Type:"
        '
        'cbLedgerType
        '
        Me.cbLedgerType.FormattingEnabled = True
        Me.cbLedgerType.Location = New System.Drawing.Point(130, 109)
        Me.cbLedgerType.Name = "cbLedgerType"
        Me.cbLedgerType.Size = New System.Drawing.Size(262, 21)
        Me.cbLedgerType.TabIndex = 29
        '
        'btnPrintDateInvoice
        '
        Me.btnPrintDateInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintDateInvoice.Location = New System.Drawing.Point(295, 250)
        Me.btnPrintDateInvoice.Name = "btnPrintDateInvoice"
        Me.btnPrintDateInvoice.Size = New System.Drawing.Size(97, 32)
        Me.btnPrintDateInvoice.TabIndex = 0
        Me.btnPrintDateInvoice.Text = "Print"
        Me.btnPrintDateInvoice.UseVisualStyleBackColor = True
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(130, 31)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(262, 21)
        Me.cbCustomer.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Customer:"
        '
        'cbRemaining
        '
        Me.cbRemaining.FormattingEnabled = True
        Me.cbRemaining.Location = New System.Drawing.Point(130, 69)
        Me.cbRemaining.Name = "cbRemaining"
        Me.cbRemaining.Size = New System.Drawing.Size(262, 21)
        Me.cbRemaining.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Remaining:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(223, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Is Floating:"
        '
        'cbCheckFloating
        '
        Me.cbCheckFloating.FormattingEnabled = True
        Me.cbCheckFloating.Location = New System.Drawing.Point(287, 104)
        Me.cbCheckFloating.Name = "cbCheckFloating"
        Me.cbCheckFloating.Size = New System.Drawing.Size(104, 21)
        Me.cbCheckFloating.TabIndex = 38
        '
        'FilterCheckReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 390)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FilterCheckReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FilterCheckReports"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPrintCheckDate As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbCheckYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCheckMonth As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbInvoiceYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbInvoiceMonth As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrintDateInvoice As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbLedgerType As System.Windows.Forms.ComboBox
    Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbRemaining As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbLedgerType2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbCustomer2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbRemaining2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbCheckFloating As ComboBox
    Friend WithEvents Label11 As Label
End Class
