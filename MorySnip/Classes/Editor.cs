using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Morysoft.MorySnip.Classes;
using Morysoft.MorySnip.Classes.Layers;
using Morysoft.MorySnip.Draw;
using Morysoft.MorySnip.Modules;

namespace Morysoft.MorySnip;

public delegate void LastNumberChangedEventHandler(object sender, EventArgs e);

public partial class Editor
{
    private readonly Stack<EditorStep> previousSteps = new();
    private readonly Stack<EditorStep> nextSteps = new();
    private readonly List<Layer> Layers = new();
    private Point imagePosition = new(0, 0);

    private MouseButtons LastButton = MouseButtons.None;
    private int lastNumber = 1;

    private EditorPaintMode paintMode = EditorPaintMode.Arrow;
    private EditorPaintMode paintModeLast = EditorPaintMode.Arrow;

    private Point startPoint;

    private Layer? newLayer;

    public event LastNumberChangedEventHandler? LastNumberChanged;

    public int LastNumber
    {
        get => this.lastNumber;
        set
        {
            this.lastNumber = value;

            LastNumberChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool CanRedo => this.nextSteps.Count > 0;

    public bool CanUndo => this.previousSteps.Count > 0;

    public string QuickText { get; set; } = String.Empty;

    public EditorPaintMode PaintMode
    {
        get => this.paintMode;
        set
        {
            this.paintModeLast = this.paintMode;
            this.paintMode = value;
        }
    }

    public Editor()
    {
        this.InitializeComponent();
    }

    public void Redo()
    {
        if (this.CanRedo)
        {
            this.previousSteps.Push(this.CreateStep());

            var step = this.nextSteps.Pop();

            this.BackgroundImage = step.Image;
            this.LastNumber = step.LastNumber;
        }
    }

    public void Undo()
    {
        if (this.CanUndo)
        {
            this.nextSteps.Push(this.CreateStep());

            this.Layers.Clear();

            var step = this.previousSteps.Pop();

            this.ApplyStep(step);
        }
    }

    public EditorStep CreateStep() => new(this.GetResult(), this.LastNumber, this.Layers.Select(l => l).ToList()); //TODO: clone every layer

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
        this.imagePosition = new Point();
    }

    public Bitmap GetResult()
    {
        var result = new Bitmap(this.Width, this.Height);

        var g = Graphics.FromImage(result);

        g.Clear(Color.White);

        if (this.EditableImage != null)
        {
            g.DrawImage(this.EditableImage, this.imagePosition.X, this.imagePosition.Y, this.EditableImage.Size.Width, this.EditableImage.Size.Height);
        }

        foreach (var l in this.Layers)
        {
            l.Render(g);
        }

        return result;
    }

    public Pen CurrentPen { get; private set; } = new Pen(Brushes.Red, 2) { StartCap = LineCap.Round, EndCap = LineCap.Round, Alignment = PenAlignment.Inset };

    public Brush CurrentBrush { get; set; } = new SolidBrush(Color.Red);

    private Image EditableImage
    {
        get => this.BackgroundImage;
        set
        {
            this.imagePosition.X = 0;
            this.imagePosition.Y = 0;
            this.BackgroundImage = value;
        }
    }

    public void SetLastPaintMode() => this.PaintMode = this.paintModeLast;

    public void RotateFlip(RotateFlipType value)
    {
        this.Render();
        this.EditableImage.RotateFlip(value);
        this.ResetImageSizeAndPosition();
    }

    public bool FillObjecs { get; set; } = true;

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        if (e is null)
        {
            throw new ArgumentNullException(nameof(e));
        }

        var g = e.Graphics;

        g.Clear(Color.White);

        if (this.EditableImage is null)
        {
            g.DrawString("NO IMAGE !!!", this.Font, Brushes.Red, 5, 5);
        }
        else
        {
            g.DrawImage(this.EditableImage, this.imagePosition.X, this.imagePosition.Y, this.EditableImage.Size.Width, this.EditableImage.Size.Height);
        }

        foreach (var l in this.Layers)
        {
            l.Render(g);
        }

        if (this.newLayer is not null)
        {
            this.newLayer.Paint(g);
        }
    }

    private void Editor_BackgroundImageChanged(object sender, EventArgs e) => this.ResetImageSizeAndPosition();

    public void ResetImageSizeAndPosition()
    {
        if (this.BackgroundImage is not null)
        {
            this.Size = this.BackgroundImage.Size;
            this.imagePosition = new Point();
            this.Refresh();
        }
    }

    private void Editor_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control || e.Shift || this.newLayer is null)
        {
            return;
        }

        if (e.KeyCode == Keys.Escape)
        {
            this.newLayer = null;
            this.Refresh();
        }
        else if (e.KeyCode == Keys.Oem3) // `/~ key
        {
            this.SecondaryAction();
        }
        else if (e.KeyCode == Keys.S && this.newLayer.Pen is not null)
        {
            SwitchPenDashStyle(this.newLayer.Pen);
            this.Refresh();
        }
    }

    private void CreateCheckpoint()
    {
        this.previousSteps.Push(this.CreateStep());
        this.nextSteps.Clear();
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
        switch (this.newLayer)
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
            case LayerLine layerLine:
                if (layerLine.Pen is null)
                {
                    return;
                }

                SwitchPenDashStyle(layerLine.Pen);
                break;
            case Layer layer:
                layer.Fill ^= true;
                break;
        }

        this.Refresh();
    }

    private static void SwitchPenDashStyle(Pen pen)
    {
        pen.DashStyle = pen.DashStyle switch
        {
            DashStyle.Solid => DashStyle.Dash,
            DashStyle.Dash => DashStyle.Dot,
            _ => DashStyle.Solid,
        };
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
                        this.startPoint = e.Location;
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
                        this.CurrentPen.DashStyle = DashStyle.Dash;
                    }

                    this.newLayer = new LayerLine(this.CurrentPen, e.Location);
                    break;
                }

            case EditorPaintMode.Rect:
                {
                    this.newLayer = new LayerRect(this.CurrentPen, this.CurrentBrush, e.Location) { Fill = e.Button == MouseButtons.Right ^ this.FillObjecs };
                    break;
                }

            case EditorPaintMode.Number:
                {
                    this.newLayer = new LayerNumber(this.CurrentPen, this.CurrentBrush, e.Location, this.LastNumber) { Fill = e.Button == MouseButtons.Right ^ this.FillObjecs };
                    break;
                }

            case EditorPaintMode.Oval:
                {
                    this.newLayer = new LayerOval(this.CurrentPen, this.CurrentBrush, e.Location) { Fill = e.Button == MouseButtons.Right ^ this.FillObjecs };
                    break;
                }

            case EditorPaintMode.Free:
                {
                    this.newLayer = new LayerFree(this.CurrentPen, this.CurrentBrush, e.Location) { Fill = e.Button == MouseButtons.Right ^ this.FillObjecs };
                    break;
                }

            case EditorPaintMode.Arrow:
                {
                    this.newLayer = new LayerArrow(this.CurrentPen, this.CurrentBrush, e.Location, arrowMode: e.Button == MouseButtons.Right ? ArrowModes.AtStart : ArrowModes.AtEnd);
                    break;
                }

            case EditorPaintMode.Magnifier:
                {
                    this.newLayer = new LayerMagnifier(
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
                    this.newLayer = new LayerText(
                        this.QuickText, this.CurrentPen, this.CurrentBrush, e.Location, this.Font,
                        e.Button == MouseButtons.Right ? ArrowModes.AtStart : ArrowModes.AtEnd);
                    break;
                }

            case EditorPaintMode.Invert:
                {
                    this.newLayer = new LayerAction(e.Location, Actions.Invert, e.Button == MouseButtons.Right ? Zones.NotSelected : Zones.Selected);
                    break;
                }

            case EditorPaintMode.Blur:
                {
                    this.newLayer = new LayerAction(e.Location, Actions.Blur, e.Button == MouseButtons.Right ? Zones.NotSelected : Zones.Selected);
                    break;
                }

            case EditorPaintMode.Puzzle:
                {
                    this.newLayer = new LayerAction(e.Location, Actions.Puzzle, e.Button == MouseButtons.Right ? Zones.NotSelected : Zones.Selected);
                    break;
                }

            case EditorPaintMode.Grayscale:
                {
                    this.newLayer = new LayerAction(e.Location, Actions.Grayscale, e.Button == MouseButtons.Right ? Zones.NotSelected : Zones.Selected);
                    break;
                }

            case EditorPaintMode.Highlight:
                {
                    this.newLayer = new LayerAction(e.Location, Actions.Highlight, Zones.Selected);
                    break;
                }

            case EditorPaintMode.Crop:
                {
                    this.newLayer = new LayerAction(e.Location, Actions.Crop, Zones.Selected);
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
                        if (this.newLayer != null)
                        {
                            this.newLayer.Step(e.Location);
                        }

                        break;
                    }

                case MouseButtons.Middle:
                    {
                        this.imagePosition.X += e.Location.X - this.startPoint.X;
                        this.imagePosition.Y += e.Location.Y - this.startPoint.Y;

                        this.startPoint = e.Location;

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
                        this.imagePosition.X += (e.Location.X - this.startPoint.X);
                        this.imagePosition.Y += (e.Location.Y - this.startPoint.Y);

                        this.startPoint = e.Location;
                        break;
                    }
            }

            this.LastButton = MouseButtons.None;

            this.Refresh();
        }
    }

    private void CompleteLayer(MouseEventArgs e)
    {
        if (this.newLayer == null)
        {
            return;
        }

        this.newLayer.Stop(e.Location);

        if (!this.newLayer.IsValid)
        {
            this.newLayer = null;
            return;
        }

        this.CreateCheckpoint();

        if (this.newLayer is LayerAction ActionLayer)
        {
            this.Render();
            this.BackgroundImage = Helpers.ApplyAction((Bitmap)this.BackgroundImage, ActionLayer.Action, ActionLayer.Zone, ActionLayer.Bounds);
        }
        else
        {
            if (this.newLayer is LayerNumber)
            {
                this.LastNumber += 1;
            }

            this.CurrentPen.DashStyle = DashStyle.Solid;

            this.Layers.Add(this.newLayer);
        }

        this.newLayer = null;
    }

    private void Editor_MouseWheel(object sender, MouseEventArgs e)
    {
        if (this.newLayer == null)
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
