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

        public void updateJumpNumbers(int millis)
        {
            msLabel.Content = $"ms: {millis}";
            int frames = (millis + 3) / 20;
            frames++;
            framesLabel.Content = frames.ToString();
        }
        public void updateZnumbers(float number)
        {
            string num = number.ToString("0.0");
            zLabel.Content = $"z: {num}";
        }
    }
}
