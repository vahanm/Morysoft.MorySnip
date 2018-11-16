Public Enum ArrowModes As Byte
    AtStart
    AtEnd
    Both
End Enum

Public Class Layer_Arrow
    Inherits Layer

    Public Sub New()

    End Sub

    Public Sub New(Pen As Pen, Brush As Brush, FirstPoint As Point, ArrowMode As ArrowModes)
        Me.Pen = Pen
        Me.Brush = Brush
        Me.ArrowMode = ArrowMode
        Me.Start(FirstPoint)
    End Sub
    Public Property ArrowMode() As ArrowModes

    Public Overrides Sub Paint(g As Graphics)
        Dim DrawArrow = Sub(PBegin As Point, PEnd As Point)
                            Dim A1 As Single = 0.5
                            Dim A2 As Single = 0.4

                            Dim NewZero As Polar = PBegin - PEnd

                            Dim TailPolar11 As New Polar(NewZero.Angle - A1, NewZero.Radius / 10)
                            Dim TailPolar12 As New Polar(NewZero.Angle - A2, NewZero.Radius / 20)
                            Dim TailPolar21 As New Polar(NewZero.Angle + A1, NewZero.Radius / 10)
                            Dim TailPolar22 As New Polar(NewZero.Angle + A2, NewZero.Radius / 20)

                            Dim Tail11 As Point = PEnd + TailPolar11
                            Dim Tail12 As Point = PEnd + TailPolar12
                            Dim Tail21 As Point = PEnd + TailPolar21
                            Dim Tail22 As Point = PEnd + TailPolar22

                            g.DrawCurve(Me.Pen, New Point() {Tail11, Tail12, PEnd}, 0.5)
                            g.DrawCurve(Me.Pen, New Point() {Tail21, Tail22, PEnd}, 0.5)
                        End Sub


        g.DrawLine(Me.Pen, Me.FirstPoint, Me.LastPoint)

        Select Case Me.ArrowMode
            Case ArrowModes.AtEnd
                DrawArrow(Me.FirstPoint, Me.LastPoint)
            Case ArrowModes.AtStart
                DrawArrow(Me.LastPoint, Me.FirstPoint)
            Case ArrowModes.Both
                DrawArrow(Me.LastPoint, Me.FirstPoint)
                DrawArrow(Me.FirstPoint, Me.LastPoint)
        End Select
    End Sub

    Public Overrides Sub Render(g As Graphics)
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Me.Paint(g)
    End Sub
End Class
