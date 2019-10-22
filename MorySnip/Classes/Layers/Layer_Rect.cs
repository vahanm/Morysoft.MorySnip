using System.Drawing;

namespace Morysoft.MorySnip
{
    public class Layer_Rect : Layer
    {
        public Layer_Rect(Pen Pen, Brush Brush, Point FirstPoint)
        {
            this.Pen = Pen;
            this.Brush = Brush;
            this.Start(FirstPoint);
        }

        public override void Paint(Graphics g)
        {
            var r = this.Bounds;

            if (this.Fill)
            {
                g.FillRectangle(this.Brush, r);
            }

            g.DrawRectangle(this.Pen, r);
        }
    }
}
