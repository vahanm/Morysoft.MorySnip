Module Helpers
    Private Function gcd(a As Integer, b As Integer) As Integer
        If b = 0 Then
            Return a
        End If
        Return gcd(b, a Mod b)
    End Function

    Public Function ReduceRatio(numerator As UInteger, denominator As UInteger) As Size
        Dim temp = Nothing, divisor
        'from: http://pages.pacificcoast.net/~cazelais/euclid.html
        'take care of some simple cases

        If numerator = denominator Then Return New Size(1, 1)

        'make sure numerator is always the larger number
        If numerator < denominator Then
            temp = numerator
            numerator = denominator
            denominator = temp
        End If

        divisor = gcd(numerator, denominator)
        If temp Is Nothing Then
            Return New Size((numerator / divisor), (denominator / divisor))
        Else
            Return New Size((denominator / divisor), (numerator / divisor))
        End If
    End Function

    Public Function NormalRectingle(p1 As Point, p2 As Point) As Rectangle
        Dim x1, x2, y1, y2 As Integer
        x1 = Math.Min(p1.X, p2.X)
        x2 = Math.Max(p1.X, p2.X)
        y1 = Math.Min(p1.Y, p2.Y)
        y2 = Math.Max(p1.Y, p2.Y)
        Return New Rectangle(x1, y1, x2 - x1, y2 - y1)
    End Function

    Public Function NormalRectingle(p As Point, s As Size) As Rectangle
        Return NormalRectingle(p, p + s)
    End Function

    Public LogFont As Font = New Font("Courier New", 10)

    Public Function ApplyAction(Img As Bitmap, ByVal type As Actions, ByVal Zone As Zones, Rect As Rectangle) As Bitmap
        Select Case type
            Case Actions.Crop
                Dim newImage As New Bitmap(Rect.Width, Rect.Height)
                Dim g As Graphics = Graphics.FromImage(newImage)
                g.DrawImage(Img, -Rect.X, -Rect.Y, Img.Width, Img.Height)
                Return newImage
        End Select

        Img = Img.Clone()

        Dim w As Integer = Img.Width
        Dim h As Integer = Img.Height

        Dim CropX As Integer = Rect.X
        Dim CropY As Integer = Rect.Y
        Dim CropW As Integer = Rect.X + Rect.Width
        Dim CropH As Integer = Rect.Y + Rect.Height

        Dim Selected = Function(x As Integer, y As Integer)
                           Return (x >= CropX And x <= CropW) And (y >= CropY And y <= CropH)
                       End Function

        Dim InZone = Function(x As Integer, y As Integer)
                         Select Case Zone
                             Case Zones.All
                                 Return True
                             Case Zones.NotSelected
                                 Return Not Selected(x, y)
                             Case Zones.Selected
                                 Return Selected(x, y)
                         End Select
                     End Function


        Dim Effect As Action(Of Integer, Integer)

        Select Case type
            Case Actions.Blur
                Effect = Sub(x As Integer, y As Integer)
                             Dim nR, nG, nB, nA, count As Integer
                             Dim r As Integer = 5

                             For sx As Integer = x - r To x + r Step 2
                                 For sy As Integer = y - r To y + r Step 2
                                     If sx < 0 OrElse sx > w - 1 OrElse sy < 0 OrElse sy > h - 1 Then Continue For

                                     Dim col As Color = Img.GetPixel(sx, sy)

                                     nR += col.R
                                     nG += col.G
                                     nB += col.B
                                     nA += col.A

                                     count += 1
                                 Next
                             Next
                             nR /= count
                             nG /= count
                             nB /= count
                             nA /= count

                             Img.SetPixel(x, y, Color.FromArgb(nA, nR, nG, nB))
                         End Sub

            Case Actions.Puzzle
                Effect = Sub(x As Integer, y As Integer)
                             Img.SetPixel(x, y, Img.GetPixel(x - x Mod 4, y - y Mod 4))
                         End Sub

            Case Actions.Grayscale
                Effect = Sub(x As Integer, y As Integer)
                             Dim b As Integer
                             Dim col As Color = Img.GetPixel(x, y)

                             b += col.R
                             b += col.G
                             b += col.B
                             b /= 3

                             Img.SetPixel(x, y, Color.FromArgb(col.A, b, b, b))
                         End Sub

            Case Actions.Invert
                Effect = Sub(x As Integer, y As Integer)
                             Img.SetPixel(x, y, Color.FromArgb(255 - Img.GetPixel(x, y).R, 255 - Img.GetPixel(x, y).G, 255 - Img.GetPixel(x, y).B))
                         End Sub

            Case Actions.Highlight
                Effect = Sub(x As Integer, y As Integer)
                             Img.SetPixel(x, y, Color.FromArgb(Img.GetPixel(x, y).R, Img.GetPixel(x, y).G, 0))
                         End Sub

            Case Else
                Effect = Sub(x As Integer, y As Integer)

                         End Sub
        End Select



        For x As Integer = 0 To Img.Width - 1
            For y As Integer = 0 To Img.Height - 1
                If InZone(x, y) Then Effect(x, y)
            Next
        Next

        Return Img
    End Function

    Dim TempFiles As New List(Of String)

    Public Function GetTempFileName() As String
        Dim result As String = My.Computer.FileSystem.GetTempFileName()
        TempFiles.Add(result)
        Return result
    End Function

    Public Sub DeleteAllTempFiles()
        For Each file As String In TempFiles
            Try
                IO.File.Delete(file)
            Catch ex As Exception

            End Try
        Next
    End Sub

    Public si As New Google.Apis.Services.BaseClientService.Initializer() With {.ApiKey = "AIzaSyBdLw3sO6yeOZSr_XXWuh_qYfMVjfkwSm4"}
    Public gcs As New Google.Apis.Urlshortener.v1.UrlshortenerService(si)
End Module
