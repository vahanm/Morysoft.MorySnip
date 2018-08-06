Public Class Polar
    Public Angle As Single
    Public Radius As Single

    Public Shared Function Convert(Source As Polar) As PointF
        Return New PointF(Source.Radius * Math.Cos(Source.Angle), Source.Radius * Math.Sin(Source.Angle))
    End Function

    Public Shared Function Convert(Source As Point) As Polar
        Return Convert(New PointF(Source.X, Source.Y))
    End Function

    Public Shared Function Convert(Source As PointF) As Polar
        Dim Angle As Single, Radius As Single

        Dim X As Single = Source.X, Y As Single = Source.Y


        If X > 0 And Y >= 0 Then
            Angle = Math.Atan(Y / X)
        ElseIf X > 0 And Y < 0 Then
            Angle = Math.Atan(Y / X) + 2 * Math.PI
        ElseIf X < 0 Then
            Angle = Math.Atan(Y / X) + Math.PI
        ElseIf X = 0 And Y > 0 Then
            Angle = Math.PI / 2
        ElseIf X = 0 And Y < 0 Then
            Angle = Math.PI * 3 / 2
        ElseIf X = 0 And Y = 0 Then
            Angle = 0
        Else
            Throw New Exception("The impossible is possible")
        End If

        Radius = (X ^ 2 + Y ^ 2) ^ 0.5

        Return New Polar(Angle, Radius)
    End Function

    Public Shared Widening Operator CType(Source As Point) As Polar
        Return Convert(Source)
    End Operator

    Public Shared Widening Operator CType(Source As PointF) As Polar
        Return Convert(Source)
    End Operator

    Public Shared Widening Operator CType(Source As Polar) As Point
        Dim Result As PointF = Convert(Source)
        Return New Point(Result.X, Result.Y)
    End Operator

    Public Shared Widening Operator CType(Source As Polar) As PointF
        Return Convert(Source)
    End Operator

    Public Shared Widening Operator CType(Source As Polar) As Size
        Dim Result As PointF = Convert(Source)
        Return New Size(Result.X, Result.Y)
    End Operator

    Public Shared Widening Operator CType(Source As Polar) As SizeF
        Dim Result As PointF = Convert(Source)
        Return New SizeF(Result.X, Result.Y)
    End Operator

    Public Sub New()

    End Sub

    Public Sub New(Angle As Single, Radius As Single)
        Me.Angle = Angle
        Me.Radius = Radius
    End Sub
End Class