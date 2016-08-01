namespace Fangame_Manager
{
    partial class OptionsForm
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
            this.AutohotkeyPanel = new System.Windows.Forms.Panel();
            this.endFileNameBox = new System.Windows.Forms.TextBox();
            this.startFileButton = new System.Windows.Forms.Button();
            this.startFileNameBox = new System.Windows.Forms.TextBox();
            this.stopScriptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.startScript = new System.Windows.Forms.Button();
            this.endFileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.autohotkeyFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.extractProgramButton = new System.Windows.Forms.Button();
            this.extractProgramTextbox = new System.Windows.Forms.TextBox();
            this.extractProgramLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.extractProgramFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.appStartupOptionsLabel = new System.Windows.Forms.Label();
            this.appStartupLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gameStartLabel = new System.Windows.Forms.Label();
            this.googleSettingsPanel = new System.Windows.Forms.Panel();
            this.addCurrentCompletedButton = new System.Windows.Forms.Button();
            this.startColumnLabel = new System.Windows.Forms.Label();
            this.startRowLabel = new System.Windows.Forms.Label();
            this.spreadsheetnameLabel = new System.Windows.Forms.Label();
            this.DirectoriesPanel = new System.Windows.Forms.Panel();
            this.archivesFolderNameLabel = new System.Windows.Forms.Label();
            this.folderNameForCompletedLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.completedGamedFolderTextbox = new System.Windows.Forms.TextBox();
            this.startColumnUpDown = new System.Windows.Forms.NumericUpDown();
            this.startRowUpDown = new System.Windows.Forms.NumericUpDown();
            this.spreadsheetnameTextbox = new System.Windows.Forms.TextBox();
            this.googleSync = new System.Windows.Forms.CheckBox();
            this.startScriptOnGameStartCheckbox = new System.Windows.Forms.CheckBox();
            this.openStatsFormOnGameStartCheckbox = new System.Windows.Forms.CheckBox();
            this.hideStatsOnGameExitCheckbox = new System.Windows.Forms.CheckBox();
            this.OpenStatsFormOnStartCheckbox = new System.Windows.Forms.CheckBox();
            this.extractArchivesCheckbox = new System.Windows.Forms.CheckBox();
            this.startAutoScriptOnAppStartCheckbox = new System.Windows.Forms.CheckBox();
            this.deleteArchivesOnExtractCheckbox = new System.Windows.Forms.CheckBox();
            this.moveCompletedCheckbox = new System.Windows.Forms.CheckBox();
            this.AutohotkeyPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.appStartupLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.googleSettingsPanel.SuspendLayout();
            this.DirectoriesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startColumnUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRowUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // AutohotkeyPanel
            // 
            this.AutohotkeyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutohotkeyPanel.Controls.Add(this.endFileNameBox);
            this.AutohotkeyPanel.Controls.Add(this.startFileButton);
            this.AutohotkeyPanel.Controls.Add(this.startFileNameBox);
            this.AutohotkeyPanel.Controls.Add(this.stopScriptButton);
            this.AutohotkeyPanel.Controls.Add(this.label1);
            this.AutohotkeyPanel.Controls.Add(this.startScript);
            this.AutohotkeyPanel.Controls.Add(this.endFileButton);
            this.AutohotkeyPanel.Controls.Add(this.label2);
            this.AutohotkeyPanel.Location = new System.Drawing.Point(12, 159);
            this.AutohotkeyPanel.Name = "AutohotkeyPanel";
            this.AutohotkeyPanel.Size = new System.Drawing.Size(386, 76);
            this.AutohotkeyPanel.TabIndex = 13;
            // 
            // endFileNameBox
            // 
            this.endFileNameBox.AllowDrop = true;
            this.endFileNameBox.Location = new System.Drawing.Point(124, 52);
            this.endFileNameBox.Name = "endFileNameBox";
            this.endFileNameBox.Size = new System.Drawing.Size(197, 20);
            this.endFileNameBox.TabIndex = 10;
            // 
            // startFileButton
            // 
            this.startFileButton.Location = new System.Drawing.Point(324, 27);
            this.startFileButton.Name = "startFileButton";
            this.startFileButton.Size = new System.Drawing.Size(59, 23);
            this.startFileButton.TabIndex = 6;
            this.startFileButton.Text = "Browse...";
            this.startFileButton.UseVisualStyleBackColor = true;
            this.startFileButton.Click += new System.EventHandler(this.startFileButton_Click);
            // 
            // startFileNameBox
            // 
            this.startFileNameBox.AllowDrop = true;
            this.startFileNameBox.Location = new System.Drawing.Point(124, 28);
            this.startFileNameBox.Name = "startFileNameBox";
            this.startFileNameBox.Size = new System.Drawing.Size(197, 20);
            this.startFileNameBox.TabIndex = 7;
            // 
            // stopScriptButton
            // 
            this.stopScriptButton.Location = new System.Drawing.Point(298, 2);
            this.stopScriptButton.Name = "stopScriptButton";
            this.stopScriptButton.Size = new System.Drawing.Size(85, 23);
            this.stopScriptButton.TabIndex = 9;
            this.stopScriptButton.Text = "Stop key script";
            this.stopScriptButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Autohotkey start script:";
            // 
            // startScript
            // 
            this.startScript.Location = new System.Drawing.Point(211, 2);
            this.startScript.Name = "startScript";
            this.startScript.Size = new System.Drawing.Size(87, 23);
            this.startScript.TabIndex = 8;
            this.startScript.Text = "Start key script";
            this.startScript.UseVisualStyleBackColor = true;
            // 
            // endFileButton
            // 
            this.endFileButton.Location = new System.Drawing.Point(324, 51);
            this.endFileButton.Name = "endFileButton";
            this.endFileButton.Size = new System.Drawing.Size(59, 23);
            this.endFileButton.TabIndex = 9;
            this.endFileButton.Text = "Browse...";
            this.endFileButton.UseVisualStyleBackColor = true;
            this.endFileButton.Click += new System.EventHandler(this.endFileButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Autohotkey stop script:";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(340, 388);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 14;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // autohotkeyFileDialog
            // 
            this.autohotkeyFileDialog.Filter = "Autohotkey scripts|*.ahk";
            // 
            // extractProgramButton
            // 
            this.extractProgramButton.Location = new System.Drawing.Point(292, 2);
            this.extractProgramButton.Name = "extractProgramButton";
            this.extractProgramButton.Size = new System.Drawing.Size(59, 23);
            this.extractProgramButton.TabIndex = 12;
            this.extractProgramButton.Text = "Browse...";
            this.extractProgramButton.UseVisualStyleBackColor = true;
            this.extractProgramButton.Click += new System.EventHandler(this.sevenzipButton_Click);
            // 
            // extractProgramTextbox
            // 
            this.extractProgramTextbox.AllowDrop = true;
            this.extractProgramTextbox.Location = new System.Drawing.Point(92, 3);
            this.extractProgramTextbox.Name = "extractProgramTextbox";
            this.extractProgramTextbox.Size = new System.Drawing.Size(197, 20);
            this.extractProgramTextbox.TabIndex = 13;
            // 
            // extractProgramLabel
            // 
            this.extractProgramLabel.AutoSize = true;
            this.extractProgramLabel.Location = new System.Drawing.Point(3, 7);
            this.extractProgramLabel.Name = "extractProgramLabel";
            this.extractProgramLabel.Size = new System.Drawing.Size(85, 13);
            this.extractProgramLabel.TabIndex = 14;
            this.extractProgramLabel.Text = "Extract Program:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.extractProgramLabel);
            this.panel2.Controls.Add(this.extractProgramButton);
            this.panel2.Controls.Add(this.extractProgramTextbox);
            this.panel2.Location = new System.Drawing.Point(12, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 27);
            this.panel2.TabIndex = 18;
            // 
            // extractProgramFileDialog
            // 
            this.extractProgramFileDialog.Filter = "Executable|*.exe";
            // 
            // appStartupOptionsLabel
            // 
            this.appStartupOptionsLabel.AutoSize = true;
            this.appStartupOptionsLabel.Location = new System.Drawing.Point(4, 1);
            this.appStartupOptionsLabel.Name = "appStartupOptionsLabel";
            this.appStartupOptionsLabel.Size = new System.Drawing.Size(98, 13);
            this.appStartupOptionsLabel.TabIndex = 22;
            this.appStartupOptionsLabel.Text = "App startup options";
            this.appStartupOptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // appStartupLayoutPanel
            // 
            this.appStartupLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.appStartupLayoutPanel.ColumnCount = 1;
            this.appStartupLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.appStartupLayoutPanel.Controls.Add(this.appStartupOptionsLabel, 0, 0);
            this.appStartupLayoutPanel.Controls.Add(this.OpenStatsFormOnStartCheckbox, 0, 4);
            this.appStartupLayoutPanel.Controls.Add(this.extractArchivesCheckbox, 0, 1);
            this.appStartupLayoutPanel.Controls.Add(this.startAutoScriptOnAppStartCheckbox, 0, 3);
            this.appStartupLayoutPanel.Controls.Add(this.deleteArchivesOnExtractCheckbox, 0, 2);
            this.appStartupLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.appStartupLayoutPanel.Name = "appStartupLayoutPanel";
            this.appStartupLayoutPanel.RowCount = 5;
            this.appStartupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.appStartupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.appStartupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.appStartupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.appStartupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.appStartupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.appStartupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.appStartupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.appStartupLayoutPanel.Size = new System.Drawing.Size(200, 108);
            this.appStartupLayoutPanel.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gameStartLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.startScriptOnGameStartCheckbox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.openStatsFormOnGameStartCheckbox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.hideStatsOnGameExitCheckbox, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(218, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(192, 88);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // gameStartLabel
            // 
            this.gameStartLabel.AutoSize = true;
            this.gameStartLabel.Location = new System.Drawing.Point(4, 1);
            this.gameStartLabel.Name = "gameStartLabel";
            this.gameStartLabel.Size = new System.Drawing.Size(107, 13);
            this.gameStartLabel.TabIndex = 22;
            this.gameStartLabel.Text = "Game startup options";
            this.gameStartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // googleSettingsPanel
            // 
            this.googleSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.googleSettingsPanel.Controls.Add(this.addCurrentCompletedButton);
            this.googleSettingsPanel.Controls.Add(this.startColumnUpDown);
            this.googleSettingsPanel.Controls.Add(this.startRowUpDown);
            this.googleSettingsPanel.Controls.Add(this.startColumnLabel);
            this.googleSettingsPanel.Controls.Add(this.startRowLabel);
            this.googleSettingsPanel.Controls.Add(this.spreadsheetnameLabel);
            this.googleSettingsPanel.Controls.Add(this.spreadsheetnameTextbox);
            this.googleSettingsPanel.Location = new System.Drawing.Point(9, 322);
            this.googleSettingsPanel.Name = "googleSettingsPanel";
            this.googleSettingsPanel.Size = new System.Drawing.Size(302, 84);
            this.googleSettingsPanel.TabIndex = 28;
            // 
            // addCurrentCompletedButton
            // 
            this.addCurrentCompletedButton.Location = new System.Drawing.Point(3, 57);
            this.addCurrentCompletedButton.Name = "addCurrentCompletedButton";
            this.addCurrentCompletedButton.Size = new System.Drawing.Size(180, 23);
            this.addCurrentCompletedButton.TabIndex = 34;
            this.addCurrentCompletedButton.Text = "Add current completed to sheet";
            this.addCurrentCompletedButton.UseVisualStyleBackColor = true;
            this.addCurrentCompletedButton.Click += new System.EventHandler(this.addCurrentCompletedButton_Click);
            // 
            // startColumnLabel
            // 
            this.startColumnLabel.AutoSize = true;
            this.startColumnLabel.Location = new System.Drawing.Point(114, 35);
            this.startColumnLabel.Name = "startColumnLabel";
            this.startColumnLabel.Size = new System.Drawing.Size(69, 13);
            this.startColumnLabel.TabIndex = 31;
            this.startColumnLabel.Text = "Start column:";
            // 
            // startRowLabel
            // 
            this.startRowLabel.AutoSize = true;
            this.startRowLabel.Location = new System.Drawing.Point(6, 35);
            this.startRowLabel.Name = "startRowLabel";
            this.startRowLabel.Size = new System.Drawing.Size(52, 13);
            this.startRowLabel.TabIndex = 29;
            this.startRowLabel.Text = "Start row:";
            // 
            // spreadsheetnameLabel
            // 
            this.spreadsheetnameLabel.AutoSize = true;
            this.spreadsheetnameLabel.Location = new System.Drawing.Point(2, 9);
            this.spreadsheetnameLabel.Name = "spreadsheetnameLabel";
            this.spreadsheetnameLabel.Size = new System.Drawing.Size(99, 13);
            this.spreadsheetnameLabel.TabIndex = 27;
            this.spreadsheetnameLabel.Text = "Spreadsheet name:";
            // 
            // DirectoriesPanel
            // 
            this.DirectoriesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DirectoriesPanel.Controls.Add(this.moveCompletedCheckbox);
            this.DirectoriesPanel.Controls.Add(this.textBox1);
            this.DirectoriesPanel.Controls.Add(this.archivesFolderNameLabel);
            this.DirectoriesPanel.Controls.Add(this.completedGamedFolderTextbox);
            this.DirectoriesPanel.Controls.Add(this.folderNameForCompletedLabel);
            this.DirectoriesPanel.Location = new System.Drawing.Point(12, 241);
            this.DirectoriesPanel.Name = "DirectoriesPanel";
            this.DirectoriesPanel.Size = new System.Drawing.Size(403, 52);
            this.DirectoriesPanel.TabIndex = 29;
            // 
            // archivesFolderNameLabel
            // 
            this.archivesFolderNameLabel.AutoSize = true;
            this.archivesFolderNameLabel.Location = new System.Drawing.Point(66, 31);
            this.archivesFolderNameLabel.Name = "archivesFolderNameLabel";
            this.archivesFolderNameLabel.Size = new System.Drawing.Size(153, 13);
            this.archivesFolderNameLabel.TabIndex = 2;
            this.archivesFolderNameLabel.Text = "Extracted archives folder name";
            // 
            // folderNameForCompletedLabel
            // 
            this.folderNameForCompletedLabel.AutoSize = true;
            this.folderNameForCompletedLabel.Location = new System.Drawing.Point(146, 7);
            this.folderNameForCompletedLabel.Name = "folderNameForCompletedLabel";
            this.folderNameForCompletedLabel.Size = new System.Drawing.Size(152, 13);
            this.folderNameForCompletedLabel.TabIndex = 0;
            this.folderNameForCompletedLabel.Text = "Completed games folder name:";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Fangame_Manager.Properties.Settings.Default, "foldernameForArchives", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(218, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = global::Fangame_Manager.Properties.Settings.Default.foldernameForArchives;
            // 
            // completedGamedFolderTextbox
            // 
            this.completedGamedFolderTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Fangame_Manager.Properties.Settings.Default, "foldernameForCompleted", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.completedGamedFolderTextbox.Location = new System.Drawing.Point(298, 3);
            this.completedGamedFolderTextbox.Name = "completedGamedFolderTextbox";
            this.completedGamedFolderTextbox.Size = new System.Drawing.Size(100, 20);
            this.completedGamedFolderTextbox.TabIndex = 1;
            this.completedGamedFolderTextbox.Text = global::Fangame_Manager.Properties.Settings.Default.foldernameForCompleted;
            // 
            // startColumnUpDown
            // 
            this.startColumnUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Fangame_Manager.Properties.Settings.Default, "startColumnForSheet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startColumnUpDown.Location = new System.Drawing.Point(185, 31);
            this.startColumnUpDown.Name = "startColumnUpDown";
            this.startColumnUpDown.Size = new System.Drawing.Size(37, 20);
            this.startColumnUpDown.TabIndex = 33;
            this.startColumnUpDown.Value = global::Fangame_Manager.Properties.Settings.Default.startColumnForSheet;
            // 
            // startRowUpDown
            // 
            this.startRowUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Fangame_Manager.Properties.Settings.Default, "startRowForSheet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startRowUpDown.Location = new System.Drawing.Point(61, 31);
            this.startRowUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.startRowUpDown.Name = "startRowUpDown";
            this.startRowUpDown.Size = new System.Drawing.Size(37, 20);
            this.startRowUpDown.TabIndex = 32;
            this.startRowUpDown.Value = global::Fangame_Manager.Properties.Settings.Default.startRowForSheet;
            // 
            // spreadsheetnameTextbox
            // 
            this.spreadsheetnameTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Fangame_Manager.Properties.Settings.Default, "spreadSheetnameForGoogle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.spreadsheetnameTextbox.Location = new System.Drawing.Point(107, 5);
            this.spreadsheetnameTextbox.Name = "spreadsheetnameTextbox";
            this.spreadsheetnameTextbox.Size = new System.Drawing.Size(190, 20);
            this.spreadsheetnameTextbox.TabIndex = 26;
            this.spreadsheetnameTextbox.Text = global::Fangame_Manager.Properties.Settings.Default.spreadSheetnameForGoogle;
            // 
            // googleSync
            // 
            this.googleSync.AutoSize = true;
            this.googleSync.Checked = global::Fangame_Manager.Properties.Settings.Default.driveSheetInsertOn;
            this.googleSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.googleSync.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Fangame_Manager.Properties.Settings.Default, "driveSheetInsertOn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.googleSync.Location = new System.Drawing.Point(9, 299);
            this.googleSync.Name = "googleSync";
            this.googleSync.Size = new System.Drawing.Size(238, 17);
            this.googleSync.TabIndex = 27;
            this.googleSync.Text = "Add completed game to Google Spreadsheet";
            this.googleSync.UseVisualStyleBackColor = true;
            this.googleSync.CheckedChanged += new System.EventHandler(this.googleSync_CheckedChanged);
            // 
            // startScriptOnGameStartCheckbox
            // 
            this.startScriptOnGameStartCheckbox.AutoSize = true;
            this.startScriptOnGameStartCheckbox.Checked = global::Fangame_Manager.Properties.Settings.Default.startAutoScriptOnGameStart;
            this.startScriptOnGameStartCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startScriptOnGameStartCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Fangame_Manager.Properties.Settings.Default, "startAutoScriptOnGameStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startScriptOnGameStartCheckbox.Location = new System.Drawing.Point(4, 42);
            this.startScriptOnGameStartCheckbox.Name = "startScriptOnGameStartCheckbox";
            this.startScriptOnGameStartCheckbox.Size = new System.Drawing.Size(133, 17);
            this.startScriptOnGameStartCheckbox.TabIndex = 20;
            this.startScriptOnGameStartCheckbox.Text = "Start Autohotkey script";
            this.startScriptOnGameStartCheckbox.UseVisualStyleBackColor = true;
            // 
            // openStatsFormOnGameStartCheckbox
            // 
            this.openStatsFormOnGameStartCheckbox.AutoSize = true;
            this.openStatsFormOnGameStartCheckbox.Checked = global::Fangame_Manager.Properties.Settings.Default.openStatsOnGameStart;
            this.openStatsFormOnGameStartCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openStatsFormOnGameStartCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Fangame_Manager.Properties.Settings.Default, "openStatsOnGameStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.openStatsFormOnGameStartCheckbox.Location = new System.Drawing.Point(4, 18);
            this.openStatsFormOnGameStartCheckbox.Name = "openStatsFormOnGameStartCheckbox";
            this.openStatsFormOnGameStartCheckbox.Size = new System.Drawing.Size(121, 17);
            this.openStatsFormOnGameStartCheckbox.TabIndex = 19;
            this.openStatsFormOnGameStartCheckbox.Text = "Open Stats Window";
            this.openStatsFormOnGameStartCheckbox.UseVisualStyleBackColor = true;
            // 
            // hideStatsOnGameExitCheckbox
            // 
            this.hideStatsOnGameExitCheckbox.AutoSize = true;
            this.hideStatsOnGameExitCheckbox.Checked = global::Fangame_Manager.Properties.Settings.Default.hideStatsOnGameExit;
            this.hideStatsOnGameExitCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideStatsOnGameExitCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Fangame_Manager.Properties.Settings.Default, "hideStatsOnGameExit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hideStatsOnGameExitCheckbox.Location = new System.Drawing.Point(4, 66);
            this.hideStatsOnGameExitCheckbox.Name = "hideStatsOnGameExitCheckbox";
            this.hideStatsOnGameExitCheckbox.Size = new System.Drawing.Size(138, 17);
            this.hideStatsOnGameExitCheckbox.TabIndex = 24;
            this.hideStatsOnGameExitCheckbox.Text = "Hide Stats on game exit";
            this.hideStatsOnGameExitCheckbox.UseVisualStyleBackColor = true;
            // 
            // OpenStatsFormOnStartCheckbox
            // 
            this.OpenStatsFormOnStartCheckbox.AutoSize = true;
            this.OpenStatsFormOnStartCheckbox.Checked = global::Fangame_Manager.Properties.Settings.Default.openStatsOnAppStart;
            this.OpenStatsFormOnStartCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Fangame_Manager.Properties.Settings.Default, "openStatsOnAppStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.OpenStatsFormOnStartCheckbox.Location = new System.Drawing.Point(4, 90);
            this.OpenStatsFormOnStartCheckbox.Name = "OpenStatsFormOnStartCheckbox";
            this.OpenStatsFormOnStartCheckbox.Size = new System.Drawing.Size(121, 17);
            this.OpenStatsFormOnStartCheckbox.TabIndex = 21;
            this.OpenStatsFormOnStartCheckbox.Text = "Open Stats Window";
            this.OpenStatsFormOnStartCheckbox.UseVisualStyleBackColor = true;
            // 
            // extractArchivesCheckbox
            // 
            this.extractArchivesCheckbox.AutoSize = true;
            this.extractArchivesCheckbox.Checked = global::Fangame_Manager.Properties.Settings.Default.extractArchivesOnStartup;
            this.extractArchivesCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Fangame_Manager.Properties.Settings.Default, "extractArchivesOnStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.extractArchivesCheckbox.Location = new System.Drawing.Point(4, 18);
            this.extractArchivesCheckbox.Name = "extractArchivesCheckbox";
            this.extractArchivesCheckbox.Size = new System.Drawing.Size(102, 17);
            this.extractArchivesCheckbox.TabIndex = 23;
            this.extractArchivesCheckbox.Text = "Extract archives";
            this.extractArchivesCheckbox.UseVisualStyleBackColor = true;
            // 
            // startAutoScriptOnAppStartCheckbox
            // 
            this.startAutoScriptOnAppStartCheckbox.AutoSize = true;
            this.startAutoScriptOnAppStartCheckbox.Checked = global::Fangame_Manager.Properties.Settings.Default.startAutoScriptOnAppStart;
            this.startAutoScriptOnAppStartCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Fangame_Manager.Properties.Settings.Default, "startAutoScriptOnAppStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startAutoScriptOnAppStartCheckbox.Location = new System.Drawing.Point(4, 66);
            this.startAutoScriptOnAppStartCheckbox.Name = "startAutoScriptOnAppStartCheckbox";
            this.startAutoScriptOnAppStartCheckbox.Size = new System.Drawing.Size(133, 17);
            this.startAutoScriptOnAppStartCheckbox.TabIndex = 20;
            this.startAutoScriptOnAppStartCheckbox.Text = "Start Autohotkey script";
            this.startAutoScriptOnAppStartCheckbox.UseVisualStyleBackColor = true;
            // 
            // deleteArchivesOnExtractCheckbox
            // 
            this.deleteArchivesOnExtractCheckbox.AutoSize = true;
            this.deleteArchivesOnExtractCheckbox.Checked = global::Fangame_Manager.Properties.Settings.Default.deleteArchivesOnExtract;
            this.deleteArchivesOnExtractCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Fangame_Manager.Properties.Settings.Default, "deleteArchivesOnExtract", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.deleteArchivesOnExtractCheckbox.Location = new System.Drawing.Point(4, 42);
            this.deleteArchivesOnExtractCheckbox.Name = "deleteArchivesOnExtractCheckbox";
            this.deleteArchivesOnExtractCheckbox.Size = new System.Drawing.Size(150, 17);
            this.deleteArchivesOnExtractCheckbox.TabIndex = 19;
            this.deleteArchivesOnExtractCheckbox.Text = "Delete archives on extract";
            this.deleteArchivesOnExtractCheckbox.UseVisualStyleBackColor = true;
            // 
            // moveCompletedCheckbox
            // 
            this.moveCompletedCheckbox.AutoSize = true;
            this.moveCompletedCheckbox.Checked = global::Fangame_Manager.Properties.Settings.Default.moveCompletedGamesAway;
            this.moveCompletedCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Fangame_Manager.Properties.Settings.Default, "moveCompletedGamesAway", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.moveCompletedCheckbox.Location = new System.Drawing.Point(6, 6);
            this.moveCompletedCheckbox.Name = "moveCompletedCheckbox";
            this.moveCompletedCheckbox.Size = new System.Drawing.Size(139, 17);
            this.moveCompletedCheckbox.TabIndex = 4;
            this.moveCompletedCheckbox.Text = "Move completed games";
            this.moveCompletedCheckbox.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 412);
            this.Controls.Add(this.DirectoriesPanel);
            this.Controls.Add(this.googleSettingsPanel);
            this.Controls.Add(this.googleSync);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.appStartupLayoutPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.AutohotkeyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.AutohotkeyPanel.ResumeLayout(false);
            this.AutohotkeyPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.appStartupLayoutPanel.ResumeLayout(false);
            this.appStartupLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.googleSettingsPanel.ResumeLayout(false);
            this.googleSettingsPanel.PerformLayout();
            this.DirectoriesPanel.ResumeLayout(false);
            this.DirectoriesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startColumnUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRowUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel AutohotkeyPanel;
        private System.Windows.Forms.TextBox endFileNameBox;
        private System.Windows.Forms.Button startFileButton;
        private System.Windows.Forms.TextBox startFileNameBox;
        private System.Windows.Forms.Button stopScriptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startScript;
        private System.Windows.Forms.Button endFileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog autohotkeyFileDialog;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button extractProgramButton;
        private System.Windows.Forms.TextBox extractProgramTextbox;
        private System.Windows.Forms.Label extractProgramLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog extractProgramFileDialog;
        private System.Windows.Forms.CheckBox deleteArchivesOnExtractCheckbox;
        private System.Windows.Forms.CheckBox startAutoScriptOnAppStartCheckbox;
        private System.Windows.Forms.CheckBox OpenStatsFormOnStartCheckbox;
        private System.Windows.Forms.Label appStartupOptionsLabel;
        private System.Windows.Forms.CheckBox extractArchivesCheckbox;
        private System.Windows.Forms.TableLayoutPanel appStartupLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label gameStartLabel;
        private System.Windows.Forms.CheckBox startScriptOnGameStartCheckbox;
        private System.Windows.Forms.CheckBox openStatsFormOnGameStartCheckbox;
        private System.Windows.Forms.TextBox spreadsheetnameTextbox;
        private System.Windows.Forms.CheckBox googleSync;
        private System.Windows.Forms.Panel googleSettingsPanel;
        private System.Windows.Forms.Label startColumnLabel;
        private System.Windows.Forms.Label startRowLabel;
        private System.Windows.Forms.Label spreadsheetnameLabel;
        private System.Windows.Forms.NumericUpDown startColumnUpDown;
        private System.Windows.Forms.NumericUpDown startRowUpDown;
        private System.Windows.Forms.CheckBox hideStatsOnGameExitCheckbox;
        private System.Windows.Forms.Button addCurrentCompletedButton;
        private System.Windows.Forms.Panel DirectoriesPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label archivesFolderNameLabel;
        private System.Windows.Forms.TextBox completedGamedFolderTextbox;
        private System.Windows.Forms.Label folderNameForCompletedLabel;
        private System.Windows.Forms.CheckBox moveCompletedCheckbox;
    }
}