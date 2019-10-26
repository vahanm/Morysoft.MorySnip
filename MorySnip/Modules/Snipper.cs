using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            return paths.Select(path =>
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
                     return null;
                 }
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
    }
}
