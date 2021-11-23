using System.Drawing;

namespace Morysoft.MorySnip;

public class LayerLine : Layer
{
    public LayerLine()
    {
    }

    public LayerLine(Pen Pen, Point FirstPoint)
    {
        this.Pen = Pen;
        this.Start(FirstPoint);
    }

    public override void Paint(Graphics g) => g.DrawLine(this.Pen, this.FirstPoint, this.LastPoint);
}
