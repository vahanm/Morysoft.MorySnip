using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Morysoft.MorySnip.Draw;

namespace Morysoft.MorySnip
{
    public class EditorStep
    {
        public Bitmap Image { get; set; }

        public int LastNumber { get; set; }

        public List<Layer> Layers { get; set; }
    }

    public partial class Editor
    {
        private readonly Stack<EditorStep> PreviousSteps = new Stack<EditorStep>();
        private readonly Stack<EditorStep> NextSteps = new Stack<EditorStep>();
        private readonly List<Layer> Layers = new List<Layer>();
        private Point ImagePosition = new Point(0, 0);

        private MouseButtons LastButton = MouseButtons.None;
        private int _LastNumber = 1;

        public event LastNumberChangedEventHandler LastNumberChanged;

        public delegate void LastNumberChangedEventHandler(object sender, EventArgs e);

        public void CreateCheckpoint()
        {
            this.PreviousSteps.Push(this.CreateStep());
            this.NextSteps.Clear();
        }

        public int LastNumber
        {
            get => this._LastNumber;
            set
            {
                this._LastNumber = value;

                LastNumberChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool CanRedo => this.NextSteps.Count > 0;

        public bool CanUndo => this.PreviousSteps.Count > 0;

        public string QuickText { get; set; }

        public void Redo()
        {
            if (this.CanRedo)
            {
                this.PreviousSteps.Push(this.CreateStep());

                var step = this.NextSteps.Pop();

                this.BackgroundImage = step.Image;
                this.LastNumber = step.LastNumber;
            }
        }

        public void Undo()
        {
            if (this.CanUndo)
            {
                this.NextSteps.Push(this.CreateStep());

                this.Layers.Clear();

                var step = this.PreviousSteps.Pop();

                this.ApplyStep(step);
            }
        }

        public EditorStep CreateStep()
        {
            return new EditorStep
            {
                Image = this.GetResult(),
                LastNumber = this.LastNumber,
                Layers = this.Layers.Select(l => l).ToList()
            };
        }

        public void ApplyStep(EditorStep step)
        {
            if (step is null)
            {
                throw new ArgumentNullException(nameof(step));
            }

            this.BackgroundImage = step.Image;
            this.LastNumber = step.LastNumber;
        }

        public void Render()
        {
            var result = this.GetResult();

            this.BackgroundImage = result;

            this.Layers.Clear();
            this.ImagePosition = new Point();
        }

        public Bitmap GetResult()
        {
            var result = new Bitmap(this.Width, this.Height);

            var g = Graphics.FromImage(result);

            g.Clear(Color.White);

            if (this.Img != null)
            {
                g.DrawImage(this.Img, this.ImagePosition.X, this.ImagePosition.Y, this.Img.Size.Width, this.Img.Size.Height);
            }

            foreach (var l in this.Layers)
            {
                l.Render(g);
            }

            return result;
        }

        public Pen CurrentPen { get; private set; } = new Pen(Brushes.Red, 2) { StartCap = LineCap.Round, EndCap = LineCap.Round, Alignment = PenAlignment.Inset };

        public Brush CurrentBrush { get; set; } = new SolidBrush(Color.Red);

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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            var g = e.Graphics;

            g.Clear(Color.White);

            if (this.Img is null)
            {
                g.DrawString("NO IMAGE !!!", this.Font, Brushes.Red, 5, 5);
            }
            else
            {
                g.DrawImage(this.Img, this.ImagePosition.X, this.ImagePosition.Y, this.Img.Size.Width, this.Img.Size.Height);
            }

            foreach (var l in this.Layers)
            {
                l.Render(g);
            }

            if (!(this.NewLayer is null))
            {
                this.NewLayer.Paint(g);
            }
        }

        public enum EditorPaintMode
        {
            // Objects
            Free,
            Line,
            Arrow,
            Oval,
            Rect,
            Number,
            Magnifier,
            Text,
            // Effects
            Highlight,
            Invert,
            Blur,
            Puzzle,
            Crop,
            Grayscale
        }

        private EditorPaintMode paintMode = EditorPaintMode.Arrow;
        private EditorPaintMode paintModeLast = EditorPaintMode.Arrow;

        public void SetLastPaintMode() => this.PaintMode = this.paintModeLast;

        public EditorPaintMode PaintMode
        {
            get => this.paintMode;
            set
            {
                this.paintModeLast = this.paintMode;
                this.paintMode = value;
            }
        }

        public bool FillObjecs { get; set; } = true;

        private Point PBegin;

        private void Editor_BackgroundImageChanged(object sender, EventArgs e) => this.ResetImageSizeAndPosition();

        public void ResetImageSizeAndPosition()
        {
            if (!(this.BackgroundImage is null))
            {
                this.Size = this.BackgroundImage.Size;
                this.ImagePosition = new Point();
                this.Refresh();
            }
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !e.Control)
            {
                this.NewLayer = null;
                this.Refresh();
            }
            else if (e.KeyCode == Keys.Oem3 && !e.Control && !e.Shift)
            {
                this.SecondaryAction();
            }
        }

        private Layer NewLayer;

        public Editor()
        {
            this.InitializeComponent();
        }

        private void Editor_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.LastButton == MouseButtons.Left && e.Button == MouseButtons.Right || this.LastButton == MouseButtons.Right && e.Button == MouseButtons.Left)
            {
                this.SecondaryAction();
            }
        }

        private void SecondaryAction()
        {
            switch (this.NewLayer)
            {
                case LayerArrow layerArrow:
                    {
                        layerArrow.ArrowMode = layerArrow.ArrowMode switch
                        {
                            ArrowModes.AtEnd => ArrowModes.AtStart,
                            ArrowModes.AtStart => ArrowModes.Both,
                            ArrowModes.Both => ArrowModes.AtEnd,
                            _ => ArrowModes.AtStart,
                        };
                        break;
                    }
                case LayerAction layerAction:
                    layerAction.Zone = layerAction.Zone switch
                    {
                        Zones.Selected => Zones.NotSelected,
                        Zones.NotSelected => Zones.Selected,
                        _ => Zones.All,
                    };
                    break;
                case Layer layer:
                    layer.Fill ^= true;
                    break;
            }

            this.Refresh();
        }

        private void Editor_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.LastButton == MouseButtons.None)
            {
                this.LastButton = e.Button;

                switch (e.Button)
                {
                    case MouseButtons.Left:
                    case MouseButtons.Right:
                        {
                            this.BeginLayer(e);

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

        private void BeginLayer(MouseEventArgs e)
        {
            switch (this.PaintMode)
            {
                case EditorPaintMode.Line:
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            this.CurrentPen.DashStyle = DashStyle.DashDotDot;
                        }

                        this.NewLayer = new LayerLine(this.CurrentPen, e.Location);
                        break;
                    }

                case EditorPaintMode.Rect:
                    {
                        this.NewLayer = new LayerRect(this.CurrentPen, this.CurrentBrush, e.Location) { Fill = e.Button == MouseButtons.Right ^ this.FillObjecs };
                        break;
                    }

                case EditorPaintMode.Number:
                    {
                        this.NewLayer = new LayerNumber(this.CurrentPen, this.CurrentBrush, e.Location, this.LastNumber) { Fill = e.Button == MouseButtons.Right ^ this.FillObjecs };
                        break;
                    }

                case EditorPaintMode.Oval:
                    {
                        this.NewLayer = new LayerOval(this.CurrentPen, this.CurrentBrush, e.Location) { Fill = e.Button == MouseButtons.Right ^ this.FillObjecs };
                        break;
                    }

                case EditorPaintMode.Free:
                    {
                        this.NewLayer = new LayerFree(this.CurrentPen, this.CurrentBrush, e.Location) { Fill = e.Button == MouseButtons.Right ^ this.FillObjecs };
                        break;
                    }

                case EditorPaintMode.Arrow:
                    {
                        this.NewLayer = new LayerArrow(this.CurrentPen, this.CurrentBrush, e.Location, arrowMode: e.Button == MouseButtons.Right ? ArrowModes.AtStart : ArrowModes.AtEnd);
                        break;
                    }

                case EditorPaintMode.Magnifier:
                    {
                        this.NewLayer = new LayerMagnifier(
                            this.CurrentPen,
                            this.CurrentBrush,
                            (Bitmap)this.BackgroundImage,
                            e.Location,
                            2,
                            50
                        );
                        break;
                    }

                case EditorPaintMode.Text:
                    {
                        this.NewLayer = new LayerText(
                            this.QuickText, this.CurrentPen, this.CurrentBrush, e.Location, this.Font,
                            e.Button == MouseButtons.Right ? ArrowModes.AtStart : ArrowModes.AtEnd);
                        break;
                    }

                case EditorPaintMode.Invert:
                    {
                        this.NewLayer = new LayerAction(e.Location, Actions.Invert, e.Button == MouseButtons.Right ? Zones.NotSelected : Zones.Selected);
                        break;
                    }

                case EditorPaintMode.Blur:
                    {
                        this.NewLayer = new LayerAction(e.Location, Actions.Blur, e.Button == MouseButtons.Right ? Zones.NotSelected : Zones.Selected);
                        break;
                    }

                case EditorPaintMode.Puzzle:
                    {
                        this.NewLayer = new LayerAction(e.Location, Actions.Puzzle, e.Button == MouseButtons.Right ? Zones.NotSelected : Zones.Selected);
                        break;
                    }

                case EditorPaintMode.Grayscale:
                    {
                        this.NewLayer = new LayerAction(e.Location, Actions.Grayscale, e.Button == MouseButtons.Right ? Zones.NotSelected : Zones.Selected);
                        break;
                    }

                case EditorPaintMode.Highlight:
                    {
                        this.NewLayer = new LayerAction(e.Location, Actions.Highlight, Zones.Selected);
                        break;
                    }

                case EditorPaintMode.Crop:
                    {
                        this.NewLayer = new LayerAction(e.Location, Actions.Crop, Zones.Selected);
                        break;
                    }
            }
        }

        private void Editor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == this.LastButton & !(this.LastButton == MouseButtons.None))
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
            if (e.Button == this.LastButton & !(this.LastButton == MouseButtons.None))
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                    case MouseButtons.Right:
                        {
                            this.CompleteLayer(e);

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

        private void CompleteLayer(MouseEventArgs e)
        {
            if (this.NewLayer == null)
            {
                return;
            }

            this.NewLayer.Stop(e.Location);

            if (!this.NewLayer.IsValid)
            {
                this.NewLayer = null;
                return;
            }

            this.CreateCheckpoint();

            if (this.NewLayer is LayerAction ActionLayer)
            {
                this.Render();
                this.BackgroundImage = Helpers.ApplyAction((Bitmap)this.BackgroundImage, ActionLayer.Action, ActionLayer.Zone, ActionLayer.Bounds);
            }
            else
            {
                if (this.NewLayer is LayerNumber)
                {
                    this.LastNumber += 1;
                }

                if (this.NewLayer is LayerLine && this.LastButton == MouseButtons.Right)
                {
                    this.CurrentPen.DashStyle = DashStyle.Solid;
                }

                this.Layers.Add(this.NewLayer);
            }

            this.NewLayer = null;
        }

        public void RotateFlip(RotateFlipType value)
        {
            this.Render();
            this.Img.RotateFlip(value);
            this.ResetImageSizeAndPosition();
        }

        private void Editor_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.NewLayer == null)
            {
                return;
            }

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

            if (e is HandledMouseEventArgs he)
            {
                he.Handled = true;
            }
        }
    }
}
