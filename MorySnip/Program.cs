using System;
using System.Windows.Forms;

namespace Morysoft.MorySnip;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        DpiHelper.SetDpiAwareness();

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FormSnippingTool());
    }
}
