using System;
using System.Collections.Generic;
using System.Text;

namespace HackerspaceApp.Models
{
    public class WebHookConfigModel
    {
        public string Title { get; set; } // example: Door (webhooks will be grouped by title on the dashboard)
        public string ActionLabel { get; set; } // example: Lock, Unlock
        public string Url { get; set; }
    }
}
