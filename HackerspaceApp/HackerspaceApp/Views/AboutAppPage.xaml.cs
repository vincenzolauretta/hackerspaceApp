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
    public partial class AboutAppPage : ContentPage
    {
        public AboutAppPage()
        {
            InitializeComponent();

            this.BindingContext = new AboutAppViewModel(this.Navigation);
        }
    }
}