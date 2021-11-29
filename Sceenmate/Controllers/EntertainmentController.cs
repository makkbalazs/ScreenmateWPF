using Screenmate.MVVM;
using Screenmate.Services;
using Screenmate.Win32Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Screenmate.Controllers
{
    /// <summary>
    /// Controls entertaining features of the screenmate
    /// </summary>
    public class EntertainmentController : ControllerBase
    {
        /// <summary>
        /// Window handling types
        /// </summary>
        private enum WindowHandlingType
        {
            Move,
            Close
        }

        #region Private fields
        /// <summary>
        /// The processess
        /// </summary>
        private List<Process> _processes = null;
        /// <summary>
        /// Random generator
        /// </summary>
        private Random _random;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates new instance of <see cref="EntertainmentController"/>.
        /// </summary>
        /// <param name="interval">Timer interval in ms.</param>
        public EntertainmentController(int interval = 600000) : base(interval)
        {
            SettingsService.InstanceChanged += SettingsService_InstanceChanged;
            _random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        protected override async void Update()
        {
            ISettings settings = SettingsService.Instance;
            if (settings.Enabled && settings.EntertainingEnabled)
            {
                _processes = new List<Process>(Process.GetProcesses().Where(p => p.MainWindowHandle != IntPtr.Zero));
                if(settings.WindowMovingEnabled)
                {
                    MoveWindow();
                }
                if(settings.WindowClosingEnabled && _random.Next() % 7 == 0)
                {
                    CloseWindow();
                }
                if(settings.BombingEnabled && _random.Next() % 11 == 0)
                {
                    Bomb();
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
            Interval = SettingsService.Instance.EntertainmentInterval;
        }

        /// <summary>
        /// Selects a process from the list that is suitable for the <paramref name="windowHandlingType"/>
        /// </summary>
        /// <param name="windowHandlingType"></param>
        /// <returns>The selected process; null if no process was found suitable</returns>
        Process SelectProcess(WindowHandlingType windowHandlingType)
        {
            Process result = null;
            ISettings settings = SettingsService.Instance;
            switch (windowHandlingType)
            {
                case WindowHandlingType.Move:
                    var moveableProcesses = _processes.Where(p => settings.ProcessesCanBeMoved?.Contains(p.ProcessName) ?? false);
                    if (moveableProcesses.Count() > 0)
                    {
                        result = moveableProcesses.ElementAtOrDefault(_random.Next(0, moveableProcesses.Count() - 1));
                    }
                    break;
                case WindowHandlingType.Close:
                    var closeableProcesses = _processes.Where(p => settings.ProcessesCanBeClosed?.Contains(p.ProcessName) ?? false);
                    if (closeableProcesses.Count() > 0)
                    {
                        result = closeableProcesses.ElementAtOrDefault(_random.Next(0, closeableProcesses.Count() - 1));
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// Selects a window and moves it.
        /// </summary>
        void MoveWindow()
        {
            Process process = SelectProcess(WindowHandlingType.Move);
            if(process != null && process.MainWindowHandle != null)
            {
                int x = _random.Next(0, 1920 / 2);
                int y = _random.Next(0, 1080 / 2);
                Win32Methods.SetWindowPos(process.MainWindowHandle, Win32Constants.HWND_NOTOPMOST, x, y, 0, 0, Win32Constants.SWP_NOZORDER | Win32Constants.SWP_NOSIZE | Win32Constants.SWP_SHOWWINDOW);
            }
        }

        /// <summary>
        /// Selects a window and closes it.
        /// </summary>
        void CloseWindow()
        {
            Process process = SelectProcess(WindowHandlingType.Close);
            process.CloseMainWindow();
        }

        void Bomb()
        {
            AnimationService.Instance.bombScreen();
        }
        #endregion
    }
}
