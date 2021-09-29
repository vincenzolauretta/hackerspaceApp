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

        private async void hybridWebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            // hide some Css Classes or Id to reuse website pages as mobile app pages

            var classesOrIdToHide = (this.BindingContext as WebAppViewModel).GetClassesOrIdToHide();

            if (classesOrIdToHide != null)
            {
                var webView = sender as WebView; // ommitting the null check, since nobody else will call this method

                foreach (var item in classesOrIdToHide)
                {
                    string scriptForId = $"document.getElementById('{item}').style.display = 'none';";

                    await webView.EvaluateJavaScriptAsync(scriptForId);

                    string scriptForClasses = $"var objectsToRemove = document.getElementsByClassName('{item}');" +
                                    "for (var i = 0; i < objectsToRemove.length; i ++) {" +
                                    "    objectsToRemove[i].style.display = 'none';" +
                                    "}";

                    await webView.EvaluateJavaScriptAsync(scriptForClasses);
                }
            }


        }
    }
}