using System;
using System.Windows.Forms;

namespace Morysoft.MorySnip
{
    public partial class Form_Settings
    {
        public static DialogResult Show()
        {
            using var form = new Form_Settings();

            return form.ShowDialog();
        }

        public Form_Settings() => this.InitializeComponent();

        private void Form_Load(object sender, EventArgs e)
        {
            this.Button_BrowseLocal.Text = Settings.DefaultPath;
            this.ComboBox_Type.SelectedIndex = Settings.FileType;
            this.ComboBox_Quality.SelectedIndex = Settings.ShareQuality;

            this.CheckBox_CopyPath.Checked = Settings.CopyPath;
            this.CheckBox_OpenFolder.Checked = Settings.OpenFolder;
        }

        private void Button_Browse_Click(object sender, EventArgs e)
        {
            using var withBlock = new FolderBrowserDialog();

            if (withBlock.ShowDialog() == DialogResult.OK)
            {
                this.Button_BrowseLocal.Text = withBlock.SelectedPath;
            }
        }

        private void ComboBox_Type_SelectedIndexChanged(object sender, EventArgs e) => Settings.FileType = this.ComboBox_Type.SelectedIndex;

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Settings.DefaultPath = this.Button_BrowseLocal.Text;
            Settings.FileType = this.ComboBox_Type.SelectedIndex;
            Settings.ShareQuality = this.ComboBox_Quality.SelectedIndex;

            Settings.CopyPath = this.CheckBox_CopyPath.Checked;
            Settings.OpenFolder = this.CheckBox_OpenFolder.Checked;
        }

        private void Button_Save_Click(object sender, EventArgs e) => this.Close();
    }
}
