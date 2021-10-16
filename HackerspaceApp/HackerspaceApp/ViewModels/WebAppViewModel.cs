using HackerspaceApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerspaceApp.ViewModels
{
    public class WebAppViewModel : BaseViewModel
    {
        bool _IsPinned;
        public bool IsPinned
        {
            get { return _IsPinned; }
            set
            {
                if (_IsPinned != value)
                {
                    _IsPinned = value;
                    OnPropertyChanged(nameof(IsPinned));
                }
            }
        }

        WebAppConfigModel _WebApp;
        public WebAppConfigModel WebApp
        {
            get { return _WebApp; }
            set
            {
                if (_WebApp != value)
                {
                    _WebApp = value;
                    OnPropertyChanged(nameof(WebApp));
                }
            }
        }
        string _Url;
        public string Url
        {
            get { return _Url; }
            set
            {
                if (_Url != value)
                {
                    _Url = value;
                    OnPropertyChanged(nameof(Url));
                }
            }
        }

        private string SessionGuid { get; set; }


        public WebAppViewModel(INavigation navigation, WebAppConfigModel webAppConfig)
        {
            this.Navigation = navigation;

            IsBusy = true;

            WebApp = webAppConfig;

            InitAsync();
        }

        public async Task InitAsync()
        {
            this.IsPinned = WebApp.IsPinned;

            this.Url = WebApp.Url;

            if (WebApp.AutoRefresh > 0)
            {
                SessionGuid = Guid.NewGuid().ToString();

                string taskGuid = SessionGuid;

                while (taskGuid == SessionGuid)
                {
                    await Task.Delay(WebApp.AutoRefresh * 1000);

                    if (taskGuid == SessionGuid)
                    {
                        this.Url = null;
                        this.Url = WebApp?.Url;
                    }
                    else
                        break;
                }
            }
        }

        public List<string> GetClassesOrIdToHide()
        {
            return WebApp.HideCssClassesOrId;
        }

        public void ContentLoaded()
        {
            IsBusy = false;
        }

        public void UnloadResources()
        {
            SessionGuid = null;
            this.Url = null;
        }


        RelayCommand _PinDashboardItemCommand;
        public ICommand PinDashboardItemCommand
        {
            get
            {
                if (_PinDashboardItemCommand == null)
                {
                    _PinDashboardItemCommand = new RelayCommand(async param =>
                    {
                        string configJson = await SecureStorage.GetAsync("ApplicationConfig");

                        ApplicationConfigModel appConfig = JsonConvert.DeserializeObject<ApplicationConfigModel>(configJson);

                        var pinnedItem = appConfig.PinnedItems.FirstOrDefault(z => z.Id == WebApp.Id);

                        if (pinnedItem == null) // pin
                        {
                            IsPinned = true;

                            appConfig.PinnedItems.Add(new DashboardItemModel()
                            {
                                Id = WebApp.Id
                            });
                        }
                        else // unpin
                        {
                            IsPinned = false;

                            appConfig.PinnedItems.Remove(pinnedItem);
                        }

                        configJson = JsonConvert.SerializeObject(appConfig, Formatting.Indented);

                        // save config
                        await SecureStorage.SetAsync("ApplicationConfig", configJson);

                        //await InitAsync();

                        WebApp?.TriggerPinnedStatusChangedEvent();
                    }, param => true);
                }
                return _PinDashboardItemCommand;
            }
        }


        RelayCommand _RefreshPageCommand;
        public ICommand RefreshPageCommand
        {
            get
            {
                if (_RefreshPageCommand == null)
                {
                    _RefreshPageCommand = new RelayCommand(param =>
                    {
                        this.Url = null;
                        this.Url = WebApp?.Url;

                    }, param => true);
                }
                return _RefreshPageCommand;
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
                        this.UnloadResources();

                        await Navigation?.PopModalAsync();

                    }, param => true);
                }
                return _NavigateBackCommand;
            }
        }


    }
}
