using System;
using System.Drawing;
using Morysoft.MorySnip.Classes;

namespace Morysoft.MorySnip.Classes.Layers;

public class LayerMagnifier : Layer
{
    private bool isValid;

    public LayerMagnifier()
    {
    }

    public LayerMagnifier(Pen pen, Brush brush, Bitmap texture, Point firstPoint, int zoom, int radius)
    {
        this.Pen = pen;
        this.Brush = brush;
        this.Texture = texture;
        this.Zoom = zoom;
        this.Radius = radius;
        this.Start(firstPoint);
    }

    public Bitmap? Texture { get; set; }

    public int Radius { get; set; }

    public int Zoom { get; set; }

    public override bool IsValid => this.isValid;

    public override void Paint(Graphics g)
    {
        if (g is null)
        {
            throw new ArgumentNullException(nameof(g));
        }

        void drawArrow(Point pBegin, Point pEnd)
        {
            var newZero = (Polar)pBegin - pEnd;

            var tailPolar11 = new Polar(newZero.Angle, this.Radius);
            var tailPolar12 = new Polar(newZero.Angle + (float)Math.PI, this.Radius * this.Zoom);

            var tail11 = tailPolar11 + pEnd;
            var tail12 = tailPolar12 + pBegin;

            g.DrawLine(this.Pen, tail12, tail11);
        };

        drawArrow(this.LastPoint, this.FirstPoint);

        var source = new Rectangle(
            this.FirstPoint.X - this.Radius,
            this.FirstPoint.Y - this.Radius,
            this.Radius * 2,
            this.Radius * 2
        );

        g.DrawEllipse(this.Pen, source);

        var magnifier = new Rectangle(
            0,
            0,
            this.Radius * 2,
            this.Radius * 2
        );

        g.TranslateTransform(this.LastPoint.X - this.Radius * this.Zoom, this.LastPoint.Y - this.Radius * this.Zoom);
        g.ScaleTransform(this.Zoom, this.Zoom);

        try
        {
            using (var texture = new TextureBrush(this.Texture, source))
            {
                g.FillEllipse(texture, magnifier);
            }

            this.isValid = true;
        }
        catch (OutOfMemoryException)
        {
            this.isValid = false;
            g.FillEllipse(this.Brush, magnifier);
        }

        g.DrawEllipse(this.Pen, magnifier);
        g.ResetTransform();
    }
}
