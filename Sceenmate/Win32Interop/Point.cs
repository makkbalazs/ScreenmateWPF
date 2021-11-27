using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sceenmate.Win32Interop
{
    /// <summary>
    /// Point struct for Win32 interop
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        #region Fields
        public int X;
        public int Y;
        #endregion

        #region Constructor
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion

        #region Operators
        public static implicit operator System.Drawing.Point(Point p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }

        public static implicit operator Point(System.Drawing.Point p)
        {
            return new Point(p.X, p.Y);
        }
        #endregion
    }
}
