using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HackerspaceApp.ViewModels
{
    public class DashboardGroupViewModel : BaseViewModel
    {
        bool _IsFavourites;
        public bool IsFavourites
        {
            get { return _IsFavourites; }
            set
            {
                if (_IsFavourites != value)
                {
                    _IsFavourites = value;
                    OnPropertyChanged(nameof(IsFavourites));
                }
            }
        }

        public string Title { get; set; }

        ObservableCollection<object> _Items;
        public ObservableCollection<object> Items
        {
            get { return _Items; }
            set
            {
                if (_Items != value)
                {
                    _Items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        public DashboardGroupViewModel()
        {
            Items = new ObservableCollection<object>();
        }
    }
}
