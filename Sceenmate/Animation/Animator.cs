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
        #endregion
    }
}
