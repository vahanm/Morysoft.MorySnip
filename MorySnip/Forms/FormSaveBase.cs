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

        public enum PublishOptions : int
        {
            OnlyImageNumber = (1 << 16) - 1,
            CopyPathOrULR = (1 << 17),
            CopyImage = (1 << 18),
            OpenFolder = (1 << 19),
            SaveToFile = (1 << 24),
            SaveAs = (1 << 25),
            WebSharing = (1 << 28), // Base service

            AsAlbum = (1 << 29),
            ShareViaFacebook = (1 << 26), // 67,108,864

            ShareViaOdnoklassniki = (1 << 27), // 134,217,728

            SendViaEmail = (1 << 30)
        }

        public List<Screenshot> Images { get; } = new List<Screenshot>();

        public bool PublishToClipboard(int imageNumber)
        {
            do
            {
                try
                {
                    Clipboard.SetImage(this.Images[imageNumber].Image);

                    return true;
                }
                catch (Exception ex)
                {
                    if (Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical | MsgBoxStyle.RetryCancel) == MsgBoxResult.Cancel)
                    {
                        return false;
                    }
                }
            }
            while (true);

            return false;
        }
        public bool PublishSaveToFile(PublishOptions Options = PublishOptions.SaveToFile)
        {
            int imageNumber = (int)(Options & PublishOptions.OnlyImageNumber);
            string path = "";

            path += Settings.DefaultPath;

            path += @"\" + DateAndTime.Now.ToString("yyyy-MM-dd HH-mm-ss-ffff") + "." + Settings.FileTypeString.ToLower();

            if (!Directory.Exists(Settings.DefaultPath) && (Options & PublishOptions.SaveToFile) == PublishOptions.SaveToFile || (Options & PublishOptions.SaveAs) == PublishOptions.SaveAs)
            {
                using (var sfd = new SaveFileDialog()
                {
                    AddExtension = true,
                    CheckPathExists = true,
                    CheckFileExists = false,
                    DefaultExt = "PNG|*.png",
                    Filter = Settings.FileTypes.Aggregate((a, i) => a + i.ToUpper() + "|*." + i.ToLower() + "|") + "All Files|*.*"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }

                    path = sfd.FileName;
                }
            }

            var tmp = this.Images[imageNumber].Image;

            switch (Path.GetExtension(path).Substring(1))
            {
                case "Bmp":
                {
                    tmp.Save(path, ImageFormat.Bmp);
                    break;
                }

                case "Emf":
                {
                    tmp.Save(path, ImageFormat.Emf);
                    break;
                }

                case "Exif":
                {
                    tmp.Save(path, ImageFormat.Exif);
                    break;
                }

                case "Gif":
                {
                    tmp.Save(path, ImageFormat.Gif);
                    break;
                }

                case "Ico":
                {
                    tmp.Save(path, ImageFormat.Icon);
                    break;
                }

                case "Jpeg":
                case "jpg":
                {
                    tmp.Save(path, ImageFormat.Jpeg);
                    break;
                }

                case "Png":
                {
                    tmp.Save(path, ImageFormat.Png);
                    break;
                }

                case "Tiff":
                {
                    tmp.Save(path, ImageFormat.Tiff);
                    break;
                }

                case "Wmf":
                {
                    tmp.Save(path, ImageFormat.Wmf);
                    break;
                }

                default:
                {
                    tmp.Save(path);
                    break;
                }
            }

            if ((Options & PublishOptions.SaveAs) == PublishOptions.SaveAs)
            {
                Interaction.Shell("explorer /select, \"" + path + "\"", AppWinStyle.NormalFocus);
            }

            return true;
        }

        public int AddImageFromClipboard()
        {
            if (Clipboard.ContainsImage())
            {
                this.Images.Add(Clipboard.GetImage());

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

                        this.Images.Add(tempImage);

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

                        this.Images.Add(tempImage);

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

            this.Images.Add(b);

            this.Show();
            this.Opacity = 1;

            return 1;
        }

        public int AddImageFromSnippingTool()
        {
            int ImagesCount = this.Images.Count;

            this.Hide();
            {
                var withBlock = new Form_SnippingTool
                {
                    SaveForm = this
                };
                withBlock.ShowDialog();
            }
            this.Show();

            return this.Images.Count - ImagesCount;
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
                                this.Images.Add(TempImage);
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
            if (Clipboard.ContainsImage())
            {
                this.SaveForm.Images.Add(Clipboard.GetImage());
                this.SaveForm.Show();
                this.Close();

                return;
            }
            else if (Clipboard.ContainsText())
            {
                string paths = Clipboard.GetText();

                foreach (string path in paths.Split('"', '\'', ';', Conversions.ToChar(Constants.vbCr), Conversions.ToChar(Constants.vbLf)).Select(fn => fn.Trim('"', '\'')))
                {
                    try
                    {
                        string localPath = new Uri(path).LocalPath;
                        Screenshot tempImage = Image.FromFile(localPath);

                        tempImage.OriginalPath = localPath;

                        this.SaveForm.Images.Add(tempImage);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                if (this.SaveForm.Images.Count > 0)
                {
                    this.SaveForm.Show();
                    this.Close();

                    return;
                }
            }
            else if (Clipboard.ContainsFileDropList())
            {
                var filesDrop = Clipboard.GetFileDropList();

                foreach (string path in filesDrop)
                {
                    string nomralizedPath = path.Trim('"', '\'');

                    try
                    {
                        string localPath = new Uri(nomralizedPath).LocalPath;
                        Screenshot tempImage = Image.FromFile(localPath);

                        tempImage.OriginalPath = localPath;

                        this.SaveForm.Images.Add(tempImage);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                if (this.SaveForm.Images.Count > 0)
                {
                    this.SaveForm.Show();
                    this.Close();

                    return;
                }
            }

            Interaction.MsgBox("No image or image file path in clipboard.", MsgBoxStyle.Critical);
        }

        public void SnipFullScreen()
        {
            this.Hide();

            var b = new Bitmap(this._virtualScreenSize.Width, this._virtualScreenSize.Height);

            var g = Graphics.FromImage(b);

            g.CopyFromScreen(this._virtualScreenLocation.X, this._virtualScreenLocation.Y, 0, 0, this._virtualScreenSize);

            this.SaveForm.Images.Add(b);

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
                            this.SaveForm.Images.Add(tempImage);
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
