using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Fangame_Manager
{
    class AutohotkeyScriptManager
    {

        private static string StartScriptFilePath { get { return Properties.Settings.Default.startScriptFilename; } }
        private static string StopScriptFilePath { get { return Properties.Settings.Default.stopScriptFilename; } }

        public static bool isScriptRunning { get; protected set; } = false;
        public static void Start()
        {
            if (isScriptRunning) return;
            startProcess(StartScriptFilePath);
            isScriptRunning = true;
        }

        public static void Stop()
        {
            if (!isScriptRunning) return;
            startProcess(StopScriptFilePath);
            isScriptRunning = false;
        }

        private static void startProcess(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File " + filePath + " does not exist!");
                return;
            }
            try
            {
                Process.Start(filePath);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Script file: " + filePath + " can't be handled! Maybe .ahk is not associated with autohotkey?", "File Error!");
            }
        }
    }
}
