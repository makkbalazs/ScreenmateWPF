using System.Runtime.InteropServices;

namespace Screenmate.Win32Interop
{
    /// <summary>
    /// Point struct for Win32 interop
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        #region Fields
        public int X;
        public int Y;
        #endregion

        #region Constructor
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion

        #region Operators
        public static implicit operator System.Drawing.Point(POINT p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }

        public static implicit operator POINT(System.Drawing.Point p)
        {
            return new POINT(p.X, p.Y);
        }
        #endregion
    }
}
