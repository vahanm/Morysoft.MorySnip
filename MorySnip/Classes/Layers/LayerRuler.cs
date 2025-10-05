using System.Drawing;

namespace Morysoft.MorySnip.Classes.Layers;

public class LayerRuler : Layer
{
    public LayerRuler()
    {
    }

    public LayerRuler(Pen pen, Point firstPoint)
    {
        this.Pen = pen;
        this.Start(firstPoint);
    }

    public float Length => (float)Math.Sqrt(
        Math.Pow(this.FirstPoint.X - this.LastPoint.X, 2) + Math.Pow(this.FirstPoint.Y - this.LastPoint.Y, 2)
    );

    public override void Paint(Graphics g)
    {
        //g.DrawLine(this.Pen, this.FirstPoint, this.LastPoint);

        g.TranslateTransform(this.FirstPoint.X, this.FirstPoint.Y);

        var deltaX = this.LastPoint.X - this.FirstPoint.X;
        var deltaY = this.LastPoint.Y - this.FirstPoint.Y;

        // Calculate the angle in radians
        var angleInRadians = (float)Math.Atan2(deltaY, deltaX);

        // Convert to degrees if needed
        var angleInDegrees = (float)(angleInRadians * (180 / Math.PI));

        g.RotateTransform(angleInDegrees);

        var length = (int)Math.Sqrt(Math.Pow(this.FirstPoint.X - this.LastPoint.X, 2) + Math.Pow(this.FirstPoint.Y - this.LastPoint.Y, 2));
        Pen pen = this.Pen ?? new Pen(Color.Red, 1);
        var penWidth = Math.Max(1, (int?)pen?.Width ?? 0);
        var stepSize = penWidth switch
        {
            > 10 => 100,
            > 8 => 50,
            > 5 => 50,
            > 2 => 20,
            _ => 10,
        };

        var width = penWidth * 10;

        g.DrawRectangle(pen!, 0, 0, length, width);

        var f = new Font("Courier New", 3 * penWidth + 1);

        for (int l = stepSize; l < length - penWidth; l += stepSize)
        {
            var odd = l % (2 * stepSize) == 0;
            var y2 = odd ? width / 3 : width / 4;

            g.DrawLine(
                new Pen(
                    pen!.Color,
                    penWidth
                ),
                l,
                0,
                l,
                y2
            );

            if (penWidth > 2 && odd)
            {
                var t = $"{l / 10}";

                g.DrawString(t, f, new SolidBrush(pen.Color), l - g.MeasureString(t, f).Width / 2, y2);
            }
        }

        g.ResetTransform();
    }
}
