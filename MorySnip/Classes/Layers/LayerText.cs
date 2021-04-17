using Morysoft.MorySnip.Draw;
using System;
using System.Drawing;

namespace Morysoft.MorySnip
{
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

        const float ArrowMinLength = 30;

        const float GapLength = 10;

        public override void Paint(Graphics g)
        {
            if (g is null)
            {
                throw new ArgumentNullException(nameof(g));
            }

            g.TranslateTransform(this.FirstPoint.X, this.FirstPoint.Y);
            g.RotateTransform((float)(Math.Atan2(this.LastPoint.Y - this.FirstPoint.Y, this.LastPoint.X - this.FirstPoint.X) / Math.PI * 180f));

            using (var font = new Font(this.Font.FontFamily, (this.Pen.Width * 2) + 10))
            {
                var drawLength = Math.Sqrt(Math.Pow(this.LastPoint.Y - this.FirstPoint.Y, 2) + Math.Pow(this.LastPoint.X - this.FirstPoint.X, 2));
                var size = g.MeasureString(this.Text, font);
                var totalLength = (float)Math.Max(size.Width + ArrowMinLength + GapLength, drawLength);
                var arrowLength = totalLength - size.Width - GapLength;

                switch (this.ArrowMode)
                {
                    case ArrowModes.AtEnd:
                    {
                        var firstPoint = new Point((int)(size.Width + GapLength), 0);
                        var lastPoint = new Point((int)totalLength, 0);

                        g.DrawString(this.Text, font, this.Brush, 0, -size.Height / 2);
                        g.DrawLine(this.Pen, firstPoint, lastPoint);

                        this.DrawArrow(g, firstPoint, lastPoint);

                        break;
                    }

                    case ArrowModes.AtStart:
                    {
                        this.DrawArrow(g, this.LastPoint, this.FirstPoint);
                        break;
                    }

                    case ArrowModes.Both:
                    {
                        this.DrawArrow(g, this.LastPoint, this.FirstPoint);
                        this.DrawArrow(g, this.FirstPoint, this.LastPoint);
                        break;
                    }
                }
            }

            g.ResetTransform();
        }
    }
}
