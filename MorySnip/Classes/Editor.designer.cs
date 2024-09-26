using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Morysoft.MorySnip;

[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
public partial class Editor : UserControl
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
        // Editor
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.DoubleBuffered = true;
        this.Name = "Editor";
        this.BackgroundImageChanged += new System.EventHandler(this.Editor_BackgroundImageChanged);
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Editor_KeyDown);
        this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Editor_MouseClick);
        this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Editor_MouseDown);
        this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Editor_MouseMove);
        this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Editor_MouseUp);
        this.MouseWheel += new MouseEventHandler(this.Editor_MouseWheel);
        this.ResumeLayout(false);

    }
}
