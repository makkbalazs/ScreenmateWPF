using System.Threading.Tasks;
using System.Timers;

namespace Screenmate.Controllers
{
    /// <summary>
    /// Base class for controllers.
    /// </summary>
    public abstract class ControllerBase : IControllerBase
    {
        #region Private fields
        /// <summary>
        /// The timer
        /// </summary>
        Timer _timer;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="interval">Timer interval in ms.</param>
        public ControllerBase(int interval = 10)
        {
            _timer = new Timer(interval);
            _timer.Elapsed += Tick;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Starts controller.
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }

        
        /// <summary>
        /// Handles timer elapsed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, ElapsedEventArgs e)
        {
            Task.Run(Update);
        }

        /// <summary>
        /// Calls methods that need to be called in every loop.
        /// </summary>
        protected abstract void Update();

        /// <summary>
        /// Stops the controller.
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
        }
        #endregion
    }
}
