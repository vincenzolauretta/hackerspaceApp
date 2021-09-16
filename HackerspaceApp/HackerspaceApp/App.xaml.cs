using HackerspaceApp.Services;
using HackerspaceApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HackerspaceApp
{
    public partial class App : Application
    {
        public static event EventHandler AppOnStart;
        public static event EventHandler AppOnSleep;
        public static event EventHandler AppOnResume;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new NavigationPage(new SplashPage());
            //MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            AppOnStart?.Invoke(null, null);
        }

        protected override void OnSleep()
        {
            AppOnSleep?.Invoke(null, null);
        }

        protected override void OnResume()
        {
            AppOnResume?.Invoke(null, null);
        }
    }
}
