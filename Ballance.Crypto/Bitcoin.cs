using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace Ballance.Crypto
{
    public class Bitcoin
    {
        public string GetCurrentPrice()
        {
            return "550.991";
        }

        public string GetLivePrice(string url, string matcher)
        {
            var htmlWeb = new HtmlWeb();
            var htmlDoc = htmlWeb.Load(url);

            var price = htmlDoc.GetElementbyId(matcher).InnerText;

            return price;
        }

        public string GetLivePriceJSON(string url, string p2)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = string.Empty;
                try
                {
                    json = webClient.DownloadString(url);

                }
                catch (WebException wex)
                {
                    if (wex.Message.Contains("The remote server returned an error: (429)"))
                    {
                        return "Error (429) You clicky too fast!";
                    }
                    return wex.ToString();
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                
                dynamic JsonDe = JsonConvert.DeserializeObject(json);
                return JsonDe["last"];
            }
        }
    }
}
