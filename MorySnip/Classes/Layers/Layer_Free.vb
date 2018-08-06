Public Class Layer_Free
    Inherits Layer

    Dim PathValue As New Drawing2D.GraphicsPath
    Public ReadOnly Property Path As Drawing2D.GraphicsPath
        Get
            Return PathValue
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub New(Pen As Pen, Brush As Brush, FirstPoint As Point)
        Me.Pen = Pen
        Me.Brush = Brush
        Me.Start(FirstPoint)
    End Sub

    Public Overrides Sub [Step](StepPoint As Point)
        Path.AddLine(LastPoint, StepPoint)
        MyBase.Step(StepPoint)
    End Sub

    Public Overrides Sub [Stop](LastPoint As Point)
        Path.AddLine(Me.LastPoint, LastPoint)
        MyBase.[Stop](LastPoint)
    End Sub

    Public Overrides ReadOnly Property Bounds() As Rectangle
        Get
            Dim x, y, w, h As Integer, IsFirst As Boolean = True
            For Each item As PointF In PathValue.PathPoints
                If IsFirst Then
                    IsFirst = False
                    x = item.X
                    y = item.Y
                    w = item.X
                    h = item.Y
                End If

                If x > item.X Then x = item.X
                If y > item.Y Then y = item.Y
                If w < item.X Then w = item.X
                If h < item.Y Then h = item.Y
            Next

            Return New Rectangle(x, y, w - x, h - y)
        End Get
    End Property

    Public Overrides Sub Paint(g As Graphics)
        If Me.Fill Then
            g.FillPath(Brush, Path)
        End If
        g.DrawPath(Pen, Path)
    End Sub
End Class
