using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Morysoft.MorySnip.Modules
{
    public static class Snipper
    {
        private static Point _virtualScreenLocation = SystemInformation.VirtualScreen.Location;
        private static Size _virtualScreenSize = SystemInformation.VirtualScreen.Size;

        private static Point _primaryScreenLocation = Screen.PrimaryScreen.Bounds.Location;
        private static Size _primaryScreenSize = Screen.PrimaryScreen.Bounds.Size;

        public static IEnumerable<Screenshot> Rectangles(IEnumerable<Rectangle> rectangles)
        {
            return rectangles.Select(rectangle =>
            {
                var b = new Bitmap(rectangle.Width, rectangle.Height);

                var g = Graphics.FromImage(b);

                g.CopyFromScreen(rectangle.Location, Point.Empty, rectangle.Size);

                return (Screenshot)b;
            });
        }

        public static IEnumerable<Screenshot> Areas(IEnumerable<Rectangle> rectangles)
        {
            return Rectangles(rectangles.Select(rectangle => new Rectangle(
                rectangle.X + _virtualScreenLocation.X,
                rectangle.Y + _virtualScreenLocation.Y,
                rectangle.Width,
                rectangle.Height
            )));
        }

        public static IEnumerable<Screenshot> AllScreens()
        {
            return Rectangles(new Rectangle[]
            {
                new Rectangle(_virtualScreenLocation, _virtualScreenSize)
            });
        }

        public static IEnumerable<Screenshot> PrimaryScreen()
        {
            return Rectangles(new Rectangle[]
            {
                new Rectangle(_primaryScreenLocation, _primaryScreenSize)
            });
        }

        public static IEnumerable<Screenshot> FromUris(IEnumerable<string> paths)
        {
            var isAborted = false;

            return paths.Select(path =>
            {
                if (isAborted)
                {
                    return null;
                }

                do
                {
                    try
                    {
                        string localPath = new Uri(path).LocalPath;
                        Screenshot tempImage = Image.FromFile(localPath);

                        tempImage.OriginalPath = localPath;

                        return tempImage;
                    }
                    catch (Exception ex)
                    {
                        switch (Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical | MsgBoxStyle.AbortRetryIgnore))
                        {
                            case MsgBoxResult.Abort:
                                isAborted = true;
                                return null;

                            case MsgBoxResult.Ignore:
                                return null;
                        }
                    }
                }
                while (true);
            }).Where(s => !(s is null));
        }

        public static IEnumerable<Screenshot> FromClipboard()
        {
            if (Clipboard.ContainsImage())
            {
                return new Screenshot[] { Clipboard.GetImage() };
            }
            else if (Clipboard.ContainsText())
            {
                return FromUris(Clipboard.GetText()
                    .Split('"', '\'', ';', '\n', '\r')
                    .Select(fn => fn.Trim('"', '\'', '\n', '\r'))
                );
            }
            else if (Clipboard.ContainsFileDropList())
            {
                var filesDroped = new List<Screenshot>();

                foreach (string path in Clipboard.GetFileDropList())
                {
                    string nomralizedPath = path.Trim('"', '\'');

                    filesDroped.AddRange(FromUris(new string[] { nomralizedPath }));
                }

                return filesDroped;
            }

            return Array.Empty<Screenshot>();
        }

        public static IEnumerable<Screenshot> FromFiles()
        {
            using (var od = new OpenFileDialog()
            {
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true,
                Filter = "All supported files|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpeg;*.jpg;*.png;*.tiff;*.wmf;"
            })
            {
                return od.ShowDialog() == DialogResult.OK
                    ? FromUris(od.FileNames.Select(fn => fn.Trim().Trim('"', '\'')))
                    : Array.Empty<Screenshot>();
            }
        }

        //public static IEnumerable<Screenshot> FromSnippingTool()
        //{
        //    using (var withBlock = new FormSnippingTool
        //    {
        //        SaveForm = this
        //    })
        //    {
        //        withBlock.ShowDialog();
        //    }
        //}
    }
}
