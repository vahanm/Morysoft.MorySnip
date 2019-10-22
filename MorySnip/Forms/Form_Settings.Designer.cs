using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Morysoft.MorySnip
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_Settings : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this._ComboBox_Type = new ComboBox();
            _ComboBox_Type.SelectedIndexChanged += ComboBox_Type_SelectedIndexChanged;
            this._Label1 = new Label();
            this._Label3 = new Label();
            this._Label4 = new Label();
            this._CheckBox_CopyPath = new CheckBox();
            this._CheckBox_OpenFolder = new CheckBox();
            this._Button_BrowseLocal = new Button();
            _Button_BrowseLocal.Click += Button_Browse_Click;
            this._ImageList_Thumbs = new ImageList(this.components);
            this._Menu_Clipboard = new ContextMenuStrip(this.components);
            this._Menu_Clipboard_Message = new ToolStripMenuItem();
            this._Menu_Clipboard_Separator1 = new ToolStripSeparator();
            this._Menu_Clipboard_Monitor = new ToolStripMenuItem();
            this._ComboBox_Quality = new ComboBox();
            _ComboBox_Quality.SelectedIndexChanged += ComboBox_Type_SelectedIndexChanged;
            this._Label8 = new Label();
            this._ToolTip_Buttons = new ToolTip(this.components);
            this._Menu_Screens = new ContextMenuStrip(this.components);
            this._Menu_Screens_Screen1 = new ToolStripMenuItem();
            this._Menu_Screens_Screen2 = new ToolStripMenuItem();
            this._Menu_Screens_Screen3 = new ToolStripMenuItem();
            this._Menu_Screens_Screen4 = new ToolStripMenuItem();
            this._ToolStripSeparator1 = new ToolStripSeparator();
            this._Menu_Screens_AllScreens = new ToolStripMenuItem();
            this._Timer_MonitorClipboard = new Timer(this.components);
            this._Menu_Clipboard.SuspendLayout();
            this._Menu_Screens.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboBox_Type
            // 
            resources.ApplyResources(this._ComboBox_Type, "ComboBox_Type");
            this._ComboBox_Type.DropDownStyle = ComboBoxStyle.DropDownList;
            this._ComboBox_Type.FormattingEnabled = true;
            this._ComboBox_Type.Items.AddRange(new object[] { resources.GetString("ComboBox_Type.Items"), resources.GetString("ComboBox_Type.Items1"), resources.GetString("ComboBox_Type.Items2"), resources.GetString("ComboBox_Type.Items3"), resources.GetString("ComboBox_Type.Items4"), resources.GetString("ComboBox_Type.Items5"), resources.GetString("ComboBox_Type.Items6"), resources.GetString("ComboBox_Type.Items7"), resources.GetString("ComboBox_Type.Items8") });
            this._ComboBox_Type.Name = "ComboBox_Type";
            // 
            // Label1
            // 
            resources.ApplyResources(this._Label1, "Label1");
            this._Label1.Name = "Label1";
            // 
            // Label3
            // 
            resources.ApplyResources(this._Label3, "Label3");
            this._Label3.BorderStyle = BorderStyle.Fixed3D;
            this._Label3.Name = "Label3";
            // 
            // Label4
            // 
            resources.ApplyResources(this._Label4, "Label4");
            this._Label4.Name = "Label4";
            // 
            // CheckBox_CopyPath
            // 
            resources.ApplyResources(this._CheckBox_CopyPath, "CheckBox_CopyPath");
            this._CheckBox_CopyPath.Checked = true;
            this._CheckBox_CopyPath.CheckState = CheckState.Checked;
            this._CheckBox_CopyPath.Name = "CheckBox_CopyPath";
            this._CheckBox_CopyPath.UseVisualStyleBackColor = true;
            // 
            // CheckBox_OpenFolder
            // 
            resources.ApplyResources(this._CheckBox_OpenFolder, "CheckBox_OpenFolder");
            this._CheckBox_OpenFolder.Checked = true;
            this._CheckBox_OpenFolder.CheckState = CheckState.Checked;
            this._CheckBox_OpenFolder.Name = "CheckBox_OpenFolder";
            this._CheckBox_OpenFolder.UseVisualStyleBackColor = true;
            // 
            // Button_BrowseLocal
            // 
            resources.ApplyResources(this._Button_BrowseLocal, "Button_BrowseLocal");
            this._Button_BrowseLocal.Name = "Button_BrowseLocal";
            this._Button_BrowseLocal.UseVisualStyleBackColor = true;
            // 
            // ImageList_Thumbs
            // 
            this._ImageList_Thumbs.ColorDepth = ColorDepth.Depth32Bit;
            resources.ApplyResources(this._ImageList_Thumbs, "ImageList_Thumbs");
            this._ImageList_Thumbs.TransparentColor = Color.Transparent;
            // 
            // Menu_Clipboard
            // 
            this._Menu_Clipboard.Items.AddRange(new ToolStripItem[] { this._Menu_Clipboard_Message, this._Menu_Clipboard_Separator1, this._Menu_Clipboard_Monitor });
            this._Menu_Clipboard.Name = "Menu_Clipboard";
            resources.ApplyResources(this._Menu_Clipboard, "Menu_Clipboard");
            // 
            // Menu_Clipboard_Message
            // 
            resources.ApplyResources(this._Menu_Clipboard_Message, "Menu_Clipboard_Message");
            this._Menu_Clipboard_Message.Name = "Menu_Clipboard_Message";
            // 
            // Menu_Clipboard_Separator1
            // 
            this._Menu_Clipboard_Separator1.Name = "Menu_Clipboard_Separator1";
            resources.ApplyResources(this._Menu_Clipboard_Separator1, "Menu_Clipboard_Separator1");
            // 
            // Menu_Clipboard_Monitor
            // 
            this._Menu_Clipboard_Monitor.Name = "Menu_Clipboard_Monitor";
            resources.ApplyResources(this._Menu_Clipboard_Monitor, "Menu_Clipboard_Monitor");
            // 
            // ComboBox_Quality
            // 
            resources.ApplyResources(this._ComboBox_Quality, "ComboBox_Quality");
            this._ComboBox_Quality.DropDownStyle = ComboBoxStyle.DropDownList;
            this._ComboBox_Quality.FormattingEnabled = true;
            this._ComboBox_Quality.Items.AddRange(new object[] { resources.GetString("ComboBox_Quality.Items"), resources.GetString("ComboBox_Quality.Items1"), resources.GetString("ComboBox_Quality.Items2") });
            this._ComboBox_Quality.Name = "ComboBox_Quality";
            // 
            // Label8
            // 
            resources.ApplyResources(this._Label8, "Label8");
            this._Label8.Name = "Label8";
            // 
            // Menu_Screens
            // 
            this._Menu_Screens.Items.AddRange(new ToolStripItem[] { this._Menu_Screens_Screen1, this._Menu_Screens_Screen2, this._Menu_Screens_Screen3, this._Menu_Screens_Screen4, this._ToolStripSeparator1, this._Menu_Screens_AllScreens });
            this._Menu_Screens.Name = "Menu_Screens";
            resources.ApplyResources(this._Menu_Screens, "Menu_Screens");
            // 
            // Menu_Screens_Screen1
            // 
            this._Menu_Screens_Screen1.Name = "Menu_Screens_Screen1";
            resources.ApplyResources(this._Menu_Screens_Screen1, "Menu_Screens_Screen1");
            this._Menu_Screens_Screen1.Tag = "0";
            // 
            // Menu_Screens_Screen2
            // 
            this._Menu_Screens_Screen2.Name = "Menu_Screens_Screen2";
            resources.ApplyResources(this._Menu_Screens_Screen2, "Menu_Screens_Screen2");
            this._Menu_Screens_Screen2.Tag = "1";
            // 
            // Menu_Screens_Screen3
            // 
            this._Menu_Screens_Screen3.Name = "Menu_Screens_Screen3";
            resources.ApplyResources(this._Menu_Screens_Screen3, "Menu_Screens_Screen3");
            this._Menu_Screens_Screen3.Tag = "2";
            // 
            // Menu_Screens_Screen4
            // 
            this._Menu_Screens_Screen4.Name = "Menu_Screens_Screen4";
            resources.ApplyResources(this._Menu_Screens_Screen4, "Menu_Screens_Screen4");
            this._Menu_Screens_Screen4.Tag = "3";
            // 
            // ToolStripSeparator1
            // 
            this._ToolStripSeparator1.Name = "ToolStripSeparator1";
            resources.ApplyResources(this._ToolStripSeparator1, "ToolStripSeparator1");
            // 
            // Menu_Screens_AllScreens
            // 
            this._Menu_Screens_AllScreens.Name = "Menu_Screens_AllScreens";
            resources.ApplyResources(this._Menu_Screens_AllScreens, "Menu_Screens_AllScreens");
            // 
            // Form_Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this._Label4);
            this.Controls.Add(this._Label8);
            this.Controls.Add(this._ComboBox_Quality);
            this.Controls.Add(this._Label1);
            this.Controls.Add(this._ComboBox_Type);
            this.Controls.Add(this._CheckBox_CopyPath);
            this.Controls.Add(this._CheckBox_OpenFolder);
            this.Controls.Add(this._Button_BrowseLocal);
            this.Controls.Add(this._Label3);
            this.Name = "Form_Settings";
            base.Load += Form_Load;
            this.FormClosing += Form_Closing;
            this._Menu_Clipboard.ResumeLayout(false);
            base.Load += Form_Load;
            this.FormClosing += Form_Closing;
            this._Menu_Screens.ResumeLayout(false);
            base.Load += Form_Load;
            this.FormClosing += Form_Closing;
            this.ResumeLayout(false);
        }
        private Button _Button_BrowseLocal;

        internal Button Button_BrowseLocal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_BrowseLocal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_BrowseLocal != null)
                {
                    _Button_BrowseLocal.Click -= Button_Browse_Click;
                }

                _Button_BrowseLocal = value;
                if (_Button_BrowseLocal != null)
                {
                    _Button_BrowseLocal.Click += Button_Browse_Click;
                }
            }
        }

        private CheckBox _CheckBox_OpenFolder;

        internal CheckBox CheckBox_OpenFolder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBox_OpenFolder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBox_OpenFolder != null)
                {
                }

                _CheckBox_OpenFolder = value;
                if (_CheckBox_OpenFolder != null)
                {
                }
            }
        }

        private ComboBox _ComboBox_Type;

        internal ComboBox ComboBox_Type
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBox_Type;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBox_Type != null)
                {
                    _ComboBox_Type.SelectedIndexChanged -= ComboBox_Type_SelectedIndexChanged;
                }

                _ComboBox_Type = value;
                if (_ComboBox_Type != null)
                {
                    _ComboBox_Type.SelectedIndexChanged += ComboBox_Type_SelectedIndexChanged;
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private CheckBox _CheckBox_CopyPath;

        internal CheckBox CheckBox_CopyPath
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBox_CopyPath;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBox_CopyPath != null)
                {
                }

                _CheckBox_CopyPath = value;
                if (_CheckBox_CopyPath != null)
                {
                }
            }
        }

        private ComboBox _ComboBox_Quality;

        internal ComboBox ComboBox_Quality
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBox_Quality;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBox_Quality != null)
                {
                    _ComboBox_Quality.SelectedIndexChanged -= ComboBox_Type_SelectedIndexChanged;
                }

                _ComboBox_Quality = value;
                if (_ComboBox_Quality != null)
                {
                    _ComboBox_Quality.SelectedIndexChanged += ComboBox_Type_SelectedIndexChanged;
                }
            }
        }

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

        private ToolTip _ToolTip_Buttons;

        internal ToolTip ToolTip_Buttons
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolTip_Buttons;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolTip_Buttons != null)
                {
                }

                _ToolTip_Buttons = value;
                if (_ToolTip_Buttons != null)
                {
                }
            }
        }

        private ImageList _ImageList_Thumbs;

        internal ImageList ImageList_Thumbs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ImageList_Thumbs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ImageList_Thumbs != null)
                {
                }

                _ImageList_Thumbs = value;
                if (_ImageList_Thumbs != null)
                {
                }
            }
        }

        private ContextMenuStrip _Menu_Screens;

        internal ContextMenuStrip Menu_Screens
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Screens;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Screens != null)
                {
                }

                _Menu_Screens = value;
                if (_Menu_Screens != null)
                {
                }
            }
        }

        private ToolStripMenuItem _Menu_Screens_Screen1;

        internal ToolStripMenuItem Menu_Screens_Screen1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Screens_Screen1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Screens_Screen1 != null)
                {
                }

                _Menu_Screens_Screen1 = value;
                if (_Menu_Screens_Screen1 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _Menu_Screens_Screen2;

        internal ToolStripMenuItem Menu_Screens_Screen2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Screens_Screen2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Screens_Screen2 != null)
                {
                }

                _Menu_Screens_Screen2 = value;
                if (_Menu_Screens_Screen2 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _Menu_Screens_Screen3;

        internal ToolStripMenuItem Menu_Screens_Screen3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Screens_Screen3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Screens_Screen3 != null)
                {
                }

                _Menu_Screens_Screen3 = value;
                if (_Menu_Screens_Screen3 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _Menu_Screens_Screen4;

        internal ToolStripMenuItem Menu_Screens_Screen4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Screens_Screen4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Screens_Screen4 != null)
                {
                }

                _Menu_Screens_Screen4 = value;
                if (_Menu_Screens_Screen4 != null)
                {
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

        private ToolStripMenuItem _Menu_Screens_AllScreens;

        internal ToolStripMenuItem Menu_Screens_AllScreens
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Screens_AllScreens;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Screens_AllScreens != null)
                {
                }

                _Menu_Screens_AllScreens = value;
                if (_Menu_Screens_AllScreens != null)
                {
                }
            }
        }

        private ContextMenuStrip _Menu_Clipboard;

        internal ContextMenuStrip Menu_Clipboard
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Clipboard;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Clipboard != null)
                {
                }

                _Menu_Clipboard = value;
                if (_Menu_Clipboard != null)
                {
                }
            }
        }

        private ToolStripMenuItem _Menu_Clipboard_Message;

        internal ToolStripMenuItem Menu_Clipboard_Message
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Clipboard_Message;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Clipboard_Message != null)
                {
                }

                _Menu_Clipboard_Message = value;
                if (_Menu_Clipboard_Message != null)
                {
                }
            }
        }

        private ToolStripSeparator _Menu_Clipboard_Separator1;

        internal ToolStripSeparator Menu_Clipboard_Separator1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Clipboard_Separator1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Clipboard_Separator1 != null)
                {
                }

                _Menu_Clipboard_Separator1 = value;
                if (_Menu_Clipboard_Separator1 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _Menu_Clipboard_Monitor;

        internal ToolStripMenuItem Menu_Clipboard_Monitor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Menu_Clipboard_Monitor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Menu_Clipboard_Monitor != null)
                {
                }

                _Menu_Clipboard_Monitor = value;
                if (_Menu_Clipboard_Monitor != null)
                {
                }
            }
        }

        private Timer _Timer_MonitorClipboard;

        internal Timer Timer_MonitorClipboard
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Timer_MonitorClipboard;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Timer_MonitorClipboard != null)
                {
                }

                _Timer_MonitorClipboard = value;
                if (_Timer_MonitorClipboard != null)
                {
                }
            }
        }
    }
}
