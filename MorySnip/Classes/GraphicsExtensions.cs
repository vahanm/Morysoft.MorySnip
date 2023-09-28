// Ignore Spelling: Deconstruct

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Morysoft.MorySnip.Classes
{
    internal static class GraphicsExtensions
    {
        public static void DrawRoundedRectangle(
            this Graphics graphics,
            float x,
            float y,
            float width,
            float height,
            float cornerRadius, Brush brush, Pen pen)
        {
            if (graphics is null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            using var path = new GraphicsPath();
            var diameter = cornerRadius * 2;
            var arc = new RectangleF(x, y, diameter, diameter);

            // Top-left corner
            path.AddArc(arc, 180, 90);

            // Top-right corner
            arc.X = x + width - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom-right corner
            arc.Y = y + height - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom-left corner
            arc.X = x;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();

            graphics.DrawPath(pen, path);
            graphics.FillPath(brush, path);
        }

        public static void Deconstruct(this SizeF size, out float sizeWidth, out float sizeHeight)
        {
            sizeWidth = size.Width;
            sizeHeight = size.Height;
        }
    }
}
