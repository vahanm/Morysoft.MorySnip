using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip.My
{
    internal static class ApplicationEvents
    {
        private static void ApplyJumpList()
        {
            var jl = new System.Windows.Shell.JumpList();
            string exe = Application.ExecutablePath;
            string dir = System.IO.Path.GetDirectoryName(exe);

            void addJumpTask(string title, string command, string icon, string customCategory)
            {
                var jt = new System.Windows.Shell.JumpTask()
                {
                    Title = title,
                    ApplicationPath = exe,
                    Arguments = command,
                    IconResourcePath = String.IsNullOrWhiteSpace(icon) ? exe : string.Format(@"{0}\Resources\JobIcons\{1}.ico", dir, icon),
                    IconResourceIndex = 0
                };

                // If Not String.IsNullOrWhiteSpace(CustomCategory) Then
                // jt.CustomCategory = CustomCategory
                // End If

                jl.JumpItems.Add(jt);
            };

            addJumpTask("Cut from screen", "", "", "Capture");

            if (Screen.AllScreens.Length == 1)
            {
                addJumpTask("Capture full screen", "--fullscreen", "Desktop", "Capture");
            }
            else if (Screen.AllScreens.Length > 1)
            {
                addJumpTask("Capture all screens", "--fullscreen", "Desktop", "Capture");

                for (int i = 0, loopTo = Screen.AllScreens.Length - 1; i <= loopTo; i++)
                {
                    addJumpTask("Capture screen " + Conversions.ToString(i + 1), "--fullscreen[" + Conversions.ToString(i) + "]", "Desktop", "Capture");
                }
            }

            addJumpTask("From clipboard", "--clipboard", "Clipboard", "Capture");
            addJumpTask("From file", "--file", "File", "Capture");

            jl.ShowRecentCategory = true;

            jl.Apply();
        }

        public static void Shutdown() => Helpers.DeleteAllTempFiles();

        public static Form Startup(string[] args)
        {
            Interaction.SaveSetting(Application.CompanyName, "Global", Application.ProductName.Replace(" ", "_") + "_Version", Application.ProductVersion);
            Interaction.SaveSetting(Application.CompanyName, "Global", Application.ProductName.Replace(" ", "_") + "_LastRun", DateAndTime.Now.ToString("hh:mm:ss dd.MM.yyyy"));

            Settings.SetDefaultSettings();

            Thread.CurrentThread.CurrentUICulture = Settings.CultureCode; // CultureInfo.CurrentCulture 'New CultureInfo("hy-am")

            ApplicationEvents.ApplyJumpList();

            if (args.Length > 0)
            {
                var tmp = new FormSaveBase();

                if (args.Length == 1)
                {
                    string com = args[0].Trim();

                    switch (com)
                    {
                        case "--fullscreen":
                            {
                                tmp.SnipFullScreen();
                                break;
                            }

                        case "--fullscreen[0]":
                            {
                                tmp.SnipScreen(0);
                                break;
                            }

                        case "--fullscreen[1]":
                            {
                                tmp.SnipScreen(1);
                                break;
                            }

                        case "--fullscreen[2]":
                            {
                                tmp.SnipScreen(2);
                                break;
                            }

                        case "--fullscreen[3]":
                            {
                                tmp.SnipScreen(3);
                                break;
                            }

                        case "--clipboard":
                            {
                                tmp.SnipFromClipboard();
                                break;
                            }

                        case "--file":
                            {
                                tmp.SnipFromFile();
                                break;
                            }
                    }
                }

                foreach (string path in args)
                {
                    var nomralizedPath = path.Trim().Trim('"', '\'');

                    try
                    {
                        string localPath = new Uri(nomralizedPath).LocalPath;
                        Screenshot tempImage = Image.FromFile(localPath);

                        tempImage.OriginalPath = localPath;
                        tmp.Screenshotes.Add(tempImage);
                    }
                    catch
                    {
                    }
                }

                if (tmp.Screenshotes.Count > 0 | tmp.Visible)
                {
                    return tmp;
                }
            }

            return new FormSnippingTool();
        }
    }
}
