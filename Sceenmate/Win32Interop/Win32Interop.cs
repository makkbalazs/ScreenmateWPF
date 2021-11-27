using System.Runtime.InteropServices;

namespace Sceenmate.Win32Interop
{
    /// <summary>
    /// Provides methods for Win32Interop.
    /// </summary>
    public static class Win32Interop
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out Point lpPoint);
    }
}
