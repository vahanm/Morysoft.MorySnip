using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Morysoft.MorySnip
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FormSnippingTool : Form
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
        //[DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSnippingTool));
            Menu_Snip = new ContextMenuStrip(this.components);
            Menu_Snip_FromClipboard = new ToolStripMenuItem();
            Menu_Snip_FromFile = new ToolStripMenuItem();
            Menu_Snip_FullScreen = new ToolStripMenuItem();
            ToolStripSeparator1 = new ToolStripSeparator();
            Menu_Snip_Settings = new ToolStripMenuItem();
            ToolStripSeparator2 = new ToolStripSeparator();
            Menu_Snip_Exit = new ToolStripMenuItem();
            Menu_Snip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu_Snip
            // 
            Menu_Snip.ImageScalingSize = new Size(32, 32);
            Menu_Snip.Items.AddRange(new ToolStripItem[] { Menu_Snip_FromClipboard, Menu_Snip_FromFile, Menu_Snip_FullScreen, ToolStripSeparator1, Menu_Snip_Settings, ToolStripSeparator2, Menu_Snip_Exit });
            Menu_Snip.Name = "Menu_Snip";
            resources.ApplyResources(Menu_Snip, "Menu_Snip");
            // 
            // Menu_Snip_FromClipboard
            // 
            Menu_Snip_FromClipboard.Image = Properties.Resources.feather_copy;
            Menu_Snip_FromClipboard.Name = "Menu_Snip_FromClipboard";
            resources.ApplyResources(Menu_Snip_FromClipboard, "Menu_Snip_FromClipboard");
            Menu_Snip_FromClipboard.Click += this.Menu_Snip_FromClipboard_Click;
            // 
            // Menu_Snip_FromFile
            // 
            Menu_Snip_FromFile.Image = Properties.Resources.feather_file_text;
            Menu_Snip_FromFile.Name = "Menu_Snip_FromFile";
            resources.ApplyResources(Menu_Snip_FromFile, "Menu_Snip_FromFile");
            Menu_Snip_FromFile.Click += this.Menu_Snip_FromFile_Click;
            // 
            // Menu_Snip_FullScreen
            // 
            Menu_Snip_FullScreen.Image = Properties.Resources.feather_monitor;
            Menu_Snip_FullScreen.Name = "Menu_Snip_FullScreen";
            resources.ApplyResources(Menu_Snip_FullScreen, "Menu_Snip_FullScreen");
            Menu_Snip_FullScreen.Click += this.Menu_Snip_FullScreen_Click;
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            resources.ApplyResources(ToolStripSeparator1, "ToolStripSeparator1");
            // 
            // Menu_Snip_Settings
            // 
            Menu_Snip_Settings.Image = Properties.Resources.feather_settings_32;
            Menu_Snip_Settings.Name = "Menu_Snip_Settings";
            resources.ApplyResources(Menu_Snip_Settings, "Menu_Snip_Settings");
            Menu_Snip_Settings.Click += this.Menu_Snip_Settings_Click;
            // 
            // ToolStripSeparator2
            // 
            ToolStripSeparator2.Name = "ToolStripSeparator2";
            resources.ApplyResources(ToolStripSeparator2, "ToolStripSeparator2");
            // 
            // Menu_Snip_Exit
            // 
            Menu_Snip_Exit.Image = Properties.Resources.feather_x;
            Menu_Snip_Exit.Name = "Menu_Snip_Exit";
            resources.ApplyResources(Menu_Snip_Exit, "Menu_Snip_Exit");
            Menu_Snip_Exit.Click += this.Menu_Snip_Exit_Click;
            // 
            // FormSnippingTool
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.Cursor = Cursors.Cross;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "FormSnippingTool";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TransparencyKey = Color.Magenta;
            this.Load += this.Form_SnippingTool_Load;
            this.KeyDown += this.Form_SnippingTool_KeyDown;
            this.KeyUp += this.Form_SnippingTool_KeyUp;
            this.MouseDown += this.Form_SnippingTool_MouseDown;
            this.MouseMove += this.Form_SnippingTool_MouseMove;
            this.MouseUp += this.Form_SnippingTool_MouseUp;
            Menu_Snip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private ContextMenuStrip Menu_Snip;

        private ToolStripMenuItem Menu_Snip_FullScreen;

        private ToolStripSeparator ToolStripSeparator1;

        private ToolStripMenuItem Menu_Snip_Exit;

        private ToolStripMenuItem Menu_Snip_FromClipboard;

        private ToolStripMenuItem Menu_Snip_FromFile;
        private ToolStripMenuItem Menu_Snip_Settings;
        private ToolStripSeparator ToolStripSeparator2;
    }
}
