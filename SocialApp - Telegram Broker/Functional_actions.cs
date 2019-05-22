using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialApp___Telegram_Broker
{
    class Functional_actions
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

        public class Win32
        {

            [DllImport("user32.dll")]
            public static extern IntPtr GetDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);
            [DllImport("gdi32.dll")]
            public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);
            public static System.Drawing.Color GetPixelColor(int x, int y)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                uint pixel = GetPixel(hdc, x, y);
                ReleaseDC(IntPtr.Zero, hdc);
                Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                             (int)(pixel & 0x0000FF00) >> 8,
                             (int)(pixel & 0x00FF0000) >> 16);
                return color;
            }
        }

        public static void ButtonClick(IntPtr hwnd, int x, int y)
        {
            SetFocus(hwnd);
            SendMessage(hwnd, WM_MOUSEACTIVATE, IntPtr.Zero, MakeLParam(x, y));
            SendMessage(hwnd, WM_LBUTTONDOWN, (IntPtr)MK_LBUTTON, MakeLParam(x, y));
            SendMessage(hwnd, WM_LBUTTONUP, IntPtr.Zero, MakeLParam(x, y));
        }
        public static IntPtr GetHandle()
        {
            IntPtr hwnd = IntPtr.Zero;
            System.Diagnostics.Process[] processlist = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processlist)
            {

                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    string TelegramSearch = process.MainWindowTitle;
                    string[] parts = TelegramSearch.Split(' ');
                    if (parts[0] == "Telegram")
                    {
                        hwnd = process.MainWindowHandle;
                    }
                }
            }
            MoveWindow(hwnd, 0, 0, 800, 600, true);
            return hwnd;
        }
        public static string GetPixel(int x, int y) {
            IntPtr hwnd = GetHandle();
            IntPtr hDC = Win32.GetDC(hwnd);
            uint colorRef = Win32.GetPixel(hDC, x, y);
            Color color = Color.FromArgb((int)(colorRef & 0x000000FF), (int)(colorRef & 0x0000FF00) >> 8, (int)(colorRef & 0x00FF0000) >> 16);
            Win32.ReleaseDC(hwnd, hDC);
            string HTMLColor = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            return HTMLColor;
        }
        public static string CheckConnectProxy()
        {
            string HTMLColorConnect = null;
            string HTMLColorBlue = null;
            int i = 0;
            do
            {
                HTMLColorConnect = GetPixel(8, 585);
                Thread.Sleep(1 * 40);
                //Проверка щита
                HTMLColorBlue = GetPixel(21, 577);
                //Конец проверки щита
                i++;
            }
            while ((HTMLColorConnect == "CFCFCF") & (i < 125) & (HTMLColorBlue != "40A7E3"));
            if (HTMLColorBlue == "40A7E3")
            {
                return "true";
            }
            else if (HTMLColorConnect == "CFCFCF")
            {
                return "false";
            }
            else {
                return "aaa";
            }
        }
    }
}
