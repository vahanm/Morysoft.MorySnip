using System;
using System.Drawing;
using System.Windows.Forms;
using Morysoft.MorySnip.Modules;

namespace Morysoft.MorySnip;

public partial class FormEdit
{
    private void Form_Edit_BackgroundImageChanged(object sender, EventArgs e) => this.Editor_Main.BackgroundImage = this.BackgroundImage;

    private int LastNumberMax = 10;

    private void AddNumberInNumbersMenu(int num)
    {
        var item = new ToolStripButton(num.ToString())
        {
            Tag = num
        };

        item.Click += (lsender, le) => this.Editor_Main.LastNumber = Convert.ToInt32(((ToolStripButton?)lsender)?.Tag);

        this.Menu_Numbers.Items.Add(item);
    }

    private void Form_Edit_Load(object sender, EventArgs e)
    {
        try
        {
            this.Editor_Main.Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.PENCIL));
        }
        catch
        {
        }

        for (int num = 1, loopTo = this.LastNumberMax; num <= loopTo; num++)
        {
            this.AddNumberInNumbersMenu(num);
        }

        if (this.Screenshot is not null)
        {
            this.BackgroundImage = this.Screenshot.Image;
        }
    }

    public Screenshot? Screenshot
    {
        get => this.Editor_Main.BackgroundImage;
        set
        {
            if (value is null)
            {
                return;
            }

            this.Editor_Main.BackgroundImage = (Image)value.Image.Clone();
        }
    }

    private void RedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Editor_Main.CurrentPen.Color = Color.Red;
        ((SolidBrush)this.Editor_Main.CurrentBrush).Color = Color.Red;
        this.Button_Color.Text = "Red";

        this.ToolStrip_Standard_Palitra.Color1 = this.Editor_Main.CurrentPen.Color;
        this.ToolStrip_Standard_Palitra.Color2 = ((SolidBrush)this.Editor_Main.CurrentBrush).Color;
    }

    private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Editor_Main.CurrentPen.Color = Color.Blue;
        ((SolidBrush)this.Editor_Main.CurrentBrush).Color = Color.Blue;
        this.Button_Color.Text = "Blue";

        this.ToolStrip_Standard_Palitra.Color1 = this.Editor_Main.CurrentPen.Color;
        this.ToolStrip_Standard_Palitra.Color2 = ((SolidBrush)this.Editor_Main.CurrentBrush).Color;
    }

    private void BlackToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Editor_Main.CurrentPen.Color = Color.Black;
        ((SolidBrush)this.Editor_Main.CurrentBrush).Color = Color.Black;
        this.Button_Color.Text = "Black";

        this.ToolStrip_Standard_Palitra.Color1 = this.Editor_Main.CurrentPen.Color;
        this.ToolStrip_Standard_Palitra.Color2 = ((SolidBrush)this.Editor_Main.CurrentBrush).Color;
    }

    private void WhiteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Editor_Main.CurrentPen.Color = Color.White;
        ((SolidBrush)this.Editor_Main.CurrentBrush).Color = Color.White;
        this.Button_Color.Text = "White";

        this.ToolStrip_Standard_Palitra.Color1 = this.Editor_Main.CurrentPen.Color;
        this.ToolStrip_Standard_Palitra.Color2 = ((SolidBrush)this.Editor_Main.CurrentBrush).Color;
    }

    private void CustomToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var tmp = new ColorDialog()
        {
            Color = this.Editor_Main.CurrentPen.Color
        };
        if (tmp.ShowDialog() == DialogResult.OK)
        {
            this.Editor_Main.CurrentPen.Color = tmp.Color;
            ((SolidBrush)this.Editor_Main.CurrentBrush).Color = tmp.Color;

            this.Button_Color.Text = this.Editor_Main.CurrentPen.Color.IsKnownColor
                ? this.Editor_Main.CurrentPen.Color.Name
                : $"{this.Editor_Main.CurrentPen.Color.R}, {this.Editor_Main.CurrentPen.Color.G}, {this.Editor_Main.CurrentPen.Color.B}";

            this.ToolStrip_Standard_Palitra.Color1 = this.Editor_Main.CurrentPen.Color;
            this.ToolStrip_Standard_Palitra.Color2 = ((SolidBrush)this.Editor_Main.CurrentBrush).Color;
        }
    }

    private void Menu_Size_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        this.Editor_Main.CurrentPen.Width = Convert.ToSingle(e.ClickedItem.Text);
        this.Button_Size.Text = $"{this.Editor_Main.CurrentPen.Width}px";
        this.Button_Size.Tag = this.Editor_Main.CurrentPen.Width;
    }

    private void Button_Back_Click(object sender, EventArgs e) => this.Editor_Main.Undo();

    private void Button_Redo_Click(object sender, EventArgs e) => this.Editor_Main.Redo();

    private void Button_Rotate_Left_Click(object sender, EventArgs e) => this.Editor_Main.RotateFlip(RotateFlipType.Rotate270FlipNone);

    private void Button_Rotate_Right_Click(object sender, EventArgs e) => this.Editor_Main.RotateFlip(RotateFlipType.Rotate90FlipNone);

    private void Button_Flip_X_Click(object sender, EventArgs e) => this.Editor_Main.RotateFlip(RotateFlipType.RotateNoneFlipX);

    private void Button_Flip_Y_Click(object sender, EventArgs e) => this.Editor_Main.RotateFlip(RotateFlipType.RotateNoneFlipY);

    private void Button_OK_Click(object sender, EventArgs e)
    {
        this.Editor_Main.Render();
        this.DialogResult = DialogResult.OK;
    }

    private void Button_Exit_Click(object sender, EventArgs e) => this.Close();

    private void Menu_PaintMode_Blur_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Blur;

    private void Menu_PaintMode_Puzzle_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Puzzle;

    private void Menu_PaintMode_Invert_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Invert;

    private void Menu_PaintMode_Grayscale_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Grayscale;

    private void Timer_Update_Tick(object sender, EventArgs e)
    {
        // Tools
        this.Menu_PaintMode_Free.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Free;
        this.Menu_PaintMode_Line.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Line;
        this.Menu_PaintMode_Arrow.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Arrow;
        this.Menu_PaintMode_Oval.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Oval;
        this.Menu_PaintMode_Rect.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Rect;
        this.Menu_PaintMode_Numbers.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Number;
        this.Menu_PaintMode_Magnifier.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Magnifier;
        this.Menu_PaintMode_Text.Checked
            = this.Menu_PaintMode_TextBox.Visible
            = this.Editor_Main.PaintMode == EditorPaintMode.Text;

        // Actions
        this.Menu_PaintMode_Highlight.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Highlight;
        this.Menu_PaintMode_Invert.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Invert;
        this.Menu_PaintMode_Grayscale.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Grayscale;
        this.Menu_PaintMode_Blur.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Blur;
        this.Menu_PaintMode_Puzzle.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Puzzle;
        this.Menu_PaintMode_Crop.Checked = this.Editor_Main.PaintMode == EditorPaintMode.Crop;

        if (this.Button_Size.Tag != (object)this.Editor_Main.CurrentPen.Width)
        {
            this.Button_Size.Text = $"{this.Editor_Main.CurrentPen.Width}px";
            this.Button_Size.Tag = this.Editor_Main.CurrentPen.Width;
        }

        this.Button_Color.Text = this.Editor_Main.CurrentPen.Color.IsKnownColor
            ? this.Editor_Main.CurrentPen.Color.Name
            : $"{this.Editor_Main.CurrentPen.Color.R}, {this.Editor_Main.CurrentPen.Color.G}, {this.Editor_Main.CurrentPen.Color.B}";

        // Special actions
        this.Button_Back.Enabled = this.Editor_Main.CanUndo;
        this.Button_Redo.Enabled = this.Editor_Main.CanRedo;

        int w = this.Editor_Main.Width;
        int h = this.Editor_Main.Height;
        int l = w + 4 - this.Panel_Image.HorizontalScroll.Value; // 
        int t = h + 4 - this.Panel_Image.VerticalScroll.Value; // 

        this.Resizer_Both.Left = l;
        this.Resizer_Both.Top = t;
        this.Resizer_Right.Left = l;
        this.Resizer_Right.Height = h;
        this.Resizer_Bottom.Top = t;
        this.Resizer_Bottom.Width = w;
    }

    private void Menu_PaintMode_Free_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Free;

    private void Menu_PaintMode_Highlight_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Highlight;

    private void Menu_PaintMode_Line_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Line;

    private void Menu_PaintMode_Arrow_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Arrow;

    private void Menu_PaintMode_Oval_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Oval;

    private void Menu_PaintMode_Rect_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Rect;

    private void Menu_PaintMode_Numbers_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Number;

    private void Menu_PaintMode_Select_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Invert;

    private void Menu_PaintMode_Fill_Click(object sender, EventArgs e) => this.Editor_Main.FillObjecs = this.Menu_PaintMode_Fill.Checked;

    private void Menu_PaintMode_Crop_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Crop;

    private int ResizerX;
    private int ResizerY;

    public FormEdit()
    {
        this.InitializeComponent();
    }

    private void Resizers_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            this.ResizerX = e.X;
            this.ResizerY = e.Y;
        }
    }

    private void Resizer_Both_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left)
        {
            return;
        }

        this.Resizer_Both.Location += new Size(e.X - this.ResizerX, e.Y - this.ResizerY);

        this.Resizer_Right.Location += new Size(e.X - this.ResizerX, 0);
        this.Resizer_Right.Size += new Size(0, e.Y - this.ResizerY);

        this.Resizer_Bottom.Location += new Size(0, e.Y - this.ResizerY);
        this.Resizer_Bottom.Size += new Size(e.X - this.ResizerX, 0);

        this.Editor_Main.Size += new Size(e.X - this.ResizerX, e.Y - this.ResizerY);
    }

    private void Resizer_Right_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            this.Resizer_Both.Location += new Size(e.X - this.ResizerX, 0);

            this.Resizer_Right.Location += new Size(e.X - this.ResizerX, 0);

            this.Resizer_Bottom.Size += new Size(e.X - this.ResizerX, 0);

            this.Editor_Main.Size += new Size(e.X - this.ResizerX, 0);
        }
    }

    private void Resizer_Bottom_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            this.Resizer_Both.Location += new Size(0, e.Y - this.ResizerY);

            this.Resizer_Right.Size += new Size(0, e.Y - this.ResizerY);

            this.Resizer_Bottom.Location += new Size(0, e.Y - this.ResizerY);

            this.Editor_Main.Size += new Size(0, e.Y - this.ResizerY);
        }
    }

    private void Render()
    {
        this.Editor_Main.Render();
        this.Screenshot = this.Editor_Main.BackgroundImage;
    }

    private void Save(PublishOptions options)
    {
        this.Render();

        if (this.Screenshot is null)
        {
            MessageBox.Show("Image not found.", "Can not save image.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }

        try
        {
            Publisher.Publish(options, this.Screenshot);

            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Can not save image.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Button_Save_Click(object sender, EventArgs e)
    {
        this.Save(PublishOptions.SaveToFile | PublishOptions.CopyPathOrULR);
    }

    private void Button_SaveAs_Click(object sender, EventArgs e)
    {
        this.Save(PublishOptions.SaveToFile | PublishOptions.SaveAs | PublishOptions.CopyPathOrULR);
    }

    private void Button_SaveCopy_Click(object sender, EventArgs e)
    {
        this.Save(PublishOptions.CopyImage);
    }

    private void Editor_Main_LastNumberChanged(object sender, EventArgs e)
    {
        if (this.LastNumberMax < this.Editor_Main.LastNumber)
        {
            for (int num = this.LastNumberMax + 1, loopTo = this.Editor_Main.LastNumber; num <= loopTo; num++)
            {
                this.AddNumberInNumbersMenu(num);
            }

            this.LastNumberMax = this.Editor_Main.LastNumber;
        }

        foreach (ToolStripItem item in this.Menu_Numbers.Items)
        {
            if (item.Tag != null)
            {
                ((ToolStripButton)item).Checked = (int)item.Tag == this.Editor_Main.LastNumber;
            }
        }
    }

    private void ToolStrip_Standard_Palitra_ColorChanged(object sender, PalitraEventArgs e)
    {
        this.Editor_Main.CurrentPen.Color = this.ToolStrip_Standard_Palitra.Color1;

        if (this.Editor_Main.CurrentBrush is SolidBrush solidBrush)
        {
            solidBrush.Color = this.ToolStrip_Standard_Palitra.Color2;
        }
    }

    private void Menu_PaintMode_Magnifier_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Magnifier;

    private void Button_Settings_Click(object sender, EventArgs e) => FormSettings.Show();

    private void Menu_PaintMode_Text_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = EditorPaintMode.Text;

    private void Menu_PaintMode_TextBox_TextChanged(object sender, EventArgs e) => this.Editor_Main.QuickText = this.Menu_PaintMode_TextBox.Text;

    private void Menu_PaintMode_TextBox_VisibleChanged(object sender, EventArgs e)
    {
        this.Menu_PaintMode_TextBox.Focus();
        this.Menu_PaintMode_TextBox.SelectAll();
    }
}
