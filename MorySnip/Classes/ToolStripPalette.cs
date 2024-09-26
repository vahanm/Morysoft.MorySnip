using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Morysoft.MorySnip.Classes;

public class PaletteEventArgs : EventArgs
{
    public Color NewColor { get; set; }

    public Color OldColor { get; set; }

    public PaletteEventArgs(Color newColor, Color oldColor)
    {
        this.NewColor = newColor;
        this.OldColor = oldColor;
    }

    public PaletteEventArgs()
    {
    }
}

public delegate void ColorChangedEventHandler(object sender, PaletteEventArgs e);

public delegate void Color1ChangedEventHandler(object sender, PaletteEventArgs e);

public delegate void Color2ChangedEventHandler(object sender, PaletteEventArgs e);

[DefaultEvent("ColorChanged")]
public class ToolStripPalette : ToolStripItem
{
    private static Color[,]? palitra;

    private static Color[,] Palitra
    {
        get
        {
            if (palitra == null)
            {
                palitra = new Color[12, 361];
                for (var l = 0; l <= 10; l++)
                {
                    for (var i = 0; i <= 360 - 1; i++)
                    {
                        palitra[l, i] = RGBHSL.HSL_to_RGB(i / (double)365, 1 - l / (double)10, 1);
                    }
                }
            }

            return palitra;
        }
    }

    public event ColorChangedEventHandler? ColorChanged;

    public event Color1ChangedEventHandler? Color1Changed;

    public event Color2ChangedEventHandler? Color2Changed;

    private Color color1 = Color.Red;
    private Color color2 = Color.Red;

    private Rectangle Color1Rect = new(5, 5, 20, 20);
    private Rectangle Color2Rect = new(15, 15, 20, 20);

    [DefaultValue(typeof(Color), "255, 0, 0")]
    public Color Color1
    {
        get => this.color1;
        set
        {
            if (this.color1 == value)
            {
                return;
            }

            if (this.color2 == this.color1)
            {
                this.color2 = value;
                Color2Changed?.Invoke(this, new PaletteEventArgs());
            }

            var oldColor = this.color1;

            this.color1 = value;
            Color1Changed?.Invoke(this, new PaletteEventArgs());

            ColorChanged?.Invoke(this, new PaletteEventArgs(value, oldColor));

            this.Parent.Refresh();
        }
    }

    [DefaultValue(typeof(Color), "255, 0, 0")]
    public Color Color2
    {
        get => this.color2;
        set
        {
            if (this.color2 == value)
            {
                return;
            }

            var oldColor = this.color2;

            this.color2 = value;
            ColorChanged?.Invoke(this, new PaletteEventArgs(value, oldColor));
            Color2Changed?.Invoke(this, new PaletteEventArgs());
            this.Parent.Refresh();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var g = e.Graphics;
        // g.Clear(Color.Red)

        g.FillRectangle(new SolidBrush(this.Color2), this.Color2Rect);
        g.DrawRectangle(Pens.Black, this.Color2Rect);
        g.FillRectangle(new SolidBrush(this.Color1), this.Color1Rect);
        g.DrawRectangle(Pens.Black, this.Color1Rect);

        for (var l = 0; l <= 10; l++)
        {
            for (var i = 0; i <= 359; i += 3)
            {
                g.FillRectangle(new SolidBrush(Palitra[l, i]), 70 + i, 5 + 3 * l, 3, 3);
            }
        }

        g.DrawRectangle(Pens.Black, new Rectangle());
    }

    private static bool TryGetColorByPoint(Point p, out Color color)
    {
        var colors = Palitra;
        var i = (p.Y - 5) / 3;
        var j = p.X - 70;

        var inRange = i >= 0 && i < colors.GetLength(0) && j >= 0 && j < colors.GetLength(1);

        color = inRange ? colors[i, j] : Color.White;

        return inRange;
    }

    private void SelectColor1(Point point)
    {
        if (TryGetColorByPoint(point, out var color))
        {
            this.Color1 = color;
        }
    }

    private void SelectColor2(Point point)
    {
        if (TryGetColorByPoint(point, out var color))
        {
            this.Color2 = color;
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            this.SelectColor1(e.Location);
        }

        if (e.Button == MouseButtons.Right)
        {
            this.SelectColor2(e.Location);
        }

        base.OnMouseDown(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            this.SelectColor1(e.Location);
        }

        if (e.Button == MouseButtons.Right)
        {
            this.SelectColor2(e.Location);
        }

        base.OnMouseMove(e);
    }

    public ToolStripPalette()
    {
    }
}
