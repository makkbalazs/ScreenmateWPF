using System.Collections.Generic;

namespace Screenmate.MVVM
{
    /// <summary>
    /// Interface to access settings.
    /// </summary>
    public interface ISettings
    {
        #region Technical
        /// <summary>
        /// Gets if the values of the model have been initialized.
        /// </summary>
        /// <value>
        /// <c>true</c> if the values have been initialized; otherwise <c>false</c>
        /// </value>
        bool Initialized { get; }
        #endregion

        #region General
        /// <summary>
        /// Gets if the screenmate is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if screenmate is enabled; <c>otherwise false</c>
        /// </value>
        bool Enabled { get; }
        #endregion

        #region Wandering &  Following
        /// <summary>
        /// Gets the update interval of the wandering and following features in ms.
        /// </summary>
        /// <value>
        /// The update interval of the wandering and following features in ms
        /// </value>
        public int WanderingAndFollowingInterval { get; }

        /// <summary>
        /// Gets if wandering is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if wandering is enabled; otherwise <c>false</c>
        /// </value>
        bool WanderingEnabled { get; }

        /// <summary>
        /// Gets wandering speed.
        /// </summary>
        /// <value>
        /// The speed of wandering in pixels per s
        /// </value>
        double WanderingSpeed { get; }

        /// <summary>
        /// Gets if cursor following is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if cursor following is enabled; otherwise <c>false</c>
        /// </value>
        bool FollowingEnabled { get; }

        /// <summary>
        /// Gets following speed.
        /// </summary>
        /// <value>
        /// SThe speed of following in pixels per s
        /// </value>
        double FollowingSpeed { get; }
        #endregion

        #region Entertaining
        /// <summary>
        /// Gets the update interval of the entertainment features in ms.
        /// </summary>
        /// <value>
        /// The update interval of the entertainment features in ms
        /// </value>
        public int EntertainmentInterval { get; }

        /// <summary>
        /// Gets if entertaining is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if entertaining is enabled; otherwise <c>false</c>
        /// </value>
        bool EntertainingEnabled { get; }

        /// <summary>
        /// Gets if window moving is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if window moving is enabled; otherwise <c>false</c>
        /// </value>
        bool WindowMovingEnabled { get; }

        /// <summary>
        /// Gets the names of processes of which's window can be moved.
        /// </summary>
        /// <value>
        /// The names of processes of which's window can be moved
        /// </value>
        List<string> ProcessesCanBeMoved { get; }

        /// <summary>
        /// Gets if window closing is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if window closing is enabled; otherwise <c>false</c>
        /// </value>
        bool WindowClosingEnabled { get; }

        /// <summary>
        /// Gets the names of processes which's window can be closed.
        /// </summary>
        /// <value>
        /// The names of processes which's window can be closed
        /// </value>
        List<string> ProcessesCanBeClosed { get; }

        /// <summary>
        /// Gets if bombing is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if bombing is enabled; otherwise <c>false</c>
        /// </value>
        bool BombingEnabled { get; }
        #endregion

        #region Monitoring & Warning
        /// <summary>
        /// Gets the update interval of the monitoring and warning features in ms.
        /// </summary>
        /// <value>
        /// The update interval of the monitoring and warning features in ms
        /// </value>
        public int MonitoringAndWarningInterval { get; }

        /// <summary>
        /// Gets if monitoring is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if monitoring is enabled; otherwise <c>false</c>
        /// </value>
        bool MonitoringEnabled { get; }

        /// <summary>
        /// Gets whether to show CPU usage.
        /// </summary>
        /// <value>
        /// <c>true</c> if CPU usage should be shown; otherwise <c>false</c>
        /// </value>
        bool ShowCPUUsage { get; }

        /// <summary>
        /// Gets whether to show memory usage.
        /// </summary>
        /// <value>
        /// <c>true</c> if memory usage should be shown; otherwise <c>false</c>
        /// </value>
        bool ShowMemoryUsage { get; }

        /// <summary>
        /// Gets if warning is enabled
        /// </summary>
        /// <value>
        /// <c>true</c> if warning is enabled; otherwise <c>false</c>
        /// </value>
        bool WarningEnabled { get; }

        /// <summary>
        /// Gets the CPU usage percentage above which warning should be displayed.
        /// </summary>
        /// <value>
        /// The CPU usage percentage above which warning should be displayed
        /// </value>
        double CPUWarningThreshold { get; }

        /// <summary>
        /// Gets the memory usage percentage above which warning should be displayed.
        /// </summary>
        /// <value>
        /// The memory usage percentage above which warning should be displayed
        /// </value>
        double MemoryWarningThreshold { get; }
        #endregion
    }
}
