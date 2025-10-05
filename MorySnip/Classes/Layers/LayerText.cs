using System.Drawing;
using Morysoft.MorySnip.Draw;

namespace Morysoft.MorySnip.Classes.Layers;

public class LayerText : LayerArrow
{
    public LayerText()
    {
    }

    public LayerText(string text, Pen pen, Brush brush, Point firstPoint, Font font, ArrowModes arrowMode) : base(pen, brush, firstPoint, arrowMode)
    {
        this.Text = text;
        this.Font = font;
    }

    public string Text { get; set; }

    public Font Font { get; set; }

    private const float ArrowMinLength = 30;

    private const float GapLength = 10;

    public override void Paint(Graphics g)
    {
        if (g is null)
        {
            throw new ArgumentNullException(nameof(g));
        }

        g.TranslateTransform(this.FirstPoint.X, this.FirstPoint.Y);
        g.RotateTransform((float)(Math.Atan2(this.LastPoint.Y - this.FirstPoint.Y, this.LastPoint.X - this.FirstPoint.X) / Math.PI * 180f));

        using (var font = new Font(this.Font.FontFamily, this.Pen.Width * 2 + 10))
        {
            var arrowMode = this.ArrowMode;
            var drawLength = (float)Math.Sqrt(Math.Pow(this.LastPoint.Y - this.FirstPoint.Y, 2) + Math.Pow(this.LastPoint.X - this.FirstPoint.X, 2));

            var textSize = g.MeasureString(this.Text, font);

            var minTotalLength = textSize.Width + GapLength + ArrowMinLength;

            if (minTotalLength > drawLength)
            {
                arrowMode = ArrowModes.None;
            }

            var totalLength = Math.Max(minTotalLength, drawLength);
            //var arrowLength = totalLength - textSize.Width - GapLength;

            switch (arrowMode)
            {
                case ArrowModes.AtEnd:
                    {
                        var firstPoint = new Point((int)(textSize.Width + GapLength), 0);
                        var lastPoint = new Point((int)totalLength, 0);

                        g.DrawLine(this.Pen, firstPoint, lastPoint);
                        g.DrawString(this.Text, font, this.Brush, 0, -textSize.Height / 2);
                        g.DrawArrow(this.Pen, this.Brush, firstPoint, lastPoint, arrowMode);

                        break;
                    }

                case ArrowModes.AtStart:
                    {
                        g.DrawArrow(this.Pen, this.Brush, this.LastPoint, this.FirstPoint, arrowMode);
                        break;
                    }

                case ArrowModes.Both:
                    {
                        g.DrawArrow(this.Pen, this.Brush, this.LastPoint, this.FirstPoint, arrowMode);
                        g.DrawArrow(this.Pen, this.Brush, this.FirstPoint, this.LastPoint, arrowMode);
                        break;
                    }

                case ArrowModes.None:
                    {
                        g.DrawString(this.Text, font, this.Brush, 0, -textSize.Height / 2);
                        break;
                    }
            }
        }

        g.ResetTransform();
    }
}
