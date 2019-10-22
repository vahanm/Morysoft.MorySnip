using System.Drawing;

namespace Morysoft.MorySnip
{
    public class LayerImage : Layer
    {
        public LayerImage(Bitmap Image)
        {
            this.Image = Image;
            this.LastPoint = (Point)Image.Size;
        }

        public Bitmap Image { get; set; }

        public override void Paint(Graphics g)
        {
            g.DrawImage(this.Image, this.Bounds);
        }
    }
}
