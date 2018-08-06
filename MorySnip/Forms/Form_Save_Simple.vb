Imports System.Threading
Imports System.Globalization
Imports System.Net
Imports Microsoft.VisualBasic.Devices
Imports System.Collections.Specialized

Public Class Form_Save_Simple
    Private Sub Button_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Save.Click
        If MyBase.Publish_SaveToFile(PublishOptions.SaveToFile) Then
            Me.Close()
        End If
    End Sub

    Private Sub Button_SaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SaveAs.Click
        If MyBase.Publish_SaveToFile(PublishOptions.SaveToFile Or PublishOptions.SaveAs) Then
            Me.Close()
        End If
    End Sub

    Private Sub Button_SaveCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SaveCopy.Click
        If MyBase.Publish_ToClipboard(0) Then
            Me.Close()
        End If
    End Sub

    Private Sub Label_Drag_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Do
                Try
                    'Dim tmp As String() = {"""" & Save(False) & """"}
                    'Dim tmp As New IO.FileInfo(Save(False))

                    Me.DoDragDrop(Images, DragDropEffects.Copy Or DragDropEffects.Move Or DragDropEffects.Link)

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

    Private Sub Button_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Edit.Click
        MyBase.Edit_OpenInEditor(0)
    End Sub

    Private Sub Button_SendToWeb_Click(sender As Object, e As EventArgs) Handles Button_SendToWeb.Click
        If MyBase.Publish_SharingService(Me.TextBox_Title.Text) Then
            Me.Close()
        End If
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub

    Private Sub Form_Save_Simple_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
