using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Morysoft.MorySnip
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ImageControls : UserControl
    {

        // UserControl overrides dispose to clean up the component list.
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
            this.SuspendLayout();
            // 
            // ImageControls
            // 
            this.AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Name = "ImageControls";
            this.Size = new Size(254, 61);
            this.ResumeLayout(false);
        }
    }
}
