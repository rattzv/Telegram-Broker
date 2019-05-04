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

namespace SocialApp___Telegram_Broker
{
    public partial class Form2 : Form
    {
        public static Form2 FormPars = null;
        public Form2()
        {
            FormPars = this;
            InitializeComponent();
            panel4.Height = button1.Height;
            panel4.Top = button1.Top;

        }
        public string user_dataJson;
        private void Form2_Load(object sender, EventArgs e)
        {
            x4526.Account account = JsonConvert.DeserializeObject<x4526.Account>(user_dataJson);
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
            label4.Text = "Парсер";
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

        private void Button15_Click(object sender, EventArgs e)
        {
            bunifuCustomTextbox3.AppendText("[" + DateTime.Now + "] - " + "Программа запущена" + Environment.NewLine);
        }

        private async void BunifuImageButton3_Click(object sender, EventArgs e)
        {
            
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            int minTime = Convert.ToInt32(bunifuCustomTextbox6.Text);
            int maxTime = Convert.ToInt32(bunifuCustomTextbox9.Text);
            bool usernameCheck = bunifuCheckbox1.Checked;
            bool wasRecently = bunifuCheckbox2.Checked;
            bool wasAWeekAgo = bunifuCheckbox3.Checked;
            bool wasAMonthAgo = bunifuCheckbox4.Checked;
            string status_flag = bunifuDropdown6.selectedValue;
            string chatname = bunifuMaterialTextbox4.Text;
            bool flag = parsing.parsechat(chatname);
            if (flag == true)
            {
                bunifuCustomDataGrid1.Rows.Clear();
                string result = await Task.Factory.StartNew<string>(() => parsing.parsAPI(chatname, FormPars), TaskCreationOptions.LongRunning);
                if (result != null) {
                    string JsonDecode = await Task.Factory.StartNew<string>(() => parsing.convertJsonToDataGrid(result, FormPars, usernameCheck, wasRecently, wasAWeekAgo, wasAMonthAgo, minTime, maxTime, status_flag), TaskCreationOptions.LongRunning);
                    button22.Visible = true;
                    button23.Visible = true;
                    button24.Visible = true;
                }
            }
            else {
                MessageBox.Show("Ошибка входных данных. Ссылка на чат неверного формата");
                bunifuMaterialTextbox4.Text = "";
            }
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            int i;
            if (bunifuCustomTextbox5.Text == "")
            {
                i = 1;
            }
            else
            {
                i = Convert.ToInt32(bunifuCustomTextbox5.Text);
            }


            if (i > 0)
            {
                bunifuCustomTextbox5.Text = Convert.ToString(i - 1);
            }
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            int i;
            if (bunifuCustomTextbox5.Text == "")
            {
                i = 0;
            }
            else
            {
                i = Convert.ToInt32(bunifuCustomTextbox5.Text);
            }


            if (i >= 0 & i < 60)
            {
                bunifuCustomTextbox5.Text = Convert.ToString(i + 1);
            }
        }
        private void Button23_Click(object sender, EventArgs e)
        {
            string fileName = label72.Text + DateTime.Now.ToString("_HH-mm-ss");
            Exporting.exportCSV(FormPars, fileName);
            button24.Visible = true;
            button23.Visible = false;
        }

        private void Button19_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", Application.StartupPath + @"\Parser");
        }
    }
}
