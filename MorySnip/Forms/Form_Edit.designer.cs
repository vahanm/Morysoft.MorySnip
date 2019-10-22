using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Morysoft.MorySnip
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_Edit : FormSaveBase
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                    components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Edit));
            this._ToolStripContainer_Main = new ToolStripContainer();
            this._Panel_Image = new Panel();
            this._Resizer_Both = new Label();
            _Resizer_Both.MouseDown += Resizers_MouseDown;
            _Resizer_Both.MouseMove += Resizer_Both_MouseMove;
            this._Resizer_Bottom = new Label();
            _Resizer_Bottom.MouseDown += Resizers_MouseDown;
            _Resizer_Bottom.MouseMove += Resizer_Bottom_MouseMove;
            this._Resizer_Right = new Label();
            _Resizer_Right.MouseDown += Resizers_MouseDown;
            _Resizer_Right.MouseMove += Resizer_Right_MouseMove;
            this._Editor_Main = new Editor();
            _Editor_Main.LastNumberChanged += Editor_Main_LastNumberChanged;
            this._ToolStrip_Draw = new ToolStrip();
            this._Menu_Numbers = new ContextMenuStrip(this.components);
            this._IncrementToolStripMenuItem = new ToolStripMenuItem();
            this._DecrementToolStripMenuItem = new ToolStripMenuItem();
            this._ToolStripSeparator10 = new ToolStripSeparator();
            this._Menu_PaintMode_Free = new ToolStripButton();
            _Menu_PaintMode_Free.Click += Menu_PaintMode_Free_Click;
            this._Menu_PaintMode_Line = new ToolStripButton();
            _Menu_PaintMode_Line.Click += Menu_PaintMode_Line_Click;
            this._Menu_PaintMode_Arrow = new ToolStripButton();
            _Menu_PaintMode_Arrow.Click += Menu_PaintMode_Arrow_Click;
            this._Menu_PaintMode_Oval = new ToolStripButton();
            _Menu_PaintMode_Oval.Click += Menu_PaintMode_Oval_Click;
            this._Menu_PaintMode_Rect = new ToolStripButton();
            _Menu_PaintMode_Rect.Click += Menu_PaintMode_Rect_Click;
            this._ToolStripSeparator7 = new ToolStripSeparator();
            this._Menu_PaintMode_Numbers = new ToolStripButton();
            _Menu_PaintMode_Numbers.Click += Menu_PaintMode_Numbers_Click;
            this._ToolStripSeparator9 = new ToolStripSeparator();
            this._Menu_PaintMode_Fill = new ToolStripButton();
            _Menu_PaintMode_Fill.Click += Menu_PaintMode_Fill_Click;
            this._ToolStripButton1 = new ToolStripButton();
            this._ToolStrip_Effects = new ToolStrip();
            this._Menu_PaintMode_Crop = new ToolStripButton();
            _Menu_PaintMode_Crop.Click += Menu_PaintMode_Crop_Click;
            this._ToolStripSeparator4 = new ToolStripSeparator();
            this._Menu_PaintMode_Highlight = new ToolStripButton();
            _Menu_PaintMode_Highlight.Click += Menu_PaintMode_Highlight_Click;
            this._Menu_PaintMode_Puzzle = new ToolStripButton();
            _Menu_PaintMode_Puzzle.Click += Menu_PaintMode_Puzzle_Click;
            this._Menu_PaintMode_Blur = new ToolStripButton();
            _Menu_PaintMode_Blur.Click += Button_Effect_Blur_Click;
            this._Menu_PaintMode_Invert = new ToolStripButton();
            _Menu_PaintMode_Invert.Click += Button_Effect_Invert_Click;
            this._Menu_PaintMode_Grayscale = new ToolStripButton();
            _Menu_PaintMode_Grayscale.Click += Button_Effect_Grayscale_Click;
            this._ToolStripButton2 = new ToolStripButton();
            this._ToolStrip_Standard = new ToolStrip();
            this._Button_Save = new ToolStripButton();
            _Button_Save.Click += Button_Save_Click;
            this._Button_SaveAs = new ToolStripButton();
            _Button_SaveAs.Click += Button_SaveAs_Click;
            this._Button_SaveCopy = new ToolStripButton();
            _Button_SaveCopy.Click += Button_SaveCopy_Click;
            this._ToolStripSeparator6 = new ToolStripSeparator();
            this._Button_Back = new ToolStripButton();
            _Button_Back.Click += Button_Back_Click;
            this._Button_Redo = new ToolStripButton();
            _Button_Redo.Click += Button_Redo_Click;
            this._ToolStripSeparator8 = new ToolStripSeparator();
            this._ToolStrip_Standard_Palitra = new ToolStripPalitra();
            _ToolStrip_Standard_Palitra.ColorChanged += ToolStrip_Standard_Palitra_ColorChanged;
            this._Button_Color = new ToolStripDropDownButton();
            this._Menu_Pens = new ContextMenuStrip(this.components);
            this._RedToolStripMenuItem = new ToolStripMenuItem();
            _RedToolStripMenuItem.Click += RedToolStripMenuItem_Click;
            this._BlueToolStripMenuItem = new ToolStripMenuItem();
            _BlueToolStripMenuItem.Click += BlueToolStripMenuItem_Click;
            this._BlackToolStripMenuItem = new ToolStripMenuItem();
            _BlackToolStripMenuItem.Click += BlackToolStripMenuItem_Click;
            this._WhiteToolStripMenuItem = new ToolStripMenuItem();
            _WhiteToolStripMenuItem.Click += WhiteToolStripMenuItem_Click;
            this._ToolStripSeparator1 = new ToolStripSeparator();
            this._CustomToolStripMenuItem = new ToolStripMenuItem();
            _CustomToolStripMenuItem.Click += CustomToolStripMenuItem_Click;
            this._Button_Size = new ToolStripDropDownButton();
            this._Menu_Size = new ContextMenuStrip(this.components);
            _Menu_Size.ItemClicked += Menu_Size_ItemClicked;
            this._ToolStripMenuItem7 = new ToolStripMenuItem();
            this._ToolStripMenuItem8 = new ToolStripMenuItem();
            this._ToolStripMenuItem9 = new ToolStripMenuItem();
            this._ToolStripMenuItem10 = new ToolStripMenuItem();
            this._ToolStripMenuItem11 = new ToolStripMenuItem();
            this._ToolStripMenuItem12 = new ToolStripMenuItem();
            this._ToolStripMenuItem13 = new ToolStripMenuItem();
            this._ToolStripMenuItem14 = new ToolStripMenuItem();
            this._ToolStripMenuItem15 = new ToolStripMenuItem();
            this._ToolStripMenuItem16 = new ToolStripMenuItem();
            this._ToolStripMenuItem17 = new ToolStripMenuItem();
            this._ToolStripMenuItem18 = new ToolStripMenuItem();
            this._ToolStripSeparator3 = new ToolStripSeparator();
            this._Button_Rotate_Left = new ToolStripButton();
            _Button_Rotate_Left.Click += Button_Rotate_Left_Click;
            this._Button_Rotate_Right = new ToolStripButton();
            _Button_Rotate_Right.Click += Button_Rotate_Right_Click;
            this._ToolStripSeparator5 = new ToolStripSeparator();
            this._Button_Flip_X = new ToolStripButton();
            _Button_Flip_X.Click += Button_Flip_X_Click;
            this._Button_Flip_Y = new ToolStripButton();
            _Button_Flip_Y.Click += Button_Flip_Y_Click;
            this._Menu_ForNothing1 = new ToolStripButton();
            this._Menu_PaintMode = new ContextMenuStrip(this.components);
            this._ToolStripMenuItem1 = new ToolStripMenuItem();
            _ToolStripMenuItem1.Click += RedToolStripMenuItem_Click;
            this._ToolStripMenuItem2 = new ToolStripMenuItem();
            _ToolStripMenuItem2.Click += BlueToolStripMenuItem_Click;
            this._ToolStripMenuItem3 = new ToolStripMenuItem();
            _ToolStripMenuItem3.Click += BlackToolStripMenuItem_Click;
            this._ToolStripMenuItem4 = new ToolStripMenuItem();
            _ToolStripMenuItem4.Click += WhiteToolStripMenuItem_Click;
            this._ToolStripSeparator2 = new ToolStripSeparator();
            this._ToolStripMenuItem5 = new ToolStripMenuItem();
            _ToolStripMenuItem5.Click += CustomToolStripMenuItem_Click;
            this._Timer_Update = new Timer(this.components);
            _Timer_Update.Tick += Timer_Update_Tick;
            this._ToolStripContainer_Main.ContentPanel.SuspendLayout();
            this._ToolStripContainer_Main.LeftToolStripPanel.SuspendLayout();
            this._ToolStripContainer_Main.TopToolStripPanel.SuspendLayout();
            this._ToolStripContainer_Main.SuspendLayout();
            this._Panel_Image.SuspendLayout();
            this._ToolStrip_Draw.SuspendLayout();
            this._Menu_Numbers.SuspendLayout();
            this._ToolStrip_Effects.SuspendLayout();
            this._ToolStrip_Standard.SuspendLayout();
            this._Menu_Pens.SuspendLayout();
            this._Menu_Size.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripContainer_Main
            // 
            // 
            // ToolStripContainer_Main.ContentPanel
            // 
            this._ToolStripContainer_Main.ContentPanel.Controls.Add(this._Panel_Image);
            resources.ApplyResources(this._ToolStripContainer_Main.ContentPanel, "ToolStripContainer_Main.ContentPanel");
            resources.ApplyResources(this._ToolStripContainer_Main, "ToolStripContainer_Main");
            // 
            // ToolStripContainer_Main.LeftToolStripPanel
            // 
            this._ToolStripContainer_Main.LeftToolStripPanel.Controls.Add(this._ToolStrip_Draw);
            this._ToolStripContainer_Main.LeftToolStripPanel.Controls.Add(this._ToolStrip_Effects);
            this._ToolStripContainer_Main.Name = "ToolStripContainer_Main";
            // 
            // ToolStripContainer_Main.TopToolStripPanel
            // 
            this._ToolStripContainer_Main.TopToolStripPanel.Controls.Add(this._ToolStrip_Standard);
            // 
            // Panel_Image
            // 
            resources.ApplyResources(this._Panel_Image, "Panel_Image");
            this._Panel_Image.BorderStyle = BorderStyle.Fixed3D;
            this._Panel_Image.Controls.Add(this._Resizer_Both);
            this._Panel_Image.Controls.Add(this._Resizer_Bottom);
            this._Panel_Image.Controls.Add(this._Resizer_Right);
            this._Panel_Image.Controls.Add(this._Editor_Main);
            this._Panel_Image.Name = "Panel_Image";
            // 
            // Resizer_Both
            // 
            this._Resizer_Both.BackColor = Color.White;
            this._Resizer_Both.BorderStyle = BorderStyle.FixedSingle;
            this._Resizer_Both.Cursor = Cursors.SizeNWSE;
            resources.ApplyResources(this._Resizer_Both, "Resizer_Both");
            this._Resizer_Both.Name = "Resizer_Both";
            // 
            // Resizer_Bottom
            // 
            this._Resizer_Bottom.BackColor = Color.White;
            this._Resizer_Bottom.BorderStyle = BorderStyle.FixedSingle;
            this._Resizer_Bottom.Cursor = Cursors.SizeNS;
            resources.ApplyResources(this._Resizer_Bottom, "Resizer_Bottom");
            this._Resizer_Bottom.Name = "Resizer_Bottom";
            // 
            // Resizer_Right
            // 
            this._Resizer_Right.BackColor = Color.White;
            this._Resizer_Right.BorderStyle = BorderStyle.FixedSingle;
            this._Resizer_Right.Cursor = Cursors.SizeWE;
            resources.ApplyResources(this._Resizer_Right, "Resizer_Right");
            this._Resizer_Right.Name = "Resizer_Right";
            // 
            // Editor_Main
            // 
            this._Editor_Main.FillObjecs = false;
            this._Editor_Main.LastNumber = 1;
            resources.ApplyResources(this._Editor_Main, "Editor_Main");
            this._Editor_Main.Name = "Editor_Main";
            this._Editor_Main.PaintMode = Editor.PaintModes.Rect;
            // 
            // ToolStrip_Draw
            // 
            this._ToolStrip_Draw.ContextMenuStrip = this._Menu_Numbers;
            resources.ApplyResources(this._ToolStrip_Draw, "ToolStrip_Draw");
            this._ToolStrip_Draw.Items.AddRange(new ToolStripItem[] { this._Menu_PaintMode_Free, this._Menu_PaintMode_Line, this._Menu_PaintMode_Arrow, this._Menu_PaintMode_Oval, this._Menu_PaintMode_Rect, this._ToolStripSeparator7, this._Menu_PaintMode_Numbers, this._ToolStripSeparator9, this._Menu_PaintMode_Fill, this._ToolStripButton1 });
            this._ToolStrip_Draw.Name = "ToolStrip_Draw";
            // 
            // Menu_Numbers
            // 
            this._Menu_Numbers.Items.AddRange(new ToolStripItem[] { this._IncrementToolStripMenuItem, this._DecrementToolStripMenuItem, this._ToolStripSeparator10 });
            this._Menu_Numbers.Name = "Menu_Numbers";
            resources.ApplyResources(this._Menu_Numbers, "Menu_Numbers");
            // 
            // IncrementToolStripMenuItem
            // 
            this._IncrementToolStripMenuItem.Checked = true;
            this._IncrementToolStripMenuItem.CheckState = CheckState.Checked;
            this._IncrementToolStripMenuItem.Name = "IncrementToolStripMenuItem";
            resources.ApplyResources(this._IncrementToolStripMenuItem, "IncrementToolStripMenuItem");
            // 
            // DecrementToolStripMenuItem
            // 
            resources.ApplyResources(this._DecrementToolStripMenuItem, "DecrementToolStripMenuItem");
            this._DecrementToolStripMenuItem.Name = "DecrementToolStripMenuItem";
            // 
            // ToolStripSeparator10
            // 
            this._ToolStripSeparator10.Name = "ToolStripSeparator10";
            resources.ApplyResources(this._ToolStripSeparator10, "ToolStripSeparator10");
            // 
            // Menu_PaintMode_Free
            // 
            this._Menu_PaintMode_Free.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Free.Image = Morysoft.MorySnip.Properties.Resources.free;
            resources.ApplyResources(this._Menu_PaintMode_Free, "Menu_PaintMode_Free");
            this._Menu_PaintMode_Free.Name = "Menu_PaintMode_Free";
            // 
            // Menu_PaintMode_Line
            // 
            this._Menu_PaintMode_Line.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Line.Image = Morysoft.MorySnip.Properties.Resources.line;
            resources.ApplyResources(this._Menu_PaintMode_Line, "Menu_PaintMode_Line");
            this._Menu_PaintMode_Line.Name = "Menu_PaintMode_Line";
            // 
            // Menu_PaintMode_Arrow
            // 
            this._Menu_PaintMode_Arrow.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Arrow.Image = Morysoft.MorySnip.Properties.Resources.arrow;
            resources.ApplyResources(this._Menu_PaintMode_Arrow, "Menu_PaintMode_Arrow");
            this._Menu_PaintMode_Arrow.Name = "Menu_PaintMode_Arrow";
            // 
            // Menu_PaintMode_Oval
            // 
            this._Menu_PaintMode_Oval.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Oval.Image = Morysoft.MorySnip.Properties.Resources.oval;
            resources.ApplyResources(this._Menu_PaintMode_Oval, "Menu_PaintMode_Oval");
            this._Menu_PaintMode_Oval.Name = "Menu_PaintMode_Oval";
            // 
            // Menu_PaintMode_Rect
            // 
            this._Menu_PaintMode_Rect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Rect.Image = Morysoft.MorySnip.Properties.Resources.rect;
            resources.ApplyResources(this._Menu_PaintMode_Rect, "Menu_PaintMode_Rect");
            this._Menu_PaintMode_Rect.Name = "Menu_PaintMode_Rect";
            // 
            // ToolStripSeparator7
            // 
            this._ToolStripSeparator7.Name = "ToolStripSeparator7";
            resources.ApplyResources(this._ToolStripSeparator7, "ToolStripSeparator7");
            // 
            // Menu_PaintMode_Numbers
            // 
            this._Menu_PaintMode_Numbers.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Numbers.Image = Morysoft.MorySnip.Properties.Resources.Numbers;
            resources.ApplyResources(this._Menu_PaintMode_Numbers, "Menu_PaintMode_Numbers");
            this._Menu_PaintMode_Numbers.Name = "Menu_PaintMode_Numbers";
            // 
            // ToolStripSeparator9
            // 
            this._ToolStripSeparator9.Name = "ToolStripSeparator9";
            resources.ApplyResources(this._ToolStripSeparator9, "ToolStripSeparator9");
            // 
            // Menu_PaintMode_Fill
            // 
            this._Menu_PaintMode_Fill.CheckOnClick = true;
            this._Menu_PaintMode_Fill.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Fill.Image = Morysoft.MorySnip.Properties.Resources.fill;
            resources.ApplyResources(this._Menu_PaintMode_Fill, "Menu_PaintMode_Fill");
            this._Menu_PaintMode_Fill.Name = "Menu_PaintMode_Fill";
            // 
            // ToolStripButton1
            // 
            resources.ApplyResources(this._ToolStripButton1, "ToolStripButton1");
            this._ToolStripButton1.Name = "ToolStripButton1";
            this._ToolStripButton1.Overflow = ToolStripItemOverflow.Always;
            // 
            // ToolStrip_Effects
            // 
            resources.ApplyResources(this._ToolStrip_Effects, "ToolStrip_Effects");
            this._ToolStrip_Effects.Items.AddRange(new ToolStripItem[] { this._Menu_PaintMode_Crop, this._ToolStripSeparator4, this._Menu_PaintMode_Highlight, this._Menu_PaintMode_Puzzle, this._Menu_PaintMode_Blur, this._Menu_PaintMode_Invert, this._Menu_PaintMode_Grayscale, this._ToolStripButton2 });
            this._ToolStrip_Effects.Name = "ToolStrip_Effects";
            // 
            // Menu_PaintMode_Crop
            // 
            this._Menu_PaintMode_Crop.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Crop.Image = Morysoft.MorySnip.Properties.Resources.transform_crop;
            resources.ApplyResources(this._Menu_PaintMode_Crop, "Menu_PaintMode_Crop");
            this._Menu_PaintMode_Crop.Name = "Menu_PaintMode_Crop";
            // 
            // ToolStripSeparator4
            // 
            this._ToolStripSeparator4.Name = "ToolStripSeparator4";
            resources.ApplyResources(this._ToolStripSeparator4, "ToolStripSeparator4");
            // 
            // Menu_PaintMode_Highlight
            // 
            this._Menu_PaintMode_Highlight.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Highlight.Image = Morysoft.MorySnip.Properties.Resources.highlight;
            resources.ApplyResources(this._Menu_PaintMode_Highlight, "Menu_PaintMode_Highlight");
            this._Menu_PaintMode_Highlight.Name = "Menu_PaintMode_Highlight";
            // 
            // Menu_PaintMode_Puzzle
            // 
            this._Menu_PaintMode_Puzzle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Puzzle.Image = Morysoft.MorySnip.Properties.Resources.blur;
            resources.ApplyResources(this._Menu_PaintMode_Puzzle, "Menu_PaintMode_Puzzle");
            this._Menu_PaintMode_Puzzle.Name = "Menu_PaintMode_Puzzle";
            // 
            // Menu_PaintMode_Blur
            // 
            this._Menu_PaintMode_Blur.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Blur.Image = Morysoft.MorySnip.Properties.Resources.blur;
            resources.ApplyResources(this._Menu_PaintMode_Blur, "Menu_PaintMode_Blur");
            this._Menu_PaintMode_Blur.Name = "Menu_PaintMode_Blur";
            // 
            // Menu_PaintMode_Invert
            // 
            this._Menu_PaintMode_Invert.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Invert.Image = Morysoft.MorySnip.Properties.Resources.stock_filters_invert_16;
            resources.ApplyResources(this._Menu_PaintMode_Invert, "Menu_PaintMode_Invert");
            this._Menu_PaintMode_Invert.Name = "Menu_PaintMode_Invert";
            // 
            // Menu_PaintMode_Grayscale
            // 
            this._Menu_PaintMode_Grayscale.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Menu_PaintMode_Grayscale.Image = Morysoft.MorySnip.Properties.Resources.black_white;
            resources.ApplyResources(this._Menu_PaintMode_Grayscale, "Menu_PaintMode_Grayscale");
            this._Menu_PaintMode_Grayscale.Name = "Menu_PaintMode_Grayscale";
            // 
            // ToolStripButton2
            // 
            resources.ApplyResources(this._ToolStripButton2, "ToolStripButton2");
            this._ToolStripButton2.Name = "ToolStripButton2";
            this._ToolStripButton2.Overflow = ToolStripItemOverflow.Always;
            // 
            // ToolStrip_Standard
            // 
            resources.ApplyResources(this._ToolStrip_Standard, "ToolStrip_Standard");
            this._ToolStrip_Standard.ImageScalingSize = new Size(32, 32);
            this._ToolStrip_Standard.Items.AddRange(new ToolStripItem[] { this._Button_Save, this._Button_SaveAs, this._Button_SaveCopy, this._ToolStripSeparator6, this._Button_Back, this._Button_Redo, this._ToolStripSeparator8, this._ToolStrip_Standard_Palitra, this._Button_Color, this._Button_Size, this._ToolStripSeparator3, this._Button_Rotate_Left, this._Button_Rotate_Right, this._ToolStripSeparator5, this._Button_Flip_X, this._Button_Flip_Y, this._Menu_ForNothing1 });
            this._ToolStrip_Standard.Name = "ToolStrip_Standard";
            // 
            // Button_Save
            // 
            this._Button_Save.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Button_Save.Image = Morysoft.MorySnip.Properties.Resources._1371823810_save;
            resources.ApplyResources(this._Button_Save, "Button_Save");
            this._Button_Save.Name = "Button_Save";
            // 
            // Button_SaveAs
            // 
            this._Button_SaveAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Button_SaveAs.Image = Morysoft.MorySnip.Properties.Resources._1371823810_saveas;
            resources.ApplyResources(this._Button_SaveAs, "Button_SaveAs");
            this._Button_SaveAs.Name = "Button_SaveAs";
            // 
            // Button_SaveCopy
            // 
            this._Button_SaveCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Button_SaveCopy.Image = Morysoft.MorySnip.Properties.Resources._1371824300_clipboard_copy;
            resources.ApplyResources(this._Button_SaveCopy, "Button_SaveCopy");
            this._Button_SaveCopy.Name = "Button_SaveCopy";
            // 
            // ToolStripSeparator6
            // 
            this._ToolStripSeparator6.Name = "ToolStripSeparator6";
            resources.ApplyResources(this._ToolStripSeparator6, "ToolStripSeparator6");
            // 
            // Button_Back
            // 
            this._Button_Back.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Button_Back.Image = Morysoft.MorySnip.Properties.Resources.Arrow2___left;
            resources.ApplyResources(this._Button_Back, "Button_Back");
            this._Button_Back.Name = "Button_Back";
            // 
            // Button_Redo
            // 
            this._Button_Redo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this._Button_Redo.Image = Morysoft.MorySnip.Properties.Resources.Arrow2___right;
            resources.ApplyResources(this._Button_Redo, "Button_Redo");
            this._Button_Redo.Name = "Button_Redo";
            // 
            // ToolStripSeparator8
            // 
            this._ToolStripSeparator8.Name = "ToolStripSeparator8";
            resources.ApplyResources(this._ToolStripSeparator8, "ToolStripSeparator8");
            // 
            // ToolStrip_Standard_Palitra
            // 
            resources.ApplyResources(this._ToolStrip_Standard_Palitra, "ToolStrip_Standard_Palitra");
            this._ToolStrip_Standard_Palitra.Name = "ToolStrip_Standard_Palitra";
            // 
            // Button_Color
            // 
            this._Button_Color.DropDown = this._Menu_Pens;
            resources.ApplyResources(this._Button_Color, "Button_Color");
            this._Button_Color.Name = "Button_Color";
            // 
            // Menu_Pens
            // 
            this._Menu_Pens.Items.AddRange(new ToolStripItem[] { this._RedToolStripMenuItem, this._BlueToolStripMenuItem, this._BlackToolStripMenuItem, this._WhiteToolStripMenuItem, this._ToolStripSeparator1, this._CustomToolStripMenuItem });
            this._Menu_Pens.Name = "Menu_Pens";
            this._Menu_Pens.OwnerItem = this._Button_Color;
            resources.ApplyResources(this._Menu_Pens, "Menu_Pens");
            // 
            // RedToolStripMenuItem
            // 
            this._RedToolStripMenuItem.Name = "RedToolStripMenuItem";
            resources.ApplyResources(this._RedToolStripMenuItem, "RedToolStripMenuItem");
            // 
            // BlueToolStripMenuItem
            // 
            this._BlueToolStripMenuItem.Name = "BlueToolStripMenuItem";
            resources.ApplyResources(this._BlueToolStripMenuItem, "BlueToolStripMenuItem");
            // 
            // BlackToolStripMenuItem
            // 
            this._BlackToolStripMenuItem.Name = "BlackToolStripMenuItem";
            resources.ApplyResources(this._BlackToolStripMenuItem, "BlackToolStripMenuItem");
            // 
            // WhiteToolStripMenuItem
            // 
            this._WhiteToolStripMenuItem.Name = "WhiteToolStripMenuItem";
            resources.ApplyResources(this._WhiteToolStripMenuItem, "WhiteToolStripMenuItem");
            // 
            // ToolStripSeparator1
            // 
            this._ToolStripSeparator1.Name = "ToolStripSeparator1";
            resources.ApplyResources(this._ToolStripSeparator1, "ToolStripSeparator1");
            // 
            // CustomToolStripMenuItem
            // 
            this._CustomToolStripMenuItem.Name = "CustomToolStripMenuItem";
            resources.ApplyResources(this._CustomToolStripMenuItem, "CustomToolStripMenuItem");
            // 
            // Button_Size
            // 
            this._Button_Size.DropDown = this._Menu_Size;
            resources.ApplyResources(this._Button_Size, "Button_Size");
            this._Button_Size.Name = "Button_Size";
            // 
            // Menu_Size
            // 
            this._Menu_Size.Items.AddRange(new ToolStripItem[] { this._ToolStripMenuItem7, this._ToolStripMenuItem8, this._ToolStripMenuItem9, this._ToolStripMenuItem10, this._ToolStripMenuItem11, this._ToolStripMenuItem12, this._ToolStripMenuItem13, this._ToolStripMenuItem14, this._ToolStripMenuItem15, this._ToolStripMenuItem16, this._ToolStripMenuItem17, this._ToolStripMenuItem18 });
            this._Menu_Size.Name = "Menu_Size";
            this._Menu_Size.OwnerItem = this._Button_Size;
            resources.ApplyResources(this._Menu_Size, "Menu_Size");
            // 
            // ToolStripMenuItem7
            // 
            this._ToolStripMenuItem7.Name = "ToolStripMenuItem7";
            resources.ApplyResources(this._ToolStripMenuItem7, "ToolStripMenuItem7");
            // 
            // ToolStripMenuItem8
            // 
            this._ToolStripMenuItem8.Name = "ToolStripMenuItem8";
            resources.ApplyResources(this._ToolStripMenuItem8, "ToolStripMenuItem8");
            // 
            // ToolStripMenuItem9
            // 
            this._ToolStripMenuItem9.Name = "ToolStripMenuItem9";
            resources.ApplyResources(this._ToolStripMenuItem9, "ToolStripMenuItem9");
            // 
            // ToolStripMenuItem10
            // 
            this._ToolStripMenuItem10.Name = "ToolStripMenuItem10";
            resources.ApplyResources(this._ToolStripMenuItem10, "ToolStripMenuItem10");
            // 
            // ToolStripMenuItem11
            // 
            this._ToolStripMenuItem11.Name = "ToolStripMenuItem11";
            resources.ApplyResources(this._ToolStripMenuItem11, "ToolStripMenuItem11");
            // 
            // ToolStripMenuItem12
            // 
            this._ToolStripMenuItem12.Name = "ToolStripMenuItem12";
            resources.ApplyResources(this._ToolStripMenuItem12, "ToolStripMenuItem12");
            // 
            // ToolStripMenuItem13
            // 
            this._ToolStripMenuItem13.Name = "ToolStripMenuItem13";
            resources.ApplyResources(this._ToolStripMenuItem13, "ToolStripMenuItem13");
            // 
            // ToolStripMenuItem14
            // 
            this._ToolStripMenuItem14.Name = "ToolStripMenuItem14";
            resources.ApplyResources(this._ToolStripMenuItem14, "ToolStripMenuItem14");
            // 
            // ToolStripMenuItem15
            // 
            this._ToolStripMenuItem15.Name = "ToolStripMenuItem15";
            resources.ApplyResources(this._ToolStripMenuItem15, "ToolStripMenuItem15");
            // 
            // ToolStripMenuItem16
            // 
            this._ToolStripMenuItem16.Name = "ToolStripMenuItem16";
            resources.ApplyResources(this._ToolStripMenuItem16, "ToolStripMenuItem16");
            // 
            // ToolStripMenuItem17
            // 
            this._ToolStripMenuItem17.Name = "ToolStripMenuItem17";
            resources.ApplyResources(this._ToolStripMenuItem17, "ToolStripMenuItem17");
            // 
            // ToolStripMenuItem18
            // 
            this._ToolStripMenuItem18.Name = "ToolStripMenuItem18";
            resources.ApplyResources(this._ToolStripMenuItem18, "ToolStripMenuItem18");
            // 
            // ToolStripSeparator3
            // 
            this._ToolStripSeparator3.Name = "ToolStripSeparator3";
            resources.ApplyResources(this._ToolStripSeparator3, "ToolStripSeparator3");
            // 
            // Button_Rotate_Left
            // 
            this._Button_Rotate_Left.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._Button_Rotate_Left, "Button_Rotate_Left");
            this._Button_Rotate_Left.Name = "Button_Rotate_Left";
            // 
            // Button_Rotate_Right
            // 
            this._Button_Rotate_Right.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._Button_Rotate_Right, "Button_Rotate_Right");
            this._Button_Rotate_Right.Name = "Button_Rotate_Right";
            // 
            // ToolStripSeparator5
            // 
            this._ToolStripSeparator5.Name = "ToolStripSeparator5";
            resources.ApplyResources(this._ToolStripSeparator5, "ToolStripSeparator5");
            // 
            // Button_Flip_X
            // 
            this._Button_Flip_X.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._Button_Flip_X, "Button_Flip_X");
            this._Button_Flip_X.Name = "Button_Flip_X";
            // 
            // Button_Flip_Y
            // 
            this._Button_Flip_Y.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._Button_Flip_Y, "Button_Flip_Y");
            this._Button_Flip_Y.Name = "Button_Flip_Y";
            // 
            // Menu_ForNothing1
            // 
            resources.ApplyResources(this._Menu_ForNothing1, "Menu_ForNothing1");
            this._Menu_ForNothing1.Name = "Menu_ForNothing1";
            this._Menu_ForNothing1.Overflow = ToolStripItemOverflow.Always;
            // 
            // Menu_PaintMode
            // 
            this._Menu_PaintMode.Name = "Menu_PaintMode";
            resources.ApplyResources(this._Menu_PaintMode, "Menu_PaintMode");
            // 
            // ToolStripMenuItem1
            // 
            this._ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            resources.ApplyResources(this._ToolStripMenuItem1, "ToolStripMenuItem1");
            // 
            // ToolStripMenuItem2
            // 
            this._ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            resources.ApplyResources(this._ToolStripMenuItem2, "ToolStripMenuItem2");
            // 
            // ToolStripMenuItem3
            // 
            this._ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            resources.ApplyResources(this._ToolStripMenuItem3, "ToolStripMenuItem3");
            // 
            // ToolStripMenuItem4
            // 
            this._ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            resources.ApplyResources(this._ToolStripMenuItem4, "ToolStripMenuItem4");
            // 
            // ToolStripSeparator2
            // 
            this._ToolStripSeparator2.Name = "ToolStripSeparator2";
            resources.ApplyResources(this._ToolStripSeparator2, "ToolStripSeparator2");
            // 
            // ToolStripMenuItem5
            // 
            this._ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            resources.ApplyResources(this._ToolStripMenuItem5, "ToolStripMenuItem5");
            // 
            // Timer_Update
            // 
            this._Timer_Update.Enabled = true;
            // 
            // Form_Edit
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this._ToolStripContainer_Main);
            this.Name = "Form_Edit";
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._ToolStripContainer_Main.ContentPanel.ResumeLayout(false);
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._ToolStripContainer_Main.LeftToolStripPanel.ResumeLayout(false);
            this._ToolStripContainer_Main.LeftToolStripPanel.PerformLayout();
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._ToolStripContainer_Main.TopToolStripPanel.ResumeLayout(false);
            this._ToolStripContainer_Main.TopToolStripPanel.PerformLayout();
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._ToolStripContainer_Main.ResumeLayout(false);
            this._ToolStripContainer_Main.PerformLayout();
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._Panel_Image.ResumeLayout(false);
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._ToolStrip_Draw.ResumeLayout(false);
            this._ToolStrip_Draw.PerformLayout();
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._Menu_Numbers.ResumeLayout(false);
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._ToolStrip_Effects.ResumeLayout(false);
            this._ToolStrip_Effects.PerformLayout();
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._ToolStrip_Standard.ResumeLayout(false);
            this._ToolStrip_Standard.PerformLayout();
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._Menu_Pens.ResumeLayout(false);
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this._Menu_Size.ResumeLayout(false);
            this.BackgroundImageChanged += Form_Edit_BackgroundImageChanged;
            base.Load += Form_Edit_Load;
            this.ResumeLayout(false);
        }
        private Editor _Editor_Main;

        internal Editor Editor_Main
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Editor_Main;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Editor_Main != null)
                {
                    _Editor_Main.LastNumberChanged -= Editor_Main_LastNumberChanged;
                }

                _Editor_Main = value;
                if (_Editor_Main != null)
                {
                    _Editor_Main.LastNumberChanged += Editor_Main_LastNumberChanged;
                }
            }
        }

        private ToolStrip _ToolStrip_Standard;

        internal ToolStrip ToolStrip_Standard
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStrip_Standard;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStrip_Standard != null)
                {
                }

                _ToolStrip_Standard = value;
                if (_ToolStrip_Standard != null)
                {
                }
            }
        }

        private ToolStripButton _Button_Back;

        internal ToolStripButton Button_Back
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Back;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Back != null)
                {
                    _Button_Back.Click -= Button_Back_Click;
                }

                _Button_Back = value;
                if (_Button_Back != null)
                {
                    _Button_Back.Click += Button_Back_Click;
                }
            }
        }

        private ContextMenuStrip _Menu_Pens;

        internal ContextMenuStrip Menu_Pens
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Pens;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Pens != null)
                {
                }

                _Menu_Pens = value;
                if (_Menu_Pens != null)
                {
                }
            }
        }

        private ToolStripMenuItem _BlackToolStripMenuItem;

        internal ToolStripMenuItem BlackToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BlackToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BlackToolStripMenuItem != null)
                {
                    _BlackToolStripMenuItem.Click -= BlackToolStripMenuItem_Click;
                }

                _BlackToolStripMenuItem = value;
                if (_BlackToolStripMenuItem != null)
                {
                    _BlackToolStripMenuItem.Click += BlackToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _WhiteToolStripMenuItem;

        internal ToolStripMenuItem WhiteToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _WhiteToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_WhiteToolStripMenuItem != null)
                {
                    _WhiteToolStripMenuItem.Click -= WhiteToolStripMenuItem_Click;
                }

                _WhiteToolStripMenuItem = value;
                if (_WhiteToolStripMenuItem != null)
                {
                    _WhiteToolStripMenuItem.Click += WhiteToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator1;

        internal ToolStripSeparator ToolStripSeparator1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator1 != null)
                {
                }

                _ToolStripSeparator1 = value;
                if (_ToolStripSeparator1 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _CustomToolStripMenuItem;

        internal ToolStripMenuItem CustomToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CustomToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CustomToolStripMenuItem != null)
                {
                    _CustomToolStripMenuItem.Click -= CustomToolStripMenuItem_Click;
                }

                _CustomToolStripMenuItem = value;
                if (_CustomToolStripMenuItem != null)
                {
                    _CustomToolStripMenuItem.Click += CustomToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripDropDownButton _Button_Color;

        internal ToolStripDropDownButton Button_Color
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Color;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Color != null)
                {
                }

                _Button_Color = value;
                if (_Button_Color != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem1;

        internal ToolStripMenuItem ToolStripMenuItem1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem1 != null)
                {
                    _ToolStripMenuItem1.Click -= RedToolStripMenuItem_Click;
                }

                _ToolStripMenuItem1 = value;
                if (_ToolStripMenuItem1 != null)
                {
                    _ToolStripMenuItem1.Click += RedToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem2;

        internal ToolStripMenuItem ToolStripMenuItem2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem2 != null)
                {
                    _ToolStripMenuItem2.Click -= BlueToolStripMenuItem_Click;
                }

                _ToolStripMenuItem2 = value;
                if (_ToolStripMenuItem2 != null)
                {
                    _ToolStripMenuItem2.Click += BlueToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem3;

        internal ToolStripMenuItem ToolStripMenuItem3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem3 != null)
                {
                    _ToolStripMenuItem3.Click -= BlackToolStripMenuItem_Click;
                }

                _ToolStripMenuItem3 = value;
                if (_ToolStripMenuItem3 != null)
                {
                    _ToolStripMenuItem3.Click += BlackToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem4;

        internal ToolStripMenuItem ToolStripMenuItem4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem4 != null)
                {
                    _ToolStripMenuItem4.Click -= WhiteToolStripMenuItem_Click;
                }

                _ToolStripMenuItem4 = value;
                if (_ToolStripMenuItem4 != null)
                {
                    _ToolStripMenuItem4.Click += WhiteToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator2;

        internal ToolStripSeparator ToolStripSeparator2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator2 != null)
                {
                }

                _ToolStripSeparator2 = value;
                if (_ToolStripSeparator2 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem5;

        internal ToolStripMenuItem ToolStripMenuItem5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem5 != null)
                {
                    _ToolStripMenuItem5.Click -= CustomToolStripMenuItem_Click;
                }

                _ToolStripMenuItem5 = value;
                if (_ToolStripMenuItem5 != null)
                {
                    _ToolStripMenuItem5.Click += CustomToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripDropDownButton _Button_Size;

        internal ToolStripDropDownButton Button_Size
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Size;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Size != null)
                {
                }

                _Button_Size = value;
                if (_Button_Size != null)
                {
                }
            }
        }

        private ContextMenuStrip _Menu_Size;

        internal ContextMenuStrip Menu_Size
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Size;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Size != null)
                {
                    _Menu_Size.ItemClicked -= Menu_Size_ItemClicked;
                }

                _Menu_Size = value;
                if (_Menu_Size != null)
                {
                    _Menu_Size.ItemClicked += Menu_Size_ItemClicked;
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem7;

        internal ToolStripMenuItem ToolStripMenuItem7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem7 != null)
                {
                }

                _ToolStripMenuItem7 = value;
                if (_ToolStripMenuItem7 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem8;

        internal ToolStripMenuItem ToolStripMenuItem8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem8 != null)
                {
                }

                _ToolStripMenuItem8 = value;
                if (_ToolStripMenuItem8 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem9;

        internal ToolStripMenuItem ToolStripMenuItem9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem9 != null)
                {
                }

                _ToolStripMenuItem9 = value;
                if (_ToolStripMenuItem9 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem10;

        internal ToolStripMenuItem ToolStripMenuItem10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem10 != null)
                {
                }

                _ToolStripMenuItem10 = value;
                if (_ToolStripMenuItem10 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem11;

        internal ToolStripMenuItem ToolStripMenuItem11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem11 != null)
                {
                }

                _ToolStripMenuItem11 = value;
                if (_ToolStripMenuItem11 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem12;

        internal ToolStripMenuItem ToolStripMenuItem12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem12 != null)
                {
                }

                _ToolStripMenuItem12 = value;
                if (_ToolStripMenuItem12 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem13;

        internal ToolStripMenuItem ToolStripMenuItem13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem13 != null)
                {
                }

                _ToolStripMenuItem13 = value;
                if (_ToolStripMenuItem13 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem14;

        internal ToolStripMenuItem ToolStripMenuItem14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem14 != null)
                {
                }

                _ToolStripMenuItem14 = value;
                if (_ToolStripMenuItem14 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem15;

        internal ToolStripMenuItem ToolStripMenuItem15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem15 != null)
                {
                }

                _ToolStripMenuItem15 = value;
                if (_ToolStripMenuItem15 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem16;

        internal ToolStripMenuItem ToolStripMenuItem16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem16 != null)
                {
                }

                _ToolStripMenuItem16 = value;
                if (_ToolStripMenuItem16 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem17;

        internal ToolStripMenuItem ToolStripMenuItem17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem17 != null)
                {
                }

                _ToolStripMenuItem17 = value;
                if (_ToolStripMenuItem17 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItem18;

        internal ToolStripMenuItem ToolStripMenuItem18
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem18;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem18 != null)
                {
                }

                _ToolStripMenuItem18 = value;
                if (_ToolStripMenuItem18 != null)
                {
                }
            }
        }

        private Timer _Timer_Update;

        internal Timer Timer_Update
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Timer_Update;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Timer_Update != null)
                {
                    _Timer_Update.Tick -= Timer_Update_Tick;
                }

                _Timer_Update = value;
                if (_Timer_Update != null)
                {
                    _Timer_Update.Tick += Timer_Update_Tick;
                }
            }
        }

        private ToolStripButton _Button_Rotate_Left;

        internal ToolStripButton Button_Rotate_Left
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Rotate_Left;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Rotate_Left != null)
                {
                    _Button_Rotate_Left.Click -= Button_Rotate_Left_Click;
                }

                _Button_Rotate_Left = value;
                if (_Button_Rotate_Left != null)
                {
                    _Button_Rotate_Left.Click += Button_Rotate_Left_Click;
                }
            }
        }

        private ToolStripButton _Button_Rotate_Right;

        internal ToolStripButton Button_Rotate_Right
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Rotate_Right;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Rotate_Right != null)
                {
                    _Button_Rotate_Right.Click -= Button_Rotate_Right_Click;
                }

                _Button_Rotate_Right = value;
                if (_Button_Rotate_Right != null)
                {
                    _Button_Rotate_Right.Click += Button_Rotate_Right_Click;
                }
            }
        }

        private ToolStripButton _Button_Flip_X;

        internal ToolStripButton Button_Flip_X
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Flip_X;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Flip_X != null)
                {
                    _Button_Flip_X.Click -= Button_Flip_X_Click;
                }

                _Button_Flip_X = value;
                if (_Button_Flip_X != null)
                {
                    _Button_Flip_X.Click += Button_Flip_X_Click;
                }
            }
        }

        private ToolStripButton _Button_Flip_Y;

        internal ToolStripButton Button_Flip_Y
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Flip_Y;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Flip_Y != null)
                {
                    _Button_Flip_Y.Click -= Button_Flip_Y_Click;
                }

                _Button_Flip_Y = value;
                if (_Button_Flip_Y != null)
                {
                    _Button_Flip_Y.Click += Button_Flip_Y_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator3;

        internal ToolStripSeparator ToolStripSeparator3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator3 != null)
                {
                }

                _ToolStripSeparator3 = value;
                if (_ToolStripSeparator3 != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator5;

        internal ToolStripSeparator ToolStripSeparator5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator5 != null)
                {
                }

                _ToolStripSeparator5 = value;
                if (_ToolStripSeparator5 != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator8;

        internal ToolStripSeparator ToolStripSeparator8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator8 != null)
                {
                }

                _ToolStripSeparator8 = value;
                if (_ToolStripSeparator8 != null)
                {
                }
            }
        }

        private ContextMenuStrip _Menu_PaintMode;

        internal ContextMenuStrip Menu_PaintMode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode != null)
                {
                }

                _Menu_PaintMode = value;
                if (_Menu_PaintMode != null)
                {
                }
            }
        }

        private ToolStrip _ToolStrip_Draw;

        internal ToolStrip ToolStrip_Draw
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStrip_Draw;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStrip_Draw != null)
                {
                }

                _ToolStrip_Draw = value;
                if (_ToolStrip_Draw != null)
                {
                }
            }
        }

        private ToolStripMenuItem _RedToolStripMenuItem;

        internal ToolStripMenuItem RedToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RedToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RedToolStripMenuItem != null)
                {
                    _RedToolStripMenuItem.Click -= RedToolStripMenuItem_Click;
                }

                _RedToolStripMenuItem = value;
                if (_RedToolStripMenuItem != null)
                {
                    _RedToolStripMenuItem.Click += RedToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _BlueToolStripMenuItem;

        internal ToolStripMenuItem BlueToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BlueToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BlueToolStripMenuItem != null)
                {
                    _BlueToolStripMenuItem.Click -= BlueToolStripMenuItem_Click;
                }

                _BlueToolStripMenuItem = value;
                if (_BlueToolStripMenuItem != null)
                {
                    _BlueToolStripMenuItem.Click += BlueToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Free;

        internal ToolStripButton Menu_PaintMode_Free
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Free;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Free != null)
                {
                    _Menu_PaintMode_Free.Click -= Menu_PaintMode_Free_Click;
                }

                _Menu_PaintMode_Free = value;
                if (_Menu_PaintMode_Free != null)
                {
                    _Menu_PaintMode_Free.Click += Menu_PaintMode_Free_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator9;

        internal ToolStripSeparator ToolStripSeparator9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator9 != null)
                {
                }

                _ToolStripSeparator9 = value;
                if (_ToolStripSeparator9 != null)
                {
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Line;

        internal ToolStripButton Menu_PaintMode_Line
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Line;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Line != null)
                {
                    _Menu_PaintMode_Line.Click -= Menu_PaintMode_Line_Click;
                }

                _Menu_PaintMode_Line = value;
                if (_Menu_PaintMode_Line != null)
                {
                    _Menu_PaintMode_Line.Click += Menu_PaintMode_Line_Click;
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Oval;

        internal ToolStripButton Menu_PaintMode_Oval
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Oval;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Oval != null)
                {
                    _Menu_PaintMode_Oval.Click -= Menu_PaintMode_Oval_Click;
                }

                _Menu_PaintMode_Oval = value;
                if (_Menu_PaintMode_Oval != null)
                {
                    _Menu_PaintMode_Oval.Click += Menu_PaintMode_Oval_Click;
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Rect;

        internal ToolStripButton Menu_PaintMode_Rect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Rect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Rect != null)
                {
                    _Menu_PaintMode_Rect.Click -= Menu_PaintMode_Rect_Click;
                }

                _Menu_PaintMode_Rect = value;
                if (_Menu_PaintMode_Rect != null)
                {
                    _Menu_PaintMode_Rect.Click += Menu_PaintMode_Rect_Click;
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Fill;

        internal ToolStripButton Menu_PaintMode_Fill
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Fill;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Fill != null)
                {
                    _Menu_PaintMode_Fill.Click -= Menu_PaintMode_Fill_Click;
                }

                _Menu_PaintMode_Fill = value;
                if (_Menu_PaintMode_Fill != null)
                {
                    _Menu_PaintMode_Fill.Click += Menu_PaintMode_Fill_Click;
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Arrow;

        internal ToolStripButton Menu_PaintMode_Arrow
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Arrow;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Arrow != null)
                {
                    _Menu_PaintMode_Arrow.Click -= Menu_PaintMode_Arrow_Click;
                }

                _Menu_PaintMode_Arrow = value;
                if (_Menu_PaintMode_Arrow != null)
                {
                    _Menu_PaintMode_Arrow.Click += Menu_PaintMode_Arrow_Click;
                }
            }
        }

        private Panel _Panel_Image;

        internal Panel Panel_Image
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel_Image;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel_Image != null)
                {
                }

                _Panel_Image = value;
                if (_Panel_Image != null)
                {
                }
            }
        }

        private Label _Resizer_Right;

        internal Label Resizer_Right
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Resizer_Right;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Resizer_Right != null)
                {
                    _Resizer_Right.MouseDown -= Resizers_MouseDown;
                    _Resizer_Right.MouseMove -= Resizer_Right_MouseMove;
                }

                _Resizer_Right = value;
                if (_Resizer_Right != null)
                {
                    _Resizer_Right.MouseDown += Resizers_MouseDown;
                    _Resizer_Right.MouseMove += Resizer_Right_MouseMove;
                }
            }
        }

        private Label _Resizer_Bottom;

        internal Label Resizer_Bottom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Resizer_Bottom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Resizer_Bottom != null)
                {
                    _Resizer_Bottom.MouseDown -= Resizers_MouseDown;
                    _Resizer_Bottom.MouseMove -= Resizer_Bottom_MouseMove;
                }

                _Resizer_Bottom = value;
                if (_Resizer_Bottom != null)
                {
                    _Resizer_Bottom.MouseDown += Resizers_MouseDown;
                    _Resizer_Bottom.MouseMove += Resizer_Bottom_MouseMove;
                }
            }
        }

        private Label _Resizer_Both;

        internal Label Resizer_Both
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Resizer_Both;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Resizer_Both != null)
                {
                    _Resizer_Both.MouseDown -= Resizers_MouseDown;
                    _Resizer_Both.MouseMove -= Resizer_Both_MouseMove;
                }

                _Resizer_Both = value;
                if (_Resizer_Both != null)
                {
                    _Resizer_Both.MouseDown += Resizers_MouseDown;
                    _Resizer_Both.MouseMove += Resizer_Both_MouseMove;
                }
            }
        }

        private ToolStripContainer _ToolStripContainer_Main;

        internal ToolStripContainer ToolStripContainer_Main
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripContainer_Main;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripContainer_Main != null)
                {
                }

                _ToolStripContainer_Main = value;
                if (_ToolStripContainer_Main != null)
                {
                }
            }
        }

        private ToolStripButton _Menu_ForNothing1;

        internal ToolStripButton Menu_ForNothing1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_ForNothing1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_ForNothing1 != null)
                {
                }

                _Menu_ForNothing1 = value;
                if (_Menu_ForNothing1 != null)
                {
                }
            }
        }

        private ToolStripButton _ToolStripButton1;

        internal ToolStripButton ToolStripButton1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButton1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButton1 != null)
                {
                }

                _ToolStripButton1 = value;
                if (_ToolStripButton1 != null)
                {
                }
            }
        }

        private ToolStrip _ToolStrip_Effects;

        internal ToolStrip ToolStrip_Effects
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStrip_Effects;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStrip_Effects != null)
                {
                }

                _ToolStrip_Effects = value;
                if (_ToolStrip_Effects != null)
                {
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Blur;

        internal ToolStripButton Menu_PaintMode_Blur
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Blur;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Blur != null)
                {
                    _Menu_PaintMode_Blur.Click -= Button_Effect_Blur_Click;
                }

                _Menu_PaintMode_Blur = value;
                if (_Menu_PaintMode_Blur != null)
                {
                    _Menu_PaintMode_Blur.Click += Button_Effect_Blur_Click;
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Invert;

        internal ToolStripButton Menu_PaintMode_Invert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Invert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Invert != null)
                {
                    _Menu_PaintMode_Invert.Click -= Button_Effect_Invert_Click;
                }

                _Menu_PaintMode_Invert = value;
                if (_Menu_PaintMode_Invert != null)
                {
                    _Menu_PaintMode_Invert.Click += Button_Effect_Invert_Click;
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Grayscale;

        internal ToolStripButton Menu_PaintMode_Grayscale
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Grayscale;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Grayscale != null)
                {
                    _Menu_PaintMode_Grayscale.Click -= Button_Effect_Grayscale_Click;
                }

                _Menu_PaintMode_Grayscale = value;
                if (_Menu_PaintMode_Grayscale != null)
                {
                    _Menu_PaintMode_Grayscale.Click += Button_Effect_Grayscale_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButton2;

        internal ToolStripButton ToolStripButton2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButton2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButton2 != null)
                {
                }

                _ToolStripButton2 = value;
                if (_ToolStripButton2 != null)
                {
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Highlight;

        internal ToolStripButton Menu_PaintMode_Highlight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Highlight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Highlight != null)
                {
                    _Menu_PaintMode_Highlight.Click -= Menu_PaintMode_Highlight_Click;
                }

                _Menu_PaintMode_Highlight = value;
                if (_Menu_PaintMode_Highlight != null)
                {
                    _Menu_PaintMode_Highlight.Click += Menu_PaintMode_Highlight_Click;
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Crop;

        internal ToolStripButton Menu_PaintMode_Crop
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Crop;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Crop != null)
                {
                    _Menu_PaintMode_Crop.Click -= Menu_PaintMode_Crop_Click;
                }

                _Menu_PaintMode_Crop = value;
                if (_Menu_PaintMode_Crop != null)
                {
                    _Menu_PaintMode_Crop.Click += Menu_PaintMode_Crop_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator4;

        internal ToolStripSeparator ToolStripSeparator4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator4 != null)
                {
                }

                _ToolStripSeparator4 = value;
                if (_ToolStripSeparator4 != null)
                {
                }
            }
        }

        private ToolStripButton _Button_Redo;

        internal ToolStripButton Button_Redo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Redo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Redo != null)
                {
                    _Button_Redo.Click -= Button_Redo_Click;
                }

                _Button_Redo = value;
                if (_Button_Redo != null)
                {
                    _Button_Redo.Click += Button_Redo_Click;
                }
            }
        }

        private ToolStripPalitra _ToolStrip_Standard_Palitra;

        internal ToolStripPalitra ToolStrip_Standard_Palitra
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStrip_Standard_Palitra;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStrip_Standard_Palitra != null)
                {
                    _ToolStrip_Standard_Palitra.ColorChanged -= ToolStrip_Standard_Palitra_ColorChanged;
                }

                _ToolStrip_Standard_Palitra = value;
                if (_ToolStrip_Standard_Palitra != null)
                {
                    _ToolStrip_Standard_Palitra.ColorChanged += ToolStrip_Standard_Palitra_ColorChanged;
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Puzzle;

        internal ToolStripButton Menu_PaintMode_Puzzle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Puzzle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Puzzle != null)
                {
                    _Menu_PaintMode_Puzzle.Click -= Menu_PaintMode_Puzzle_Click;
                }

                _Menu_PaintMode_Puzzle = value;
                if (_Menu_PaintMode_Puzzle != null)
                {
                    _Menu_PaintMode_Puzzle.Click += Menu_PaintMode_Puzzle_Click;
                }
            }
        }

        private ToolStripButton _Button_SaveCopy;

        internal ToolStripButton Button_SaveCopy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_SaveCopy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_SaveCopy != null)
                {
                    _Button_SaveCopy.Click -= Button_SaveCopy_Click;
                }

                _Button_SaveCopy = value;
                if (_Button_SaveCopy != null)
                {
                    _Button_SaveCopy.Click += Button_SaveCopy_Click;
                }
            }
        }

        private ToolStripButton _Button_SaveAs;

        internal ToolStripButton Button_SaveAs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_SaveAs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_SaveAs != null)
                {
                    _Button_SaveAs.Click -= Button_SaveAs_Click;
                }

                _Button_SaveAs = value;
                if (_Button_SaveAs != null)
                {
                    _Button_SaveAs.Click += Button_SaveAs_Click;
                }
            }
        }

        private ToolStripButton _Button_Save;

        internal ToolStripButton Button_Save
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Save;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Save != null)
                {
                    _Button_Save.Click -= Button_Save_Click;
                }

                _Button_Save = value;
                if (_Button_Save != null)
                {
                    _Button_Save.Click += Button_Save_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator6;

        internal ToolStripSeparator ToolStripSeparator6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator6 != null)
                {
                }

                _ToolStripSeparator6 = value;
                if (_ToolStripSeparator6 != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator7;

        internal ToolStripSeparator ToolStripSeparator7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator7 != null)
                {
                }

                _ToolStripSeparator7 = value;
                if (_ToolStripSeparator7 != null)
                {
                }
            }
        }

        private ContextMenuStrip _Menu_Numbers;

        internal ContextMenuStrip Menu_Numbers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Numbers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Numbers != null)
                {
                }

                _Menu_Numbers = value;
                if (_Menu_Numbers != null)
                {
                }
            }
        }

        private ToolStripMenuItem _IncrementToolStripMenuItem;

        internal ToolStripMenuItem IncrementToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _IncrementToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_IncrementToolStripMenuItem != null)
                {
                }

                _IncrementToolStripMenuItem = value;
                if (_IncrementToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _DecrementToolStripMenuItem;

        internal ToolStripMenuItem DecrementToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DecrementToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DecrementToolStripMenuItem != null)
                {
                }

                _DecrementToolStripMenuItem = value;
                if (_DecrementToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator10;

        internal ToolStripSeparator ToolStripSeparator10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator10 != null)
                {
                }

                _ToolStripSeparator10 = value;
                if (_ToolStripSeparator10 != null)
                {
                }
            }
        }

        private ToolStripButton _Menu_PaintMode_Numbers;

        internal ToolStripButton Menu_PaintMode_Numbers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_PaintMode_Numbers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_PaintMode_Numbers != null)
                {
                    _Menu_PaintMode_Numbers.Click -= Menu_PaintMode_Numbers_Click;
                }

                _Menu_PaintMode_Numbers = value;
                if (_Menu_PaintMode_Numbers != null)
                {
                    _Menu_PaintMode_Numbers.Click += Menu_PaintMode_Numbers_Click;
                }
            }
        }
    }
}
