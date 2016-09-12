using System;
using System.Collections.Generic;
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

        private bool extractArchive
        {
            get { return Properties.Settings.Default.extractArchivesOnStartup; }
            set { Properties.Settings.Default.extractArchivesOnStartup = value; }
        }
        
    }
}
