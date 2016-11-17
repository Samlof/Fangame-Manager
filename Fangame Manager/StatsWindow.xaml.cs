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
    /// Interaction logic for StatsWindow.xaml
    /// </summary>
    public partial class StatsWindow : Window
    {
        static StatsWindow _instance;
        public static StatsWindow Instance { get { return _instance; } }
        InputManager inputManager;
        public StatsWindow()
        {
            inputManager = new InputManager();
            InitializeComponent();
            _instance = this;
        }


        public string frames { get; set; } = "0";
        public string jumpMs { get { return inputManager.jumpMillis.ToString() + "ms"; } }
        public string shootAmnt { get { return inputManager.shootAmout + "z"; } }
    }
}
