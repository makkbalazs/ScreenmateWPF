namespace Screenmate.Animation
{
    /// <summary>
    /// Handles animation.
    /// </summary>
    public interface IAnimator
    {
        void ShowTransparentWindow();

        void ShowImage(int posx, int posy);

        void moveRon(double x, double y);
    }
}
