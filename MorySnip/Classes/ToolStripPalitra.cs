using System.Drawing;
using System.Windows.Forms;
using System;
using System.ComponentModel;

namespace Morysoft.MorySnip
{
    public class PalitraEventArgs : EventArgs
    {
        public Color NewColor { get; set; }
        public Color OldColor { get; set; }

        public PalitraEventArgs(Color NewColor, Color OldColor)
        {
            this.NewColor = NewColor;
            this.OldColor = OldColor;
        }

        public PalitraEventArgs()
        {
        }
    }

    [DefaultEvent("ColorChanged")]
    public class ToolStripPalitra : ToolStripItem
    {
        private static Color[,] _Palitra = null;
        public static Color[,] Palitra
        {
            get
            {
                if (_Palitra == null)
                {
                    _Palitra = new Color[12, 361];
                    for (int l = 0; l <= 10; l++)
                    {
                        for (int i = 0; i <= 360 - 1; i++)
                        {
                            _Palitra[l, i] = RGBHSL.HSL_to_RGB(i / (double)365, 1 - l / (double)10, 1);
                        }
                    }
                }

                return _Palitra;
            }
        }

        public event ColorChangedEventHandler ColorChanged;

        public delegate void ColorChangedEventHandler(object sender, PalitraEventArgs e);

        public event Color1ChangedEventHandler Color1Changed;

        public delegate void Color1ChangedEventHandler(object sender, PalitraEventArgs e);

        public event Color2ChangedEventHandler Color2Changed;

        public delegate void Color2ChangedEventHandler(object sender, PalitraEventArgs e);

        private Color _Color1 = Color.Red;
        [DefaultValue(typeof(Color), "255, 0, 0")]
        public Color Color1
        {
            get => this._Color1;
            set
            {
                if (!(this._Color1 == value))
                {
                    ColorChanged?.Invoke(this, new PalitraEventArgs(value, this._Color1));
                    Color1Changed?.Invoke(this, new PalitraEventArgs());
                    this._Color1 = value;
                    this.Parent.Refresh();
                }
            }
        }

        private Color _Color2 = Color.Red;
        [DefaultValue(typeof(Color), "255, 0, 0")]
        public Color Color2
        {
            get => this._Color2;
            set
            {
                if (!(this._Color2 == value))
                {
                    ColorChanged?.Invoke(this, new PalitraEventArgs(value, this._Color2));
                    Color2Changed?.Invoke(this, new PalitraEventArgs());
                    this._Color2 = value;
                    this.Parent.Refresh();
                }
            }
        }

        private Rectangle Color1Rect = new Rectangle(5, 5, 20, 20);
        private Rectangle Color2Rect = new Rectangle(15, 15, 20, 20);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            // g.Clear(Color.Red)

            g.FillRectangle(new SolidBrush(this.Color2), this.Color2Rect);
            g.DrawRectangle(Pens.Black, this.Color2Rect);
            g.FillRectangle(new SolidBrush(this.Color1), this.Color1Rect);
            g.DrawRectangle(Pens.Black, this.Color1Rect);

            for (int l = 0; l <= 10; l++)
            {
                for (int i = 0; i <= 359; i += 3)
                {
                    g.FillRectangle(new SolidBrush(Palitra[l, i]), 70 + i, 5 + 3 * l, 3, 3);
                }
            }

            g.DrawRectangle(Pens.Black, new Rectangle());
        }

        private Color GetColorByPoint(Point p)
        {
            var colors = Palitra;
            int i = (p.Y - 5) / 3;
            int j = p.X - 70;

            if (i >= 0 && i < colors.GetLength(0) && j >= 0 && j < colors.GetLength(1))
            {
                return colors[i, j];
            }
            else
            {
                return Color.Black;
            }
        }

        private void SelectColor1(Point l)
        {
            this.Color1 = this.GetColorByPoint(l);
        }

        private void SelectColor2(Point l)
        {
            this.Color2 = this.GetColorByPoint(l);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((int)e.Button == (int)MouseButtons.Left)
            {
                this.SelectColor1(e.Location);
            }

            if ((int)e.Button == (int)MouseButtons.Right)
            {
                this.SelectColor2(e.Location);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs mea)
        {
            if ((int)mea.Button == (int)MouseButtons.Left)
            {
                this.SelectColor1(mea.Location);
            }

            if ((int)mea.Button == (int)MouseButtons.Right)
            {
                this.SelectColor2(mea.Location);
            }

            base.OnMouseMove(mea);
        }

        public ToolStripPalitra()
        {
        }
    }
}
