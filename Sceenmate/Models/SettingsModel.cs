using Screenmate.MVVM;
using System.Collections.Generic;

namespace Screenmate.Models
{
    /// <summary>
    /// The settings data model
    /// </summary>
    public class SettingsModel : NotfiyPropertyChanged, ISettings
    {
        #region Technical
        /// <summary>
        /// Have the values of the model been initialized?
        /// </summary>
        private volatile bool _initialized;

        /// <summary>
        /// Gets or sets if the values of the model have been initialized.
        /// </summary>
        /// <value>
        /// <c>true</c> if the values have been initialized; otherwise <c>false</c>
        /// </value>
        public bool Initialized
        {
            get { return _initialized; }
            set { SetField(ref _initialized, value); }
        }
        #endregion

        #region General
        /// <summary>
        /// Enables screenmate
        /// </summary>
        private bool _enabled;

        /// <summary>
        /// Gets or sets if the screenmate is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if screenmate is enabled; <c>otherwise false</c>
        /// </value>
        public bool Enabled
        {
            get { return _enabled; }
            set { SetField(ref _enabled, value); }
        }
        #endregion

        #region Wandering & Following
        /// <summary>
        /// The update interval of the wandering and following features in ms
        /// </summary>
        private int _wanderingAndFollowingInterval;

        /// <summary>
        /// Gets or sets the update interval of the wandering and following features in ms.
        /// </summary>
        /// <value>
        /// The update interval of the wandering and following features in ms
        /// </value>
        public int WanderingAndFollowingInterval
        {
            get { return _wanderingAndFollowingInterval; }
            set
            {
                if (value > 0)
                {
                    SetField(ref _wanderingAndFollowingInterval, value);
                }
            }
        }

        /// <summary>
        /// Enables wandering
        /// </summary>
        private bool _wanderingEnabled;

        /// <summary>
        /// Gets or sets if wandering is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if wandering is enabled; otherwise <c>false</c>
        /// </value>
        public bool WanderingEnabled
        {
            get { return _wanderingEnabled; }
            set { SetField(ref _wanderingEnabled, value); }
        }

        /// <summary>
        /// The speed of wandering in pixels per s
        /// </summary>
        private double _wanderingSpeed;

        /// <summary>
        /// Gets or sets wandering speed.
        /// </summary>
        /// <value>
        /// The speed of wandering in pixels per s
        /// </value>
        public double WanderingSpeed
        {
            get { return _wanderingSpeed; }
            set { SetField(ref _wanderingSpeed, value); }
        }

        /// <summary>
        /// enables cursor following
        /// </summary>
        private bool _followingEnabled;

        /// <summary>
        /// Gets or sets if cursor following is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if cursor following is enabled; otherwise <c>false</c>
        /// </value>
        public bool FollowingEnabled
        {
            get { return _followingEnabled; }
            set { SetField(ref _followingEnabled, value); }
        }

        /// <summary>
        /// The speed of following in pixels per s
        /// </summary>
        private double _followingSpeed;

        /// <summary>
        /// Gets or sets following speed.
        /// </summary>
        /// <value>
        /// The speed of following in pixels per s
        /// </value>
        public double FollowingSpeed
        {
            get { return _followingSpeed; }
            set { SetField(ref _followingSpeed, value); }
        }
        #endregion

        #region Entertaining
        /// <summary>
        /// The update interval of the entertainment features in ms
        /// </summary>
        private int _entertainmentInterval;

        /// <summary>
        /// Gets or sets the update interval of the entertainment features in ms.
        /// </summary>
        /// <value>
        /// The update interval of the entertainment features in ms
        /// </value>
        public int EntertainmentInterval
        {
            get { return _entertainmentInterval; }
            set
            {
                if (value > 0)
                {
                    SetField(ref _entertainmentInterval, value);
                }
            }
        }

        /// <summary>
        /// Enables entertaining
        /// </summary>
        private bool _entertainingEnabled;

        /// <summary>
        /// Gets or sets if entertaining is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if entertaining is enabled; otherwise <c>false</c>
        /// </value>
        public bool EntertainingEnabled
        {
            get { return _entertainingEnabled; }
            set { SetField(ref _entertainingEnabled, value); }
        }

        /// <summary>
        /// Enables window moving
        /// </summary>
        private bool _windowMovingEnabled;

        /// <summary>
        /// Gets or sets if window moving is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if window moving is enabled; otherwise <c>false</c>
        /// </value>
        public bool WindowMovingEnabled
        {
            get { return _windowMovingEnabled; }
            set { SetField(ref _windowMovingEnabled, value); }
        }

        /// <summary>
        /// The names of processes of which's window can be moved
        /// </summary>
        private List<string> _processesCanBeMoved;

        /// <summary>
        /// Gets or sets the names of processes of which's window can be moved.
        /// </summary>
        /// <value>
        /// The names of processes of which's window can be moved
        /// </value>
        public List<string> ProcessesCanBeMoved
        {
            get { return _processesCanBeMoved; }
            set { SetField(ref _processesCanBeMoved, value); }
        }

        /// <summary>
        /// Enables window closing
        /// </summary>
        private bool _windowClosingEnabled;

        /// <summary>
        /// Gets or sets if window closing is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if window closing is enabled; otherwise <c>false</c>
        /// </value>
        public bool WindowClosingEnabled
        {
            get { return _windowClosingEnabled; }
            set { SetField(ref _windowClosingEnabled, value); }
        }

        /// <summary>
        /// The names of processes which's window can be closed
        /// </summary>
        private List<string> _processesCanBeClosed;

        /// <summary>
        /// Gets or sets the names of processes which's window can be closed.
        /// </summary>
        /// <value>
        /// The names of processes which's window can be closed
        /// </value>
        public List<string> ProcessesCanBeClosed
        {
            get { return _processesCanBeClosed; }
            set { SetField(ref _processesCanBeClosed, value); }
        }

        /// <summary>
        /// Enables bombing
        /// </summary>
        private bool _bombingEnabled;

        /// <summary>
        /// Gets or sets if bombing is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if bombing is enabled; otherwise <c>false</c>
        /// </value>
        public bool BombingEnabled
        {
            get { return _bombingEnabled; }
            set { SetField(ref _bombingEnabled, value); }
        }

        #endregion

        #region Monitoring & Warning
        /// <summary>
        /// The update interval of the monitoring and warning features in ms
        /// </summary>
        private int _monitoringAndWarningInterval;

        /// <summary>
        /// Gets the update interval of the monitoring and warning features in ms.
        /// </summary>
        /// <value>
        /// The update interval of the monitoring and warning features in ms
        /// </value>
        public int MonitoringAndWarningInterval
        {
            get { return _monitoringAndWarningInterval; }
            set
            {
                if (value > 0)
                {
                    SetField(ref _monitoringAndWarningInterval, value);
                }
            }
        }

        /// <summary>
        /// Enables monitoring
        /// </summary>
        private bool _monitoringEnabled;

        /// <summary>
        /// Gets or sets if monitoring is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if monitoring is enabled; otherwise <c>false</c>
        /// </value>
        public bool MonitoringEnabled
        {
            get { return _monitoringEnabled; }
            set { SetField(ref _monitoringEnabled, value); }
        }

        /// <summary>
        /// Show CPU usage
        /// </summary>
        private bool _showCPUUsage;

        /// <summary>
        /// Gets or sets whether to show CPU usage.
        /// </summary>
        /// <value>
        /// <c>true</c> if CPU usage should be shown; otherwise <c>false</c>
        /// </value>
        public bool ShowCPUUsage
        {
            get { return _showCPUUsage; }
            set { SetField(ref _showCPUUsage, value); }
        }

        /// <summary>
        /// Show memory usage
        /// </summary>
        private bool _showMemoryUsage;

        /// <summary>
        /// Gets or sets whether to show memory usage.
        /// </summary>
        /// <value>
        /// <c>true</c> if memory usage should be shown; otherwise <c>false</c>
        /// </value>
        public bool ShowMemoryUsage
        {
            get { return _showMemoryUsage; }
            set { SetField(ref _showMemoryUsage, value); }
        }

        /// <summary>
        /// Enables warning
        /// </summary>
        private bool _warningEnabled;

        /// <summary>
        /// Gets or sets if warning is enabled
        /// </summary>
        /// <value>
        /// <c>true</c> if warning is enabled; otherwise <c>false</c>
        /// </value>
        public bool WarningEnabled
        {
            get { return _warningEnabled; }
            set { SetField(ref _warningEnabled, value); }
        }

        /// <summary>
        /// The CPU usage percentage above which warning should be displayed
        /// </summary>
        private double _CPUWarningThreshold;

        /// <summary>
        /// Gets or sets the CPU usage percentage above which warning should be displayed.
        /// </summary>
        /// <value>
        /// The CPU usage percentage above which warning should be displayed
        /// </value>
        public double CPUWarningThreshold
        {
            get { return _CPUWarningThreshold; }
            set { SetField(ref _CPUWarningThreshold, value); }
        }

        /// <summary>
        /// The memory usage percentage above which warning should be displayed
        /// </summary>
        private double _memoryWarningThreshold;

        /// <summary>
        /// Gets or sets the memory usage percentage above which warning should be displayed.
        /// </summary>
        /// <value>
        /// The memory usage percentage above which warning should be displayed
        /// </value>
        public double MemoryWarningThreshold
        {
            get { return _memoryWarningThreshold; }
            set { SetField(ref _memoryWarningThreshold, value); }
        }
        #endregion
    }
}
