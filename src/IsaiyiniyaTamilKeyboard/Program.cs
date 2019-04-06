using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using CaretPosition;

namespace Tace16TamilKeyboard
{
    static class Program
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static bool lastKeyWasLetter = false;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);


       static frmTooltip objfrmTooltip = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _hookID = SetHook(_proc);
            Application.Run(new IsaiyiniKeyBoard());
            UnhookWindowsHookEx(_hookID);
            
        }
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static void ToggleCapsLock()
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;

            UnhookWindowsHookEx(_hookID);
            keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            _hookID = SetHook(_proc);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if(objfrmTooltip == null)
            {
                objfrmTooltip = new frmTooltip();
            }

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                if (lastKeyWasLetter)
                {
                    if (Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock))
                    {
                        //ToggleCapsLock();//COMMETD BY MPM FOR TEST ONLY MAY ENABLE THIS
                    }
                    lastKeyWasLetter = false;
                }
                Keys key = (Keys)Marshal.ReadInt32(lParam);
                if (key == Keys.Space)
                {
                    if (!Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock))
                    {
                        //ToggleCapsLock();
                    }
                }
                else if (key >= Keys.A && key <= Keys.Z)
                {
                   lastKeyWasLetter = true;
                }
                ShowingWords(key);
                
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static void ShowingWords(Keys key)
        {
            ShowingWords();
            objfrmTooltip.setListedWords(key.ToString());

        }

        private static void ShowingWords()
        {
            
            //objfrmTooltip.Location = Cursor.Position;
            //objfrmTooltip.BringToFront();

            if (objfrmTooltip.Visible == false)
            {
                objfrmTooltip.Show();
            }
            
        }
    }

}