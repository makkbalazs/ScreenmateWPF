using System;
using System.Diagnostics;
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
        #region Private fields
        /// <summary>
        /// The previous position of the cursor
        /// </summary>
        private Win32Interop.Point _previousCursorPos;
        /// <summary>
        /// The current position of the cursor
        /// </summary>
        private Win32Interop.Point _currentCursorPos;

        int afk;
        Vector ranDir;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates new instance of <see cref="CharacterController"/>.
        /// </summary>
        /// <param name="interval">Timer interval in ms.</param>
        public CharacterController(int interval = 10) : base(interval)
        {
            SettingsService.InstanceChanged += SettingsService_InstanceChanged;
            afk = 0;
        }
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
                if(settings.FollowingEnabled && afk < 900)
                {
                    FollowCursor();
                }
            }
        }

        /// <summary>
        /// Handles instance changed event of the settings service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsService_InstanceChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SettingsService.Instance.PropertyChanged += UpdateTimerInterval;
            UpdateTimerInterval(sender, e);
        }

        /// <summary>
        /// Updates timer interval.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimerInterval(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Interval = SettingsService.Instance.WanderingAndFollowingInterval;
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

                if (_currentCursorPos.X != _previousCursorPos.X && _currentCursorPos.Y != _previousCursorPos.Y) afk = 0;
            }
        }

        /// <summary>
        /// Wander logic
        /// </summary>
        private void Wander()
        {
            if (afk == 1000)
            {
                Random rnd = new Random();
                ranDir = new Vector(rnd.Next(100) - 50, rnd.Next(100) - 50);
                ranDir.Normalize();
            }
            if (afk >= 1000 && afk <= 1100){
                Vector r = new Vector(AnimationService.Instance.getRonLeft(), AnimationService.Instance.getRonTop());
                r = AnimationService.Instance.convertCoords(r);
                if (r.X + 4 * ranDir.X > 0 && r.Y + 4 * ranDir.Y > 0 && r.X + 4 * ranDir.X < 1920 - 120 && r.Y + 4 * ranDir.Y < 1080 - 160)
                    AnimationService.Instance.moveRon(4 * ranDir.X, 4 * ranDir.Y);
                else
                {
                    afk = 900;
                    AnimationService.Instance.moveRon(0, 0);
                }
            }
            if (afk == 1100)
            {
                afk = 900;
                AnimationService.Instance.moveRon(0, 0);
            }
            afk++;
        }

        /// <summary>
        /// Cursor following logic
        /// </summary>
        private void FollowCursor()
        {
            Vector r = new Vector(AnimationService.Instance.getRonLeft(), AnimationService.Instance.getRonTop());
            r = AnimationService.Instance.convertCoords(r);
            Vector n = new Vector(_currentCursorPos.X - 60 - r.X, _currentCursorPos.Y - 80 - r.Y);
            if (Math.Abs(n.X) > 60 || Math.Abs(n.Y) > 80)
            {
                n.Normalize();
                AnimationService.Instance.moveRon(4*n.X, 4*n.Y);
            }
            else AnimationService.Instance.moveRon(0, 0);
        }
        #endregion
    }
}
