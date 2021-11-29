using Screenmate.ViewModels;
using System;
using System.Windows;

namespace Screenmate.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        /// <summary>
        /// The viewmodel
        /// </summary>
        private ISettingsViewModel viewModel;

        public SettingsWindow()
        {
            InitializeComponent();

            viewModel = new SettingsViewModel();

            DataContext = viewModel;

            _ = viewModel.OnNavigatedTo();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
