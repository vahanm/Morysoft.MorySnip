using System.Drawing;

namespace Morysoft.MorySnip;

public class LayerOval : Layer
{
    public LayerOval()
    {
    }

    public LayerOval(Pen Pen, Brush Brush, Point FirstPoint)
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
            g.FillEllipse(this.Brush, r);
        }

        g.DrawEllipse(this.Pen, r);
    }
}
