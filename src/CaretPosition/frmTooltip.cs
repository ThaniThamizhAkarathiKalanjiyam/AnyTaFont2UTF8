
//////////////////////////////////////////////////////////////////////////
//                                                                      //
//  Anybody can Use, Modify, Redistribute this code freely. If this     // 
//  module has been helpful to you then just leave a comment on Website //
//                                                                      //
//////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.IO;
using WPEntities.Noolkal.Entities;
using TamilWords;

namespace CaretPosition
{
    public partial class frmTooltip : Form
    {
        List<String> lstProcesses = new List<string>();
        //List<FontMapChars> itrans = new List<FontMapChars>();
        TamilWordNLP objTamilWordNLP = new TamilWordNLP();
        bool showTheForm = false;

        public bool ShowTheForm
        {
            get { return showTheForm; }
            set { showTheForm = value; }
        }

        //include FindWindowEx
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        //include SendMessage
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        //this is a constant indicating the window that we want to send a text message
        const int WM_SETTEXT = 0X000C;

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

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            //using (Process curProcess = getNotepadProcess().)
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
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
            //if (showTheForm == true)
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                {
                    if (lastKeyWasLetter)
                    {
                        if (Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock))
                        {
                            ToggleCapsLock();
                        }
                        lastKeyWasLetter = false;
                    }
                    Keys key = (Keys)Marshal.ReadInt32(lParam);
                    if (key == Keys.Space)
                    {
                        if (!Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock))
                        {
                            ToggleCapsLock();
                        }
                    }
                    else if (key >= Keys.A && key <= Keys.Z)
                    {
                        lastKeyWasLetter = true;
                    }

                    //test();
                }

            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        public frmTooltip()
        {
            InitializeComponent();
            timer1.Start();  // Processing events from Hooks involves message queue complexities.
        }                    // Timer has been used just to avoid that Mouse and Keyboard hooking                           
        // and to keep things simple. 

        # region Data Members & Structures



        [StructLayout(LayoutKind.Sequential)]    // Required by user32.dll
        public struct RECT
        {
            public uint Left;
            public uint Top;
            public uint Right;
            public uint Bottom;
        };

        [StructLayout(LayoutKind.Sequential)]    // Required by user32.dll
        public struct GUITHREADINFO
        {
            public uint cbSize;
            public uint flags;
            public IntPtr hwndActive;
            public IntPtr hwndFocus;
            public IntPtr hwndCapture;
            public IntPtr hwndMenuOwner;
            public IntPtr hwndMoveSize;
            public IntPtr hwndCaret;
            public RECT rcCaret;
        };

        Point startPosition = new Point();       // Point required for ToolTip movement by Mouse
        GUITHREADINFO guiInfo;                     // To store GUI Thread Information
        Point caretPosition;                     // To store Caret Position  


        # endregion

        # region DllImports


        /*- Retrieves Title Information of the specified window -*/
        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        /*- Retrieves Id of the thread that created the specified window -*/
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(int hWnd, out uint lpdwProcessId);

        /*- Retrieves information about active window or any specific GUI thread -*/
        [DllImport("user32.dll", EntryPoint = "GetGUIThreadInfo")]
        public static extern bool GetGUIThreadInfo(uint tId, out GUITHREADINFO threadInfo);

        /*- Retrieves Handle to the ForeGroundWindow -*/
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /*- Converts window specific point to screen specific -*/
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, out Point position);



        # endregion

        #region Event Handlers


        private void timer1_Tick(object sender, EventArgs e)
        {

            //}
            //private void test()
            //{
            // If Tooltip window is active window (Suppose user clicks on the Tooltip Window)
            if (GetForegroundWindow() == this.Handle)
            {
                // then do no processing
                return;
            }

            // Get Current active Process
            string activeProcess = GetActiveProcess();

            // If window explorer is active window (eg. user has opened any drive)
            // Or for any failure when activeProcess is nothing               
            if (
                (activeProcess.ToLower().Contains("explorer")
                | activeProcess.ToLower().Contains("devenv")
                | activeProcess.ToLower().Contains("tace16tamilkeyboard")
                | (activeProcess == string.Empty)))
            {
                // Dissappear Tooltip
                this.Visible = false;
            }
            else
            {
                // Otherwise Calculate Caret position
                EvaluateCaretPosition();

                // Adjust ToolTip according to the Caret
                AdjustUI();

                // Display current active Process on Tooltip
                lblCurrentApp.Text = " You are Currently inside : " + activeProcess;
                this.Visible = true;
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            // Set the Mouse Cursor
            this.Cursor = Cursors.SizeAll;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // If Left Button was pressed
            if (e.Button == MouseButtons.Left)
            {
                // then move the Tooltip
                this.Left += e.Location.X - startPosition.X;
                this.Top += e.Location.Y - startPosition.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Store start position of mouse when clicked down.
            // It will be used to calculate offset during movement.
            startPosition = e.Location;
        }


        #endregion

        #region Methods



        /// <summary>
        /// This function will adjust Tooltip position and
        /// will keep it always inside the screen area.
        /// </summary>
        private void AdjustUI()
        {
            // Get Current Screen Resolution
            Rectangle workingArea = SystemInformation.WorkingArea;

            // If current caret position throws Tooltip outside of screen area
            // then do some UI adjustment.
            if (caretPosition.X + this.Width > workingArea.Width)
            {
                caretPosition.X = caretPosition.X - this.Width - 50;
            }

            if (caretPosition.Y + this.Height > workingArea.Height)
            {
                caretPosition.Y = caretPosition.Y - this.Height - 50;
            }

            this.Left = caretPosition.X;
            this.Top = caretPosition.Y;
        }

        /// <summary>
        /// Evaluates Cursor Position with respect to client screen.
        /// </summary>
        private void EvaluateCaretPosition()
        {
            caretPosition = new Point();

            // Fetch GUITHREADINFO
            GetCaretPosition();

            caretPosition.X = (int)guiInfo.rcCaret.Left + 25;
            //               caretPosition.Y = (int)guiInfo.rcCaret.Bottom + 25;
            caretPosition.Y = (int)guiInfo.rcCaret.Bottom + 5;

            ClientToScreen(guiInfo.hwndCaret, out caretPosition);

            txtCaretX.Text = (caretPosition.X).ToString();
            txtCaretY.Text = caretPosition.Y.ToString();

            textBox1.Focus();
        }

        /// <summary>
        /// Get the caret position
        /// </summary>
        public void GetCaretPosition()
        {
            guiInfo = new GUITHREADINFO();
            guiInfo.cbSize = (uint)Marshal.SizeOf(guiInfo);

            // Get GuiThreadInfo into guiInfo
            GetGUIThreadInfo(0, out guiInfo);
            ActivateTargetApplication();
        }

        /// <summary>
        /// Retrieves name of active Process.
        /// </summary>
        /// <returns>Active Process Name</returns>
        private string GetActiveProcess()
        {
            const int nChars = 256;
            int handle = 0;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = (int)GetForegroundWindow();

            // If Active window has some title info
            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                uint lpdwProcessId;
                uint dwCaretID = GetWindowThreadProcessId(handle, out lpdwProcessId);
                uint dwCurrentID = (uint)Thread.CurrentThread.ManagedThreadId;
                return Process.GetProcessById((int)lpdwProcessId).ProcessName;
            }
            // Otherwise either error or non client region
            return String.Empty;
        }



        #endregion


        private void frmTooltip_Load(object sender, EventArgs e)
        {
            lstProcesses = objTamilWordNLP.getProcessList();
            //itrans = objTamilWordNLP.getItransMap();
            ActivateTargetApplication();
        }

        StringBuilder sb = new StringBuilder();

        public void setListedWords(string givenCharacter)
        {

            if (givenCharacter == Keys.Enter.ToString())
            {

            }
            if (givenCharacter == Keys.Tab.ToString()
                || givenCharacter == Keys.Space.ToString())
            {
                sb = new StringBuilder();
                //lstBoxSuggestedWords.Items.Clear();
            }
            else
            {
                sb.Append(givenCharacter);
                lstBoxSuggestedWords.Items.Clear();
                lstBoxSuggestedWords.Items.AddRange(objTamilWordNLP.getSuggestedWordslist(sb));
            }

        }



        public void setActiveControl()
        {
            //this.ActiveControl = lstBoxSuggestedWords;
            //ActivateTargetApplication();
        }
        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);

        public void ActivateTargetApplication()
        {
            Process[] prco = Process.GetProcessesByName(this.Name);

            //Process p = Process.Start(this.Name);
            //p.WaitForInputIdle();
            IntPtr h = this.Handle;
            SetForegroundWindow(h);
            ////SendKeys.SendWait("");
            //IntPtr processFoundWindow = p.MainWindowHandle;

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                //getting notepad's process | at least one instance of notepad must be running
                //Process notepadProccess = Process.GetProcessesByName("notepad")[0];

                ////getting notepad's textbox handle from the main window's handle
                ////the textbox is called 'Edit'
                //IntPtr notepadTextbox = FindWindowEx(notepadProccess.MainWindowHandle, IntPtr.Zero, "Edit", null);
                ////sending the message to the textbox
                ////SendMessage(notepadTextbox, WM_SETTEXT, 0, textBox1.Text);
                //SendMessage(notepadTextbox, WM_SETTEXT, 0, textBox1.Text);
                //textBox1.Text = "";


                Process[] notepads = Process.GetProcessesByName("notepad");
                if (notepads.Length == 0) return;
                if (notepads[0] != null)
                {
                    wholeTextFile.Append(textBox1.Text + " ");
                    IntPtr child = FindWindowEx(notepads[0].MainWindowHandle, new IntPtr(0), "Edit", null);
                    SendMessage(child, 0x000C, 0, wholeTextFile.ToString());
                    setListedWords(textBox1.Text);
                    textBox1.Text = "";
                    //this.Visible = false;
                }
            }
        }

        StringBuilder wholeTextFile = new StringBuilder();


        static void ExportToNotepad(string text)
        {
            ProcessStartInfo startInfo = getNotepadProcess(text);

            Process notepad = Process.Start(startInfo);
            notepad.WaitForInputIdle();

            IntPtr child = FindWindowEx(notepad.MainWindowHandle, new IntPtr(0), null, null);
            SendMessage(child, 0x000c, 0, text);
        }

        private static ProcessStartInfo getNotepadProcess(string text)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(text);
            startInfo.UseShellExecute = false;
            return startInfo;
        }

    }
}
