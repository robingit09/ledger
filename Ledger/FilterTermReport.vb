Public Class FilterTermReport

    Private selectedCustomer As Integer = 0
    Dim remaining_val As String = ""
    Dim remaining_query As String = ""
    Private selectedLedgerType As Integer = -1

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '** beginning of check if filter record exist
        Dim queryValidator As String = "select ID from ledger where status <> 0 and payment_type = 2"

        If Trim(cbCustomer.Text) <> "All" Then
            queryValidator = queryValidator & " and customer = " & selectedCustomer
        End If

        If Trim(cbRemaining.Text) <> "All" Then
            queryValidator = queryValidator & " and DateDiff('d',NOW(),[payment_due_date]) " & remaining_query
        End If

        If Trim(cbLedgerType.Text) <> "All" Then
            queryValidator = queryValidator & " and ledger = " & selectedLedgerType
        End If

        If cbMonth.Text <> "All" Then
            queryValidator = queryValidator & " and MONTH(date_issue) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            queryValidator = queryValidator & " and YEAR(date_issue) = " & cbYear.Text
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

        Dim cr As New crTermReports
        cr.RecordSelectionFormula = "{ledger.status} <> 0 and {ledger.payment_type} = 2"

        If cbCustomer.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND ({ledger.customer}) = " & selectedCustomer
        End If

        If cbRemaining.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND datediff('d',CurrentDate,{ledger.payment_due_date}) " & remaining_val
        End If

        If cbLedgerType.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.ledger} = " & selectedLedgerType
        End If

        If cbMonth.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND MONTH({ledger.date_issue}) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND YEAR({ledger.date_issue}) = " & cbYear.Text
        End If

        ReportViewer.Enabled = True
        ReportViewer.CrystalReportViewer1.ReportSource = cr
        ReportViewer.CrystalReportViewer1.Refresh()
        ReportViewer.CrystalReportViewer1.RefreshReport()
        ReportViewer.ShowDialog()
    End Sub

    Private Sub FilterTermReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getCustomerList("")
        loadRemaining()
        loadledgertype()
        getMonth()
        getYear()
    End Sub

    Public Sub getCustomerList(ByVal query As String)

        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()
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
            cbYear.SelectedIndex = 0
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

    Private Sub cbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = CInt(key)
        End If
    End Sub

    Private Sub cbRemaining_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRemaining.SelectedIndexChanged
        If (cbRemaining.SelectedIndex > 0) Then
            Select Case cbRemaining.SelectedIndex
                Case 1
                    remaining_val = "< 0"
                    remaining_query = "< 0"
                Case 2
                    remaining_val = " = 0"
                    remaining_query = " = 0"
                Case 3
                    remaining_val = " in 1 to 3"
                    remaining_query = " between 1 and 3"
                Case 4
                    remaining_val = " in 4 to 5"
                    remaining_query = " between 4 and 5"
                Case 5
                    remaining_val = " in 6 to 7"
                    remaining_query = " between 6 and 7"
            End Select
        End If
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

    Private Sub cbLedgerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLedgerType.SelectedIndexChanged
        If cbLedgerType.SelectedIndex > 0 Then
            Select Case Trim(cbLedgerType.Text).ToLower
                Case "charge"
                    selectedLedgerType = 0
                Case "delivery"
                    selectedLedgerType = 1
                Case Else
                    selectedLedgerType = -1
            End Select
        End If
    End Sub

End Class