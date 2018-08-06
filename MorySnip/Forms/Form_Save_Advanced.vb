Imports System.Threading
Imports System.Globalization
Imports System.Net
Imports Microsoft.VisualBasic.Devices
Imports System.Collections.Specialized

Public Class Form_Save_Advanced

    Private Sub Form_Save_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Button_BrowseLocal.Text = Settings.DefaultPath
        Me.ComboBox_Type.SelectedIndex = Settings.FileType
        Me.ComboBox_Quality.SelectedIndex = Settings.ShareQuality

        Me.CheckBox_CopyPath.Checked = Settings.CopyPath
        Me.CheckBox_OpenFolder.Checked = Settings.OpenFolder

        PreviewImages()

        'TODO: Remove to enable AutoUpdate
        'AutoUpdaterDotNET.AutoUpdater.Start("http://share.cucak.am/downloads/snipping-tool/version.xml.php")

        'Button_SendToWeb.Enabled = My.Computer.Network.Ping("cucak.am")
    End Sub

    Private Sub PreviewImages(Optional SelectedIndex As Integer = 0)
        Dim Index As Integer = 0
        For Each Image As Screenshot In Images
            If Index = Me.TabControl_Preview.TabPages.Count Then
                If SelectedIndex = -1 Then
                    SelectedIndex = Index
                End If

                Dim PictureBox As New PictureBox()

                With PictureBox
                    .Dock = DockStyle.Fill
                    .Image = Image
                    .SizeMode = PictureBoxSizeMode.Zoom
                End With

                Me.ImageList_Thumbs.Images.Add(Image.GetThumbnailImage(64, 64, Color.Transparent))

                Dim TabPage As New TabPage(Index + 1)

                TabPage.Controls.Add(PictureBox)
                TabPage.ImageIndex = Me.ImageList_Thumbs.Images.Count - 1

                Me.TabControl_Preview.TabPages.Add(TabPage)
            Else
                Dim tp As TabPage = Me.TabControl_Preview.TabPages(Index)
                Me.ImageList_Thumbs.Images(Index) = Image.GetThumbnailImage(64, 64, Color.Transparent)
                Dim PictureBox As PictureBox = tp.Controls(0)
                PictureBox.Image = Image
            End If

            Index += 1
        Next

        If SelectedIndex = -1 Then
            SelectedIndex = 0
        End If

        Me.TabControl_Preview.SelectedIndex = SelectedIndex

        For i As Integer = Me.TabControl_Preview.TabCount - 1 To Index Step -1
            Me.TabControl_Preview.TabPages.RemoveAt(i)
            Me.ImageList_Thumbs.Images.RemoveAt(i)
        Next


        Me.Button_Edit.Enabled = Images.Count > 0
        Me.Button_SaveCopy.Enabled = Images.Count > 0
        Me.Button_Save.Enabled = Images.Count > 0
        Me.Button_SaveAs.Enabled = Images.Count > 0
        Me.Button_Remove.Enabled = Images.Count > 0

        Me.Button_SendToWeb.Enabled = Images.Count > 0
        Me.Button_Share_Facebook.Enabled = Images.Count > 0
        Me.Button_Share_Odnoklassniki.Enabled = Images.Count > 0
    End Sub

    Private Sub Button_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Save.Click
        Do
            Try
                If Me.CheckBox_CopyPath.Checked Then
                    Clipboard.SetText("""" & Save(SaveModes.Normal) & """")
                Else
                    Save(SaveModes.Normal)
                End If

                Exit Do
            Catch ex As Exception
                If MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            End Try
        Loop
        If Images.Count = 1 Then Me.Close()
    End Sub

    Private Sub Button_SaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SaveAs.Click
        Do
            Try
                If Me.CheckBox_CopyPath.Checked Then
                    Clipboard.SetText("""" & Save(SaveModes.Normal) & """")
                Else
                    Save(SaveModes.SaveAs)
                End If

                Exit Do
            Catch ex As Exception
                If MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            End Try
        Loop
        If Images.Count = 1 Then Me.Close()
    End Sub

    Private Sub Button_SaveCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SaveCopy.Click
        Do
            Try
                Clipboard.SetImage(Images(TabControl_Preview.SelectedIndex))

                Exit Do
            Catch ex As Exception
                If MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            End Try
        Loop
        If Images.Count = 1 Then Me.Close()
    End Sub

    Private Sub Button_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_BrowseLocal.Click
        Dim tmp As New FolderBrowserDialog
        If tmp.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Button_BrowseLocal.Text = tmp.SelectedPath
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

    Public Enum SaveModes
        Normal
        SaveAs
        Server
    End Enum

    Private Function Save(Optional ByVal Mode As SaveModes = SaveModes.Normal) As String
        Dim path As String = ""

        path &= Me.Button_BrowseLocal.Text

        path &= "\" & Now.ToString("yyyy-MM-dd HH-mm-ss-ffff") & "." & CStr(Me.ComboBox_Type.SelectedItem).ToLower

        If (Not IO.Directory.Exists(Me.Button_BrowseLocal.Text) AndAlso Mode = SaveModes.Normal) OrElse Mode = SaveModes.SaveAs Then

            Dim sfd As New SaveFileDialog
            sfd.AddExtension = True
            sfd.CheckPathExists = True
            sfd.CheckFileExists = False
            sfd.DefaultExt = "PNG|*.png"

            Dim fil As String = ""
            For Each i As String In Me.ComboBox_Type.Items
                fil &= i.ToUpper & "|*." & i.ToLower & "|"
            Next
            fil &= "All Files|*.*"

            sfd.Filter = fil

            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                path = sfd.FileName
            Else
                Throw New Exception("Cancelled by user.")
            End If
        End If

        Dim tmp As Image = Images(TabControl_Preview.SelectedIndex)

        Select Case IO.Path.GetExtension(path).Substring(1)
            Case "Bmp"
                tmp.Save(path, Imaging.ImageFormat.Bmp)
            Case "Emf"
                tmp.Save(path, Imaging.ImageFormat.Emf)
            Case "Exif"
                tmp.Save(path, Imaging.ImageFormat.Exif)
            Case "Gif"
                tmp.Save(path, Imaging.ImageFormat.Gif)
            Case "Ico"
                tmp.Save(path, Imaging.ImageFormat.Icon)
            Case "Jpeg", "jpg"
                tmp.Save(path, Imaging.ImageFormat.Jpeg)
            Case "Png"
                tmp.Save(path, Imaging.ImageFormat.Png)
            Case "Tiff"
                tmp.Save(path, Imaging.ImageFormat.Tiff)
            Case "Wmf"
                tmp.Save(path, Imaging.ImageFormat.Wmf)
            Case Else
                tmp.Save(path)
        End Select

        If Me.CheckBox_OpenFolder.Checked Then
            Shell("explorer /select, """ & path & """", AppWinStyle.NormalFocus)
        End If

        Return path
    End Function

    Enum ShareModes
        None = 0
        SendToFacebook = 2 ^ 0 '1
        SendToOdnoklassniki = 2 ^ 1 '2


        SendToEmail = 2 ^ 16
    End Enum

    Private Sub ComboBox_Type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Type.SelectedIndexChanged, ComboBox_Quality.SelectedIndexChanged
        Settings.FileType = Me.ComboBox_Type.SelectedIndex
    End Sub

    Private Sub Button_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Edit.Click
        Dim Index As Integer = TabControl_Preview.SelectedIndex
        If MyBase.Edit_OpenInEditor(Index) Then
            PreviewImages(Index)
        End If
    End Sub

    Private Sub Button_SendToWeb_Click(sender As Object, e As EventArgs) Handles Button_SendToWeb.Click
        Dim URL As String = ""
        Do
            Try
                URL = SaveToServer(PublishOptions.WebSharing, Me.TextBox_Title.Text)

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

        If Me.CheckBox_CopyPath.Checked Then
            Do
                Try
                    Clipboard.SetText(URL)
                    Exit Do
                Catch ex As Exception
                    If MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                        Exit Sub
                    End If
                End Try
            Loop
        End If
        Me.Close()
    End Sub

    Private Sub Button_Share_Socials_Click(sender As Object, e As EventArgs) Handles Button_Share_Facebook.Click, Button_Share_Odnoklassniki.Click, Button_Share_EMail.Click
        Dim URL As String = ""
        Do
            Try
                Dim options As PublishOptions = PublishOptions.WebSharing

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

    Private Sub Form_Save_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Settings.DefaultPath = Me.Button_BrowseLocal.Text
        Settings.FileType = Me.ComboBox_Type.SelectedIndex
        Settings.ShareQuality = Me.ComboBox_Quality.SelectedIndex

        Settings.CopyPath = Me.CheckBox_CopyPath.Checked
        Settings.OpenFolder = Me.CheckBox_OpenFolder.Checked
    End Sub

    Private Function FromClipboard() As Boolean?
        If Clipboard.ContainsImage() Then
            Me.Images.Add(Clipboard.GetImage())
            PreviewImages(-1)
            Return True
        ElseIf Clipboard.ContainsText() Then
            Dim paths = Clipboard.GetText(), Count As Integer = 0

            If paths Like "*[A-z]*[.][A-z]*" AndAlso (paths.StartsWith("http://") OrElse paths.StartsWith("https://") OrElse paths.StartsWith("ftp://")) Then
                Dim ImagePath As String = GetTempFileName()
                Try
                    My.Computer.Network.DownloadFile(paths, ImagePath, "", "", True, 3000, True, FileIO.UICancelOption.ThrowException)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    Return Nothing
                End Try
                paths = ImagePath
            End If

            For Each path As String In paths.Split("""", "'", ";", vbCr, vbLf)
                path = path.Trim().Trim("""", "'")
                Do
                    Try
                        Dim LocalPath = (New Uri(path)).LocalPath
                        Dim TempImage As Screenshot = Image.FromFile(LocalPath)
                        TempImage.OriginalPath = LocalPath
                        Me.Images.Add(TempImage)
                        Count += 1

                        Exit Do
                    Catch ex As Exception
                        Select Case MsgBox(ex.Message, MsgBoxStyle.AbortRetryIgnore)
                            Case MsgBoxResult.Retry
                                Continue Do
                            Case MsgBoxResult.Ignore
                                Continue For
                            Case MsgBoxResult.Abort
                                Return Nothing
                        End Select
                    End Try
                Loop
            Next
            If Count Then
                PreviewImages(-1)
                Return True
            End If
        ElseIf Clipboard.ContainsFileDropList() Then
            Dim l As StringCollection = Clipboard.GetFileDropList(), Count As Integer = 0

            For Each path As String In l
                path = path.Trim().Trim("""", "'")
                Try
                    Dim LocalPath = (New Uri(path)).LocalPath
                    Dim TempImage As Screenshot = Image.FromFile(LocalPath)
                    TempImage.OriginalPath = LocalPath
                    Me.Images.Add(TempImage)
                    Count += 1
                Catch ex As Exception

                End Try
            Next
            If Count Then
                PreviewImages(-1)
                Return True
            End If
        End If

        Return False
    End Function

    Private Sub Button_FromClipboard_Click(sender As Object, e As EventArgs) Handles Button_FromClipboard.Click
        If Not FromClipboard() Then
            Me.Menu_Clipboard_Message.Visible = True
            Me.Menu_Clipboard_Separator1.Visible = True

            Me.Menu_Clipboard.Show(Me.Button_FromClipboard, New Point(0, Me.Button_FromClipboard.Height), ToolStripDropDownDirection.BelowRight)
            'MsgBox("No image or image file path in clipboard.", MsgBoxStyle.Critical)

            Me.Menu_Clipboard_Message.Visible = False
            Me.Menu_Clipboard_Separator1.Visible = False
        End If
    End Sub

    Private Sub Button_FullScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_FullScreen.Click, Menu_Screens_Screen4.Click, Menu_Screens_Screen3.Click, Menu_Screens_Screen2.Click, Menu_Screens_Screen1.Click, Menu_Screens_AllScreens.Click
        If sender Is Me.Button_FullScreen AndAlso Screen.AllScreens.Length > 1 Then
            Me.Menu_Screens_Screen3.Visible = Screen.AllScreens.Length > 2
            Me.Menu_Screens_Screen4.Visible = Screen.AllScreens.Length > 3
            Me.Menu_Screens.Show(Me.Button_FullScreen, New Point(0, Me.Button_FullScreen.Height), ToolStripDropDownDirection.BelowRight)
        Else
            'Dim tmp As Control = sender
            Dim vl As Point
            Dim vs As Size

            If sender.Tag Is Nothing Then
                vl = SystemInformation.VirtualScreen.Location
                vs = SystemInformation.VirtualScreen.Size
            Else
                vl = Screen.AllScreens(CInt(sender.Tag)).Bounds.Location
                vs = Screen.AllScreens(CInt(sender.Tag)).Bounds.Size
            End If

            Me.Opacity = 0
            Me.Hide()

            Dim b As New Bitmap(vs.Width, vs.Height)

            Dim g As Graphics = Graphics.FromImage(b)

            g.CopyFromScreen(vl.X, vl.Y, 0, 0, vs)

            Me.Images.Add(b)

            Me.Show()
            Me.Opacity = 1

            PreviewImages(-1)
        End If
    End Sub

    Private Sub Button_CutFromScreen_Click(sender As Object, e As EventArgs) Handles Button_CutFromScreen.Click
        Me.Hide()
        With New Form_SnippingTool
            .SaveForm = Me
            .ShowDialog()
        End With
        Me.Show()
        PreviewImages(-1)
    End Sub

    Private Sub Button_FromFile_Click(sender As Object, e As EventArgs) Handles Button_FromFile.Click
        Dim od As New OpenFileDialog()
        od.AutoUpgradeEnabled = True
        od.CheckFileExists = True
        od.CheckPathExists = True
        od.Multiselect = True
        od.Filter = "All supported files|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpeg;*.jpg;*.png;*.tiff;*.wmf;"


        If od.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each path As String In od.FileNames
                Do
                    path = path.Trim().Trim("""", "'")
                    Try
                        Dim LocalPath = (New Uri(path)).LocalPath
                        Dim TempImage As Screenshot = Image.FromFile(LocalPath)
                        TempImage.OriginalPath = LocalPath
                        Me.Images.Add(TempImage)
                        Exit Do
                    Catch ex As Exception
                        Select Case MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.AbortRetryIgnore)
                            Case MsgBoxResult.Retry

                            Case MsgBoxResult.Abort
                                Exit For
                            Case MsgBoxResult.Ignore
                                Exit Do
                        End Select
                    End Try
                Loop
            Next
            PreviewImages(-1)
        End If
    End Sub

    Private Sub Button_Remove_Click(sender As Object, e As EventArgs) Handles Button_Remove.Click
        Dim Index As Integer = TabControl_Preview.SelectedIndex
        Images.RemoveAt(Index)
        PreviewImages(Index - 1)
    End Sub

    Private Sub Menu_Clipboard_Monitor_Click(sender As Object, e As EventArgs) Handles Menu_Clipboard_Monitor.Click
        Clipboard.Clear()
        Me.Menu_Clipboard_Monitor.Checked += 1
        Me.Timer_MonitorClipboard.Enabled = Me.Menu_Clipboard_Monitor.Checked
    End Sub

    Private Sub Timer_MonitorClipboard_Tick(sender As Object, e As EventArgs) Handles Timer_MonitorClipboard.Tick
        Dim state As Boolean = Me.Timer_MonitorClipboard.Enabled

        If state Then
            Me.Timer_MonitorClipboard.Stop()
        End If

        FromClipboard()

        Clipboard.Clear()

        Me.Timer_MonitorClipboard.Enabled = state
    End Sub
End Class
