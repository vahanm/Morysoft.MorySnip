using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip
{
    internal static class Helpers
    {
        private static int _gcd(int a, int b) => b == 0 ? a : _gcd(b, a % b);

        public static Size ReduceRatio(uint numerator, uint denominator)
        {
            object temp = null;
            // from: http://pages.pacificcoast.net/~cazelais/euclid.html
            // take care of some simple cases

            if (numerator == denominator)
            {
                return new Size(1, 1);
            }

            // make sure numerator is always the larger number
            if (numerator < denominator)
            {
                temp = numerator;
                numerator = denominator;
                denominator = Conversions.ToUInteger(temp);
            }

            int divisor = _gcd(Conversions.ToInteger(numerator), Conversions.ToInteger(denominator));

            if (temp == null)
            {
                return new Size(Conversions.ToInteger(numerator / divisor), Conversions.ToInteger(denominator / divisor));
            }
            else
            {
                return new Size(Conversions.ToInteger(denominator / divisor), Conversions.ToInteger(numerator / divisor));
            }
        }

        public static Rectangle NormalizeRectingle(Point p1, Point p2)
        {
            int x1 = Math.Min(p1.X, p2.X);
            int x2 = Math.Max(p1.X, p2.X);
            int y1 = Math.Min(p1.Y, p2.Y);
            int y2 = Math.Max(p1.Y, p2.Y);

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        public static Rectangle NormalRectingle(Point p, Size s) => NormalizeRectingle(p, p + s);

        public static Font LogFont = new("Courier New", 10);

        public static Bitmap ApplyAction(Bitmap image, Actions type, Zones zone, Rectangle area)
        {
            switch (type)
            {
                case Actions.Crop:
                {
                    var newImage = new Bitmap(area.Width, area.Height);
                    var g = Graphics.FromImage(newImage);

                    g.DrawImage(image, -area.X, -area.Y, image.Width, image.Height);

                    return newImage;
                }
            }

            image = (Bitmap)image.Clone();

            int w = image.Width;
            int h = image.Height;

            int cropX = area.X;
            int cropY = area.Y;
            int cropW = area.X + area.Width;
            int cropH = area.Y + area.Height;

            bool isSelected(int x, int y) => x >= cropX & x <= cropW & y >= cropY & y <= cropH;

            bool inZone(int x, int y)
            {
                switch (zone)
                {
                    case Zones.All:
                    {
                        return true;
                    }

                    case Zones.NotSelected:
                    {
                        return !isSelected(x, y);
                    }

                    case Zones.Selected:
                    {
                        return isSelected(x, y);
                    }
                }

                return false;
            };


            Action<int, int> Effect;

            switch (type)
            {
                case Actions.Blur:
                {
                    Effect = (x, y) =>
                    {
                        int nR = default, nG = default, nB = default, nA = default, count = default;
                        int r = 5;

                        for (int sx = x - r, loopTo = x + r; sx <= loopTo; sx += 2)
                        {
                            for (int sy = y - r, loopTo1 = y + r; sy <= loopTo1; sy += 2)
                            {
                                if (sx < 0 || sx > w - 1 || sy < 0 || sy > h - 1)
                                {
                                    continue;
                                }

                                var col = image.GetPixel(sx, sy);

                                nR += col.R;
                                nG += col.G;
                                nB += col.B;
                                nA += col.A;

                                count += 1;
                            }
                        }

                        nR /= count;
                        nG /= count;
                        nB /= count;
                        nA /= count;

                        image.SetPixel(x, y, Color.FromArgb(nA, nR, nG, nB));
                    };
                    break;
                }

                case Actions.Puzzle:
                {
                    Effect = (x, y) => image.SetPixel(x, y, image.GetPixel(x - x % 4, y - y % 4));
                    break;
                }

                case Actions.Grayscale:
                {
                    Effect = (x, y) =>
                    {
                        int b = default;
                        var col = image.GetPixel(x, y);

                        b += col.R;
                        b += col.G;
                        b += col.B;
                        b /= 3;

                        image.SetPixel(x, y, Color.FromArgb(col.A, b, b, b));
                    };
                    break;
                }

                case Actions.Invert:
                {
                    Effect = (x, y) => image.SetPixel(x, y, Color.FromArgb(255 - image.GetPixel(x, y).R, 255 - image.GetPixel(x, y).G, 255 - image.GetPixel(x, y).B));
                    break;
                }

                case Actions.Highlight:
                {
                    Effect = (x, y) => image.SetPixel(x, y, Color.FromArgb(image.GetPixel(x, y).R, image.GetPixel(x, y).G, 0));
                    break;
                }

                default:
                {
                    Effect = (x, y) =>
                    {
                    };
                    break;
                }
            }

            for (int x = 0, loopTo = image.Width - 1; x <= loopTo; x++)
            {
                for (int y = 0, loopTo1 = image.Height - 1; y <= loopTo1; y++)
                {
                    if (inZone(x, y))
                    {
                        Effect(x, y);
                    }
                }
            }

            return image;
        }

        private static readonly List<string> TempFiles = new();

        public static string GetTempFileName()
        {
            string result = Path.GetTempFileName();

            TempFiles.Add(result);

            return result;
        }

        public static void DeleteAllTempFiles()
        {
            foreach (string file in TempFiles)
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {

                }
            }
        }
    }
}
