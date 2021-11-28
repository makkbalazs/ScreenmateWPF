using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Screenmate.Views;

namespace Screenmate.Animation
{
    /// <summary>
    /// Handles animation.
    /// </summary>
    public class Animator : IAnimator
    {
        #region Private fields
        CanvasWindow _canvasWindow;
        #endregion

        #region Constructors
        public Animator()
        {
            _canvasWindow = new CanvasWindow();
        }
        #endregion

        #region Methods
        public void ShowTransparentWindow()
        {
            _canvasWindow.Show();
        }

        public void ShowImage(int posx, int posy)
        {

        }

        public void moveRon(double x, double y)
        {
            _canvasWindow.Dispatcher.Invoke(() => _canvasWindow.moveRon(x, y));
        }

        public double getRonLeft()
        {
            return _canvasWindow.Dispatcher.Invoke(() => _canvasWindow.getRonLeft());
        }

        public double getRonTop()
        {
            return _canvasWindow.Dispatcher.Invoke(() => _canvasWindow.getRonTop());
        }

        public Vector convertCoords(Vector v)
        {
            return _canvasWindow.Dispatcher.Invoke(() => _canvasWindow.convertCoords(v));
        }

        public void bombScreen()
        {
            _canvasWindow.Dispatcher.Invoke(() => _canvasWindow.bombScreen());
        }
        #endregion
    }
}
