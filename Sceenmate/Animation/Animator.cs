using System.Windows;
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

        public void showMessage(string message)
        {
            _canvasWindow.Dispatcher.Invoke(() => _canvasWindow.showMessage(message));
        }

        public void showData(string data)
        {
            _canvasWindow.Dispatcher.Invoke(() => _canvasWindow.showData(data));
        }

        public void hideData()
        {
            _canvasWindow.Dispatcher.Invoke(() => _canvasWindow.hideData());
        }

        public void showRon()
        {
            _canvasWindow.Dispatcher.Invoke(() => _canvasWindow.showRon());
        }

        public void hideRon()
        {
            _canvasWindow.Dispatcher.Invoke(() => _canvasWindow.hideRon());
        }
        #endregion
    }
}
