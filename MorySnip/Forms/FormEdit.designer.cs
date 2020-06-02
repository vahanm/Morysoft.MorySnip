using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Morysoft.MorySnip
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FormEdit : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdit));
            this.Panel_Image = new System.Windows.Forms.Panel();
            this.Editor_Main = new Morysoft.MorySnip.Editor();
            this.Resizer_Both = new System.Windows.Forms.Label();
            this.Resizer_Bottom = new System.Windows.Forms.Label();
            this.Resizer_Right = new System.Windows.Forms.Label();
            this.Menu_Numbers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.IncrementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DecrementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_PaintMode_Numbers_Config = new System.Windows.Forms.ToolStripDropDownButton();
            this.Menu_PaintMode_Crop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_PaintMode_Free = new System.Windows.Forms.ToolStripButton();
            this.Menu_PaintMode_Line = new System.Windows.Forms.ToolStripButton();
            this.Menu_PaintMode_Arrow = new System.Windows.Forms.ToolStripButton();
            this.Menu_PaintMode_Oval = new System.Windows.Forms.ToolStripButton();
            this.Menu_PaintMode_Rect = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_PaintMode_Numbers = new System.Windows.Forms.ToolStripButton();
            this.Menu_PaintMode_Magnifier = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_PaintMode_Fill = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_PaintMode_Highlight = new System.Windows.Forms.ToolStripButton();
            this.Menu_PaintMode_Puzzle = new System.Windows.Forms.ToolStripButton();
            this.Menu_PaintMode_Blur = new System.Windows.Forms.ToolStripButton();
            this.Menu_PaintMode_Invert = new System.Windows.Forms.ToolStripButton();
            this.Menu_PaintMode_Grayscale = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip_Standard = new System.Windows.Forms.ToolStrip();
            this.Button_Save = new System.Windows.Forms.ToolStripButton();
            this.Button_SaveAs = new System.Windows.Forms.ToolStripButton();
            this.Button_SaveCopy = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.Button_Back = new System.Windows.Forms.ToolStripButton();
            this.Button_Redo = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStrip_Standard_Palitra = new Morysoft.MorySnip.ToolStripPalitra();
            this.Button_Color = new System.Windows.Forms.ToolStripDropDownButton();
            this.Menu_Pens = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Button_Size = new System.Windows.Forms.ToolStripDropDownButton();
            this.Menu_Size = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Button_Rotate_Left = new System.Windows.Forms.ToolStripButton();
            this.Button_Rotate_Right = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Button_Flip_X = new System.Windows.Forms.ToolStripButton();
            this.Button_Flip_Y = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.Button_Settings = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip_Draw = new System.Windows.Forms.ToolStrip();
            this.Menu_PaintMode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer_Update = new System.Windows.Forms.Timer(this.components);
            this.Panel_Image.SuspendLayout();
            this.Menu_Numbers.SuspendLayout();
            this.ToolStrip_Standard.SuspendLayout();
            this.Menu_Pens.SuspendLayout();
            this.Menu_Size.SuspendLayout();
            this.ToolStrip_Draw.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Image
            // 
            resources.ApplyResources(this.Panel_Image, "Panel_Image");
            this.Panel_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_Image.Controls.Add(this.Editor_Main);
            this.Panel_Image.Controls.Add(this.Resizer_Both);
            this.Panel_Image.Controls.Add(this.Resizer_Bottom);
            this.Panel_Image.Controls.Add(this.Resizer_Right);
            this.Panel_Image.Name = "Panel_Image";
            // 
            // Editor_Main
            // 
            this.Editor_Main.FillObjecs = false;
            this.Editor_Main.LastNumber = 1;
            resources.ApplyResources(this.Editor_Main, "Editor_Main");
            this.Editor_Main.Name = "Editor_Main";
            this.Editor_Main.PaintMode = Morysoft.MorySnip.Editor.EditorPaintMode.Rect;
            this.Editor_Main.LastNumberChanged += new Morysoft.MorySnip.Editor.LastNumberChangedEventHandler(this.Editor_Main_LastNumberChanged);
            // 
            // Resizer_Both
            // 
            this.Resizer_Both.BackColor = System.Drawing.Color.White;
            this.Resizer_Both.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Resizer_Both.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            resources.ApplyResources(this.Resizer_Both, "Resizer_Both");
            this.Resizer_Both.Name = "Resizer_Both";
            this.Resizer_Both.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.Resizer_Both.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Both_MouseMove);
            // 
            // Resizer_Bottom
            // 
            this.Resizer_Bottom.BackColor = System.Drawing.Color.White;
            this.Resizer_Bottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Resizer_Bottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            resources.ApplyResources(this.Resizer_Bottom, "Resizer_Bottom");
            this.Resizer_Bottom.Name = "Resizer_Bottom";
            this.Resizer_Bottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.Resizer_Bottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Bottom_MouseMove);
            // 
            // Resizer_Right
            // 
            this.Resizer_Right.BackColor = System.Drawing.Color.White;
            this.Resizer_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Resizer_Right.Cursor = System.Windows.Forms.Cursors.SizeWE;
            resources.ApplyResources(this.Resizer_Right, "Resizer_Right");
            this.Resizer_Right.Name = "Resizer_Right";
            this.Resizer_Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.Resizer_Right.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resizer_Right_MouseMove);
            // 
            // Menu_Numbers
            // 
            this.Menu_Numbers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IncrementToolStripMenuItem,
            this.DecrementToolStripMenuItem,
            this.ToolStripSeparator10});
            this.Menu_Numbers.Name = "Menu_Numbers";
            this.Menu_Numbers.OwnerItem = this.Menu_PaintMode_Numbers_Config;
            resources.ApplyResources(this.Menu_Numbers, "Menu_Numbers");
            // 
            // IncrementToolStripMenuItem
            // 
            this.IncrementToolStripMenuItem.Checked = true;
            this.IncrementToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncrementToolStripMenuItem.Name = "IncrementToolStripMenuItem";
            resources.ApplyResources(this.IncrementToolStripMenuItem, "IncrementToolStripMenuItem");
            // 
            // DecrementToolStripMenuItem
            // 
            resources.ApplyResources(this.DecrementToolStripMenuItem, "DecrementToolStripMenuItem");
            this.DecrementToolStripMenuItem.Name = "DecrementToolStripMenuItem";
            // 
            // ToolStripSeparator10
            // 
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";
            resources.ApplyResources(this.ToolStripSeparator10, "ToolStripSeparator10");
            // 
            // Menu_PaintMode_Numbers_Config
            // 
            this.Menu_PaintMode_Numbers_Config.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.Menu_PaintMode_Numbers_Config.DropDown = this.Menu_Numbers;
            resources.ApplyResources(this.Menu_PaintMode_Numbers_Config, "Menu_PaintMode_Numbers_Config");
            this.Menu_PaintMode_Numbers_Config.Name = "Menu_PaintMode_Numbers_Config";
            // 
            // Menu_PaintMode_Crop
            // 
            this.Menu_PaintMode_Crop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Crop.Image = global::Morysoft.MorySnip.Properties.Resources.feather_crop;
            resources.ApplyResources(this.Menu_PaintMode_Crop, "Menu_PaintMode_Crop");
            this.Menu_PaintMode_Crop.Name = "Menu_PaintMode_Crop";
            this.Menu_PaintMode_Crop.Click += new System.EventHandler(this.Menu_PaintMode_Crop_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // Menu_PaintMode_Free
            // 
            this.Menu_PaintMode_Free.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Free.Image = global::Morysoft.MorySnip.Properties.Resources.feather_cloud_snow_32;
            this.Menu_PaintMode_Free.Name = "Menu_PaintMode_Free";
            resources.ApplyResources(this.Menu_PaintMode_Free, "Menu_PaintMode_Free");
            this.Menu_PaintMode_Free.Click += new System.EventHandler(this.Menu_PaintMode_Free_Click);
            // 
            // Menu_PaintMode_Line
            // 
            this.Menu_PaintMode_Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Line.Image = global::Morysoft.MorySnip.Properties.Resources.feather_line_up_right_32;
            resources.ApplyResources(this.Menu_PaintMode_Line, "Menu_PaintMode_Line");
            this.Menu_PaintMode_Line.Name = "Menu_PaintMode_Line";
            this.Menu_PaintMode_Line.Click += new System.EventHandler(this.Menu_PaintMode_Line_Click);
            // 
            // Menu_PaintMode_Arrow
            // 
            this.Menu_PaintMode_Arrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Arrow.Image = global::Morysoft.MorySnip.Properties.Resources.feather_arrow_up_right_32;
            resources.ApplyResources(this.Menu_PaintMode_Arrow, "Menu_PaintMode_Arrow");
            this.Menu_PaintMode_Arrow.Name = "Menu_PaintMode_Arrow";
            this.Menu_PaintMode_Arrow.Click += new System.EventHandler(this.Menu_PaintMode_Arrow_Click);
            // 
            // Menu_PaintMode_Oval
            // 
            this.Menu_PaintMode_Oval.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Oval.Image = global::Morysoft.MorySnip.Properties.Resources.feather_circle_32;
            this.Menu_PaintMode_Oval.Name = "Menu_PaintMode_Oval";
            resources.ApplyResources(this.Menu_PaintMode_Oval, "Menu_PaintMode_Oval");
            this.Menu_PaintMode_Oval.Click += new System.EventHandler(this.Menu_PaintMode_Oval_Click);
            // 
            // Menu_PaintMode_Rect
            // 
            this.Menu_PaintMode_Rect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Rect.Image = global::Morysoft.MorySnip.Properties.Resources.feather_square_32;
            resources.ApplyResources(this.Menu_PaintMode_Rect, "Menu_PaintMode_Rect");
            this.Menu_PaintMode_Rect.Name = "Menu_PaintMode_Rect";
            this.Menu_PaintMode_Rect.Click += new System.EventHandler(this.Menu_PaintMode_Rect_Click);
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            resources.ApplyResources(this.ToolStripSeparator7, "ToolStripSeparator7");
            // 
            // Menu_PaintMode_Numbers
            // 
            this.Menu_PaintMode_Numbers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Numbers.Image = global::Morysoft.MorySnip.Properties.Resources.feather_slack_32;
            resources.ApplyResources(this.Menu_PaintMode_Numbers, "Menu_PaintMode_Numbers");
            this.Menu_PaintMode_Numbers.Name = "Menu_PaintMode_Numbers";
            this.Menu_PaintMode_Numbers.Click += new System.EventHandler(this.Menu_PaintMode_Numbers_Click);
            // 
            // Menu_PaintMode_Magnifier
            // 
            this.Menu_PaintMode_Magnifier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Magnifier.Image = global::Morysoft.MorySnip.Properties.Resources.feather_zoom_in_32;
            resources.ApplyResources(this.Menu_PaintMode_Magnifier, "Menu_PaintMode_Magnifier");
            this.Menu_PaintMode_Magnifier.Name = "Menu_PaintMode_Magnifier";
            this.Menu_PaintMode_Magnifier.Click += new System.EventHandler(this.Menu_PaintMode_Magnifier_Click);
            // 
            // ToolStripSeparator9
            // 
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";
            resources.ApplyResources(this.ToolStripSeparator9, "ToolStripSeparator9");
            // 
            // Menu_PaintMode_Fill
            // 
            this.Menu_PaintMode_Fill.CheckOnClick = true;
            this.Menu_PaintMode_Fill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Fill.Image = global::Morysoft.MorySnip.Properties.Resources.feather_droplet_32;
            resources.ApplyResources(this.Menu_PaintMode_Fill, "Menu_PaintMode_Fill");
            this.Menu_PaintMode_Fill.Name = "Menu_PaintMode_Fill";
            this.Menu_PaintMode_Fill.Click += new System.EventHandler(this.Menu_PaintMode_Fill_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            resources.ApplyResources(this.ToolStripSeparator4, "ToolStripSeparator4");
            // 
            // Menu_PaintMode_Highlight
            // 
            this.Menu_PaintMode_Highlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Highlight.Image = global::Morysoft.MorySnip.Properties.Resources.feather_highlighter_32;
            resources.ApplyResources(this.Menu_PaintMode_Highlight, "Menu_PaintMode_Highlight");
            this.Menu_PaintMode_Highlight.Name = "Menu_PaintMode_Highlight";
            this.Menu_PaintMode_Highlight.Click += new System.EventHandler(this.Menu_PaintMode_Highlight_Click);
            // 
            // Menu_PaintMode_Puzzle
            // 
            this.Menu_PaintMode_Puzzle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Puzzle.Image = global::Morysoft.MorySnip.Properties.Resources.feather_grid_32;
            resources.ApplyResources(this.Menu_PaintMode_Puzzle, "Menu_PaintMode_Puzzle");
            this.Menu_PaintMode_Puzzle.Name = "Menu_PaintMode_Puzzle";
            this.Menu_PaintMode_Puzzle.Click += new System.EventHandler(this.Menu_PaintMode_Puzzle_Click);
            // 
            // Menu_PaintMode_Blur
            // 
            this.Menu_PaintMode_Blur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Blur.Image = global::Morysoft.MorySnip.Properties.Resources.feather_aperture_32;
            resources.ApplyResources(this.Menu_PaintMode_Blur, "Menu_PaintMode_Blur");
            this.Menu_PaintMode_Blur.Name = "Menu_PaintMode_Blur";
            this.Menu_PaintMode_Blur.Click += new System.EventHandler(this.Menu_PaintMode_Blur_Click);
            // 
            // Menu_PaintMode_Invert
            // 
            this.Menu_PaintMode_Invert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Invert.Image = global::Morysoft.MorySnip.Properties.Resources.feather_negative_32;
            resources.ApplyResources(this.Menu_PaintMode_Invert, "Menu_PaintMode_Invert");
            this.Menu_PaintMode_Invert.Name = "Menu_PaintMode_Invert";
            this.Menu_PaintMode_Invert.Click += new System.EventHandler(this.Menu_PaintMode_Invert_Click);
            // 
            // Menu_PaintMode_Grayscale
            // 
            this.Menu_PaintMode_Grayscale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu_PaintMode_Grayscale.Image = global::Morysoft.MorySnip.Properties.Resources.feather_grayscale_32;
            resources.ApplyResources(this.Menu_PaintMode_Grayscale, "Menu_PaintMode_Grayscale");
            this.Menu_PaintMode_Grayscale.Name = "Menu_PaintMode_Grayscale";
            this.Menu_PaintMode_Grayscale.Click += new System.EventHandler(this.Menu_PaintMode_Grayscale_Click);
            // 
            // ToolStrip_Standard
            // 
            this.ToolStrip_Standard.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip_Standard.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip_Standard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button_Save,
            this.Button_SaveAs,
            this.Button_SaveCopy,
            this.ToolStripSeparator6,
            this.Button_Back,
            this.Button_Redo,
            this.ToolStripSeparator8,
            this.ToolStrip_Standard_Palitra,
            this.Button_Color,
            this.Button_Size,
            this.ToolStripSeparator3,
            this.Button_Rotate_Left,
            this.Button_Rotate_Right,
            this.ToolStripSeparator5,
            this.Button_Flip_X,
            this.Button_Flip_Y,
            this.toolStripSeparator12,
            this.Button_Settings});
            resources.ApplyResources(this.ToolStrip_Standard, "ToolStrip_Standard");
            this.ToolStrip_Standard.Name = "ToolStrip_Standard";
            // 
            // Button_Save
            // 
            this.Button_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Save.Image = global::Morysoft.MorySnip.Properties.Resources.feather_save;
            resources.ApplyResources(this.Button_Save, "Button_Save");
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_SaveAs
            // 
            this.Button_SaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_SaveAs.Image = global::Morysoft.MorySnip.Properties.Resources.feather_external_link;
            resources.ApplyResources(this.Button_SaveAs, "Button_SaveAs");
            this.Button_SaveAs.Name = "Button_SaveAs";
            this.Button_SaveAs.Click += new System.EventHandler(this.Button_SaveAs_Click);
            // 
            // Button_SaveCopy
            // 
            this.Button_SaveCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_SaveCopy.Image = global::Morysoft.MorySnip.Properties.Resources.feather_copy;
            resources.ApplyResources(this.Button_SaveCopy, "Button_SaveCopy");
            this.Button_SaveCopy.Name = "Button_SaveCopy";
            this.Button_SaveCopy.Click += new System.EventHandler(this.Button_SaveCopy_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            resources.ApplyResources(this.ToolStripSeparator6, "ToolStripSeparator6");
            // 
            // Button_Back
            // 
            this.Button_Back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Back.Image = global::Morysoft.MorySnip.Properties.Resources.feather_chevrons_left;
            resources.ApplyResources(this.Button_Back, "Button_Back");
            this.Button_Back.Name = "Button_Back";
            this.Button_Back.Click += new System.EventHandler(this.Button_Back_Click);
            // 
            // Button_Redo
            // 
            this.Button_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Redo.Image = global::Morysoft.MorySnip.Properties.Resources.feather_chevrons_right;
            resources.ApplyResources(this.Button_Redo, "Button_Redo");
            this.Button_Redo.Name = "Button_Redo";
            this.Button_Redo.Click += new System.EventHandler(this.Button_Redo_Click);
            // 
            // ToolStripSeparator8
            // 
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            resources.ApplyResources(this.ToolStripSeparator8, "ToolStripSeparator8");
            // 
            // ToolStrip_Standard_Palitra
            // 
            resources.ApplyResources(this.ToolStrip_Standard_Palitra, "ToolStrip_Standard_Palitra");
            this.ToolStrip_Standard_Palitra.Name = "ToolStrip_Standard_Palitra";
            this.ToolStrip_Standard_Palitra.ColorChanged += new Morysoft.MorySnip.ToolStripPalitra.ColorChangedEventHandler(this.ToolStrip_Standard_Palitra_ColorChanged);
            // 
            // Button_Color
            // 
            this.Button_Color.DropDown = this.Menu_Pens;
            this.Button_Color.Image = global::Morysoft.MorySnip.Properties.Resources.feather_edit_3;
            resources.ApplyResources(this.Button_Color, "Button_Color");
            this.Button_Color.Name = "Button_Color";
            // 
            // Menu_Pens
            // 
            this.Menu_Pens.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RedToolStripMenuItem,
            this.BlueToolStripMenuItem,
            this.BlackToolStripMenuItem,
            this.WhiteToolStripMenuItem,
            this.ToolStripSeparator1,
            this.CustomToolStripMenuItem});
            this.Menu_Pens.Name = "Menu_Pens";
            this.Menu_Pens.OwnerItem = this.Button_Color;
            resources.ApplyResources(this.Menu_Pens, "Menu_Pens");
            // 
            // RedToolStripMenuItem
            // 
            this.RedToolStripMenuItem.Name = "RedToolStripMenuItem";
            resources.ApplyResources(this.RedToolStripMenuItem, "RedToolStripMenuItem");
            this.RedToolStripMenuItem.Click += new System.EventHandler(this.RedToolStripMenuItem_Click);
            // 
            // BlueToolStripMenuItem
            // 
            this.BlueToolStripMenuItem.Name = "BlueToolStripMenuItem";
            resources.ApplyResources(this.BlueToolStripMenuItem, "BlueToolStripMenuItem");
            this.BlueToolStripMenuItem.Click += new System.EventHandler(this.BlueToolStripMenuItem_Click);
            // 
            // BlackToolStripMenuItem
            // 
            this.BlackToolStripMenuItem.Name = "BlackToolStripMenuItem";
            resources.ApplyResources(this.BlackToolStripMenuItem, "BlackToolStripMenuItem");
            this.BlackToolStripMenuItem.Click += new System.EventHandler(this.BlackToolStripMenuItem_Click);
            // 
            // WhiteToolStripMenuItem
            // 
            this.WhiteToolStripMenuItem.Name = "WhiteToolStripMenuItem";
            resources.ApplyResources(this.WhiteToolStripMenuItem, "WhiteToolStripMenuItem");
            this.WhiteToolStripMenuItem.Click += new System.EventHandler(this.WhiteToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            resources.ApplyResources(this.ToolStripSeparator1, "ToolStripSeparator1");
            // 
            // CustomToolStripMenuItem
            // 
            this.CustomToolStripMenuItem.Name = "CustomToolStripMenuItem";
            resources.ApplyResources(this.CustomToolStripMenuItem, "CustomToolStripMenuItem");
            this.CustomToolStripMenuItem.Click += new System.EventHandler(this.CustomToolStripMenuItem_Click);
            // 
            // Button_Size
            // 
            this.Button_Size.DropDown = this.Menu_Size;
            this.Button_Size.Image = global::Morysoft.MorySnip.Properties.Resources.feather_minus;
            resources.ApplyResources(this.Button_Size, "Button_Size");
            this.Button_Size.Name = "Button_Size";
            // 
            // Menu_Size
            // 
            this.Menu_Size.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem7,
            this.ToolStripMenuItem8,
            this.ToolStripMenuItem9,
            this.ToolStripMenuItem10,
            this.ToolStripMenuItem11,
            this.ToolStripMenuItem12,
            this.ToolStripMenuItem13,
            this.ToolStripMenuItem14,
            this.ToolStripMenuItem15,
            this.ToolStripMenuItem16,
            this.ToolStripMenuItem17,
            this.ToolStripMenuItem18});
            this.Menu_Size.Name = "Menu_Size";
            this.Menu_Size.OwnerItem = this.Button_Size;
            resources.ApplyResources(this.Menu_Size, "Menu_Size");
            this.Menu_Size.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_Size_ItemClicked);
            // 
            // ToolStripMenuItem7
            // 
            this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
            resources.ApplyResources(this.ToolStripMenuItem7, "ToolStripMenuItem7");
            // 
            // ToolStripMenuItem8
            // 
            this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
            resources.ApplyResources(this.ToolStripMenuItem8, "ToolStripMenuItem8");
            // 
            // ToolStripMenuItem9
            // 
            this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
            resources.ApplyResources(this.ToolStripMenuItem9, "ToolStripMenuItem9");
            // 
            // ToolStripMenuItem10
            // 
            this.ToolStripMenuItem10.Name = "ToolStripMenuItem10";
            resources.ApplyResources(this.ToolStripMenuItem10, "ToolStripMenuItem10");
            // 
            // ToolStripMenuItem11
            // 
            this.ToolStripMenuItem11.Name = "ToolStripMenuItem11";
            resources.ApplyResources(this.ToolStripMenuItem11, "ToolStripMenuItem11");
            // 
            // ToolStripMenuItem12
            // 
            this.ToolStripMenuItem12.Name = "ToolStripMenuItem12";
            resources.ApplyResources(this.ToolStripMenuItem12, "ToolStripMenuItem12");
            // 
            // ToolStripMenuItem13
            // 
            this.ToolStripMenuItem13.Name = "ToolStripMenuItem13";
            resources.ApplyResources(this.ToolStripMenuItem13, "ToolStripMenuItem13");
            // 
            // ToolStripMenuItem14
            // 
            this.ToolStripMenuItem14.Name = "ToolStripMenuItem14";
            resources.ApplyResources(this.ToolStripMenuItem14, "ToolStripMenuItem14");
            // 
            // ToolStripMenuItem15
            // 
            this.ToolStripMenuItem15.Name = "ToolStripMenuItem15";
            resources.ApplyResources(this.ToolStripMenuItem15, "ToolStripMenuItem15");
            // 
            // ToolStripMenuItem16
            // 
            this.ToolStripMenuItem16.Name = "ToolStripMenuItem16";
            resources.ApplyResources(this.ToolStripMenuItem16, "ToolStripMenuItem16");
            // 
            // ToolStripMenuItem17
            // 
            this.ToolStripMenuItem17.Name = "ToolStripMenuItem17";
            resources.ApplyResources(this.ToolStripMenuItem17, "ToolStripMenuItem17");
            // 
            // ToolStripMenuItem18
            // 
            this.ToolStripMenuItem18.Name = "ToolStripMenuItem18";
            resources.ApplyResources(this.ToolStripMenuItem18, "ToolStripMenuItem18");
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            resources.ApplyResources(this.ToolStripSeparator3, "ToolStripSeparator3");
            // 
            // Button_Rotate_Left
            // 
            this.Button_Rotate_Left.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Rotate_Left.Image = global::Morysoft.MorySnip.Properties.Resources.feather_rotate_ccw_32;
            resources.ApplyResources(this.Button_Rotate_Left, "Button_Rotate_Left");
            this.Button_Rotate_Left.Name = "Button_Rotate_Left";
            this.Button_Rotate_Left.Click += new System.EventHandler(this.Button_Rotate_Left_Click);
            // 
            // Button_Rotate_Right
            // 
            this.Button_Rotate_Right.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Rotate_Right.Image = global::Morysoft.MorySnip.Properties.Resources.feather_rotate_cw_32;
            resources.ApplyResources(this.Button_Rotate_Right, "Button_Rotate_Right");
            this.Button_Rotate_Right.Name = "Button_Rotate_Right";
            this.Button_Rotate_Right.Click += new System.EventHandler(this.Button_Rotate_Right_Click);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            resources.ApplyResources(this.ToolStripSeparator5, "ToolStripSeparator5");
            // 
            // Button_Flip_X
            // 
            this.Button_Flip_X.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Flip_X.Image = global::Morysoft.MorySnip.Properties.Resources.feather_corner_up_left_32;
            resources.ApplyResources(this.Button_Flip_X, "Button_Flip_X");
            this.Button_Flip_X.Name = "Button_Flip_X";
            this.Button_Flip_X.Click += new System.EventHandler(this.Button_Flip_X_Click);
            // 
            // Button_Flip_Y
            // 
            this.Button_Flip_Y.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Flip_Y.Image = global::Morysoft.MorySnip.Properties.Resources.feather_corner_left_down_32;
            resources.ApplyResources(this.Button_Flip_Y, "Button_Flip_Y");
            this.Button_Flip_Y.Name = "Button_Flip_Y";
            this.Button_Flip_Y.Click += new System.EventHandler(this.Button_Flip_Y_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // Button_Settings
            // 
            this.Button_Settings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Button_Settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Settings.Image = global::Morysoft.MorySnip.Properties.Resources.feather_settings_32;
            resources.ApplyResources(this.Button_Settings, "Button_Settings");
            this.Button_Settings.Name = "Button_Settings";
            this.Button_Settings.Click += new System.EventHandler(this.Button_Settings_Click);
            // 
            // ToolStrip_Draw
            // 
            this.ToolStrip_Draw.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip_Draw.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip_Draw.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_PaintMode_Crop,
            this.toolStripSeparator11,
            this.Menu_PaintMode_Free,
            this.Menu_PaintMode_Line,
            this.Menu_PaintMode_Arrow,
            this.Menu_PaintMode_Oval,
            this.Menu_PaintMode_Rect,
            this.ToolStripSeparator7,
            this.Menu_PaintMode_Numbers,
            this.Menu_PaintMode_Numbers_Config,
            this.Menu_PaintMode_Magnifier,
            this.ToolStripSeparator9,
            this.Menu_PaintMode_Fill,
            this.ToolStripSeparator4,
            this.Menu_PaintMode_Highlight,
            this.Menu_PaintMode_Puzzle,
            this.Menu_PaintMode_Blur,
            this.Menu_PaintMode_Invert,
            this.Menu_PaintMode_Grayscale});
            resources.ApplyResources(this.ToolStrip_Draw, "ToolStrip_Draw");
            this.ToolStrip_Draw.Name = "ToolStrip_Draw";
            // 
            // Menu_PaintMode
            // 
            this.Menu_PaintMode.Name = "Menu_PaintMode";
            resources.ApplyResources(this.Menu_PaintMode, "Menu_PaintMode");
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            resources.ApplyResources(this.ToolStripMenuItem1, "ToolStripMenuItem1");
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            resources.ApplyResources(this.ToolStripMenuItem2, "ToolStripMenuItem2");
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            resources.ApplyResources(this.ToolStripMenuItem3, "ToolStripMenuItem3");
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            resources.ApplyResources(this.ToolStripMenuItem4, "ToolStripMenuItem4");
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            resources.ApplyResources(this.ToolStripSeparator2, "ToolStripSeparator2");
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            resources.ApplyResources(this.ToolStripMenuItem5, "ToolStripMenuItem5");
            // 
            // Timer_Update
            // 
            this.Timer_Update.Enabled = true;
            this.Timer_Update.Tick += new System.EventHandler(this.Timer_Update_Tick);
            // 
            // FormEdit
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel_Image);
            this.Controls.Add(this.ToolStrip_Draw);
            this.Controls.Add(this.ToolStrip_Standard);
            this.Name = "FormEdit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Edit_Load);
            this.BackgroundImageChanged += new System.EventHandler(this.Form_Edit_BackgroundImageChanged);
            this.Panel_Image.ResumeLayout(false);
            this.Menu_Numbers.ResumeLayout(false);
            this.ToolStrip_Standard.ResumeLayout(false);
            this.ToolStrip_Standard.PerformLayout();
            this.Menu_Pens.ResumeLayout(false);
            this.Menu_Size.ResumeLayout(false);
            this.ToolStrip_Draw.ResumeLayout(false);
            this.ToolStrip_Draw.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Editor Editor_Main;

        private ToolStrip ToolStrip_Standard;

        private ToolStripButton Button_Back;

        private ContextMenuStrip Menu_Pens;

        private ToolStripMenuItem BlackToolStripMenuItem;

        private ToolStripMenuItem WhiteToolStripMenuItem;

        private ToolStripSeparator ToolStripSeparator1;

        private ToolStripMenuItem CustomToolStripMenuItem;

        private ToolStripDropDownButton Button_Color;

        private ToolStripMenuItem ToolStripMenuItem1;

        private ToolStripMenuItem ToolStripMenuItem2;

        private ToolStripMenuItem ToolStripMenuItem3;

        private ToolStripMenuItem ToolStripMenuItem4;

        private ToolStripSeparator ToolStripSeparator2;

        private ToolStripMenuItem ToolStripMenuItem5;

        private ToolStripDropDownButton Button_Size;

        private ContextMenuStrip Menu_Size;

        private ToolStripMenuItem ToolStripMenuItem7;

        private ToolStripMenuItem ToolStripMenuItem8;

        private ToolStripMenuItem ToolStripMenuItem9;

        private ToolStripMenuItem ToolStripMenuItem10;

        private ToolStripMenuItem ToolStripMenuItem11;

        private ToolStripMenuItem ToolStripMenuItem12;

        private ToolStripMenuItem ToolStripMenuItem13;

        private ToolStripMenuItem ToolStripMenuItem14;

        private ToolStripMenuItem ToolStripMenuItem15;

        private ToolStripMenuItem ToolStripMenuItem16;

        private ToolStripMenuItem ToolStripMenuItem17;

        private ToolStripMenuItem ToolStripMenuItem18;

        private Timer Timer_Update;

        private ToolStripButton Button_Rotate_Left;

        private ToolStripButton Button_Rotate_Right;

        private ToolStripButton Button_Flip_X;

        private ToolStripButton Button_Flip_Y;

        private ToolStripSeparator ToolStripSeparator3;

        private ToolStripSeparator ToolStripSeparator5;

        private ToolStripSeparator ToolStripSeparator8;

        private ContextMenuStrip Menu_PaintMode;

        private ToolStrip ToolStrip_Draw;

        private ToolStripMenuItem RedToolStripMenuItem;

        private ToolStripMenuItem BlueToolStripMenuItem;

        private ToolStripButton Menu_PaintMode_Free;

        private ToolStripSeparator ToolStripSeparator9;

        private ToolStripButton Menu_PaintMode_Line;

        private ToolStripButton Menu_PaintMode_Oval;

        private ToolStripButton Menu_PaintMode_Rect;

        private ToolStripButton Menu_PaintMode_Fill;

        private ToolStripButton Menu_PaintMode_Arrow;

        private Panel Panel_Image;

        private Label Resizer_Right;

        private Label Resizer_Bottom;

        private Label Resizer_Both;

        private ToolStripButton Menu_PaintMode_Blur;

        private ToolStripButton Menu_PaintMode_Invert;

        private ToolStripButton Menu_PaintMode_Grayscale;

        private ToolStripButton Menu_PaintMode_Highlight;

        private ToolStripButton Menu_PaintMode_Crop;

        private ToolStripSeparator ToolStripSeparator4;

        private ToolStripButton Button_Redo;

        private ToolStripPalitra ToolStrip_Standard_Palitra;

        private ToolStripButton Menu_PaintMode_Puzzle;

        private ToolStripButton Button_SaveCopy;

        private ToolStripButton Button_SaveAs;

        private ToolStripButton Button_Save;

        private ToolStripSeparator ToolStripSeparator6;

        private ToolStripSeparator ToolStripSeparator7;

        private ContextMenuStrip Menu_Numbers;

        private ToolStripMenuItem IncrementToolStripMenuItem;

        private ToolStripMenuItem DecrementToolStripMenuItem;

        private ToolStripSeparator ToolStripSeparator10;

        private ToolStripButton Menu_PaintMode_Numbers;
        private ToolStripButton Menu_PaintMode_Magnifier;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripDropDownButton Menu_PaintMode_Numbers_Config;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton Button_Settings;
    }
}
