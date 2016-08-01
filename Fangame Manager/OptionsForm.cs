using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Fangame_Manager
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            LoadOptions();
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Just a faster get/set
        bool isScriptRunning
        {
            get { return MainForm.Instance.isScriptRunning; }
            set { MainForm.Instance.isScriptRunning = value; }
        }

        public void LoadOptions()
        {
            startFileNameBox.Text = Properties.Settings.Default.startScriptFilename;
            endFileNameBox.Text = Properties.Settings.Default.stopScriptFilename;


            if (!Properties.Settings.Default.driveSheetInsertOn)
            {
                int heightToRemove = googleSettingsPanel.Size.Height;
                googleSettingsPanel.Hide();
                System.Drawing.Size newSize = this.Size;
                newSize.Height -= heightToRemove;
                this.Size = newSize;
            }

            if (MainForm.Instance.FindExtractProgram())
            {
                extractProgramTextbox.Text = Properties.Settings.Default.extractProgramFilename;
            }
            extractProgramFileDialog.Filter = "Unrar or 7zip|unrar.exe;7z.exe";
        }


        private void startFileButton_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = autohotkeyFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                startFileNameBox.Text = autohotkeyFileDialog.FileName;
                Properties.Settings.Default.startScriptFilename = autohotkeyFileDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void endFileButton_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = autohotkeyFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                endFileNameBox.Text = autohotkeyFileDialog.FileName;
                Properties.Settings.Default.stopScriptFilename = autohotkeyFileDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void startScript_Click(object sender, EventArgs e)
        {
            MainForm.Instance.loadAutoStartScript();
        }

        private void stopScriptButton_Click(object sender, EventArgs e)
        {
            MainForm.Instance.loadAutoEndScript();
        }

        private void startFileNameBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.startScriptFilename = startFileNameBox.Text;
            Properties.Settings.Default.Save();
        }

        private void endFileNameBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.stopScriptFilename = endFileNameBox.Text;
            Properties.Settings.Default.Save();
        }
        
        

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sevenzipButton_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = extractProgramFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                extractProgramTextbox.Text = extractProgramFileDialog.FileName;
                Properties.Settings.Default.extractProgramFilename = extractProgramFileDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void UpdateGoogleOptionsPanel(bool check)
        {
            Properties.Settings.Default.driveSheetInsertOn = check;
            if (check)
            {
                if (!googleSettingsPanel.Visible)
                {
                    int heightToRemove = googleSettingsPanel.Size.Height;
                    googleSettingsPanel.Show();
                    System.Drawing.Size newSize = this.Size;
                    newSize.Height = this.Size.Height + heightToRemove;
                    this.Size = newSize;
                }
            }
            else if (!check)
            {
                if (googleSettingsPanel.Visible)
                {
                    int heightToRemove = googleSettingsPanel.Size.Height;
                    googleSettingsPanel.Hide();
                    System.Drawing.Size newSize = this.Size;
                    newSize.Height = this.Size.Height - heightToRemove;
                    this.Size = newSize;
                }
            }
        }

        private void googleSync_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            UpdateGoogleOptionsPanel(cb.Checked);
            Properties.Settings.Default.Save();
        }

        private void addCurrentCompletedButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.showAddCurrentCompletedButton = false;
            MainForm.Instance.addCurrentCompletedToSheet();
            Properties.Settings.Default.Save();
        }
    }
}
