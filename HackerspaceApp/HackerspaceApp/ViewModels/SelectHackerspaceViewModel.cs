using HackerspaceApp.Models;
using HackerspaceApp.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HackerspaceApp.ViewModels
{
    public class SelectHackerspaceViewModel : BaseViewModel
    {
        ObservableCollection<HackerspaceItemModel> _HackerspacesItems;
        public ObservableCollection<HackerspaceItemModel> HackerspacesItems
        {
            get { return _HackerspacesItems; }
            set
            {
                if (_HackerspacesItems != value)
                {
                    _HackerspacesItems = value;
                    OnPropertyChanged(nameof(HackerspacesItems));
                }
            }
        }


        public SelectHackerspaceViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            InitAsync();
        }
        async Task InitAsync()
        {
            HttpClient c = new HttpClient();

            string spacesListJson = await c.GetStringAsync("https://raw.githubusercontent.com/SpaceApi/directory/master/directory.json");

            var spacesList = JsonConvert.DeserializeObject<JObject>(spacesListJson);

            var hackerspaces = new List<HackerspaceItemModel>();

            foreach (var item in spacesList)
            {
                string spaceName = item.Key;
                string spaceApiUrl = item.Value.ToString();

                hackerspaces.Add(new HackerspaceItemModel()
                {
                    Name = spaceName,
                    SpaceApiUrl = spaceApiUrl
                });
            }

            HackerspacesItems = new ObservableCollection<HackerspaceItemModel>(hackerspaces.OrderBy(z=>z.Name));

            //foreach (var item in HackerspacesItems)
            //{
            //    var _spaceApiRepository = new Repositories.SpaceApiRepository(item.SpaceApiUrl);

            //    try
            //    {
            //        await _spaceApiRepository.LoadJson();
            //    }
            //    catch (Exception ex)
            //    {

            //        //throw;
            //    }

            //}
        }


        RelayCommand _HackerspaceTappedCommand;
        public ICommand HackerspaceTappedCommand
        {
            get
            {
                if (_HackerspaceTappedCommand == null)
                {
                    _HackerspaceTappedCommand = new RelayCommand(async param =>
                    {
                        await Navigation?.PushModalAsync(new SelectedHackerspaceDetailsPage(param as HackerspaceItemModel));

                    }, param => true);
                }
                return _HackerspaceTappedCommand;
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
