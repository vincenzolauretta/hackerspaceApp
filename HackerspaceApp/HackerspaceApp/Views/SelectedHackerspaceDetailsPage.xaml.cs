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
    public partial class SelectedHackerspaceDetailsPage : ContentPage
    {
        public SelectedHackerspaceDetailsPage()
        {
            InitializeComponent();
        }

        public SelectedHackerspaceDetailsPage(HackerspaceItemModel hackerspaceItem)
        {
            InitializeComponent();

            this.BindingContext = new SelectedHackerspaceDetailsViewModel(this.Navigation, hackerspaceItem);
        }
    }
}