Public Class FilterCheckReports

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim cr As New crLedgerAllCustomer
        cr.RecordSelectionFormula = "{ledger.status} <> 0 and {ledger.payment_type} = 1 or {ledger.payment_type} = 3"
        ReportViewer.Enabled = True
        ReportViewer.CrystalReportViewer1.ReportSource = cr
        ReportViewer.CrystalReportViewer1.Refresh()
        ReportViewer.CrystalReportViewer1.RefreshReport()
        ReportViewer.ShowDialog()
    End Sub
End Class