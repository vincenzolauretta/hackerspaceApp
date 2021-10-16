using HackerspaceApp.Helpers;
using HackerspaceApp.Models;
using HackerspaceApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerspaceApp.ViewModels
{
    public class AppConfigViewModel : BaseViewModel
    {
        string _Configuration;
        public string Configuration
        {
            get { return _Configuration; }
            set
            {
                if (_Configuration != value)
                {
                    _Configuration = value;
                    OnPropertyChanged(nameof(Configuration));
                }
            }
        }


        public AppConfigViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            InitAsync();
        }

        async Task InitAsync()
        {
            var configJson = await SecureStorage.GetAsync("ApplicationConfig");

            Configuration = configJson;
        }


        RelayCommand _SaveConfigurationCommand;
        public ICommand SaveConfigurationCommand
        {
            get
            {
                if (_SaveConfigurationCommand == null)
                {
                    _SaveConfigurationCommand = new RelayCommand(async param =>
                    {
                        try
                        {
                            ApplicationConfigModel appConfig = JsonConvert.DeserializeObject<ApplicationConfigModel>(Configuration);

                            if (appConfig == null) // probably empty json
                            {
                                return;
                            }

                            // fixing null lists
                            if (appConfig.DashboardItems == null)
                                appConfig.DashboardItems = new List<DashboardItemModel>();

                            if (appConfig.PinnedItems == null)
                                appConfig.PinnedItems = new List<DashboardItemModel>();

                            if (appConfig.WebApps == null)
                                appConfig.WebApps = new List<WebAppConfigModel>();

                            if (appConfig.WebHooks == null)
                                appConfig.WebHooks = new List<WebHookConfigModel>();

                            // save config
                            await SecureStorage.SetAsync("ApplicationConfig", Configuration);

                            // navigate to previous page
                            await this.Navigation?.PopAsync();
                        }
                        catch (Exception)
                        {
                            
                        }

                    }, param => true);
                }
                return _SaveConfigurationCommand;
            }
        }


        RelayCommand _ScanConfigurationCommand;
        public ICommand ScanConfigurationCommand
        {
            get
            {
                if (_ScanConfigurationCommand == null)
                {
                    _ScanConfigurationCommand = new RelayCommand(async param =>
                    {
                        try
                        {
                            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Camera>();

                            // only for iOS, in android it seems it request for permission every time
                            if (Device.RuntimePlatform == Device.iOS)
                            {
                                if (status == PermissionStatus.Denied)
                                {
                                    await Application.Current.MainPage.DisplayAlert("error", "Enable Camera access permission for this app.", "ok");
                                    return;
                                }
                            }

                            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

                            var result = await scanner.Scan();
                            
                            if (result != null)
                            {
                                var potentialCompressedJson = result.Text;

                                try
                                {
                                    var potentialJson = Compression.Unzip(Convert.FromBase64String(potentialCompressedJson));

                                    var obj = JsonConvert.DeserializeObject(potentialJson);

                                    Configuration = JsonConvert.SerializeObject(obj, Formatting.Indented);

                                }
                                catch (Exception)
                                {

                                }
                            }
                        }
                        catch(Exception exc)
                        {

                        }

                    }, param => true);
                }
                return _ScanConfigurationCommand;
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
                        await Navigation?.PopAsync();

                    }, param => true);
                }
                return _NavigateBackCommand;
            }
        }


        RelayCommand _ShareConfigurationCommand;
        public ICommand ShareConfigurationCommand
        {
            get
            {
                if (_ShareConfigurationCommand == null)
                {
                    _ShareConfigurationCommand = new RelayCommand(async param =>
                    {
                        await Navigation?.PushModalAsync(new ConfigShareQRCodePage());

                    }, param => true);
                }
                return _ShareConfigurationCommand;
            }
        }


        RelayCommand _LoadConfigurationFromUrlCommand;
        public ICommand LoadConfigurationFromUrlCommand
        {
            get
            {
                if (_LoadConfigurationFromUrlCommand == null)
                {
                    _LoadConfigurationFromUrlCommand = new RelayCommand(async param =>
                    {
                        await Navigation?.PushModalAsync(new ConfigLoadUrlPage(this));

                    }, param => true);
                }
                return _LoadConfigurationFromUrlCommand;
            }
        }


    }
}
