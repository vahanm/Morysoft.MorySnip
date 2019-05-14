Imports System.Drawing.Drawing2D

Public Class Editor
    Dim PreviousSteps As New List(Of Image)
    Dim NextSteps As New List(Of Image)
    Dim Layers As New List(Of Layer)
    Dim ImagePosition As New Point(0, 0)

    Dim LastButton As MouseButtons = MouseButtons.None
    Dim _LastNumber As Integer = 1

    Public Event LastNumberChanged(sender As Object, e As EventArgs)

    Public Sub CreateCheckpoint(Optional Image As Image = Nothing)
        If Image Is Nothing Then
            Image = Me.GetResult()
        End If
        Me.PreviousSteps.Add(Image)
        Me.NextSteps.Clear()
    End Sub

    Public Property LastNumber As Integer
        Get
            Return Me._LastNumber
        End Get
        Set(value As Integer)
            Me._LastNumber = value

            RaiseEvent LastNumberChanged(Me, New EventArgs())
        End Set
    End Property

    Public ReadOnly Property CanRedo As Boolean
        Get
            Return Me.NextSteps.Count > 0
        End Get
    End Property

    Public ReadOnly Property CanUndo As Boolean
        Get
            Return Me.PreviousSteps.Count > 0
        End Get
    End Property

    Public Sub Redo()
        If Me.CanRedo Then
            Me.PreviousSteps.Add(Me.GetResult())
            Me.BackgroundImage = Me.NextSteps(Me.NextSteps.Count - 1)
            Me.NextSteps.RemoveAt(Me.NextSteps.Count - 1)
        End If
    End Sub

    Public Sub Undo()
        If Me.CanUndo Then
            Me.NextSteps.Add(Me.GetResult())
            Me.Layers.Clear()
            Me.BackgroundImage = Me.PreviousSteps(Me.PreviousSteps.Count - 1)
            Me.PreviousSteps.RemoveAt(Me.PreviousSteps.Count - 1)
        End If
    End Sub

    Public Sub Render()
        Dim result As Image = Me.GetResult()

        Me.BackgroundImage = result

        Me.Layers.Clear()
        Me.ImagePosition = New Point()
    End Sub

    Public Function GetResult() As Image
        Dim result As New Bitmap(Me.Width, Me.Height)

        Dim g As Graphics = Graphics.FromImage(result)

        g.Clear(Color.White)

        If Me.Img IsNot Nothing Then
            g.DrawImage(Me.Img, Me.ImagePosition.X, Me.ImagePosition.Y, Me.Img.Size.Width, Me.Img.Size.Height)
        End If

        For Each l As Layer In Me.Layers
            l.Render(g)
        Next
        Return result
    End Function
    Public ReadOnly Property CurrentPen As New Pen(Brushes.Red, 2) With {.StartCap = LineCap.Round, .EndCap = LineCap.Round, .Alignment = PenAlignment.Inset}

    Dim CurrentBrushValue As New SolidBrush(Color.Red)
    Public Property CurrentBrush As Brush
        Get
            Return Me.CurrentBrushValue
        End Get
        Set(value As Brush)
            Me.CurrentBrushValue = value
        End Set
    End Property

    Private Property Img() As Bitmap
        Get
            Return Me.BackgroundImage
        End Get
        Set(ByVal value As Bitmap)
            Me.ImagePosition.X = 0
            Me.ImagePosition.Y = 0
            Me.BackgroundImage = value
        End Set
    End Property

    Dim GrayedAreaBrush As New SolidBrush(Color.FromArgb(200, 0, 0, 0))
    Dim HighlightColor As Color = Color.FromArgb(100, Color.Yellow)
    Dim HighlightBrush As New SolidBrush(Me.HighlightColor)

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        g.Clear(Color.White)

        If Me.Img Is Nothing Then
            g.DrawString("NO IMAGE !!!", Me.Font, Brushes.Red, 5, 5)
        Else
            g.DrawImage(Me.Img, Me.ImagePosition.X, Me.ImagePosition.Y, Me.Img.Size.Width, Me.Img.Size.Height)
        End If

        For Each l As Layer In Me.Layers
            l.Render(g)
        Next

        If Me.NewLayer IsNot Nothing Then
            Me.NewLayer.Paint(g)
        End If
    End Sub

    Public Enum PaintModes
        Free
        Line
        Arrow
        Oval
        Rect
        Number

        Highlight
        Invert
        Blur
        Puzzle
        Crop
        Grayscale
    End Enum

    Dim _PaintMode As PaintModes = PaintModes.Free
    Dim _PaintModeLast As PaintModes = PaintModes.Free

    Public Sub SetLastPaintMode()
        Me.PaintMode = Me._PaintModeLast
    End Sub

    Public Property PaintMode() As PaintModes
        Get
            Return Me._PaintMode
        End Get
        Set(ByVal value As PaintModes)
            Me._PaintModeLast = Me._PaintMode
            Me._PaintMode = value
        End Set
    End Property

    Public Property FillObjecs() As Boolean = True

    Dim Painting As Boolean = False
    Dim PBegin As Point
    Dim PEnd As Point

    Private Sub Editor_BackgroundImageChanged(sender As Object, e As EventArgs) Handles Me.BackgroundImageChanged
        Me.ResetImageSizeAndPosition()
    End Sub

    Public Sub ResetImageSizeAndPosition()
        If Me.BackgroundImage IsNot Nothing Then
            Me.Size = Me.BackgroundImage.Size
            Me.ImagePosition = New Point()
            Me.Refresh()
        End If
    End Sub

    Private Sub Editor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape AndAlso e.Control = False Then
            Me.NewLayer = Nothing
            Me.Refresh()
        End If
    End Sub

    Dim NewLayer As Layer

    Private Sub Editor_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If Me.LastButton = MouseButtons.Left AndAlso e.Button = MouseButtons.Right OrElse Me.LastButton = MouseButtons.Right AndAlso e.Button = MouseButtons.Left Then
            If TypeOf Me.NewLayer Is Layer_Arrow Then
                Dim NewLayerArrow As Layer_Arrow = Me.NewLayer
                Select Case NewLayerArrow.ArrowMode
                    Case ArrowModes.AtEnd
                        NewLayerArrow.ArrowMode = ArrowModes.AtStart
                    Case ArrowModes.AtStart
                        NewLayerArrow.ArrowMode = ArrowModes.Both
                    Case ArrowModes.Both
                        NewLayerArrow.ArrowMode = ArrowModes.AtEnd
                End Select
            End If
        End If
    End Sub

    Private Sub Editor_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        If Me.LastButton = MouseButtons.None Then
            Me.LastButton = e.Button

            Select Case e.Button
                Case MouseButtons.Left, MouseButtons.Right
                    Select Case Me.PaintMode
                        Case PaintModes.Line
                            If e.Button = MouseButtons.Right Then
                                Me.CurrentPen.DashStyle = DashStyle.DashDotDot
                            End If
                            Me.NewLayer = New Layer_Line(Me.CurrentPen, e.Location)
                        Case PaintModes.Rect
                            Me.NewLayer = New Layer_Rect(Me.CurrentPen, Me.CurrentBrush, e.Location) With {.Fill = e.Button = MouseButtons.Right Xor Me.FillObjecs}
                        Case PaintModes.Number
                            Me.NewLayer = New Layer_Number(Me.CurrentPen, Me.CurrentBrush, e.Location, Me.LastNumber) With {.Fill = e.Button = MouseButtons.Right Xor Me.FillObjecs}
                        Case PaintModes.Oval
                            Me.NewLayer = New Layer_Oval(Me.CurrentPen, Me.CurrentBrush, e.Location) With {.Fill = e.Button = MouseButtons.Right Xor Me.FillObjecs}
                        Case PaintModes.Free
                            Me.NewLayer = New Layer_Free(Me.CurrentPen, Me.CurrentBrush, e.Location) With {.Fill = e.Button = MouseButtons.Right Xor Me.FillObjecs}
                        Case PaintModes.Arrow
                            Me.NewLayer = New Layer_Arrow(Me.CurrentPen, Me.CurrentBrush, e.Location, ArrowMode:=If(e.Button = MouseButtons.Right, ArrowModes.AtStart, ArrowModes.AtEnd))
                        Case PaintModes.Invert
                            Me.NewLayer = New Layer_Action(e.Location, Actions.Invert, IIf(e.Button = MouseButtons.Right, Zones.NotSelected, Zones.Selected))
                        Case PaintModes.Blur
                            Me.NewLayer = New Layer_Action(e.Location, Actions.Blur, IIf(e.Button = MouseButtons.Right, Zones.NotSelected, Zones.Selected))
                        Case PaintModes.Puzzle
                            Me.NewLayer = New Layer_Action(e.Location, Actions.Puzzle, IIf(e.Button = MouseButtons.Right, Zones.NotSelected, Zones.Selected))
                        Case PaintModes.Grayscale
                            Me.NewLayer = New Layer_Action(e.Location, Actions.Grayscale, IIf(e.Button = MouseButtons.Right, Zones.NotSelected, Zones.Selected))
                        Case PaintModes.Highlight
                            Me.NewLayer = New Layer_Action(e.Location, Actions.Highlight, Zones.Selected)
                        Case PaintModes.Crop
                            Me.NewLayer = New Layer_Action(e.Location, Actions.Crop, Zones.Selected)
                    End Select

                Case MouseButtons.Middle
                    Me.PBegin = e.Location
                Case Else
                    Me.LastButton = MouseButtons.None
            End Select
        End If
    End Sub

    Private Sub Editor_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = Me.LastButton And Not Me.LastButton = MouseButtons.None Then
            Select Case e.Button
                Case MouseButtons.Left, MouseButtons.Right
                    If Me.NewLayer IsNot Nothing Then
                        Me.NewLayer.Step(e.Location)
                    End If
                Case MouseButtons.Middle
                    Me.ImagePosition.X += (e.Location - Me.PBegin).X
                    Me.ImagePosition.Y += (e.Location - Me.PBegin).Y

                    Me.PBegin = e.Location
            End Select

            Me.Refresh()
        End If
    End Sub

    Private Sub Editor_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = Me.LastButton And Not Me.LastButton = MouseButtons.None Then
            Select Case e.Button
                Case MouseButtons.Left, MouseButtons.Right
                    If Me.NewLayer IsNot Nothing Then
                        Me.NewLayer.Stop(e.Location)
                        Me.CreateCheckpoint()

                        If TypeOf Me.NewLayer Is Layer_Action Then
                            Dim ActionLayer As Layer_Action = Me.NewLayer
                            Me.Render()
                            Me.BackgroundImage = ApplyAction(Me.BackgroundImage, ActionLayer.Action, ActionLayer.Zone, ActionLayer.Bounds)
                        Else
                            If TypeOf Me.NewLayer Is Layer_Number Then
                                Me.LastNumber += 1
                            End If
                            If TypeOf Me.NewLayer Is Layer_Line AndAlso Me.LastButton = MouseButtons.Right Then
                                Me.CurrentPen.DashStyle = DashStyle.Solid
                            End If
                            Me.Layers.Add(Me.NewLayer)
                        End If

                        Me.NewLayer = Nothing
                    End If
                Case MouseButtons.Middle
                    Me.ImagePosition.X += (e.Location - Me.PBegin).X
                    Me.ImagePosition.Y += (e.Location - Me.PBegin).Y

                    Me.PBegin = e.Location
            End Select

            Me.LastButton = MouseButtons.None

            Me.Refresh()
        End If
    End Sub

    Public Sub RotateFlip(ByVal value As RotateFlipType)
        Me.Render()
        Me.Img.RotateFlip(value)
        Me.ResetImageSizeAndPosition()
    End Sub

    Private Sub Editor_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If Me.NewLayer IsNot Nothing Then
            If e.Delta > 0 Then
                If Me.CurrentPen.Width < 30 Then Me.CurrentPen.Width += 1
            Else
                If Me.CurrentPen.Width > 1 Then Me.CurrentPen.Width -= 1
            End If
            Me.Refresh()
            CType(e, HandledMouseEventArgs).Handled = True
        End If
    End Sub
End Class
