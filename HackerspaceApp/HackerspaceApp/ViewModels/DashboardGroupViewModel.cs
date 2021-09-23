using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HackerspaceApp.ViewModels
{
    public class DashboardGroupViewModel : BaseViewModel
    {
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
