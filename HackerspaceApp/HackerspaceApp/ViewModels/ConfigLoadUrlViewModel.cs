using HackerspaceApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerspaceApp.ViewModels
{
    public class ConfigLoadUrlViewModel : BaseViewModel
    {
        string _Url;
        public string Url
        {
            get { return _Url; }
            set
            {
                if (_Url != value)
                {
                    _Url = value;
                    OnPropertyChanged(nameof(Url));
                }
            }
        }

        private AppConfigViewModel _appConfigViewModel;

        public ConfigLoadUrlViewModel(INavigation navigation, AppConfigViewModel appConfigViewModel)
        {
            this.Navigation = navigation;
            this._appConfigViewModel = appConfigViewModel;

            InitAsync();
        }

        public async Task InitAsync()
        {
            Url = "https://";
        }

        RelayCommand _LoadConfigurationCommand;
        public ICommand LoadConfigurationCommand
        {
            get
            {
                if (_LoadConfigurationCommand == null)
                {
                    _LoadConfigurationCommand = new RelayCommand(async param =>
                    {

                        var client = new HttpClient(new System.Net.Http.HttpClientHandler()
                        {
                            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                            {
                                return true;
                            }
                        }, false);

                        try
                        {
                            var response = await client.GetAsync(Url);

                            string configurationJson = await response.Content.ReadAsStringAsync();

                            _appConfigViewModel.Configuration = configurationJson;

                            await Navigation?.PopModalAsync();

                        }
                        catch (Exception exc)
                        {
                            await App.Current.MainPage.DisplayAlert("error", exc.Message, "ok");
                            //throw;
                        }

                    }, param => true);
                }
                return _LoadConfigurationCommand;
            }
        }

        RelayCommand _NavigateBackCommand;
        public ICommand NavigateBackCommand
        {
            get
            {
                if (_NavigateBackCommand == null)
                {
                    _NavigateBackCommand = new RelayCommand(async param =>
                    {
                        await Navigation?.PopModalAsync();

                    }, param => true);
                }
                return _NavigateBackCommand;
            }
        }
    }
}
