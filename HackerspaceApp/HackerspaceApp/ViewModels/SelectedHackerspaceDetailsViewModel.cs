using HackerspaceApp.Models;
using HackerspaceApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HackerspaceApp.ViewModels
{
    public class SelectedHackerspaceDetailsViewModel : BaseViewModel
    {
        private HackerspaceItemModel _hackerspaceItem;
        private SpaceApiRepository _spaceApiRepository;

        public SelectedHackerspaceDetailsViewModel(INavigation navigation, HackerspaceItemModel hackerspaceItem)
        {
            this.Navigation = navigation;
            _hackerspaceItem = hackerspaceItem;

            InitAsync();
        }

        async Task InitAsync()
        {
            _spaceApiRepository = new SpaceApiRepository(_hackerspaceItem.SpaceApiUrl);

            await _spaceApiRepository.LoadJson();
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
