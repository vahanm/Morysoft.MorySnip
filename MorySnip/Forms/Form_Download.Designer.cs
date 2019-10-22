using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Morysoft.MorySnip
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form_Download : Form
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
            this._ProgressBar_Files = new ProgressBar();
            this._Timer_Begin = new Timer(this.components);
            _Timer_Begin.Tick += Timer_Begin_Tick;
            this.SuspendLayout();
            // 
            // ProgressBar_Files
            // 
            this._ProgressBar_Files.Location = new Point(12, 12);
            this._ProgressBar_Files.Name = "ProgressBar_Files";
            this._ProgressBar_Files.Size = new Size(308, 23);
            this._ProgressBar_Files.TabIndex = 0;
            // 
            // Timer_Begin
            // 
            this._Timer_Begin.Enabled = true;
            // 
            // Form_Download
            // 
            this.AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(332, 47);
            this.Controls.Add(this._ProgressBar_Files);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Download";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Download";
            base.Load += Form_Download_Load;
            this.ResumeLayout(false);
        }
        private ProgressBar _ProgressBar_Files;

        internal ProgressBar ProgressBar_Files
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ProgressBar_Files;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ProgressBar_Files != null)
                {
                }

                _ProgressBar_Files = value;
                if (_ProgressBar_Files != null)
                {
                }
            }
        }

        private Timer _Timer_Begin;

        internal Timer Timer_Begin
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Timer_Begin;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Timer_Begin != null)
                {
                    _Timer_Begin.Tick -= Timer_Begin_Tick;
                }

                _Timer_Begin = value;
                if (_Timer_Begin != null)
                {
                    _Timer_Begin.Tick += Timer_Begin_Tick;
                }
            }
        }
    }
}
