Public Class LedgerSummary
    Public selectedCustomer As Integer = 0
    Public selectedLedgerType As Integer = 0
    Public transCount As Integer = 0
    Public selectedSalesType As Integer = 0
    Dim term As Integer = 0

    Dim remaining_val As String = ""


    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        btnPrint.Enabled = False
        btnPrint.Text = "Printing..."
        Dim path As String = Application.StartupPath & "\ledger_summary.html"
        Try
            Dim code As String = ""
            If rYear.Checked = True Then
                code = generatePrintYear()
            ElseIf rMonth.Checked = True Then
                code = generatePrintMonth()
            ElseIf gCustomer.Checked = True
                code = generatePrint()
            End If

            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrint.Text = "Print"
        btnPrint.Enabled = True
    End Sub

    Private Function generatePrint()

        'display variable
        Dim cash_display As String = ""
        Dim cod_display As String = ""
        Dim credit_display As String = ""
        Dim post_display As String = ""

        If ckCash.Checked = False Then
            cash_display = "display:none;"
        End If

        If ckCOD.Checked = False Then
            cod_display = "display:none;"
        End If

        If ckCredit.Checked = False Then
            credit_display = "display:none;"
        End If

        If ckPost.Checked = False Then
            post_display = "display:none;"
        End If

        Dim count_progress As Integer = 0
        Dim total_amount As Double = 0
        Dim cash_total As Double = 0
        Dim cod_total As Double = 0
        Dim credit_total As Double = 0
        Dim post_dated_total As Double = 0

        Dim label_header1 As String = ""
        Dim label_header2 As String = ""



        If selectedCustomer > 0 Then
            label_header1 = "Customer: " & getCustomerName(selectedCustomer)
        End If

        If fYes.Checked = True Then
            label_header2 = "Floating Ledger"
        End If

        Dim filter_query As String = ""
        Dim filter As String = ""

        If fYes.Checked = True Then
            filter_query = " and floating = true"
        ElseIf fNo.Checked = True Then
            filter_query = " and floating = false"
        End If

        If pYes.Checked = True Then
            filter_query = filter_query & " and paid = true"
        ElseIf pNo.Checked = True Then
            filter_query = filter_query & " and paid = false"
        End If

        If cbSalesType.Text <> "All" Then
            filter_query = filter_query & " and sales_type = " & selectedSalesType
        End If

        If cbTerms.Text <> "All" Then
            filter_query = filter_query & " and payment_terms = " & term
        End If

        If selectedCustomer > 0 Then
            filter = " And l.customer = " & selectedCustomer
        End If


        Dim query As String = "Select c.id,c.company
        from company as c
        where c.status <> 0"


        If selectedCustomer > 0 Then
            query = query & " and c.id = " & selectedCustomer
        End If


        query = query & " order by c.company"
        Dim result As String = ""
        Dim table_content As String = ""
        Dim dbprod As New DatabaseCon()
        With dbprod
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read

                    Dim tr As String = "<tr>"
                    Dim id As Integer = .dr("id")
                    Dim customer As String = .dr("company")

                    Dim cash As String = "0"
                    Dim cod As String = "0"
                    Dim credit As String = "0"
                    Dim post_dated As String = "0"

                    ' begin get cash
                    Dim dbcash As New DatabaseCon
                    With dbcash
                        .selectByQuery("select sum(amount) from ledger where status <> 0 and payment_type = 0 and customer = " & id & filter_query)
                        If .dr.Read Then
                            cash = If(IsDBNull(.dr.GetValue(0)), "0.00", Val(.dr.GetValue(0)).ToString("N2"))
                        End If
                        .dr.Close()
                        .con.Close()
                    End With
                    'end get cash

                    ' begin get cod
                    Dim dbcod As New DatabaseCon
                    With dbcod
                        .selectByQuery("select sum(amount) from ledger where status <> 0 and payment_type = 1 and customer = " & id & filter_query)
                        If .dr.Read Then
                            cod = If(IsDBNull(.dr.GetValue(0)), "0.00", Val(.dr.GetValue(0)).ToString("N2"))
                        End If
                        .dr.Close()
                        .con.Close()
                    End With
                    'end get cod

                    ' begin get credit
                    Dim dbcredit As New DatabaseCon
                    With dbcredit
                        .selectByQuery("select sum(amount) from ledger where status <> 0 and payment_type = 2 and customer = " & id & filter_query)
                        If .dr.Read Then
                            credit = If(IsDBNull(.dr.GetValue(0)), "0.00", Val(.dr.GetValue(0)).ToString("N2"))
                        End If
                        .dr.Close()
                        .con.Close()
                    End With
                    'end get credit

                    ' begin get post dated
                    Dim dbpostdated As New DatabaseCon
                    With dbpostdated
                        .selectByQuery("select sum(amount) from ledger where status <> 0 and payment_type = 3 and customer = " & id & filter_query)
                        If .dr.Read Then
                            post_dated = If(IsDBNull(.dr.GetValue(0)), "0.00", Val(.dr.GetValue(0)).ToString("N2"))
                        End If
                        .dr.Close()
                        .con.Close()
                    End With
                    'end get post datedt

                    ' check display before add to total
                    If cash_display <> "" Then
                        cash = 0
                    End If

                    If cod_display <> "" Then
                        cod = 0
                    End If

                    If credit_display <> "" Then
                        credit = 0
                    End If

                    If post_display <> "" Then
                        post_dated = 0
                    End If

                    cash_total += CDbl(cash.Replace(",", ""))
                    cod_total += CDbl(cod.Replace(",", ""))
                    credit_total += CDbl(credit.Replace(",", ""))
                    post_dated_total += CDbl(post_dated.Replace(",", ""))



                    Dim total As Double = CDbl(cash.Replace(",", "")) + CDbl(cod.Replace(",", "")) + CDbl(credit.Replace(",", "")) + CDbl(post_dated.Replace(",", ""))
                    total_amount += total

                    tr = tr & "<td>" & customer & "</td>"
                    tr = tr & "<td  style='color:red;" & cash_display & "'>" & cash & "</td>"
                    tr = tr & "<td  style='color:red;" & cod_display & "'>" & cod & "</td>"
                    tr = tr & "<td  style='color:red;" & credit_display & "'>" & credit & "</td>"
                    tr = tr & "<td  style='color:red;" & post_display & "'>" & post_dated & "</td>"
                    tr = tr & "<td  style='color:red;'>" & total.ToString("N2") & "</td>"

                    tr = tr & "</tr>"
                    table_content = table_content & tr

                End While


            Else
                MsgBox("No Record found!", MsgBoxStyle.Critical)
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
    <h3><center>Ledger Summary Reports</center></h3>
    <h4><center>" & label_header1 & "</center></h4>
    <h4><center>" & label_header2 & "</center></h4>
    <table>
      <thead>
      <tr>
    	<th>Customer</th>
        <th style='color:black;" & cash_display & "'>Cash</th>
        <th style='color:black;" & cod_display & "'>C.O.D</th>
        <th style='color:black;" & credit_display & "'>Credit</th>
        <th style='color:black;" & post_display & "'>Post Dated</th>
        <th>Total</th>

      </tr>
      </thead>
      <tbody>
        " & table_content & "
        <tr>
            <td colspan='1'><strong>Grand Total</strong></td>
            <td colspan='1' style='color:red;" & cash_display & "'><strong>" & Val(cash_total).ToString("N2") & "</strong></td>
            <td colspan='1' style='color:red;" & cod_display & "'><strong>" & Val(cod_total).ToString("N2") & "</strong></td>
            <td colspan='1' style='color:red;" & credit_display & "'><strong>" & Val(credit_total).ToString("N2") & "</strong></td>
            <td colspan='1' style='color:red;" & post_display & "'><strong>" & Val(post_dated_total).ToString("N2") & "</strong></td>
            <td colspan='1' style='color:red;'><strong>" & Val(total_amount).ToString("N2") & "</strong></td>
        </tr>
      </tbody>
    </table>
    </body>
    </html>
    "
        Return result
    End Function

    Private Function generatePrintMonth()

        'display variable
        Dim cash_display As String = ""
        Dim cod_display As String = ""
        Dim credit_display As String = ""
        Dim post_display As String = ""

        If ckCash.Checked = False Then
            cash_display = "display:none;"
        End If

        If ckCOD.Checked = False Then
            cod_display = "display:none;"
        End If

        If ckCredit.Checked = False Then
            credit_display = "display:none;"
        End If

        If ckPost.Checked = False Then
            post_display = "display:none;"
        End If


        Dim cash_total As Double = 0
        Dim cod_total As Double = 0
        Dim credit_total As Double = 0
        Dim post_total As Double = 0
        Dim total_amount As Double = 0

        Dim label_header1 As String = ""
        Dim label_header2 As String = ""

        If selectedCustomer > 0 Then
            label_header1 = "Customer: " & getCustomerName(selectedCustomer)
        End If

        If fYes.Checked = True Then
            label_header2 = "Floating Ledger"
        End If

        Dim filter_floating_query As String = ""
        If fYes.Checked = True Then
            filter_floating_query = " and floating = true"
        ElseIf fNo.Checked = True Then
            filter_floating_query = " and floating = false"
        End If

        If cbTerms.Text <> "All" Then
            filter_floating_query = filter_floating_query & " and payment_terms = " & term
        End If


        Dim query As String = "Select c.company,Format(l.date_issue,'yyyy-mm') as monthly from ledger as l 
                    inner join company as c on c.id = l.customer 
                    where l.status <> 0 and c.status <> 0"

        If selectedCustomer > 0 And cbCustomer.Text <> "All" Then
            query = query & " and c.id = " & selectedCustomer
        End If

        If cbTerms.Text <> "All" Then
            query = query & " and l.payment_terms = " & term
        End If

        query = query & " group by Format(l.date_issue,'yyyy-mm'),c.company order by c.company,Format(l.date_issue,'yyyy-mm')"
        Dim result As String = ""
        Dim table_content As String = ""
        Dim dbprod As New DatabaseCon
        With dbprod
            .selectByQuery(query)
            If .dr.HasRows Then
                Dim after_company As String = ""

                While .dr.Read

                    Dim cash_d As String = "0"
                    Dim cod_d As String = "0"
                    Dim credit_d As String = "0"
                    Dim post_d As String = "0"
                    Dim amount_d As String = "0"


                    Dim term_d As String = ""
                    Dim year_month() As String = .dr("monthly").ToString().Split("-")

                    Dim customer_id As Integer = 0
                    customer_id = New DatabaseCon().get_id("company", "company", Replace(.dr("company"), "'", "''"))

                    'get summary of total amount ***
                    ' get cash 
                    If cash_display = "" Then
                        Dim dbcash As New DatabaseCon
                        With dbcash
                            .selectByQuery("select sum(amount) as total_amount from ledger where status <> 0 and payment_type = 0 and customer = " & customer_id & " and YEAR(date_issue) = " & year_month(0) & " and MONTH(date_issue) = " & year_month(1) & filter_floating_query)
                            If .dr.Read Then
                                cash_d = If(IsDBNull(.dr("total_amount")), "0.00", Val(.dr("total_amount")).ToString("N2"))
                                cash_total += Val(cash_d.Replace(",", ""))
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    End If


                    ' get cod 
                    If cod_display = "" Then
                        Dim dbcod As New DatabaseCon
                        With dbcod
                            .selectByQuery("select sum(amount) as total_amount from ledger where status <> 0 and payment_type = 1 and customer = " & customer_id & " and YEAR(date_issue) = " & year_month(0) & " and MONTH(date_issue) = " & year_month(1) & filter_floating_query)
                            If .dr.Read Then
                                cod_d = If(IsDBNull(.dr("total_amount")), "0.00", Val(.dr("total_amount")).ToString("N2"))
                                cod_total += Val(cod_d.Replace(",", ""))
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    End If


                    ' get credit 
                    If credit_display = "" Then
                        Dim dbcredit As New DatabaseCon
                        With dbcredit
                            .selectByQuery("select sum(amount) as total_amount from ledger where status <> 0 and payment_type = 2 and customer = " & customer_id & " and YEAR(date_issue) = " & year_month(0) & " and MONTH(date_issue) = " & year_month(1) & filter_floating_query)
                            If .dr.Read Then
                                credit_d = If(IsDBNull(.dr("total_amount")), "0.00", Val(.dr("total_amount")).ToString("N2"))
                                credit_total += Val(credit_d.Replace(",", ""))
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    End If



                    ' get post dated 
                    If post_display = "" Then
                        Dim dbpostdated As New DatabaseCon
                        With dbpostdated
                            .selectByQuery("select sum(amount) as total_amount from ledger where status <> 0 and payment_type = 3 and customer = " & customer_id & " and YEAR(date_issue) = " & year_month(0) & " and MONTH(date_issue) = " & year_month(1) & filter_floating_query)
                            If .dr.Read Then
                                post_d = If(IsDBNull(.dr("total_amount")), "0.00", Val(.dr("total_amount")).ToString("N2"))
                                post_total += Val(post_d.Replace(",", ""))
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    End If


                    ' get total 
                    amount_d = CDbl(cash_d.Replace(",", "")) + CDbl(cod_d.Replace(",", "")) + CDbl(credit_d.Replace(",", "")) + CDbl(post_d.Replace(",", ""))
                    total_amount += CDbl(amount_d)
                    'Dim dbamount As New DatabaseCon
                    'With dbamount
                    '    .selectByQuery("select sum(amount) as total_amount from ledger where status <> 0 and customer = " & customer_id & " and YEAR(date_issue) = " & year_month(0) & " and MONTH(date_issue) = " & year_month(1) & filter_floating_query)
                    '    If .dr.HasRows Then
                    '        If .dr.Read Then
                    '            amount_d = If(IsDBNull(.dr("total_amount")), "0.00", Val(.dr("total_amount")).ToString("N2"))
                    '            total_amount += Val(amount_d.Replace(",", ""))
                    '        End If
                    '    End If
                    '    .cmd.Dispose()
                    '    .dr.Close()
                    '    .con.Close()
                    'End With
                    'end get summary of total amount ***

                    'Dim dbterm As New DatabaseCon
                    'With dbterm
                    '    .selectByQuery("select payment_terms from ledger where status <> 0 and payment_type = 2 and customer = " & customer_id & " and MONTH(date_issue) = " & month_year(0))
                    '    If .dr.HasRows Then
                    '        If .dr.Read Then
                    '            term_d = .dr("payment_terms")
                    '        End If
                    '    End If
                    '    .cmd.Dispose()
                    '    .dr.Close()
                    '    .con.Close()
                    'End With


                    Dim color_remaining As String = ""
                    Dim tr As String = "<tr>"
                    Dim id As Integer = 0
                    Dim customer As String = .dr("company")

                    If (.dr("company") = after_company) Then
                        customer = ""
                    Else
                        customer = .dr("company")
                    End If
                    'Dim remaining As String = .dr("r")
                    Dim monthly As String = monthNumberToString(year_month(1)) & " " & year_month(0)
                    'Dim invoice_no As String = .dr("invoice_no")
                    Dim amount As String = Val(amount_d).ToString("N2")
                    'Dim counter_no As String = .dr("counter_no")
                    'Dim terms As String = term_d & " Days"
                    'Dim due_date As String = .dr("payment_due_date")
                    'Dim ledger_type As String = .dr("ledger_type")


                    'Dim edate = due_date
                    'Dim pdate As DateTime = Convert.ToDateTime(edate)
                    'edate = pdate.ToString("MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture)


                    'remaining = pdate.Subtract(DateTime.Now).Days
                    'Dim remaining_val As String = remaining
                    'If CInt(remaining) < 0 Then
                    '    remaining_val = "Over Due"
                    '    color_remaining = "style='color:red;'"
                    'End If
                    'If CInt(remaining) = 0 Then
                    '    remaining_val = "Due Date"
                    '    color_remaining = "style='color:red;'"
                    'End If

                    'Select Case ledger_type
                    '    Case "0"
                    '        ledger_type = "Charge"
                    '    Case "1"
                    '        ledger_type = "Delivery"
                    '    Case Else
                    '        ledger_type = ""
                    'End Select

                    tr = tr & "<td><strong>" & customer & "</strong></td>"
                    tr = tr & "<td>" & monthly & "</td>"
                    tr = tr & "<td style='color:red;" & cash_display & "'>" & cash_d & "</td>"
                    tr = tr & "<td style='color:red;" & cod_display & "'>" & cod_d & "</td>"
                    tr = tr & "<td style='color:red;" & credit_display & " '>" & credit_d & "</td>"
                    tr = tr & "<td style='color:red;" & post_display & "'>" & post_d & "</td>"
                    tr = tr & "<td style='color:red;'>" & amount & "</td>"
                    'tr = tr & "<td>" & terms & "</td>"
                    'tr = tr & "<td>" & ledger_type & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr

                    after_company = .dr("company")
                End While
            Else
                MsgBox("No Record found!", MsgBoxStyle.Critical)
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
    <h3><center>Ledger Summary Reports</center></h3>
     <h4><center>" & label_header1 & "</center></h4>
     <h4><center>" & label_header2 & "</center></h4>
    <table>
      <thead>
      <tr>
    	<th>Customer</th>
        <th>Month</th>
	    <th style='color:black;" & cash_display & "'>Cash</th>
    	<th style='color:black;" & cod_display & "'>C.O.D</th>
    	<th style='color:black;" & credit_display & "'>Credit</th>
  	    <th style='color:black;" & post_display & "'>Post Dated</th>
        <th>TOTAL</th>
      </tr>
      </thead>
      <tbody>
        " & table_content & "
        <tr>
            <td colspan='2'><strong>GRAND TOTAL</strong></td>
            <td style='color:red;" & cash_display & "'><strong>" & Val(cash_total).ToString("N2") & "</strong></td>
            <td style='color:red;" & cod_display & "'><strong>" & Val(cod_total).ToString("N2") & "</strong></td>
            <td style='color:red;" & credit_display & "'><strong>" & Val(credit_total).ToString("N2") & "</strong></td>
            <td style='color:red;" & post_display & "'><strong>" & Val(post_total).ToString("N2") & "</strong></td>
            <td style='color:red;''><strong>" & Val(total_amount).ToString("N2") & "</strong></td>
        </tr>
      </tbody>
    </table>
    </body>
    </html>
    "
        Return result
    End Function

    Private Function generatePrintYear()

        'display variable
        Dim cash_display As String = ""
        Dim cod_display As String = ""
        Dim credit_display As String = ""
        Dim post_display As String = ""

        If ckCash.Checked = False Then
            cash_display = "display:none;"
        End If

        If ckCOD.Checked = False Then
            cod_display = "display:none;"
        End If

        If ckCredit.Checked = False Then
            credit_display = "display:none;"
        End If

        If ckPost.Checked = False Then
            post_display = "display:none;"
        End If


        Dim cash_total As Double = 0
        Dim cod_total As Double = 0
        Dim credit_total As Double = 0
        Dim post_total As Double = 0
        Dim total_amount As Double = 0

        Dim label_header1 As String = ""
        Dim label_header2 As String = ""

        If selectedCustomer > 0 Then
            label_header1 = "Customer: " & getCustomerName(selectedCustomer)
        End If

        If fYes.Checked = True Then
            label_header2 = "Floating Ledger"
        End If

        Dim filter_floating_query As String = ""
        If fYes.Checked = True Then
            filter_floating_query = " and floating = true"
        ElseIf fNo.Checked = True Then
            filter_floating_query = " and floating = false"
        End If

        If cbTerms.Text <> "All" Then
            filter_floating_query = filter_floating_query & " and payment_terms = " & term
        End If



        Dim query As String = "Select c.company,Format(l.date_issue,'yyyy') as yearly from ledger as l 
                    inner join company as c on c.id = l.customer 
                    where l.status <> 0 and c.status <> 0"

        If selectedCustomer > 0 And cbCustomer.Text <> "All" Then
            query = query & " and c.id = " & selectedCustomer
        End If

        If cbTerms.Text <> "All" Then
            query = query & " and l.payment_terms = " & term
        End If

        query = query & " group by Format(l.date_issue,'yyyy'),c.company order by c.company,Format(l.date_issue,'yyyy')"
        Dim result As String = ""
        Dim table_content As String = ""
        Dim dbprod As New DatabaseCon
        With dbprod
            .selectByQuery(query)
            If .dr.HasRows Then
                Dim after_company As String = ""

                While .dr.Read

                    Dim cash_d As String = "0"
                    Dim cod_d As String = "0"
                    Dim credit_d As String = "0"
                    Dim post_d As String = "0"
                    Dim amount_d As String = "0"


                    Dim term_d As String = ""
                    Dim year As String = .dr("yearly").ToString()

                    Dim customer_id As Integer = 0
                    customer_id = New DatabaseCon().get_id("company", "company", Replace(.dr("company"), "'", "''"))

                    'get summary of total amount ***
                    ' get cash 
                    If cash_display = "" Then
                        Dim dbcash As New DatabaseCon
                        With dbcash
                            .selectByQuery("select sum(amount) as total_amount from ledger where status <> 0 and payment_type = 0 and customer = " & customer_id & " and YEAR(date_issue) = " & year & " " & filter_floating_query)
                            If .dr.Read Then
                                cash_d = If(IsDBNull(.dr("total_amount")), "0.00", Val(.dr("total_amount")).ToString("N2"))
                                cash_total += Val(cash_d.Replace(",", ""))
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    End If


                    ' get cod 
                    If cod_display = "" Then
                        Dim dbcod As New DatabaseCon
                        With dbcod
                            .selectByQuery("select sum(amount) as total_amount from ledger where status <> 0 and payment_type = 1 and customer = " & customer_id & " and YEAR(date_issue) = " & year & " " & filter_floating_query)
                            If .dr.Read Then
                                cod_d = If(IsDBNull(.dr("total_amount")), "0.00", Val(.dr("total_amount")).ToString("N2"))
                                cod_total += Val(cod_d.Replace(",", ""))
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    End If


                    ' get credit 
                    If credit_display = "" Then
                        Dim dbcredit As New DatabaseCon
                        With dbcredit
                            .selectByQuery("select sum(amount) as total_amount from ledger where status <> 0 and payment_type = 2 and customer = " & customer_id & " and YEAR(date_issue) = " & year & " " & filter_floating_query)
                            If .dr.Read Then
                                credit_d = If(IsDBNull(.dr("total_amount")), "0.00", Val(.dr("total_amount")).ToString("N2"))
                                credit_total += Val(credit_d.Replace(",", ""))
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    End If



                    ' get post dated 
                    If post_display = "" Then
                        Dim dbpostdated As New DatabaseCon
                        With dbpostdated
                            .selectByQuery("select sum(amount) as total_amount from ledger where status <> 0 and payment_type = 3 and customer = " & customer_id & " and YEAR(date_issue) = " & year & " " & filter_floating_query)
                            If .dr.Read Then
                                post_d = If(IsDBNull(.dr("total_amount")), "0.00", Val(.dr("total_amount")).ToString("N2"))
                                post_total += Val(post_d.Replace(",", ""))
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    End If


                    ' get total 
                    amount_d = CDbl(cash_d.Replace(",", "")) + CDbl(cod_d.Replace(",", "")) + CDbl(credit_d.Replace(",", "")) + CDbl(post_d.Replace(",", ""))
                    total_amount += CDbl(amount_d)
                    'Dim dbamount As New DatabaseCon
                    'With dbamount
                    '    .selectByQuery("select sum(amount) as total_amount from ledger where status <> 0 and customer = " & customer_id & " and YEAR(date_issue) = " & year_month(0) & " and MONTH(date_issue) = " & year_month(1) & filter_floating_query)
                    '    If .dr.HasRows Then
                    '        If .dr.Read Then
                    '            amount_d = If(IsDBNull(.dr("total_amount")), "0.00", Val(.dr("total_amount")).ToString("N2"))
                    '            total_amount += Val(amount_d.Replace(",", ""))
                    '        End If
                    '    End If
                    '    .cmd.Dispose()
                    '    .dr.Close()
                    '    .con.Close()
                    'End With
                    'end get summary of total amount ***

                    'Dim dbterm As New DatabaseCon
                    'With dbterm
                    '    .selectByQuery("select payment_terms from ledger where status <> 0 and payment_type = 2 and customer = " & customer_id & " and MONTH(date_issue) = " & month_year(0))
                    '    If .dr.HasRows Then
                    '        If .dr.Read Then
                    '            term_d = .dr("payment_terms")
                    '        End If
                    '    End If
                    '    .cmd.Dispose()
                    '    .dr.Close()
                    '    .con.Close()
                    'End With


                    Dim color_remaining As String = ""
                    Dim tr As String = "<tr>"
                    Dim id As Integer = 0
                    Dim customer As String = .dr("company")

                    If (.dr("company") = after_company) Then
                        customer = ""
                    Else
                        customer = .dr("company")
                    End If

                    Dim yearly As String = year

                    Dim amount As String = Val(amount_d).ToString("N2")


                    tr = tr & "<td><strong>" & customer & "</strong></td>"
                    tr = tr & "<td>" & yearly & "</td>"
                    tr = tr & "<td style='color:red;" & cash_display & "'>" & cash_d & "</td>"
                    tr = tr & "<td style='color:red;" & cod_display & "'>" & cod_d & "</td>"
                    tr = tr & "<td style='color:red;" & credit_display & " '>" & credit_d & "</td>"
                    tr = tr & "<td style='color:red;" & post_display & "'>" & post_d & "</td>"
                    tr = tr & "<td style='color:red;'>" & amount & "</td>"
                    'tr = tr & "<td>" & terms & "</td>"
                    'tr = tr & "<td>" & ledger_type & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr

                    after_company = .dr("company")
                End While
            Else
                MsgBox("No Record found!", MsgBoxStyle.Critical)
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
    <h3><center>Ledger Summary Reports</center></h3>
     <h4><center>" & label_header1 & "</center></h4>
     <h4><center>" & label_header2 & "</center></h4>
    <table>
      <thead>
      <tr>
    	<th>Customer</th>
        <th>YEAR</th>
	    <th style='color:black;" & cash_display & "'>Cash</th>
    	<th style='color:black;" & cod_display & "'>C.O.D</th>
    	<th style='color:black;" & credit_display & "'>Credit</th>
  	    <th style='color:black;" & post_display & "'>Post Dated</th>
        <th>TOTAL</th>
      </tr>
      </thead>
      <tbody>
        " & table_content & "
        <tr>
            <td colspan='2'><strong>GRAND TOTAL</strong></td>
            <td style='color:red;" & cash_display & "'><strong>" & Val(cash_total).ToString("N2") & "</strong></td>
            <td style='color:red;" & cod_display & "'><strong>" & Val(cod_total).ToString("N2") & "</strong></td>
            <td style='color:red;" & credit_display & "'><strong>" & Val(credit_total).ToString("N2") & "</strong></td>
            <td style='color:red;" & post_display & "'><strong>" & Val(post_total).ToString("N2") & "</strong></td>
            <td style='color:red;''><strong>" & Val(total_amount).ToString("N2") & "</strong></td>
        </tr>
      </tbody>
    </table>
    </body>
    </html>
    "
        Return result
    End Function

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
            comboSource.Add(0, "All")
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

    Private Sub LedgerSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCustomerList("")
        getSalesType()
        loadTerm()
        fYes.Checked = True
        pYes.Checked = True
        gCustomer.Checked = True

    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            cbCustomer.BackColor = Color.White
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key
            txtTransCount.Text = getTransCount(selectedCustomer)
            'MsgBox(selectedCustomer)

            Dim dbledger As New DatabaseCon
            With dbledger
                .selectByQuery("select top 1 ledger from ledger where customer = " & selectedCustomer & " order by created_at desc")
                If .dr.HasRows Then
                    If .dr.Read Then

                        selectedLedgerType = If(IsDBNull(.dr("ledger")), 0, .dr("ledger"))

                        Select Case selectedLedgerType
                            Case 0
                                'cbLedgerType.SelectedIndex = cbLedgerType.FindString("Charge")
                                txtLedgerType.Text = "Charge"

                            Case 1
                                'cbLedgerType.SelectedIndex = cbLedgerType.FindString("Delivery")
                                txtLedgerType.Text = "Delivery"
                        End Select
                    End If
                Else

                    .dr.Close()
                    .selectByQuery("Select ledger_type from company where id = " & selectedCustomer)

                    If .dr.HasRows Then
                        If .dr.Read Then
                            selectedLedgerType = If(IsDBNull(.dr("ledger_type")), 0, .dr("ledger_type"))

                            Select Case selectedLedgerType
                                Case 0
                                    'cbLedgerType.SelectedIndex = cbLedgerType.FindString("Charge")
                                    txtLedgerType.Text = "Charge"

                                Case 1
                                    'cbLedgerType.SelectedIndex = cbLedgerType.FindString("Delivery")
                                    txtLedgerType.Text = "Delivery"
                            End Select
                        End If
                    End If
                End If
                .con.Close()
                .dr.Close()
                .cmd.Dispose()
            End With

        Else
            selectedCustomer = 0
            selectedLedgerType = -1
            txtLedgerType.Text = ""
            txtTransCount.Text = ""
            'cbLedgerType.SelectedIndex = 0
        End If
        'MsgBox(selectedCustomer)
    End Sub

    Private Function getTransCount(ByVal c As Integer) As Integer
        Dim result As Integer = 0
        Dim dbtcount As New DatabaseCon
        With dbtcount
            .selectByQuery("SELECT COUNT(id) FROM Ledger where status = 1 and customer = " & c)
            If .dr.Read Then
                result = CInt(.dr.GetValue(0))
            End If
            .dr.Close()
            .con.Close()
        End With

        Return result
    End Function

    Private Function getCustomerName(ByVal c As Integer) As String
        Dim result As String = ""

        Dim dbgetcustomer As New DatabaseCon
        With dbgetcustomer
            .selectByQuery("Select company from company where id = " & c)
            If .dr.Read Then
                result = .dr.GetValue(0)
            End If
            .dr.Close()
            .con.Close()
        End With

        Return result
    End Function

    Private Function monthNumberToString(ByVal x As String)
        Dim result As String = ""
        Select Case x
            Case "01"
                result = "January"
            Case "02"
                result = "February"
            Case "03"
                result = "March"
            Case "04"
                result = "April"
            Case "05"
                result = "May"
            Case "06"
                result = "June"
            Case "07"
                result = "July"
            Case "08"
                result = "August"
            Case "09"
                result = "September"
            Case "10"
                result = "October"
            Case "11"
                result = "November"
            Case "12"
                result = "December"
            Case Else
                result = ""
        End Select
        Return result
    End Function


    Private Sub getSalesType()
        cbSalesType.DataSource = Nothing
        cbSalesType.Items.Clear()

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
        comboSource.Add(0, "All")
        comboSource.Add(1, "Retail")
        comboSource.Add(2, "Wholesale")

        cbSalesType.DataSource = New BindingSource(comboSource, Nothing)
        cbSalesType.DisplayMember = "Value"
        cbSalesType.ValueMember = "Key"

    End Sub

    Private Sub cbSalesType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSalesType.SelectedIndexChanged
        If cbSalesType.SelectedIndex >= 0 Then
            Dim key As String = CInt(DirectCast(cbSalesType.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbSalesType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedSalesType = key

        End If
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
                'cbPaymentType.SelectedIndex = cbPaymentType.FindString("C.O.D")
        End Select
        If cbTerms.SelectedIndex > 0 Then
            cbTerms.BackColor = Color.White
        End If
    End Sub
End Class