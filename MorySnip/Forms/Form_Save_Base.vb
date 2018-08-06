Imports System.Collections.Specialized
Imports System.Linq
Imports System.Net

Public Class Form_Save_Base
    Inherits Form

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

    Public Function Publish_SharingService(Optional TitleText As String = Nothing) As Boolean
        Dim URL As String = ""
        Do
            Try
                URL = SaveToServer(PublishOptions.WebSharing Or (PublishOptions.CopyPathOrULR And Settings.CopyPath) Or (PublishOptions.OpenFolder And Settings.OpenFolder), TitleText)

                If String.IsNullOrWhiteSpace(URL) Then
                    Return False
                End If

                Exit Do
            Catch ex As Exception
                If MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                    Return False
                End If
            End Try
        Loop

        Return True
    End Function

    Public Function Publish_Album(TitleText As String) As Boolean
        Dim URL As String = ""
        Do
            Try
                URL = SaveToServer(PublishOptions.WebSharing Or PublishOptions.AsAlbum Or PublishOptions.CopyPathOrULR Or PublishOptions.OpenFolder, TitleText)

                If URL Is Nothing Then
                    Return False
                End If

                Exit Do
            Catch ex As Exception
                If MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                    Return False
                End If
            End Try
        Loop

        Return True
    End Function

    Public Function SaveToServer(Options As PublishOptions, Optional TitleText As String = Nothing) As String
        Dim id As Single = Rnd(-Now.Millisecond)

        Dim UploadId As String = Now.Ticks & CInt(id * 89999 + 10000).ToString("00000")
        Dim nc As ICredentials = New NetworkCredential("snipping-tool@parap.am", "snipping-tool")

        Dim url As String = "http://share.cucak.am/" & UploadId

        Dim us As New Google.Apis.Urlshortener.v1.UrlResource(gcs)
        Dim surl As Google.Apis.Urlshortener.v1.Data.Url = us.Insert(New Google.Apis.Urlshortener.v1.Data.Url() With {.LongUrl = url}).Execute()

        If Not String.IsNullOrWhiteSpace(surl.Id) Then
            url = surl.Id
        End If

        If (Options And PublishOptions.CopyPathOrULR) = PublishOptions.CopyPathOrULR Then
            Do
                Try
                    Clipboard.SetText(url)
                    Exit Do
                Catch ex As Exception
                    If MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                        Throw ex
                    End If
                End Try
            Loop
        End If

        Dim ZipPath As String = GetTempFileName()
        Dim Zip As New Ionic.Zip.ZipFile()

        Dim Index As Integer = 0
        For Each tmp As Screenshot In Me.Images
            Dim ImagePath As String = GetTempFileName()

            Select Case Settings.ShareQuality
                Case 1
                    Dim SizeRate As Double = ((tmp.Image.Width * tmp.Image.Height) / (2 * 1920 * 1080)) ^ 0.5 '4 * 10 ^ 6
                    If SizeRate > 1 Then
                        tmp = ImageUtilities.ResizeImage(tmp, tmp.Image.Width / SizeRate, tmp.Image.Height / SizeRate)
                    End If
                    tmp.Image.Save(ImagePath, Imaging.ImageFormat.Jpeg)
                Case 2
                    tmp.Image.Save(ImagePath, Imaging.ImageFormat.Gif)
                Case Else
                    If Not String.IsNullOrWhiteSpace(tmp.OriginalPath) Then
                        ImagePath = tmp.OriginalPath
                    Else
                        tmp.Image.Save(ImagePath, Imaging.ImageFormat.Png)
                    End If
            End Select

            If (Options And PublishOptions.AsAlbum) = PublishOptions.AsAlbum Then
                Dim ThumbPath As String = GetTempFileName()
                tmp.GetThumbnailImage(330, 330, Color.Transparent).Save(ThumbPath)
                Zip.AddEntry(UploadId & String.Format("{0:000}.330x330.png", Index), New IO.FileStream(ThumbPath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read))
            End If

            If (Options And PublishOptions.AsAlbum) = PublishOptions.AsAlbum Then
                Dim ThumbPath As String = GetTempFileName()
                tmp.GetThumbnailImage(150, 150, Color.Transparent).Save(ThumbPath)
                Zip.AddEntry(UploadId & String.Format("{0:000}.150x150.png", Index), New IO.FileStream(ThumbPath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read))
            End If

            If (Options And PublishOptions.AsAlbum) = PublishOptions.AsAlbum Then
                Dim ThumbPath As String = GetTempFileName()
                tmp.GetThumbnailImage(1200, 800, Color.Transparent).Save(ThumbPath)
                Zip.AddEntry(UploadId & String.Format("{0:000}.1200x800.png", Index), New IO.FileStream(ThumbPath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read))
            End If

            If Not String.IsNullOrEmpty(tmp.Comment) Then
                Zip.AddEntry(UploadId & String.Format("{0:000}.comment", Index), tmp.Comment, System.Text.Encoding.UTF8)
            End If

            If Not String.IsNullOrEmpty(tmp.Title) Then
                Zip.AddEntry(UploadId & String.Format("{0:000}.title", Index), tmp.Title, System.Text.Encoding.UTF8)
            End If

            Zip.AddEntry(UploadId & String.Format("{0:000}.png", Index), New IO.FileStream(ImagePath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read))
            Index += 1
        Next

        If Not String.IsNullOrEmpty(TitleText) Then
            Zip.AddEntry(UploadId & ".title", TitleText, System.Text.Encoding.UTF8)
        End If

        Zip.Save(ZipPath)

        Dim getUri = Function() New Uri(String.Format("ftp://cucak.am/snapshots/{0}.zip", UploadId))

        My.Computer.Network.UploadFile(ZipPath, getUri(), nc, True, 200, FileIO.UICancelOption.ThrowException)

        SettingHistoryAdd(UploadId, TitleText)

        If (Options And PublishOptions.ShareViaFacebook) = PublishOptions.ShareViaFacebook Then
            Shell("explorer ""https://www.facebook.com/sharer/sharer.php?u=http%3A%2F%2Fshare.cucak.am%2F" & UploadId & """", AppWinStyle.NormalFocus)
        ElseIf (Options And PublishOptions.ShareViaOdnoklassniki) = PublishOptions.ShareViaOdnoklassniki Then
            Shell("explorer ""http://www.odnoklassniki.ru/dk?st.cmd=addShare&st.s=1&st._surl=http%3A%2F%2Fshare.cucak.am%2F" & UploadId & """", AppWinStyle.NormalFocus)
        Else
            If (Options And PublishOptions.OpenFolder) = PublishOptions.OpenFolder Then
                Shell("explorer """ & url & """", AppWinStyle.NormalFocus)
            End If
        End If

        Return url
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

    Public Function Edit_OpenInEditor(ImageNumber As Integer) As Boolean
        With New Form_Edit
            .Image = Me.Images(ImageNumber)

            If .ShowDialog(Me) = DialogResult.OK Then
                Me.Images(ImageNumber) = .Image
                Return True
            Else
                Return False
            End If
        End With
    End Function
End Class
