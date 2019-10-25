using System.Drawing;

namespace Morysoft.MorySnip
{
    public abstract class Layer
    {
        public Point Offset { get; set; }
        public bool Fill { get; set; }
        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
        public Point FirstPoint { get; set; }
        public Point LastPoint { get; set; }

        public virtual void Start(Point FirstPoint)
        {
            this.FirstPoint = FirstPoint;
            this.LastPoint = FirstPoint;
        }

        public virtual void Step(Point StepPoint) => this.LastPoint = StepPoint;

        public virtual void Stop(Point LastPoint)
        {
            this.LastPoint = LastPoint;

            if (this.Pen != null)
            {
                this.Pen = (Pen)this.Pen.Clone();
            }

            if (this.Brush != null)
            {
                this.Brush = (Brush)this.Brush.Clone();
            }
        }

        public virtual Rectangle Bounds => Helpers.NormalRectingle(this.FirstPoint, this.LastPoint);

        public bool InBounds(Point p)
        {
            return p.X > this.Bounds
   .X && p.Y > this.Bounds.Y && p.X < this.Bounds.X + this.Bounds.Width && p.Y < this.Bounds.Y + this.Bounds.Height;
        }

        public virtual void Render(Graphics g)
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.Paint(g);
        }

        public abstract void Paint(Graphics g);
    }
}
