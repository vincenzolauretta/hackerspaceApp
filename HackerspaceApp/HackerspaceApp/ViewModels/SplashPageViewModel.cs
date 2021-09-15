using HackerspaceApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerspaceApp.ViewModels
{
    public class SplashPageViewModel : BaseViewModel
    {
        public SplashPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            InitAsync();
        }

        async Task InitAsync()
        {
            await Task.Delay(2000);
            await Navigation?.PushAsync(new DashboardPage());
        }
    }
}
