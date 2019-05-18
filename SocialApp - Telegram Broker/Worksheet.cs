using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using CsvHelper;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SocialApp___Telegram_Broker
{
    public partial class Worksheet : Form
    {
        public static Worksheet FormPars = null;
        public Worksheet()
        {
            FormPars = this;
            InitializeComponent();
            panel4.Height = button1.Height;
            panel4.Top = button1.Top;

        }
        public string user_dataJson;
        public CancellationTokenSource tokenCancel;
        private void Form2_Load(object sender, EventArgs e)
        {
            bunifuDropdown9.Clear();
            string[] items = { "Россия", "Украина" };
            foreach (var item in items)
            {
                bunifuDropdown9.AddItem(item);
            }
            bunifuDropdown9.selectedIndex = 0;
            QuickType.Account account = JsonConvert.DeserializeObject<QuickType.Account>(user_dataJson);
            label10.Text = account.email;
            if (account.subscription_status == "paid")
            {
                label17.Text = "активна, оплачена";
            }
            switch (account.subscription_type)
            {
                case "limit_30_day":
                    label19.Text = "Ежемесячная подписка";
                    break;
                case "limit_year":
                    label19.Text = "Годовая подписка";
                    break;
                case "no_limit":
                    label19.Text = "Пожизненная подписка";
                    break;
                case "limit_1_day":
                    label19.Text = "Демо-версия (1 день)";
                    break;
            }
            label13.Text = Convert.ToString(account.date_registration);
            label15.Text = Convert.ToString(account.date_last_payment);
            label21.Text = account.renewal_counter;
            DateTime reg_date = account.date_last_payment;
            DateTime now = DateTime.Now;
            TimeSpan t = now - reg_date;
            double NrOfDays = Math.Round(30 - t.TotalDays);
            bunifuCircleProgressbar1.Value = Convert.ToInt32(NrOfDays);
            label28.Text = Convert.ToString(NrOfDays);
            label30.Text = Convert.ToString(NrOfDays);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            panel4.Height = button1.Height;
            panel4.Top = button1.Top;
            tabControl1.SelectedIndex = 7;
            label4.Text = "Регистрация";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
            tabControl1.SelectedIndex = 3;
            label4.Text = "Парсинг";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            panel4.Height = button3.Height;
            panel4.Top = button3.Top;
            tabControl1.SelectedIndex = 8;
            label4.Text = "Рассылка";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            panel4.Height = button4.Height;
            panel4.Top = button4.Top;
            tabControl1.SelectedIndex = 6;
            label4.Text = "Чекер";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            panel4.Height = 0;
            panel4.Top = 0;
            tabControl1.SelectedIndex = 9;
            label4.Text = "Парсинг. Таблица учатсников";

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            panel4.Height = button6.Height;
            panel4.Top = button6.Top;
            tabControl1.SelectedIndex = 4;
            label4.Text = "Поддержка и связь";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            panel4.Height = button7.Height;
            panel4.Top = button7.Top;
            tabControl1.SelectedIndex = 1;
            label4.Text = "Настройки";

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            panel4.Height = 0;
            label4.Text = "Мой аккаунт";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            panel4.Height = button8.Height;
            panel4.Top = button8.Top;
            tabControl1.SelectedIndex = 2;
            label4.Text = "Обновление и предложения";
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        bool drag = false;
        Point start_point = new Point(0, 0);
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Panel3_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void Panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void Panel3_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            int i;
            if (bunifuCustomTextbox4.Text == "")
            {
                i = 1;
            }
            else
            {
                i = Convert.ToInt32(bunifuCustomTextbox4.Text);
            }


            if (i > 0)
            {
                bunifuCustomTextbox4.Text = Convert.ToString(i - 1);
            }
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            int i;
            if (bunifuCustomTextbox4.Text == "")
            {
                i = 0;
            }
            else
            {
                i = Convert.ToInt32(bunifuCustomTextbox4.Text);
            }


            if (i >= 0)
            {
                bunifuCustomTextbox4.Text = Convert.ToString(i + 1);
            }
        }

        private void BunifuCustomTextbox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
        private async void BunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.tokenCancel = new CancellationTokenSource();
            CancellationToken token = tokenCancel.Token;
            await Task.Run(
                async () =>
                {
                    if (Convert.ToInt32(bunifuCustomTextbox6.Text) < Convert.ToInt32(bunifuCustomTextbox9.Text))
                    {
                        button18.Invoke(new Action(() => button18.Text = "Ожидайте..."));
                        button18.Invoke(new Action(() => button18.Enabled = false));
                        button22.Invoke(new Action(() => button22.Visible = false));
                        button23.Invoke(new Action(() => button23.Visible = false));
                        button24.Invoke(new Action(() => button24.Visible = false));

                        int minTime = Convert.ToInt32(bunifuCustomTextbox6.Text);
                        int maxTime = Convert.ToInt32(bunifuCustomTextbox9.Text);
                        bool usernameCheck = bunifuCheckbox1.Checked;
                        bool wasRecently = bunifuCheckbox2.Checked;
                        bool wasAWeekAgo = bunifuCheckbox3.Checked;
                        bool wasAMonthAgo = bunifuCheckbox4.Checked;
                        string status_flag = null;
                        bunifuDropdown6.Invoke(new Action(() => status_flag = bunifuDropdown6.selectedValue));
                        string chatname = bunifuMaterialTextbox4.Text;
                        bool flag = Model_parsing.parsechat(chatname);
                        string parsingOnly = null;
                        bunifuDropdown7.Invoke(new Action(() => parsingOnly = bunifuDropdown7.selectedValue));
                        if (flag == true)
                        {
                            string result = await Task.Factory.StartNew<string>(() => Model_parsing.parsAPI(token, chatname, FormPars), TaskCreationOptions.LongRunning);
                            switch (result)
                            {
                                case "error":
                                    FormPars.PushMessage.ShowBalloonTip(1000, "Ошибка обработки запроса, указанный чат не сущестует", "Ошибка: обработка запроса", ToolTipIcon.Warning);
                                    bunifuMaterialTextbox4.Invoke(new Action(() => bunifuMaterialTextbox4.Text = ""));
                                    bunifuCustomTextbox5.Invoke(new Action(() => bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Ошибка обработки запроса, возможно указанный чат не сущестует." + Environment.NewLine)));
                                    break;
                                case "limit":
                                    PushMessage.ShowBalloonTip(1000, "Максимальное число участников чата для парсинга - 10 000", "Ошибка: лимит парсинга", ToolTipIcon.Warning);
                                    bunifuCustomTextbox5.Invoke(new Action(() =>
                                    {
                                        bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Ошибка: лимит парсинга!" + "\n" + "Максимальное число участников чата для парсинга - 10 000." + Environment.NewLine);
                                        bunifuMaterialTextbox4.Text = "";
                                    }));
                                    break;
                                case "cancel":
                                    break;
                                default:
                                    if (token.IsCancellationRequested)
                                    {
                                        button18.Invoke(new Action(() =>
                                        {
                                            bunifuMaterialTextbox4.Text = "";
                                            button18.Text = "Начать";
                                            label54.Text = "готов к работе";
                                            button18.Enabled = true;
                                            bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Парсинг прерван пользователем." + Environment.NewLine);
                                        }));
                                        return;
                                    }
                                    string JsonDecode = await Task.Factory.StartNew<string>(() => Model_parsing.convertJsonToDataGrid(token, result, FormPars, usernameCheck, wasRecently, wasAWeekAgo, wasAMonthAgo, minTime, maxTime, status_flag, parsingOnly), TaskCreationOptions.LongRunning);
                                    button22.Invoke(new Action(() =>
                                    {
                                        button22.Visible = true;
                                        button23.Visible = true;
                                        button24.Visible = true;
                                    }));
                                    break;
                            }
                        }
                        else
                        {
                            FormPars.PushMessage.ShowBalloonTip(1000, "Ошибка входных данных. Ссылка на чат неверного формата", "Ошибка: входной параметр", ToolTipIcon.Warning);
                            bunifuMaterialTextbox4.Invoke(new Action(() => bunifuMaterialTextbox4.Text = ""));
                            bunifuCustomTextbox5.Invoke(new Action(() => bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Ошибка входных данных. Ссылка на чат неверного формата." + Environment.NewLine)));
                        }
                        button18.Invoke(new Action(() =>
                        {
                            bunifuMaterialTextbox4.Text = "";
                            button18.Text = "Начать";
                            button18.Enabled = true;
                        }));


                    }
                    else
                    {
                        FormPars.PushMessage.ShowBalloonTip(1000, "Ошибка входных данных. Некоректный временной интервал", "Ошибка: входной параметр", ToolTipIcon.Warning);
                        bunifuCustomTextbox5.Invoke(new Action(() => bunifuCustomTextbox5.AppendText("[" + DateTime.Now + "] " + "Ошибка входных данных. Некоректный временной интервал." + Environment.NewLine)));
                    }
                }, token);

        }
        private void Button23_Click(object sender, EventArgs e)
        {
            string fileName = label72.Text + DateTime.Now.ToString("_HH-mm-ss");
            Exporting.exportCSV(FormPars, fileName);
            button24.Visible = true;
            button23.Visible = false;
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", Application.StartupPath + @"\Parser");
        }

        private void BunifuImageButton3_Click_1(object sender, EventArgs e)
        {
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
            tabControl1.SelectedIndex = 3;
            label4.Text = "Парсер";
        }

        private void BunifuCustomTextbox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            int i;
            if (bunifuCustomTextbox6.Text == "")
            {
                i = 1;
            }
            else
            {
                i = Convert.ToInt32(bunifuCustomTextbox6.Text);
            }
            if (i > 0)
            {
                bunifuCustomTextbox6.Text = Convert.ToString(i - 1);
            }
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            int i;
            if (bunifuCustomTextbox6.Text == "")
            {
                i = 0;
            }
            else
            {
                i = Convert.ToInt32(bunifuCustomTextbox6.Text);
            }
            if (i >= 0 && i < 60)
            {
                bunifuCustomTextbox6.Text = Convert.ToString(i + 1);
            }
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            int i;
            if (bunifuCustomTextbox9.Text == "")
            {
                i = 0;
            }
            else
            {
                i = Convert.ToInt32(bunifuCustomTextbox9.Text);
            }
            if (i >= 0 && i < 60)
            {
                bunifuCustomTextbox9.Text = Convert.ToString(i + 1);
            }
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            int i;
            if (bunifuCustomTextbox9.Text == "")
            {
                i = 1;
            }
            else
            {
                i = Convert.ToInt32(bunifuCustomTextbox9.Text);
            }
            if (i > 0)
            {
                bunifuCustomTextbox9.Text = Convert.ToString(i - 1);
            }
        }

        private void BunifuDropdown6_onItemSelected(object sender, EventArgs e)
        {
            if (bunifuDropdown6.selectedValue == "Онлайн")
            {

                bunifuCustomTextbox6.Text = "00";
                bunifuCustomTextbox9.Text = "60";
                button20.Enabled = false;
                button21.Enabled = false;
                button26.Enabled = false;
                button27.Enabled = false;
                bunifuCustomTextbox6.Enabled = false;
                bunifuCustomTextbox9.Enabled = false;
            }
            else
            {
                button20.Enabled = true;
                button21.Enabled = true;
                button26.Enabled = true;
                button27.Enabled = true;
                bunifuCustomTextbox6.Text = "0";
                bunifuCustomTextbox9.Text = "60";
                bunifuCustomTextbox6.Enabled = true;
                bunifuCustomTextbox9.Enabled = true;
            }
        }
        private void BunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            if (bunifuDropdown1.selectedValue == "Латиница + иероглифические")
            {
                bunifuDropdown9.Clear();
                string[] items = { "Армения", "Австралия", "Бельгия", "Канада", "Китай", "Эстония", "Финляндия", "Франция", "Германия", "Индия", "Италия", "Япония", "США" };
                foreach (var item in items)
                {
                    bunifuDropdown9.AddItem(item);
                }
                bunifuDropdown9.selectedIndex = 12;
            }

            if (bunifuDropdown1.selectedValue == "Кириллица")
            {
                bunifuDropdown9.Clear();
                string[] items = { "Россия", "Украина" };
                foreach (var item in items)
                {
                    bunifuDropdown9.AddItem(item);
                }
                bunifuDropdown9.selectedIndex = 0;
            }
        }

        private void BunifuCheckbox7_OnChange(object sender, EventArgs e)
        {
            if (!bunifuCheckbox7.Checked)
            {
                button25.Enabled = false;
                button25.Visible = false;
            }
            else
            {
                button25.Enabled = true;
                button25.Visible = true;
            }
        }

        private void BunifuCheckbox8_OnChange(object sender, EventArgs e)
        {
            if (!bunifuCheckbox8.Checked)
            {
                bunifuCustomTextbox2.Enabled = false;
                bunifuCustomTextbox2.Visible = false;
            }
            else
            {
                bunifuCustomTextbox2.Enabled = true;
                bunifuCustomTextbox2.Visible = true;
            }
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            this.tokenCancel.Cancel();
            label54.Text = "готов к работе.";
            FormPars.bunifuCustomTextbox3.Invoke(new Action(() => FormPars.bunifuCustomTextbox3.AppendText("[" + DateTime.Now + "] " + "Отмена операции. Остановка..." + Environment.NewLine)));
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Resources\Telegram.exe");
        }
    }
}
