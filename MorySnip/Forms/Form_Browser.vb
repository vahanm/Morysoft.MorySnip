Public Class Form_Browser

    Private Sub Button_Refresh_Click(sender As Object, e As EventArgs) Handles Button_Refresh.Click
        Me.WB.Refresh(WebBrowserRefreshOption.Completely)
    End Sub
End Class