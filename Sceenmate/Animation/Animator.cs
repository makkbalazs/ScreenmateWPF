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
            _canvasWindow.Show();
        }
        #endregion

        #region Methods
        public void ShowImage(int posx, int posy)
        {

        }
        #endregion
    }
}
