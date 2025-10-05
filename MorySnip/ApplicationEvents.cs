using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using Morysoft.MorySnip.Classes;
using Morysoft.MorySnip.Modules;
using JumpList = Microsoft.WindowsAPICodePack.Taskbar.JumpList;

namespace Morysoft.MorySnip;

internal static class ApplicationEvents
{
    public static void Shutdown() => Helpers.DeleteAllTempFiles();

    public static void ApplyJumpList(Form form)
    {
        var exe = Application.ExecutablePath;
        var dir = Path.GetDirectoryName(exe)!;

        // Create or get jump list
        var jl = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, form.Handle);

        // Clear existing
        jl.ClearAllUserTasks();

        void addJumpTask(string title, string command, string icon, string customCategory)
        {
            var iconPath = String.IsNullOrWhiteSpace(icon)
                ? exe
                : Path.Combine(dir, "Resources", "JobIcons", icon + ".ico");

            var jt = new JumpListLink(exe, title)
            {
                Arguments = command,
                IconReference = new IconReference(iconPath, 0)
            };

            jl.AddUserTasks(jt);
        }

        // Capture options
        addJumpTask("Cut from screen", "", "", "Capture");

        if (Screen.AllScreens.Length == 1)
        {
            addJumpTask("Capture full screen", "--fullscreen", "Desktop", "Capture");
        }
        else
        {
            addJumpTask("Capture all screens", "--fullscreen", "Desktop", "Capture");

            for (var i = 0; i < Screen.AllScreens.Length; i++)
            {
                addJumpTask($"Capture screen {i + 1}", $"--fullscreen[{i}]", "Desktop", "Capture");
            }
        }

        addJumpTask("From clipboard", "--clipboard", "Clipboard", "Capture");
        addJumpTask("From file", "--file", "File", "Capture");

        // Add standard recent items category
        //jl.AddKnownCategory(KnownDestinationCategory.Recent);

        // Commit changes
        jl.Refresh();
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
