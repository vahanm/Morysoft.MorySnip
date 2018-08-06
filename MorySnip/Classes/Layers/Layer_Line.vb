Public Class Layer_Line
    Inherits Layer

    Public Sub New()

    End Sub

    Public Sub New(Pen As Pen, FirstPoint As Point)
        Me.Pen = Pen
        Me.Start(FirstPoint)
    End Sub

    Public Overrides Sub Paint(g As Graphics)
        g.DrawLine(Pen, FirstPoint, LastPoint)
    End Sub
End Class
