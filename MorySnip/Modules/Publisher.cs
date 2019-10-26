using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Morysoft.MorySnip.Modules
{
    [Flags]
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

    public static class Publisher
    {
        private static bool PublishToClipboard(Screenshot screenshot)
        {
            if (screenshot is null)
            {
                throw new ArgumentNullException(nameof(screenshot));
            }

            do
            {
                try
                {
                    Clipboard.SetImage(screenshot.Image);

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

        public static bool Publish(PublishOptions options, params Screenshot[] screenshotes)
        {
            if (screenshotes is null || screenshotes.Length == 0)
            {
                throw new ArgumentNullException(nameof(screenshotes));
            }

            int imageNumber = (int)(options & PublishOptions.OnlyImageNumber);
            var screenshot = screenshotes[imageNumber].Image;

            if ((options & PublishOptions.CopyImage) == PublishOptions.CopyImage)
            {
                return PublishToClipboard(screenshot);
            }

            return PublishSaveToFile(options, screenshot);
        }

        private static bool PublishSaveToFile(PublishOptions options, Screenshot screenshot)
        {
            string path = "";

            path += Settings.DefaultPath;

            path += @"\" + DateAndTime.Now.ToString("yyyy-MM-dd HH-mm-ss-ffff") + "." + Settings.FileTypeString.ToLower();

            if (!Directory.Exists(Settings.DefaultPath) && (options & PublishOptions.SaveToFile) == PublishOptions.SaveToFile || (options & PublishOptions.SaveAs) == PublishOptions.SaveAs)
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

            ImageFormat imageFormat(string imagePath)
            {
                switch (Path.GetExtension(imagePath).Substring(1))
                {
                    case "Bmp": return ImageFormat.Bmp;
                    case "Emf": return ImageFormat.Emf;
                    case "Exif": return ImageFormat.Exif;
                    case "Gif": return ImageFormat.Gif;
                    case "Ico": return ImageFormat.Icon;
                    case "Jpeg":
                    case "jpg": return ImageFormat.Jpeg;
                    case "Png": return ImageFormat.Png;
                    case "Tiff": return ImageFormat.Tiff;
                    case "Wmf": return ImageFormat.Wmf;
                    default: return null;
                }
            }

            var img = screenshot.Image;
            var format = imageFormat(path);

            if (format is null)
            {
                img.Save(path);
            }
            else
            {
                img.Save(path, format);
            }

            if ((options & PublishOptions.SaveAs) == PublishOptions.SaveAs)
            {
                Interaction.Shell("explorer /select, \"" + path + "\"", AppWinStyle.NormalFocus);
            }

            return true;
        }
    }
}
