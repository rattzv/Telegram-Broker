using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using Newtonsoft;
using System.Text.RegularExpressions;
using System.Threading;

namespace SocialApp___Telegram_Broker
{
    class parsing
    {
        public static bool parsechat(string parsechat)
        {
            Match isMatch = Regex.Match(parsechat, @"https://t.me/(\w*)", RegexOptions.IgnoreCase);
            bool parsechat_status = isMatch.Success;
            if (parsechat_status == false)
            {
                isMatch = Regex.Match(parsechat, @"[@](\w*)", RegexOptions.IgnoreCase);
                parsechat_status = isMatch.Success;
                return parsechat_status;
            }
            return parsechat_status;
        }
        public static string parsAPI(CancellationToken token, string chatname, Form2 FormPars)
        {
            FormPars.label54.Invoke(new Action(() => FormPars.label54.Text = "выполняется..."));
            FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Начало работы" + Environment.NewLine)));
            string url = "https://kzac.ru/bot/api/parser/index.php";
            FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Подготовка запроса..." + Environment.NewLine)));
            using (var webClient = new WebClient())
            {
                string filenameLoad = "parse-" + DateTime.Now.ToString("HH-mm-ss") + ".json";
                var pars = new NameValueCollection();
                pars.Add("filename", filenameLoad);
                pars.Add("chatname", Convert.ToString(chatname));
                pars.Add("key", "13sd54f68s7dr435v1b4nr3y6m8s7j3hd41cm3fu8yc43x");
                FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Начало парсинга (может занять длительное время)" + Environment.NewLine)));
                try
                {
                    string path = "";
                    FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Запрос отправлен, ждем ответ" + Environment.NewLine)));
                    var response = webClient.UploadValues(url, pars);
                    string str_response = System.Text.Encoding.UTF8.GetString(response);
                    FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Ответ сервера получен. Анализ данных..." + Environment.NewLine)));
                    if (str_response == "limit")
                    {
                        return "limit";
                    }
                    else
                    {
                        if ((str_response != null) && (str_response != "error"))
                        {
                            FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Загрузка файла..." + Environment.NewLine)));
                            string pathSystem = Application.StartupPath + @"\fullfilearray_system";
                            if (!Directory.Exists(pathSystem))
                            {
                                DirectoryInfo di = Directory.CreateDirectory(pathSystem);
                                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                            }
                            WebClient wc = new WebClient();
                            Uri ui = new Uri(str_response);
                            path = Application.StartupPath + @"\fullfilearray_system\" + ui.Segments[5];
                            wc.DownloadFile(ui, path);
                            FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Загрузка завершена" + Environment.NewLine)));
                            return path;
                        }
                        else
                        {
                            FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Сервер вернул ошибку, проверьте входные данные. Если ошибка повторяется - обратитесь к администрации." + Environment.NewLine)));
                            return "error";
                        }
                    }
                }
                catch
                {
                    for (int s = 0; s < 25; s++)
                    {
                        try
                        {

                            FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Время ожидания ответа сервера истекло. Поиск результатов на сервере..." + Environment.NewLine)));
                            FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Загрузка файла..." + Environment.NewLine)));
                            Directory.CreateDirectory(Application.StartupPath + @"\fullfilearray_system");
                            WebClient wc = new WebClient();
                            Uri ui = new Uri("https://kzac.ru/bot/api/parser/parseDone/" + filenameLoad);
                            string path = Application.StartupPath + @"\fullfilearray_system\" + ui.Segments[5];
                            wc.DownloadFile(ui, path);
                            FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Загрузка завершена" + Environment.NewLine)));
                            return path;
                        }
                        catch
                        {
                            if (token.IsCancellationRequested)
                            {
                                FormPars.button18.Invoke(new Action(() => {
                                FormPars.bunifuMaterialTextbox4.Text = "";
                                FormPars.button18.Text = "Начать";
                                FormPars.label54.Text = "готов к работе";
                                FormPars.button18.Enabled = true;
                                FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Парсинг прерван пользователем." + Environment.NewLine);
                                }));
                                return "cancel";
                            }
                            FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Таймаут - 5 секунд." + Environment.NewLine)));
                            System.Threading.Thread.Sleep(5 * 1000);
                        }
                    }
                    FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Сервер вернул ошибку, проверьте входные данные. Если ошибка повторяется - обратитесь к администрации." + Environment.NewLine)));
                    return "error";
                }
            }
        }
        public static string convertJsonToDataGrid(CancellationToken token, string result, Form2 FormPars, bool usernameCheck, bool wasRecently, bool wasAWeekAgo, bool wasAMonthAgo, int minTime, int maxTime, string status_flag, string parsingOnly)
        {
            int minTimeIn = minTime;
            int userOnline = 0;
            int i = 1;
            string s = File.ReadAllText(result, Encoding.UTF8);
            QuickType.ParserApi list = Newtonsoft.Json.JsonConvert.DeserializeObject<QuickType.ParserApi>(s);
            FormPars.label68.Invoke(new Action(() => FormPars.label68.Text = "Чат: " + list.Title));
            FormPars.label72.Invoke(new Action(() => FormPars.label72.Text = list.Username));
            FormPars.label70.Invoke(new Action(() => FormPars.label70.Text = "Всего участников - " + list.ParticipantsCount));
            FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Начало разбора и фильтрации данных..." + Environment.NewLine)));
            foreach (QuickType.Participant r in list.Participants)
            {
                if (token.IsCancellationRequested)
                {
                    FormPars.button18.Invoke(new Action(() => {
                    FormPars.bunifuMaterialTextbox4.Text = "";
                    FormPars.button18.Text = "Начать";
                    FormPars.button18.Enabled = true;
                    }));
                    break;
                }
                if (r.User.Status != null)
                {
                    if (r.User.Type == "user")
                    {
                        FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.Add(r.User.FirstName, r.User.LastName, r.User.Username, r.Role, r.User.Status.Empty, r.User.Status.WasOnline)));
                    }
                }
                else if (r.User.Status == null) {
                    if (r.User.Type == "bot")
                    {
                        FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.Add(r.User.FirstName, r.User.LastName, r.User.Username, r.User.Type, "BOT", "BOT")));
                    }
                }
                i++;
                double numb = i * 100 / Convert.ToInt32(list.ParticipantsCount);
                FormPars.label54.Invoke(new Action(() => FormPars.label54.Text = " обработано " + Convert.ToString(Math.Round(numb)) + "%"));
            }
            for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
            {
                if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) == "userStatusOnline")
                {
                    userOnline++;
                }
            }
            FormPars.label71.Invoke(new Action(() => FormPars.label71.Text = "Сейчас онлайн - " + userOnline));
            FormPars.label54.Invoke(new Action(() => FormPars.label54.Text = " обработано 99%"));
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            switch (status_flag)
            {
                case "Минут назад":
                    minTime = unixTimestamp - (minTime * 60);
                    maxTime = unixTimestamp - (maxTime * 60);
                    for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                    {
                        if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) == "userStatusOffline")
                        {
                            if ((Convert.ToInt32(FormPars.bunifuCustomDataGrid1[5, n].Value) <= minTime) & (Convert.ToInt32(FormPars.bunifuCustomDataGrid1[5, n].Value) >= maxTime))
                            {
                            }
                            else
                            {
                                FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                            }
                        }
                        else if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) == "userStatusOnline") {
                            if (minTimeIn > 0) {
                                FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                            }
                        }
                    }
                    break;
                case "Часов назад":
                    minTime = unixTimestamp - (minTime * 3600);
                    maxTime = unixTimestamp - (maxTime * 3600);
                    for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                    {
                        if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) == "userStatusOffline")
                        {
                            if ((Convert.ToInt32(FormPars.bunifuCustomDataGrid1[5, n].Value) <= minTime) & (Convert.ToInt32(FormPars.bunifuCustomDataGrid1[5, n].Value) >= maxTime))
                            {
                            }
                            else
                            {
                                FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                            }
                        }
                        else if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) == "userStatusOnline")
                        {
                            if (minTimeIn > 0)
                            {
                                FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                            }
                        }
                    }
                    break;
                case "Дней назад":
                    minTime = unixTimestamp - (minTime * 86400);
                    maxTime = unixTimestamp - (maxTime * 86400);
                    for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                    {
                        if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) == "userStatusOffline")
                        {
                            if ((Convert.ToInt32(FormPars.bunifuCustomDataGrid1[5, n].Value) <= minTime) & (Convert.ToInt32(FormPars.bunifuCustomDataGrid1[5, n].Value) >= maxTime))
                            {
                            }
                            else
                            {
                                FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                            }
                        }
                        else if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) == "userStatusOnline")
                        {
                            if (minTimeIn > 0)
                            {
                                FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                            }
                        }
                    }
                    break;
                case "Неважно":
                    break;
                case "Онлайн":
                    for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                    {
                        if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) != "userStatusOnline")
                        {
                            FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                        }
                    }
                    break;
            }
            switch (parsingOnly) {
                case "только боты":
                    for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                    {
                        if (Convert.ToString(FormPars.bunifuCustomDataGrid1[3, n].Value) != "bot")
                        {
                            FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                        }
                    }
                    break;
                case "только пользователи":
                    for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                    {
                        if (Convert.ToString(FormPars.bunifuCustomDataGrid1[3, n].Value) != "user")
                        {
                            FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                        }
                    }
                    break;
                case "только администраторы":
                    for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                    {
                        if ((Convert.ToString(FormPars.bunifuCustomDataGrid1[3, n].Value) != "admin") & (Convert.ToString(FormPars.bunifuCustomDataGrid1[3, n].Value) != "creator"))
                        {
                            FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                        }
                    }
                    break;
                case "всех":
                    break;
                case "всех, кроме ботов":
                    for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                    {
                        if (Convert.ToString(FormPars.bunifuCustomDataGrid1[3, n].Value) == "bot")
                        {
                            FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                        }
                    }
                    break;
            }
            if (usernameCheck == true)
            {
                for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                {
                    if (Convert.ToString(FormPars.bunifuCustomDataGrid1[2, n].Value) == null || Convert.ToString(FormPars.bunifuCustomDataGrid1[2, n].Value) == "")
                    {
                        FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                    }
                }
            }
            if (wasRecently == false)
            {
                for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                {
                    if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) == "userStatusRecently")
                    {
                        FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                    }
                }
            }
            if (wasAWeekAgo == false)
            {
                for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                {
                    if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) == "userStatusLastWeek")
                    {
                        FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                    }
                }
            }
            if (wasAMonthAgo == false)
            {
                for (int n = 0; n < FormPars.bunifuCustomDataGrid1.RowCount; n++)
                {
                    if (Convert.ToString(FormPars.bunifuCustomDataGrid1[4, n].Value) == "userStatusLastMonth")
                    {
                        FormPars.bunifuCustomDataGrid1.Invoke(new Action(() => FormPars.bunifuCustomDataGrid1.Rows.RemoveAt(n--)));
                    }
                }
            }
            if (token.IsCancellationRequested)
            {
                FormPars.button18.Invoke(new Action(() =>
                {
                    FormPars.bunifuMaterialTextbox4.Text = "";
                    FormPars.button18.Text = "Начать";
                    FormPars.label54.Text = "готов к работе";
                    FormPars.button18.Enabled = true;
                    FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Парсинг прерван пользователем." + Environment.NewLine);
                }));
                return "";
            }
            else {
                FormPars.label73.Invoke(new Action(() => FormPars.label73.Text = "Получено строк - " + FormPars.bunifuCustomDataGrid1.RowCount));
                FormPars.label54.Invoke(new Action(() => FormPars.label54.Text = " обработано 100%"));
                FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Парсинг завершен." + Environment.NewLine)));
                FormPars.bunifuCustomTextbox5.Invoke(new Action(() => FormPars.bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Получено участников (с учетом фильтрации): " + Convert.ToString(FormPars.bunifuCustomDataGrid1.RowCount) + Environment.NewLine)));
                FormPars.label66.Invoke(new Action(() => FormPars.label66.Visible = true));
                FormPars.label67.Invoke(new Action(() => FormPars.label67.Visible = true));
                FormPars.bunifuDropdown8.Invoke(new Action(() => FormPars.bunifuDropdown8.Visible = true));
                FormPars.button22.Invoke(new Action(() => FormPars.button22.Visible = true));
                FormPars.button23.Invoke(new Action(() => FormPars.button23.Visible = true));
                FormPars.PushMessage.ShowBalloonTip(1000, "Парсинг участников группы - " + list.Title + " завершен", "Парсинг завершен", ToolTipIcon.Info);
                return "Ok";
            }
            
        }
    }
}