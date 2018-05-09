Public Class TermNotification
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
        autocompleteCustomer()
        getMonth()
        getYear()
        loadRemaining()
        loadLedger("SELECT * from ledger where status <> 0 and payment_type = 2 order by id desc")
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

                Dim term_ As String = CStr(.dr.GetValue(17)) & " Days"
                Dim row As String() = New String() {ID, remaining_res, date_issue, customer_val, invoice_no, ledger_type_val, FormatCurrency(amount).Replace("$", ""), paid, floating, payment_type_val, bank_details, check_date, counter_no, term_, status_val}
                dgvLedger.Rows.Add(row)
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
        'Dim db As New DatabaseCon
        'db.selectByQuery("SELECT DateDiff('d',NOW(),[check_date]) from ledger where  status <> 0 and payment_type in (1,3)")
        'With db
        '    If .dr.Read Then
        '        MsgBox(.dr.GetValue(0))
        '    End If
        '    .cmd.Dispose()
        '    .dr.Close()
        '    .con.Close()
        'End With
        'Exit Sub

        btnFilter.Enabled = False
        Dim queryValidator As String = "SELECT * FROM ledger l inner join company c on c.id = l.customer  WHERE c.status <> 0 and l.payment_type = 2"
        Dim filters As New Dictionary(Of String, String)
        filters.Add("customer", txtCustomer.Text)
        filters.Add("month", cbMonth.Text)
        filters.Add("year", cbYear.Text)
        filters.Add("remaining", cbRemaining.Text)

        For Each k In filters.Keys
            Select Case k
                Case "customer"
                    If txtCustomer.Text.Length > 0 Then
                        queryValidator = queryValidator & " and c.company = '" & txtCustomer.Text & "'"
                    End If
                Case "month"
                    If cbMonth.Text <> "All" Then
                        queryValidator = queryValidator & " and MONTH(l.date_issue) = " & monthToNumber(cbMonth.Text)
                    End If
                Case "year"
                    If cbYear.Text <> "All" Then
                        queryValidator = queryValidator & " and YEAR(l.date_issue) = " & cbYear.Text
                    End If
                Case "remaining"
                    If cbRemaining.Text <> "All" Then
                        queryValidator = queryValidator & " and DateDiff('d',NOW(),[l.payment_due_date]) " & remaining_val
                    End If
            End Select
        Next
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
End Class