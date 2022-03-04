using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Morysoft.MorySnip.Modules;

[Flags]
public enum PublishOptions : int
{
    OnlyImageNumber = (1 << 16) - 1,
    CopyPathOrULR = (1 << 17),
    CopyImage = (1 << 18),
    OpenFolder = (1 << 19),
    SaveToFile = (1 << 24),
    SaveAs = (1 << 25),
    Package = (1 << 26),
}

public static class Publisher
{
    public static string? GetPath(bool saveAs = false, string? defaultType = null, string[]? supportedTypes = null)
    {
        if (String.IsNullOrWhiteSpace(defaultType))
        {
            defaultType = Settings.FileTypeString;
        }

        if (supportedTypes is null || supportedTypes.Length == 0)
        {
            supportedTypes = Settings.FileTypes;
        }

        string path = Settings.DefaultPath;

        path += @"\" + DateAndTime.Now.ToString("yyyy-MM-dd HH-mm-ss-ffff") + "." + defaultType.ToLower();

        if (saveAs || !Directory.Exists(Settings.DefaultPath))
        {
            using var sfd = new SaveFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                CheckFileExists = false,
                DefaultExt = $"{defaultType.ToUpper()}|*.{defaultType.ToLower()}",
                Filter = Settings.FileTypes.Aggregate((a, i) => a + $"{i.ToUpper()}|*.{i.ToLower()}|") + "All Files|*.*"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            path = sfd.FileName;
        }

        return path;
    }

    private static void PublishToClipboard(Screenshot screenshot)
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

                return;
            }
            catch (Exception ex)
            {
                if (Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical | MsgBoxStyle.RetryCancel) == MsgBoxResult.Cancel)
                {
                    return;
                }
            }
        }
        while (true);
    }

    public static void Publish(PublishOptions options, params Screenshot[] screenshotes)
    {
        if (screenshotes is null || screenshotes.Length == 0)
        {
            throw new ArgumentNullException(nameof(screenshotes));
        }

        int imageNumber = (int)(options & PublishOptions.OnlyImageNumber);
        var screenshot = screenshotes[imageNumber].Image;

        if (options.HasFlag(PublishOptions.CopyImage))
        {
            PublishToClipboard(screenshot);
        }

        if (options.HasFlag(PublishOptions.SaveToFile))
        {
            PublishSaveToFile(options, screenshot);
        }
    }

    private static void PublishSaveToFile(PublishOptions options, Screenshot screenshot)
    {
        string? path = GetPath(saveAs: options.HasFlag(PublishOptions.SaveAs));

        if (path is null)
        {
            return;
        }

        static ImageFormat? imageFormat(string imagePath)
        {
            return Path.GetExtension(imagePath)[1..] switch
            {
                "Bmp" => ImageFormat.Bmp,
                "Emf" => ImageFormat.Emf,
                "Exif" => ImageFormat.Exif,
                "Gif" => ImageFormat.Gif,
                "Ico" => ImageFormat.Icon,
                "Jpeg" or "jpg" => ImageFormat.Jpeg,
                "Png" => ImageFormat.Png,
                "Tiff" => ImageFormat.Tiff,
                "Wmf" => ImageFormat.Wmf,
                _ => null,
            };
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

        if (options.HasFlag(PublishOptions.OpenFolder))
        {
            Interaction.Shell("explorer /select, \"" + path + "\"", AppWinStyle.NormalFocus);
        }
    }

    public static bool PublishMultipleFrames(PublishOptions options, IEnumerable<Screenshot> screenshotes)
    {
        if (screenshotes is null)
        {
            throw new ArgumentNullException(nameof(screenshotes));
        }

        var path = GetPath(
            saveAs: options.HasFlag(PublishOptions.SaveAs),
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
