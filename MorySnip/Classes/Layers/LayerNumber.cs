using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip
{
    public class LayerNumber : Layer
    {
        public LayerNumber()
        {
        }

        public LayerNumber(Pen Pen, Brush Brush, Point FirstPoint, int Number)
        {
            this.Pen = Pen;
            this.Brush = Brush;
            this.Number = Number;
            this.Start(FirstPoint);
        }
        public int Number { get; set; }

        public override void Paint(Graphics g)
        {
            var r = this.Bounds;

            // If Me.Fill Then
            // g.FillRectangle(Brush, r)
            // End If
            g.DrawRectangle(this.Pen, r);

            int w = Conversions.ToInteger(this.Pen.Width);
            int s = 8 + w;
            var f = new Font("Courier New", s + 2);

            int h = Conversions.ToInteger(g.MeasureString("000", f).Width);
            var t = g.MeasureString(Conversions.ToString(this.Number), f);

            var rb = new Rectangle(r.X - h / 2, r.Y - h / 2, h, h);
            var rf = new Rectangle(r.X - h / 2 + 1, r.Y - h / 2 + 1, h - 2, h - 2);
            g.FillEllipse(Brushes.White, rf);
            g.DrawEllipse(new Pen(this.Pen.Color, Conversions.ToLong(this.Pen.Width) / 2 + 1) { Alignment = System.Drawing.Drawing2D.PenAlignment.Outset }, rb);
            g.DrawString(Conversions.ToString(this.Number), f, Brushes.Black, r.X - t.Width / 2, r.Y - (t.Height + s) / 4);
        }
    }
}
