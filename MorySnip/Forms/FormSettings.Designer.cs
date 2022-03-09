using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Morysoft.MorySnip
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FormSettings : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.imageTypeComboBox = new System.Windows.Forms.ComboBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._Label4 = new System.Windows.Forms.Label();
            this.copyPathCheckBox = new System.Windows.Forms.CheckBox();
            this.openFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.browseLocalButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.quickShotSaveFileCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageTypeComboBox
            // 
            this.imageTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageTypeComboBox.FormattingEnabled = true;
            this.imageTypeComboBox.Items.AddRange(new object[] {
            resources.GetString("imageTypeComboBox.Items"),
            resources.GetString("imageTypeComboBox.Items1"),
            resources.GetString("imageTypeComboBox.Items2"),
            resources.GetString("imageTypeComboBox.Items3"),
            resources.GetString("imageTypeComboBox.Items4"),
            resources.GetString("imageTypeComboBox.Items5"),
            resources.GetString("imageTypeComboBox.Items6"),
            resources.GetString("imageTypeComboBox.Items7"),
            resources.GetString("imageTypeComboBox.Items8")});
            resources.ApplyResources(this.imageTypeComboBox, "imageTypeComboBox");
            this.imageTypeComboBox.Name = "imageTypeComboBox";
            this.imageTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Type_SelectedIndexChanged);
            // 
            // _Label1
            // 
            resources.ApplyResources(this._Label1, "_Label1");
            this._Label1.Name = "_Label1";
            // 
            // _Label4
            // 
            resources.ApplyResources(this._Label4, "_Label4");
            this._Label4.Name = "_Label4";
            // 
            // copyPathCheckBox
            // 
            resources.ApplyResources(this.copyPathCheckBox, "copyPathCheckBox");
            this.copyPathCheckBox.Checked = true;
            this.copyPathCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.copyPathCheckBox.Name = "copyPathCheckBox";
            this.copyPathCheckBox.UseVisualStyleBackColor = true;
            // 
            // openFolderCheckBox
            // 
            resources.ApplyResources(this.openFolderCheckBox, "openFolderCheckBox");
            this.openFolderCheckBox.Checked = true;
            this.openFolderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openFolderCheckBox.Name = "openFolderCheckBox";
            this.openFolderCheckBox.UseVisualStyleBackColor = true;
            // 
            // browseLocalButton
            // 
            resources.ApplyResources(this.browseLocalButton, "browseLocalButton");
            this.browseLocalButton.Name = "browseLocalButton";
            this.browseLocalButton.UseVisualStyleBackColor = true;
            this.browseLocalButton.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.quickShotSaveFileCheckBox);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // quickShotSaveFileCheckBox
            // 
            resources.ApplyResources(this.quickShotSaveFileCheckBox, "quickShotSaveFileCheckBox");
            this.quickShotSaveFileCheckBox.Name = "quickShotSaveFileCheckBox";
            this.quickShotSaveFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this._Label4);
            this.groupBox2.Controls.Add(this._Label1);
            this.groupBox2.Controls.Add(this.imageTypeComboBox);
            this.groupBox2.Controls.Add(this.copyPathCheckBox);
            this.groupBox2.Controls.Add(this.openFolderCheckBox);
            this.groupBox2.Controls.Add(this.browseLocalButton);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // FormSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Button browseLocalButton;
        private CheckBox openFolderCheckBox;
        private ComboBox imageTypeComboBox;
        private Label _Label1;
        private Label _Label4;
        private CheckBox copyPathCheckBox;
        private Button saveButton;
        private GroupBox groupBox1;
        private CheckBox quickShotSaveFileCheckBox;
        private GroupBox groupBox2;
    }
}
