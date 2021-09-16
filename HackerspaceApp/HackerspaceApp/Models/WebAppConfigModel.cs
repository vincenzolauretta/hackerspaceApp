using System;
using System.Collections.Generic;
using System.Text;

namespace HackerspaceApp.Models
{
    public class WebAppConfigModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int AutoRefresh { get; set; }
    }
}
