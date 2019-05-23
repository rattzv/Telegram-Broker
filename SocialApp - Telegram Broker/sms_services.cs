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
        public static string[] GetPhoneNumber(string ServiceName, string ApiKey, string Country)
        {
            string CountryCode = GetServicesCountryCode(ServiceName, Country);
            string[] PhoneNumber = new string[2];
            string url = null;
            string result;
            switch (ServiceName)
            {
                case "sms-activate.ru":
                    url = "http://sms-activate.ru/stubs/handler_api.php?api_key=" + ApiKey + "&action=getNumber&service=tg&country=" + CountryCode;
                    using (var webClient = new WebClient())
                    {
                        webClient.Encoding = System.Text.Encoding.UTF8;
                        result = webClient.DownloadString(url);
                    }
                    if (result == "NO_NUMBERS")
                    {
                        PhoneNumber[0] = "NO_NUMBERS";
                    }
                    else {
                        var split = result.Split(':');
                        PhoneNumber[0] = split[2];
                        PhoneNumber[1] = split[1];
                    }
                    break;
                default:
                    break;
            }
            return PhoneNumber;
        }
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
        public static string GetServicesCountryCode(string ServiceName, string Country)
        {
            string ServicesCountryCode = null;
            if (ServiceName == "sms-activate.ru")
            {
                switch (Country)
                {
                    case "Россия":
                        ServicesCountryCode = "0";
                        break;
                    case "Украина":
                        ServicesCountryCode = "1";
                        break;
                    case "Казахстан":
                        ServicesCountryCode = "2";
                        break;
                    case "Китай":
                        ServicesCountryCode = "3";
                        break;
                    case "США":
                        ServicesCountryCode = "12";
                        break;
                    default:
                        break;
                }
            }
            return ServicesCountryCode;
        }
        public static string DelCountryCodeByNumber(string ServiceName, string Country, string PhoneNumber)
        {
            if (ServiceName == "sms-activate.ru")
            {
                switch (Country)
                {
                    case "Russia":
                        PhoneNumber = " " + PhoneNumber.Remove(0, 1);
                        break;
                    case "Украина":
                        break;
                    case "Казахстан":
                        PhoneNumber = " " + PhoneNumber.Remove(0, 1);
                        break;
                    case "Китай":
                        break;
                    case "США":
                        break;
                    default:
                        break;
                }
            }
            return PhoneNumber;
        }
    }
}
