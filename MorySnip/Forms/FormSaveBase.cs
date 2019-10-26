using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Morysoft.MorySnip.Modules;

namespace Morysoft.MorySnip
{
    public class FormSaveBase : Form
    {
        protected Point _virtualScreenLocation = SystemInformation.VirtualScreen.Location;
        protected Size _virtualScreenSize = SystemInformation.VirtualScreen.Size;

        protected Point _primaryScreenLocation = Screen.PrimaryScreen.Bounds.Location;
        protected Size _primaryScreenSize = Screen.PrimaryScreen.Bounds.Size;

        private FormSaveBase _saveForm;

        public FormSaveBase SaveForm
        {
            get
            {
                if (this._saveForm == null)
                {
                    this._saveForm = new Form_Edit();
                }

                return this._saveForm;
            }
            set => this._saveForm = value;
        }

        public List<Screenshot> Screenshotes { get; } = new List<Screenshot>();

        public int AddImageFromClipboard()
        {
            if (Clipboard.ContainsImage())
            {
                this.Screenshotes.Add(Clipboard.GetImage());

                return 1;
            }
            else if (Clipboard.ContainsText())
            {
                string paths = Clipboard.GetText();
                int count = 0;

                if (LikeOperator.LikeString(paths, "*[A-z]*[.][A-z]*", CompareMethod.Binary) && (paths.StartsWith("http://") || paths.StartsWith("https://") || paths.StartsWith("ftp://")))
                {
                    string ImagePath = Helpers.GetTempFileName();
                    (new Network()).DownloadFile(paths, ImagePath, "", "", true, 3000, true, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                    paths = ImagePath;
                }

                foreach (string path in paths.Split('"', '\'', ';', Conversions.ToChar(Constants.vbCr), Conversions.ToChar(Constants.vbLf)))
                {
                    string nomralizedPath = path.Trim().Trim('"', '\'');

                    try
                    {
                        string localPath = new Uri(nomralizedPath).LocalPath;
                        var tempImage = new Screenshot
                        {
                            Image = Image.FromFile(localPath),
                            OriginalPath = localPath
                        };

                        this.Screenshotes.Add(tempImage);

                        count += 1;
                    }
                    catch
                    {
                        //TODO: Handle exception
                    }
                }

                return count;
            }
            else if (Clipboard.ContainsFileDropList())
            {
                var l = Clipboard.GetFileDropList();
                int count = 0;

                foreach (string path in l)
                {
                    string nomralizedPath = path.Trim().Trim('"', '\'');

                    try
                    {
                        string localPath = new Uri(nomralizedPath).LocalPath;
                        var tempImage = new Screenshot
                        {
                            Image = Image.FromFile(localPath),
                            OriginalPath = localPath
                        };

                        this.Screenshotes.Add(tempImage);

                        count += 1;
                    }
                    catch
                    {
                        //TODO: Handle exception
                    }
                }

                return count;
            }

            return default;
        }

        public object AddImageFullScreen(int ScreenNumber = -1)
        {
            Point vl;
            Size vs;

            if (ScreenNumber < 0 || ScreenNumber > Screen.AllScreens.Length - 1)
            {
                vl = SystemInformation.VirtualScreen.Location;
                vs = SystemInformation.VirtualScreen.Size;
            }
            else
            {
                vl = Screen.AllScreens[ScreenNumber].Bounds.Location;
                vs = Screen.AllScreens[ScreenNumber].Bounds.Size;
            }

            this.Opacity = 0;
            this.Hide();

            var b = new Bitmap(vs.Width, vs.Height);

            var g = Graphics.FromImage(b);

            g.CopyFromScreen(vl.X, vl.Y, 0, 0, vs);

            this.Screenshotes.Add(b);

            this.Show();
            this.Opacity = 1;

            return 1;
        }

        public int AddImageFromSnippingTool()
        {
            int imagesCount = this.Screenshotes.Count;

            this.Hide();

            using (var withBlock = new Form_SnippingTool
            {
                SaveForm = this
            })
            {
                withBlock.ShowDialog();
            }

            this.Show();

            return this.Screenshotes.Count - imagesCount;
        }

        public int AddImageFromFile()
        {
            using (var od = new OpenFileDialog()
            {
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true,
                Filter = "All supported files|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpeg;*.jpg;*.png;*.tiff;*.wmf;"
            })
            {
                int imagesAdd = 0;

                if (od.ShowDialog() == DialogResult.OK)
                {
                    bool tryToLoad(string path)
                    {
                        do
                        {
                            try
                            {
                                string LocalPath = new Uri(path).LocalPath;
                                Screenshot TempImage = Image.FromFile(LocalPath);
                                TempImage.OriginalPath = LocalPath;
                                this.Screenshotes.Add(TempImage);
                                imagesAdd += 1;

                                return true;
                            }
                            catch (Exception ex)
                            {
                                switch (Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical | MsgBoxStyle.AbortRetryIgnore))
                                {
                                    case MsgBoxResult.Abort:
                                        return false;

                                    case MsgBoxResult.Ignore:
                                        break;
                                }
                            }
                        }
                        while (true);
                    }

                    foreach (string path in od.FileNames.Select(fn => fn.Trim().Trim('"', '\'')))
                    {
                        if (!tryToLoad(path))
                        {
                            break;
                        }
                    }
                }

                return imagesAdd;
            }
        }

        public void SnipFromClipboard()
        {
            var screenshotes = Snipper.FromClipboard();

            this.SaveForm.Screenshotes.AddRange(screenshotes);

            if (this.SaveForm.Screenshotes.Count == 0)
            {
                Interaction.MsgBox("No image or image file path in clipboard.", MsgBoxStyle.Critical);
            }
            else
            {
                this.SaveForm.Show();
                this.Close();
            }
        }

        public void SnipFullScreen()
        {
            this.Hide();

            this.SaveForm.Screenshotes.AddRange(Snipper.AllScreens());

            this.SaveForm.Show();

            this.Close();
        }

        public void SnipScreen(int index) => throw new NotImplementedException();

        public void SnipFromFile()
        {
            var od = new OpenFileDialog()
            {
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true,
                Filter = "All supported files|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpeg;*.jpg;*.png;*.tiff;*.wmf;"
            };

            this.Hide();

            if ((int)od.ShowDialog(this.SaveForm) == (int)DialogResult.OK)
            {
                foreach (string path in od.FileNames.Select(fn => fn.Trim('"', '\'')))
                {
                    do
                    {
                        try
                        {
                            string localPath = new Uri(path).LocalPath;
                            Screenshot tempImage = Image.FromFile(localPath);
                            tempImage.OriginalPath = localPath;
                            this.SaveForm.Screenshotes.Add(tempImage);
                            break;
                        }
                        catch (Exception ex)
                        {
                            switch (Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical | MsgBoxStyle.AbortRetryIgnore))
                            {
                                case MsgBoxResult.Retry:
                                {
                                    break;
                                }

                                case MsgBoxResult.Abort:
                                {
                                    break;
                                    break;
                                }

                                case MsgBoxResult.Ignore:
                                {
                                    break;
                                    break;
                                }
                            }
                        }
                    }
                    while (true);
                }

                this.SaveForm.Show();
                this.Close();

                return;
            }

            this.Show();
        }
    }
}
