Public MustInherit Class Layer
    Private OffsetValue As Point
    Public Property Offset() As Point
        Get
            Return OffsetValue
        End Get
        Set(ByVal value As Point)
            OffsetValue = value
        End Set
    End Property

    Private FillValue As Boolean
    Public Property Fill() As Boolean
        Get
            Return FillValue
        End Get
        Set(ByVal value As Boolean)
            FillValue = value
        End Set
    End Property

    Private PenValue As Pen
    Public Property Pen() As Pen
        Get
            Return PenValue
        End Get
        Set(ByVal value As Pen)
            PenValue = value
        End Set
    End Property

    Private BrushValue As Brush
    Public Property Brush() As Brush
        Get
            Return BrushValue
        End Get
        Set(ByVal value As Brush)
            BrushValue = value
        End Set
    End Property

    Private FirstPointValue As Point
    Public Property FirstPoint() As Point
        Get
            Return FirstPointValue
        End Get
        Set(ByVal value As Point)
            FirstPointValue = value
        End Set
    End Property

    Private LastPointValue As Point
    Public Property LastPoint() As Point
        Get
            Return LastPointValue
        End Get
        Set(ByVal value As Point)
            LastPointValue = value
        End Set
    End Property

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
            Return NormalRectingle(FirstPoint, LastPoint)
        End Get
    End Property

    Public Function InBounds(p As Point) As Boolean
        With Bounds
            Return p.X > .X AndAlso p.Y > .Y AndAlso p.X < .X + .Width AndAlso p.Y < .Y + .Height
        End With
    End Function

    Public Overridable Sub Render(g As Graphics)
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Paint(g)
    End Sub

    Public MustOverride Sub Paint(g As Graphics)
End Class
