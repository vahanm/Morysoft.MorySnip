Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging

Public Module ImageUtilities
    ''' <summary>
    ''' A quick lookup for getting image encoders
    ''' </summary>
    Private EncodersValue As Dictionary(Of String, ImageCodecInfo) = Nothing

    ''' <summary>
    ''' A quick lookup for getting image encoders
    ''' </summary>
    Public ReadOnly Property Encoders As Dictionary(Of String, ImageCodecInfo)
        'get accessor that creates the dictionary on demand
        Get
            'if the quick lookup isn't initialised, initialise it
            If (EncodersValue Is Nothing) Then Encoders = New Dictionary(Of String, ImageCodecInfo)()

            'if there are no codecs, try loading them
            If (EncodersValue.Count = 0) Then
                'get all the codecs
                For Each codec As ImageCodecInfo In ImageCodecInfo.GetImageEncoders()
                    'add each codec to the quick lookup
                    EncodersValue.Add(codec.MimeType.ToLower(), codec)
                Next
            End If

            'return the lookup
            Return EncodersValue
        End Get
    End Property

    ''' <summary>
    ''' Resize the image to the specified width and height.
    ''' </summary>
    ''' <param name="image">The image to resize.</param>
    ''' <param name="width">The width to resize to.</param>
    ''' <param name="height">The height to resize to.</param>
    ''' <returns>The resized image.</returns>
    Public Function ResizeImage(image As System.Drawing.Image, width As Integer, height As Integer) As System.Drawing.Bitmap
        'a holder for the result
        Dim result As Bitmap = New Bitmap(width, height)
        ' set the resolutions the same to avoid cropping due to resolution differences
        result.SetResolution(image.HorizontalResolution, image.VerticalResolution)

        'use a graphics object to draw the resized image into the bitmap
        With Graphics.FromImage(result)
            'set the resize quality modes to high quality
            .CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            .InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            .SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            'draw the image into the target bitmap
            .DrawImage(image, 0, 0, result.Width, result.Height)
        End With

        'return the resulting bitmap
        Return result
    End Function

    ''' <summary>
    ''' Saves an image as a jpeg image, with the given quality 
    ''' </summary> 
    ''' <param name="path">Path to which the image would be saved.</param>
    ''' <param name="quality">An integer from 0 to 100, with 100 being the 
    ''' highest quality</param>
    ''' <exception cref="ArgumentOutOfRangeException">
    ''' An invalid value was entered for image quality.
    ''' </exception>
    Public Sub SaveJpeg(Path As String, Image As Image, Quality As Integer)
        'ensure the quality is within the correct range
        If ((quality < 0) OrElse (quality > 100)) Then
            'create the error message
            Dim err As String = String.Format("Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.", quality)
            'throw a helpful exception
            Throw New ArgumentOutOfRangeException(err)
        End If

        'create an encoder parameter for the image quality
        Dim qualityParam As EncoderParameter = New EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality)
        'get the jpeg codec
        Dim jpegCodec As ImageCodecInfo = GetEncoderInfo("image/jpeg")

        'create a collection of all parameters that we will pass to the encoder
        Dim encoderParams As EncoderParameters = New EncoderParameters(1)
        'set the quality parameter for the codec
        encoderParams.Param(0) = qualityParam
        'save the image using the codec and the parameters
        Image.Save(path, jpegCodec, encoderParams)
    End Sub

    ''' <summary>
    ''' Returns the image codec with the given mime type 
    ''' </summary> 
    Public Function GetEncoderInfo(mimeType As String) As ImageCodecInfo
        'do a case insensitive search for the mime type
        Dim lookupKey As String = mimeType.ToLower()

        'the codec to return, default to Nothing
        Dim foundCodec As ImageCodecInfo = Nothing

        'if we have the encoder, get it to return
        If (Encoders.ContainsKey(lookupKey)) Then
            'pull the codec from the lookup
            foundCodec = Encoders(lookupKey)
        End If

        Return foundCodec
    End Function
End Module
