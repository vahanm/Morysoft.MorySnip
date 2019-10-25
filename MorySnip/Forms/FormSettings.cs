using System;
using System.Windows.Forms;

namespace Morysoft.MorySnip
{
    public partial class Form_Settings
    {
        public Form_Settings()
        {
            this.InitializeComponent();
        }

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
            {
                var withBlock = new FolderBrowserDialog();
                if ((int)withBlock.ShowDialog() == (int)DialogResult.OK)
                {
                    this.Button_BrowseLocal.Text = withBlock.SelectedPath;
                }
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
    }
}
