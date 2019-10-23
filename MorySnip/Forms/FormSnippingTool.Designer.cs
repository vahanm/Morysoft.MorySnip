using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Morysoft.MorySnip
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_SnippingTool : FormSaveBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SnippingTool));
            this._Menu_Snip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._Menu_Snip_FromClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this._Menu_Snip_FromFile = new System.Windows.Forms.ToolStripMenuItem();
            this._Menu_Snip_FullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._Menu_Snip_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this._Menu_Snip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Menu_Snip
            // 
            this._Menu_Snip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this._Menu_Snip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Menu_Snip_FromClipboard,
            this._Menu_Snip_FromFile,
            this._Menu_Snip_FullScreen,
            this._ToolStripSeparator1,
            this._Menu_Snip_Exit});
            this._Menu_Snip.Name = "Menu_Snip";
            resources.ApplyResources(this._Menu_Snip, "_Menu_Snip");
            // 
            // _Menu_Snip_FromClipboard
            // 
            this._Menu_Snip_FromClipboard.Image = global::Morysoft.MorySnip.Properties.Resources.iconic_new_window;
            this._Menu_Snip_FromClipboard.Name = "_Menu_Snip_FromClipboard";
            resources.ApplyResources(this._Menu_Snip_FromClipboard, "_Menu_Snip_FromClipboard");
            this._Menu_Snip_FromClipboard.Click += new System.EventHandler(this.Menu_Snip_FromClipboard_Click);
            // 
            // _Menu_Snip_FromFile
            // 
            this._Menu_Snip_FromFile.Image = global::Morysoft.MorySnip.Properties.Resources.iconic_folder;
            this._Menu_Snip_FromFile.Name = "_Menu_Snip_FromFile";
            resources.ApplyResources(this._Menu_Snip_FromFile, "_Menu_Snip_FromFile");
            this._Menu_Snip_FromFile.Click += new System.EventHandler(this.Menu_Snip_FromFile_Click);
            // 
            // _Menu_Snip_FullScreen
            // 
            this._Menu_Snip_FullScreen.Image = global::Morysoft.MorySnip.Properties.Resources.iconic_fullscreen;
            this._Menu_Snip_FullScreen.Name = "_Menu_Snip_FullScreen";
            resources.ApplyResources(this._Menu_Snip_FullScreen, "_Menu_Snip_FullScreen");
            // 
            // _ToolStripSeparator1
            // 
            this._ToolStripSeparator1.Name = "_ToolStripSeparator1";
            resources.ApplyResources(this._ToolStripSeparator1, "_ToolStripSeparator1");
            // 
            // _Menu_Snip_Exit
            // 
            this._Menu_Snip_Exit.Image = global::Morysoft.MorySnip.Properties.Resources.iconic_x;
            this._Menu_Snip_Exit.Name = "_Menu_Snip_Exit";
            resources.ApplyResources(this._Menu_Snip_Exit, "_Menu_Snip_Exit");
            this._Menu_Snip_Exit.Click += new System.EventHandler(this.Menu_Snip_FullScreen_Click);
            // 
            // Form_SnippingTool
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_SnippingTool";
            this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.Form_SnippingTool_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_SnippingTool_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_SnippingTool_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_SnippingTool_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_SnippingTool_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_SnippingTool_MouseUp);
            this._Menu_Snip.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private ContextMenuStrip _Menu_Snip;

        internal ContextMenuStrip Menu_Snip
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Snip;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Snip != null)
                {
                }

                _Menu_Snip = value;
                if (_Menu_Snip != null)
                {
                }
            }
        }

        private ToolStripMenuItem _Menu_Snip_FullScreen;

        internal ToolStripMenuItem Menu_Snip_FullScreen
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Snip_FullScreen;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Snip_FullScreen != null)
                {
                    _Menu_Snip_FullScreen.Click -= Menu_Snip_FullScreen_Click;
                }

                _Menu_Snip_FullScreen = value;
                if (_Menu_Snip_FullScreen != null)
                {
                    _Menu_Snip_FullScreen.Click += Menu_Snip_FullScreen_Click;
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

        private ToolStripMenuItem _Menu_Snip_Exit;

        internal ToolStripMenuItem Menu_Snip_Exit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Snip_Exit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Snip_Exit != null)
                {
                    _Menu_Snip_Exit.Click -= Menu_Snip_Exit_Click;
                }

                _Menu_Snip_Exit = value;
                if (_Menu_Snip_Exit != null)
                {
                    _Menu_Snip_Exit.Click += Menu_Snip_Exit_Click;
                }
            }
        }

        private ToolStripMenuItem _Menu_Snip_FromClipboard;

        internal ToolStripMenuItem Menu_Snip_FromClipboard
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Snip_FromClipboard;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Snip_FromClipboard != null)
                {
                    _Menu_Snip_FromClipboard.Click -= Menu_Snip_FromClipboard_Click;
                }

                _Menu_Snip_FromClipboard = value;
                if (_Menu_Snip_FromClipboard != null)
                {
                    _Menu_Snip_FromClipboard.Click += Menu_Snip_FromClipboard_Click;
                }
            }
        }

        private ToolStripMenuItem _Menu_Snip_FromFile;

        internal ToolStripMenuItem Menu_Snip_FromFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Snip_FromFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Snip_FromFile != null)
                {
                    _Menu_Snip_FromFile.Click -= Menu_Snip_FromFile_Click;
                }

                _Menu_Snip_FromFile = value;
                if (_Menu_Snip_FromFile != null)
                {
                    _Menu_Snip_FromFile.Click += Menu_Snip_FromFile_Click;
                }
            }
        }
    }
}
