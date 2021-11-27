using Screenmate.MVVM;
using Screenmate.Services;

namespace Screenmate.Controllers
{
    /// <summary>
    /// Controls screenmate character.
    /// </summary>
    public class CharacterController : ControllerBase
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
                if(settings.WanderingEnabled)
                {

                }
                if(settings.FollowingEnabled)
                {

                }
            }
        }
        #endregion
    }
}
