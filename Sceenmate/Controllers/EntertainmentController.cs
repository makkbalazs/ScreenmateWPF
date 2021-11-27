using Screenmate.MVVM;
using Screenmate.Services;

namespace Screenmate.Controllers
{
    /// <summary>
    /// Controls entertaining features of the screenmate
    /// </summary>
    public class EntertainmentController : ControllerBase
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        protected override async void Update()
        {
            ISettings settings = SettingsService.Instance;
            if(settings.Enabled && settings.EntertainingEnabled)
            {

            }
        }
        #endregion
    }
}
