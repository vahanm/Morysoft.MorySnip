using System;
using System.Windows.Forms;

namespace Morysoft.MorySnip
{
    public partial class FormSettings
    {
        public static new DialogResult Show()
        {
            using var form = new FormSettings();

            return form.ShowDialog();
        }

        public FormSettings() => this.InitializeComponent();

        private void Form_Load(object sender, EventArgs e)
        {
            this.BrowseLocalButton.Text = Settings.DefaultPath;
            this.ImageTypeComboBox.SelectedIndex = Settings.FileType;

            this.CopyPathCheckBox.Checked = Settings.CopyPath;
            this.OpenFolderCheckBox.Checked = Settings.OpenFolder;

            this.quickShotSaveFileCheckBox.Checked = Settings.QuickShotToFile;
        }

        private void Button_Browse_Click(object sender, EventArgs e)
        {
            using var withBlock = new FolderBrowserDialog();

            if (withBlock.ShowDialog() == DialogResult.OK)
            {
                this.BrowseLocalButton.Text = withBlock.SelectedPath;
            }
        }

        private void ComboBox_Type_SelectedIndexChanged(object sender, EventArgs e) => Settings.FileType = this.ImageTypeComboBox.SelectedIndex;

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Settings.DefaultPath = this.BrowseLocalButton.Text;
            Settings.FileType = this.ImageTypeComboBox.SelectedIndex;

            Settings.CopyPath = this.CopyPathCheckBox.Checked;
            Settings.OpenFolder = this.OpenFolderCheckBox.Checked;

            Settings.QuickShotToFile = this.quickShotSaveFileCheckBox.Checked;
        }

        private void Button_Save_Click(object sender, EventArgs e) => this.Close();
    }
}
