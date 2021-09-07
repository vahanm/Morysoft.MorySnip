using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public static string GetPath(bool saveAs = false, string defaultType = null, string[] supportedTypes = null)
        {
            if (String.IsNullOrWhiteSpace(defaultType))
            {
                defaultType = Settings.FileTypeString;
            }

            if (supportedTypes is null || supportedTypes.Length == 0)
            {
                supportedTypes = Settings.FileTypes;
            }

            string path = "";

            path += Settings.DefaultPath;

            path += @"\" + DateAndTime.Now.ToString("yyyy-MM-dd HH-mm-ss-ffff") + "." + defaultType.ToLower();

            if (!Directory.Exists(Settings.DefaultPath))
            {
                using (var sfd = new SaveFileDialog()
                {
                    AddExtension = true,
                    CheckPathExists = true,
                    CheckFileExists = false,
                    DefaultExt = $"{defaultType.ToUpper()}|*.{defaultType.ToLower()}",
                    Filter = Settings.FileTypes.Aggregate((a, i) => a + $"{i.ToUpper()}|*.{i.ToLower()}|") + "All Files|*.*"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        return null;
                    }

                    path = sfd.FileName;
                }
            }

            return path;
        }

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
                    System.Windows.Forms.Clipboard.SetImage(screenshot.Image);

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
            string path = GetPath(saveAs: (options & PublishOptions.SaveAs) == PublishOptions.SaveAs);

            if (path is null)
            {
                return false;
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

        public static bool PublishMultipleFrames(PublishOptions options, IEnumerable<Screenshot> screenshotes)
        {
            if (screenshotes is null)
            {
                throw new ArgumentNullException(nameof(screenshotes));
            }

            string path = GetPath(
                saveAs: (options & PublishOptions.SaveAs) == PublishOptions.SaveAs,
                defaultType: "Gif",
                supportedTypes: new string[] { "Gif" });

            if (path is null)
            {
                return false;
            }

            //var gEnc = new GifBitmapEncoder();

            //foreach (Bitmap bmpImage in screenshotes)
            //{
            //    var bmp = bmpImage.GetHbitmap();
            //    var src = Imaging.CreateBitmapSourceFromHBitmap(
            //        bmp,
            //        IntPtr.Zero,
            //        Int32Rect.Empty,
            //        BitmapSizeOptions.FromEmptyOptions());

            //    gEnc.Frames.Add(BitmapFrame.Create(src));

            //    //Marshal.FreeCoTaskMem(bmp); // recommended, handle memory leak
            //}

            //using (var fs = new FileStream(path, FileMode.Create))
            //{
            //    gEnc.Save(fs);
            //}

            return true;
        }
    }
}
