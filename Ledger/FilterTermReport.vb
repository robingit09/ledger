Public Class FilterTermReport

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim cr As New crTermReports
        cr.RecordSelectionFormula = "{ledger.status} <> 0 and {ledger.payment_type} = 2"

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
        getMonth()
        getYear()
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
End Class