Public MustInherit Class Layer
    Private OffsetValue As Point
    Public Property Offset() As Point
        Get
            Return Me.OffsetValue
        End Get
        Set(ByVal value As Point)
            Me.OffsetValue = value
        End Set
    End Property

    Private FillValue As Boolean
    Public Property Fill() As Boolean
        Get
            Return Me.FillValue
        End Get
        Set(ByVal value As Boolean)
            Me.FillValue = value
        End Set
    End Property

    Private PenValue As Pen
    Public Property Pen() As Pen
        Get
            Return Me.PenValue
        End Get
        Set(ByVal value As Pen)
            Me.PenValue = value
        End Set
    End Property

    Private BrushValue As Brush
    Public Property Brush() As Brush
        Get
            Return Me.BrushValue
        End Get
        Set(ByVal value As Brush)
            Me.BrushValue = value
        End Set
    End Property

    Private FirstPointValue As Point
    Public Property FirstPoint() As Point
        Get
            Return Me.FirstPointValue
        End Get
        Set(ByVal value As Point)
            Me.FirstPointValue = value
        End Set
    End Property

    Private LastPointValue As Point
    Public Property LastPoint() As Point
        Get
            Return Me.LastPointValue
        End Get
        Set(ByVal value As Point)
            Me.LastPointValue = value
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

        Paint(g)
    End Sub

    Public MustOverride Sub Paint(g As Graphics)
End Class
