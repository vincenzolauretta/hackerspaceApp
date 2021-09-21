using System;
using System.Collections.Generic;
using System.Text;

namespace HackerspaceApp.Models
{
    public class ApplicationConfigModel
    {
        public List<WebAppConfigModel> WebApps { get; set; }
        public List<WebHookConfigModel> WebHooks { get; set; }

        public ApplicationConfigModel()
        {
            WebApps = new List<WebAppConfigModel>();
            WebHooks = new List<WebHookConfigModel>();
        }
    }
}
