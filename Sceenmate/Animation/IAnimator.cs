using System.Windows;

namespace Screenmate.Animation
{
    /// <summary>
    /// Handles animation.
    /// </summary>
    public interface IAnimator
    {
        void ShowTransparentWindow();

        void moveRon(double x, double y);

        double getRonLeft();

        double getRonTop();

        Vector convertCoords(Vector v);

        void bombScreen();

        void showMessage(string message);

        void showData(string data);

        void hideData();

        void showRon();

        void hideRon();
    }
}
