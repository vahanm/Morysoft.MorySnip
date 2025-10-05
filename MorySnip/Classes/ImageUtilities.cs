using System.Drawing;
using System.Drawing.Imaging;

namespace Morysoft.MorySnip.Classes;

public static class ImageUtilities
{
    /// <summary>
    /// A quick lookup for getting image encoders
    /// </summary>
    private static readonly Dictionary<string, ImageCodecInfo>? EncodersValue = null;

    /// <summary>
    /// A quick lookup for getting image encoders
    /// </summary>
    public static Dictionary<string, ImageCodecInfo> Encoders
    {
        // get accessor that creates the dictionary on demand
        get
        {
            var EncodersRet = default(Dictionary<string, ImageCodecInfo>);
            // if the quick lookup isn't initialised, initialise it
            if (EncodersValue == null)
            {
                EncodersRet = [];
            }

            // if there are no codecs, try loading them
            if (EncodersValue.Count == 0)
            {
                // get all the codecs
                foreach (var codec in ImageCodecInfo.GetImageEncoders())
                {
                    // add each codec to the quick lookup
                    EncodersValue.Add(codec.MimeType.ToLower(), codec);
                }
            }

            // return the lookup
            return EncodersValue;
        }
    }

    /// <summary>
    /// Resize the image to the specified width and height.
    /// </summary>
    /// <param name="image">The image to resize.</param>
    /// <param name="width">The width to resize to.</param>
    /// <param name="height">The height to resize to.</param>
    /// <returns>The resized image.</returns>
    public static Bitmap ResizeImage(Image image, int width, int height)
    {
        // a holder for the result
        var result = new Bitmap(width, height);
        // set the resolutions the same to avoid cropping due to resolution differences
        result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        // use a graphics object to draw the resized image into the bitmap
        {
            var withBlock = Graphics.FromImage(result);
            // set the resize quality modes to high quality
            withBlock.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            withBlock.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            withBlock.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // draw the image into the target bitmap
            withBlock.DrawImage(image, 0, 0, result.Width, result.Height);
        }

        // return the resulting bitmap
        return result;
    }

    /// <summary>
    /// Saves an image as a jpeg image, with the given quality
    /// </summary>
    /// <param name="path">Path to which the image would be saved.</param>
    /// <param name="quality">An integer from 0 to 100, with 100 being the
    /// highest quality</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// An invalid value was entered for image quality.
    /// </exception>
    public static void SaveJpeg(string Path, Image Image, int Quality)
    {
        // ensure the quality is within the correct range
        if (Quality < 0 || Quality > 100)
        {
            // create the error message
            var err = String.Format("Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.", Quality);
            // throw a helpful exception
            throw new ArgumentOutOfRangeException(err);
        }

        // create an encoder parameter for the image quality
        var qualityParam = new EncoderParameter(Encoder.Quality, Quality);
        // get the jpeg codec
        var jpegCodec = GetEncoderInfo("image/jpeg");

        // create a collection of all parameters that we will pass to the encoder
        var encoderParams = new EncoderParameters(1);
        // set the quality parameter for the codec
        encoderParams.Param[0] = qualityParam;
        // save the image using the codec and the parameters
        Image.Save(Path, jpegCodec, encoderParams);
    }

    /// <summary>
    /// Returns the image codec with the given mime type
    /// </summary>
    public static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        // do a case insensitive search for the mime type
        var lookupKey = mimeType.ToLower();

        // the codec to return, default to Nothing
        ImageCodecInfo foundCodec = null;

        // if we have the encoder, get it to return
        if (Encoders.ContainsKey(lookupKey))
        {
            // pull the codec from the lookup
            foundCodec = Encoders[lookupKey];
        }

        return foundCodec;
    }
}
