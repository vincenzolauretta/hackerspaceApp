using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerspaceApp.ViewModels
{
    public class ConfigShareQRCodeViewModel : BaseViewModel
    {
        ImageSource _QRCode;
        public ImageSource QRCode
        {
            get { return _QRCode; }
            set
            {
                if (_QRCode != value)
                {
                    _QRCode = value;
                    OnPropertyChanged(nameof(QRCode));
                }
            }
        }



        public ConfigShareQRCodeViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            InitAsync();
        }

        public async Task InitAsync()
        {
            var configJson = await SecureStorage.GetAsync("ApplicationConfig");

            var obj = JsonConvert.DeserializeObject(configJson);

            // minified
            configJson = JsonConvert.SerializeObject(obj);

            int qrLength = configJson.Length;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(configJson, QRCodeGenerator.ECCLevel.Q);

            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            var qrCodeBytes = qrCode.GetGraphic(20);

            QRCode = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
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
