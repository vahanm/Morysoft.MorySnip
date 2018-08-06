Public Class Form_History

    Private Sub Form_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

    Private Sub RefreshList()
        Me.ListView_History.Items.Clear()

        For Each id As String In SettingHistory
            Dim title As String = SettingHistoryTitle(id)

            Dim tmp As New ListViewItem(New Date(CLng(id.Substring(0, 18))).ToString(), 0)

            tmp.Tag = id
            tmp.SubItems.Add(title)

            Me.ListView_History.Items.Insert(0, tmp)
        Next
    End Sub

    Private Sub ListView_History_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView_History.SelectedIndexChanged
        Me.Button_Copy.Enabled = Me.ListView_History.SelectedItems.Count > 0
        Me.Button_Remove.Enabled = Me.ListView_History.SelectedItems.Count > 0

        Me.Button_ViewInBrowser.Enabled = Me.ListView_History.SelectedItems.Count = 1
    End Sub

    Private Sub Button_Remove_Click(sender As Object, e As EventArgs) Handles Button_Remove.Click
        For Each i As ListViewItem In Me.ListView_History.SelectedItems
            SettingHistoryRemove(i.Tag)
        Next
        RefreshList()
    End Sub

    Private Sub Button_Copy_Click(sender As Object, e As EventArgs) Handles Button_Copy.Click
        Do
            Try
                My.Computer.Clipboard.SetText(SelectedURLs())
                Exit Do
            Catch ex As Exception
                If MsgBox(ex.Message, MsgBoxStyle.RetryCancel Or MsgBoxStyle.Exclamation) = MsgBoxResult.Cancel Then
                    Exit Do
                End If
            End Try
        Loop
    End Sub

    Private Function SelectedURLs() As String
        Dim URLs As String = ""

        For Each i As ListViewItem In Me.ListView_History.SelectedItems
            If Not String.IsNullOrWhiteSpace(URLs) Then URLs &= vbCrLf
            URLs &= "http://share.cucak.am/" & i.Tag
        Next

        Return URLs
    End Function

    Private Sub Button_ViewInBrowser_Click(sender As Object, e As EventArgs) Handles Button_ViewInBrowser.Click
        ViewInBrowser()
    End Sub

    Private Sub ViewInBrowser()
        Shell("explorer """ & SelectedURLs() & """", AppWinStyle.NormalFocus)
    End Sub

    Private Sub ListView_History_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView_History.MouseDoubleClick
        If Me.ListView_History.SelectedItems.Count = 1 AndAlso e.Button = Windows.Forms.MouseButtons.Left AndAlso e.Clicks = 2 Then
            ViewInBrowser()
        End If
    End Sub
End Class
