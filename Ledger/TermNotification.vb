Public Class TermNotification
    Dim selectedID As Integer = 0
    Dim selectedPaymentType As Integer = -1
    Dim term As Integer = -1
    Dim remaining_val As String = ""

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

    Private Sub getMonth()
        cbMonth.Items.Clear()
        Dim formatInfo = System.Globalization.DateTimeFormatInfo.CurrentInfo
        cbMonth.Items.Add("All")
        For i As Integer = 1 To 12
            Dim monthName = formatInfo.GetMonthName(i)
            cbMonth.Items.Add(monthName)
        Next
        cbMonth.SelectedIndex = 0
    End Sub

    Private Sub getYear()
        cbYear.Items.Clear()
        cbYear.Items.Add("All")
        Dim db As New DatabaseCon
        With db
            .selectByQuery("SELECT distinct YEAR(date_issue) FROM ledger where status <> 0 order by YEAR(date_issue) DESC")
            While .dr.Read
                cbYear.Items.Add(.dr.GetValue(0))
            End While
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
            cbYear.SelectedIndex = 0
        End With
    End Sub


    Private Function monthToNumber(ByVal month As String) As String
        Dim result As String = ""
        Select Case month.ToUpper
            Case "JANUARY"
                result = "1"
            Case "FEBRUARY"
                result = "2"
            Case "MARCH"
                result = "3"
            Case "APRIL"
                result = "4"
            Case "MAY"
                result = "5"
            Case "JUNE"
                result = "6"
            Case "JULY"
                result = "7"
            Case "AUGUST"
                result = "8"
            Case "SEPTEMBER"
                result = "9"
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

    Private Sub loadRemaining()
        cbRemaining.Items.Clear()
        cbRemaining.Items.Add("All")
        cbRemaining.Items.Add("Over Due")
        cbRemaining.Items.Add("Due Date")
        cbRemaining.Items.Add("3 to 1 Days")
        cbRemaining.Items.Add("5 to 4 Days")
        cbRemaining.Items.Add("7 to 6 Days")
        cbRemaining.SelectedIndex = 0
    End Sub

    Private Sub cbRemaining_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRemaining.SelectedIndexChanged
        btnFilter.Enabled = True
        If (cbRemaining.SelectedIndex > 0) Then
            Select Case cbRemaining.SelectedIndex
                Case 1
                    remaining_val = "< 0"
                Case 2
                    remaining_val = " = 0"
                Case 3
                    remaining_val = "between 1 and 3"
                Case 4
                    remaining_val = "between 4 and 5"
                Case 5
                    remaining_val = "between 6 and 7"

            End Select
        End If

    End Sub

    Private Sub Notification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Invoke(Sub() autocompleteCustomer())
        Invoke(Sub() loadPaymentType())
        Invoke(Sub() loadTerm())
        Invoke(Sub() getMonth())
        Invoke(Sub() getYear())
        Invoke(Sub() loadRemaining())
        'If BackgroundWorker1.IsBusy = False Then
        '    BackgroundWorker1.RunWorkerAsync()
        'End If
        Invoke(Sub() loadLedger("SELECT TOP 300 * from ledger where status <> 0 and payment_type = 2 order by id desc"))

    End Sub

    Public Sub loadLedger(ByVal query As String)
        dgvLedger.Rows.Clear()
        Dim db1 As New DatabaseCon
        With db1
            If query = "" Then
                .selectByQuery("SELECT * from ledger where status <> 0 order by id desc")
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
            Dim rowindex As Integer = 0
            While .dr.Read
                Dim ID As Integer = CInt(.dr.GetValue(0))
                Dim counter_no As String = .dr.GetValue(1)
                Dim date_issue As String = .dr.GetValue(2)
                Dim invoice_no As String = .dr.GetValue(3)
                Dim amount As String = .dr.GetValue(4)
                Dim paid As Boolean = CBool(.dr.GetValue(5))
                'Dim date_paid As String = .dr.GetValue(6)
                Dim floating As Boolean = CBool(.dr.GetValue(7))
                Dim bank_details As String = .dr.GetValue(8)
                Dim check_date As String = .dr.GetValue(9)
                Dim status As Integer = CInt(.dr.GetValue(10))
                Dim status_val As String = ""
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
                    If db2.dr.Read Then
                        customer_val = db2.dr.GetValue(0)
                    End If
                    db2.cmd.Dispose()
                    db2.dr.Close()
                    db2.con.Close()
                End With

                Dim ledger_type As Integer = CInt(.dr.GetValue(12))
                Dim ledger_type_val As String = ""
                Select Case ledger_type
                    Case 0
                        ledger_type_val = "Charge"
                    Case 1
                        ledger_type_val = "Delivery"
                End Select

                Dim payment_type As Integer = CInt(.dr.GetValue(13))
                Dim payment_type_val As String = ""
                Select Case payment_type
                    Case 0
                        payment_type_val = "Cash"
                        bank_details = "N/A"
                        check_date = "N/A"
                        counter_no = "N/A"
                    Case 1
                        payment_type_val = "C.O.D"
                        counter_no = "N/A"
                    Case 2
                        payment_type_val = "Credit"
                        bank_details = "N/A"
                        check_date = "N/A"
                    Case 3
                        payment_type_val = "Post Dated"
                End Select

                Dim remaining_res As String = ""
                Dim remaining As Double = 0
                Dim dtp_due As New Date

                If Not IsDBNull(.dr.GetValue(16)) Then
                    dtp_due = .dr.GetValue(16)
                    remaining = Math.Floor(dtp_due.Subtract(DateTime.Now).TotalDays) + 1
                    If remaining < 0 Then
                        remaining_res = "Over Due"
                    ElseIf remaining = 0 Then
                        remaining_res = "Due Date"
                    Else
                        remaining_res = CStr(remaining) & " days"
                    End If
                End If

                Dim term_ As String
                If (.dr("payment_terms") = -1) Then
                    term_ = "C.O.D"
                Else
                    term_ = CStr(.dr("payment_terms")) & " Days"
                End If

                Dim row As String() = New String() {ID, remaining_res, date_issue, customer_val, invoice_no, ledger_type_val, FormatCurrency(amount).Replace("$", ""), paid, floating, payment_type_val, bank_details, check_date, counter_no, term_, status_val}
                dgvLedger.Invoke(Sub() dgvLedger.Rows.Add(row))

                Dim colCount As Integer = dgvLedger.Rows(rowindex).Cells.Count
                Select Case remaining
                    Case Is < 0
                        For i = 0 To colCount - 1
                            dgvLedger.Rows(rowindex).Cells(i).Style.BackColor = Color.Red
                            dgvLedger.Rows(rowindex).Cells(i).Style.ForeColor = Color.White
                        Next
                    Case 0
                        For i = 0 To colCount - 1
                            dgvLedger.Rows(rowindex).Cells(i).Style.BackColor = Color.Orange
                            dgvLedger.Rows(rowindex).Cells(i).Style.ForeColor = Color.White
                        Next
                    Case 1 To 3
                        For i = 0 To colCount - 1
                            dgvLedger.Rows(rowindex).Cells(i).Style.BackColor = Color.Yellow
                            dgvLedger.Rows(rowindex).Cells(i).Style.ForeColor = Color.Black
                        Next
                    Case 4 To 5
                        For i = 0 To colCount - 1
                            dgvLedger.Rows(rowindex).Cells(i).Style.BackColor = Color.Blue
                            dgvLedger.Rows(rowindex).Cells(i).Style.ForeColor = Color.White
                        Next
                    Case 6 To 7
                        For i = 0 To colCount - 1
                            dgvLedger.Rows(rowindex).Cells(i).Style.BackColor = Color.Green
                            dgvLedger.Rows(rowindex).Cells(i).Style.ForeColor = Color.White
                        Next
                End Select
                rowindex = rowindex + 1
            End While

            dgvLedger.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvLedger.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvLedger.Columns(1).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
            .cmd.Dispose()
            .dr.Close()
            .con.Close()

        End With

    End Sub


    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click


        btnFilter.Enabled = False
        Dim queryValidator As String = "SELECT * FROM ledger l inner join company c on c.id = l.customer  WHERE c.status <> 0 and l.payment_type = 2"


        If txtCustomer.Text.Length > 0 Then
            queryValidator = queryValidator & " and c.company = '" & txtCustomer.Text & "'"
        End If

        If cbPaymentType.Text <> "All" Then
            queryValidator = queryValidator & " and l.payment_type = " & selectedPaymentType
        End If


        If cbTerms.Text <> "All" Then
            queryValidator = queryValidator & " and l.payment_terms = " & term
        End If

        If cbMonth.Text <> "All" Then
            queryValidator = queryValidator & " and MONTH(l.date_issue) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            queryValidator = queryValidator & " and YEAR(l.date_issue) = " & cbYear.Text
        End If

        If cbRemaining.Text <> "All" Then
            queryValidator = queryValidator & " and DateDiff('d',NOW(),[l.payment_due_date]) " & remaining_val
        End If

        loadLedger(queryValidator)
    End Sub

    Private Sub cbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMonth.SelectedIndexChanged
        btnFilter.Enabled = True
    End Sub

    Private Sub cbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbYear.SelectedIndexChanged
        btnFilter.Enabled = True
    End Sub

    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged
        If txtCustomer.Text.Length > 0 Then
            btnFilter.Enabled = True

        End If
    End Sub

    Private Sub txtCustomer_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomer.KeyUp
        If txtCustomer.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            txtCustomer.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtCustomer.Text.ToLower())
        End If
    End Sub


    Private Sub dgvLedger_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLedger.CellContentClick
        If dgvLedger.SelectedRows.Count = 1 Then
            selectedID = CInt(dgvLedger.SelectedRows(0).Cells(0).Value)
        End If
    End Sub

    Private Sub dgvLedger_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvLedger.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dgvLedger.ClearSelection()
            dgvLedger.Rows(e.RowIndex).Selected = True
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Click
        If dgvLedger.SelectedRows.Count = 1 Then
            selectedID = CInt(dgvLedger.SelectedRows(0).Cells(0).Value)
            LedgerForm.btnSave.Text = "Update"
            LedgerForm.btnSaveAndPrint.Text = "Update and Print"
            LedgerForm.getCustomerList("")
            LedgerForm.loadPaymentType()
            LedgerForm.loadLedgerType()
            LedgerForm.loadTerm()
            LedgerList.loadToUpdateInfo(selectedID)
            LedgerForm.ShowDialog()
        Else
            MsgBox("Please select ledger!", MsgBoxStyle.Critical)
        End If
    End Sub

    Public Sub loadPaymentType()
        cbPaymentType.DataSource = Nothing
        cbPaymentType.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add(-1, "All")
        comboSource.Add(0, "Cash")
        comboSource.Add(1, "C.O.D")
        comboSource.Add(2, "Credit")
        comboSource.Add(3, "Post Dated")

        cbPaymentType.DataSource = New BindingSource(comboSource, Nothing)
        cbPaymentType.ValueMember = "Key"
        cbPaymentType.DisplayMember = "Value"

        cbPaymentType.SelectedIndex = 0
    End Sub

    Public Sub loadTerm()
        cbTerms.Items.Clear()
        cbTerms.Items.Add("All")
        cbTerms.Items.Add("C.O.D")
        cbTerms.Items.Add("10 Days")
        cbTerms.Items.Add("15 Days")
        cbTerms.Items.Add("30 Days")
        cbTerms.Items.Add("60 Days")
        cbTerms.Items.Add("90 Days")
        cbTerms.Items.Add("120 Days")
        cbTerms.SelectedIndex = 0
    End Sub

    Private Sub cbPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaymentType.SelectedIndexChanged
        If cbPaymentType.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPaymentType = key
        End If
        btnFilter.Enabled = True
    End Sub

    Private Sub cbTerms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTerms.SelectedIndexChanged
        Select Case cbTerms.Text
            Case "10 Days"
                term = 10
            Case "15 Days"
                term = 15
            Case "30 Days"
                term = 30
            Case "60 Days"
                term = 60
            Case "90 Days"
                term = 90
            Case "120 Days"
                term = 120
            Case "Select Term"
                term = 0
            Case "C.O.D"
                term = -1
                cbPaymentType.SelectedIndex = cbPaymentType.FindString("C.O.D")
        End Select
        If cbTerms.SelectedIndex > 0 Then
            cbTerms.BackColor = Color.White
        End If
        btnFilter.Enabled = True
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim path As String = Application.StartupPath & "\term.html"
        'Try
        Dim code As String = generatePrint()
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Critical)
            'End Try

            Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
    End Sub

    Private Function generatePrint()
        Dim query As String = "SELECT l.customer,MAX(c.company) as company, MAX(l.payment_due_date) as  payment_due_date,MAX(l.payment_terms) as payment_terms FROM ledger l inner join company c on c.id = l.customer  WHERE c.status <> 0 and l.payment_type = 2"


        If txtCustomer.Text.Length > 0 Then
            query = query & " and c.company = '" & txtCustomer.Text & "'"
        End If

        'If cbPaymentType.Text <> "All" Then
        '    query = query & " and l.payment_type = " & selectedPaymentType
        'End If


        If cbTerms.Text <> "All" Then
            query = query & " and l.payment_terms = " & term
        End If

        If cbMonth.Text <> "All" Then
            query = query & " and MONTH(l.date_issue) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            query = query & " and YEAR(l.date_issue) = " & cbYear.Text
        End If

        If cbRemaining.Text <> "All" Then
            query = query & " and DateDiff('d',NOW(),[l.payment_due_date]) " & remaining_val
        End If

        query = query & " group by l.customer order by MAX(c.company)"

        Dim result As String = ""
        Dim table_content As String = ""
        Dim dbprod As New DatabaseCon()
        With dbprod
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    'Dim counter_no As String = .dr("counter_no")
                    'Dim date_issue As String = .dr("date_issue")
                    'Dim invoice_no As String = .dr("invoice_no")
                    'Dim amount As String = .dr("amount")
                    'Dim paid As Boolean = CBool(.dr("paid"))
                    'Dim date_paid As String = .dr.GetValue(6)
                    'Dim floating As Boolean = CBool(.dr("floating"))
                    'Dim bank_details As String = .dr("bank_details")
                    'Dim check_date As String = .dr("check_date")
                    'Dim status As Integer = CInt(.dr("status"))
                    'Dim status_val As String = ""
                    'Select Case status
                    '    Case 1
                    '        status_val = "Active"
                    '    Case 2
                    '        status_val = "Inactive"
                    'End Select


                    Dim customer As String = .dr("company")


                    'Dim ledger_type As Integer = CInt(.dr("ledger"))
                    'Dim ledger_type_val As String = ""
                    'Select Case ledger_type
                    '    Case 0
                    '        ledger_type_val = "Charge"
                    '    Case 1
                    '        ledger_type_val = "Delivery"
                    'End Select

                    'Dim payment_type As Integer = CInt(.dr("payment_type"))
                    'Dim payment_type_val As String = ""
                    'Select Case payment_type
                    '    Case 0
                    '        payment_type_val = "Cash"
                    '        bank_details = "N/A"
                    '        check_date = "N/A"
                    '        counter_no = "N/A"
                    '    Case 1
                    '        payment_type_val = "C.O.D"
                    '        counter_no = "N/A"
                    '    Case 2
                    '        payment_type_val = "Credit"
                    '        bank_details = "N/A"
                    '        check_date = "N/A"
                    '    Case 3
                    '        payment_type_val = "Post Dated"
                    'End Select

                    Dim remaining_res As String = ""
                    Dim remaining As Double = 0
                    Dim dtp_due As New Date

                    If Not IsDBNull(.dr("payment_due_date")) Then
                        dtp_due = .dr("payment_due_date")
                        remaining = Math.Floor(dtp_due.Subtract(DateTime.Now).TotalDays) + 1
                        If remaining < 0 Then
                            remaining_res = "Over Due"
                        ElseIf remaining = 0 Then
                            remaining_res = "Due Date"
                        Else
                            remaining_res = CStr(remaining) & " days"
                        End If
                    End If

                    Dim term_ As String
                    If (.dr("payment_terms") = -1) Then
                        term_ = "C.O.D"
                    Else
                        term_ = CStr(.dr("payment_terms")) & " Days"
                    End If

                    tr = tr & "<td>" & customer & "</td>"
                    'tr = tr & "<td>" & ledger_type_val & "</td>"
                    tr = tr & "<td>" & term_ & "</td>"
                    'tr = tr & "<td>" & city & "</td>"
                    'tr = tr & "<td>" & owner & "</td>"
                    'tr = tr & "<td>" & contact1 & "</td>"
                    'tr = tr & "<td>" & contact2 & "</td>"
                    'tr = tr & "<td>" & faxtel & "</td>"
                    'tr = tr & "<td>" & tin & "</td>"
                    'tr = tr & "<td>" & email & "</td>"
                    'tr = tr & "<td>" & status & "</td>"
                    'tr = tr & "<td>" & ledger_type & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr

                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        result = "
<!DOCTYPE html>
<html>
<head>
<style>
table {
	font-family:serif;
	border-collapse: collapse;
	width: 100%;
    font-size:8pt;
}

td, th {
	border: 1px solid #dddddd;
	text-align: left;
	padding: 5px;
}

tr:nth-child(even) {

}
</style>
</head>
<body>

<h3><center>Customer & Terms</center></h3>

<table>
  <thead>
  <tr>
	<th width='40%'>Company</th>
	<th width='30%'>Terms</th>

  </tr>
  </thead>
  <tbody>
    " & table_content & "
  </tbody>
</table>

</body>
</html>

"
        Return result
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        CheckForIllegalCrossThreadCalls = False

        loadLedger("SELECT TOP 300 * from ledger where status <> 0 and payment_type = 2 order by id desc")
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub
End Class