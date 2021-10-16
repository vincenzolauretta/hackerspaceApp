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
        bool _IsMenuVisible;
        public bool IsMenuVisible
        {
            get { return _IsMenuVisible; }
            set
            {
                if (_IsMenuVisible != value)
                {
                    _IsMenuVisible = value;
                    OnPropertyChanged(nameof(IsMenuVisible));
                }
            }
        }

        ObservableCollection<MenuItemViewModel> _MenuItems;
        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get { return _MenuItems; }
            set
            {
                if (_MenuItems != value)
                {
                    _MenuItems = value;
                    OnPropertyChanged(nameof(MenuItems));
                }
            }
        }


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

        private bool _reloadConfigurationOnAppearing { get; set; }

        public DashboardViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            InitAsync();
        }

        public async Task InitAsync()
        {
            string configJson = null;

//#if !DEBUG
            configJson = await SecureStorage.GetAsync("ApplicationConfig");
//#endif

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

            // pinned items
            if (appConfig.PinnedItems.Count > 0)
            {
                var pinnedGroup = new DashboardGroupViewModel()
                {
                    Title = "Pinned",
                    IsFavourites = true
                };

                Groups.Add(pinnedGroup);

                foreach (var item in appConfig.PinnedItems)
                {
                    var webAppObj = appConfig.WebApps.FirstOrDefault(z => z.Id == item.Id);

                    if (webAppObj != null)
                    {
                        webAppObj.IsPinned = appConfig.PinnedItems.FirstOrDefault(z => z.Id == webAppObj.Id) != null;

                        pinnedGroup.Items.Add(webAppObj);
                    }
                }
            }

            // all other items
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

                    //var socialObj = appConfig.SocialFeeds.FirstOrDefault(z => z.Id == id);

                    //if (socialObj != null)
                    //{
                    //    g.Items.Add(socialObj);
                    //}

                    var webAppObj = appConfig.WebApps.FirstOrDefault(z => z.Id == id);

                    if (webAppObj != null)
                    {
                        webAppObj.IsPinned = appConfig.PinnedItems.FirstOrDefault(z => z.Id == webAppObj.Id) != null;

                        g.Items.Add(webAppObj);
                    }
                }
            }

            MenuItems = new ObservableCollection<MenuItemViewModel>();
            MenuItems.Add(new MenuItemViewModel()
            {
                Title = "Select Hackerspace",
                Type = "select_hackerspace"
            }); MenuItems.Add(new MenuItemViewModel()
            {
                Title = "Configuration",
                Type = "config"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                Title = "About",
                Type = "about_app"
            });
        }

        private ApplicationConfigModel CreateDefaultConfiguration()
        {
            var config = new ApplicationConfigModel();

            config.SplashLogo = "https://hackerspace.sg/imgs/banner.png";
            config.SplashBackgroundColor = "#f0f0f0";

            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "News",
                Id = "twitter"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "cam"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "faq"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "location"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "membership"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Space",
                Id = "site"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Printers",
                Id = "dymo"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Useful links",
                Id = "google"
            });
            config.DashboardItems.Add(new DashboardItemModel()
            {
                GroupName = "Test",
                Id = "selfsigned"
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
                Id = "faq",
                Title = "FAQ",
                Url = "https://hackerspace.sg/faq/",
                HideCssClassesOrId = new List<string>()
                {
                    "navbar",
                    "jumbotron"
                }
            });
            config.WebApps.Add(new WebAppConfigModel()
            {
                Id = "location",
                Title = "Location",
                Url = "https://hackerspace.sg/location/",
                HideCssClassesOrId = new List<string>()
                {
                    "navbar",
                    "jumbotron"
                }
            });
            config.WebApps.Add(new WebAppConfigModel()
            {
                Id = "membership",
                Title = "Membership",
                Url = "https://hackerspace.sg/membership/",
                HideCssClassesOrId = new List<string>()
                {
                    "navbar",
                    "jumbotron"
                }
            });
            config.WebApps.Add(new WebAppConfigModel()
            {
                Id = "site",
                Title = "Hackerspace",
                Url = "https://hackerspace.sg",
                LaunchInBrowser = true
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
            config.WebApps.Add(new WebAppConfigModel()
            {
                Id = "twitter",
                Title = "Twitter",
                Url = "https://twitter.com/hackerspacesg"
            });

            //config.SocialFeeds.Add(new SocialFeedConfigModel()
            //{
            //    Id = "twitter",
            //    Title = "Twitter",
            //    SocialNetwork = "twitter",
            //    Url = "https://twitter.com/hackerspacesg"
            //});

            return config;
        }


        public void ReloadConfigurationOnAppearing()
        {
            if (_reloadConfigurationOnAppearing)
            {
                _reloadConfigurationOnAppearing = false;

                InitAsync();
            }
        }


        RelayCommand _OpenWebViewCommand;
        public ICommand OpenWebViewCommand
        {
            get
            {
                if (_OpenWebViewCommand == null)
                {
                    _OpenWebViewCommand = new RelayCommand(async param =>
                    {
                        var webApp = param as WebAppConfigModel;

                        webApp.PinnedStatusChanged -= WebApp_PinnedStatusChanged;
                        webApp.PinnedStatusChanged += WebApp_PinnedStatusChanged;

                        if (webApp.LaunchInBrowser)
                        {
                            await Browser.OpenAsync(webApp.Url, BrowserLaunchMode.SystemPreferred);
                        }
                        else
                        {
                            this.Navigation?.PushModalAsync(new WebAppPage(webApp));
                        }

                    }, param => true);
                }
                return _OpenWebViewCommand;
            }
        }

        private void WebApp_PinnedStatusChanged(object sender, EventArgs e)
        {
            _reloadConfigurationOnAppearing = true;
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



        RelayCommand _ToggleMenuCommand;
        public ICommand ToggleMenuCommand
        {
            get
            {
                if (_ToggleMenuCommand == null)
                {
                    _ToggleMenuCommand = new RelayCommand(param =>
                    {
                        IsMenuVisible = !IsMenuVisible;

                    }, param => true);
                }
                return _ToggleMenuCommand;
            }
        }


        RelayCommand _MenuItemTappedCommand;
        public ICommand MenuItemTappedCommand
        {
            get
            {
                if (_MenuItemTappedCommand == null)
                {
                    _MenuItemTappedCommand = new RelayCommand(async param =>
                    {
                        var item = param as MenuItemViewModel;

                        switch (item.Type)
                        {
                            case "config":
                                {
                                    _reloadConfigurationOnAppearing = true;

                                    await this.Navigation?.PushAsync(new AppConfigPage());
                                }
                                break;
                            case "select_hackerspace":
                                {
                                    _reloadConfigurationOnAppearing = true;

                                    await this.Navigation?.PushModalAsync(new SelectHackerspacePage());
                                }
                                break;
                            case "about_app":
                                {
                                    await this.Navigation?.PushModalAsync(new AboutAppPage());
                                }
                                break;
                        }

                        ToggleMenuCommand.Execute(null);

                    }, param => true);
                }
                return _MenuItemTappedCommand;
            }
        }

    }
}
