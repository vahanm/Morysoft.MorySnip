Imports System.Globalization
Imports System.Threading

Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub ApplyJumpList()
            Dim jl As New System.Windows.Shell.JumpList()
            Dim dir As String = My.Application.Info.DirectoryPath
            Dim ass As String = My.Application.Info.AssemblyName
            Dim exe As String = String.Format("{0}\{1}.exe", dir, ass)

            Dim AddJumpTask = Sub(Title As String, Command As String, Icon As String, CustomCategory As String)
                                  Dim jt As New System.Windows.Shell.JumpTask()

                                  'If Not String.IsNullOrWhiteSpace(CustomCategory) Then
                                  '    jt.CustomCategory = CustomCategory
                                  'End If

                                  jt.Title = Title
                                  jt.ApplicationPath = exe
                                  jt.Arguments = Command
                                  jt.IconResourcePath = IIf(String.IsNullOrWhiteSpace(Icon), exe, String.Format("{0}\Resources\JobIcons\{1}.ico", dir, Icon))
                                  jt.IconResourceIndex = 0

                                  jl.JumpItems.Add(jt)
                              End Sub

            AddJumpTask("Cut from screen", "", "", "Capture")

            If Screen.AllScreens.Length = 1 Then
                AddJumpTask("Capture full screen", "--fullscreen", "Desktop", "Capture")
            ElseIf Screen.AllScreens.Length > 1 Then
                AddJumpTask("Capture all screens", "--fullscreen", "Desktop", "Capture")

                For i As Integer = 0 To Screen.AllScreens.Length - 1
                    AddJumpTask("Capture screen " & i + 1, "--fullscreen[" & i & "]", "Desktop", "Capture")
                Next
            End If

            AddJumpTask("From clipboard", "--clipboard", "Clipboard", "Capture")
            AddJumpTask("From file", "--file", "File", "Capture")
            AddJumpTask("New Album", "--album", "Album", "Capture")

            AddJumpTask("View history", "--history", "History", "Settings")

            jl.ShowRecentCategory = True

            jl.Apply()
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            DeleteAllTempFiles()
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            SaveSetting(My.Application.Info.CompanyName, "Global", My.Application.Info.AssemblyName.Replace(" ", "_") & "_Version", My.Application.Info.Version.ToString())
            SaveSetting(My.Application.Info.CompanyName, "Global", My.Application.Info.AssemblyName.Replace(" ", "_") & "_Path", My.Application.Info.DirectoryPath)
            SaveSetting(My.Application.Info.CompanyName, "Global", My.Application.Info.AssemblyName.Replace(" ", "_") & "_LastRun", Now.ToString("hh:mm:ss dd.MM.yyyy"))

            SetDefaultSettings()

            Thread.CurrentThread.CurrentUICulture = CultureCode 'CultureInfo.CurrentCulture 'New CultureInfo("hy-am")

            ApplyJumpList()

            If e.CommandLine.Count > 0 Then
                Dim tmp As New Form_Save_Advanced

                If e.CommandLine.Count = 1 Then
                    Dim com As String = e.CommandLine(0).Trim()

                    If com Like "cucak://##############*#/*" Then
                        Dim params As String() = com.Replace("cucak://", "").Split(New Char() {"/"}, StringSplitOptions.RemoveEmptyEntries)

                        Select Case params.Length
                            Case 1
                                MsgBox("Action not supported") : End
                            Case 2, 3
                                Select Case params(1)
                                    Case "download"
                                        Dim df As New Form_Download()

                                        df.ShareId = params(0)

                                        If params.Length = 3 Then
                                            df.ItemsCount = params(2)
                                        Else
                                            df.ItemsCount = 1
                                        End If

                                        My.Application.MainForm = df
                                    Case "add-to-history"
                                        Dim ShareId = params(0)
                                        Dim TitleText As String = ""

                                        Dim decode = Function(encodedData As String) As String
                                                         Dim encodedDataAsBytes As Byte() = System.Convert.FromBase64String(encodedData)
                                                         Dim returnValue As String = System.Text.Encoding.UTF8.GetString(encodedDataAsBytes)
                                                         Return returnValue
                                                     End Function

                                        If params.Length = 3 Then
                                            TitleText = decode(System.Web.HttpUtility.UrlDecode(params(2)))
                                        End If

                                        SettingHistoryAdd(ShareId, TitleText)

                                        MsgBox("Post added to your posts' history list.", MsgBoxStyle.Information)
                                        End

                                    Case "edit-and-share"
                                        Dim ShareId As String = params(0)
                                        Dim ItemNumber As Integer = 1

                                        If params.Length = 3 Then
                                            ItemNumber = params(2)
                                        End If

                                        Dim filename As String = GetTempFileName()
                                        Dim img As Image

                                        Try
                                            My.Computer.Network.DownloadFile(String.Format("http://share.cucak.am/snapshots/{0}{1}.png", ShareId, ItemNumber.ToString("000")), filename, "", "", True, 3000, True, FileIO.UICancelOption.ThrowException)
                                            img = Image.FromFile(filename)
                                        Catch ex1 As Exception
                                            Try
                                                My.Computer.Network.DownloadFile(String.Format("http://share.cucak.am/snapshots/{0}/{0}{1}.png", ShareId, ItemNumber.ToString("000")), filename, "", "", True, 3000, True, FileIO.UICancelOption.ThrowException)
                                                img = Image.FromFile(filename)
                                            Catch ex As Exception
                                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                                                End
                                            End Try
                                        End Try

                                        With New Form_Edit
                                            .Image = img

                                            If .ShowDialog() = DialogResult.OK Then
                                                img = .Image

                                                Dim sf As New Form_Save_Advanced()

                                                sf.Images.Add(img)
                                                sf.Show()
                                            End If
                                        End With
                                        End
                                    Case Else
                                        MsgBox("Action not supported") : End
                                End Select
                            Case Else
                                MsgBox("Action not supported") : End
                        End Select
                    Else
                        Select Case com
                            Case "--fullscreen"
                                tmp.Show()
                                tmp.Menu_Screens_AllScreens.PerformClick()
                            Case "--fullscreen[0]"
                                tmp.Show()
                                tmp.Menu_Screens_Screen1.PerformClick()
                            Case "--fullscreen[1]"
                                tmp.Show()
                                tmp.Menu_Screens_Screen2.PerformClick()
                            Case "--fullscreen[2]"
                                tmp.Show()
                                tmp.Menu_Screens_Screen3.PerformClick()
                            Case "--fullscreen[3]"
                                tmp.Show()
                                tmp.Menu_Screens_Screen4.PerformClick()
                            Case "--clipboard"
                                tmp.Show()
                                tmp.Button_FromClipboard.PerformClick()
                            Case "--file"
                                tmp.Show()
                                tmp.Button_FromFile.PerformClick()
                            Case "--history"
                                My.Application.MainForm = Form_History
                                Return
                            Case "--album"
                                My.Application.MainForm = Form_Save_Album
                                Return
                        End Select
                    End If

                End If

                For Each path As String In e.CommandLine
                    path = path.Trim().Trim("""", "'")
                    Try
                        Dim LocalPath = (New Uri(path)).LocalPath
                        Dim TempImage As Screenshot = Image.FromFile(LocalPath)
                        TempImage.OriginalPath = LocalPath
                        tmp.Images.Add(TempImage)
                    Catch ex As Exception

                    End Try
                Next

                If tmp.Images.Count > 0 Or tmp.Visible Then
                    My.Application.MainForm = tmp
                    'e.Cancel = True
                    'tmp.ShowDialog()
                End If
            End If
        End Sub

        Private Sub MyApplication_StartupNextInstance(sender As Object, e As ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance

        End Sub
    End Class
End Namespace

