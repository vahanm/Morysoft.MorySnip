Public Class Form_Save_Album
    Enum ShareModes
        None = 0
        SendToFacebook = 2 ^ 0 '1
        SendToOdnoklassniki = 2 ^ 1 '2

        SendToEmail = 2 ^ 16
    End Enum

    Private Sub PreviewImages()
        Dim Index As Integer = 0
        For Each Screenshot As Screenshot In Images
            If Index = Me.ListView_Images.Items.Count Then
                Me.ImageList_Thumbs.Images.Add(Screenshot.GetThumbnailImage())

                Dim ListViewItem As New ListViewItem(Index + 1)

                ListViewItem.ImageIndex = Me.ImageList_Thumbs.Images.Count - 1

                Me.ListView_Images.Items.Add(ListViewItem)
            Else
                Dim tp As ListViewItem = Me.ListView_Images.Items(Index)
                Me.ImageList_Thumbs.Images(Index) = Screenshot.GetThumbnailImage()
            End If

            Index += 1
        Next

        Me.ListView_Images.SelectedIndices.Clear()

        For i As Integer = Me.ListView_Images.Items.Count - 1 To Index Step -1
            Me.ListView_Images.Items.RemoveAt(i)
            Me.ImageList_Thumbs.Images.RemoveAt(i)
        Next

        Me.Button_Edit.Enabled = Images.Count > 0
        Me.Button_Remove.Enabled = Images.Count > 0

        Me.Button_SendToWeb.Enabled = Images.Count > 0
        Me.Button_Share_Facebook.Enabled = Images.Count > 0
    End Sub

    Private Sub EditSelectedImage()
        If Me.ListView_Images.SelectedIndices.Count = 1 Then
            Dim Index As Integer = ListView_Images.SelectedIndices(0)
            If MyBase.Edit_OpenInEditor(Index) Then
                PreviewImages()
            End If
        End If
    End Sub

    Private Sub Form_Save_Album_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ComboBox_Quality.SelectedIndex = Settings.ShareQuality
        Me.CheckBox_CopyPath.Checked = Settings.CopyPath
        Me.CheckBox_OpenFolder.Checked = Settings.OpenFolder

        PreviewImages()

        'TODO: Remove to enable AutoUpdate
        'AutoUpdaterDotNET.AutoUpdater.Start("http://share.cucak.am/downloads/snipping-tool/version.xml.php")

        'Button_SendToWeb.Enabled = My.Computer.Network.Ping("cucak.am")
    End Sub

    Private Sub Form_Save_Album_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Settings.ShareQuality = Me.ComboBox_Quality.SelectedIndex

        Settings.CopyPath = Me.CheckBox_CopyPath.Checked
        Settings.OpenFolder = Me.CheckBox_OpenFolder.Checked
    End Sub

    Private Sub Button_SendToWeb_Click(sender As Object, e As EventArgs) Handles Button_SendToWeb.Click
        If MyBase.Publish_Album(Me.TextBox_Title.Text) Then
            MsgBox("Success", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button_Share_Socials_Click(sender As Object, e As EventArgs) Handles Button_Share_Facebook.Click, Button_Share_EMail.Click
        Dim URL As String = ""
        Do
            Try
                Dim options As PublishOptions = PublishOptions.WebSharing Or PublishOptions.AsAlbum

                Select Case CType(CType(sender, Control).Tag, ShareModes)
                    Case ShareModes.SendToEmail
                        options = options Or PublishOptions.SendViaEmail
                    Case ShareModes.SendToFacebook
                        options = options Or PublishOptions.ShareViaFacebook
                    Case ShareModes.SendToOdnoklassniki
                        options = options Or PublishOptions.ShareViaOdnoklassniki
                End Select

                If Me.CheckBox_CopyPath.Checked Then
                    options = options Or PublishOptions.CopyPathOrULR
                End If

                URL = SaveToServer(options, Me.TextBox_Title.Text)

                If URL Is Nothing Then
                    Return
                End If

                Exit Do
            Catch ex As Exception
                If MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            End Try
        Loop

        Me.Close()
    End Sub

    Private Sub Button_FromFile_Click(sender As Object, e As EventArgs) Handles Button_FromFile.Click
        If MyBase.AddImage_FromFile() Then
            PreviewImages()
        End If
    End Sub

    Private Sub Button_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Edit.Click
        EditSelectedImage()
    End Sub

    Private Sub Button_Remove_Click(sender As Object, e As EventArgs) Handles Button_Remove.Click
        If Me.ListView_Images.SelectedIndices.Count > 0 Then
            For i As Integer = Me.ListView_Images.SelectedIndices.Count - 1 To 0 Step -1
                Images.RemoveAt(Me.ListView_Images.SelectedIndices(i))
            Next
            PreviewImages()
        End If
    End Sub

    Private Sub ListView_Images_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView_Images.MouseDoubleClick
        EditSelectedImage()
    End Sub

    Private Sub ListView_Images_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles ListView_Images.AfterLabelEdit
        Me.Images(e.Item).Title = e.Label
    End Sub
End Class
