Imports System.ComponentModel

Public Class PalitraEventArgs
    Inherits EventArgs

    Public Property NewColor As Color
    Public Property OldColor As Color

    Public Sub New(NewColor As Color, OldColor As Color)
        Me.NewColor = NewColor
        Me.OldColor = OldColor
    End Sub

    Public Sub New()

    End Sub
End Class

<DefaultEvent("ColorChanged")>
Public Class ToolStripPalitra
    Inherits System.Windows.Forms.ToolStripItem

#Region "Palitra"
    Private Shared _Palitra As Color(,) = Nothing
    Public Shared ReadOnly Property Palitra As Color(,)
        Get
            If _Palitra Is Nothing Then
                _Palitra = New Color(11, 360) {}
                For l As Integer = 0 To 10
                    For i As Integer = 0 To 360 - 1
                        _Palitra(l, i) = RGBHSL.HSL_to_RGB(i / 365, 1 - l / 10, 1)
                    Next
                Next
            End If

            Return _Palitra
        End Get
    End Property
#End Region

    Public Event ColorChanged(sender As Object, e As PalitraEventArgs)
    Public Event Color1Changed(sender As Object, e As PalitraEventArgs)
    Public Event Color2Changed(sender As Object, e As PalitraEventArgs)

    Private _Color1 As Color = Color.Red
    <DefaultValue(GetType(Color), "255, 0, 0")>
    Public Property Color1 As Color
        Get
            Return Me._Color1
        End Get
        Set(value As Color)
            If Not Me._Color1 = value Then
                RaiseEvent ColorChanged(Me, New PalitraEventArgs(value, Me._Color1))
                RaiseEvent Color1Changed(Me, New PalitraEventArgs())
                Me._Color1 = value
                Me.Parent.Refresh()
            End If
        End Set
    End Property

    Private _Color2 As Color = Color.Red
    <DefaultValue(GetType(Color), "255, 0, 0")>
    Public Property Color2 As Color
        Get
            Return Me._Color2
        End Get
        Set(value As Color)
            If Not Me._Color2 = value Then
                RaiseEvent ColorChanged(Me, New PalitraEventArgs(value, Me._Color2))
                RaiseEvent Color2Changed(Me, New PalitraEventArgs())
                Me._Color2 = value
                Me.Parent.Refresh()
            End If
        End Set
    End Property

    Dim Color1Rect As New Rectangle(5, 5, 20, 20)
    Dim Color2Rect As New Rectangle(15, 15, 20, 20)

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim g As Graphics = e.Graphics
        'g.Clear(Color.Red)

        g.FillRectangle(New SolidBrush(Me.Color2), Me.Color2Rect)
        g.DrawRectangle(Pens.Black, Me.Color2Rect)
        g.FillRectangle(New SolidBrush(Me.Color1), Me.Color1Rect)
        g.DrawRectangle(Pens.Black, Me.Color1Rect)

        For l As Integer = 0 To 10
            For i As Integer = 0 To 359 Step 3
                g.FillRectangle(New SolidBrush(Palitra(l, i)), 70 + i, 5 + 3 * l, 3, 3)
            Next
        Next

        g.DrawRectangle(Pens.Black, New Rectangle())
    End Sub

    Private Function GetColorByPoint(p As Point) As Color
        Dim colors = Palitra
        Dim i = (p.Y - 5) \ 3, j = (p.X - 70)

        If i >= 0 AndAlso i < colors.GetLength(0) AndAlso j >= 0 AndAlso j < colors.GetLength(1) Then
            Return colors(i, j)
        Else
            Return Color.Black
        End If
    End Function

    Private Sub SelectColor1(l As Point)
        Me.Color1 = Me.GetColorByPoint(l)
    End Sub

    Private Sub SelectColor2(l As Point)
        Me.Color2 = Me.GetColorByPoint(l)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then Me.SelectColor1(e.Location)
        If e.Button = MouseButtons.Right Then Me.SelectColor2(e.Location)

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(mea As MouseEventArgs)
        If mea.Button = MouseButtons.Left Then Me.SelectColor1(mea.Location)
        If mea.Button = MouseButtons.Right Then Me.SelectColor2(mea.Location)

        MyBase.OnMouseMove(mea)
    End Sub

    Public Sub New()
        'Me.Container.Add(New Button())
    End Sub
End Class
