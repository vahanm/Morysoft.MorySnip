using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Morysoft.MorySnip.Modules;

namespace Morysoft.MorySnip
{
    public partial class Form_SnippingTool
    {
        private int x, y, w, h;
        private Point FirstPoint;
        private Point LastPoint;
        private MouseButtons LastButton = MouseButtons.None;

        private bool bordersOnlyMode = false;

        public Form_SnippingTool()
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

        private void Crop()
        {
            var images = new List<Screenshot>();

            void capture()
            {
                this.Opacity = 0;
                this.Refresh();

                var b = new Bitmap(this.w, this.h);
                var g = Graphics.FromImage(b);

                g.CopyFromScreen(this._virtualScreenLocation.X + this.x, this._virtualScreenLocation.Y + this.y, 0, 0, new Size(this.w, this.h));

                images.Add(b);

                this.Opacity = 1;
                this.Refresh();
            };

            switch (this.LastButton)
            {
                case MouseButtons.Left:
                {
                    this.Hide();

                    if (!(new Keyboard()).AltKeyDown)
                    {
                        capture();
                    }
                    else
                    {
                        using (var acf = new Form_AutoCapture())
                        {
                            if (acf.ShowDialog() != DialogResult.OK)
                            {
                                Environment.Exit(0);
                            }
                            else
                            {
                                void wait(int milliseconds) => Process.GetCurrentProcess().WaitForExit(milliseconds);

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
                        }
                    }

                    this.Hide();
                    this.SaveForm.Screenshotes.AddRange(images);
                    this.SaveForm.ShowDialog();
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
            var g = e.Graphics;

            g.Clear(Color.Black);

            if (this.w > 3 && this.h > 3 && !(this.LastButton == (int)MouseButtons.None))
            {
                if (this.bordersOnlyMode)
                {
                    g.Clear(this.TransparencyKey);
                    g.DrawRectangle(new Pen(Color.Red, 2), this.x, this.y, this.w, this.h);
                }
                else
                {
                    // g.DrawLine(New Pen(Brushes.DarkOrange, 2), x, y - 5, x + w, y - 5)

                    // g.DrawLine(New Pen(Brushes.DarkOrange, 2), x - 5, y, x - 5, y + h)

                    g.FillRectangle(new SolidBrush(this.TransparencyKey), this.x, this.y, this.w + 1, this.h + 1);
                    // g.DrawRectangle(Pens.Red, x, y, w, h)
                    g.DrawRectangle(Pens.Red, -10, this.y, 10000, this.h + 1);
                    g.DrawRectangle(Pens.Red, this.x, -10, this.w + 1, 10000);

                    var r1 = Helpers.ReduceRatio(Conversions.ToUInteger(this.w / 10), Conversions.ToUInteger(this.h / 10));
                    var r2 = Helpers.ReduceRatio(Conversions.ToUInteger(this.w), Conversions.ToUInteger(this.h));
                    bool approximate = !(r1 == r2);

                    g.DrawString(String.Format("{0:# ##0px} - {1:# ##0px} -- {4}{2}:{3}", this.w, this.h, r1.Width, r1.Height, Interaction.IIf(approximate, "≈", "")), new Font(this.Font.FontFamily, 11, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.White, this.x, this.y - 14);
                }
            }
            else if ((new Mouse()).ButtonsSwapped)
            {
                g.DrawString(Properties.Resources.PressLeftClickToViewOptions, new Font(this.Font.FontFamily, 40, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.DarkGray, -this._virtualScreenLocation.X + this._primaryScreenLocation.X + 10, -this._virtualScreenLocation.Y + this._primaryScreenLocation.Y + this._primaryScreenSize.Height / 2 - 20);
            }
            else
            {
                g.DrawString(Properties.Resources.PressRightClickToViewOptions, new Font(this.Font.FontFamily, 40, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.DarkGray, -this._virtualScreenLocation.X + this._primaryScreenLocation.X + 10, -this._virtualScreenLocation.Y + this._primaryScreenLocation.Y + this._primaryScreenSize.Height / 2 - 20);
            }
        }

        private void Form_SnippingTool_Load(object sender, EventArgs e)
        {
            this.Location = SystemInformation.VirtualScreen.Location;
            this.Size = SystemInformation.VirtualScreen.Size;
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
            if (e.Button == this.LastButton)
            {
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
        }

        private void Menu_Snip_FullScreen_Click(object sender, EventArgs e) => this.SnipFullScreen();

        private void Menu_Snip_Exit_Click(object sender, EventArgs e) => this.Close();

        private void Menu_Snip_FromClipboard_Click(object sender, EventArgs e) => this.SnipFromClipboard();

        private void Menu_Snip_FromFile_Click(object sender, EventArgs e) => this.SnipFromFile();
    }
}
