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
        Me.components = New System.ComponentModel.Container()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dgvLedger = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatePaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsFloating = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CounterNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Terms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ledger = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.business_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.View = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbPaid = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbBusinessType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbSalesType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbpayment_mode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.cbLedgerType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LedgerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TermsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LedgerSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckNotificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoSetFloatingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.loadLedgerWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.View.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.btnUpdate.Text = "Update"
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
        Me.dgvLedger.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLedger.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.DateIssue, Me.Customer, Me.InvoiceNo, Me.Amount, Me.IsPaid, Me.DatePaid, Me.IsFloating, Me.BankDetails, Me.CheckDate, Me.CounterNo, Me.Terms, Me.PaymentType, Me.Ledger, Me.Status, Me.sales_type, Me.business_type})
        Me.dgvLedger.ContextMenuStrip = Me.View
        Me.dgvLedger.Location = New System.Drawing.Point(11, 174)
        Me.dgvLedger.Name = "dgvLedger"
        Me.dgvLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLedger.Size = New System.Drawing.Size(1347, 550)
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
        Me.Customer.Width = 170
        '
        'InvoiceNo
        '
        Me.InvoiceNo.HeaderText = "Invoice No"
        Me.InvoiceNo.Name = "InvoiceNo"
        Me.InvoiceNo.ReadOnly = True
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
        'BankDetails
        '
        Me.BankDetails.HeaderText = "Bank Details"
        Me.BankDetails.Name = "BankDetails"
        Me.BankDetails.ReadOnly = True
        Me.BankDetails.Width = 170
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
        'PaymentType
        '
        Me.PaymentType.HeaderText = "Payment Type"
        Me.PaymentType.Name = "PaymentType"
        Me.PaymentType.ReadOnly = True
        Me.PaymentType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PaymentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Ledger
        '
        Me.Ledger.HeaderText = "Ledger Type"
        Me.Ledger.Name = "Ledger"
        Me.Ledger.ReadOnly = True
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'sales_type
        '
        Me.sales_type.HeaderText = "Sales Type"
        Me.sales_type.Name = "sales_type"
        Me.sales_type.ReadOnly = True
        '
        'business_type
        '
        Me.business_type.HeaderText = "Business Type"
        Me.business_type.Name = "business_type"
        Me.business_type.ReadOnly = True
        '
        'View
        '
        Me.View.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem})
        Me.View.Name = "View"
        Me.View.Size = New System.Drawing.Size(155, 26)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ViewToolStripMenuItem.Text = "View or Update"
        '
        'btnFilter
        '
        Me.btnFilter.BackColor = System.Drawing.Color.Transparent
        Me.btnFilter.Location = New System.Drawing.Point(925, 54)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbPaid)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbBusinessType)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbSalesType)
        Me.GroupBox1.Controls.Add(Me.Label3)
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
        Me.GroupBox1.Size = New System.Drawing.Size(1019, 100)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FILTER"
        '
        'cbPaid
        '
        Me.cbPaid.FormattingEnabled = True
        Me.cbPaid.Location = New System.Drawing.Point(358, 56)
        Me.cbPaid.Name = "cbPaid"
        Me.cbPaid.Size = New System.Drawing.Size(204, 21)
        Me.cbPaid.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(274, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Paid:"
        '
        'cbBusinessType
        '
        Me.cbBusinessType.FormattingEnabled = True
        Me.cbBusinessType.Location = New System.Drawing.Point(671, 23)
        Me.cbBusinessType.Name = "cbBusinessType"
        Me.cbBusinessType.Size = New System.Drawing.Size(245, 21)
        Me.cbBusinessType.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(586, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Business Type:"
        '
        'cbSalesType
        '
        Me.cbSalesType.FormattingEnabled = True
        Me.cbSalesType.Location = New System.Drawing.Point(671, 56)
        Me.cbSalesType.Name = "cbSalesType"
        Me.cbSalesType.Size = New System.Drawing.Size(245, 21)
        Me.cbSalesType.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(586, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Sales Type:"
        '
        'cbpayment_mode
        '
        Me.cbpayment_mode.FormattingEnabled = True
        Me.cbpayment_mode.Location = New System.Drawing.Point(358, 23)
        Me.cbpayment_mode.Name = "cbpayment_mode"
        Me.cbpayment_mode.Size = New System.Drawing.Size(204, 21)
        Me.cbpayment_mode.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(274, 26)
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem, Me.CustomerToolStripMenuItem, Me.NotificationToolStripMenuItem, Me.CheckNotificationToolStripMenuItem, Me.AutoSetFloatingToolStripMenuItem, Me.UserManagementToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1370, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerToolStripMenuItem1, Me.LedgerToolStripMenuItem, Me.TermsToolStripMenuItem, Me.CheckToolStripMenuItem, Me.LedgerSummaryToolStripMenuItem})
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.PrintToolStripMenuItem.Text = "Reports"
        '
        'CustomerToolStripMenuItem1
        '
        Me.CustomerToolStripMenuItem1.Name = "CustomerToolStripMenuItem1"
        Me.CustomerToolStripMenuItem1.Size = New System.Drawing.Size(164, 22)
        Me.CustomerToolStripMenuItem1.Text = "Customer"
        '
        'LedgerToolStripMenuItem
        '
        Me.LedgerToolStripMenuItem.Name = "LedgerToolStripMenuItem"
        Me.LedgerToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.LedgerToolStripMenuItem.Text = "Ledger"
        '
        'TermsToolStripMenuItem
        '
        Me.TermsToolStripMenuItem.Name = "TermsToolStripMenuItem"
        Me.TermsToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.TermsToolStripMenuItem.Text = "Terms"
        '
        'CheckToolStripMenuItem
        '
        Me.CheckToolStripMenuItem.Name = "CheckToolStripMenuItem"
        Me.CheckToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CheckToolStripMenuItem.Text = "Check"
        '
        'LedgerSummaryToolStripMenuItem
        '
        Me.LedgerSummaryToolStripMenuItem.Name = "LedgerSummaryToolStripMenuItem"
        Me.LedgerSummaryToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.LedgerSummaryToolStripMenuItem.Text = "Ledger Summary"
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
        'AutoSetFloatingToolStripMenuItem
        '
        Me.AutoSetFloatingToolStripMenuItem.Name = "AutoSetFloatingToolStripMenuItem"
        Me.AutoSetFloatingToolStripMenuItem.Size = New System.Drawing.Size(110, 20)
        Me.AutoSetFloatingToolStripMenuItem.Text = "Auto Set Floating"
        '
        'UserManagementToolStripMenuItem
        '
        Me.UserManagementToolStripMenuItem.Name = "UserManagementToolStripMenuItem"
        Me.UserManagementToolStripMenuItem.Size = New System.Drawing.Size(116, 20)
        Me.UserManagementToolStripMenuItem.Text = "User Management"
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(1266, 27)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(92, 35)
        Me.btnLoad.TabIndex = 7
        Me.btnLoad.Text = "Reload"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.txtSearch)
        Me.GroupBox2.Location = New System.Drawing.Point(1037, 68)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(321, 100)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search Information"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(183, 59)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(118, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(18, 26)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(283, 20)
        Me.txtSearch.TabIndex = 0
        '
        'loadLedgerWorker1
        '
        Me.loadLedgerWorker1.WorkerReportsProgress = True
        Me.loadLedgerWorker1.WorkerSupportsCancellation = True
        '
        'LedgerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 749)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoad)
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
        Me.Text = "Ledger"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.View.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents LedgerSummaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoSetFloatingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents DateIssue As DataGridViewTextBoxColumn
    Friend WithEvents Customer As DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNo As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
    Friend WithEvents IsPaid As DataGridViewTextBoxColumn
    Friend WithEvents DatePaid As DataGridViewTextBoxColumn
    Friend WithEvents IsFloating As DataGridViewTextBoxColumn
    Friend WithEvents BankDetails As DataGridViewTextBoxColumn
    Friend WithEvents CheckDate As DataGridViewTextBoxColumn
    Friend WithEvents CounterNo As DataGridViewTextBoxColumn
    Friend WithEvents Terms As DataGridViewTextBoxColumn
    Friend WithEvents PaymentType As DataGridViewTextBoxColumn
    Friend WithEvents Ledger As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents sales_type As DataGridViewTextBoxColumn
    Friend WithEvents business_type As DataGridViewTextBoxColumn
    Friend WithEvents cbBusinessType As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbSalesType As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbPaid As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents loadLedgerWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents UserManagementToolStripMenuItem As ToolStripMenuItem
End Class
