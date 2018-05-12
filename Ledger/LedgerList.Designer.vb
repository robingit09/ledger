<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerList
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
        Me.components = New System.ComponentModel.Container
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.dgvLedger = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Customer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ledger = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsPaid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DatePaid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsFloating = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BankDetails = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CounterNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Terms = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.View = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnFilter = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbpayment_mode = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.cbLedgerType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.LedgerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TermsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NotificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CheckNotificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnLoad = New System.Windows.Forms.Button
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.View.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(11, 39)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(110, 39)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "View"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(207, 39)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'dgvLedger
        '
        Me.dgvLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLedger.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.DateIssue, Me.Customer, Me.InvoiceNo, Me.Ledger, Me.Amount, Me.IsPaid, Me.DatePaid, Me.IsFloating, Me.PaymentType, Me.BankDetails, Me.CheckDate, Me.CounterNo, Me.Terms, Me.Status})
        Me.dgvLedger.ContextMenuStrip = Me.View
        Me.dgvLedger.Location = New System.Drawing.Point(11, 174)
        Me.dgvLedger.Name = "dgvLedger"
        Me.dgvLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLedger.Size = New System.Drawing.Size(1365, 477)
        Me.dgvLedger.TabIndex = 3
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 5
        '
        'DateIssue
        '
        Me.DateIssue.HeaderText = "Date Invoice"
        Me.DateIssue.Name = "DateIssue"
        Me.DateIssue.ReadOnly = True
        '
        'Customer
        '
        Me.Customer.HeaderText = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.ReadOnly = True
        '
        'InvoiceNo
        '
        Me.InvoiceNo.HeaderText = "Invoice No"
        Me.InvoiceNo.Name = "InvoiceNo"
        Me.InvoiceNo.ReadOnly = True
        '
        'Ledger
        '
        Me.Ledger.HeaderText = "Ledger Type"
        Me.Ledger.Name = "Ledger"
        Me.Ledger.ReadOnly = True
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'IsPaid
        '
        Me.IsPaid.HeaderText = "Is Paid?"
        Me.IsPaid.Name = "IsPaid"
        Me.IsPaid.ReadOnly = True
        Me.IsPaid.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DatePaid
        '
        Me.DatePaid.HeaderText = "Date Paid"
        Me.DatePaid.Name = "DatePaid"
        Me.DatePaid.ReadOnly = True
        Me.DatePaid.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatePaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'IsFloating
        '
        Me.IsFloating.HeaderText = "Is Floating?"
        Me.IsFloating.Name = "IsFloating"
        Me.IsFloating.ReadOnly = True
        Me.IsFloating.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsFloating.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PaymentType
        '
        Me.PaymentType.HeaderText = "Payment Type"
        Me.PaymentType.Name = "PaymentType"
        Me.PaymentType.ReadOnly = True
        Me.PaymentType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PaymentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BankDetails
        '
        Me.BankDetails.HeaderText = "Bank Details"
        Me.BankDetails.Name = "BankDetails"
        Me.BankDetails.ReadOnly = True
        '
        'CheckDate
        '
        Me.CheckDate.HeaderText = "Check Date"
        Me.CheckDate.Name = "CheckDate"
        Me.CheckDate.ReadOnly = True
        '
        'CounterNo
        '
        Me.CounterNo.HeaderText = "Counter No"
        Me.CounterNo.Name = "CounterNo"
        Me.CounterNo.ReadOnly = True
        '
        'Terms
        '
        Me.Terms.HeaderText = "Terms"
        Me.Terms.Name = "Terms"
        Me.Terms.ReadOnly = True
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'View
        '
        Me.View.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem})
        Me.View.Name = "View"
        Me.View.Size = New System.Drawing.Size(100, 26)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'btnFilter
        '
        Me.btnFilter.BackColor = System.Drawing.Color.Transparent
        Me.btnFilter.Location = New System.Drawing.Point(697, 59)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbpayment_mode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCustomer)
        Me.GroupBox1.Controls.Add(Me.cbLedgerType)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(793, 100)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FILTER"
        '
        'cbpayment_mode
        '
        Me.cbpayment_mode.FormattingEnabled = True
        Me.cbpayment_mode.Location = New System.Drawing.Point(568, 23)
        Me.cbpayment_mode.Name = "cbpayment_mode"
        Me.cbpayment_mode.Size = New System.Drawing.Size(204, 21)
        Me.cbpayment_mode.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(484, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Payment Type:"
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(80, 23)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(175, 20)
        Me.txtCustomer.TabIndex = 9
        '
        'cbLedgerType
        '
        Me.cbLedgerType.FormattingEnabled = True
        Me.cbLedgerType.Location = New System.Drawing.Point(80, 56)
        Me.cbLedgerType.Name = "cbLedgerType"
        Me.cbLedgerType.Size = New System.Drawing.Size(175, 21)
        Me.cbLedgerType.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Ledger Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Customer"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem, Me.CustomerToolStripMenuItem, Me.NotificationToolStripMenuItem, Me.CheckNotificationToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1377, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerToolStripMenuItem1, Me.LedgerToolStripMenuItem, Me.TermsToolStripMenuItem, Me.CheckToolStripMenuItem})
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.PrintToolStripMenuItem.Text = "Reports"
        '
        'CustomerToolStripMenuItem1
        '
        Me.CustomerToolStripMenuItem1.Name = "CustomerToolStripMenuItem1"
        Me.CustomerToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.CustomerToolStripMenuItem1.Text = "Customer"
        '
        'LedgerToolStripMenuItem
        '
        Me.LedgerToolStripMenuItem.Name = "LedgerToolStripMenuItem"
        Me.LedgerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LedgerToolStripMenuItem.Text = "Ledger"
        '
        'TermsToolStripMenuItem
        '
        Me.TermsToolStripMenuItem.Name = "TermsToolStripMenuItem"
        Me.TermsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TermsToolStripMenuItem.Text = "Terms"
        '
        'CheckToolStripMenuItem
        '
        Me.CheckToolStripMenuItem.Name = "CheckToolStripMenuItem"
        Me.CheckToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CheckToolStripMenuItem.Text = "Check"
        '
        'CustomerToolStripMenuItem
        '
        Me.CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem"
        Me.CustomerToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.CustomerToolStripMenuItem.Text = "Customer"
        '
        'NotificationToolStripMenuItem
        '
        Me.NotificationToolStripMenuItem.Name = "NotificationToolStripMenuItem"
        Me.NotificationToolStripMenuItem.Size = New System.Drawing.Size(117, 20)
        Me.NotificationToolStripMenuItem.Text = "Terms Notification"
        '
        'CheckNotificationToolStripMenuItem
        '
        Me.CheckNotificationToolStripMenuItem.Name = "CheckNotificationToolStripMenuItem"
        Me.CheckNotificationToolStripMenuItem.Size = New System.Drawing.Size(118, 20)
        Me.CheckNotificationToolStripMenuItem.Text = "Check Notification"
        '
        'btnLoad
        '
        Me.btnLoad.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(1273, 27)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(92, 35)
        Me.btnLoad.TabIndex = 7
        Me.btnLoad.Text = "Show All"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'LedgerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1377, 663)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvLedger)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimizeBox = False
        Me.Name = "LedgerList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LedgerList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.View.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents dgvLedger As System.Windows.Forms.DataGridView
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbLedgerType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbpayment_mode As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents CustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckNotificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents View As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LedgerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TermsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateIssue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Customer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ledger As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatePaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsFloating As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankDetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CounterNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Terms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
