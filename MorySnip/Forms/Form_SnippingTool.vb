Imports System.Collections.Specialized
Imports System.Linq
Imports System.Windows.Forms

Public Class Form_SnippingTool
    Dim x, y, w, h As Integer
    Dim FirstPoint As Point
    Dim LastPoint As Point
    Dim LastButton As MouseButtons = MouseButtons.None

    Dim bordersOnlyMode As Boolean = False

    Private Sub CalculateArea()
        If Me.FirstPoint.X < Me.LastPoint.X Then
            Me.x = Me.FirstPoint.X
            Me.w = Me.LastPoint.X - Me.FirstPoint.X
        Else
            Me.x = Me.LastPoint.X
            Me.w = Me.FirstPoint.X - Me.LastPoint.X
        End If
        If Me.FirstPoint.Y < Me.LastPoint.Y Then
            Me.y = Me.FirstPoint.Y
            Me.h = Me.LastPoint.Y - Me.FirstPoint.Y
        Else
            Me.y = Me.LastPoint.Y
            Me.h = Me.FirstPoint.Y - Me.LastPoint.Y
        End If

        If My.Computer.Keyboard.CtrlKeyDown Then
            Me.w = Math.Max(Me.w, Me.h)
            Me.h = Math.Max(Me.w, Me.h)
        End If

        If My.Computer.Keyboard.ShiftKeyDown Then
            Me.x = Me.FirstPoint.X - Me.w
            Me.y = Me.FirstPoint.Y - Me.h
            Me.w *= 2
            Me.h *= 2
        End If

        Me.Refresh()
    End Sub

    Private Sub Crop()
        Dim capture = Sub()
                          Me.Opacity = 0
                          Me.Refresh()

                          Dim b As New Bitmap(Me.w, Me.h)
                          Dim g As Graphics = Graphics.FromImage(b)

                          g.CopyFromScreen(Me._virtualScreenLocation.X + Me.x, Me._virtualScreenLocation.Y + Me.y, 0, 0, New Size(Me.w, Me.h))

                          Me.SaveForm.Images.Add(b)

                          Me.Opacity = 1
                          Me.Refresh()
                      End Sub

        Select Case Me.LastButton
            Case MouseButtons.Left
                Me.Hide()

                If My.Computer.Keyboard.AltKeyDown Then
                    Dim acf As New Form_AutoCapture()

                    If acf.ShowDialog() = DialogResult.OK Then
                        Dim wait = Sub(milliseconds As Integer)
                                       Process.GetCurrentProcess().WaitForExit(milliseconds)
                                   End Sub

                        Dim waitMilliseconds As Integer = acf.NumericUpDown_Start.Value * 1000
                        Dim intervalMilliseconds As Integer = acf.NumericUpDown_Interval.Value
                        Dim count As Integer = acf.NumericUpDown_Count.Value

                        Me.bordersOnlyMode = True
                        Me.Opacity = 1
                        Me.Show()
                        Me.Refresh()

                        For i As Integer = 1 To count
                            wait(IIf(i = 1, waitMilliseconds, intervalMilliseconds))
                            capture()
                        Next
                    Else
                        End
                    End If
                Else
                    capture()
                End If

                Me.SaveForm.Show()
                Me.Close()

            Case MouseButtons.Right
                Me.Hide()
                capture()
                Me.SaveForm.Show()
                Me.Close()
        End Select
    End Sub

    Private Sub Cancel()
        Me.LastButton = MouseButtons.None
        Me.x = 0
        Me.y = 0
        Me.w = 0
        Me.h = 0

        Me.Refresh()
    End Sub

    Private Sub ShowMenu()
        Me.Menu_Snip.Show(Cursor.Position)
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        g.Clear(Color.Black)

        If Me.w > 3 AndAlso Me.h > 3 AndAlso Not Me.LastButton = MouseButtons.None Then
            If Me.bordersOnlyMode Then
                g.Clear(Me.TransparencyKey)
                g.DrawRectangle(New Pen(Color.Red, 2), Me.x, Me.y, Me.w, Me.h)
            Else
                'g.DrawLine(New Pen(Brushes.DarkOrange, 2), x, y - 5, x + w, y - 5)

                'g.DrawLine(New Pen(Brushes.DarkOrange, 2), x - 5, y, x - 5, y + h)

                g.FillRectangle(New SolidBrush(Me.TransparencyKey), Me.x, Me.y, Me.w + 1, Me.h + 1)
                'g.DrawRectangle(Pens.Red, x, y, w, h)
                g.DrawRectangle(Pens.Red, -10, Me.y, 10000, Me.h + 1)
                g.DrawRectangle(Pens.Red, Me.x, -10, Me.w + 1, 10000)

                Dim r1 = ReduceRatio(Me.w \ 10, Me.h \ 10)
                Dim r2 = ReduceRatio(Me.w, Me.h)
                Dim approximate As Boolean = Not r1 = r2

                g.DrawString(String.Format("{0:# ##0px} - {1:# ##0px} -- {4}{2}:{3}", Me.w, Me.h, r1.Width, r1.Height, IIf(approximate, "≈", "")), New Font(Me.Font.FontFamily, 11, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.White, Me.x, Me.y - 14)
            End If
        Else
            If My.Computer.Mouse.ButtonsSwapped Then
                g.DrawString(My.Resources.PressLeftClickToViewOptions, New Font(Me.Font.FontFamily, 40, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.DarkGray, -Me._virtualScreenLocation.X + Me._primaryScreenLocation.X + 10, -Me._virtualScreenLocation.Y + Me._primaryScreenLocation.Y + Me._primaryScreenSize.Height \ 2 - 20)
            Else
                g.DrawString(My.Resources.PressRightClickToViewOptions, New Font(Me.Font.FontFamily, 40, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.DarkGray, -Me._virtualScreenLocation.X + Me._primaryScreenLocation.X + 10, -Me._virtualScreenLocation.Y + Me._primaryScreenLocation.Y + Me._primaryScreenSize.Height \ 2 - 20)
            End If
        End If
    End Sub

    Private Sub Form_SnippingTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = SystemInformation.VirtualScreen.Location
        Me.Size = SystemInformation.VirtualScreen.Size
    End Sub

    Private Sub Form_SnippingTool_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Me.LastButton = MouseButtons.None Then
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
        If Me.LastButton = MouseButtons.None Then
            Select Case e.KeyCode
                Case Keys.Apps
                    ShowMenu()
            End Select
        Else
            CalculateArea()
        End If
    End Sub

    Private Sub Form_SnippingTool_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        If Me.LastButton = MouseButtons.None Then
            Me.FirstPoint = e.Location
            Me.LastPoint = e.Location
            Me.LastButton = e.Button
        End If
    End Sub

    Private Sub Form_SnippingTool_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = Me.LastButton AndAlso Not Me.LastButton = MouseButtons.None Then
            Me.LastPoint = e.Location
            Me.CalculateArea()
        End If
    End Sub

    Private Sub Form_SnippingTool_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = Me.LastButton Then
            If Not Me.LastButton = MouseButtons.None AndAlso Me.w > 3 AndAlso Me.h > 3 Then
                Me.LastPoint = e.Location
                Me.CalculateArea()
                Me.Crop()
            ElseIf e.Button = MouseButtons.Right AndAlso Me.w < 3 AndAlso Me.h < 3 Then
                Me.ShowMenu()
            End If

            Me.LastButton = MouseButtons.None
        End If
    End Sub

    Private Sub Menu_Snip_FullScreen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Menu_Snip_FullScreen.Click
        Me.Snip_FullScreen()
    End Sub

    Private Sub Menu_Snip_Exit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Menu_Snip_Exit.Click
        Me.Close()
    End Sub

    Private Sub Menu_Snip_FromClipboard_Click(sender As Object, e As EventArgs) Handles Menu_Snip_FromClipboard.Click
        Me.Snip_FromClipboard()
    End Sub

    Private Sub Menu_Snip_FromFile_Click(sender As Object, e As EventArgs) Handles Menu_Snip_FromFile.Click
        Me.Snip_FromFile()
    End Sub
End Class
