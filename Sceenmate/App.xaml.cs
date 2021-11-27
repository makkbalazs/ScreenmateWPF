using Screenmate.Controllers;
using Screenmate.Services;
using System.Collections.Generic;
using System.Windows;

namespace Screenmate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Controllers
        /// </summary>
        private List<IControllerBase> _controllers;

        public App()
        {
            CreateControllers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            StartControllers();
            AnimationService.Instance.ShowTransparentWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            StopControllers();
        }

        /// <summary>
        /// Creates controllers.
        /// </summary>
        private void CreateControllers()
        {
            List<IControllerBase> controllers = new List<IControllerBase>(4);
            controllers.Add(new CharacterController());
            controllers.Add(new EntertainmentController());
            controllers.Add(new MonitoringAndWarningController());

            _controllers = controllers;
        }

        /// <summary>
        /// Starts controllers.
        /// </summary>
        private void StartControllers()
        {
            foreach (IControllerBase controller in _controllers)
            {
                controller.Start();
            }
        }

        /// <summary>
        /// Stops controllers.
        /// </summary>
        private void StopControllers()
        {
            foreach (IControllerBase controller in _controllers)
            {
                controller.Stop();
            }
        }
    }
}
