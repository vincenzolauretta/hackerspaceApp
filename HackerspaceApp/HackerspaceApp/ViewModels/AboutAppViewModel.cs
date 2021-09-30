using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HackerspaceApp.ViewModels
{
    public class AboutAppViewModel : BaseViewModel
    {

        public AboutAppViewModel()
        {
            InitAsync();
        }

        public async Task InitAsync()
        {

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
