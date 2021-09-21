using HackerspaceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerspaceApp.ViewModels
{
    public class WebHookViewModel : BaseViewModel
    {
        public string Title
        {
            get
            {
                return WebHooks?.First()?.Title;
            }
        }
        private List<WebHookConfigModel> WebHooks { get; set; }
    }
}
