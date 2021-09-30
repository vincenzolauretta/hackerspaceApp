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
    public partial class ConfigLoadUrlPage : ContentPage
    {
        public ConfigLoadUrlPage()
        {
            InitializeComponent();
        }

        public ConfigLoadUrlPage(AppConfigViewModel appConfigViewModel)
        {
            InitializeComponent();

            this.BindingContext = new ConfigLoadUrlViewModel(this.Navigation, appConfigViewModel);
        }
    }
}