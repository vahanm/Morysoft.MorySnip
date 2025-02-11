using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Morysoft.MorySnip.Classes;

namespace Morysoft.MorySnip.Draw;

[Flags]
public enum ArrowModes
{
    None = 0,
    AtStart = 1,
    AtEnd = 2,
    Both = AtStart | AtEnd
}

public static class Arrow
{
    private static void DrawEnd(Graphics g,
                                Pen pen,
                                Brush brush,
                                Point pBegin,
                                Point pEnd,
                                out Point tailLocation)
    {
        var newZero = (Polar)pBegin - pEnd;

        var sizeBase = Math.Max(pen.Width, 2.5f);

        var tailPolarShift = new Polar(newZero.Angle + (float)Math.PI, sizeBase * 5); //  + newZero.Radius / 50
        var tailPolarL = new Polar(newZero.Angle - (float)Math.PI / 2, sizeBase * 2); //  + newZero.Radius / 100
        var tailPolarR = new Polar(newZero.Angle + (float)Math.PI / 2, sizeBase * 2); //  + newZero.Radius / 100

        tailLocation = (Polar)pEnd - tailPolarShift;

        var tailL = tailPolarL + tailLocation;
        var tailR = tailPolarR + tailLocation;

        using var path = new GraphicsPath(new Point[] { tailL, pEnd, tailR }, [1, 1, 1]);

        g.FillPath(brush, path);

        //g.DrawCurve(this.Pen, new Point[] { tail12, pEnd }, 0.5f);
        //g.DrawCurve(this.Pen, new Point[] { tail22, pEnd }, 0.5f);
    }

    public static void DrawArrow(this Graphics g, Pen pen, Brush brush, Point pBegin, Point pEnd, ArrowModes arrowMode)
    {
        ArgumentNullException.ThrowIfNull(g);
        ArgumentNullException.ThrowIfNull(pen);
        ArgumentNullException.ThrowIfNull(brush);

        switch (arrowMode)
        {
            case ArrowModes.AtEnd:
                {
                    DrawEnd(g, pen, brush, pBegin, pEnd, out var tailLocation);

                    g.DrawLine(pen, pBegin, tailLocation);
                    break;
                }

            case ArrowModes.AtStart:
                {
                    DrawEnd(g, pen, brush, pEnd, pBegin, out var tailLocation);
                    g.DrawLine(pen, tailLocation, pEnd);
                    break;
                }

            case ArrowModes.Both:
                {
                    DrawEnd(g, pen, brush, pBegin, pEnd, out var tailLocationEnd);
                    DrawEnd(g, pen, brush, pEnd, pBegin, out var tailLocationBegin);
                    g.DrawLine(pen, tailLocationBegin, tailLocationEnd);
                    break;
                }
        }
    }
}
