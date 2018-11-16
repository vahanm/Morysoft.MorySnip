Public Class Layer_Free
    Inherits Layer
    Public ReadOnly Property Path As New Drawing2D.GraphicsPath

    Public Sub New()

    End Sub

    Public Sub New(Pen As Pen, Brush As Brush, FirstPoint As Point)
        Me.Pen = Pen
        Me.Brush = Brush
        Me.Start(FirstPoint)
    End Sub

    Public Overrides Sub [Step](StepPoint As Point)
        Me.Path.AddLine(Me.LastPoint, StepPoint)
        MyBase.Step(StepPoint)
    End Sub

    Public Overrides Sub [Stop](LastPoint As Point)
        Me.Path.AddLine(Me.LastPoint, LastPoint)
        MyBase.[Stop](LastPoint)
    End Sub

    Public Overrides ReadOnly Property Bounds() As Rectangle
        Get
            Dim x, y, w, h As Integer, IsFirst As Boolean = True
            For Each item As PointF In Me.Path.PathPoints
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
            g.FillPath(Me.Brush, Me.Path)
        End If
        g.DrawPath(Me.Pen, Me.Path)
    End Sub
End Class
