using Newtonsoft.Json;
using Screenmate.Models;
using Screenmate.MVVM;
using Screenmate.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Screenmate.ViewModels
{
    public class SettingsViewModel : NotfiyPropertyChanged, ISettingsViewModel
    {
        /// <summary>
        /// The path and name of the settings file
        /// </summary>
        private string settingsFile = "settings.json";
        /// <summary>
        /// The settings
        /// </summary>
        private SettingsModel _settings = new SettingsModel();
        /// <summary>
        /// The save settings command
        /// </summary>
        private IRelayCommand _saveSettingsCommand;
        /// <summary>
        /// The load settings command
        /// </summary>
        private IRelayCommand _loadSettingsCommand;
        /// <summary>
        /// The reset defaults command
        /// </summary>
        private IRelayCommand _resetDefaultsCommand;

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        public SettingsModel Settings
        {
            get { return _settings; }
            set
            {
                SetField(ref _settings, value);
                SettingsService.Instance = _settings;
            }
        }

        /// <summary>
        /// Gets or sets the save settings command.
        /// </summary>
        public IRelayCommand SaveSettingsCommand
        {
            get { return _saveSettingsCommand; }
            set { SetField(ref _saveSettingsCommand, value); }
        }

        /// <summary>
        /// Gets or sets the load settings command.
        /// </summary>
        public IRelayCommand LoadSettingsCommand
        {
            get { return _loadSettingsCommand; }
            set { SetField(ref _loadSettingsCommand, value); }
        }

        /// <summary>
        /// Gets or sets the reset defaults command.
        /// </summary>
        public IRelayCommand ResetDefaultsCommand
        {
            get { return _resetDefaultsCommand; }
            set { SetField(ref _resetDefaultsCommand, value); }
        }

        public SettingsViewModel()
        {
            SetupCommands();
        }

        /// <summary>
        /// Initializes model. First tries to load settings, if it fails, sets defaults.
        /// </summary>
        /// <returns></returns>
        private void InitializeModel()
        {
            if (!LoadSettings())
            {
                SetDefaults();
            }
        }

        /// <summary>
        /// Sets up commands.
        /// </summary>
        private void SetupCommands()
        {
            SaveSettingsCommand = new RelayCommand(() => SaveSettings());
            LoadSettingsCommand = new RelayCommand(() => LoadSettings());
            ResetDefaultsCommand = new RelayCommand(() => SetDefaults());
        }

        public async Task OnNavigatedTo()
        {
            if(!Settings.Initialized)
            {
                InitializeModel();
            }
        }

        /// <summary>
        /// Sets default settings.
        /// </summary>
        private void SetDefaults()
        {
            SettingsModel settings = new SettingsModel()
            {
                //Technical
                Initialized = true,
                //General
                Enabled = false,
                //Wandering
                WanderingAndFollowingInterval = 10,
                WanderingEnabled = true,
                WanderingSpeed = 10,
                //Following
                FollowingEnabled = false,
                FollowingSpeed = 10,
                //Entertainment
                EntertainmentInterval = 600000,
                EntertainingEnabled = false,
                WindowMovingEnabled = true,
                ProcessesCanBeMoved = new List<string>()
                {
                    "notepad"
                },
                WindowClosingEnabled = false,
                ProcessesCanBeClosed = new List<string>()
                {
                    "notepad"
                },
                BombingEnabled = true,
                //Monitoring & Warning
                MonitoringAndWarningInterval = 2000,
                MonitoringEnabled = false,
                ShowCPUUsage = true,
                ShowMemoryUsage = true,
                WarningEnabled = false,
                CPUWarningThreshold = 99.0,
                MemoryWarningThreshold = 80.0
            };
            Settings = settings;
        }

        /// <summary>
        /// Saves settings to settings.json file.
        /// </summary>
        /// <returns></returns>
        private void SaveSettings()
        {
            string json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            File.WriteAllText(settingsFile, json);
        }

        /// <summary>
        /// Loads settings from settings.json file.
        /// </summary>
        /// <returns><c>true</c> if settings could be loaded; otherwise <c>false</c></returns>
        private bool LoadSettings()
        {
            bool result;
            try
            {
                string json = null;
                if (File.Exists(settingsFile))
                {
                    json = File.ReadAllText(settingsFile);
                }
                SettingsModel settings = JsonConvert.DeserializeObject<SettingsModel>(json);
                result = settings != null;
                if(result)
                {
                    Settings = settings;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
