using Screenmate.MVVM;
using Screenmate.Services;

namespace Screenmate.Controllers
{
    /// <summary>
    /// Controls monitoring and warning features of the screenmate.
    /// </summary>
    public class MonitoringAndWarningController : ControllerBase
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        protected override async void Update()
        {
            ISettings settings = SettingsService.Instance;
            if (settings.Enabled)
            {
                if (settings.MonitoringEnabled)
                {

                }
                if (settings.WanderingEnabled)
                {

                }
            }
        }
        #endregion
    }
}
