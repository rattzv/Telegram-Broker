using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace SocialApp___Telegram_Broker
{
    class Model_registration
    {
        ////////////////////////////////Начало WINAPI////////////////////////////////
        public static UInt32 WM_MOUSEMOVE = 0x0200;
        public static UInt32 WM_LBUTTONDOWN = 0x0201;
        public static UInt32 MK_LBUTTON = 0x0001;
        public static UInt32 MK_RBUTTON = 0x0002;
        public static UInt32 WM_LBUTTONUP = 0x0202;
        public static UInt32 WM_CHAR = 0x0102;
        public static UInt32 WM_MOUSEACTIVATE = 0x0021;
        public static UInt32 WM_KEYDOWN = 0x0100;
        public static UInt32 VK_RETURN = 0x0D;
        public static UInt32 WM_KEYUP = 0x0101;
        public static UInt32 VK_MENU = 0x12;
        public static UInt32 VK_BACK = 0x08;
        public static UInt32 WM_SETCURSOR = 0x0020;
        public static UInt32 WM_GETTEXT = 0x000D;
        public static UInt32 WM_RBUTTONDOWN = 0x0204;
        public static UInt32 WM_RBUTTONUP = 0x0205;
        public static UInt32 KEYEVENTF_KEYUP = 0x0002;
        public static UInt32 VK_CONTROL = 0x11;
        public static UInt32 WM_PARENTNOTIFY = 0x0210;
        public static UInt32 WM_ACTIVATE = 0x0006;
        public static UInt32 SC_CLOSE = 0xF060;
        public static UInt32 WM_SYSCOMMAND = 0x112;
        public static UInt32 WM_CLOSE = 0x0010;
        public static UInt32 WM_PRINT = 0x0317;
        public static UInt32 WM_PRINTCLIENT = 0x0318;
        public static UInt32 VK_SNAPSHOT = 0x2C;
        public static UInt32 KEYEVENTF_EXTENDEDKEY = 0x0001;
        public static UInt32 WM_MOUSEWHEEL = 0x020A;
        public static UInt32 WM_ACTIVATEAPP = 0x001C;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        static extern int GetPixel(IntPtr hDC, int x, int y);

        public static IntPtr MakeWParam(int LoWord, int HiWord)
        {
            return (IntPtr)((HiWord << 16) + (LoWord & 0xffff));
        }

        public static IntPtr MakeLParam(int LoWord, int HiWord)
        {
            return (IntPtr)((HiWord << 16) | (LoWord & 0xffff));
        }

        public static string[] PersonGenerate(string gender, string region) {
            string[] PersonGenerate_Lines = new string[3];
            string JsonGenerateName = GetUinames(gender, region);
            QuickType.JsonGetUinames list = Newtonsoft.Json.JsonConvert.DeserializeObject<QuickType.JsonGetUinames>(JsonGenerateName);
            PersonGenerate_Lines[0] = list.name;
            PersonGenerate_Lines[1] = list.surname;
            Random rnd = new Random();
            int value = rnd.Next(1960, 99999);
            PersonGenerate_Lines[2] = Transliterations.Transliteration.Front(PersonGenerate_Lines[0] + PersonGenerate_Lines[1]) + value;
            PersonGenerate_Lines[2] = PersonGenerate_Lines[2].ToLower();
            return PersonGenerate_Lines;
        }
        ////////////////////////////////Конец WINAPI////////////////////////////////
        public static void OpenTelegramPortable()
        {
            System.Diagnostics.Process[] processlist = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processlist)
            {

                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    string TelegramSearch = process.MainWindowTitle;
                    string[] parts = TelegramSearch.Split(' ');
                    if (parts[0] == "Telegram")
                    {
                        process.Kill();
                    }
                }
            }
            System.Diagnostics.Process.Start(@"Resources\Telegram.exe");
        }
            public static bool Test()
        {
            System.Diagnostics.Process.Start(@"Resources\Telegram.exe");
            Thread.Sleep(5000);
            IntPtr hwnd = FindWindow("Qt5QWindowIcon", null);
            Functional_actions.ButtonClick(hwnd, 405, 430);
            Functional_actions.ButtonClick(hwnd, 423, 245);
            string reg_countru = ("Russia");
            for (int i = 0; i < reg_countru.Length; i++)
            {
                SendMessage(hwnd, WM_CHAR, (IntPtr)reg_countru[i], (IntPtr)(MapVirtualKey('6', 0 << 16 | 1)));
            }
            System.Threading.Thread.Sleep(1 * 500);
            SendMessage(hwnd, WM_KEYDOWN, (IntPtr)VK_RETURN, (IntPtr)(MapVirtualKey(VK_RETURN, 0) << 16 | 1));
            System.Threading.Thread.Sleep(1 * 500);
            string reg_phone = " " + "9044296585";
            for (int i = 0; i < reg_phone.Length; i++)
            {
                SendMessage(hwnd, WM_CHAR, (IntPtr)reg_phone[i], (IntPtr)(MapVirtualKey('6', 0) << 16 | 1));
            }
            System.Threading.Thread.Sleep(1 * 500);
            Functional_actions.ButtonClick(hwnd, 501, 412);
            return true;
        }
        public static string GetUinames(string gender, string region) {
            string response;
            using (var webClient = new WebClient())
            {
                string url = "https://uinames.com/api/?";
                url += "gender=" + gender;
                url += "&region=" + region;
                webClient.Encoding = System.Text.Encoding.UTF8;
                response = webClient.DownloadString(url);
            }
            return response;
        }
        public static string SwitchRegion(string region)
        {
            switch (region) {
                case "Армения":
                    region = "Armenia";
                    break;
                case "Австралия":
                    region = "Australia";
                    break;
                case "Бельгия":
                    region = "Belgium";
                    break;
                case "Канада":
                    region = "Canada";
                    break;
                case "Китай":
                    region = "China";
                    break;
                case "Эстония":
                    region = "Estonia";
                    break;
                case "Финляндия":
                    region = "Finland";
                    break;
                case "Франция":
                    region = "France";
                    break;
                case "Германия":
                    region = "Germany";
                    break;
                case "Индия":
                    region = "India";
                    break;
                case "Италия":
                    region = "Italy";
                    break;
                case "Япония":
                    region = "Japan";
                    break;
                case "США":
                    region = "United States";
                    break;
                case "Россия":
                    region = "Russia";
                    break;
                case "Украина":
                    region = "Ukraine";
                    break;
            }
            return region;
        }
        public static string SwitchGender(string gender)
        {
            switch (gender)
            {
                case "Любой (random)":
                    gender = "random";
                    break;
                case "Мужской":
                    gender = "male";
                    break;
                case "Женский":
                    gender = "female";
                    break;
            }
            return gender;
        }
    }
}
