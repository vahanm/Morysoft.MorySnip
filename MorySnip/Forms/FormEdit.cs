using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip
{
    public partial class Form_Edit
    {
        private void Form_Edit_BackgroundImageChanged(object sender, EventArgs e) => this.Editor_Main.BackgroundImage = this.BackgroundImage;

        private int LastNumberMax = 10;

        private void AddNumberInNumbersMenu(int num)
        {
            var item = new ToolStripButton(num.ToString())
            {
                Tag = num
            };

            item.Click += (lsender, le) => this.Editor_Main.LastNumber = Conversions.ToInteger(((ToolStripButton)lsender).Tag);

            this.Menu_Numbers.Items.Add(item);
        }

        private void Form_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                this.Editor_Main.Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.PENCIL));
            }
            catch (Exception ex)
            {
            }

            if (this.Images.Count == 1)
            {
                this.BackgroundImage = this.Images[0].Image;
            }

            for (int num = 1, loopTo = this.LastNumberMax; num <= loopTo; num++)
            {
                this.AddNumberInNumbersMenu(num);
            }
        }

        public Screenshot Image
        {
            get => this.Editor_Main.BackgroundImage;
            set => this.Editor_Main.BackgroundImage = (Image)value?.Image?.Clone();
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
            var tmp = new ColorDialog()
            {
                Color = this.Editor_Main.CurrentPen.Color
            };

            if ((int)tmp.ShowDialog() == (int)DialogResult.OK)
            {
                this.Editor_Main.CurrentPen.Color = tmp.Color;
                ((SolidBrush)this.Editor_Main.CurrentBrush).Color = tmp.Color;

                if (this.Editor_Main.CurrentPen.Color.IsKnownColor)
                {
                    this.Button_Color.Text = this.Editor_Main.CurrentPen.Color.Name;
                }
                else
                {
                    this.Button_Color.Text = Conversions.ToString(this.Editor_Main.CurrentPen.Color.R) + ", " + Conversions.ToString(this.Editor_Main.CurrentPen.Color.G) + ", " + Conversions.ToString(this.Editor_Main.CurrentPen.Color.B);
                }

                this.ToolStrip_Standard_Palitra.Color1 = this.Editor_Main.CurrentPen.Color;
                this.ToolStrip_Standard_Palitra.Color2 = ((SolidBrush)this.Editor_Main.CurrentBrush).Color;
            }
        }

        private void Menu_Size_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.Editor_Main.CurrentPen.Width = Conversions.ToSingle(Conversion.Val(e.ClickedItem.Text));
            this.Button_Size.Text = Conversions.ToString(this.Editor_Main.CurrentPen.Width) + "px";
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

        private void Menu_PaintMode_Blur_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Blur;

        private void Menu_PaintMode_Puzzle_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Puzzle;

        private void Menu_PaintMode_Invert_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Invert;

        private void Menu_PaintMode_Grayscale_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Grayscale;

        private void Timer_Update_Tick(object sender, EventArgs e)
        {
            // Tools
            if (!(this.Menu_PaintMode_Free.Checked == (this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Free)))
            {
                this.Menu_PaintMode_Free.Checked = this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Free;
            }

            if (!(this.Menu_PaintMode_Line.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Line)))
            {
                this.Menu_PaintMode_Line.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Line;
            }

            if (!(this.Menu_PaintMode_Arrow.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Arrow)))
            {
                this.Menu_PaintMode_Arrow.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Arrow;
            }

            if (!(this.Menu_PaintMode_Oval.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Oval)))
            {
                this.Menu_PaintMode_Oval.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Oval;
            }

            if (!(this.Menu_PaintMode_Rect.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Rect)))
            {
                this.Menu_PaintMode_Rect.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Rect;
            }

            if (!(this.Menu_PaintMode_Numbers.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Number)))
            {
                this.Menu_PaintMode_Numbers.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Number;
            }

            // Actions
            if (!(this.Menu_PaintMode_Highlight.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Highlight)))
            {
                this.Menu_PaintMode_Highlight.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Highlight;
            }

            if (!(this.Menu_PaintMode_Invert.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Invert)))
            {
                this.Menu_PaintMode_Invert.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Invert;
            }

            if (!(this.Menu_PaintMode_Grayscale.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Grayscale)))
            {
                this.Menu_PaintMode_Grayscale.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Grayscale;
            }

            if (!(this.Menu_PaintMode_Blur.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Blur)))
            {
                this.Menu_PaintMode_Blur.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Blur;
            }

            if (!(this.Menu_PaintMode_Puzzle.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Puzzle)))
            {
                this.Menu_PaintMode_Puzzle.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Puzzle;
            }

            if (!(this.Menu_PaintMode_Crop.Checked == ((int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Crop)))
            {
                this.Menu_PaintMode_Crop.Checked = (int)this.Editor_Main.PaintMode == (int)Editor.EditorPaintMode.Crop;
            }

            if (!Operators.ConditionalCompareObjectEqual(this.Button_Size.Tag, this.Editor_Main.CurrentPen.Width, false))
            {
                this.Button_Size.Text = Conversions.ToString(this.Editor_Main.CurrentPen.Width) + "px";
                this.Button_Size.Tag = this.Editor_Main.CurrentPen.Width;
            }

            // Special actions
            if (!(this.Button_Back.Enabled == this.Editor_Main.CanUndo))
            {
                this.Button_Back.Enabled = this.Editor_Main.CanUndo;
            }

            if (!(this.Button_Redo.Enabled == this.Editor_Main.CanRedo))
            {
                this.Button_Redo.Enabled = this.Editor_Main.CanRedo;
            }

            int w = this.Width;
            int h = this.Height;
            int l = w + 4 - this.Panel_Image.HorizontalScroll.Value;
            int t = h + 4 - this.Panel_Image.VerticalScroll.Value;

            if (!(this.Resizer_Both.Left == l))
            {
                this.Resizer_Both.Left = l;
            }

            if (!(this.Resizer_Both.Top == t))
            {
                this.Resizer_Both.Top = t;
            }

            if (!(this.Resizer_Right.Left == l))
            {
                this.Resizer_Right.Left = l;
            }

            if (!(this.Resizer_Right.Height == h))
            {
                this.Resizer_Right.Height = h;
            }

            if (!(this.Resizer_Bottom.Top == t))
            {
                this.Resizer_Bottom.Top = t;
            }

            if (!(this.Resizer_Bottom.Width == w))
            {
                this.Resizer_Bottom.Width = w;
            }
        }

        private void Menu_PaintMode_Free_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Free;

        private void Menu_PaintMode_Highlight_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Highlight;

        private void Menu_PaintMode_Line_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Line;

        private void Menu_PaintMode_Arrow_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Arrow;

        private void Menu_PaintMode_Oval_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Oval;

        private void Menu_PaintMode_Rect_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Rect;

        private void Menu_PaintMode_Numbers_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Number;

        private void Menu_PaintMode_Select_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Invert;

        private void Menu_PaintMode_Fill_Click(object sender, EventArgs e) => this.Editor_Main.FillObjecs = this.Menu_PaintMode_Fill.Checked;

        private void Menu_PaintMode_Crop_Click(object sender, EventArgs e) => this.Editor_Main.PaintMode = Editor.EditorPaintMode.Crop;

        private int ResizerX;
        private int ResizerY;

        public Form_Edit()
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
            if (e.Button == MouseButtons.Left)
            {
                this.Resizer_Both.Location += new Size(e.X - this.ResizerX, e.Y - this.ResizerY);

                this.Resizer_Right.Location += new Size(e.X - this.ResizerX, 0);
                this.Resizer_Right.Size += new Size(0, e.Y - this.ResizerY);

                this.Resizer_Bottom.Location += new Size(0, e.Y - this.ResizerY);
                this.Resizer_Bottom.Size += new Size(e.X - this.ResizerX, 0);

                this.Editor_Main.Size += new Size(e.X - this.ResizerX, e.Y - this.ResizerY);
            }
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
            this.Images[0] = this.Editor_Main.BackgroundImage;
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            this.Render();

            if (this.PublishSaveToFile(PublishOptions.SaveToFile | PublishOptions.CopyPathOrULR))
            {
                this.Close();
            }
        }

        private void Button_SaveAs_Click(object sender, EventArgs e)
        {
            this.Render();

            if (this.PublishSaveToFile(PublishOptions.SaveToFile | PublishOptions.SaveAs | PublishOptions.CopyPathOrULR))
            {
                this.Close();
            }
        }

        private void Button_SaveCopy_Click(object sender, EventArgs e)
        {
            this.Render();

            if (this.PublishToClipboard(0))
            {
                this.Close();
            }
        }

        private void Menu_PaintMode_Numbers_ButtonClick(object sender, EventArgs e)
        {
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
                    ((ToolStripButton)item).Checked = Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(item.Tag, this.Editor_Main.LastNumber, false));
                }
            }
        }

        private void ToolStrip_Standard_Palitra_ColorChanged(object sender, PalitraEventArgs e)
        {
            this.Editor_Main.CurrentPen.Color = this.ToolStrip_Standard_Palitra.Color1;
            ((SolidBrush)this.Editor_Main.CurrentBrush).Color = this.ToolStrip_Standard_Palitra.Color2;

            if (this.Editor_Main.CurrentPen.Color.IsKnownColor)
            {
                this.Button_Color.Text = this.Editor_Main.CurrentPen.Color.Name;
            }
            else
            {
                this.Button_Color.Text = $"{this.Editor_Main.CurrentPen.Color.R}, {this.Editor_Main.CurrentPen.Color.G}, {this.Editor_Main.CurrentPen.Color.B}";
            }
        }
    }
}
