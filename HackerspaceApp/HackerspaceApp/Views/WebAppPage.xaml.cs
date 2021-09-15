using HackerspaceApp.Models;
using HackerspaceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HackerspaceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebAppPage : ContentPage
    {
        public WebAppPage()
        {
            InitializeComponent();
        }

        public WebAppPage(WebAppConfigModel webAppConfig)
        {
            InitializeComponent();

            this.BindingContext = new WebAppViewModel(this.Navigation, webAppConfig);
        }
    }
}