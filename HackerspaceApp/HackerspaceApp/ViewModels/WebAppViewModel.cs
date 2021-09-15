using HackerspaceApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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


        public WebAppViewModel(INavigation navigation, WebAppConfigModel webAppConfig)
        {
            this.Navigation = navigation;

            WebApp = webAppConfig;

            InitAsync();
        }

        async Task InitAsync()
        {

        }
    }
}
