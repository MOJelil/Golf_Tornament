Public Class frmMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnGolfers_Click(sender As Object, e As EventArgs) Handles btnGolfers.Click
        frmManageGolfers.ShowDialog()
    End Sub

    Private Sub btnSponsor_Click(sender As Object, e As EventArgs) Handles btnSponsor.Click
        frmManageSponsor.ShowDialog()
    End Sub

    Private Sub btnGS_Click(sender As Object, e As EventArgs) Handles btnGS.Click
        frmStatistics.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
