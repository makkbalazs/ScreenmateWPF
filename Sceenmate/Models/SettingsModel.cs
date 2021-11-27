using Screenmate.MVVM;

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

        #region Wandering
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
        #endregion

        #region Following
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

        #endregion

        #region Monitoring & Warning
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
        #endregion
    }
}
