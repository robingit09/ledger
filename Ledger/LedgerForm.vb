Public Class LedgerForm

    Public selectedCustomer As Integer = 0
    Public selectedPaymentType As Integer = 0
    Public selectedLedgerType As Integer = 0
    Public term As Integer = 0
    Public isfloating As Boolean = False

    Public Sub loadTerm()
        cbTerms.Items.Clear()
        cbTerms.Items.Add("Select Term")
        cbTerms.Items.Add("30 Days")
        cbTerms.Items.Add("60 Days")
        cbTerms.Items.Add("90 Days")
        cbTerms.Items.Add("120 Days")
        cbTerms.SelectedIndex = 0
    End Sub

    Public Sub getCustomerList(ByVal query As String)

        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()
        Dim db As New DatabaseCon

        With db
            If query = "" Then
                .selectByQuery("select distinct company,ID from company where status <> 0")
            Else

            End If

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Customer")
            While db.dr.Read
                Dim cus As String = db.dr.GetValue(0)
                Dim id As String = db.dr.GetValue(1)
                comboSource.Add(id, cus)
            End While

            cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
            cbCustomer.DisplayMember = "Value"
            cbCustomer.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            If (validator()) Then
                Exit Sub
            End If
            insertData()
            clearfields()
            LedgerList.loadLedger("")
            LedgerList.loadledgertype()
            LedgerList.getPaymentMode()

        ElseIf btnSave.Text = "Update" Then
            'MsgBox(selectedPaymentType)
            'Exit Sub
            If (validator()) Then
                Exit Sub
            End If
            updateData()
            clearfields()
            LedgerList.loadLedger("")
            LedgerList.loadledgertype()
            LedgerList.getPaymentMode()
            Me.Close()

        End If
    End Sub

    Public Sub clearfields()
        cbCustomer.Text = ""
        txtCounterNo.Text = ""
        txtInvoiceNo.Text = ""
        txtAmount.Text = ""

        rPaidYes.Checked = False
        rPaidNo.Checked = False
        rbFloatingYes.Checked = False
        rbFloatingNo.Checked = False

        txtBankDetails.Text = ""
        cbLedgerType.SelectedIndex = 0
        cbCustomer.SelectedIndex = 0
        cbPaymentType.SelectedIndex = 0
        cbTerms.SelectedIndex = 0
        txtRemarks.Clear()

    End Sub

    Private Sub insertData()

        Dim db As New DatabaseCon
        With db
            Try
                .cmd.CommandType = CommandType.Text
                .cmd.Connection = .con
                .cmd.CommandText = "INSERT INTO ledger([customer],[date_issue],[counter_no],[invoice_no],[amount],[payment_type],[date_paid],[paid],[check_date],[bank_details],[floating],[ledger],[status],[created_at],[updated_at],[payment_due_date],[payment_terms],[remarks])" & _
                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                .cmd.Parameters.AddWithValue("@customer", selectedCustomer)
                .cmd.Parameters.AddWithValue("@date_issue", dtpDateIssue.Value.Date.ToString)

                Dim ctr_no_result As String = ""
                If txtCounterNo.Text.Length > 0 Then
                    ctr_no_result = txtCounterNo.Text
                Else
                    ctr_no_result = "0"
                End If

                .cmd.Parameters.AddWithValue("@counter_no", ctr_no_result)
                .cmd.Parameters.AddWithValue("@invoice_no", txtInvoiceNo.Text)

                Dim format_amount As String = ""
                If txtAmount.Text.Contains(",") Or txtAmount.Text.Contains(".") Then
                    format_amount = txtAmount.Text.Replace(",", "")
                End If

                .cmd.Parameters.AddWithValue("@amount", format_amount)
                .cmd.Parameters.AddWithValue("@payment_type", selectedPaymentType)
                .cmd.Parameters.AddWithValue("@date_paid", dtpPaid.Value.Date.ToString)

                Dim ispaid As Boolean
                If rPaidYes.Checked Then
                    ispaid = True
                End If

                If rPaidNo.Checked Then
                    ispaid = False
                End If
                .cmd.Parameters.AddWithValue("@paid", ispaid)
                .cmd.Parameters.AddWithValue("@check_date", dtpCheckDate.Value.Date.ToString)
                .cmd.Parameters.AddWithValue("@bank_details", txtBankDetails.Text)
                .cmd.Parameters.AddWithValue("@floating", Me.isfloating)

                If Trim(cbLedgerType.Text) = "charge" Then
                    selectedLedgerType = 0
                ElseIf Trim(cbLedgerType.Text) = "delivery" Then
                    selectedLedgerType = 1
                End If
                .cmd.Parameters.AddWithValue("@ledger", selectedLedgerType)
                .cmd.Parameters.AddWithValue("@status", 1)
                .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)

                Dim payment_date As New Date
                payment_date = dtpDateIssue.Value.AddDays(term)
                .cmd.Parameters.AddWithValue("@payment_due_date", payment_date.ToString)
                .cmd.Parameters.AddWithValue("@payment_terms", term)
                .cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)
                .cmd.ExecuteNonQuery()
                .cmd.Dispose()
                .con.Close()

                MsgBox("Save Successful!", MsgBoxStyle.Information)
                clearfields()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message & " " & .cmd.CommandText, MsgBoxStyle.Critical)
            End Try
        End With
    End Sub

    Private Sub updateData()

        Dim ispaid As Boolean = False
        If rPaidYes.Checked = True Then
            ispaid = True
        End If
        If rPaidNo.Checked = True Then
            ispaid = False
        End If

        Dim isfloating As Boolean = False
        If rbFloatingYes.Checked = True Then
            isfloating = True
        End If
        If rbFloatingNo.Checked = True Then
            isfloating = False
        End If
        Dim dtp_payment_due As New Date
        dtp_payment_due = dtpDateIssue.Value.AddDays(term)


        Dim db As New DatabaseCon
        With db
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            '            .cmd.CommandText = "UPDATE [ledger] SET [counter_no]='" & txtCounterNo.Text & "',[date_issue]='" & dtpDateIssue.Value.Date & "',[invoice_no]='" & txtInvoiceNo.Text & "',[amount]=" & txtAmount.Text & ", " & _
            '"[paid]=" & ispaid & ",[date_paid]='" & dtpPaid.Value.Date & "', [floating]=" & isfloating & ",[bank_details]='" & txtBankDetails.Text & "',[check_date]='" & dtpCheckDate.Value.Date & "',[customer]=" & Me.selectedCustomer & ",[ledger]= " & selectedLedgerType & ",[payment_type]= " & selectedPaymentType & ",[updated_at]='" & DateTime.Now.ToString & "',[payment_due_date]='" & dtp_payment_due.ToString & "',[payment_terms]=" & term & ",[remarks]= '" & txtRemarks.Text & "' WHERE [ID] = " & LedgerList.selectedID

            '            .cmd.CommandText = "UPDATE ledger SET [counter_no]='" & txtCounterNo.Text & "',[date_issue]='" & dtpDateIssue.Value.Date & "',[invoice_no]='" & txtInvoiceNo.Text & "',[amount]=" & txtAmount.Text & ", " & _
            '"[paid]=" & ispaid & ",[date_paid]='" & dtpPaid.Value.Date & "', [floating]=" & isfloating & ",[bank_details]='" & txtBankDetails.Text & "',[check_date]='" & dtpCheckDate.Value.Date & "',[customer]=" & Me.selectedCustomer & ",[ledger]= " & selectedLedgerType & ",[payment_type]= " & selectedPaymentType & ",[updated_at]='" & DateTime.Now.ToString & "',[payment_due_date]='" & dtp_payment_due.ToString & "',[payment_terms]=" & term & ",[remarks]= '" & txtRemarks.Text & "' WHERE [ID] = " & LedgerList.selectedID
           
            .cmd.CommandText = "UPDATE ledger SET [counter_no]=?,[date_issue]=?,[invoice_no]=?,[amount]=?, " & _
            "[paid]=?,[date_paid]=?, [floating]=?,[bank_details]=?,[check_date]=?,[customer]=?,[ledger]=?,[payment_type]=?,[updated_at]=?,[payment_due_date]=?,[payment_terms]=?,[remarks]=? WHERE [ID] = " & LedgerList.selectedID
            .cmd.Parameters.AddWithValue("@counter_no", Val(txtCounterNo.Text))
            .cmd.Parameters.AddWithValue("@date_issue", dtpDateIssue.Value.Date)
            .cmd.Parameters.AddWithValue("@invoice_no", txtInvoiceNo.Text)

            Dim format_amount As String = ""
            If txtAmount.Text.Contains(",") Or txtAmount.Text.Contains(".") Then
                format_amount = txtAmount.Text.Replace(",", "")
            End If

            .cmd.Parameters.AddWithValue("@amount", format_amount)
            .cmd.Parameters.AddWithValue("@paid", ispaid)
            .cmd.Parameters.AddWithValue("@date_paid", dtpPaid.Value.Date.ToString)
            .cmd.Parameters.AddWithValue("@floating", isfloating)
            .cmd.Parameters.AddWithValue("@bank_details", txtBankDetails.Text)
            .cmd.Parameters.AddWithValue("@check_date", dtpCheckDate.Value.Date.ToString)
            .cmd.Parameters.AddWithValue("@customer", Val(Me.selectedCustomer))
            .cmd.Parameters.AddWithValue("@ledger", Val(Me.selectedLedgerType))
            .cmd.Parameters.AddWithValue("@payment_type", Val(Me.selectedPaymentType))
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@payment_due_date", dtp_payment_due.ToString)
            .cmd.Parameters.AddWithValue("@payment_terms", Val(term))
            .cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)

          
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            MsgBox("Update Successful!", MsgBoxStyle.Information)

        End With
    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            cbCustomer.BackColor = Color.White
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key
        End If
    End Sub

    Public Sub loadLedgerType()
        cbLedgerType.DataSource = Nothing
        cbLedgerType.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add(-1, "Select Ledger Type")
        comboSource.Add(0, "Charge")
        comboSource.Add(1, "Delivery")

        cbLedgerType.DataSource = New BindingSource(comboSource, Nothing)
        cbLedgerType.DisplayMember = "Value"
        cbLedgerType.ValueMember = "Key"

        cbLedgerType.SelectedIndex = 0
    End Sub
    Public Sub loadPaymentType()
        cbPaymentType.DataSource = Nothing
        cbPaymentType.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add(-1, "Select Payment Type")
        comboSource.Add(0, "Cash")
        comboSource.Add(1, "C.O.D")
        comboSource.Add(2, "Credit")
        comboSource.Add(3, "Post Dated")

        cbPaymentType.DataSource = New BindingSource(comboSource, Nothing)
        cbPaymentType.DisplayMember = "Value"
        cbPaymentType.ValueMember = "Key"

        cbPaymentType.SelectedIndex = 0
    End Sub

    Private Sub cbLedgerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLedgerType.SelectedIndexChanged

        If cbLedgerType.SelectedIndex > 0 Then
            cbLedgerType.BackColor = Color.White
            Dim key As String = DirectCast(cbLedgerType.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbLedgerType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedLedgerType = key

        End If
    End Sub

    Private Sub cbPaymentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPaymentType.SelectedIndexChanged
        If cbPaymentType.SelectedIndex > 0 Then
            cbPaymentType.BackColor = Color.White

            Select Case cbPaymentType.Text
                Case "Cash"
                    gpCheck.Enabled = False
                Case "C.O.D"
                    gpCheck.Enabled = False
                Case "Credit"
                    gpCheck.Enabled = True
                Case Else
                    gpCheck.Enabled = False
            End Select

            If Trim(cbPaymentType.Text) = "Credit" Then
                txtCounterNo.Enabled = True
                rPaidNo.Checked = True
                rbFloatingNo.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = False
                txtBankDetails.Enabled = False
                txtBankDetails.Clear()
                gpCheck.Enabled = False
                cbTerms.Enabled = True

            End If

            If Trim(cbPaymentType.Text) = "C.O.D" Then
                txtCounterNo.Enabled = False
                txtCounterNo.Clear()
                txtCounterNo.BackColor = Color.White
                rPaidYes.Checked = True
                rbFloatingYes.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = True
                gpCheck.Enabled = True
                txtBankDetails.Enabled = True
                cbTerms.Enabled = False

            End If

            If Trim(cbPaymentType.Text) = "Cash" Then
                txtCounterNo.Enabled = False
                txtCounterNo.Clear()
                txtCounterNo.BackColor = Color.White
                rPaidYes.Checked = True
                rbFloatingYes.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = True
                txtBankDetails.Enabled = False
                txtBankDetails.Clear()
                gpCheck.Enabled = False
                cbTerms.Enabled = False

            End If

            If Trim(cbPaymentType.Text) = "Post Dated" Then
                txtCounterNo.Enabled = True
                rPaidYes.Checked = True
                rbFloatingYes.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = True
                gpCheck.Enabled = True
                txtBankDetails.Enabled = True
                cbTerms.Enabled = False

            End If

            Dim key As Integer = CInt(DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPaymentType = key
        End If
    End Sub
    Private Function validator() As Boolean

        Dim err_ As Boolean = False
        If cbCustomer.SelectedIndex <= 0 Then
            MsgBox("Please select customer!", MsgBoxStyle.Critical)
            cbCustomer.BackColor = Color.Red
            cbCustomer.Focus()
            err_ = True
            Return err_
        End If

        If Trim(txtCounterNo.Text).Length = 0 And txtCounterNo.Enabled = True Then
            MsgBox("Please input counter no!", MsgBoxStyle.Critical)
            txtCounterNo.Focus()
            err_ = True
            Return err_
        End If

        If Trim(txtInvoiceNo.Text).Length = 0 Then
            MsgBox("Please input invoice no!", MsgBoxStyle.Critical)
            txtCounterNo.Focus()
            err_ = True
            Return err_
        End If

        If Trim(txtAmount.Text).Length = 0 Then
            MsgBox("Please input amount no!", MsgBoxStyle.Critical)
            txtCounterNo.Focus()
            err_ = True
            Return err_
        End If

        If cbPaymentType.SelectedIndex <= 0 Then
            MsgBox("Please select payment type!", MsgBoxStyle.Critical)
            cbPaymentType.BackColor = Color.Red
            cbPaymentType.Focus()
            err_ = True
            Return err_
        End If

        If rPaidYes.Checked = False And rPaidNo.Checked = False Then
            MsgBox("Please check if paid!", MsgBoxStyle.Critical)
            gpPaid.BackColor = Color.Red
            gpPaid.Focus()
            err_ = True
            Return err_
        End If

        If Trim(txtBankDetails.Text).Length = 0 And (cbPaymentType.Text = "Post Dated" Or cbPaymentType.Text = "C.O.D") Then
            MsgBox("Please input bank details!", MsgBoxStyle.Critical)
            txtBankDetails.BackColor = Color.Red
            txtBankDetails.Focus()
            err_ = True
            Return err_
        End If

        If gpCheck.Enabled = True And rPaidYes.Checked And (rbFloatingYes.Checked = False And rbFloatingNo.Checked = False) Then
            MsgBox("Please check floating!", MsgBoxStyle.Critical)
            gpCheck.BackColor = Color.Red
            gpCheck.Focus()
            err_ = True
            Return err_
        End If

        If selectedPaymentType = 2 And term = 0 Then
            MsgBox("Please select terms!", MsgBoxStyle.Critical)
            cbTerms.BackColor = Color.Red
            cbTerms.Focus()
            err_ = True
            Return err_
        End If



        If cbLedgerType.SelectedIndex <= 0 Then
            MsgBox("Please select ledger type!", MsgBoxStyle.Critical)
            cbLedgerType.BackColor = Color.Red
            cbLedgerType.Focus()
            err_ = True
            Return err_
        End If

        'input format validation
        If Not IsNumeric(txtAmount.Text) Then
            MsgBox("Invalid input type for amount!", MsgBoxStyle.Critical)
            txtAmount.BackColor = Color.Red
            txtAmount.Focus()
            err_ = True
            Return err_
        End If

        If Not IsNumeric(txtCounterNo.Text) And txtCounterNo.Enabled = True Then
            MsgBox("Invalid input for counter no!", MsgBoxStyle.Critical)
            txtCounterNo.BackColor = Color.Red
            txtCounterNo.Focus()
            err_ = True
            Return err_
        End If

        If Not IsNumeric(txtInvoiceNo.Text) Then
            MsgBox("Invalid input for invoice no!", MsgBoxStyle.Critical)
            txtInvoiceNo.BackColor = Color.Red
            txtInvoiceNo.Focus()
            err_ = True
            Return err_
        End If

        Return err_
    End Function

    Private Sub btnSaveAndPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAndPrint.Click
        If (validator()) Then
            Exit Sub
        End If
        insertData()
        clearfields()
        LedgerList.loadLedger("")
        Me.Close()

        Dim cr As New crLedgerByCustomer
        cr.RecordSelectionFormula = "{ledger.ID} = " & getLastID()
        ReportViewer.Enabled = True
        ReportViewer.CrystalReportViewer1.ReportSource = cr
        ReportViewer.CrystalReportViewer1.Refresh()
        ReportViewer.CrystalReportViewer1.RefreshReport()
        ReportViewer.ShowDialog()
    End Sub

    Public Function getLastID() As Integer
        Dim id As Integer = 0
        Dim db As New DatabaseCon
        With db
            .selectByQuery("SELECT ID from ledger where status <> 0 order by ID DESC")
            If .dr.Read Then
                id = .dr.GetValue(0)
            End If
        End With
        Return id
    End Function
    
    Private Sub rbFloatingYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFloatingYes.CheckedChanged
        If rbFloatingYes.Checked Then
            Me.isfloating = True
        End If
    End Sub

    Private Sub rbFloatingNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFloatingNo.CheckedChanged
        If rbFloatingNo.Checked Then
            Me.isfloating = false
        End If
    End Sub

    Private Sub txtCounterNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCounterNo.TextChanged
        If txtCounterNo.TextLength > 0 Then
            If Not IsNumeric(txtCounterNo.Text) Then
                txtCounterNo.BackColor = Color.Red
                txtCounterNo.SelectAll()
            Else
                txtCounterNo.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub txtInvoiceNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceNo.TextChanged
        If txtInvoiceNo.TextLength > 0 Then
            If Not IsNumeric(txtInvoiceNo.Text) Then
                txtInvoiceNo.BackColor = Color.Red
                txtInvoiceNo.SelectAll()
            Else
                txtInvoiceNo.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        If txtAmount.TextLength > 0 Then
            If Not IsNumeric(txtAmount.Text) Then
                txtAmount.BackColor = Color.Red
                txtAmount.SelectAll()
            Else
                txtAmount.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub cbPaymentType_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPaymentType.Enter
        If txtAmount.Text.Length > 0 Then
            txtAmount.Text = FormatCurrency(txtAmount.Text).Replace("$", "")
        End If
    End Sub

    Private Sub cbTerms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTerms.SelectedIndexChanged
        Select Case cbTerms.Text
            Case "30 Days"
                term = 30
            Case "60 Days"
                term = 60
            Case "90 Days"
                term = 90
            Case "120 Days"
                term = 120
            Case Else
                term = 0
        End Select
        If cbTerms.SelectedIndex > 0 Then
            cbTerms.BackColor = Color.White
        End If
    End Sub

    Private Sub btnAddCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCustomer.Click
        CustomerForm.btnSave.Text = "Save"
        CustomerForm.loadCompanyStatus()
        CustomerForm.ShowDialog()
    End Sub

    Private Sub txtAmount_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.Leave
        If txtAmount.Text.Length > 0 Then
            txtAmount.Text = FormatCurrency(txtAmount.Text).Replace("$", "")
        End If
    End Sub

    Private Sub txtBankDetails_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBankDetails.TextChanged
        If Trim(txtBankDetails.Text).Length > 0 Then
            txtBankDetails.BackColor = Color.White
        End If
    End Sub

    Private Sub cbCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer.TextChanged
        If cbCustomer.Text.Length > 0 Then
            'getCustomerList("select distinct company,ID from company where company like '%" & Trim(cbCustomer.Text) & "%' status <> 0")
        End If
    End Sub

    Private Sub LedgerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    'Public Sub autocompleteCustomer()
    '    Dim MySource As New AutoCompleteStringCollection()

    '    With cbCustomer
    '        .AutoCompleteCustomSource = MySource
    '        .AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        .AutoCompleteSource = AutoCompleteSource.CustomSource
    '    End With

    '    MySource.Add("asdasd")
    'End Sub
End Class
