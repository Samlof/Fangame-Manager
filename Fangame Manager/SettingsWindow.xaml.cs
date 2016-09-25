using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fangame_Manager
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            Properties.Settings.Default.Reload();
        }

        protected override void OnClosed(EventArgs e)
        {
            Properties.Settings.Default.Save();
            base.OnClosed(e);
        }

        private void StartAutoFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDial = new OpenFileDialog();
            if(openFileDial.ShowDialog() == true)
            {
                Properties.Settings.Default.startScriptFilename = openFileDial.FileName;
            }
        }

        private void StopAutoFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDial = new OpenFileDialog();
            if (openFileDial.ShowDialog() == true)
            {
                Properties.Settings.Default.stopScriptFilename = openFileDial.FileName;
            }

        }

        private void ExtractProgram_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDial = new OpenFileDialog();
            if (openFileDial.ShowDialog() == true)
            {
                Properties.Settings.Default.extractProgramFilename = openFileDial.FileName;
            }
        }

        private void StartScript_Click(object sender, RoutedEventArgs e)
        {
            AutohotkeyScriptManager.Start();
        }

        private void StopScript_Click(object sender, RoutedEventArgs e)
        {
            AutohotkeyScriptManager.Stop();
        }

        private void AddCurrentCompletedToSheetButton_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.addCurrentCompletedToSheet();
        }
    }
}
