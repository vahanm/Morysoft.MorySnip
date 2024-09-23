using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using Morysoft.MorySnip.Classes;
using Morysoft.MorySnip.Modules;

namespace Morysoft.MorySnip;

public partial class FormSnippingTool
{
    private static Point _virtualScreenLocation;
    private static Size _virtualScreenSize;

    private static Point _primaryScreenLocation;
    private static Size _primaryScreenSize;

    private int x, y, w, h;
    private Point FirstPoint;
    private Point LastPoint;
    private MouseButtons LastButton = MouseButtons.None;

    private bool bordersOnlyMode;

    public List<Screenshot> Screenshotes { get; } = new List<Screenshot>();

    public void SnipFromClipboard()
    {
        this.SaveForm.Screenshot = Snipper.FromClipboard().FirstOrDefault();

        if (this.SaveForm.Screenshot?.Image is null)
        {
            Interaction.MsgBox("No image or image file path in clipboard.", MsgBoxStyle.Critical);
        }
        else
        {
            this.Hide();
            this.SaveForm.ShowDialog();
            this.Close();
        }
    }

    public void SnipFullScreen()
    {
        this.Hide();

        this.SaveForm.Screenshot = Snipper.AllScreens().First();

        this.SaveForm.ShowDialog();

        this.Close();
    }

    public void SnipScreen(int index) => throw new NotImplementedException();

    public void SnipFromFile()
    {
        this.Hide();

        var screenshotes = Snipper.FromFiles();

        if (!screenshotes.Any())
        {
            this.Show();
        }
        else
        {
            this.SaveForm.Screenshot = screenshotes.First();
            this.Hide();
            this.SaveForm.ShowDialog();
            this.Close();
        }
    }

    private FormEdit? _saveForm;

    public FormEdit SaveForm
    {
        get => this._saveForm ??= new FormEdit();
        set => this._saveForm = value;
    }

    public FormSnippingTool()
    {
        this.InitializeComponent();
    }

    private static readonly Keyboard systemKeyboard = new();

    private void CalculateArea()
    {
        if (this.FirstPoint.X < this.LastPoint.X)
        {
            this.x = this.FirstPoint.X;
            this.w = this.LastPoint.X - this.FirstPoint.X;
        }
        else
        {
            this.x = this.LastPoint.X;
            this.w = this.FirstPoint.X - this.LastPoint.X;
        }

        if (this.FirstPoint.Y < this.LastPoint.Y)
        {
            this.y = this.FirstPoint.Y;
            this.h = this.LastPoint.Y - this.FirstPoint.Y;
        }
        else
        {
            this.y = this.LastPoint.Y;
            this.h = this.FirstPoint.Y - this.LastPoint.Y;
        }

        if (systemKeyboard.CtrlKeyDown)
        {
            this.w = Math.Max(this.w, this.h);
            this.h = Math.Max(this.w, this.h);
        }

        if (systemKeyboard.ShiftKeyDown)
        {
            this.x = this.FirstPoint.X - this.w;
            this.y = this.FirstPoint.Y - this.h;
            this.w *= 2;
            this.h *= 2;
        }

        this.Refresh();
    }

    private void Crop()
    {
        var images = new List<Screenshot>();

        void capture()
        {
            this.Opacity = 0;
            this.Refresh();

            images.AddRange(Snipper.Areas(new Rectangle[]
            {
                    new Rectangle(this.x, this.y, this.w, this.h)
            }));

            this.Opacity = 1;
            this.Refresh();
        };

        switch (this.LastButton)
        {
            case MouseButtons.Left:
                {
                    this.Hide();

                    if (!systemKeyboard.AltKeyDown)
                    {
                        capture();

                        this.Hide();
                        this.SaveForm.Screenshot = images.First();
                        this.SaveForm.ShowDialog();
                    }
                    else
                    {
                        using var acf = new FormAutoCapture();

                        if (acf.ShowDialog() != DialogResult.OK)
                        {
                            Environment.Exit(0);

                            return;
                        }

                        static void wait(int milliseconds) => Process.GetCurrentProcess().WaitForExit(milliseconds);

                        int waitMilliseconds = (int)acf.NumericUpDown_Start.Value * 1000;
                        int intervalMilliseconds = (int)acf.NumericUpDown_Interval.Value;
                        int count = (int)acf.NumericUpDown_Count.Value;

                        this.bordersOnlyMode = true;
                        this.Opacity = 1;
                        this.Show();
                        this.Refresh();

                        for (int i = 1, loopTo = count; i <= loopTo; i++)
                        {
                            wait(i == 1 ? waitMilliseconds : intervalMilliseconds);
                            capture();
                        }

                        Publisher.PublishMultipleFrames(PublishOptions.Package, images);
                    }

                    this.Close();

                    break;
                }

            case MouseButtons.Right:
                {
                    this.Hide();

                    capture();

                    this.Screenshotes.AddRange(images);

                    var options = PublishOptions.CopyImage;

                    if (Settings.QuickShotToFile)
                    {
                        options |= PublishOptions.SaveToFile;

                        if (Settings.OpenFolder)
                        {
                            options |= PublishOptions.OpenFolder;
                        }
                    }

                    Publisher.Publish(options, images.ToArray());

                    this.Close();
                    break;
                }
        }
    }

    private void Cancel()
    {
        this.LastButton = MouseButtons.None;
        this.x = 0;
        this.y = 0;
        this.w = 0;
        this.h = 0;

        this.Refresh();
    }

    private void ShowMenu() => this.Menu_Snip.Show(Cursor.Position);

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);

        var g = e.Graphics;

        g.Clear(Color.DarkSlateGray);

        g.CompositingQuality = CompositingQuality.HighQuality;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        foreach (var screen in Screen.AllScreens)
        {
            var scaleFactor = DpiHelper.GetScaleFactorForScreen(screen);
            var bounds = screen.Bounds;
            var padding = 3;

            g.DrawRectangle(
                Pens.GreenYellow,
                bounds.Left + padding,
                bounds.Top + padding,
                bounds.Width - 2 * padding,
                bounds.Height - 2 * padding);

            g.DrawString(
                $"{screen.DeviceName} - {bounds.Width}x{bounds.Height} - {scaleFactor * 100}%",
                this.Font,
                Brushes.GreenYellow,
                bounds.Left + 2 * padding,
                bounds.Top + 2 * padding);
        }

        if (this.LastButton == MouseButtons.None)
        {
            this.DrawInstructions(g);

            return;
        }

        if (this.bordersOnlyMode)
        {
            this.DrawCropAreaWithBordersOnly(g);

            return;
        }

        this.DrawCropArea(g);
    }

    private void DrawCropArea(Graphics g)
    {
        using var brush = new SolidBrush(this.TransparencyKey);

        g.FillRectangle(brush, this.x, this.y, this.w + 1, this.h + 1);
        g.DrawRectangle(Pens.DarkGray, -10, this.y - 1, 10000, this.h + 3);
        g.DrawRectangle(Pens.DarkGray, this.x - 1, -10, this.w + 3, 10000);
        g.DrawRectangle(Pens.LightGray, this.x, this.y, this.w + 1, this.h + 1);

        var r1 = Helpers.ReduceRatio(Convert.ToUInt32(this.w / 10), Convert.ToUInt32(this.h / 10));
        var r2 = Helpers.ReduceRatio(Convert.ToUInt32(this.w), Convert.ToUInt32(this.h));
        bool approximate = !(r1 == r2);
        using var font = new Font(this.Font.FontFamily, 11, FontStyle.Italic, GraphicsUnit.Point);
        var sizeText = $"{this.w:#,##0} x {this.h:#,##0} {(approximate ? "≈" : "=")} {r1.Width}:{r1.Height}";
        var (sizeTextWidth, sizeTextHeight) = g.MeasureString(sizeText, font);
        var sizeTextX = this.x + 5;
        var sizeTextY = (float)(this.y - font.Height * 1.1) - 5;
        var padding = 6.0F;

        g.DrawRoundedRectangle(
            sizeTextX,
            sizeTextY - 2 * padding,
            sizeTextWidth + 2 * padding,
            sizeTextHeight + 2 * padding,
            sizeTextHeight / 4,
            new SolidBrush(Color.Black),
            new Pen(Color.FromArgb(30, 30, 30), 4)
        );

        g.DrawString(
            sizeText,
            font,
            Brushes.White,
            sizeTextX + padding,
            sizeTextY - padding
        );
    }

    private void DrawInstructions(Graphics g)
    {
        using var font = new Font(this.Font.FontFamily, _primaryScreenSize.Height / 20, FontStyle.Italic, GraphicsUnit.Pixel);

        g.DrawString((new Mouse()).ButtonsSwapped
            ? Properties.Resources.PressLeftClickToViewOptions
            : Properties.Resources.PressRightClickToViewOptions,
            font,
            Brushes.DarkGray,
            -_virtualScreenLocation.X + _primaryScreenLocation.X + 10,
            -_virtualScreenLocation.Y + _primaryScreenLocation.Y + (_primaryScreenSize.Height / 2) - font.Height
        );
    }

    private void DrawCropAreaWithBordersOnly(Graphics g)
    {
        g.Clear(this.TransparencyKey);

        using var pen = new Pen(Color.Red, 2);

        g.DrawRectangle(pen, this.x, this.y, this.w, this.h);
    }

    private void Form_SnippingTool_Load(object sender, EventArgs e)
    {
        _virtualScreenLocation = SystemInformation.VirtualScreen.Location;
        _virtualScreenSize = SystemInformation.VirtualScreen.Size;

        _primaryScreenLocation = Screen.PrimaryScreen.WorkingArea.Location; // .Bounds.Location;
        _primaryScreenSize = Screen.PrimaryScreen.WorkingArea.Size; // .Bounds.Size;

        this.Location = _virtualScreenLocation;
        this.Size = _virtualScreenSize;
    }

    private void Form_SnippingTool_KeyDown(object sender, KeyEventArgs e)
    {
        if (this.LastButton == MouseButtons.None)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
        else
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancel();
                    break;

                case Keys.ControlKey:
                case Keys.ShiftKey:
                    this.CalculateArea();
                    break;

                case Keys.Enter:
                    this.Crop();
                    break;
            }
        }
    }

    private void Form_SnippingTool_KeyUp(object sender, KeyEventArgs e)
    {
        if (this.LastButton != MouseButtons.None)
        {
            this.CalculateArea();
        }
        else
        {
            switch (e.KeyCode)
            {
                case Keys.Apps:
                    this.ShowMenu();
                    break;
            }
        }
    }

    private void Form_SnippingTool_MouseDown(object sender, MouseEventArgs e)
    {
        if (this.LastButton == MouseButtons.None)
        {
            this.FirstPoint = e.Location;
            this.LastPoint = e.Location;
            this.LastButton = e.Button;
        }
    }

    private void Form_SnippingTool_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == this.LastButton && this.LastButton != MouseButtons.None)
        {
            this.LastPoint = e.Location;
            this.CalculateArea();
        }
    }

    private void Form_SnippingTool_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button != this.LastButton)
        {
            return;
        }

        if (this.LastButton != MouseButtons.None && this.w > 3 && this.h > 3)
        {
            this.LastPoint = e.Location;
            this.CalculateArea();
            this.Crop();
        }
        else if (e.Button == MouseButtons.Right && this.w < 3 && this.h < 3)
        {
            this.ShowMenu();
        }

        this.LastButton = MouseButtons.None;
        this.Refresh();
    }

    private void Menu_Snip_FullScreen_Click(object sender, EventArgs e) => this.SnipFullScreen();

    private void Menu_Snip_Settings_Click(object sender, EventArgs e)
    {
        this.Hide();

        FormSettings.Show();

        this.Show();
    }

    private void Menu_Snip_Exit_Click(object sender, EventArgs e) => this.Close();

    private void Menu_Snip_FromClipboard_Click(object sender, EventArgs e) => this.SnipFromClipboard();

    private void Menu_Snip_FromFile_Click(object sender, EventArgs e) => this.SnipFromFile();
}
