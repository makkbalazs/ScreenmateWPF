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
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        protected override async void Update()
        {
            ISettings settings = SettingsService.Instance;
            Interval = settings.MonitoringAndWarningInterval;
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
