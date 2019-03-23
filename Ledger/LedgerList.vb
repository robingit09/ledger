Public Class LedgerList

    Public selectedID As Integer = 0
    Public selectedPaymentType As Integer = 0
    Public selectedCustomer As Integer = 0

    Public selectedSalesType As Integer = 0
    Public selectedBusinessType As Integer = 0
    Public selectedPaid As Integer = -1

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click

        LedgerForm.getCustomerList("")
        LedgerForm.loadPaymentType()
        LedgerForm.loadLedgerType()
        LedgerForm.loadTerm()
        LedgerForm.loadSalesType()
        LedgerForm.btnSave.Text = "Save"
        LedgerForm.btnSaveAndPrint.Text = "Save and Print"
        LedgerForm.cbCustomer.Focus()
        LedgerForm.ShowDialog()
        autocompleteCustomer()

    End Sub

    Public Sub loadLedger(ByVal query As String)

        dgvLedger.Rows.Clear()

        Dim db As New DatabaseCon
        With db
            If query = "" Then
                .selectByQuery("SELECT top 300 * from ledger where status <> 0  order by id desc")
            Else
                .selectByQuery(query)
            End If

            If .dr.HasRows = False Then
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
                MsgBox("No record found!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            While .dr.Read
                Dim ID As Integer = CInt(.dr.GetValue(0))
                Dim counter_no As String = .dr("counter_no")
                Dim date_issue As String = Convert.ToDateTime(.dr("date_issue")).ToString("MM-dd-yyyy")
                Dim invoice_no As String = .dr("invoice_no")
                Dim amount As String = .dr("amount")
                Dim paid As Boolean = CBool(.dr("paid"))
                Dim paid_val As String = If(paid, "Yes", "No")

                Dim date_paid As String = Convert.ToDateTime(.dr("date_paid")).ToString("MM-dd-yyyy")

                Dim floating As Boolean = CBool(.dr("floating"))
                Dim floating_val As String = If(floating, "Yes", "No")

                Dim bank_details As String = .dr("bank_details")
                Dim check_date As String = Convert.ToDateTime(.dr("check_date")).ToString("MM-dd-yyyy")

                Dim status As String = .dr.GetValue(10)

                Select Case CInt(status)
                    Case 1
                        status = "Active"
                    Case 2
                        status = "Inactive"
                End Select

                Dim customer As Integer = CInt(.dr("customer"))
                Dim customer_val As String = ""
                Dim business_type As String = ""
                Dim db2 As New DatabaseCon
                With db2
                    .selectByQuery("Select company,business_type from company where ID = " & customer)
                    If .dr.Read Then
                        customer_val = If(IsDBNull(.dr.GetValue(0)), "", .dr.GetValue(0))

                        business_type = If(IsDBNull(.dr.GetValue(1)), 0, .dr.GetValue(1))
                        Select Case CInt(business_type)
                            Case 1
                                business_type = "Shop"
                            Case 2
                                business_type = "Paint Center"
                            Case Else
                                business_type = ""
                        End Select
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()

                End With

                Dim ledger_type As Integer = CInt(.dr("ledger"))
                Dim ledger_type_val As String = ""
                Select Case ledger_type
                    Case 0
                        ledger_type_val = "Charge"
                    Case 1
                        ledger_type_val = "Delivery"
                End Select


                Dim term_ As Integer = CInt(.dr("payment_terms"))
                Dim term_val As String
                If term_ = 0 Then
                    term_val = "N/A"
                ElseIf term_ = -1
                    term_val = "C.O.D"
                Else
                    term_val = CStr(term_) & " Days"
                End If

                Dim payment_type As Integer = CInt(.dr("payment_type"))
                Dim payment_type_val As String = ""
                Select Case payment_type
                    Case 0
                        payment_type_val = "Cash"
                        bank_details = "N/A"
                        check_date = "N/A"
                        counter_no = "N/A"
                        floating_val = "N/A"
                        term_val = "N/A"


                    Case 1
                        payment_type_val = "C.O.D"
                        counter_no = "N/A"

                    Case 2
                        payment_type_val = "Credit"
                        date_paid = "N/A"
                        bank_details = "N/A"
                        check_date = "N/A"
                        floating_val = "N/A"
                    Case 3
                        payment_type_val = "Post Dated"
                        term_val = "N/A"

                End Select

                Dim sales_type As String = If(IsDBNull(.dr("sales_type")), 0, .dr("sales_type"))
                Select Case CInt(sales_type)
                    Case 1
                        sales_type = "Retail"
                    Case 2
                        sales_type = "Wholesale"
                    Case Else
                        sales_type = ""
                End Select

                Dim row As String() = New String() {ID, date_issue, customer_val, invoice_no, FormatCurrency(amount).Replace("$", ""), paid_val, date_paid, floating_val, bank_details, check_date, counter_no, term_val, payment_type_val, ledger_type_val, status, sales_type, business_type}
                dgvLedger.Rows.Add(row)

            End While
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If dgvLedger.SelectedRows.Count = 1 Then
            selectedID = CInt(dgvLedger.SelectedRows(0).Cells(0).Value)
            LedgerForm.selectedID = Me.selectedID
            LedgerForm.btnSave.Text = "Update"
            LedgerForm.btnSaveAndPrint.Text = "Update and Print"
            LedgerForm.getCustomerList("")
            LedgerForm.loadPaymentType()
            LedgerForm.loadLedgerType()

            LedgerForm.loadTerm()
            LedgerForm.loadSalesType()

            loadToUpdateInfo(selectedID)
            LedgerForm.ShowDialog()
        Else
            LedgerForm.selectedID = 0
            MsgBox("Please select ledger!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If dgvLedger.SelectedRows.Count = 1 Then
            Dim id As String = dgvLedger.SelectedRows(0).Cells(0).Value
            Dim customer As String = dgvLedger.SelectedRows(0).Cells(2).Value
            Dim invoice As String = dgvLedger.SelectedRows(0).Cells(4).Value

            Dim yesno As Integer = MsgBox("Are you sure you want to delete this payment ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            If yesno = MsgBoxResult.Yes Then
                Dim dbdelete As New DatabaseCon
                With dbdelete
                    .update_where("ledger", id, "status", 0)
                    .update_where("ledger", id, "updated_at", "'" & DateTime.Now.ToString & "'")
                    .cmd.Dispose()
                    .con.Close()
                End With
                MsgBox(invoice & " has been deleted!", MsgBoxStyle.Critical)
                Me.loadLedger("")
            End If

        End If
    End Sub

    Private Sub LedgerList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModelFunction.updateFloating()
        'ModelFunction.saveledgerType()
        loadLedger("")
        loadledgertype()
        getPaymentMode()
        autocompleteCustomer()
        getSalesType()
        getBusinessType()
        getPaid()
    End Sub

    Private Sub dgvLedger_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLedger.CellContentClick
        If dgvLedger.SelectedRows.Count = 1 Then
            selectedID = CInt(dgvLedger.SelectedRows(0).Cells(0).Value)
        End If
    End Sub

    Public Sub loadToUpdateInfo(ByVal ledgerID As Integer)

        Dim db As New DatabaseCon
        With db
            .selectByQuery("Select * from ledger where status <> 0 and ID = " & ledgerID & " order by id desc")
            If .dr.Read Then
                Dim counter_no As String = .dr.GetValue(1)
                Dim date_issue As String = .dr.GetValue(2)
                Dim invoice_no As String = .dr.GetValue(3)
                Dim amount As String = .dr.GetValue(4)
                Dim paid As Boolean = CBool(.dr.GetValue(5))
                Dim date_paid As String = .dr.GetValue(6)
                Dim floating As Boolean = CBool(.dr.GetValue(7))
                Dim bank_details As String = .dr.GetValue(8)
                Dim check_date As String = .dr.GetValue(9)
                Dim status As Integer = CInt(.dr.GetValue(10))
                Dim status_val As String = ""
                Dim sales_type As String = If(IsDBNull(.dr("sales_type")), 0, .dr("sales_type"))

                Select Case status
                    Case 1
                        status_val = "Active"
                    Case 2
                        status_val = "Inactive"
                End Select

                Dim customer As Integer = CInt(.dr.GetValue(11))
                Dim customer_val As String = ""
                Dim db2 As New DatabaseCon
                With db2
                    .selectByQuery("Select company from company where ID = " & customer)
                    If .dr.Read Then
                        customer_val = .dr.GetValue(0)
                        LedgerForm.cbCustomer.SelectedIndex = LedgerForm.cbCustomer.FindStringExact(customer_val)
                        LedgerForm.cbCustomer.Text = customer_val
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                End With


                Dim ledger_type As Integer = If(IsDBNull(.dr.GetValue(12)), 0, .dr.GetValue(12))
                Dim ledger_type_val As String = ""
                Select Case ledger_type
                    Case 0
                        ledger_type_val = "Charge"
                    Case 1
                        ledger_type_val = "Delivery"
                End Select

                LedgerForm.cbLedgerType.SelectedIndex = LedgerForm.cbLedgerType.FindStringExact(ledger_type_val)
                LedgerForm.cbLedgerType.Text = ledger_type_val

                Dim payment_type As Integer = CInt(.dr.GetValue(13))
                Dim payment_type_val As String = ""
                Select Case payment_type
                    Case 0
                        payment_type_val = "Cash"
                    Case 1
                        payment_type_val = "C.O.D"
                    Case 2
                        payment_type_val = "Credit"
                    Case 3
                        payment_type_val = "Post Dated"
                End Select

                Dim term_ As Integer = CInt(.dr("payment_terms"))
                Select Case term_
                    Case 30
                        LedgerForm.cbTerms.SelectedIndex = LedgerForm.cbTerms.FindString("30 Days")
                    Case 60
                        LedgerForm.cbTerms.SelectedIndex = LedgerForm.cbTerms.FindString("60 Days")
                    Case 90
                        LedgerForm.cbTerms.SelectedIndex = LedgerForm.cbTerms.FindString("90 Days")
                    Case 120
                        LedgerForm.cbTerms.SelectedIndex = LedgerForm.cbTerms.FindString("120 Days")
                    Case 0
                        LedgerForm.cbTerms.SelectedIndex = LedgerForm.cbTerms.FindString("Select Term")
                    Case -1
                        LedgerForm.cbTerms.SelectedIndex = LedgerForm.cbTerms.FindString("C.O.D")
                End Select
                Dim remarks As String = .dr.GetValue(18)

                LedgerForm.cbPaymentType.SelectedIndex = LedgerForm.cbPaymentType.FindStringExact(ledger_type_val)
                LedgerForm.cbPaymentType.Text = payment_type_val
                LedgerForm.dtpDateIssue.Value = date_issue
                LedgerForm.txtCounterNo.Text = counter_no
                LedgerForm.txtInvoiceNo.Text = invoice_no
                LedgerForm.txtAmount.Text = amount

                If paid = True Then
                    LedgerForm.rPaidYes.Checked = True
                Else
                    LedgerForm.rPaidYes.Checked = False
                End If

                If paid = False Then
                    LedgerForm.rPaidNo.Checked = True
                Else
                    LedgerForm.rPaidNo.Checked = False
                End If

                LedgerForm.dtpPaid.Value = date_paid
                LedgerForm.txtBankDetails.Text = bank_details
                LedgerForm.dtpCheckDate.Value = check_date

                If floating = True Then
                    LedgerForm.rbFloatingYes.Checked = True
                Else
                    LedgerForm.rbFloatingYes.Checked = False
                End If

                If floating = False Then
                    LedgerForm.rbFloatingNo.Checked = True
                Else
                    LedgerForm.rbFloatingNo.Checked = False
                End If
                LedgerForm.txtRemarks.Text = remarks

                If LedgerForm.txtCounterNo.Text = "N/A" Then
                    LedgerForm.txtCounterNo.Enabled = False
                    LedgerForm.txtCounterNo.BackColor = Color.White
                    LedgerForm.cbDisable.Checked = True
                Else
                    LedgerForm.cbDisable.Checked = False
                End If


                LedgerForm.selectedSalesType = CInt(sales_type)
                Select Case CInt(sales_type)
                    Case 1
                        LedgerForm.cbSalesType.SelectedIndex = 1
                        LedgerForm.cbSalesType.BackColor = Color.White
                    Case 2
                        LedgerForm.cbSalesType.SelectedIndex = 2
                        LedgerForm.cbSalesType.BackColor = Color.White
                    Case Else
                        LedgerForm.cbSalesType.SelectedIndex = 0

                End Select
            End If
        End With
    End Sub
    Public Sub loadledgertype()
        cbLedgerType.DataSource = Nothing
        cbLedgerType.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(-1, "All")

        Dim tableledger As New DatabaseCon
        With tableledger
            .selectByQuery("SELECT distinct ledger from ledger where status <> 0")
            While .dr.Read
                Dim id As String = .dr.GetValue(0)
                Select Case id
                    Case 0
                        comboSource.Add(id, "Charge")
                    Case 1
                        comboSource.Add(id, "Delivery")
                End Select
            End While
            cbLedgerType.DataSource = New BindingSource(comboSource, Nothing)
            cbLedgerType.DisplayMember = "Value"
            cbLedgerType.ValueMember = "Key"
        End With
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Enabled = False
        Dim ledgertype_val As Integer = 0
        Select Case Trim(cbLedgerType.Text)
            Case "Charge"
                ledgertype_val = 0
            Case "Delivery"
                ledgertype_val = 1
            Case Else
                ledgertype_val = -1
        End Select

        Dim queryValidator As String = "SELECT top 300 * FROM ledger l inner join company c on c.id = l.customer WHERE l.status <> 0"

        Dim filters As New Dictionary(Of String, String)
        filters.Add("customer", txtCustomer.Text)
        filters.Add("ledger_type", ledgertype_val)
        filters.Add("payment_type", selectedPaymentType)

        For Each k In filters.Keys
            Select Case k
                Case "customer"
                    If txtCustomer.Text.Length > 0 Then
                        'cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.customer} = " & selectedCustomer
                        'queryValidator = queryValidator & " and c.company = '" & txtCustomer.Text & "'"
                        queryValidator = queryValidator & " and c.id = " & selectedCustomer
                    End If
                Case "ledger_type"
                    If cbLedgerType.Text <> "All" Then
                        'cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.payment_type} = " & selectedModeOfPayment
                        queryValidator = queryValidator & " and l.ledger = " & ledgertype_val
                    End If
                Case "payment_type"
                    If cbpayment_mode.Text <> "All" Then
                        'cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.payment_type} = " & selectedModeOfPayment
                        queryValidator = queryValidator & " and l.payment_type = " & selectedPaymentType
                    End If

            End Select
        Next

        If cbSalesType.Text <> "All" Then
            queryValidator = queryValidator & " and l.sales_type = " & selectedSalesType
        End If

        If cbBusinessType.Text <> "All" Then
            queryValidator = queryValidator & " and c.business_type = " & selectedBusinessType
        End If

        If selectedPaid = 1 Then
            queryValidator = queryValidator & " and l.paid = true"
        ElseIf selectedPaid = 0
            queryValidator = queryValidator & " and l.paid = false"
        End If


        queryValidator = queryValidator & " order by l.date_issue desc"
        loadLedger(queryValidator)
    End Sub

    Public Sub doFilter()
        Dim ledgertype_val As Integer = 0
        Select Case Trim(cbLedgerType.Text)
            Case "Charge"
                ledgertype_val = 0
            Case "Delivery"
                ledgertype_val = 1
            Case Else
                ledgertype_val = -1
        End Select

        Dim queryValidator As String = "SELECT top 200 * FROM ledger l inner join company c on c.id = l.customer WHERE l.status <> 0"

        Dim filters As New Dictionary(Of String, String)
        filters.Add("customer", txtCustomer.Text)
        filters.Add("ledger_type", ledgertype_val)
        filters.Add("payment_type", selectedPaymentType)

        For Each k In filters.Keys
            Select Case k
                Case "customer"
                    If txtCustomer.Text.Length > 0 Then
                        'cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.customer} = " & selectedCustomer
                        'queryValidator = queryValidator & " and c.company = '" & txtCustomer.Text & "'"
                        queryValidator = queryValidator & " and c.id = " & selectedCustomer
                    End If
                Case "ledger_type"
                    If cbLedgerType.Text <> "All" Then
                        'cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.payment_type} = " & selectedModeOfPayment
                        queryValidator = queryValidator & " and l.ledger = " & ledgertype_val
                    End If
                Case "payment_type"
                    If cbpayment_mode.Text <> "All" Then
                        'cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.payment_type} = " & selectedModeOfPayment
                        queryValidator = queryValidator & " and l.payment_type = " & selectedPaymentType
                    End If

            End Select
        Next
        loadLedger(queryValidator)
    End Sub

    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged

        If txtCustomer.Text.Length > 0 Then
            btnFilter.Enabled = True
        End If
    End Sub

    Public Sub autocompleteCustomer()
        Dim MySource As New AutoCompleteStringCollection()

        With txtCustomer
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With

        Dim customer As New DatabaseCon
        With customer
            .selectByQuery("Select distinct company from company  where status <> 0")
            While .dr.Read
                MySource.Add(.dr.GetValue(0))
            End While
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Public Sub getPaymentMode()
        cbpayment_mode.DataSource = Nothing
        cbpayment_mode.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()

        Dim db As New DatabaseCon
        With db
            comboSource.Add(-1, "All")
            .selectByQuery("SELECT distinct payment_type from ledger where status <> 0 order by payment_type")
            While .dr.Read
                Select Case .dr.GetValue(0)
                    Case 0
                        comboSource.Add(0, "Cash")
                    Case 1
                        comboSource.Add(1, "C.O.D")
                    Case 2
                        comboSource.Add(2, "Credit")
                    Case 3
                        comboSource.Add(3, "Post Dated")
                End Select
            End While
        End With

        cbpayment_mode.DataSource = New BindingSource(comboSource, Nothing)
        cbpayment_mode.DisplayMember = "Value"
        cbpayment_mode.ValueMember = "Key"
    End Sub

    Public Sub getSalesType()
        cbSalesType.DataSource = Nothing
        cbSalesType.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()

        Dim db As New DatabaseCon
        With db
            comboSource.Add(0, "All")
            .selectByQuery("SELECT distinct sales_type from ledger where status <> 0 and sales_type <> null  order by sales_type")
            While .dr.Read
                Select Case .dr.GetValue(0)
                    Case 1
                        comboSource.Add(1, "Retail")
                    Case 2
                        comboSource.Add(2, "Wholesale")

                End Select
            End While
        End With

        cbSalesType.DataSource = New BindingSource(comboSource, Nothing)
        cbSalesType.DisplayMember = "Value"
        cbSalesType.ValueMember = "Key"
    End Sub

    Public Sub getBusinessType()
        cbBusinessType.DataSource = Nothing
        cbBusinessType.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()

        Dim db As New DatabaseCon
        With db
            comboSource.Add(0, "All")
            .selectByQuery("SELECT distinct business_type from company where status <> 0 and business_type <> null  order by business_type")
            While .dr.Read
                Select Case .dr.GetValue(0)
                    Case 1
                        comboSource.Add(1, "Shop")
                    Case 2
                        comboSource.Add(2, "Paint Center")

                End Select
            End While
        End With

        cbBusinessType.DataSource = New BindingSource(comboSource, Nothing)
        cbBusinessType.DisplayMember = "Value"
        cbBusinessType.ValueMember = "Key"
    End Sub

    Private Sub getPaid()
        cbPaid.DataSource = Nothing
        cbPaid.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()
        'Dim db As New DatabaseCon
        'With db
        '    comboSource.Add(-1, "All")
        '    .selectByQuery("SELECT distinct paid from ledger where status <> 0 order by paid")
        '    While .dr.Read
        '        Select Case .dr.GetValue(0)
        '            Case 1
        '                comboSource.Add(0, "Yes")
        '            Case 1
        '                comboSource.Add(1, "Delivery")
        '        End Select
        '    End While
        'End With
        comboSource.Add(-1, "All")
        comboSource.Add(1, "Yes")
        comboSource.Add(0, "No")

        cbPaid.DataSource = New BindingSource(comboSource, Nothing)
        cbPaid.DisplayMember = "Value"
        cbPaid.ValueMember = "Key"

    End Sub



    Private Sub cbpayment_mode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpayment_mode.SelectedIndexChanged
        If cbpayment_mode.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbpayment_mode.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbpayment_mode.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPaymentType = key
        End If
        btnFilter.Enabled = True
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        btnLoad.Enabled = False
        Me.loadLedger("")
        txtCustomer.Clear()
        cbLedgerType.SelectedIndex = 0
        cbpayment_mode.SelectedIndex = 0
        selectedID = 0
        selectedPaymentType = 0
        txtSearch.Clear()
        btnLoad.Enabled = True
    End Sub

    Private Sub cbLedgerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLedgerType.SelectedIndexChanged
        btnFilter.Enabled = True
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem.Click
        CustomerList.ShowDialog()
    End Sub

    Private Sub NotificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotificationToolStripMenuItem.Click
        TermNotification.ShowDialog()
    End Sub

    Private Sub CheckNotificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNotificationToolStripMenuItem.Click
        CheckNotification.ShowDialog()
    End Sub

    Private Sub dgvLedger_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvLedger.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex >= 0 Then
                dgvLedger.ClearSelection()
                dgvLedger.Rows(e.RowIndex).Selected = True
                View.Show(Cursor.Position)
            End If
        End If
    End Sub


    Private Sub View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles View.Click
        btnUpdate.PerformClick()
    End Sub

    Private Sub LedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerToolStripMenuItem.Click
        LedgerFilterReports.ShowDialog()
    End Sub

    Private Sub TermsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TermsToolStripMenuItem.Click
        FilterTermReport.ShowDialog()
    End Sub

    Private Sub CheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckToolStripMenuItem.Click
        FilterCheckReports.ShowDialog()
    End Sub

    Private Sub CustomerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem1.Click
        FilterCustomerReports.ShowDialog()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Trim(txtSearch.Text).Length > 0 Then
            loadLedger("select * from ledger where counter_no like '%" & txtSearch.Text & "%' or date_issue like '%" & txtSearch.Text & "%' or invoice_no like '%" & txtSearch.Text & "%' or amount like '%" & txtSearch.Text & "%' or date_paid like '%" & txtSearch.Text & "%' or bank_details like '%" & txtSearch.Text & "%' or date_issue like '%" & txtSearch.Text & "%' and status <> 0")
        End If
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Trim(txtSearch.Text).Length > 0 Then
                loadLedger("select * from ledger where counter_no like '%" & txtSearch.Text & "%' or date_issue like '%" & txtSearch.Text & "%' or invoice_no like '%" & txtSearch.Text & "%' or amount like '%" & txtSearch.Text & "%' or date_paid like '%" & txtSearch.Text & "%' or bank_details like '%" & txtSearch.Text & "%' or date_issue like '%" & txtSearch.Text & "%' and status <> 0")
            End If
        End If
    End Sub

    Private Sub txtCustomer_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustomer.KeyDown
        If txtCustomer.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            txtCustomer.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtCustomer.Text.ToLower())
            Dim replace_customer As String = Replace(txtCustomer.Text, "'", "''")
            selectedCustomer = New DatabaseCon().get_id("company", "company", Trim(replace_customer))
        Else
            selectedCustomer = 0
        End If
    End Sub

    Private Sub LedgerSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LedgerSummaryToolStripMenuItem.Click
        LedgerSummary.ShowDialog()
    End Sub

    Private Sub AutoSetFloatingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoSetFloatingToolStripMenuItem.Click
        ModelFunction.updateFloating()
        MsgBox("Successfully floating update", MsgBoxStyle.Information)
    End Sub

    Private Sub cbSalesType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSalesType.SelectedIndexChanged
        If cbSalesType.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSalesType.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSalesType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedSalesType = key
        Else
            selectedSalesType = 0
        End If
        btnFilter.Enabled = True
    End Sub

    Private Sub cbBusinessType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBusinessType.SelectedIndexChanged
        If cbBusinessType.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbBusinessType.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbBusinessType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedBusinessType = key
        Else
            selectedBusinessType = 0
        End If
        btnFilter.Enabled = True
    End Sub

    Private Sub cbPaid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaid.SelectedIndexChanged
        If cbPaid.SelectedIndex >= 0 Then
            Dim key As String = CInt(DirectCast(cbPaid.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbPaid.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPaid = key
        End If
        btnFilter.Enabled = True
    End Sub
End Class