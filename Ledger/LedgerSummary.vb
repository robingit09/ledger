Public Class LedgerSummary
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        btnPrint.Text = "Printing..."
        Dim path As String = Application.StartupPath & "\ledger_summary.html"
        Try
            Dim code As String = ""
            'Select Case cbpayment_mode.Text
            '    Case "Cash"
            '        code = generatePrintCash()
            '    Case "Credit"
            '        code = generatePrintCredit()
            '    Case Else
            '        code = generatePrint()
            'End Select
            code = generatePrint()


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
        Dim total_amount As Double = 0
        Dim query As String = "Select distinct c.id,c.company,
        (select sum(amount) from ledger where customer = c.id and payment_type = 0) as cash, 
          (select sum(amount) from ledger where customer = c.id and payment_type = 1) as cod,
          (select sum(amount) from ledger where customer = c.id and payment_type = 2) as credit 
        from ledger as l 
        INNER JOIN company as c on c.id = l.customer"


        query = query & " order by c.company "
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
                    Dim cash As String = If(IsDBNull(.dr("cash")), "0.00", Val(.dr("cash")).ToString("N2"))
                    Dim cod As String = If(IsDBNull(.dr("cod")), "0.00", Val(.dr("cod")).ToString("N2"))
                    Dim credit As String = If(IsDBNull(.dr("credit")), "0.00", Val(.dr("credit")).ToString("N2"))

                    total_amount += CDbl(cash) + CDbl(cod) + CDbl(credit)

                    tr = tr & "<td>" & customer & "</td>"
                    tr = tr & "<td  style='color:red;'>" & cash & "</td>"
                    tr = tr & "<td  style='color:red;'>" & cod & "</td>"
                    tr = tr & "<td  style='color:red;'>" & credit & "</td>"

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
    <table>
      <thead>
      <tr>
    	<th>Customer</th>
        <th>Cash</th>
        <th>C.O.D</th>
        <th>Credit</th>

      </tr>
      </thead>
      <tbody>
        " & table_content & "
        <tr>
            <td colspan='1'><strong>Grand Total</strong></td><td colspan='3' style='color:red;''><strong>" & Val(total_amount).ToString("N2") & "</strong></td>
        </tr>
      </tbody>
    </table>
    </body>
    </html>
    "
        Return result
    End Function
End Class