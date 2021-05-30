using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Morysoft.MorySnip.Draw
{
    [Flags]
    public enum ArrowModes
    {
        AtStart = 1,
        AtEnd = 2,
        Both = AtStart | AtEnd
    }

    public static class Arrow
    {
        private static void DrawEnd(Graphics g, Pen pen, Brush brush, Point pBegin, Point pEnd)
        {
            var newZero = (Polar)pBegin - pEnd;

            var sizeBase = Math.Max(pen.Width, 2.5f);

            var tailPolarL = new Polar(newZero.Angle - (float)Math.PI / 2, sizeBase * 2); //  + newZero.Radius / 100
            var tailPolarR = new Polar(newZero.Angle + (float)Math.PI / 2, sizeBase * 2); //  + newZero.Radius / 100
            var tailPolarE = new Polar(newZero.Angle + (float)Math.PI, sizeBase * 5); //  + newZero.Radius / 50

            var tailL = tailPolarL + pEnd;
            var tailR = tailPolarR + pEnd;
            var tailE = tailPolarE + pEnd;

            using var path = new GraphicsPath(new Point[] { tailL, tailE, tailR }, new byte[] { 1, 1, 1 });

            g.FillPath(brush, path);

            //g.DrawCurve(this.Pen, new Point[] { tail12, pEnd }, 0.5f);
            //g.DrawCurve(this.Pen, new Point[] { tail22, pEnd }, 0.5f);
        }

        public static void DrawArrow(this Graphics g, Pen pen, Brush brush, Point pBegin, Point pEnd, ArrowModes arrowMode)
        {
            if (g is null)
            {
                throw new ArgumentNullException(nameof(g));
            }

            if (pen is null)
            {
                throw new ArgumentNullException(nameof(pen));
            }

            if (brush is null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            switch (arrowMode)
            {
                case ArrowModes.AtEnd:
                    {
                        g.DrawLine(pen, pBegin, pEnd);
                        DrawEnd(g, pen, brush, pBegin, pEnd);
                        break;
                    }

                case ArrowModes.AtStart:
                    {
                        g.DrawLine(pen, pBegin, pEnd);
                        DrawEnd(g, pen, brush, pBegin, pEnd);
                        break;
                    }

                case ArrowModes.Both:
                    {
                        g.DrawLine(pen, pBegin, pEnd);
                        DrawEnd(g, pen, brush, pBegin, pEnd);
                        DrawEnd(g, pen, brush, pBegin, pEnd);
                        break;
                    }
            }
        }
    }
}
