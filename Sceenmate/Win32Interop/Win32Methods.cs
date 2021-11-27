﻿using System;
using System.Runtime.InteropServices;

namespace Screenmate.Win32Interop
{
    /// <summary>
    /// Provides methods for Win32Interop.
    /// </summary>
    public static class Win32Methods
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    }
}