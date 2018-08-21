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

            Dim addJumpTask = Sub(Title As String, Command As String, Icon As String, CustomCategory As String)
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

            addJumpTask("Cut from screen", "", "", "Capture")

            If Screen.AllScreens.Length = 1 Then
                addJumpTask("Capture full screen", "--fullscreen", "Desktop", "Capture")
            ElseIf Screen.AllScreens.Length > 1 Then
                addJumpTask("Capture all screens", "--fullscreen", "Desktop", "Capture")

                For i As Integer = 0 To Screen.AllScreens.Length - 1
                    addJumpTask("Capture screen " & i + 1, "--fullscreen[" & i & "]", "Desktop", "Capture")
                Next
            End If

            addJumpTask("From clipboard", "--clipboard", "Clipboard", "Capture")
            addJumpTask("From file", "--file", "File", "Capture")

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
                Dim tmp As New Form_Save_Base

                If e.CommandLine.Count = 1 Then
                    Dim com As String = e.CommandLine(0).Trim()

                    Select Case com
                        Case "--fullscreen"
                            tmp.Snip_FullScreen()
                        Case "--fullscreen[0]"
                            tmp.Snip_Screen(0)
                        Case "--fullscreen[1]"
                            tmp.Snip_Screen(1)
                        Case "--fullscreen[2]"
                            tmp.Snip_Screen(2)
                        Case "--fullscreen[3]"
                            tmp.Snip_Screen(3)
                        Case "--clipboard"
                            tmp.Snip_FromClipboard()
                        Case "--file"
                            tmp.Snip_FromFile()
                    End Select
                End If

                For Each path As String In e.CommandLine
                    path = path.Trim().Trim("""", "'")

                    Try
                        Dim localPath = (New Uri(path)).LocalPath
                        Dim tempImage As Screenshot = Image.FromFile(localPath)

                        tempImage.OriginalPath = localPath
                        tmp.Images.Add(tempImage)
                    Catch ex As Exception

                    End Try
                Next

                If tmp.Images.Count > 0 Or tmp.Visible Then
                    My.Application.MainForm = tmp
                End If
            End If
        End Sub

        Private Sub MyApplication_StartupNextInstance(sender As Object, e As ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance

        End Sub
    End Class
End Namespace

