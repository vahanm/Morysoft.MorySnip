using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public partial class DpiHelper
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct MarshalPoint
    {
        public int X { get; set; }

        public int Y { get; set; }

        public static implicit operator MarshalPoint(Point point) => new() { X = point.X, Y = point.Y };
    }

    [LibraryImport("user32.dll")]
    private static partial IntPtr MonitorFromPoint(MarshalPoint pt, uint dwFlags);

    [LibraryImport("shcore.dll")]
    private static partial int GetDpiForMonitor(IntPtr hmonitor, int dpiType, out uint dpiX, out uint dpiY);

    private const int MDT_EFFECTIVE_DPI = 0; // DPI setting we are interested in

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool SetProcessDpiAwarenessContext(int dpiFlag);

    // Per monitor DPI-aware flag
    private const int DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = -4;

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
