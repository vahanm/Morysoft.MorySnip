using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using System.Drawing.Drawing2D;

namespace Morysoft.MorySnip
{
    public partial class Editor
    {
        private readonly List<Image> PreviousSteps = new List<Image>();
        private readonly List<Image> NextSteps = new List<Image>();
        private readonly List<Layer> Layers = new List<Layer>();
        private Point ImagePosition = new Point(0, 0);

        private MouseButtons LastButton = MouseButtons.None;
        private int _LastNumber = 1;

        public event LastNumberChangedEventHandler LastNumberChanged;

        public delegate void LastNumberChangedEventHandler(object sender, EventArgs e);

        public void CreateCheckpoint(Image Image = null)
        {
            if (Image == null)
            {
                Image = this.GetResult();
            }

            this.PreviousSteps.Add(Image);
            this.NextSteps.Clear();
        }

        public int LastNumber
        {
            get => this._LastNumber;
            set
            {
                this._LastNumber = value;

                LastNumberChanged?.Invoke(this, new EventArgs());
            }
        }

        public bool CanRedo
        {
            get
            {
                return this.NextSteps.Count > 0;
            }
        }

        public bool CanUndo
        {
            get
            {
                return this.PreviousSteps.Count > 0;
            }
        }

        public void Redo()
        {
            if (this.CanRedo)
            {
                this.PreviousSteps.Add(this.GetResult());
                this.BackgroundImage = this.NextSteps[this.NextSteps.Count - 1];
                this.NextSteps.RemoveAt(this.NextSteps.Count - 1);
            }
        }

        public void Undo()
        {
            if (this.CanUndo)
            {
                this.NextSteps.Add(this.GetResult());
                this.Layers.Clear();
                this.BackgroundImage = this.PreviousSteps[this.PreviousSteps.Count - 1];
                this.PreviousSteps.RemoveAt(this.PreviousSteps.Count - 1);
            }
        }

        public void Render()
        {
            var result = this.GetResult();

            this.BackgroundImage = result;

            this.Layers.Clear();
            this.ImagePosition = new Point();
        }

        public Image GetResult()
        {
            var result = new Bitmap(this.Width, this.Height);

            var g = Graphics.FromImage(result);

            g.Clear(Color.White);

            if (this.Img != null)
            {
                g.DrawImage(this.Img, this.ImagePosition.X, this.ImagePosition.Y, this.Img.Size.Width, this.Img.Size.Height);
            }

            foreach (Layer l in this.Layers)
            {
                l.Render(g);
            }

            return result;
        }
        public Pen CurrentPen { get; private set; } = new Pen(Brushes.Red, 2) { StartCap = LineCap.Round, EndCap = LineCap.Round, Alignment = PenAlignment.Inset };

        private Brush CurrentBrushValue = new SolidBrush(Color.Red);

        public Brush CurrentBrush
        {
            get => this.CurrentBrushValue;
            set => this.CurrentBrushValue = value;
        }

        private Image Img
        {
            get => this.BackgroundImage;
            set
            {
                this.ImagePosition.X = 0;
                this.ImagePosition.Y = 0;
                this.BackgroundImage = value;
            }
        }

        private readonly SolidBrush GrayedAreaBrush = new SolidBrush(Color.FromArgb(200, 0, 0, 0));
        private readonly Color HighlightColor = Color.FromArgb(100, Color.Yellow);
        private readonly SolidBrush HighlightBrush = new SolidBrush(Color.FromArgb(100, Color.Yellow));

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);

            if (this.Img == null)
            {
                g.DrawString("NO IMAGE !!!", this.Font, Brushes.Red, 5, 5);
            }
            else
            {
                g.DrawImage(this.Img, this.ImagePosition.X, this.ImagePosition.Y, this.Img.Size.Width, this.Img.Size.Height);
            }

            foreach (Layer l in this.Layers)
            {
                l.Render(g);
            }

            if (this.NewLayer != null)
            {
                this.NewLayer.Paint(g);
            }
        }

        public enum PaintModes
        {
            Free,
            Line,
            Arrow,
            Oval,
            Rect,
            Number,
            Highlight,
            Invert,
            Blur,
            Puzzle,
            Crop,
            Grayscale
        }

        private PaintModes _PaintMode = PaintModes.Free;
        private PaintModes _PaintModeLast = PaintModes.Free;

        public void SetLastPaintMode()
        {
            this.PaintMode = this._PaintModeLast;
        }

        public PaintModes PaintMode
        {
            get => this._PaintMode;
            set
            {
                this._PaintModeLast = this._PaintMode;
                this._PaintMode = value;
            }
        }

        public bool FillObjecs { get; set; } = true;

        private readonly bool Painting = false;
        private Point PBegin;
        private Point PEnd;

        private void Editor_BackgroundImageChanged(object sender, EventArgs e)
        {
            this.ResetImageSizeAndPosition();
        }

        public void ResetImageSizeAndPosition()
        {
            if (this.BackgroundImage != null)
            {
                this.Size = this.BackgroundImage.Size;
                this.ImagePosition = new Point();
                this.Refresh();
            }
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Escape && e.Control == false)
            {
                this.NewLayer = null;
                this.Refresh();
            }
        }

        private Layer NewLayer;

        private void Editor_MouseClick(object sender, MouseEventArgs e)
        {
            if ((int)this.LastButton == (int)MouseButtons.Left && (int)e.Button == (int)MouseButtons.Right || (int)this.LastButton == (int)MouseButtons.Right && (int)e.Button == (int)MouseButtons.Left)
            {
                if (this.NewLayer is LayerArrow NewLayerArrow)
                {
                    switch (NewLayerArrow.ArrowMode)
                    {
                        case ArrowModes.AtEnd:
                            {
                                NewLayerArrow.ArrowMode = ArrowModes.AtStart;
                                break;
                            }

                        case ArrowModes.AtStart:
                            {
                                NewLayerArrow.ArrowMode = ArrowModes.Both;
                                break;
                            }

                        case ArrowModes.Both:
                            {
                                NewLayerArrow.ArrowMode = ArrowModes.AtEnd;
                                break;
                            }
                    }
                }
            }
        }

        private void Editor_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.LastButton == (int)MouseButtons.None)
            {
                this.LastButton = e.Button;

                switch (e.Button)
                {
                    case MouseButtons.Left:
                    case MouseButtons.Right:
                        {
                            switch (this.PaintMode)
                            {
                                case PaintModes.Line:
                                    {
                                        if ((int)e.Button == (int)MouseButtons.Right)
                                        {
                                            this.CurrentPen.DashStyle = DashStyle.DashDotDot;
                                        }

                                        this.NewLayer = new Layer_Line(this.CurrentPen, e.Location);
                                        break;
                                    }

                                case PaintModes.Rect:
                                    {
                                        this.NewLayer = new Layer_Rect(this.CurrentPen, this.CurrentBrush, e.Location) { Fill = (int)e.Button == (int)MouseButtons.Right ^ this.FillObjecs };
                                        break;
                                    }

                                case PaintModes.Number:
                                    {
                                        this.NewLayer = new Layer_Number(this.CurrentPen, this.CurrentBrush, e.Location, this.LastNumber) { Fill = (int)e.Button == (int)MouseButtons.Right ^ this.FillObjecs };
                                        break;
                                    }

                                case PaintModes.Oval:
                                    {
                                        this.NewLayer = new Layer_Oval(this.CurrentPen, this.CurrentBrush, e.Location) { Fill = (int)e.Button == (int)MouseButtons.Right ^ this.FillObjecs };
                                        break;
                                    }

                                case PaintModes.Free:
                                    {
                                        this.NewLayer = new Layer_Free(this.CurrentPen, this.CurrentBrush, e.Location) { Fill = (int)e.Button == (int)MouseButtons.Right ^ this.FillObjecs };
                                        break;
                                    }

                                case PaintModes.Arrow:
                                    {
                                        this.NewLayer = new LayerArrow(this.CurrentPen, this.CurrentBrush, e.Location, ArrowMode: (int)e.Button == (int)MouseButtons.Right ? ArrowModes.AtStart : ArrowModes.AtEnd);
                                        break;
                                    }

                                case PaintModes.Invert:
                                    {
                                        this.NewLayer = new Layer_Action(e.Location, Actions.Invert, (Zones)Interaction.IIf((int)e.Button == (int)MouseButtons.Right, Zones.NotSelected, Zones.Selected));
                                        break;
                                    }

                                case PaintModes.Blur:
                                    {
                                        this.NewLayer = new Layer_Action(e.Location, Actions.Blur, (Zones)Interaction.IIf((int)e.Button == (int)MouseButtons.Right, Zones.NotSelected, Zones.Selected));
                                        break;
                                    }

                                case PaintModes.Puzzle:
                                    {
                                        this.NewLayer = new Layer_Action(e.Location, Actions.Puzzle, (Zones)Interaction.IIf((int)e.Button == (int)MouseButtons.Right, Zones.NotSelected, Zones.Selected));
                                        break;
                                    }

                                case PaintModes.Grayscale:
                                    {
                                        this.NewLayer = new Layer_Action(e.Location, Actions.Grayscale, (Zones)Interaction.IIf((int)e.Button == (int)MouseButtons.Right, Zones.NotSelected, Zones.Selected));
                                        break;
                                    }

                                case PaintModes.Highlight:
                                    {
                                        this.NewLayer = new Layer_Action(e.Location, Actions.Highlight, Zones.Selected);
                                        break;
                                    }

                                case PaintModes.Crop:
                                    {
                                        this.NewLayer = new Layer_Action(e.Location, Actions.Crop, Zones.Selected);
                                        break;
                                    }
                            }

                            break;
                        }

                    case MouseButtons.Middle:
                        {
                            this.PBegin = e.Location;
                            break;
                        }

                    default:
                        {
                            this.LastButton = MouseButtons.None;
                            break;
                        }
                }
            }
        }

        private void Editor_MouseMove(object sender, MouseEventArgs e)
        {
            if ((int)e.Button == (int)this.LastButton & !(this.LastButton == (int)MouseButtons.None))
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                    case MouseButtons.Right:
                        {
                            if (this.NewLayer != null)
                            {
                                this.NewLayer.Step(e.Location);
                            }

                            break;
                        }

                    case MouseButtons.Middle:
                        {
                            this.ImagePosition.X += e.Location.X - this.PBegin.X;
                            this.ImagePosition.Y += e.Location.Y - this.PBegin.Y;

                            this.PBegin = e.Location;

                            break;
                        }
                }

                this.Refresh();
            }
        }

        private void Editor_MouseUp(object sender, MouseEventArgs e)
        {
            if ((int)e.Button == (int)this.LastButton & !(this.LastButton == (int)MouseButtons.None))
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                    case MouseButtons.Right:
                        {
                            if (this.NewLayer != null)
                            {
                                this.NewLayer.Stop(e.Location);
                                this.CreateCheckpoint();

                                if (this.NewLayer is Layer_Action ActionLayer)
                                {
                                    this.Render();
                                    this.BackgroundImage = Helpers.ApplyAction((Bitmap)this.BackgroundImage, ActionLayer.Action, ActionLayer.Zone, ActionLayer.Bounds);
                                }
                                else
                                {
                                    if (this.NewLayer is Layer_Number)
                                    {
                                        this.LastNumber += 1;
                                    }

                                    if (this.NewLayer is Layer_Line && (int)this.LastButton == (int)MouseButtons.Right)
                                    {
                                        this.CurrentPen.DashStyle = DashStyle.Solid;
                                    }

                                    this.Layers.Add(this.NewLayer);
                                }

                                this.NewLayer = null;
                            }

                            break;
                        }

                    case MouseButtons.Middle:
                        {
                            this.ImagePosition.X += (e.Location.X - this.PBegin.X);
                            this.ImagePosition.Y += (e.Location.Y - this.PBegin.Y);

                            this.PBegin = e.Location;
                            break;
                        }
                }

                this.LastButton = MouseButtons.None;

                this.Refresh();
            }
        }

        public void RotateFlip(RotateFlipType value)
        {
            this.Render();
            this.Img.RotateFlip(value);
            this.ResetImageSizeAndPosition();
        }

        private void Editor_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.NewLayer != null)
            {
                if (e.Delta > 0)
                {
                    if (this.CurrentPen.Width < 30)
                    {
                        this.CurrentPen.Width += 1;
                    }
                }
                else if (this.CurrentPen.Width > 1)
                {
                    this.CurrentPen.Width -= 1;
                }

                this.Refresh();
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }
    }
}
