using Screenmate.Models;
using Screenmate.MVVM;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Screenmate.ViewModels
{
    public interface ISettingsViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        SettingsModel Settings { get; set; }

        /// <summary>
        /// Gets or sets the save settings command.
        /// </summary>
        IRelayCommand SaveSettingsCommand { get; set; }

        /// <summary>
        /// Gets or sets the load settings command.
        /// </summary>
        IRelayCommand LoadSettingsCommand { get; set; }

        /// <summary>
        /// Gets or sets the reset defaults command.
        /// </summary>
        IRelayCommand ResetDefaultsCommand { get; set; }

        /// <summary>
        /// Called when navigated to the view.
        /// </summary>
        /// <returns></returns>
        Task OnNavigatedTo();
    }
}
