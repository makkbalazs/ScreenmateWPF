namespace Screenmate.Controllers
{
    /// <summary>
    /// Base interface for controllers.
    /// </summary>
    public interface IControllerBase
    {
        /// <summary>
        /// Starts controller.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops controller.
        /// </summary>
        void Stop();
    }
}
