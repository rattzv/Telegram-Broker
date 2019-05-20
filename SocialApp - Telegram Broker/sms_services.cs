using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp___Telegram_Broker
{
    class Sms_services
    {
        public static string GetBallance(string ServiceName, string ApiKey)
        {
            string url;
            string response;
            string pattern;
            string result;
            switch (ServiceName)
            {
                case "sms-activate.ru":
                    url = "http://sms-activate.ru/stubs/handler_api.php?api_key=" + ApiKey + "&action=getBalance";
                    using (var webClient = new WebClient())
                    {
                        webClient.Encoding = System.Text.Encoding.UTF8;
                        response = webClient.DownloadString(url);
                    }
                    pattern = @"(?<=ACCESS_BALANCE:).*";
                    result = System.Text.RegularExpressions.Regex.Match(response, pattern).Value;
                    break;
                default:
                    result = "error";
                    break;
            }
            return result;
        }
        public static string GetAmmountPhone(string ServiceName, string ApiKey, string Country)
        {
            string url;
            string response;
            string pattern;
            string result = null;
            switch (ServiceName)
            {
                case "sms-activate.ru":
                    url = "http://sms-activate.ru/stubs/handler_api.php?api_key=" + ApiKey + "&action=getNumbersStatus&country=" + Country + "";
                    using (var webClient = new WebClient())
                    {
                        webClient.Encoding = System.Text.Encoding.UTF8;
                        response = webClient.DownloadString(url);
                    }
                    pattern = @"(?<=""tg_0"":"").*?(?="","")";
                    result = System.Text.RegularExpressions.Regex.Match(response, pattern).Value;
                    break;
                default:
                    result = "error";
                    break;
            }
            return result;
        }
    }
}
