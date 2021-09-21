using HackerspaceApp.Models;
using HackerspaceApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerspaceApp.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        ObservableCollection<WebAppConfigModel> _WebApps;
        public ObservableCollection<WebAppConfigModel> WebApps
        {
            get { return _WebApps; }
            set
            {
                if (_WebApps != value)
                {
                    _WebApps = value;
                    OnPropertyChanged(nameof(WebApps));
                }
            }
        }

        ObservableCollection<WebHookViewModel> _WebHooks;
        public ObservableCollection<WebHookViewModel> WebHooks
        {
            get { return _WebHooks; }
            set
            {
                if (_WebHooks != value)
                {
                    _WebHooks = value;
                    OnPropertyChanged(nameof(WebHooks));
                }
            }
        }




        public DashboardViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            InitAsync();
        }

        public async Task InitAsync()
        {
            string configJson = null;

#if !DEBUG
            configJson = await SecureStorage.GetAsync("ApplicationConfig");
#endif

            if (string.IsNullOrWhiteSpace(configJson))
            {
                var config = this.CreateDefaultConfiguration();

                configJson = JsonConvert.SerializeObject(config, Formatting.Indented);

                await SecureStorage.SetAsync("ApplicationConfig", configJson);
            }

            ApplicationConfigModel appConfig = JsonConvert.DeserializeObject<ApplicationConfigModel>(configJson);

            if (appConfig == null) // probably empty json
            {
                var config = this.CreateDefaultConfiguration();

                configJson = JsonConvert.SerializeObject(config, Formatting.Indented);

                await SecureStorage.SetAsync("ApplicationConfig", configJson);

                appConfig = JsonConvert.DeserializeObject<ApplicationConfigModel>(configJson);
            }

            WebApps = new ObservableCollection<WebAppConfigModel>(appConfig.WebApps);

            WebHooks = new ObservableCollection<WebHookViewModel>();
            foreach (var group in appConfig.WebHooks.GroupBy(z=>z.Title))
            {
                var webHook = new WebHookViewModel();
                foreach (var item in group)
                {

                }
            }
        }

        private ApplicationConfigModel CreateDefaultConfiguration()
        {
            var config = new ApplicationConfigModel();

            config.WebApps.Add(new WebAppConfigModel()
            {
                Title = "Cam",
                Url = "http://cam.hackerspace.sg",
                AutoRefresh = 3
            });
            config.WebApps.Add(new WebAppConfigModel()
            {
                Title = "Google",
                Url = "https://www.google.com"
            });

            config.WebApps.Add(new WebAppConfigModel()
            {
                Title = "Hackerspace",
                Url = "https://hackerspace.sg"
            });

            config.WebApps.Add(new WebAppConfigModel()
            {
                Title = "Dymo Printer",
                Url = "http://192.168.6.148:8080/"
            });

            return config;
        }


        RelayCommand _OpenWebViewCommand;
        public ICommand OpenWebViewCommand
        {
            get
            {
                if (_OpenWebViewCommand == null)
                {
                    _OpenWebViewCommand = new RelayCommand(param =>
                    {
                        var webApp = param as WebAppConfigModel;

                        this.Navigation?.PushModalAsync(new WebAppPage(webApp));

                    }, param => true);
                }
                return _OpenWebViewCommand;
            }
        }


        RelayCommand _RunWebHookCommand;
        public ICommand RunWebHookCommand
        {
            get
            {
                if (_RunWebHookCommand == null)
                {
                    _RunWebHookCommand = new RelayCommand(async param =>
                    {
                        var webHook = param as WebHookConfigModel;

                        var client = new HttpClient(new System.Net.Http.HttpClientHandler()
                        {
                            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                            {
                                return true;
                            }
                        }, false);

                        try
                        {
                            var response = await client.GetAsync(webHook.Url);

                            string message = await response.Content.ReadAsStringAsync();

                            if (!string.IsNullOrWhiteSpace(message))
                                await App.Current.MainPage.DisplayAlert("info", message, "ok");
                        }
                        catch (Exception exc)
                        {
                            await App.Current.MainPage.DisplayAlert("error", exc.Message, "ok");
                            //throw;
                        }

                    }, param => true);
                }
                return _RunWebHookCommand;
            }
        }



        RelayCommand _EditConfigurationCommand;
        public ICommand EditConfigurationCommand
        {
            get
            {
                if (_EditConfigurationCommand == null)
                {
                    _EditConfigurationCommand = new RelayCommand(async param =>
                    {
                        await this.Navigation?.PushModalAsync(new AppConfigPage(this));

                    }, param => true);
                }
                return _EditConfigurationCommand;
            }
        }


    }
}
