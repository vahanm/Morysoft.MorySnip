Imports System.Collections.Specialized
Imports System.Linq
Imports System.Net

Public Class Form_Save_Base
    Inherits Form

    Protected _virtualScreenLocation As Point = SystemInformation.VirtualScreen.Location
    Protected _virtualScreenSize As Size = SystemInformation.VirtualScreen.Size

    Protected _primaryScreenLocation As Point = Screen.PrimaryScreen.Bounds.Location
    Protected _primaryScreenSize As Size = Screen.PrimaryScreen.Bounds.Size

    Private _saveForm As Form_Save_Base

    Public Property SaveForm As Form_Save_Base
        Get
            If Me._saveForm Is Nothing Then
                Me._saveForm = New Form_Edit()
            End If

            Return Me._saveForm
        End Get
        Set
            Me._saveForm = Value
        End Set
    End Property

    Public Enum PublishOptions As Integer
        OnlyImageNumber = 2 ^ 16 - 1

        CopyPathOrULR = 2 ^ 17
        CopyImage = 2 ^ 18
        OpenFolder = 2 ^ 19

        SaveToFile = 2 ^ 24
        SaveAs = 2 ^ 25
        WebSharing = 2 ^ 28 'Base service
        AsAlbum = 2 ^ 29
        ShareViaFacebook = 2 ^ 26 '67,108,864
        ShareViaOdnoklassniki = 2 ^ 27 '134,217,728
        SendViaEmail = 2 ^ 30
    End Enum

    Public Images As New List(Of Screenshot)

    Public Function Publish_ToClipboard(ImageNumber As Integer) As Boolean
        Do
            Try
                Clipboard.SetImage(Me.Images(ImageNumber))

                Return True
            Catch ex As Exception
                If MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                    Return False
                End If
            End Try
        Loop

        Return False
    End Function

    Public Function Publish_SaveToFile(Optional ByVal Options As PublishOptions = PublishOptions.SaveToFile) As Boolean
        Dim imageNumber As Integer = Options And PublishOptions.OnlyImageNumber
        Dim path As String = ""

        path &= Settings.DefaultPath

        path &= "\" & Now.ToString("yyyy-MM-dd HH-mm-ss-ffff") & "." & FileTypeString.ToLower()

        If (Not IO.Directory.Exists(Settings.DefaultPath) AndAlso ((Options And PublishOptions.SaveToFile) = PublishOptions.SaveToFile)) OrElse ((Options And PublishOptions.SaveAs) = PublishOptions.SaveAs) Then
            Dim sfd As New SaveFileDialog With {
                .AddExtension = True,
                .CheckPathExists = True,
                .CheckFileExists = False,
                .DefaultExt = "PNG|*.png",
                .Filter = Settings.FileTypes.Aggregate(Function(a, i) a & i.ToUpper & "|*." & i.ToLower & "|") & "All Files|*.*"
            }

            If sfd.ShowDialog = DialogResult.OK Then
                path = sfd.FileName
            Else
                Return False
            End If
        End If

        Dim tmp As Image = Me.Images(imageNumber)

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

        If (Options And PublishOptions.SaveAs) = PublishOptions.SaveAs Then
            Shell("explorer /select, """ & path & """", AppWinStyle.NormalFocus)
        End If

        Return True
    End Function

    Public Function AddImage_FromClipboard() As Integer
        If Clipboard.ContainsImage() Then
            Me.Images.Add(Clipboard.GetImage())
            Return 1
        ElseIf Clipboard.ContainsText() Then
            Dim paths = Clipboard.GetText(), Count As Integer = 0

            If paths Like "*[A-z]*[.][A-z]*" AndAlso (paths.StartsWith("http://") OrElse paths.StartsWith("https://") OrElse paths.StartsWith("ftp://")) Then
                Dim ImagePath As String = GetTempFileName()
                My.Computer.Network.DownloadFile(paths, ImagePath, "", "", True, 3000, True, FileIO.UICancelOption.ThrowException)
                paths = ImagePath
            End If

            For Each path As String In paths.Split("""", "'", ";", vbCr, vbLf)
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

            Return Count
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
            Return Count
        End If
    End Function

    Public Function AddImage_FullScreen(Optional ScreenNumber As Integer = -1)
        Dim vl As Point
        Dim vs As Size

        If ScreenNumber < 0 OrElse ScreenNumber > Screen.AllScreens.Length - 1 Then
            vl = SystemInformation.VirtualScreen.Location
            vs = SystemInformation.VirtualScreen.Size
        Else
            vl = Screen.AllScreens(ScreenNumber).Bounds.Location
            vs = Screen.AllScreens(ScreenNumber).Bounds.Size
        End If

        Me.Opacity = 0
        Me.Hide()

        Dim b As New Bitmap(vs.Width, vs.Height)

        Dim g As Graphics = Graphics.FromImage(b)

        g.CopyFromScreen(vl.X, vl.Y, 0, 0, vs)

        Me.Images.Add(b)

        Me.Show()
        Me.Opacity = 1

        Return 1
    End Function

    Public Function AddImage_FromSnippingTool() As Integer
        Dim ImagesCount As Integer = Me.Images.Count

        Me.Hide()
        With New Form_SnippingTool
            .SaveForm = Me
            .ShowDialog()
        End With
        Me.Show()

        Return Me.Images.Count - ImagesCount
    End Function

    Public Function AddImage_FromFile() As Integer
        Dim od As New OpenFileDialog With {
            .AutoUpgradeEnabled = True,
            .CheckFileExists = True,
            .CheckPathExists = True,
            .Multiselect = True,
            .Filter = "All supported files|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpeg;*.jpg;*.png;*.tiff;*.wmf;"
        }

        Dim ImagesAdd As Integer = 0

        If od.ShowDialog() = DialogResult.OK Then
            For Each path As String In od.FileNames.Select(Function(fn) fn.Trim().Trim("""", "'"))
                Do
                    Try
                        Dim LocalPath = (New Uri(path)).LocalPath
                        Dim TempImage As Screenshot = Image.FromFile(LocalPath)
                        TempImage.OriginalPath = LocalPath
                        Me.Images.Add(TempImage)

                        ImagesAdd += 1

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
        End If

        Return ImagesAdd
    End Function

    Public Sub Snip_FromClipboard()
        If Clipboard.ContainsImage() Then
            Me.SaveForm.Images.Add(Clipboard.GetImage())
            Me.SaveForm.Show()
            Me.Close()

            Return
        ElseIf Clipboard.ContainsText() Then
            Dim paths = Clipboard.GetText()

            For Each path As String In paths.Split("""", "'", ";", vbCr, vbLf).Select(Function(fn) fn.Trim("""", "'"))
                Try
                    Dim localPath = (New Uri(path)).LocalPath
                    Dim tempImage As Screenshot = Image.FromFile(localPath)

                    tempImage.OriginalPath = localPath

                    Me.SaveForm.Images.Add(tempImage)
                Catch ex As Exception

                End Try
            Next

            If Me.SaveForm.Images.Count Then
                Me.SaveForm.Show()
                Me.Close()

                Return
            End If
        ElseIf Clipboard.ContainsFileDropList() Then
            Dim filesDrop = Clipboard.GetFileDropList()

            For Each path As String In filesDrop
                path = path.Trim("""", "'")

                Try
                    Dim localPath = (New Uri(path)).LocalPath
                    Dim tempImage As Screenshot = Image.FromFile(localPath)

                    tempImage.OriginalPath = localPath

                    Me.SaveForm.Images.Add(tempImage)
                Catch ex As Exception

                End Try
            Next

            If Me.SaveForm.Images.Count Then
                Me.SaveForm.Show()
                Me.Close()

                Return
            End If
        End If

        MsgBox("No image or image file path in clipboard.", MsgBoxStyle.Critical)
    End Sub

    Public Sub Snip_FullScreen()
        Me.Hide()

        Dim b As New Bitmap(Me._virtualScreenSize.Width, Me._virtualScreenSize.Height)

        Dim g As Graphics = Graphics.FromImage(b)

        g.CopyFromScreen(Me._virtualScreenLocation.X, Me._virtualScreenLocation.Y, 0, 0, Me._virtualScreenSize)

        Me.SaveForm.Images.Add(b)

        Me.SaveForm.Show()

        Me.Close()
    End Sub

    Public Sub Snip_Screen(index As Integer)
        Throw New NotImplementedException()
    End Sub

    Public Sub Snip_FromFile()
        Dim od As New OpenFileDialog With {
            .AutoUpgradeEnabled = True,
            .CheckFileExists = True,
            .CheckPathExists = True,
            .Multiselect = True,
            .Filter = "All supported files|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpeg;*.jpg;*.png;*.tiff;*.wmf;"
        }

        Me.Hide()

        If od.ShowDialog(Me.SaveForm) = DialogResult.OK Then
            For Each path As String In od.FileNames.Select(Function(fn) fn.Trim("""", "'"))
                Do
                    Try
                        Dim localPath = (New Uri(path)).LocalPath
                        Dim tempImage As Screenshot = Image.FromFile(localPath)

                        tempImage.OriginalPath = localPath

                        Me.SaveForm.Images.Add(tempImage)

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

            Me.SaveForm.Show()
            Me.Close()

            Return
        End If

        Me.Show()
    End Sub
End Class
