using System;
using System.Collections.Generic;
using System.Text;

namespace HackerspaceApp.Models
{
    public class ApplicationConfigModel
    {
        public string SplashBackgroundColor { get; set; }
        public string SplashLogo { get; set; }
        public string SpaceApiUrl { get; set; }
        public List<DashboardItemModel> PinnedItems { get; set; }
        public List<DashboardItemModel> DashboardItems { get; set; }
        public List<WebAppConfigModel> WebApps { get; set; }
        public List<WebHookConfigModel> WebHooks { get; set; }
        public List<SocialFeedConfigModel> SocialFeeds { get; set; }

        public ApplicationConfigModel()
        {
            PinnedItems = new List<DashboardItemModel>();
            DashboardItems = new List<DashboardItemModel>();
            WebApps = new List<WebAppConfigModel>();
            WebHooks = new List<WebHookConfigModel>();
            SocialFeeds = new List<SocialFeedConfigModel>();
        }
    }
}
