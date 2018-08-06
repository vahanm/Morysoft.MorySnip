Imports System.Threading
Imports System.Globalization
Imports System.Net
Imports Microsoft.VisualBasic.Devices
Imports System.Collections.Specialized

Public Class Form_Save_Advanced

    Private Sub Form_Save_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.Button_BrowseLocal.Text = Settings.DefaultPath
        Me.ComboBox_Type.SelectedIndex = Settings.FileType
        Me.ComboBox_Quality.SelectedIndex = Settings.ShareQuality

        Me.CheckBox_CopyPath.Checked = Settings.CopyPath
        Me.CheckBox_OpenFolder.Checked = Settings.OpenFolder

        'TODO: Remove to enable AutoUpdate
        'AutoUpdaterDotNET.AutoUpdater.Start("http://share.cucak.am/downloads/snipping-tool/version.xml.php")
    End Sub

    Private Sub Button_Browse_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_BrowseLocal.Click
        With New FolderBrowserDialog
            If .ShowDialog = DialogResult.OK Then
                Me.Button_BrowseLocal.Text = .SelectedPath
            End If
        End With
    End Sub

    Private Sub Label_Drag_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Do
                Try
                    Me.DoDragDrop(Me.Images, DragDropEffects.Copy Or DragDropEffects.Move Or DragDropEffects.Link)

                    Exit Do
                Catch ex As Exception
                    If MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                        Exit Sub
                    End If
                End Try
            Loop

            Me.Close()
        End If
    End Sub

    Public Enum SaveModes
        Normal
        SaveAs
        Server
    End Enum

    Enum ShareModes
        None = 0
        SendToFacebook = 2 ^ 0 '1
        SendToOdnoklassniki = 2 ^ 1 '2

        SendToEmail = 2 ^ 16
    End Enum

    Private Sub ComboBox_Type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBox_Type.SelectedIndexChanged, ComboBox_Quality.SelectedIndexChanged
        Settings.FileType = Me.ComboBox_Type.SelectedIndex
    End Sub

    Private Sub Form_Save_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Settings.DefaultPath = Me.Button_BrowseLocal.Text
        Settings.FileType = Me.ComboBox_Type.SelectedIndex
        Settings.ShareQuality = Me.ComboBox_Quality.SelectedIndex

        Settings.CopyPath = Me.CheckBox_CopyPath.Checked
        Settings.OpenFolder = Me.CheckBox_OpenFolder.Checked
    End Sub
End Class
