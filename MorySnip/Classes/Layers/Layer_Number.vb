Public Class Layer_Number
    Inherits Layer

    Public Sub New()

    End Sub

    Public Sub New(Pen As Pen, Brush As Brush, FirstPoint As Point, Number As Integer)
        Me.Pen = Pen
        Me.Brush = Brush
        Me.Number = Number
        Me.Start(FirstPoint)
    End Sub

    Private NumberValue As Integer
    Public Property Number() As Integer
        Get
            Return Me.NumberValue
        End Get
        Set(ByVal value As Integer)
            Me.NumberValue = value
        End Set
    End Property

    Public Overrides Sub Paint(g As Graphics)
        Dim r As Rectangle = Me.Bounds

        'If Me.Fill Then
        '    g.FillRectangle(Brush, r)
        'End If
        g.DrawRectangle(Me.Pen, r)

        Dim w As Integer = Me.Pen.Width
        Dim s As Integer = 8 + w
        Dim f As New Font("Courier New", s + 2)

        Dim h As Integer = g.MeasureString("000", f).Width
        Dim t As SizeF = g.MeasureString(Me.Number, f)

        Dim rb As New Rectangle(r.X - h \ 2, r.Y - h \ 2, h, h)
        Dim rf As New Rectangle(r.X - h \ 2 + 1, r.Y - h \ 2 + 1, h - 2, h - 2)
        g.FillEllipse(Brushes.White, rf)
        g.DrawEllipse(New Pen(Me.Pen.Color, Me.Pen.Width \ 2 + 1) With {.Alignment = Drawing2D.PenAlignment.Outset}, rb)
        g.DrawString(Me.Number, f, Brushes.Black, r.X - t.Width / 2, r.Y - ((t.Height + s) / 4))
    End Sub
End Class
