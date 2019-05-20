using CsvHelper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SocialApp___Telegram_Broker
{
    class X4526
    {
        public static bool EmailValidate(string login)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(login, pattern, RegexOptions.IgnoreCase);
            bool EmailValidate_status = isMatch.Success;
            return EmailValidate_status;
        }
        public static string ProcessAuth(string login, string password)
        {
            string url = "https://kzac.ru/bot/login.php";
            using (var webClient = new WebClient())
            {
                // Создаём коллекцию параметров
                var pars = new NameValueCollection
                {
                    // Добавляем необходимые параметры в виде пар ключ, значение
                    { "email", Convert.ToString(login) },
                    { "password", Convert.ToString(password) },
                    { "key", "13sd54f68s7dr435v1b4nr3y6m8s7j3hd41cm3fu8yc43x" }
                };
                // Посылаем параметры на сервер
                // Может быть ответ в виде массива байт
                var response = webClient.UploadValues(url, pars);
                string str_response = System.Text.Encoding.UTF8.GetString(response);
                Thread.Sleep(1300);
                return str_response;
            }
        }
        public static string CheckEmailExist(string login, string password, string subscription_type, string hash_system, string motherBoardID, string processorID)
        {
            string url = "https://kzac.ru/bot/registered.php";
            switch (subscription_type)
            {
                case "Ежемесячная подписка":
                    subscription_type = "limit_30_day";
                    break;
                case "Годовая подписка":
                    subscription_type = "limit_year";
                    break;
                case "Пожизненная подписка":
                    subscription_type = "no_limit";
                    break;
                case "Демо-версия (1 день)":
                    subscription_type = "limit_1_day";
                    break;
            }
            using (var webClient = new WebClient())
            {
                // Создаём коллекцию параметров
                var pars = new NameValueCollection
                {
                    // Добавляем необходимые параметры в виде пар ключ, значение
                    { "email", Convert.ToString(login) },
                    { "password", Convert.ToString(password) },
                    { "subscription_type", Convert.ToString(subscription_type) },
                    { "hash_system", Convert.ToString(hash_system) },
                    { "motherBoardID", Convert.ToString(motherBoardID) },
                    { "processorID", Convert.ToString(processorID) },
                    { "key", "13sd54f68s7dr435v1b4nr3y6m8s7j3hd41cm3fu8yc43x" }
                };
                // Посылаем параметры на сервер
                // Может быть ответ в виде массива байт
                var response = webClient.UploadValues(url, pars);
                string str_response_email = System.Text.Encoding.UTF8.GetString(response);
                return str_response_email;
            }
        }
        public static string GetMotherBoardID()
        {
            string MotherBoardID = "";
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                ManagementObjectCollection moc = mos.Get();

                foreach (ManagementObject queryObj in moc)
                {
                    MotherBoardID = queryObj["SerialNumber"].ToString();
                }
                return MotherBoardID;
            }
            catch (Exception)
            {
                return "NotFoundMotherBoardID";
            }
        }
        public static string GetProcessorID()
        {
            String ProcessorID = "";
            try
            {
                ManagementObjectSearcher pocessors = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_processor");
                ManagementObjectCollection moc = pocessors.Get();
                foreach (ManagementObject queryObj in moc)
                {
                    ProcessorID = queryObj["ProcessorId"].ToString();
                }
                return ProcessorID;
            }
            catch (Exception)
            {
                return "NotFoundProcessorID";
            }
        }
        public static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
        public static DateTime UnixTimestampToDateTime(double unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (long)(unixTime * TimeSpan.TicksPerSecond);
            return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
        }
    }
}
