using System;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip
{
    public class Screenshot
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string OriginalPath { get; set; }

        public static implicit operator Screenshot(Image source) => new() { Image = source };

        public static explicit operator Image(Screenshot source) => source.Image;

        public Screenshot Clone() => new()
        {
            Image = (Image)this.Image?.Clone(),
            Comment = this.Comment,
            Title = this.Title,
            OriginalPath = this.OriginalPath
        };

        public Bitmap GetThumbnailImage() => this.GetThumbnailImage(128, 128, Color.White);

        public Bitmap GetThumbnailImage(int width, int height, Color fill)
        {
            // a holder for the result
            var result = new Bitmap(width, height);

            if (this.Image == null)
            {
                return result;
            }

            // set the resolutions the same to avoid cropping due to resolution differences
            result.SetResolution(this.Image.HorizontalResolution, this.Image.VerticalResolution);

            int x = default, y = default, w = default, h = default;

            if (this.Image.Width < result.Width && this.Image.Height < result.Height)
            {
                w = this.Image.Width;
                h = this.Image.Height;
                x = Conversions.ToInteger((result.Width - w) / (double)2);
                y = Conversions.ToInteger((result.Height - h) / (double)2);
            }
            else
            {
                double r1 = this.Image.Width / (double)this.Image.Height;
                double r2 = result.Width / (double)result.Height;

                if (r1 == r2)
                {
                    w = result.Width;
                    h = result.Height;
                    x = 0;
                    y = 0;
                }
                else if (r1 > r2)
                {
                    w = result.Width;
                    h = Conversions.ToInteger(this.Image.Height * (result.Width / (double)this.Image.Width));
                    x = 0;
                    y = Conversions.ToInteger((height - h) / (double)2);
                }
                else if (r1 < r2)
                {
                    w = Conversions.ToInteger(this.Image.Width * (result.Height / (double)this.Image.Height));
                    h = result.Height;
                    x = Conversions.ToInteger((result.Width - w) / (double)2);
                    y = 0;
                }
            }

            // use a graphics object to draw the resized image into the bitmap
            {
                var withBlock = Graphics.FromImage(result);

                withBlock.Clear(fill);
                // set the resize quality modes to high quality
                withBlock.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                withBlock.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                withBlock.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                // draw the image into the target bitmap
                withBlock.DrawImage(this.Image, x, y, w, h);
            }

            // return the resulting bitmap
            return result;
        }
    }
}
