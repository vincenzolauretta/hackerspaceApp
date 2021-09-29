using HackerspaceApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HackerspaceApp.ViewModels
{
    public class WebAppViewModel : BaseViewModel
    {
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

            WebApp = webAppConfig;

            InitAsync();
        }

        public async Task InitAsync()
        {
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

        public void UnloadResources()
        {
            SessionGuid = null;
            this.Url = null;
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
