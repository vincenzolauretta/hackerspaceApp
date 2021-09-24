using HackerspaceApp.Interfaces;
using HackerspaceApp.Models;
using HackerspaceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace HackerspaceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebAppPage : ContentPage, IModalPageWithBackgroundActivities
    {
        public WebAppPage()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        public WebAppPage(WebAppConfigModel webAppConfig)
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            this.BindingContext = new WebAppViewModel(this.Navigation, webAppConfig);
        }

        protected override bool OnBackButtonPressed()
        {
            (this.BindingContext as WebAppViewModel).UnloadResources();

            return base.OnBackButtonPressed();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.AppOnResume -= App_AppOnResume;
            App.AppOnResume += App_AppOnResume;
            App.AppOnSleep -= App_AppOnSleep;
            App.AppOnSleep += App_AppOnSleep;
        }

        private void App_AppOnSleep(object sender, EventArgs e)
        {
            (this.BindingContext as WebAppViewModel).UnloadResources();
        }

        private void App_AppOnResume(object sender, EventArgs e)
        {
            (this.BindingContext as WebAppViewModel).InitAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            App.AppOnResume -= App_AppOnResume;
            App.AppOnSleep -= App_AppOnSleep;
        }
    }
}