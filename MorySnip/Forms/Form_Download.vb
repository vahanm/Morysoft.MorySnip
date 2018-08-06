Public Class Form_Download
    Private ShareIdValue As String
    Public Property ShareId() As String
        Get
            Return Me.ShareIdValue
        End Get
        Set(ByVal value As String)
            Me.ShareIdValue = value
        End Set
    End Property

    Private ItemsCountValue As Integer
    Public Property ItemsCount() As Integer
        Get
            Return Me.ItemsCountValue
        End Get
        Set(ByVal value As Integer)
            Me.ItemsCountValue = value
        End Set
    End Property

    Public Sub BeginDownload()
        Me.ProgressBar_Files.Maximum = Me.ItemsCount

        For i As Integer = 0 To Me.ItemsCount - 1
            Do
                Try
                    Download(Me.ShareId & i.ToString("000"))
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
            Me.ProgressBar_Files.Value = i
        Next

        Me.Close()
    End Sub

    Private Sub Download(Id As String)
        My.Computer.Network.DownloadFile(String.Format("http://share.cucak.am/snapshots/{0}.png", Id), String.Format("{1}\tmp\{0}.png", Id, My.Computer.FileSystem.SpecialDirectories.Desktop), "", "", True, 3000, True, FileIO.UICancelOption.ThrowException)
    End Sub

    Private Sub Form_Download_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer_Begin_Tick(sender As Object, e As EventArgs) Handles Timer_Begin.Tick
        Me.Timer_Begin.Stop()
        BeginDownload()
    End Sub
End Class