using Sceenmate.Views;
using System.Windows;

namespace Screenmate.Animation
{
    /// <summary>
    /// Handles animation.
    /// </summary>
    public class Animator : IAnimator
    {
        #region Private fields
        Window _canvasWindow;
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
        #endregion
    }
}
