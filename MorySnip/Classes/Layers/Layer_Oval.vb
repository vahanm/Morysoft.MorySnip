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
        Dim r As Rectangle = Me.Bounds

        If Me.Fill Then
            g.FillEllipse(Me.Brush, r)
        End If
        g.DrawEllipse(Me.Pen, r)
    End Sub
End Class
