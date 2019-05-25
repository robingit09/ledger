Public Class FilterCheckReports

    Private invoice_customer As Integer = 0
    Dim invoice_remaining_val As String = ""
    Dim invoice_remaining_query As String = ""
    Private invoice_LedgerType As Integer = -1

    Private check_customer As Integer = 0
    Dim check_remaining_val As String = ""
    Dim check_remaining_query As String = ""
    Private check_LedgerType As Integer = -1
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintCheckDate.Click
        '** beginning of check if filter record exist
        Dim queryValidator As String = "select ID,customer from ledger where status <> 0 and (payment_type = 1 or payment_type = 3)"

        If Trim(cbCustomer2.Text) <> "All" Then
            queryValidator = queryValidator & " and customer = " & check_customer
        End If

        If Trim(cbRemaining2.Text) <> "All" Then
            queryValidator = queryValidator & " and DateDiff('d',NOW(),[check_date]) " & check_remaining_query
        End If

        If Trim(cbLedgerType2.Text) <> "All" Then
            queryValidator = queryValidator & " and ledger = " & check_LedgerType
        End If

        If cbCheckFloating.Text <> "All" Then
            If cbCheckFloating.Text = "Yes" Then
                queryValidator = queryValidator & " and floating = True"
            End If

            If cbCheckFloating.Text = "No" Then
                queryValidator = queryValidator & " and floating = False"
            End If
        End If

        If cbCheckPaid.Text <> "All" Then
            If cbCheckPaid.Text = "Yes" Then
                queryValidator = queryValidator & " and paid = True"
            End If

            If cbCheckPaid.Text = "No" Then
                queryValidator = queryValidator & " and paid = False"
            End If
        End If

        If cbCheckMonth.Text <> "All" Then
            queryValidator = queryValidator & " and MONTH(check_date) = " & monthToNumber(cbCheckMonth.Text)
        End If

        If cbCheckYear.Text <> "All" Then
            queryValidator = queryValidator & " and YEAR(check_date) = " & cbCheckYear.Text
        End If

        Dim db As New DatabaseCon
        With db
            .selectByQuery(queryValidator)
            If .dr.Read Then

            Else
                MsgBox("No record found!", MsgBoxStyle.Critical)
                .dr.Close()
                .cmd.Dispose()
                .con.Close()
                Exit Sub
            End If
        End With
        '*** end - check if filter record exist****'

        Dim cr As New crLedgerAllCustomer
        cr.RecordSelectionFormula = "{ledger.status} <> 0 and ({ledger.payment_type} = 1 or {ledger.payment_type} = 3)"

        If cbCustomer2.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND ({ledger.customer}) = " & check_customer
        End If

        If cbRemaining2.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND datediff('d',CurrentDate,{ledger.check_date}) " & check_remaining_val
        End If

        If cbLedgerType2.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.ledger} = " & check_LedgerType
        End If

        If cbCheckFloating.Text <> "All" Then
            If cbCheckFloating.Text = "Yes" Then
                cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.floating} = True"
            End If
            If cbCheckFloating.Text = "No" Then
                cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.floating} = False"
            End If
        End If

        If cbCheckPaid.Text <> "All" Then
            If cbCheckPaid.Text = "Yes" Then
                cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.paid} = True"
            End If
            If cbCheckPaid.Text = "No" Then
                cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.paid} = False"
            End If
        End If


        If cbCheckMonth.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND MONTH({ledger.check_date}) = " & monthToNumber(cbCheckMonth.Text)
        End If

        If cbCheckYear.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND YEAR({ledger.check_date}) = " & cbCheckYear.Text
        End If

        ReportViewer.Enabled = True
        ReportViewer.CrystalReportViewer1.ReportSource = cr
        ReportViewer.CrystalReportViewer1.Refresh()
        ReportViewer.CrystalReportViewer1.RefreshReport()
        ReportViewer.ShowDialog()
    End Sub

    Private Sub getMonth()
        cbCheckMonth.Items.Clear()
        cbInvoiceMonth.Items.Clear()
        Dim formatInfo = System.Globalization.DateTimeFormatInfo.CurrentInfo
        cbCheckMonth.Items.Add("All")
        cbInvoiceMonth.Items.Add("All")
        For i As Integer = 1 To 12
            Dim monthName = formatInfo.GetMonthName(i)
            cbCheckMonth.Items.Add(monthName)
            cbInvoiceMonth.Items.Add(monthName)
        Next
        cbCheckMonth.SelectedIndex = 0
        cbInvoiceMonth.SelectedIndex = 0
    End Sub

    Private Sub getYear()
        cbCheckYear.Items.Clear()
        cbCheckYear.Items.Add("All")
        Dim db As New DatabaseCon
        With db
            .selectByQuery("SELECT distinct YEAR(date_issue) FROM ledger where status <> 0 order by YEAR(date_issue) DESC")
            While .dr.Read
                cbCheckYear.Items.Add(.dr.GetValue(0))
            End While
            cbCheckYear.SelectedIndex = 0
        End With
    End Sub


    Private Sub getCheckYear()
        cbInvoiceYear.Items.Clear()
        cbInvoiceYear.Items.Add("All")
        Dim db As New DatabaseCon
        With db
            .selectByQuery("SELECT distinct YEAR(check_date) FROM ledger where status <> 0 order by YEAR(check_date) DESC")
            While .dr.Read
                cbInvoiceYear.Items.Add(.dr.GetValue(0))
            End While
            cbInvoiceYear.SelectedIndex = 0
        End With
    End Sub

    Private Function monthToNumber(ByVal month As String) As String
        Dim result As String = ""
        Select Case month.ToUpper
            Case "JANUARY"
                result = "01"
            Case "FEBRUARY"
                result = "02"
            Case "MARCH"
                result = "03"
            Case "APRIL"
                result = "04"
            Case "MAY"
                result = "05"
            Case "JUNE"
                result = "06"
            Case "JULY"
                result = "07"
            Case "AUGUST"
                result = "08"
            Case "SEPTEMBER"
                result = "09"
            Case "OCTOBER"
                result = "10"
            Case "NOVEMBER"
                result = "11"
            Case "DECEMBER"
                result = "12"
            Case Else
                result = ""
        End Select
        Return result
    End Function

    Private Sub FilterCheckReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getCustomerList("")
        loadRemaining()
        loadledgertype()
        loadCheckFloating()
        loadCheckIsPaid()

        getMonth()
        getYear()
        getCheckYear()
    End Sub

    Public Sub loadCheckFloating()
        cbCheckFloating.Items.Clear()
        cbCheckFloating.Items.Add("All")
        cbCheckFloating.Items.Add("Yes")
        cbCheckFloating.Items.Add("No")
        cbCheckFloating.SelectedIndex = 0
    End Sub


    Public Sub loadCheckIsPaid()
        cbCheckPaid.Items.Clear()
        cbCheckPaid.Items.Add("All")
        cbCheckPaid.Items.Add("Yes")
        cbCheckPaid.Items.Add("No")
        cbCheckPaid.SelectedIndex = 0
    End Sub

    Public Sub getCustomerList(ByVal query As String)

        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()

        cbCustomer2.DataSource = Nothing
        cbCustomer2.Items.Clear()

        Dim db As New DatabaseCon

        With db
            If query = "" Then
                .selectByQuery("select distinct company,ID from company where status <> 0 order by company")
            Else

            End If

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "All")
            While db.dr.Read
                Dim cus As String = db.dr.GetValue(0)
                Dim id As String = db.dr.GetValue(1)
                comboSource.Add(id, cus)
            End While

            cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
            cbCustomer.DisplayMember = "Value"
            cbCustomer.ValueMember = "Key"

            cbCustomer2.DataSource = New BindingSource(comboSource, Nothing)
            cbCustomer2.DisplayMember = "Value"
            cbCustomer2.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub

    Private Sub loadRemaining()
        cbRemaining.Items.Clear()
        cbRemaining.Items.Add("All")
        cbRemaining.Items.Add("Over Due")
        cbRemaining.Items.Add("Due Date")
        cbRemaining.Items.Add("3 to 1 Days")
        cbRemaining.Items.Add("5 to 4 Days")
        cbRemaining.Items.Add("7 to 6 Days")
        cbRemaining.SelectedIndex = 0

        cbRemaining2.Items.Clear()
        cbRemaining2.Items.Add("All")
        cbRemaining2.Items.Add("Over Due")
        cbRemaining2.Items.Add("Due Date")
        cbRemaining2.Items.Add("3 to 1 Days")
        cbRemaining2.Items.Add("5 to 4 Days")
        cbRemaining2.Items.Add("7 to 6 Days")
        cbRemaining2.SelectedIndex = 0
    End Sub

    Public Sub loadledgertype()
        cbLedgerType.DataSource = Nothing
        cbLedgerType.Items.Clear()

        cbLedgerType2.DataSource = Nothing
        cbLedgerType2.Items.Clear()


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

            cbLedgerType2.DataSource = New BindingSource(comboSource, Nothing)
            cbLedgerType2.DisplayMember = "Value"
            cbLedgerType2.ValueMember = "Key"
        End With
    End Sub

    Private Sub btnPrintDateInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDateInvoice.Click
        '** beginning of check if filter record exist
        Dim queryValidator As String = "select ID,customer from ledger where status <> 0 and (payment_type = 1 or payment_type = 3)"

        If Trim(cbCustomer.Text) <> "All" Then
            queryValidator = queryValidator & " and customer = " & invoice_customer
        End If

        If Trim(cbRemaining.Text) <> "All" Then
            queryValidator = queryValidator & " and DateDiff('d',NOW(),[payment_due_date]) " & invoice_remaining_query
        End If

        If Trim(cbLedgerType.Text) <> "All" Then
            queryValidator = queryValidator & " and ledger = " & invoice_LedgerType
        End If

        If cbInvoiceMonth.Text <> "All" Then
            queryValidator = queryValidator & " and MONTH(date_issue) = " & monthToNumber(cbInvoiceMonth.Text)
        End If

        If cbCheckYear.Text <> "All" Then
            queryValidator = queryValidator & " and YEAR(date_issue) = " & cbInvoiceYear.Text
        End If

        Dim db As New DatabaseCon
        With db
            .selectByQuery(queryValidator)
            If .dr.Read Then

            Else
                MsgBox("No record found!", MsgBoxStyle.Critical)
                .dr.Close()
                .cmd.Dispose()
                .con.Close()
                Exit Sub
            End If
        End With
        '*** end - check if filter record exist****'

        Dim cr As New crLedgerAllCustomer
        cr.RecordSelectionFormula = "{ledger.status} <> 0 and ({ledger.payment_type} = 1 or {ledger.payment_type} = 3)"

        If cbCustomer.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND ({ledger.customer}) = " & invoice_customer
        End If

        If cbRemaining.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND datediff('d',CurrentDate,{ledger.payment_due_date}) " & invoice_remaining_val
        End If

        If cbLedgerType.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.ledger} = " & invoice_LedgerType
        End If

        If cbInvoiceMonth.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND MONTH({ledger.date_issue}) = " & monthToNumber(cbInvoiceMonth.Text)
        End If

        If cbInvoiceYear.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND YEAR({ledger.date_issue}) = " & cbInvoiceYear.Text
        End If

        ReportViewer.Enabled = True
        ReportViewer.CrystalReportViewer1.ReportSource = cr
        ReportViewer.CrystalReportViewer1.Refresh()
        ReportViewer.CrystalReportViewer1.RefreshReport()
        ReportViewer.ShowDialog()
    End Sub
   
    Private Sub cbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            invoice_customer = CInt(key)
        End If
    End Sub

    Private Sub cbRemaining_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRemaining.SelectedIndexChanged
        If (cbRemaining.SelectedIndex > 0) Then
            Select Case cbRemaining.SelectedIndex
                Case 1
                    invoice_remaining_val = "< 0"
                    invoice_remaining_query = "< 0"
                Case 2
                    invoice_remaining_val = " = 0"
                    invoice_remaining_query = " = 0"
                Case 3
                    invoice_remaining_val = " in 1 to 3"
                    invoice_remaining_query = " between 1 and 3"
                Case 4
                    invoice_remaining_val = " in 4 to 5"
                    invoice_remaining_query = " between 4 and 5"
                Case 5
                    invoice_remaining_val = " in 6 to 7"
                    invoice_remaining_query = " between 6 and 7"
            End Select
        End If
    End Sub
   
    Private Sub cbLedgerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLedgerType.SelectedIndexChanged
        If cbLedgerType.SelectedIndex > 0 Then
            Select Case Trim(cbLedgerType.Text).ToLower
                Case "charge"
                    invoice_LedgerType = 0
                Case "delivery"
                    invoice_LedgerType = 1
                Case Else
                    invoice_LedgerType = -1
            End Select
        End If
    End Sub

  
    Private Sub cbCustomer2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer2.SelectedIndexChanged
        If cbCustomer2.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCustomer2.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer2.SelectedItem, KeyValuePair(Of String, String)).Value
            check_customer = CInt(key)
        End If
    End Sub

    Private Sub cbRemaining2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRemaining2.SelectedIndexChanged
        If (cbRemaining2.SelectedIndex > 0) Then
            Select Case cbRemaining2.SelectedIndex
                Case 1
                    check_remaining_val = "< 0"
                    check_remaining_query = "< 0"
                Case 2
                    check_remaining_val = " = 0"
                    check_remaining_query = " = 0"
                Case 3
                    check_remaining_val = " in 1 to 3"
                    check_remaining_query = " between 1 and 3"
                Case 4
                    check_remaining_val = " in 4 to 5"
                    check_remaining_query = " between 4 and 5"
                Case 5
                    check_remaining_val = " in 6 to 7"
                    check_remaining_query = " between 6 and 7"
            End Select
        End If
    End Sub

    Private Sub cbLedgerType2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLedgerType2.SelectedIndexChanged
        If cbLedgerType2.SelectedIndex > 0 Then
            Select Case Trim(cbLedgerType2.Text).ToLower
                Case "charge"
                    check_LedgerType = 0
                Case "delivery"
                    check_LedgerType = 1
                Case Else
                    check_LedgerType = -1
            End Select
        End If
    End Sub
End Class