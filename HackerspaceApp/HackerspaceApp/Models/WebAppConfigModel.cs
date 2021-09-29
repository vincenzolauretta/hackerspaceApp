using System;
using System.Collections.Generic;
using System.Text;

namespace HackerspaceApp.Models
{
    public class WebAppConfigModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int AutoRefresh { get; set; }
        public bool LaunchInBrowser { get; set; }
        public List<string> HideCssClassesOrId { get; set; }
    }
}
