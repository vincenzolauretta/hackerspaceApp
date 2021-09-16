﻿using HackerspaceApp.ViewModels;
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
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();

            this.BindingContext = new DashboardViewModel(this.Navigation);
        }

        protected override bool OnBackButtonPressed()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();

            return true;
        }
    }
}