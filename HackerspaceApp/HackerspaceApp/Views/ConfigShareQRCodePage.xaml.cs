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
    public partial class ConfigShareQRCodePage : ContentPage
    {
        public ConfigShareQRCodePage()
        {
            InitializeComponent();

            this.BindingContext = new ConfigShareQRCodeViewModel(this.Navigation);
        }
    }
}