<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LedgerSummary
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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fNo = New System.Windows.Forms.RadioButton()
        Me.fYes = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLedgerType = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTransCount = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ckPost = New System.Windows.Forms.CheckBox()
        Me.ckCredit = New System.Windows.Forms.CheckBox()
        Me.ckCOD = New System.Windows.Forms.CheckBox()
        Me.ckCash = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rMonth = New System.Windows.Forms.RadioButton()
        Me.gCustomer = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.pNo = New System.Windows.Forms.RadioButton()
        Me.pYes = New System.Windows.Forms.RadioButton()
        Me.cbSalesType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rYear = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(369, 546)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.fNo)
        Me.GroupBox1.Controls.Add(Me.fYes)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 276)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 47)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Floating"
        '
        'fNo
        '
        Me.fNo.AutoSize = True
        Me.fNo.Location = New System.Drawing.Point(120, 19)
        Me.fNo.Name = "fNo"
        Me.fNo.Size = New System.Drawing.Size(41, 17)
        Me.fNo.TabIndex = 1
        Me.fNo.TabStop = True
        Me.fNo.Text = "No"
        Me.fNo.UseVisualStyleBackColor = True
        '
        'fYes
        '
        Me.fYes.AutoSize = True
        Me.fYes.Location = New System.Drawing.Point(20, 19)
        Me.fYes.Name = "fYes"
        Me.fYes.Size = New System.Drawing.Size(46, 17)
        Me.fYes.TabIndex = 0
        Me.fYes.TabStop = True
        Me.fYes.Text = "Yes"
        Me.fYes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Customer"
        '
        'cbCustomer
        '
        Me.cbCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(173, 26)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(283, 21)
        Me.cbCustomer.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ledger Type"
        '
        'txtLedgerType
        '
        Me.txtLedgerType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLedgerType.Location = New System.Drawing.Point(173, 58)
        Me.txtLedgerType.Name = "txtLedgerType"
        Me.txtLedgerType.ReadOnly = True
        Me.txtLedgerType.Size = New System.Drawing.Size(283, 20)
        Me.txtLedgerType.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Transaction Count"
        '
        'txtTransCount
        '
        Me.txtTransCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransCount.Location = New System.Drawing.Point(173, 92)
        Me.txtTransCount.Name = "txtTransCount"
        Me.txtTransCount.ReadOnly = True
        Me.txtTransCount.Size = New System.Drawing.Size(283, 20)
        Me.txtTransCount.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckPost)
        Me.GroupBox2.Controls.Add(Me.ckCredit)
        Me.GroupBox2.Controls.Add(Me.ckCOD)
        Me.GroupBox2.Controls.Add(Me.ckCash)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 341)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(439, 82)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "View Filter"
        '
        'ckPost
        '
        Me.ckPost.AutoSize = True
        Me.ckPost.Checked = True
        Me.ckPost.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckPost.Location = New System.Drawing.Point(332, 34)
        Me.ckPost.Name = "ckPost"
        Me.ckPost.Size = New System.Drawing.Size(89, 17)
        Me.ckPost.TabIndex = 3
        Me.ckPost.Text = "Post Dated"
        Me.ckPost.UseVisualStyleBackColor = True
        '
        'ckCredit
        '
        Me.ckCredit.AutoSize = True
        Me.ckCredit.Checked = True
        Me.ckCredit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckCredit.Location = New System.Drawing.Point(227, 34)
        Me.ckCredit.Name = "ckCredit"
        Me.ckCredit.Size = New System.Drawing.Size(59, 17)
        Me.ckCredit.TabIndex = 2
        Me.ckCredit.Text = "Credit"
        Me.ckCredit.UseVisualStyleBackColor = True
        '
        'ckCOD
        '
        Me.ckCOD.AutoSize = True
        Me.ckCOD.Checked = True
        Me.ckCOD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckCOD.Location = New System.Drawing.Point(122, 34)
        Me.ckCOD.Name = "ckCOD"
        Me.ckCOD.Size = New System.Drawing.Size(60, 17)
        Me.ckCOD.TabIndex = 1
        Me.ckCOD.Text = "C.O.D"
        Me.ckCOD.UseVisualStyleBackColor = True
        '
        'ckCash
        '
        Me.ckCash.AutoSize = True
        Me.ckCash.Checked = True
        Me.ckCash.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckCash.Location = New System.Drawing.Point(19, 34)
        Me.ckCash.Name = "ckCash"
        Me.ckCash.Size = New System.Drawing.Size(54, 17)
        Me.ckCash.TabIndex = 0
        Me.ckCash.Text = "Cash"
        Me.ckCash.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rYear)
        Me.GroupBox3.Controls.Add(Me.rMonth)
        Me.GroupBox3.Controls.Add(Me.gCustomer)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 444)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(439, 79)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Group By"
        '
        'rMonth
        '
        Me.rMonth.AutoSize = True
        Me.rMonth.Location = New System.Drawing.Point(122, 36)
        Me.rMonth.Name = "rMonth"
        Me.rMonth.Size = New System.Drawing.Size(69, 17)
        Me.rMonth.TabIndex = 3
        Me.rMonth.TabStop = True
        Me.rMonth.Text = "Monthly"
        Me.rMonth.UseVisualStyleBackColor = True
        '
        'gCustomer
        '
        Me.gCustomer.AutoSize = True
        Me.gCustomer.Location = New System.Drawing.Point(19, 36)
        Me.gCustomer.Name = "gCustomer"
        Me.gCustomer.Size = New System.Drawing.Size(77, 17)
        Me.gCustomer.TabIndex = 2
        Me.gCustomer.TabStop = True
        Me.gCustomer.Text = "Customer"
        Me.gCustomer.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.pNo)
        Me.GroupBox4.Controls.Add(Me.pYes)
        Me.GroupBox4.Location = New System.Drawing.Point(276, 276)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(180, 47)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Paid "
        '
        'pNo
        '
        Me.pNo.AutoSize = True
        Me.pNo.Location = New System.Drawing.Point(120, 19)
        Me.pNo.Name = "pNo"
        Me.pNo.Size = New System.Drawing.Size(41, 17)
        Me.pNo.TabIndex = 1
        Me.pNo.TabStop = True
        Me.pNo.Text = "No"
        Me.pNo.UseVisualStyleBackColor = True
        '
        'pYes
        '
        Me.pYes.AutoSize = True
        Me.pYes.Location = New System.Drawing.Point(20, 19)
        Me.pYes.Name = "pYes"
        Me.pYes.Size = New System.Drawing.Size(46, 17)
        Me.pYes.TabIndex = 0
        Me.pYes.TabStop = True
        Me.pYes.Text = "Yes"
        Me.pYes.UseVisualStyleBackColor = True
        '
        'cbSalesType
        '
        Me.cbSalesType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSalesType.FormattingEnabled = True
        Me.cbSalesType.Location = New System.Drawing.Point(173, 127)
        Me.cbSalesType.Name = "cbSalesType"
        Me.cbSalesType.Size = New System.Drawing.Size(283, 21)
        Me.cbSalesType.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Sales Type"
        '
        'rYear
        '
        Me.rYear.AutoSize = True
        Me.rYear.Location = New System.Drawing.Point(209, 36)
        Me.rYear.Name = "rYear"
        Me.rYear.Size = New System.Drawing.Size(60, 17)
        Me.rYear.TabIndex = 4
        Me.rYear.TabStop = True
        Me.rYear.Text = "Yearly"
        Me.rYear.UseVisualStyleBackColor = True
        '
        'LedgerSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 591)
        Me.Controls.Add(Me.cbSalesType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtTransCount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLedgerType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbCustomer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "LedgerSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger Summary Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPrint As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents fNo As RadioButton
    Friend WithEvents fYes As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCustomer As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLedgerType As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTransCount As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rMonth As RadioButton
    Friend WithEvents gCustomer As RadioButton
    Friend WithEvents ckPost As CheckBox
    Friend WithEvents ckCredit As CheckBox
    Friend WithEvents ckCOD As CheckBox
    Friend WithEvents ckCash As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents pNo As RadioButton
    Friend WithEvents pYes As RadioButton
    Friend WithEvents cbSalesType As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents rYear As RadioButton
End Class
