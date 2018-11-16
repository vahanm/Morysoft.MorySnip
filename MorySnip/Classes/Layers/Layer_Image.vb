Public Class Layer_Image
    Inherits Layer

    Public Sub New(Image As Image)
        Me.Image = Image
        Me.LastPoint = Image.Size
    End Sub

    Public Property Image() As Image

    Public Overrides Sub Paint(g As Graphics)
        g.DrawImage(Me.Image, Me.Bounds)
    End Sub
End Class
