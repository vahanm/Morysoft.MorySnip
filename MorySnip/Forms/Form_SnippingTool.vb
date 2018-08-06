Imports System.Collections.Specialized

Public Class Form_SnippingTool
    Dim NewSaveForm As Form_Save_Base

    Dim x, y, w, h As Integer
    Dim FirstPoint As Point
    Dim LastPoint As Point
    Dim LastButton As MouseButtons = Windows.Forms.MouseButtons.None

    Dim vl As Point = SystemInformation.VirtualScreen.Location
    Dim vs As Size = SystemInformation.VirtualScreen.Size

    Dim pl As Point = Screen.PrimaryScreen.Bounds.Location
    Dim ps As Size = Screen.PrimaryScreen.Bounds.Size

    Dim BordersOnlyMode As Boolean = False

    Public Property SaveForm As Form_Save_Base
        Get
            If NewSaveForm Is Nothing Then NewSaveForm = New Form_Save_Advanced
            Return NewSaveForm
        End Get
        Set(value As Form_Save_Base)
            NewSaveForm = value
        End Set
    End Property

    Private Sub CalculateArea()
        If FirstPoint.X < LastPoint.X Then
            x = FirstPoint.X
            w = LastPoint.X - FirstPoint.X
        Else
            x = LastPoint.X
            w = FirstPoint.X - LastPoint.X
        End If
        If FirstPoint.Y < LastPoint.Y Then
            y = FirstPoint.Y
            h = LastPoint.Y - FirstPoint.Y
        Else
            y = LastPoint.Y
            h = FirstPoint.Y - LastPoint.Y
        End If

        If My.Computer.Keyboard.CtrlKeyDown Then
            w = Math.Max(w, h)
            h = Math.Max(w, h)
        End If

        If My.Computer.Keyboard.ShiftKeyDown Then
            x = FirstPoint.X - w
            y = FirstPoint.Y - h
            w *= 2
            h *= 2
        End If

        Me.Refresh()
    End Sub

    Private Sub Crop()
        Dim Capture = Sub()
                          Me.Opacity = 0
                          Me.Refresh()

                          Dim b As New Bitmap(w, h)
                          Dim g As Graphics = Graphics.FromImage(b)

                          g.CopyFromScreen(vl.X + x, vl.Y + y, 0, 0, New Size(w, h))

                          SaveForm.Images.Add(b)

                          Me.Opacity = 1
                          Me.Refresh()
                      End Sub

        Select Case LastButton
            Case Windows.Forms.MouseButtons.Left
                Me.Hide()

                If My.Computer.Keyboard.AltKeyDown Then
                    Dim acf As New Form_AutoCapture()
                    If acf.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Dim Wait = Sub(milliseconds As Integer)
                                       Process.GetCurrentProcess().WaitForExit(milliseconds)
                                   End Sub

                        Dim WaitMilliseconds As Integer = acf.NumericUpDown_Start.Value * 1000
                        Dim IntervalMilliseconds As Integer = acf.NumericUpDown_Interval.Value
                        Dim Count As Integer = acf.NumericUpDown_Count.Value

                        BordersOnlyMode = True
                        Me.Opacity = 1
                        Me.Show()
                        Me.Refresh()

                        For i As Integer = 1 To Count
                            Wait(IIf(i = 1, WaitMilliseconds, IntervalMilliseconds))
                            Capture()
                        Next
                    Else
                        End
                    End If
                Else
                    Capture()
                End If

                SaveForm.Show()

                Me.Close()

            Case Windows.Forms.MouseButtons.Right
                Me.Hide()
                SaveForm = New Form_Edit()
                CType(SaveForm, Form_Edit).Button_OK.Visible = False
                CType(SaveForm, Form_Edit).ToolStrip_Share.Visible = True
                Capture()
                SaveForm.Show()
                Me.Close()
        End Select
    End Sub

    Private Sub Cancel()
        LastButton = Windows.Forms.MouseButtons.None
        x = 0
        y = 0
        w = 0
        h = 0

        Me.Refresh()
    End Sub

    Private Sub ShowMenu()
        Me.Menu_Snip.Show(Windows.Forms.Cursor.Position)
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim g As Graphics = e.Graphics

        g.Clear(Color.Black)

        If w > 3 AndAlso h > 3 AndAlso Not LastButton = Windows.Forms.MouseButtons.None Then
            If BordersOnlyMode Then
                g.Clear(Me.TransparencyKey)
                g.DrawRectangle(New Pen(Color.Red, 2), x, y, w, h)
            Else
                'g.DrawLine(New Pen(Brushes.DarkOrange, 2), x, y - 5, x + w, y - 5)

                'g.DrawLine(New Pen(Brushes.DarkOrange, 2), x - 5, y, x - 5, y + h)

                g.FillRectangle(New SolidBrush(Me.TransparencyKey), x, y, w + 1, h + 1)
                'g.DrawRectangle(Pens.Red, x, y, w, h)
                g.DrawRectangle(Pens.Red, -10, y, 10000, h + 1)
                g.DrawRectangle(Pens.Red, x, -10, w + 1, 10000)

                Dim r1 = ReduceRatio(w \ 10, h \ 10)
                Dim r2 = ReduceRatio(w, h)
                Dim Approximate As Boolean = Not r1 = r2

                g.DrawString(String.Format("{0:# ##0px} - {1:# ##0px} -- {4}{2}:{3}", w, h, r1.Width, r1.Height, IIf(Approximate, "≈", "")), New Font(Me.Font.FontFamily, 11, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.White, x, y - 14)
            End If
        Else
            If My.Computer.Mouse.ButtonsSwapped Then
                g.DrawString(My.Resources.PressLeftClickToViewOptions, New Font(Me.Font.FontFamily, 40, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.DarkGray, -vl.X + pl.X + 10, -vl.Y + pl.Y + ps.Height \ 2 - 20)
            Else
                g.DrawString(My.Resources.PressRightClickToViewOptions, New Font(Me.Font.FontFamily, 40, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.DarkGray, -vl.X + pl.X + 10, -vl.Y + pl.Y + ps.Height \ 2 - 20)
            End If
        End If
    End Sub

    Private Sub Form_SnippingTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = SystemInformation.VirtualScreen.Location
        Me.Size = SystemInformation.VirtualScreen.Size
    End Sub

    Private Sub Form_SnippingTool_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If LastButton = Windows.Forms.MouseButtons.None Then
            Select Case e.KeyCode
                Case Keys.Escape
                    Me.Close()
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.Escape
                    Cancel()
                Case Keys.ControlKey, Keys.ShiftKey
                    CalculateArea()
                Case Keys.Enter
                    Crop()
            End Select
        End If
    End Sub

    Private Sub Form_SnippingTool_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If LastButton = Windows.Forms.MouseButtons.None Then
            Select Case e.KeyCode
                Case Keys.Apps
                    ShowMenu()
            End Select
        Else
            CalculateArea()
        End If
    End Sub

    'Private Sub Form_SnippingTool_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
    '    Cancel()
    'End Sub

    Private Sub Form_SnippingTool_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If LastButton = Windows.Forms.MouseButtons.None AndAlso (e.Button = Windows.Forms.MouseButtons.Left OrElse (e.Button = Windows.Forms.MouseButtons.Right And NewSaveForm Is Nothing)) Then
            FirstPoint = e.Location
            LastPoint = e.Location
            LastButton = e.Button
        End If
    End Sub

    Private Sub Form_SnippingTool_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = LastButton AndAlso Not LastButton = Windows.Forms.MouseButtons.None Then
            LastPoint = e.Location
            CalculateArea()
        End If
    End Sub

    Private Sub Form_SnippingTool_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.Button = LastButton AndAlso Not LastButton = Windows.Forms.MouseButtons.None AndAlso w > 3 AndAlso h > 3 Then
            LastPoint = e.Location
            CalculateArea()
            Crop()
        ElseIf e.Button = Windows.Forms.MouseButtons.Right AndAlso w < 3 AndAlso h < 3 Then
            ShowMenu()
        End If

        If LastButton = e.Button Then LastButton = Windows.Forms.MouseButtons.None
    End Sub

    Private Sub Form_SnippingTool_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel

    End Sub

    Private Sub Menu_Snip_FullScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Snip_FullScreen.Click
        Me.Hide()

        Dim b As New Bitmap(vs.Width, vs.Height)

        Dim g As Graphics = Graphics.FromImage(b)

        g.CopyFromScreen(vl.X, vl.Y, 0, 0, vs)

        SaveForm.Images.Add(b)

        SaveForm.Show()

        Me.Close()
    End Sub

    Private Sub Menu_Snip_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Snip_Exit.Click
        Me.Close()
    End Sub

    Private Sub Menu_Snip_FromClipboard_Click(sender As Object, e As EventArgs) Handles Menu_Snip_FromClipboard.Click
        If Clipboard.ContainsImage() Then

            SaveForm.Images.Add(Clipboard.GetImage())
            SaveForm.Show()

            Me.Close()
            Return
        ElseIf Clipboard.ContainsText() Then
            Dim paths = Clipboard.GetText()


            For Each path As String In paths.Split("""", "'", ";", vbCr, vbLf)
                path = path.Trim().Trim("""", "'")
                Try
                    Dim LocalPath = (New Uri(path)).LocalPath
                    Dim TempImage As Screenshot = Image.FromFile(LocalPath)
                    TempImage.OriginalPath = LocalPath
                    SaveForm.Images.Add(TempImage)
                Catch ex As Exception

                End Try
            Next
            If SaveForm.Images.Count Then
                SaveForm.Show()
                Me.Close()
                Return
            End If
        ElseIf Clipboard.ContainsFileDropList() Then
            Dim l As StringCollection = Clipboard.GetFileDropList()


            For Each path As String In l
                path = path.Trim().Trim("""", "'")
                Try
                    Dim LocalPath = (New Uri(path)).LocalPath
                    Dim TempImage As Screenshot = Image.FromFile(LocalPath)
                    TempImage.OriginalPath = LocalPath
                    SaveForm.Images.Add(TempImage)
                Catch ex As Exception

                End Try
            Next
            If SaveForm.Images.Count Then
                SaveForm.Show()
                Me.Close()
                Return
            End If
        End If

        MsgBox("No image or image file path in clipboard.", MsgBoxStyle.Critical)
    End Sub

    Private Sub Menu_Snip_FromFile_Click(sender As Object, e As EventArgs) Handles Menu_Snip_FromFile.Click
        Dim od As New OpenFileDialog()
        od.AutoUpgradeEnabled = True
        od.CheckFileExists = True
        od.CheckPathExists = True
        od.Multiselect = True
        od.Filter = "All supported files|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpeg;*.jpg;*.png;*.tiff;*.wmf;"

        Me.Hide()

        If od.ShowDialog(SaveForm) = Windows.Forms.DialogResult.OK Then
            For Each path As String In od.FileNames
                Do
                    path = path.Trim().Trim("""", "'")
                    Try
                        Dim LocalPath = (New Uri(path)).LocalPath
                        Dim TempImage As Screenshot = Image.FromFile(LocalPath)
                        TempImage.OriginalPath = LocalPath
                        SaveForm.Images.Add(TempImage)
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

            SaveForm.Show()
            Me.Close()
            Return
        End If

        Me.Show()
    End Sub

    Private Sub Menu_Snip_Album_Click(sender As Object, e As EventArgs) Handles Menu_Snip_Album.Click
        Form_Save_Album.Show()
        Me.Close()
    End Sub

    Private Sub Menu_Snip_History_Click(sender As Object, e As EventArgs) Handles Menu_Snip_History.Click
        Form_History.Show()
        Me.Close()
    End Sub
End Class
