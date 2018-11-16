Public MustInherit Class Layer
    Public Property Offset() As Point
    Public Property Fill() As Boolean
    Public Property Pen() As Pen
    Public Property Brush() As Brush
    Public Property FirstPoint() As Point
    Public Property LastPoint() As Point

    Public Overridable Sub Start(FirstPoint As Point)
        Me.FirstPoint = FirstPoint
        Me.LastPoint = FirstPoint
    End Sub

    Public Overridable Sub [Step](StepPoint As Point)
        Me.LastPoint = StepPoint
    End Sub

    Public Overridable Sub [Stop](LastPoint As Point)
        Me.LastPoint = LastPoint
        If Me.Pen IsNot Nothing Then Me.Pen = Me.Pen.Clone()
        If Me.Brush IsNot Nothing Then Me.Brush = Me.Brush.Clone()
    End Sub

    Public Overridable ReadOnly Property Bounds() As Rectangle
        Get
            Return NormalRectingle(Me.FirstPoint, Me.LastPoint)
        End Get
    End Property

    Public Function InBounds(p As Point) As Boolean
        With Me.Bounds
            Return p.X > .X AndAlso p.Y > .Y AndAlso p.X < .X + .Width AndAlso p.Y < .Y + .Height
        End With
    End Function

    Public Overridable Sub Render(g As Graphics)
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Me.Paint(g)
    End Sub

    Public MustOverride Sub Paint(g As Graphics)
End Class
