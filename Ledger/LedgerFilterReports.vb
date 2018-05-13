Public Class LedgerFilterReports
    Public selectedCustomer As Integer = 0
    Public selectedModeOfPayment As Integer = -1
    Public selectedLedgerType As Integer = -1
    Private Sub LedgerFilterReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getCustomerList()
        getMonth()
        getYear()
        getPaymentMode()
        getLedgerType()
    End Sub

    Public Sub getCustomerList()
        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()
        Dim db As New DatabaseCon

        With db
            .selectByQuery("select distinct c.company,c.ID from company c inner join ledger l on l.customer = c.ID where l.status <> 0 order by c.company")
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

    Private Sub getLedgerType()
        cbLedgerType.DataSource = Nothing
        cbLedgerType.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()

        Dim db As New DatabaseCon
        With db
            comboSource.Add(-1, "All")
            .selectByQuery("SELECT distinct ledger from ledger where status <> 0 order by ledger")
            While .dr.Read
                Select Case .dr.GetValue(0)
                    Case 0
                        comboSource.Add(0, "Charge")
                    Case 1
                        comboSource.Add(1, "Delivery")
                End Select
            End While
        End With

        cbLedgerType.DataSource = New BindingSource(comboSource, Nothing)
        cbLedgerType.DisplayMember = "Value"
        cbLedgerType.ValueMember = "Key"

    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer.SelectedIndexChanged

        If cbCustomer.SelectedIndex >= 0 Then

            Dim key As String = CInt(DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key

        End If
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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '*****check if filter record exist******'
        Dim queryValidator As String = "select ID from ledger where status <> 0"
        If cbCustomer.Text <> "All" Then
            queryValidator = queryValidator & " and customer = " & selectedCustomer
        End If

        If cbMonth.Text <> "All" Then
            queryValidator = queryValidator & " and MONTH(date_issue) = " & monthToNumber(cbMonth.Text)
        End If

        If cbpayment_mode.Text <> "All" Then
            queryValidator = queryValidator & " and payment_type = " & selectedModeOfPayment
        End If

        If cbLedgerType.Text <> "All" Then
            queryValidator = queryValidator & " and ledger = " & selectedLedgerType
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


        If cbCustomer.Text <> "All" Then
            'print cash filter by customer
            If selectedModeOfPayment = 0 Then
                Dim crCash As New crCashLedgerCustomer
                crCash.RecordSelectionFormula = "{ledger.status} <> 0 AND {ledger.customer} = " & selectedCustomer

                ReportViewer.Enabled = True
                ReportViewer.CrystalReportViewer1.ReportSource = crCash
                ReportViewer.CrystalReportViewer1.Refresh()
                ReportViewer.CrystalReportViewer1.RefreshReport()
                ReportViewer.ShowDialog()
                Exit Sub
            End If

            Dim cr As New crLedgerByCustomer
            cr.RecordSelectionFormula = "{ledger.status} <> 0"

            Dim formula As String = ""
            Dim filters As New Dictionary(Of String, String)
            filters.Add("customer", cbCustomer.Text)
            filters.Add("month", cbMonth.Text)
            filters.Add("year", cbYear.Text)
            filters.Add("payment_type", cbpayment_mode.Text)
            filters.Add("ledger_type", cbLedgerType.Text)

            For Each k In filters.Keys
                Select Case k
                    Case "customer"
                        If cbCustomer.Text <> "All" Then
                            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.customer} = " & selectedCustomer

                        End If

                    Case "month"
                        If cbMonth.Text <> "All" Then
                            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND MONTH({ledger.date_issue}) = " & monthToNumber(cbMonth.Text)

                        End If
                    Case "year"
                        If cbYear.Text <> "All" Then
                            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND YEAR({ledger.date_issue}) = " & cbYear.Text

                        End If
                    Case "payment_type"
                        If cbpayment_mode.Text <> "All" Then
                            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.payment_type} = " & selectedModeOfPayment

                        End If

                    Case "ledger_type"
                        If cbLedgerType.Text <> "All" Then
                            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.ledger} = " & selectedLedgerType

                        End If

                End Select
            Next
 

            ReportViewer.Enabled = True
            ReportViewer.CrystalReportViewer1.ReportSource = cr
            ReportViewer.CrystalReportViewer1.Refresh()
            ReportViewer.CrystalReportViewer1.RefreshReport()
            ReportViewer.ShowDialog()
        Else

            'print cash
            If selectedModeOfPayment = 0 Then
                Dim crCash As New crCashLedger
                crCash.RecordSelectionFormula = "{ledger.status} <> 0"
                ReportViewer.Enabled = True
                ReportViewer.CrystalReportViewer1.ReportSource = crCash
                ReportViewer.CrystalReportViewer1.Refresh()
                ReportViewer.CrystalReportViewer1.RefreshReport()
                ReportViewer.ShowDialog()
                Exit Sub
            End If

            Dim cr As New crLedgerAllCustomer
            cr.RecordSelectionFormula = "{ledger.status} <> 0"

            Dim formula As String = ""
            Dim filters As New Dictionary(Of String, String)
            filters.Add("customer", cbCustomer.Text)
            filters.Add("month", cbMonth.Text)
            filters.Add("year", cbYear.Text)
            filters.Add("payment_type", cbpayment_mode.Text)
            filters.Add("ledger_type", cbLedgerType.Text)

            For Each k In filters.Keys
                Select Case k
                    Case "customer"
                        If cbCustomer.Text <> "All" Then
                            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.customer} = " & selectedCustomer

                        End If

                    Case "month"
                        If cbMonth.Text <> "All" Then
                            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND MONTH({ledger.date_issue}) = " & monthToNumber(cbMonth.Text)
                            queryValidator = queryValidator & " and MONTH(date_issue) = " & monthToNumber(cbMonth.Text)
                        End If
                    Case "year"
                        If cbYear.Text <> "All" Then
                            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND YEAR({ledger.date_issue}) = " & cbYear.Text

                        End If
                    Case "payment_type"
                        If cbpayment_mode.Text <> "All" Then
                            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.payment_type} = " & selectedModeOfPayment

                        End If

                    Case "ledger_type"
                        If cbLedgerType.Text <> "All" Then
                            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.ledger} = " & selectedLedgerType

                        End If

                End Select
            Next


            ReportViewer.Enabled = True
            ReportViewer.CrystalReportViewer1.ReportSource = cr
            ReportViewer.CrystalReportViewer1.Refresh()
            ReportViewer.CrystalReportViewer1.RefreshReport()
            ReportViewer.ShowDialog()
        End If

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

    Private Sub getYear()
        cbYear.Items.Clear()
        cbYear.Items.Add("All")
        Dim db As New DatabaseCon
        With db
            .selectByQuery("SELECT distinct YEAR(date_issue) FROM ledger where status <> 0 order by YEAR(date_issue) DESC")
            While .dr.Read
                cbYear.Items.Add(.dr.GetValue(0))
            End While
            cbYear.SelectedIndex = 0
        End With
    End Sub

    Private Sub cbpayment_mode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpayment_mode.SelectedIndexChanged
        If cbpayment_mode.SelectedIndex >= 0 Then
            Dim key As String = CInt(DirectCast(cbpayment_mode.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbpayment_mode.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedModeOfPayment = key
        End If
    End Sub

    Private Sub cbLedgerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLedgerType.SelectedIndexChanged
        If cbLedgerType.SelectedIndex >= 0 Then
            Dim key As String = CInt(DirectCast(cbLedgerType.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbLedgerType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedLedgerType = key
        End If
    End Sub
End Class