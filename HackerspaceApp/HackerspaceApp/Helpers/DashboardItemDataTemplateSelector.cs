using HackerspaceApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HackerspaceApp.Helpers
{
    public class DashboardItemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WebAppTemplate { get; set; }
        public DataTemplate SocialFeedTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item.GetType() == typeof(WebAppConfigModel))
                return WebAppTemplate;
            else if (item.GetType() == typeof(SocialFeedConfigModel))
                return SocialFeedTemplate;
            else
                return null;
        }
    }
}
