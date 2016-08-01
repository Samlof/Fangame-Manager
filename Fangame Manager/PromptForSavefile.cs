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
    public partial class PromptForSavefile : Form
    {
        public PromptForSavefile(bool s1, bool s2, bool s3, string gamename)
        {
            InitializeComponent();
            gameNameLabel.Text = gamename;
            AcceptButton = save1Button;
            if (!s1)
            {
                AcceptButton = save2Button;
                save1Button.Hide();
            }
            if (!s2)
            {
                save2Button.Hide();
            }
            if (!s3)
            {
                save3Button.Hide();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
