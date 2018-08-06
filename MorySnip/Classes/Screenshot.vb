Public Class Screenshot
    Inherits MarshalByRefObject

    Public Image As Image
    Public Title As String
    Public Comment As String
    Public OriginalPath As String

    Public Shared Widening Operator CType(source As Image) As Screenshot
        Return New Screenshot With {.Image = source}
    End Operator

    Public Shared Narrowing Operator CType(source As Screenshot) As Image
        Return source.Image
    End Operator

    Public Function Clone() As Screenshot
        Dim Cloned As New Screenshot

        If Me.Image IsNot Nothing Then Cloned.Image = Me.Image.Clone()
        If Me.Comment IsNot Nothing Then Cloned.Comment = Me.Comment.Clone()
        If Me.Title IsNot Nothing Then Cloned.Title = Me.Title.Clone()
        If Me.OriginalPath IsNot Nothing Then Cloned.OriginalPath = Me.OriginalPath.Clone()

        Return Cloned
    End Function

    Public Function GetThumbnailImage() As Bitmap
        Return GetThumbnailImage(128, 128, Color.White, New Pen(Brushes.DarkGray, 2))
    End Function

    Public Function GetThumbnailImage(Width As Integer, Height As Integer, Fill As Color, Optional Border As Pen = Nothing) As Bitmap
        'a holder for the result
        Dim Result As Bitmap = New Bitmap(Width, Height)

        If Me.Image Is Nothing Then
            Return Result
        End If

        ' set the resolutions the same to avoid cropping due to resolution differences
        Result.SetResolution(Me.Image.HorizontalResolution, Me.Image.VerticalResolution)

        Dim x, y, w, h As Integer


        If Me.Image.Width < Result.Width AndAlso Me.Image.Height < Result.Height Then
            w = Me.Image.Width
            h = Me.Image.Height
            x = (Result.Width - w) / 2
            y = (Result.Height - h) / 2
        Else
            Dim r1 As Double = Me.Image.Width / Me.Image.Height
            Dim r2 As Double = Result.Width / Result.Height

            If r1 = r2 Then
                w = Result.Width
                h = Result.Height
                x = 0
                y = 0
            ElseIf r1 > r2 Then
                w = Result.Width
                h = Me.Image.Height * (Result.Width / Me.Image.Width)
                x = 0
                y = (Height - h) / 2
            ElseIf r1 < r2 Then
                w = Me.Image.Width * (Result.Height / Me.Image.Height)
                h = Result.Height
                x = (Result.Width - w) / 2
                y = 0
            End If
        End If

        'use a graphics object to draw the resized image into the bitmap
        With Graphics.FromImage(Result)
            .Clear(Fill)
            'set the resize quality modes to high quality
            .CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            .InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            .SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            'draw the image into the target bitmap
            .DrawImage(Me.Image, x, y, w, h)
        End With

        'return the resulting bitmap
        Return Result
    End Function
End Class
