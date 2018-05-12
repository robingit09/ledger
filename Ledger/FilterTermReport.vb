Public Class FilterTermReport

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim cr As New crTermReports
        ReportViewer.Enabled = True
        ReportViewer.CrystalReportViewer1.ReportSource = cr
        ReportViewer.CrystalReportViewer1.Refresh()
        ReportViewer.CrystalReportViewer1.RefreshReport()
        ReportViewer.ShowDialog()
    End Sub
End Class