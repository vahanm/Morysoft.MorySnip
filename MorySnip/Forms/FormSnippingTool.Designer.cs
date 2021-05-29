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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSnippingTool));
            this.Menu_Snip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_Snip_FromClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Snip_FromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Snip_FullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Snip_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Snip_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Snip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu_Snip
            // 
            this.Menu_Snip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Menu_Snip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Snip_FromClipboard,
            this.Menu_Snip_FromFile,
            this.Menu_Snip_FullScreen,
            this.ToolStripSeparator1,
            this.Menu_Snip_Settings,
            this.ToolStripSeparator2,
            this.Menu_Snip_Exit});
            this.Menu_Snip.Name = "Menu_Snip";
            resources.ApplyResources(this.Menu_Snip, "Menu_Snip");
            // 
            // Menu_Snip_FromClipboard
            // 
            this.Menu_Snip_FromClipboard.Image = global::Morysoft.MorySnip.Properties.Resources.feather_copy;
            this.Menu_Snip_FromClipboard.Name = "Menu_Snip_FromClipboard";
            resources.ApplyResources(this.Menu_Snip_FromClipboard, "Menu_Snip_FromClipboard");
            this.Menu_Snip_FromClipboard.Click += new System.EventHandler(this.Menu_Snip_FromClipboard_Click);
            // 
            // Menu_Snip_FromFile
            // 
            this.Menu_Snip_FromFile.Image = global::Morysoft.MorySnip.Properties.Resources.feather_file_text;
            this.Menu_Snip_FromFile.Name = "Menu_Snip_FromFile";
            resources.ApplyResources(this.Menu_Snip_FromFile, "Menu_Snip_FromFile");
            this.Menu_Snip_FromFile.Click += new System.EventHandler(this.Menu_Snip_FromFile_Click);
            // 
            // Menu_Snip_FullScreen
            // 
            this.Menu_Snip_FullScreen.Image = global::Morysoft.MorySnip.Properties.Resources.feather_monitor;
            this.Menu_Snip_FullScreen.Name = "Menu_Snip_FullScreen";
            resources.ApplyResources(this.Menu_Snip_FullScreen, "Menu_Snip_FullScreen");
            this.Menu_Snip_FullScreen.Click += new System.EventHandler(this.Menu_Snip_FullScreen_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            resources.ApplyResources(this.ToolStripSeparator1, "ToolStripSeparator1");
            // 
            // Menu_Snip_Settings
            // 
            this.Menu_Snip_Settings.Image = global::Morysoft.MorySnip.Properties.Resources.feather_settings_32;
            this.Menu_Snip_Settings.Name = "Menu_Snip_Settings";
            resources.ApplyResources(this.Menu_Snip_Settings, "Menu_Snip_Settings");
            this.Menu_Snip_Settings.Click += new System.EventHandler(this.Menu_Snip_Settings_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            resources.ApplyResources(this.ToolStripSeparator2, "ToolStripSeparator2");
            // 
            // Menu_Snip_Exit
            // 
            this.Menu_Snip_Exit.Image = global::Morysoft.MorySnip.Properties.Resources.feather_x;
            this.Menu_Snip_Exit.Name = "Menu_Snip_Exit";
            resources.ApplyResources(this.Menu_Snip_Exit, "Menu_Snip_Exit");
            this.Menu_Snip_Exit.Click += new System.EventHandler(this.Menu_Snip_Exit_Click);
            // 
            // FormSnippingTool
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSnippingTool";
            this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.Form_SnippingTool_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_SnippingTool_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_SnippingTool_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_SnippingTool_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_SnippingTool_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_SnippingTool_MouseUp);
            this.Menu_Snip.ResumeLayout(false);
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
