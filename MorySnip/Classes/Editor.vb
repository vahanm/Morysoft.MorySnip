Imports System.Drawing.Drawing2D

Public Class Editor
    Dim PreviousSteps As New List(Of Image)
    Dim NextSteps As New List(Of Image)
    Dim Layers As New List(Of Layer)
    Dim ImagePosition As New Point(0, 0)

    Dim LastButton As MouseButtons = Windows.Forms.MouseButtons.None

    Dim LastNUmber As Integer = 1

    Public Sub CreateCheckpoint(Optional Image As Image = Nothing)
        If Image Is Nothing Then
            Image = GetResult()
        End If
        PreviousSteps.Add(Image)
        NextSteps.Clear()
    End Sub

    Public ReadOnly Property CanRedo As Boolean
        Get
            Return NextSteps.Count > 0
        End Get
    End Property

    Public ReadOnly Property CanUndo As Boolean
        Get
            Return PreviousSteps.Count > 0
        End Get
    End Property

    Public Sub Redo()
        If CanRedo Then
            PreviousSteps.Add(GetResult())
            Me.BackgroundImage = NextSteps(NextSteps.Count - 1)
            NextSteps.RemoveAt(NextSteps.Count - 1)
        End If
    End Sub

    Public Sub Undo()
        If CanUndo Then
            NextSteps.Add(GetResult())
            Layers.Clear()
            Me.BackgroundImage = PreviousSteps(PreviousSteps.Count - 1)
            PreviousSteps.RemoveAt(PreviousSteps.Count - 1)
        End If
    End Sub

    Public Sub Render()
        Dim result As Image = GetResult()

        Me.BackgroundImage = result

        Layers.Clear()
        ImagePosition = New Point()
    End Sub

    Public Function GetResult() As Image
        Dim result As New Bitmap(Me.Width, Me.Height)

        Dim g As Graphics = Graphics.FromImage(result)

        g.Clear(Color.White)

        If Img IsNot Nothing Then
            g.DrawImage(Img, ImagePosition.X, ImagePosition.Y, Img.Size.Width, Img.Size.Height)
        End If

        For Each l As Layer In Layers
            l.Render(g)
        Next
        Return result
    End Function

    Dim CurrentPenValue As New Pen(Brushes.Red, 2) With {.StartCap = LineCap.Round, .EndCap = LineCap.Round, .Alignment = PenAlignment.Inset}
    Public ReadOnly Property CurrentPen As Pen
        Get
            Return CurrentPenValue
        End Get
    End Property

    Dim CurrentBrushValue As New SolidBrush(Color.Red)
    Public Property CurrentBrush As Brush
        Get
            Return CurrentBrushValue
        End Get
        Set(value As Brush)
            CurrentBrushValue = value
        End Set
    End Property

    Private Property Img() As Bitmap
        Get
            Return Me.BackgroundImage
        End Get
        Set(ByVal value As Bitmap)
            ImagePosition.X = 0
            ImagePosition.Y = 0
            Me.BackgroundImage = value
        End Set
    End Property

    Dim GrayedAreaBrush As New SolidBrush(Color.FromArgb(200, 0, 0, 0))
    Dim HighlightColor As Color = Color.FromArgb(100, Color.Yellow)
    Dim HighlightBrush As New SolidBrush(HighlightColor)

    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim g As Graphics = e.Graphics

        g.Clear(Color.White)

        If Img Is Nothing Then
            g.DrawString("NO IMAGE !!!", Me.Font, Brushes.Red, 5, 5)
        Else
            g.DrawImage(Img, ImagePosition.X, ImagePosition.Y, Img.Size.Width, Img.Size.Height)
        End If

        For Each l As Layer In Layers
            l.Render(g)
        Next

        If NewLayer IsNot Nothing Then
            NewLayer.Paint(g)
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
    Dim _FillObjecs As Boolean = True

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

    Public Property FillObjecs() As Boolean
        Get
            Return _FillObjecs
        End Get
        Set(ByVal value As Boolean)
            _FillObjecs = value
        End Set
    End Property

    Dim Painting As Boolean = False
    Dim PBegin As Point
    Dim PEnd As Point

    Private Sub Editor_BackgroundImageChanged(sender As Object, e As EventArgs) Handles Me.BackgroundImageChanged
        ResetImageSizeAndPosition()
    End Sub

    Public Sub ResetImageSizeAndPosition()
        If Me.BackgroundImage IsNot Nothing Then
            Me.Size = Me.BackgroundImage.Size
            ImagePosition = New Point()
            Me.Refresh()
        End If
    End Sub

    Private Sub Editor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape AndAlso e.Control = False Then
            NewLayer = Nothing
            Me.Refresh()
        End If
    End Sub

    Dim NewLayer As Layer

    Private Sub Editor_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If LastButton = Windows.Forms.MouseButtons.Left AndAlso e.Button = Windows.Forms.MouseButtons.Right OrElse LastButton = Windows.Forms.MouseButtons.Right AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
            If TypeOf NewLayer Is Layer_Arrow Then
                Dim NewLayerArrow As Layer_Arrow = NewLayer
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

    Private Sub Editor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If LastButton = Windows.Forms.MouseButtons.None Then
            LastButton = e.Button

            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left, Windows.Forms.MouseButtons.Right
                    Select Case Me.PaintMode
                        Case PaintModes.Line
                            If e.Button = Windows.Forms.MouseButtons.Right Then
                                CurrentPen.DashStyle = DashStyle.DashDotDot
                            End If
                            NewLayer = New Layer_Line(CurrentPen, e.Location)
                        Case PaintModes.Rect
                            NewLayer = New Layer_Rect(CurrentPen, CurrentBrush, e.Location) With {.Fill = e.Button = Windows.Forms.MouseButtons.Right Xor FillObjecs}
                        Case PaintModes.Number
                            NewLayer = New Layer_Number(CurrentPen, CurrentBrush, e.Location, LastNUmber) With {.Fill = e.Button = Windows.Forms.MouseButtons.Right Xor FillObjecs}
                        Case PaintModes.Oval
                            NewLayer = New Layer_Oval(CurrentPen, CurrentBrush, e.Location) With {.Fill = e.Button = Windows.Forms.MouseButtons.Right Xor FillObjecs}
                        Case PaintModes.Free
                            NewLayer = New Layer_Free(CurrentPen, CurrentBrush, e.Location) With {.Fill = e.Button = Windows.Forms.MouseButtons.Right Xor FillObjecs}
                        Case PaintModes.Arrow
                            NewLayer = New Layer_Arrow(CurrentPen, CurrentBrush, e.Location, ArrowMode:=If(e.Button = Windows.Forms.MouseButtons.Right, ArrowModes.AtStart, ArrowModes.AtEnd))
                        Case PaintModes.Invert
                            NewLayer = New Layer_Action(e.Location, Actions.Invert, IIf(e.Button = Windows.Forms.MouseButtons.Right, Zones.NotSelected, Zones.Selected))
                        Case PaintModes.Blur
                            NewLayer = New Layer_Action(e.Location, Actions.Blur, IIf(e.Button = Windows.Forms.MouseButtons.Right, Zones.NotSelected, Zones.Selected))
                        Case PaintModes.Puzzle
                            NewLayer = New Layer_Action(e.Location, Actions.Puzzle, IIf(e.Button = Windows.Forms.MouseButtons.Right, Zones.NotSelected, Zones.Selected))
                        Case PaintModes.Grayscale
                            NewLayer = New Layer_Action(e.Location, Actions.Grayscale, IIf(e.Button = Windows.Forms.MouseButtons.Right, Zones.NotSelected, Zones.Selected))
                        Case PaintModes.Highlight
                            NewLayer = New Layer_Action(e.Location, Actions.Highlight, Zones.Selected)
                        Case PaintModes.Crop
                            NewLayer = New Layer_Action(e.Location, Actions.Crop, Zones.Selected)
                    End Select

                Case Windows.Forms.MouseButtons.Middle
                    PBegin = e.Location
                Case Else
                    LastButton = Windows.Forms.MouseButtons.None
            End Select
        End If
    End Sub

    Private Sub Editor_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = LastButton And Not LastButton = Windows.Forms.MouseButtons.None Then
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left, Windows.Forms.MouseButtons.Right
                    If NewLayer IsNot Nothing Then
                        NewLayer.Step(e.Location)
                    End If
                Case Windows.Forms.MouseButtons.Middle
                    ImagePosition.X += (e.Location - PBegin).X
                    ImagePosition.Y += (e.Location - PBegin).Y

                    PBegin = e.Location
            End Select

            Me.Refresh()
        End If
    End Sub

    Private Sub Editor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.Button = LastButton And Not LastButton = Windows.Forms.MouseButtons.None Then
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left, Windows.Forms.MouseButtons.Right
                    If NewLayer IsNot Nothing Then
                        NewLayer.Stop(e.Location)

                        CreateCheckpoint()

                        If TypeOf NewLayer Is Layer_Action Then
                            Dim ActionLayer As Layer_Action = NewLayer
                            Render()
                            Me.BackgroundImage = ApplyAction(Me.BackgroundImage, ActionLayer.Action, ActionLayer.Zone, ActionLayer.Bounds)
                        Else
                            If TypeOf NewLayer Is Layer_Number Then
                                LastNUmber += 1
                            End If
                            If TypeOf NewLayer Is Layer_Line AndAlso LastButton = Windows.Forms.MouseButtons.Right Then
                                CurrentPen.DashStyle = DashStyle.Solid
                            End If
                            Layers.Add(NewLayer)
                        End If

                        NewLayer = Nothing
                    End If
                Case Windows.Forms.MouseButtons.Middle
                    ImagePosition.X += (e.Location - PBegin).X
                    ImagePosition.Y += (e.Location - PBegin).Y

                    PBegin = e.Location
            End Select

            LastButton = Windows.Forms.MouseButtons.None

            Me.Refresh()
        End If
    End Sub

    Public Sub RotateFlip(ByVal value As RotateFlipType)
        Render()
        Img.RotateFlip(value)
        ResetImageSizeAndPosition()
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
