using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Morysoft.MorySnip.Forms
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            this.InitializeComponent();
        }

        private void FormTest_Load(object sender, System.EventArgs e)
        {
            var x = Screen.AllScreens.Min(s => s.Bounds.X);
            var y = Screen.AllScreens.Min(s => s.Bounds.Y);
            var w = Screen.AllScreens.Max(s => s.Bounds.X + s.Bounds.Width) - x;
            var h = Screen.AllScreens.Max(s => s.Bounds.Y + s.Bounds.Height) - y;

            var b = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var g = Graphics.FromImage(b);

            //g.Clear(Color.Yellow);

            g.CopyFromScreen(x, y, 0, 0, new Size(w, h));

            var location = GetLocation(b, w, h);
            var size = GetSize(b, location, w, h);

            var f = new Bitmap(size.Width, size.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            var fg = Graphics.FromImage(f);

            fg.DrawImage(b, new Point(-location.X, -location.Y));

            this.BackgroundImage = f;
        }

        private static Size GetSize(Bitmap bitmap, Point location, int width, int height)
        {
            for (int x = width - 1; x > location.X; x--)
            {
                for (int y = height - 1; y > location.Y; y--)
                {
                    if (bitmap.GetPixel(x, y).A > 0)
                    {
                        return new Size(x - location.X, y - location.Y);
                    }
                }
            }

            throw new System.Exception();
        }

        private static Point GetLocation(Bitmap bitmap, int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (bitmap.GetPixel(x, y).A > 0)
                    {
                        return new Point(x, y);
                    }
                }
            }

            throw new System.Exception();
        }
    }
}
