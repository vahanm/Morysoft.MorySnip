using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip
{
    public enum ArrowModes : byte
    {
        AtStart,
        AtEnd,
        Both
    }

    public class LayerArrow : Layer
    {
        public LayerArrow() { }

        public LayerArrow(Pen Pen, Brush Brush, Point FirstPoint, ArrowModes ArrowMode)
        {
            this.Pen = Pen;
            this.Brush = Brush;
            this.ArrowMode = ArrowMode;
            this.Start(FirstPoint);
        }

        public ArrowModes ArrowMode { get; set; }

        public override void Paint(Graphics g)
        {
            void drawArrow(Point pBegin, Point pEnd)
            {
                float a1 = Conversions.ToSingle(0.5);
                float a2 = Conversions.ToSingle(0.4);

                Polar newZero = (Polar)pBegin - pEnd;

                var tailPolar11 = new Polar(newZero.Angle - a1, newZero.Radius / 10);
                var tailPolar12 = new Polar(newZero.Angle - a2, newZero.Radius / 20);
                var tailPolar21 = new Polar(newZero.Angle + a1, newZero.Radius / 10);
                var tailPolar22 = new Polar(newZero.Angle + a2, newZero.Radius / 20);

                var tail11 = tailPolar11 + pEnd;
                var tail12 = tailPolar12 + pEnd;
                var tail21 = tailPolar21 + pEnd;
                var tail22 = tailPolar22 + pEnd;

                g.DrawCurve(this.Pen, new Point[] { tail11, tail12, pEnd }, 0.5f);
                g.DrawCurve(this.Pen, new Point[] { tail21, tail22, pEnd }, 0.5f);
            };

            g.DrawLine(this.Pen, this.FirstPoint, this.LastPoint);

            switch (this.ArrowMode)
            {
                case ArrowModes.AtEnd:
                    {
                        drawArrow(this.FirstPoint, this.LastPoint);
                        break;
                    }

                case ArrowModes.AtStart:
                    {
                        drawArrow(this.LastPoint, this.FirstPoint);
                        break;
                    }

                case ArrowModes.Both:
                    {
                        drawArrow(this.LastPoint, this.FirstPoint);
                        drawArrow(this.FirstPoint, this.LastPoint);
                        break;
                    }
            }
        }

        public override void Render(Graphics g)
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.Paint(g);
        }
    }
}
