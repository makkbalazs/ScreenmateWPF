using Screenmate.MVVM;
using Screenmate.Services;
using System.Diagnostics;

namespace Screenmate.Controllers
{
    /// <summary>
    /// Controls monitoring and warning features of the screenmate.
    /// </summary>
    public class MonitoringAndWarningController : ControllerBase
    {
        #region Private fields
        /// <summary>
        /// CPU usage percent
        /// </summary>
        private double _CPUUsage;
        /// <summary>
        /// Memory usage percent
        /// </summary>
        private double _memoryUsage;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates new instance of <see cref="MonitoringAndWarningController"/>.
        /// </summary>
        /// <param name="interval">Timer interval in ms.</param>
        public MonitoringAndWarningController(int interval = 2000) : base(interval)
        {
            SettingsService.InstanceChanged += SettingsService_InstanceChanged;
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
                if (settings.MonitoringEnabled)
                {
                    UpdateUsageStatistics();
                    if(settings.ShowCPUUsage)
                    {
                        //AnimationService.ShowCPUUsage(_CPUUsage);
                    }
                    if(settings.ShowMemoryUsage)
                    {
                        //AnimationService.ShowMemoryUsage(_memoryUsage);
                    }
                }
                if (settings.WarningEnabled)
                {
                    if(_CPUUsage > settings.CPUWarningThreshold)
                    {
                        //Warn
                    }
                    if(_memoryUsage > settings.MemoryWarningThreshold)
                    {
                        //Warn
                    }
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
            Interval = SettingsService.Instance.MonitoringAndWarningInterval;
        }

        /// <summary>
        /// Gets current usage statistics.
        /// </summary>
        private void UpdateUsageStatistics()
        {
            Process[] processes = Process.GetProcesses();
            double CPUUsage = 0.0, memoryUsage = 0.0;
            foreach(Process process in processes)
            {
                
            }
        }
        #endregion
    }
}
