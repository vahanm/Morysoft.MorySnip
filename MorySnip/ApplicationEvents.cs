using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip.My
{
    // The following events are available for MyApplication:
    // 
    // Startup: Raised when the application starts, before the startup form is created.
    // Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    // UnhandledException: Raised if the application encounters an unhandled exception.
    // StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    // NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    internal partial class MyApplication
    {
        /*
        private void ApplyJumpList()
        {
            var jl = new System.Windows.Shell.JumpList();
            string dir = MyProject.Application.Info.DirectoryPath;
            string ass = MyProject.Application.Info.AssemblyName;
            string exe = string.Format(@"{0}\{1}.exe", dir, ass);

            void addJumpTask(string Title, string Command, string Icon, string CustomCategory)
            {
                var jt = new System.Windows.Shell.JumpTask()
                {
                    Title = Title,
                    ApplicationPath = exe,
                    Arguments = Command,
                    IconResourcePath = string.IsNullOrWhiteSpace(Icon) ? exe : string.Format(@"{0}\Resources\JobIcons\{1}.ico", dir, Icon),
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

        private void MyApplication_Shutdown(object sender, EventArgs e)
        {
            Helpers.DeleteAllTempFiles();
        }

        private void MyApplication_Startup(object sender, Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
        {
            Interaction.SaveSetting(MyProject.Application.Info.CompanyName, "Global", MyProject.Application.Info.AssemblyName.Replace(" ", "_") + "_Version", MyProject.Application.Info.Version.ToString());
            Interaction.SaveSetting(MyProject.Application.Info.CompanyName, "Global", MyProject.Application.Info.AssemblyName.Replace(" ", "_") + "_Path", MyProject.Application.Info.DirectoryPath);
            Interaction.SaveSetting(MyProject.Application.Info.CompanyName, "Global", MyProject.Application.Info.AssemblyName.Replace(" ", "_") + "_LastRun", DateAndTime.Now.ToString("hh:mm:ss dd.MM.yyyy"));

            Settings.SetDefaultSettings();

            Thread.CurrentThread.CurrentUICulture = Settings.CultureCode; // CultureInfo.CurrentCulture 'New CultureInfo("hy-am")

            this.ApplyJumpList();

            if (e.CommandLine.Count > 0)
            {
                var tmp = new Form_Save_Base();

                if (e.CommandLine.Count == 1)
                {
                    string com = e.CommandLine[0].Trim();

                    switch (com)
                    {
                        case "--fullscreen":
                            {
                                tmp.Snip_FullScreen();
                                break;
                            }

                        case "--fullscreen[0]":
                            {
                                tmp.Snip_Screen(0);
                                break;
                            }

                        case "--fullscreen[1]":
                            {
                                tmp.Snip_Screen(1);
                                break;
                            }

                        case "--fullscreen[2]":
                            {
                                tmp.Snip_Screen(2);
                                break;
                            }

                        case "--fullscreen[3]":
                            {
                                tmp.Snip_Screen(3);
                                break;
                            }

                        case "--clipboard":
                            {
                                tmp.Snip_FromClipboard();
                                break;
                            }

                        case "--file":
                            {
                                tmp.Snip_FromFile();
                                break;
                            }
                    }
                }

                foreach (string path in e.CommandLine)
                {
                    var nomralizedPath = path.Trim().Trim('"', '\'');

                    try
                    {
                        string localPath = new Uri(nomralizedPath).LocalPath;
                        Screenshot tempImage = Image.FromFile(localPath);

                        tempImage.OriginalPath = localPath;
                        tmp.Images.Add(tempImage);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                if (tmp.Images.Count > 0 | tmp.Visible)
                {
                    MyProject.Application.MainForm = tmp;
                }
            }
        }

        private void MyApplication_StartupNextInstance(object sender, Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs e)
        {
        }
        */
    }
}


