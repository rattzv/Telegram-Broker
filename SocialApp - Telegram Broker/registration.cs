using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialApp___Telegram_Broker
{
    class registration
    {
        public class JsonPersonAPI
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string gender { get; set; }
            public string region { get; set; }
        }
        public static string getPersonAPI()
        {
            string url = "https://randus.org/api.php";
            using (var webClient = new WebClient())
            {
                // Создаём коллекцию параметров
                var pars = new NameValueCollection();
                // Добавляем необходимые параметры в виде пар ключ, значение
                pars.Add("key", "13sd54f68s7dr435v1b4nr3y6m8s7j3hd41cm3fu8yc43x");
                var response = webClient.UploadValues(url, pars);
                string str_response = System.Text.Encoding.UTF8.GetString(response);
                return str_response;
            }
        }
    }
}
