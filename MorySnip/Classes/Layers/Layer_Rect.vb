Public Class Layer_Rect
    Inherits Layer

    Public Sub New(Pen As Pen, Brush As Brush, FirstPoint As Point)
        Me.Pen = Pen
        Me.Brush = Brush
        Me.Start(FirstPoint)
    End Sub

    Public Overrides Sub Paint(g As Graphics)
        Dim r As Rectangle = Me.Bounds

        If Me.Fill Then
            g.FillRectangle(Me.Brush, r)
        End If

        g.DrawRectangle(Me.Pen, r)
    End Sub
End Class
