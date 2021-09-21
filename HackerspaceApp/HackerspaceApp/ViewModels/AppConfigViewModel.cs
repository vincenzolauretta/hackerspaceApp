using HackerspaceApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerspaceApp.ViewModels
{
    public class AppConfigViewModel : BaseViewModel
    {
        string _Configuration;
        public string Configuration
        {
            get { return _Configuration; }
            set
            {
                if (_Configuration != value)
                {
                    _Configuration = value;
                    OnPropertyChanged(nameof(Configuration));
                }
            }
        }

        private DashboardViewModel _dashboardViewModel { get; set; }

        public AppConfigViewModel(INavigation navigation, DashboardViewModel dashboardViewModel)
        {
            this.Navigation = navigation;
            _dashboardViewModel = dashboardViewModel;

            InitAsync();
        }

        async Task InitAsync()
        {
            var configJson = await SecureStorage.GetAsync("ApplicationConfig");

            Configuration = configJson;
        }


        RelayCommand _SaveConfigurationCommand;
        public ICommand SaveConfigurationCommand
        {
            get
            {
                if (_SaveConfigurationCommand == null)
                {
                    _SaveConfigurationCommand = new RelayCommand(async param =>
                    {
                        try
                        {
                            ApplicationConfigModel appConfig = JsonConvert.DeserializeObject<ApplicationConfigModel>(Configuration);

                            if (appConfig == null) // probably empty json
                            {
                                return;
                            }

                            // fixing null lists
                            if (appConfig.WebApps == null)
                                appConfig.WebApps = new List<WebAppConfigModel>();

                            if (appConfig.WebHooks == null)
                                appConfig.WebHooks = new List<WebHookConfigModel>();

                            // save config
                            await SecureStorage.SetAsync("ApplicationConfig", Configuration);

                            // navigate to previous page
                            await this.Navigation?.PopModalAsync();

                            // reload dashboard (this should be moved to OnAppearing of DashboardPage)
                            await _dashboardViewModel.InitAsync();
                        }
                        catch (Exception)
                        {
                            
                        }

                    }, param => true);
                }
                return _SaveConfigurationCommand;
            }
        }

        RelayCommand _NavigateBackCommand;
        public ICommand NavigateBackCommand
        {
            get
            {
                if (_NavigateBackCommand == null)
                {
                    _NavigateBackCommand = new RelayCommand(async param =>
                    {
                        await Navigation?.PopModalAsync();

                    }, param => true);
                }
                return _NavigateBackCommand;
            }
        }

    }
}
