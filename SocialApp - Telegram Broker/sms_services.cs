using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialApp___Telegram_Broker
{
    class Sms_services
    {
        public static double GetBallance(string ServiceName, string ApiKey)
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
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            double ResponceBallance_double = double.Parse(result);
            Thread.CurrentThread.CurrentCulture = temp_culture;
            return ResponceBallance_double;
        }
        public static int GetAmmountPhone(string ServiceName, string ApiKey, string Country)
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
                    break;
            }
            return Convert.ToInt32(result);
        }
    }
}
