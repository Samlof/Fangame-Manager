using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Fangame_Manager
{
    public partial class StatsForm : Form
    {

        #region Keyhandling
        //These Dll's will handle the hooks. Yaaar mateys!

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);


        bool autofire = false;
        int autofireInterval = 100;
        System.Timers.Timer autofireTimer;
        Stopwatch autofireSw = new Stopwatch();
        Stopwatch shiftSw = new Stopwatch();
        Stopwatch zSw = new Stopwatch();
        private Queue<int> zTimes = new Queue<int>();
        int lastZinMillis = 0;
        int zCount = 0;
        bool zReleased = true;
        bool oReleased = true;
        bool processingShift = false;
        Keys keyToCheck;

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;
                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    // Pressed Jump button
                    if (!Instance.processingShift && (key == Keys.LShiftKey || key == Keys.RShiftKey))
                    {
                        Instance.processingShift = true;
                        Instance.keyToCheck = key;
                        Instance.shiftSw.Restart();
                    }
                    // Pressed Shoot button
                    else if (Instance.zReleased && key == Keys.Z)
                    {
                        if (Instance.autofire)
                        {
                            if (!Instance.autofireSw.IsRunning)
                            {
                                Instance.autofireSw.Start();
                                Instance.autofireTimer.Start();
                            }

                        }

                        // Should timer be reset
                        if ((Instance.lastZinMillis + 3000 < Instance.zSw.ElapsedMilliseconds) || !Instance.zSw.IsRunning)
                        {
                            Instance.zSw.Restart();
                            Instance.zCount = 0;
                            Instance.zTimes.Clear();
                        }

                        // Update timer and count
                        Instance.zCount++;
                        Instance.zTimes.Enqueue((int)Instance.zSw.ElapsedMilliseconds);
                        Instance.lastZinMillis = (int)Instance.zSw.ElapsedMilliseconds;
                        if (Instance.zTimes.Count > 1)
                        {
                            // Is the oldest time older than 5 seconds
                            while (Instance.zTimes.Peek() < Instance.lastZinMillis - 5000)
                            {
                                Instance.zTimes.Dequeue();
                            }

                            // Update shown time
                            int totalTime = Instance.lastZinMillis - Instance.zTimes.Peek();
                            int zTotalTimes = Instance.zTimes.Count;
                            float average = (float)zTotalTimes * 1000 / (float)totalTime;
                            Instance.UpdateStatuszAmount("z: " + average.ToString("0.0"));
                            Instance.zReleased = false;
                        }
                    }
                    else if (Instance.oReleased && key == Keys.O)
                    {
                        Instance.oReleased = false;
                        Instance.autofire = !Instance.autofire;
                    }
                }
                else if (wParam == (IntPtr)WM_KEYUP)
                {
                    // Released Jump button
                    if (Instance.processingShift && key == Instance.keyToCheck)
                    {
                        // Update frames
                        Instance.shiftSw.Stop();
                        int millis = (int)Instance.shiftSw.ElapsedMilliseconds;
                        int frames = (millis + 3) / 20;
                        frames++;
                        Instance.UpdateStatus(frames.ToString(), millis.ToString());

                        Instance.processingShift = false;
                        Instance.keyToCheck = key;
                        Instance.shiftSw.Reset();
                    }
                    // Released Shoot button
                    else if (!Instance.zReleased && key == Keys.Z)
                    {
                        Instance.zReleased = true;
                    }
                    else if (!Instance.oReleased && key == Keys.O)
                    {
                        Instance.oReleased = true;
                    }
                }
            }
            // Pass back to windows
            return CallNextHookEx(nCode, wParam, lParam);
        }

        private void AutofireTimerElapsed(object source, ElapsedEventArgs e)
        {
            SendKeys.SendWait("z");
            if (autofireSw.ElapsedMilliseconds > 500)
            {
                autofireSw.Reset();
                autofireTimer.Stop();
            }
        }
        public void UpdateStatus(string frames, string millis)
        {
            UpdateStatusfr(frames);
            UpdateStatusms(millis);
        }

        private delegate void UpdateStatusDelegate(string status);
        public void UpdateStatusfr(string status)
        {
            if (this.framesHoldedLabel.InvokeRequired)
            {
                this.Invoke(new UpdateStatusDelegate(this.UpdateStatusfr), new object[] { status });
                return;
            }

            this.framesHoldedLabel.Text = status;
        }

        public void UpdateStatuszAmount(string status)
        {
            if (this.zAverageLabel.InvokeRequired)
            {
                this.Invoke(new UpdateStatusDelegate(this.UpdateStatuszAmount), new object[] { status });
                return;
            }

            this.zAverageLabel.Text = status;
        }

        private void UpdateStatusms(string status)
        {
            if (this.millisLabel.InvokeRequired)
            {
                this.Invoke(new UpdateStatusDelegate(this.UpdateStatusms), new object[] { status });
                return;
            }

            this.millisLabel.Text = "ms: " + status;
        }
        #endregion

        public static StatsForm Instance
        {
            get { return instance; }
        }

        private static StatsForm instance;
        public StatsForm()
        {
            InitializeComponent();
            instance = this;
            _hookID = SetHook(_proc);
            autofireTimer = new System.Timers.Timer();
            autofireTimer.Elapsed += AutofireTimerElapsed;
            autofireTimer.Interval = autofireInterval;

            if (Properties.Settings.Default.statsWindowLocation.X != 0)
            {
                this.Location = Properties.Settings.Default.statsWindowLocation;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            Properties.Settings.Default.statsWindowLocation = this.Location;
            Properties.Settings.Default.Save();
            base.OnClosed(e);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            UnhookWindowsHookEx(_hookID);
            _hookID = IntPtr.Zero;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
