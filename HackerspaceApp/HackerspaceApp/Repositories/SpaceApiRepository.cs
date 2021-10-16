using HackerspaceApp.Models.SpaceApi012;
using HackerspaceApp.Models.SpaceApi013;
using HackerspaceApp.Models.SpaceApi014;
using HackerspaceApp.Models.SpaceApi015Draft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HackerspaceApp.Repositories
{
    public class SpaceApiRepository
    {
        private SpaceApi012Model _api012 { get; set; }
        private SpaceApi013Model _api013 { get; set; }
        private SpaceApi014Model _api014 { get; set; }
        private SpaceApi015DraftModel _api015Draft { get; set; }
        private string _spaceApiUrl;

        public SpaceApiRepository(string spaceApiUrl)
        {
            _spaceApiUrl = spaceApiUrl;
        }

        public async Task LoadJson()
        {
            var client = new HttpClient(new System.Net.Http.HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                }
            }, false);

            //string json = await client.GetStringAsync(_spaceApiUrl);
            string json = null;

            var result = await client.GetAsync(_spaceApiUrl);
            using (var sr = new StreamReader(await result.Content.ReadAsStreamAsync(), Encoding.UTF8))
            {
                json = sr.ReadToEnd();
            }

            var obj = JsonConvert.DeserializeObject<JObject>(json);

            string apiVersion = obj["api"]?.ToString();

            if (apiVersion == null)
            {
                foreach (var item in obj["api_compatibility"])
                {
                    if (item.ToString() == "14")
                    {
                        apiVersion = "0.14";
                    }
                    else
                    {
                        
                    }
                }
            }

            switch (apiVersion)
            {
                case "0.12":
                    {
                        _api012 = JsonConvert.DeserializeObject<SpaceApi012Model>(json);
                    }
                    break;
                case "0.13":
                    {
                        _api013 = JsonConvert.DeserializeObject<SpaceApi013Model>(json);
                    }
                    break;
                case "0.14":
                    {
                        _api014 = JsonConvert.DeserializeObject<SpaceApi014Model>(json);
                    }
                    break;
                case "0.15":
                    {
                        _api015Draft = JsonConvert.DeserializeObject<SpaceApi015DraftModel>(json);
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
