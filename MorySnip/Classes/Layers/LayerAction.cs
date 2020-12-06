using System.Drawing;
using System.Drawing.Drawing2D;

namespace Morysoft.MorySnip
{
    public class LayerAction : Layer
    {
        public LayerAction(Point FirstPoint, Actions Action, Zones Zone)
        {
            this.Action = Action;
            this.Zone = Zone;
            this.Start(FirstPoint);
        }

        public Actions Action { get; set; }

        public Zones Zone { get; set; }

        private readonly Pen Pen1 = new Pen(Color.White, 1);
        private readonly Pen Pen2 = new Pen(Color.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Custom, DashPattern = new float[] { 3, 3 } };
        private readonly HatchBrush BrushFill = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal, Color.DarkGray, Color.Transparent);

        public override void Paint(Graphics g)
        {
            var r = this.Bounds;

            switch (this.Zone)
            {
                case Zones.NotSelected:
                {
                    if (r.Y > 0)
                    {
                        g.FillRectangle(this.BrushFill, new Rectangle(0, 0, 10000, r.Y));
                    }

                    if (r.X > 0)
                    {
                        g.FillRectangle(this.BrushFill, new Rectangle(0, r.Y, r.X, 10000));
                    }

                    g.FillRectangle(this.BrushFill, new Rectangle(r.X, r.Y + r.Height, 10000, 10000));
                    g.FillRectangle(this.BrushFill, new Rectangle(r.X + r.Width, r.Y, 10000, r.Height));
                    break;
                }

                case Zones.Selected:
                {
                    g.FillRectangle(this.BrushFill, r);
                    break;
                }
            }

            g.DrawRectangle(this.Pen1, r);
            g.DrawRectangle(this.Pen2, r);
        }

        public override void Render(Graphics g)
        {
        }

        public override bool IsValid => this.FirstPoint.X != this.LastPoint.X && this.FirstPoint.Y != this.LastPoint.Y;
    }
}
