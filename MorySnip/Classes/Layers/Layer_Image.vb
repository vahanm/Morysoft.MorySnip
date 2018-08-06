Public Class Layer_Image
    Inherits Layer

    Public Sub New()

    End Sub

    Public Sub New(Image As Image)
        Me.Image = Image
        Me.LastPoint = Image.Size
    End Sub

    Private ImageValue As Image
    Public Property Image() As Image
        Get
            Return Me.ImageValue
        End Get
        Set(ByVal value As Image)
            Me.ImageValue = value
        End Set
    End Property

    Public Overrides Sub Paint(g As Graphics)
        g.DrawImage(Me.Image, Me.Bounds)
    End Sub
End Class
