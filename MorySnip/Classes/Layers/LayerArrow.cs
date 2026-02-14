using System.Drawing;
using System.Drawing.Drawing2D;
using Morysoft.MorySnip.Draw;

namespace Morysoft.MorySnip.Classes.Layers;

public class LayerArrow : Layer
{
    public LayerArrow() { }

    public LayerArrow(Pen pen, Brush brush, Point firstPoint, ArrowModes arrowMode)
    {
        this.Pen = pen;
        this.Brush = brush;
        this.ArrowMode = arrowMode;

        this.Start(firstPoint);
    }

    public ArrowModes ArrowMode { get; set; }

    public override void Paint(Graphics g) => g.DrawArrow(this.Pen, this.Brush, this.FirstPoint, this.LastPoint, this.ArrowMode);

    public override void Render(Graphics g)
    {
        ArgumentNullException.ThrowIfNull(g);

        g.CompositingQuality = CompositingQuality.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        this.Paint(g);
    }

    public override void SecondaryAction()
    {
        this.ArrowMode = this.ArrowMode switch
        {
            ArrowModes.AtEnd => ArrowModes.AtStart,
            ArrowModes.AtStart => ArrowModes.Both,
            ArrowModes.Both => ArrowModes.AtEnd,
            _ => ArrowModes.AtStart,
        };
    }
}
