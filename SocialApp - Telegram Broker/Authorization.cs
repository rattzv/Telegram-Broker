using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialApp___Telegram_Broker
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
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
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void BunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }






        private async void Button1_Click(object sender, EventArgs e)
        {
            this.label6.Visible = false;
            string login = bunifuMaterialTextbox1.Text;
            string password = bunifuMaterialTextbox2.Text;
            if (login.Equals("") || (password.Equals("")))
            {
                this.label6.Text = "Все поля обязательны для заполнения";
                this.label6.Visible = true;
            }
            else {
                pictureBox7.Visible = true;
                bool EmailValidate_status = x4526.EmailValidate(login);
                if (EmailValidate_status == true)
                {
                    string result = await Task.Factory.StartNew<string>(() => x4526.ProcessAuth(login, password), TaskCreationOptions.LongRunning);
                    switch (result)
                    {
                        case "not_found":
                            this.label6.Text = "Неверный логин или пароль. Попробуйте еще раз.";
                            break;
                        case "not_paid":
                            this.label6.Text = "Необходимо оплатить подписку, обратитесь к администратору: ссылка на Админа.";
                            break;
                        case "":
                            this.label6.Text = "Сервер не отвечает, попробуйте позднее.";
                            break;
                        default:
                            this.label6.Text = "";
                            this.Hide();
                            using (Worksheet fr = new Worksheet()) {
                                fr.user_dataJson = result;
                                fr.ShowDialog();
                            }
                            break;

                    }
                    this.label6.Visible = true;
                    pictureBox7.Visible = false;
                }

                else
                {
                    this.label6.Text = "Некорректный email адрес.";
                    this.label6.Visible = true;
                    pictureBox7.Visible = false;
                }
            }
            
        }

        private void BunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            bunifuCheckbox1.Checked = !bunifuCheckbox1.Checked;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private async void Button4_Click_1(object sender, EventArgs e)
        {
            this.label10.Visible = false;
            string login = bunifuMaterialTextbox4.Text;
            string password = bunifuMaterialTextbox3.Text;
            string rePassword = bunifuMaterialTextbox5.Text;
            string subscription_type = bunifuDropdown1.selectedValue;
            string processorID = x4526.getProcessorID();
            string motherBoardID = x4526.getMotherBoardID();
            string hash_system = processorID + motherBoardID;

            if (login.Equals("") || password.Equals("") || rePassword.Equals(""))
            {
                this.label10.Text = "Все поля обязательны для заполнения";
                this.label10.Visible = true;
            }
            else {
                if (password != rePassword)
                {
                    this.label10.Text = "Пароли не совпадают";
                    this.label10.Visible = true;
                }
                else {
                    pictureBox8.Visible = true;
                    bool EmailValidate_status = x4526.EmailValidate(login);
                    if (EmailValidate_status == true)
                    {
                        string result = await Task.Factory.StartNew<string>(() => x4526.checkEmailExist(login, password, subscription_type, hash_system, motherBoardID, processorID), TaskCreationOptions.LongRunning);
                        if (result == "emailExist")
                        {
                            this.label10.Text = "Пользователь с таким email уже зарегистрирован.";
                            this.label10.Visible = true;
                            pictureBox8.Visible = false;
                        }
                        else {
                            pictureBox8.Visible = false;
                            MessageBox.Show("Регистрация прошла успешно! Обратитесь к разработчикам для оплаты подписки, доступ будет предоставлен только после оплаты.");
                            tabControl1.SelectedIndex = 0;
                            bunifuMaterialTextbox4.Text = "";
                            bunifuMaterialTextbox3.Text = "";
                            bunifuMaterialTextbox5.Text = "";
                        }
                    }

                    else
                    {
                        this.label10.Text = "Некорректный email адрес.";
                        this.label10.Visible = true;
                        pictureBox8.Visible = false;
                    }
                }
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
    }
}
