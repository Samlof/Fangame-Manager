using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fangame_Manager
{
    public partial class WaitForm : Form
    {
        private static WaitForm instance;


        public static WaitForm Instance
        {
            get { return instance; }
        }

        public WaitForm(string text)
        {
            instance = this;
            InitializeComponent();

            pleaseWaitLabel.Text = text;
        }

        public void updateProgress(string s)
        {
            progressLabel.Text = "Progess: " + s;
        }
    }
}
