using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Morysoft.MorySnip.Classes;
using Morysoft.MorySnip.Modules;

namespace Morysoft.MorySnip;

internal static class ApplicationEvents
{
    public static void Shutdown() => Helpers.DeleteAllTempFiles();

    private static void ApplyJumpList()
    {
        //var jl = new System.Windows.Shell.JumpList();
        //string exe = Application.ExecutablePath;
        //string dir = System.IO.Path.GetDirectoryName(exe);

        //void addJumpTask(string title, string command, string icon, string customCategory)
        //{
        //    var jt = new System.Windows.Shell.JumpTask()
        //    {
        //        Title = title,
        //        ApplicationPath = exe,
        //        Arguments = command,
        //        IconResourcePath = String.IsNullOrWhiteSpace(icon) ? exe : String.Format(@"{0}\Resources\JobIcons\{1}.ico", dir, icon),
        //        IconResourceIndex = 0
        //    };

        //    // If Not String.IsNullOrWhiteSpace(CustomCategory) Then
        //    // jt.CustomCategory = CustomCategory
        //    // End If

        //    jl.JumpItems.Add(jt);
        //};

        //addJumpTask("Cut from screen", "", "", "Capture");

        //if (Screen.AllScreens.Length == 1)
        //{
        //    addJumpTask("Capture full screen", "--fullscreen", "Desktop", "Capture");
        //}
        //else if (Screen.AllScreens.Length > 1)
        //{
        //    addJumpTask("Capture all screens", "--fullscreen", "Desktop", "Capture");

        //    for (int i = 0, loopTo = Screen.AllScreens.Length - 1; i <= loopTo; i++)
        //    {
        //        addJumpTask("Capture screen " + Conversions.ToString(i + 1), "--fullscreen[" + Conversions.ToString(i) + "]", "Desktop", "Capture");
        //    }
        //}

        //addJumpTask("From clipboard", "--clipboard", "Clipboard", "Capture");
        //addJumpTask("From file", "--file", "File", "Capture");

        //jl.ShowRecentCategory = true;

        //jl.Apply();
    }

    private static FormEdit FromJumpList(string com)
    {
        var tmp = new FormEdit();

        switch (com)
        {
            case "--fullscreen":
                {
                    tmp.Screenshot = Snipper.AllScreens().First();
                    break;
                }

            case "--fullscreen[0]":
                {
                    tmp.Screenshot = Snipper.SnipScreen(0).First();
                    break;
                }

            case "--fullscreen[1]":
                {
                    tmp.Screenshot = Snipper.SnipScreen(1).First();
                    break;
                }

            case "--fullscreen[2]":
                {
                    tmp.Screenshot = Snipper.SnipScreen(2).First();
                    break;
                }

            case "--fullscreen[3]":
                {
                    tmp.Screenshot = Snipper.SnipScreen(3).First();
                    break;
                }

            case "--clipboard":
                {
                    tmp.Screenshot = Snipper.FromClipboard().First();
                    break;
                }

            case "--file":
                {
                    tmp.Screenshot = Snipper.FromFiles().First();
                    break;
                }
        }

        return tmp;
    }

    private static Form FromPath(string[] args)
    {
        var tmp = new FormEdit();

        foreach (var path in args)
        {
            var nomralizedPath = path.Trim().Trim('"', '\'');

            try
            {
                var localPath = new Uri(nomralizedPath).LocalPath;
                Screenshot tempImage = Image.FromFile(localPath);

                tempImage.OriginalPath = localPath;
                tmp.Screenshot = tempImage;
            }
            catch
            {
            }
        }

        return tmp;
    }

    public static Form Startup(string[] args)
    {
        Interaction.SaveSetting(Application.CompanyName, "Global", Application.ProductName.Replace(" ", "_") + "_Version", Application.ProductVersion);
        Interaction.SaveSetting(Application.CompanyName, "Global", Application.ProductName.Replace(" ", "_") + "_LastRun", DateAndTime.Now.ToString("hh:mm:ss dd.MM.yyyy"));

        Settings.SetDefaultSettings();

        Thread.CurrentThread.CurrentUICulture = Settings.CultureCode; // CultureInfo.CurrentCulture 'New CultureInfo("hy-am")

        ApplyJumpList();

        if (
            args.Length == 1
            && FromJumpList(args[0].Trim()) is FormEdit fromJumpList
            && fromJumpList.Screenshot?.Image is not null
        )
        {
            return fromJumpList;
        }

        if (args.Length > 0 && FromPath(args) is Form formPath)
        {
            return formPath;
        }

        return new FormSnippingTool();
    }
}
