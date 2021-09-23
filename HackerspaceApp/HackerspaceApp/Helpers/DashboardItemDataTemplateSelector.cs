using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HackerspaceApp.Helpers
{
    public class DashboardItemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WebAppTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return WebAppTemplate;
        }
    }
}
