using Sceenmate.Win32Interop;
using Screenmate.MVVM;
using Screenmate.Services;

namespace Screenmate.Controllers
{
    /// <summary>
    /// Controls screenmate character.
    /// </summary>
    public class CharacterController : ControllerBase
    {
        #region
        /// <summary>
        /// The previous position of the cursor
        /// </summary>
        private Point _previousCursorPos;
        /// <summary>
        /// The current position of the cursor
        /// </summary>
        private Point _currentCursorPos;
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        protected override async void Update()
        {
            ISettings settings = SettingsService.Instance;
            if (settings.Enabled)
            {
                UpdateCursorPos();
                if(settings.WanderingEnabled)
                {
                    Wander();
                }
                if(settings.FollowingEnabled)
                {
                    FollowCursor();
                }
            }
        }

        /// <summary>
        /// Updates cursor position values.
        /// </summary>
        private void UpdateCursorPos()
        {
            Point cursorPos = new Point();
            if (Win32Interop.GetCursorPos(out cursorPos))
            {
                System.Console.WriteLine(cursorPos.X.ToString() + "; " + cursorPos.Y.ToString() + '\n');
                _previousCursorPos = _currentCursorPos;
                _currentCursorPos = cursorPos;
            }
        }

        private void Wander()
        {

        }

        private void FollowCursor()
        {
            
        }
        #endregion
    }
}
