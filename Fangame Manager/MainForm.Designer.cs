using System.Windows.Forms;

namespace Fangame_Manager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

 

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.newGamesLabel = new System.Windows.Forms.Label();
            this.newGamesListbox = new System.Windows.Forms.ListBox();
            this.recentGamesListbox = new System.Windows.Forms.ListBox();
            this.oldGamesLabel = new System.Windows.Forms.Label();
            this.recentGamesLabel = new System.Windows.Forms.Label();
            this.fangamesListbox = new System.Windows.Forms.ListBox();
            this.gamesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.completeGameButton = new System.Windows.Forms.Button();
            this.hideGameButton = new System.Windows.Forms.Button();
            this.deleteGameButton = new System.Windows.Forms.Button();
            this.gamelistButtonsPanel = new System.Windows.Forms.Panel();
            this.openStatsButton = new System.Windows.Forms.Button();
            this.gamesLayoutPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gamelistButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileDialog1
            // 
            this.fileDialog1.FileName = "openFileDialog1";
            this.fileDialog1.Filter = "Autohotkey scripts|*.ahk";
            // 
            // newGamesLabel
            // 
            this.newGamesLabel.AutoSize = true;
            this.newGamesLabel.Location = new System.Drawing.Point(154, 0);
            this.newGamesLabel.Name = "newGamesLabel";
            this.newGamesLabel.Size = new System.Drawing.Size(32, 13);
            this.newGamesLabel.TabIndex = 16;
            this.newGamesLabel.Text = "New:";
            // 
            // newGamesListbox
            // 
            this.newGamesListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newGamesListbox.FormattingEnabled = true;
            this.newGamesListbox.Location = new System.Drawing.Point(154, 18);
            this.newGamesListbox.Name = "newGamesListbox";
            this.newGamesListbox.Size = new System.Drawing.Size(145, 43);
            this.newGamesListbox.TabIndex = 15;
            this.newGamesListbox.SelectedIndexChanged += new System.EventHandler(this.newGamesListbox_SelectedIndexChanged);
            this.newGamesListbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fangamesListbox_MouseDoubleClick);
            // 
            // recentGamesListbox
            // 
            this.recentGamesListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recentGamesListbox.FormattingEnabled = true;
            this.recentGamesListbox.Location = new System.Drawing.Point(305, 18);
            this.recentGamesListbox.Name = "recentGamesListbox";
            this.recentGamesListbox.Size = new System.Drawing.Size(147, 43);
            this.recentGamesListbox.TabIndex = 17;
            this.recentGamesListbox.SelectedIndexChanged += new System.EventHandler(this.recentGamesListbox_SelectedIndexChanged);
            this.recentGamesListbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fangamesListbox_MouseDoubleClick);
            // 
            // oldGamesLabel
            // 
            this.oldGamesLabel.AutoSize = true;
            this.oldGamesLabel.Location = new System.Drawing.Point(3, 0);
            this.oldGamesLabel.Name = "oldGamesLabel";
            this.oldGamesLabel.Size = new System.Drawing.Size(43, 13);
            this.oldGamesLabel.TabIndex = 14;
            this.oldGamesLabel.Text = "Games;";
            // 
            // recentGamesLabel
            // 
            this.recentGamesLabel.AutoSize = true;
            this.recentGamesLabel.Location = new System.Drawing.Point(305, 0);
            this.recentGamesLabel.Name = "recentGamesLabel";
            this.recentGamesLabel.Size = new System.Drawing.Size(45, 13);
            this.recentGamesLabel.TabIndex = 18;
            this.recentGamesLabel.Text = "Recent:";
            // 
            // fangamesListbox
            // 
            this.fangamesListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fangamesListbox.FormattingEnabled = true;
            this.fangamesListbox.Location = new System.Drawing.Point(3, 18);
            this.fangamesListbox.Name = "fangamesListbox";
            this.fangamesListbox.Size = new System.Drawing.Size(145, 43);
            this.fangamesListbox.TabIndex = 13;
            this.fangamesListbox.SelectedIndexChanged += new System.EventHandler(this.fangamesListbox_SelectedIndexChanged);
            this.fangamesListbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fangamesListbox_MouseDoubleClick);
            // 
            // gamesLayoutPanel
            // 
            this.gamesLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gamesLayoutPanel.ColumnCount = 3;
            this.gamesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.gamesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.gamesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.gamesLayoutPanel.Controls.Add(this.fangamesListbox, 0, 1);
            this.gamesLayoutPanel.Controls.Add(this.recentGamesLabel, 2, 0);
            this.gamesLayoutPanel.Controls.Add(this.newGamesListbox, 1, 1);
            this.gamesLayoutPanel.Controls.Add(this.oldGamesLabel, 0, 0);
            this.gamesLayoutPanel.Controls.Add(this.newGamesLabel, 1, 0);
            this.gamesLayoutPanel.Controls.Add(this.recentGamesListbox, 2, 1);
            this.gamesLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.gamesLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.gamesLayoutPanel.Name = "gamesLayoutPanel";
            this.gamesLayoutPanel.RowCount = 2;
            this.gamesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.gamesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gamesLayoutPanel.Size = new System.Drawing.Size(455, 68);
            this.gamesLayoutPanel.TabIndex = 19;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(455, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.quitToolStripMenuItem,
            this.quitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(113, 6);
            // 
            // quitToolStripMenuItem1
            // 
            this.quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            this.quitToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.quitToolStripMenuItem1.Text = "Quit";
            this.quitToolStripMenuItem1.Click += new System.EventHandler(this.quitToolStripMenuItem1_Click);
            // 
            // completeGameButton
            // 
            this.completeGameButton.Location = new System.Drawing.Point(3, 3);
            this.completeGameButton.Name = "completeGameButton";
            this.completeGameButton.Size = new System.Drawing.Size(75, 23);
            this.completeGameButton.TabIndex = 19;
            this.completeGameButton.Text = "Complete";
            this.completeGameButton.UseVisualStyleBackColor = true;
            this.completeGameButton.Click += new System.EventHandler(this.completeGameButton_Click);
            // 
            // hideGameButton
            // 
            this.hideGameButton.Location = new System.Drawing.Point(84, 3);
            this.hideGameButton.Name = "hideGameButton";
            this.hideGameButton.Size = new System.Drawing.Size(75, 23);
            this.hideGameButton.TabIndex = 20;
            this.hideGameButton.Text = "Hide";
            this.hideGameButton.UseVisualStyleBackColor = true;
            this.hideGameButton.Click += new System.EventHandler(this.hideGameButton_Click);
            // 
            // deleteGameButton
            // 
            this.deleteGameButton.Location = new System.Drawing.Point(165, 3);
            this.deleteGameButton.Name = "deleteGameButton";
            this.deleteGameButton.Size = new System.Drawing.Size(75, 23);
            this.deleteGameButton.TabIndex = 22;
            this.deleteGameButton.Text = "Delete";
            this.deleteGameButton.UseVisualStyleBackColor = true;
            this.deleteGameButton.Click += new System.EventHandler(this.deleteGameButton_Click);
            // 
            // gamelistButtonsPanel
            // 
            this.gamelistButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gamelistButtonsPanel.Controls.Add(this.openStatsButton);
            this.gamelistButtonsPanel.Controls.Add(this.completeGameButton);
            this.gamelistButtonsPanel.Controls.Add(this.deleteGameButton);
            this.gamelistButtonsPanel.Controls.Add(this.hideGameButton);
            this.gamelistButtonsPanel.Location = new System.Drawing.Point(0, 89);
            this.gamelistButtonsPanel.Name = "gamelistButtonsPanel";
            this.gamelistButtonsPanel.Size = new System.Drawing.Size(440, 28);
            this.gamelistButtonsPanel.TabIndex = 23;
            // 
            // openStatsButton
            // 
            this.openStatsButton.Location = new System.Drawing.Point(247, 2);
            this.openStatsButton.Name = "openStatsButton";
            this.openStatsButton.Size = new System.Drawing.Size(75, 23);
            this.openStatsButton.TabIndex = 23;
            this.openStatsButton.Text = "Open Stats";
            this.openStatsButton.UseVisualStyleBackColor = true;
            this.openStatsButton.Click += new System.EventHandler(this.openStatsButton_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 116);
            this.Controls.Add(this.gamelistButtonsPanel);
            this.Controls.Add(this.gamesLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 155);
            this.Name = "MainForm";
            this.Text = "Fangame Manager";
            this.gamesLayoutPanel.ResumeLayout(false);
            this.gamesLayoutPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gamelistButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileDialog1;
        private System.Windows.Forms.Label newGamesLabel;
        private System.Windows.Forms.ListBox newGamesListbox;
        private System.Windows.Forms.ListBox recentGamesListbox;
        private System.Windows.Forms.Label oldGamesLabel;
        private System.Windows.Forms.Label recentGamesLabel;
        private System.Windows.Forms.ListBox fangamesListbox;
        private System.Windows.Forms.TableLayoutPanel gamesLayoutPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripSeparator quitToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem1;
        private Button completeGameButton;
        private Button hideGameButton;
        private Button deleteGameButton;
        private Panel gamelistButtonsPanel;
        private Button openStatsButton;
    }
}

