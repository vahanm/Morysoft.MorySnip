Public Class Layer_Action
    Inherits Layer

    Public Sub New(FirstPoint As Point, Action As Actions, Zone As Zones)
        Me.Action = Action
        Me.Zone = Zone
        Me.Start(FirstPoint)
    End Sub

    Private ActionValue As Actions
    Public Property Action() As Actions
        Get
            Return ActionValue
        End Get
        Set(ByVal value As Actions)
            ActionValue = value
        End Set
    End Property

    Private ZoneValue As Zones
    Public Property Zone() As Zones
        Get
            Return ZoneValue
        End Get
        Set(ByVal value As Zones)
            ZoneValue = value
        End Set
    End Property

    Dim Pen1 As New Pen(Color.White, 1)
    Dim Pen2 As New Pen(Color.Black, 1) With {.DashStyle = Drawing2D.DashStyle.Custom, .DashPattern = New Single() {3, 3}}
    Dim BrushFill As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.BackwardDiagonal, Color.DarkGray, Color.Transparent)

    Public Overrides Sub Paint(g As Graphics)
        Dim r As Rectangle = Bounds

        Select Case Zone
            Case Zones.NotSelected
                If r.Y > 0 Then g.FillRectangle(BrushFill, New Rectangle(0, 0, 10000, r.Y))
                If r.X > 0 Then g.FillRectangle(BrushFill, New Rectangle(0, r.Y, r.X, 10000))
                g.FillRectangle(BrushFill, New Rectangle(r.X, r.Y + r.Height, 10000, 10000))
                g.FillRectangle(BrushFill, New Rectangle(r.X + r.Width, r.Y, 10000, r.Height))

            Case Zones.Selected
                g.FillRectangle(BrushFill, r)
        End Select

        g.DrawRectangle(Pen1, r)
        g.DrawRectangle(Pen2, r)
    End Sub

    Public Overrides Sub Render(g As Graphics)
    End Sub
End Class
