using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Morysoft.MorySnip.Modules;

namespace Morysoft.MorySnip
{
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

        private FormEdit _saveForm;

        public FormEdit SaveForm
        {
            get
            {
                if (this._saveForm == null)
                {
                    this._saveForm = new FormEdit();
                }

                return this._saveForm;
            }
            set => this._saveForm = value;
        }

        public FormSnippingTool()
        {
            this.InitializeComponent();
        }

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

            if ((new Keyboard()).CtrlKeyDown)
            {
                this.w = Math.Max(this.w, this.h);
                this.h = Math.Max(this.w, this.h);
            }

            if ((new Keyboard()).ShiftKeyDown)
            {
                this.x = this.FirstPoint.X - this.w;
                this.y = this.FirstPoint.Y - this.h;
                this.w *= 2;
                this.h *= 2;
            }

            this.Refresh();
        }

        Keyboard systemKeyboard = new Keyboard();

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
                        }

                        Publisher.PublishMultipleFrames(PublishOptions.AsAlbum, images);

                        this.Close();

                        break;
                    }

                case MouseButtons.Right:
                    {
                        this.Hide();

                        capture();

                        this.Screenshotes.AddRange(images);
                        Publisher.Publish(PublishOptions.CopyImage, images.ToArray());
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
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            var g = e.Graphics;

            g.Clear(Color.Black);

            if (this.w < 3 || this.h < 3 || this.LastButton == MouseButtons.None)
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
            g.DrawRectangle(Pens.Red, -10, this.y, 10000, this.h + 1);
            g.DrawRectangle(Pens.Red, this.x, -10, this.w + 1, 10000);

            var r1 = Helpers.ReduceRatio(Conversions.ToUInteger(this.w / 10), Conversions.ToUInteger(this.h / 10));
            var r2 = Helpers.ReduceRatio(Conversions.ToUInteger(this.w), Conversions.ToUInteger(this.h));
            bool approximate = !(r1 == r2);
            using var font = new Font(this.Font.FontFamily, _primaryScreenSize.Height / 45, FontStyle.Italic, GraphicsUnit.Pixel);

            g.DrawString($"{this.w:# ##0px} - {this.h:# ##0px} -- {(approximate ? "≈" : "")}{r1.Width}:{r1.Height}",
                font,
                Brushes.White,
                this.x,
                (float)(this.y - font.Height * 1.1)
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
        }

        private void Menu_Snip_FullScreen_Click(object sender, EventArgs e) => this.SnipFullScreen();

        private void Menu_Snip_Settings_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form_Settings.Show();

            this.Show();
        }

        private void Menu_Snip_Exit_Click(object sender, EventArgs e) => this.Close();

        private void Menu_Snip_FromClipboard_Click(object sender, EventArgs e) => this.SnipFromClipboard();

        private void Menu_Snip_FromFile_Click(object sender, EventArgs e) => this.SnipFromFile();
    }
}
