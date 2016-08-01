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
    public partial class PromptForRating : Form
    {
        public PromptForRating(string gamename)
        {
            InitializeComponent();
            ratingLabel.Text += " " + gamename;
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
