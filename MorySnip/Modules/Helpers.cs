using System.Drawing;
using System.Collections.Generic;
using System;
using Microsoft.VisualBasic.CompilerServices;
using System.IO;

namespace Morysoft.MorySnip
{
    static class Helpers
    {
        private static int _gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return _gcd(b, a % b);
        }

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

            var divisor = _gcd(Conversions.ToInteger(numerator), Conversions.ToInteger(denominator));

            if (temp == null)
            {
                return new Size(Conversions.ToInteger(numerator / divisor), Conversions.ToInteger(denominator / divisor));
            }
            else
            {
                return new Size(Conversions.ToInteger(denominator / divisor), Conversions.ToInteger(numerator / divisor));
            }
        }

        public static Rectangle NormalRectingle(Point p1, Point p2)
        {
            int x1, x2, y1, y2;
            x1 = Math.Min(p1.X, p2.X);
            x2 = Math.Max(p1.X, p2.X);
            y1 = Math.Min(p1.Y, p2.Y);
            y2 = Math.Max(p1.Y, p2.Y);
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        public static Rectangle NormalRectingle(Point p, Size s)
        {
            return NormalRectingle(p, p + s);
        }

        public static Font LogFont = new Font("Courier New", 10);

        public static Bitmap ApplyAction(Bitmap Img, Actions type, Zones Zone, Rectangle Rect)
        {
            switch (type)
            {
                case Actions.Crop:
                    {
                        var newImage = new Bitmap(Rect.Width, Rect.Height);
                        var g = Graphics.FromImage(newImage);
                        g.DrawImage(Img, -Rect.X, -Rect.Y, Img.Width, Img.Height);
                        return newImage;
                    }
            }

            Img = (Bitmap)Img.Clone();

            int w = Img.Width;
            int h = Img.Height;

            int CropX = Rect.X;
            int CropY = Rect.Y;
            int CropW = Rect.X + Rect.Width;
            int CropH = Rect.Y + Rect.Height;

            bool Selected(int x, int y) => x >= CropX & x <= CropW & y >= CropY & y <= CropH;

            bool inZone(int x, int y)
            {
                switch (Zone)
                {
                    case Zones.All:
                        {
                            return true;
                        }

                    case Zones.NotSelected:
                        {
                            return !Selected(x, y);
                        }

                    case Zones.Selected:
                        {
                            return Selected(x, y);
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

                                    var col = Img.GetPixel(sx, sy);

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

                            Img.SetPixel(x, y, Color.FromArgb(nA, nR, nG, nB));
                        };
                        break;
                    }

                case Actions.Puzzle:
                    {
                        Effect = (x, y) => Img.SetPixel(x, y, Img.GetPixel(x - x % 4, y - y % 4));
                        break;
                    }

                case Actions.Grayscale:
                    {
                        Effect = (x, y) =>
                        {
                            var b = default(int);
                            var col = Img.GetPixel(x, y);

                            b += col.R;
                            b += col.G;
                            b += col.B;
                            b /= 3;

                            Img.SetPixel(x, y, Color.FromArgb(col.A, b, b, b));
                        };
                        break;
                    }

                case Actions.Invert:
                    {
                        Effect = (x, y) => Img.SetPixel(x, y, Color.FromArgb(255 - Img.GetPixel(x, y).R, 255 - Img.GetPixel(x, y).G, 255 - Img.GetPixel(x, y).B));
                        break;
                    }

                case Actions.Highlight:
                    {
                        Effect = (x, y) => Img.SetPixel(x, y, Color.FromArgb(Img.GetPixel(x, y).R, Img.GetPixel(x, y).G, 0));
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

            for (int x = 0, loopTo = Img.Width - 1; x <= loopTo; x++)
            {
                for (int y = 0, loopTo1 = Img.Height - 1; y <= loopTo1; y++)
                {
                    if (inZone(x, y))
                    {
                        Effect(x, y);
                    }
                }
            }

            return Img;
        }

        private static readonly List<string> TempFiles = new List<string>();

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
