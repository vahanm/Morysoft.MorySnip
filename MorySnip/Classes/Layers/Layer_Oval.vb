Public Class Layer_Oval
    Inherits Layer

    Public Sub New()

    End Sub

    Public Sub New(Pen As Pen, Brush As Brush, FirstPoint As Point)
        Me.Pen = Pen
        Me.Brush = Brush
        Me.Start(FirstPoint)
    End Sub

    Public Overrides Sub Paint(g As Graphics)
        Dim r As Rectangle = Bounds

        If Me.Fill Then
            g.FillEllipse(Brush, r)
        End If
        g.DrawEllipse(Pen, r)
    End Sub
End Class
