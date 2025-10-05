using System.Windows.Forms;
using Morysoft.MorySnip.Modules;

namespace Morysoft.MorySnip;

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
        this.browseLocalButton.Text = Settings.DefaultPath;
        this.imageTypeComboBox.SelectedIndex = Settings.FileType;

        this.copyPathCheckBox.Checked = Settings.CopyPath;
        this.openFolderCheckBox.Checked = Settings.OpenFolder;

        this.quickShotSaveFileCheckBox.Checked = Settings.QuickShotToFile;
    }

    private void Button_Browse_Click(object sender, EventArgs e)
    {
        using var withBlock = new FolderBrowserDialog();

        if (withBlock.ShowDialog() == DialogResult.OK)
        {
            this.browseLocalButton.Text = withBlock.SelectedPath;
        }
    }

    private void ComboBox_Type_SelectedIndexChanged(object sender, EventArgs e) => Settings.FileType = this.imageTypeComboBox.SelectedIndex;

    private void Form_Closing(object sender, FormClosingEventArgs e)
    {
        Settings.DefaultPath = this.browseLocalButton.Text;
        Settings.FileType = this.imageTypeComboBox.SelectedIndex;

        Settings.CopyPath = this.copyPathCheckBox.Checked;
        Settings.OpenFolder = this.openFolderCheckBox.Checked;

        Settings.QuickShotToFile = this.quickShotSaveFileCheckBox.Checked;
    }

    private void Button_Save_Click(object sender, EventArgs e) => this.Close();
}
