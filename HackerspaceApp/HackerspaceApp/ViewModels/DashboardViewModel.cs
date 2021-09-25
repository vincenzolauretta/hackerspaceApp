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
        ObservableCollection<DashboardGroupViewModel> _Groups;
        public ObservableCollection<DashboardGroupViewModel> Groups
        {
            get { return _Groups; }
            set
            {
                if (_Groups != value)
                {
                    _Groups = value;
                    OnPropertyChanged(nameof(Groups));
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

            Groups = new ObservableCollection<DashboardGroupViewModel>();

            var dashboardItemsGroups = appConfig.DashboardItems
                .Select(z => z.GroupName)
                .Distinct();

            foreach (var g in dashboardItemsGroups)
            {
                Groups.Add(new DashboardGroupViewModel()
                {
                    Title = g
                });
            }

            foreach (var g in Groups)
            {
                var items = appConfig.DashboardItems
                    .Where(z => z.GroupName == g.Title);

                foreach (var item in items)
                {
                    var id = item.Id;

                    var obj = appConfig.WebApps.FirstOrDefault(z => z.Id == id);

                    if (obj != null)
                    {
                        g.Items.Add(obj);
                    }
                }
            }

        }

        private ApplicationConfigModel CreateDefaultConfiguration()
        {
            var config = new ApplicationConfigModel();

            config.SplashLogo = "https://hackerspace.sg/imgs/banner.png";
            config.SplashBackgroundColor = "#f0f0f0";

            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "cam",
                Title = "Cam"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "cam",
                Title = "Cam"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "cam",
                Title = "Cam"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "cam",
                Title = "Cam"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "cam",
                Title = "Cam"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "cam",
                Title = "Cam"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "cam",
                Title = "Cam"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "cam",
                Title = "Cam"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "site",
                Title = "Hackerspace"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Printers",
                Id = "dymo",
                Title = "Dymo Printer"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Useful links",
                Id = "google",
                Title = "Google"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Useful links2",
                Id = "google",
                Title = "Google"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Useful links3",
                Id = "google",
                Title = "Google"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Useful links4",
                Id = "google",
                Title = "Google"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Useful links5",
                Id = "google",
                Title = "Google"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Test",
                Id = "selfsigned",
                Title = "Self-signed certificate"
            });

            config.WebApps.Add(new WebAppConfigModel()
            {
                Id = "cam",
                Title = "Cam",
                Url = "http://cam.hackerspace.sg",
                AutoRefresh = 3
            });
            config.WebApps.Add(new WebAppConfigModel()
            {
                Id = "google",
                Title = "Google",
                Url = "https://www.google.com"
            });

            config.WebApps.Add(new WebAppConfigModel()
            {
                Id = "site",
                Title = "Hackerspace",
                Url = "https://hackerspace.sg"
            });

            config.WebApps.Add(new WebAppConfigModel()
            {
                Id = "dymo",
                Title = "Dymo Printer",
                Url = "http://192.168.6.148:8080/"
            });
            config.WebApps.Add(new WebAppConfigModel()
            {
                Id = "selfsigned",
                Title = "Self Signed",
                Url = "https://self-signed.badssl.com"
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
                        await this.Navigation?.PushAsync(new AppConfigPage(this));

                    }, param => true);
                }
                return _EditConfigurationCommand;
            }
        }


    }
}
