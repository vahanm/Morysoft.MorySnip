using System;
using System.Drawing;

namespace Morysoft.MorySnip.Classes.Layers;

public class LayerLine : Layer
{
    public LayerLine()
    {
    }

    public LayerLine(Pen pen, Point firstPoint)
    {
        this.Pen = pen;
        this.Start(firstPoint);
    }

    public float Length => (float)Math.Sqrt(
        Math.Pow(this.FirstPoint.X - this.LastPoint.X, 2) + Math.Pow(this.FirstPoint.Y - this.LastPoint.Y, 2)
    );

    public override void Paint(Graphics g) => g.DrawLine(this.Pen, this.FirstPoint, this.LastPoint);
}
