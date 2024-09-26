using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip.Classes.Layers;

public class LayerFree : Layer
{
    public GraphicsPath Path { get; private set; } = new GraphicsPath();

    public LayerFree()
    {
    }

    public LayerFree(Pen Pen, Brush Brush, Point FirstPoint)
    {
        this.Pen = Pen;
        this.Brush = Brush;
        this.Start(FirstPoint);
    }

    public override void Step(Point StepPoint)
    {
        this.Path.AddLine(this.LastPoint, StepPoint);
        base.Step(StepPoint);
    }

    public override void Stop(Point LastPoint)
    {
        this.Path.AddLine(this.LastPoint, LastPoint);
        base.Stop(LastPoint);
    }

    public override Rectangle Bounds
    {
        get
        {
            int x = default, y = default, w = default, h = default;
            var IsFirst = true;

            foreach (var item in this.Path.PathPoints)
            {
                if (IsFirst)
                {
                    IsFirst = false;
                    x = Conversions.ToInteger(item.X);
                    y = Conversions.ToInteger(item.Y);
                    w = Conversions.ToInteger(item.X);
                    h = Conversions.ToInteger(item.Y);
                }

                if (x > item.X)
                {
                    x = Conversions.ToInteger(item.X);
                }

                if (y > item.Y)
                {
                    y = Conversions.ToInteger(item.Y);
                }

                if (w < item.X)
                {
                    w = Conversions.ToInteger(item.X);
                }

                if (h < item.Y)
                {
                    h = Conversions.ToInteger(item.Y);
                }
            }

            return new Rectangle(x, y, w - x, h - y);
        }
    }

    public override void Paint(Graphics g)
    {
        if (this.Fill)
        {
            g.FillPath(this.Brush, this.Path);
        }

        g.DrawPath(this.Pen, this.Path);
    }
}
