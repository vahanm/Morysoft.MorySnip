using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class DpiHelper
{
    [DllImport("user32.dll")]
    static extern IntPtr MonitorFromPoint(Point pt, uint dwFlags);

    [DllImport("shcore.dll")]
    static extern int GetDpiForMonitor(IntPtr hmonitor, int dpiType, out uint dpiX, out uint dpiY);

    const int MDT_EFFECTIVE_DPI = 0; // DPI setting we are interested in

    [DllImport("user32.dll")]
    static extern bool SetProcessDpiAwarenessContext(int dpiFlag);

    // Per monitor DPI-aware flag
    const int DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = -4;

    public static void SetDpiAwareness()
    {
        SetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
    }

    public static float GetScaleFactorForScreen(Screen screen)
    {
        // Get the handle of the monitor
        IntPtr hMonitor = MonitorFromPoint(screen.Bounds.Location, 2 /*MONITOR_DEFAULTTONEAREST*/);

        // Get DPI for the monitor
        var r = GetDpiForMonitor(hMonitor, MDT_EFFECTIVE_DPI, out var dpiX, out var dpiY);

        return dpiX / 96.0f; // 96 DPI is standard 100% scaling
    }

    public static void Print()
    {
        var s = "";

        foreach (Screen screen in Screen.AllScreens)
        {
            float scaleFactor = DpiHelper.GetScaleFactorForScreen(screen);
            Rectangle screenBounds = screen.Bounds;
            var scaledBounds = new Rectangle(
                (int)(screenBounds.X * scaleFactor),
                (int)(screenBounds.Y * scaleFactor),
                (int)(screenBounds.Width * scaleFactor),
                (int)(screenBounds.Height * scaleFactor)
            );

            // Use scaledBounds for snipping on this screen
            s += $"""
                Screen: {screen}
                Scale Factor: {scaleFactor}
                Scaled Bounds: {scaledBounds}


                """;
        }
    }
}
