using System.Drawing;

namespace Morysoft.MorySnip.Classes.Layers;

public class LayerRect : Layer
{
    public LayerRect(Pen Pen, Brush Brush, Point FirstPoint)
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
