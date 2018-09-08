<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerList
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
        Me.dgvCustomer = New System.Windows.Forms.DataGridView()
        Me.VIew = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtShowAll = New System.Windows.Forms.Button()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactPerson = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CityTown = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Owner = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OwnerAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNumber1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNumber2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FaxTel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompanyStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ledger_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VIew.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCustomer
        '
        Me.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Customer, Me.ContactPerson, Me.Address, Me.CityTown, Me.Owner, Me.OwnerAddress, Me.ContactNumber1, Me.ContactNumber2, Me.FaxTel, Me.TIN, Me.Email, Me.CompanyStatus, Me.ledger_type})
        Me.dgvCustomer.ContextMenuStrip = Me.VIew
        Me.dgvCustomer.Location = New System.Drawing.Point(12, 135)
        Me.dgvCustomer.Name = "dgvCustomer"
        Me.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomer.Size = New System.Drawing.Size(1344, 323)
        Me.dgvCustomer.TabIndex = 0
        '
        'VIew
        '
        Me.VIew.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem})
        Me.VIew.Name = "VIew"
        Me.VIew.Size = New System.Drawing.Size(100, 26)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(12, 26)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 1
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(109, 26)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(203, 26)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtShowAll)
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtLocation)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCustomer)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(932, 62)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'txtShowAll
        '
        Me.txtShowAll.Location = New System.Drawing.Point(838, 20)
        Me.txtShowAll.Name = "txtShowAll"
        Me.txtShowAll.Size = New System.Drawing.Size(75, 23)
        Me.txtShowAll.TabIndex = 6
        Me.txtShowAll.Text = "Show All"
        Me.txtShowAll.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(738, 20)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 5
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(297, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Location"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(354, 17)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(165, 20)
        Me.txtLocation.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(82, 17)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(165, 20)
        Me.txtCustomer.TabIndex = 0
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 5
        '
        'Customer
        '
        Me.Customer.HeaderText = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.ReadOnly = True
        '
        'ContactPerson
        '
        Me.ContactPerson.HeaderText = "Contact Person"
        Me.ContactPerson.Name = "ContactPerson"
        Me.ContactPerson.ReadOnly = True
        '
        'Address
        '
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        '
        'CityTown
        '
        Me.CityTown.HeaderText = "City/Town"
        Me.CityTown.Name = "CityTown"
        Me.CityTown.ReadOnly = True
        '
        'Owner
        '
        Me.Owner.HeaderText = "Owner"
        Me.Owner.Name = "Owner"
        Me.Owner.ReadOnly = True
        '
        'OwnerAddress
        '
        Me.OwnerAddress.HeaderText = "Home Address"
        Me.OwnerAddress.Name = "OwnerAddress"
        Me.OwnerAddress.ReadOnly = True
        '
        'ContactNumber1
        '
        Me.ContactNumber1.HeaderText = "Contact Number 1"
        Me.ContactNumber1.Name = "ContactNumber1"
        Me.ContactNumber1.ReadOnly = True
        '
        'ContactNumber2
        '
        Me.ContactNumber2.HeaderText = "Contact Number 2"
        Me.ContactNumber2.Name = "ContactNumber2"
        Me.ContactNumber2.ReadOnly = True
        '
        'FaxTel
        '
        Me.FaxTel.HeaderText = "Fax / Tel"
        Me.FaxTel.Name = "FaxTel"
        Me.FaxTel.ReadOnly = True
        '
        'TIN
        '
        Me.TIN.HeaderText = "TIN"
        Me.TIN.Name = "TIN"
        Me.TIN.ReadOnly = True
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        '
        'CompanyStatus
        '
        Me.CompanyStatus.HeaderText = "Company Status"
        Me.CompanyStatus.Name = "CompanyStatus"
        Me.CompanyStatus.ReadOnly = True
        '
        'ledger_type
        '
        Me.ledger_type.HeaderText = "Ledger Type"
        Me.ledger_type.Name = "ledger_type"
        Me.ledger_type.ReadOnly = True
        '
        'CustomerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1368, 489)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.dgvCustomer)
        Me.Name = "CustomerList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CustomerList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VIew.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCustomer As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents txtShowAll As System.Windows.Forms.Button
    Friend WithEvents VIew As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Customer As DataGridViewTextBoxColumn
    Friend WithEvents ContactPerson As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents CityTown As DataGridViewTextBoxColumn
    Friend WithEvents Owner As DataGridViewTextBoxColumn
    Friend WithEvents OwnerAddress As DataGridViewTextBoxColumn
    Friend WithEvents ContactNumber1 As DataGridViewTextBoxColumn
    Friend WithEvents ContactNumber2 As DataGridViewTextBoxColumn
    Friend WithEvents FaxTel As DataGridViewTextBoxColumn
    Friend WithEvents TIN As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents CompanyStatus As DataGridViewTextBoxColumn
    Friend WithEvents ledger_type As DataGridViewTextBoxColumn
End Class
