using System;
using System.Windows;
using Screenmate.MVVM;
using Screenmate.Services;
using Screenmate.Win32Interop;

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
        private Win32Interop.Point _previousCursorPos;
        /// <summary>
        /// The current position of the cursor
        /// </summary>
        private Win32Interop.Point _currentCursorPos;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates new instance of <see cref="CharacterController"/>.
        /// </summary>
        /// <param name="interval">Timer interval in ms.</param>
        public CharacterController(int interval = 100) : base(interval)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        protected override async void Update()
        {
            ISettings settings = SettingsService.Instance;
            Interval = settings.WanderingAndFollowingInterval;
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
            Win32Interop.Point cursorPos = new Win32Interop.Point();
            if (Win32Methods.GetCursorPos(out cursorPos))
            {
                System.Console.WriteLine(cursorPos.X.ToString() + "; " + cursorPos.Y.ToString() + '\n');
                _previousCursorPos = _currentCursorPos;
                _currentCursorPos = cursorPos;
            }
        }

        /// <summary>
        /// Wander logic
        /// </summary>
        private void Wander()
        {
            //Nem szeretek kódba írni, de ide kell valami logika, hogy ha a following is be van kapcsolva, akkor
            //mi legyen. Ha kicsit mozdult a kurzor/nem mozdult, akkor vándoroljon? Vagy legyen a settingsben kizáró
            //a wander és a follow?
        }

        /// <summary>
        /// Cursor following logic
        /// </summary>
        private void FollowCursor()
        {
            if (_previousCursorPos.X != _currentCursorPos.X && _previousCursorPos.Y != _currentCursorPos.Y)
            {
                if (Math.Abs(_currentCursorPos.X) > 60 || Math.Abs(_currentCursorPos.Y) > 80)
                {
                    Vector n = new Vector (_currentCursorPos.X, _currentCursorPos.Y);
                    n.Normalize();
                    AnimationService.Instance.moveRon(n.X, n.Y);
                }
                else AnimationService.Instance.moveRon(0, 0);
            }
            else AnimationService.Instance.moveRon(0, 0);
        }
        #endregion
    }
}
