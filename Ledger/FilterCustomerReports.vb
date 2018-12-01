Public Class FilterCustomerReports

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim cr As New crCustomerReports
        'cr.RecordSelectionFormula = "{company.status} <> 0"
        'ReportViewer.Enabled = True
        'ReportViewer.CrystalReportViewer1.ReportSource = cr
        'ReportViewer.CrystalReportViewer1.Refresh()
        'ReportViewer.CrystalReportViewer1.RefreshReport()
        'ReportViewer.ShowDialog()

        Dim path As String = Application.StartupPath & "\customer.html"
        Try
            Dim code As String = generatePrint()
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
    End Sub

    Private Function generatePrint()
        Dim query As String = "Select * from company where status <> 0"

        If cbLocation.Text <> "All" Then
            query = query & " and city = '" & cbLocation.Text.Trim & "'"

        End If

        query = query & " order by company"
        Dim result As String = ""
        Dim table_content As String = ""
        Dim dbprod As New DatabaseCon()
        With dbprod
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    Dim id As Integer = .dr("id")
                    Dim company As String = .dr("company")
                    Dim contact_person As String = .dr("contact_person")
                    Dim address As String = .dr("address")
                    Dim city As String = .dr("city")
                    Dim owner As String = .dr("owner_name")
                    Dim contact1 As String = .dr("contact_number1")
                    Dim contact2 As String = .dr("contact_number2")
                    Dim faxtel As String = .dr("fax_tel")
                    Dim tin As String = .dr("tin")
                    Dim email As String = .dr("email")
                    Dim status As String = .dr("status")
                    Dim ledger_type As String = ""

                    Select Case status
                        Case "0"
                            status = ""
                        Case "1"
                            status = "Rented"
                        Case "2"
                            status = "Owned"
                    End Select
                    Dim dbledger As New DatabaseCon
                    With dbledger
                        .selectByQuery("select top 1 ledger from ledger where customer = " & id & " order by created_at desc")
                        If .dr.HasRows Then
                            If .dr.Read Then
                                ledger_type = .dr("ledger")
                            End If
                        End If
                        .con.Close()
                        .dr.Close()
                        .cmd.Dispose()
                    End With

                    Select Case ledger_type
                        Case "0"
                            ledger_type = "Charge"
                        Case "1"
                            ledger_type = "Delivery"
                    End Select

                    tr = tr & "<td>" & company & "</td>"
                    tr = tr & "<td>" & contact_person & "</td>"
                    tr = tr & "<td>" & address & "</td>"
                    tr = tr & "<td>" & city & "</td>"
                    tr = tr & "<td>" & owner & "</td>"
                    tr = tr & "<td>" & contact1 & "</td>"
                    tr = tr & "<td>" & contact2 & "</td>"
                    tr = tr & "<td>" & faxtel & "</td>"
                    tr = tr & "<td>" & tin & "</td>"
                    tr = tr & "<td>" & email & "</td>"
                    tr = tr & "<td>" & status & "</td>"
                    tr = tr & "<td>" & ledger_type & "</td>"
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

<h3><center>Customer List</center></h3>

<table>
  <thead>
  <tr>
	<th width='12%'>Company</th>
	<th width='7%'>Contact Person</th>
	<th width='15%'>Address</th>
	<th width='8%'>City</th>
	<th width='7%'>Owner</th>
	<th width='8%'>Contact #1</th>
	<th width='8%'>Contact #2</th>
	<th width='8%'>Fax/Tel</th>
	<th width='8%'>TIN</th>
	<th width='8%'>Email</th>
	<th width='5%'>Status</th>
	<th width='8%'>Ledger Type</th>
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

    Private Sub FilterCustomerReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadLocation("")
    End Sub

    Private Function loadLocation(ByVal query As String)
        cbLocation.DataSource = Nothing
        cbLocation.Items.Clear()
        Dim db As New DatabaseCon
        Dim i As Integer = 1
        With db
            If query = "" Then
                .selectByQuery("select distinct city from company where status <> 0 and city <> '' order by city")
            Else

            End If

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "All")
            While db.dr.Read
                Dim city As String = db.dr.GetValue(0)
                comboSource.Add(i, city.Trim)
                i = i + 1
            End While

            cbLocation.DataSource = New BindingSource(comboSource, Nothing)
            cbLocation.DisplayMember = "Value"
            cbLocation.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Return ""
    End Function
End Class