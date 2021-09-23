using System;
using System.Collections.Generic;
using System.Text;

namespace HackerspaceApp.Models
{
    public class ApplicationConfigModel
    {
        public List<DashboardItemModel> DashboardItems { get; set; }
        public List<WebAppConfigModel> WebApps { get; set; }
        public List<WebHookConfigModel> WebHooks { get; set; }

        public ApplicationConfigModel()
        {
            DashboardItems = new List<DashboardItemModel>();
            WebApps = new List<WebAppConfigModel>();
            WebHooks = new List<WebHookConfigModel>();
        }
    }
}
