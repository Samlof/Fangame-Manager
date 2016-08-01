namespace Fangame_Manager
{
    partial class PromptForSavefile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.save1Button = new System.Windows.Forms.Button();
            this.save2Button = new System.Windows.Forms.Button();
            this.save3Button = new System.Windows.Forms.Button();
            this.chooseSaveLabel = new System.Windows.Forms.Label();
            this.gameNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // save1Button
            // 
            this.save1Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.save1Button.Location = new System.Drawing.Point(6, 39);
            this.save1Button.Name = "save1Button";
            this.save1Button.Size = new System.Drawing.Size(75, 23);
            this.save1Button.TabIndex = 0;
            this.save1Button.Text = "Save1";
            this.save1Button.UseVisualStyleBackColor = true;
            this.save1Button.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // save2Button
            // 
            this.save2Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.save2Button.Location = new System.Drawing.Point(87, 39);
            this.save2Button.Name = "save2Button";
            this.save2Button.Size = new System.Drawing.Size(75, 23);
            this.save2Button.TabIndex = 1;
            this.save2Button.Text = "Save2";
            this.save2Button.UseVisualStyleBackColor = true;
            this.save2Button.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // save3Button
            // 
            this.save3Button.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.save3Button.Location = new System.Drawing.Point(168, 39);
            this.save3Button.Name = "save3Button";
            this.save3Button.Size = new System.Drawing.Size(75, 23);
            this.save3Button.TabIndex = 2;
            this.save3Button.Text = "Save3";
            this.save3Button.UseVisualStyleBackColor = true;
            this.save3Button.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // chooseSaveLabel
            // 
            this.chooseSaveLabel.AutoSize = true;
            this.chooseSaveLabel.Location = new System.Drawing.Point(55, 23);
            this.chooseSaveLabel.Name = "chooseSaveLabel";
            this.chooseSaveLabel.Size = new System.Drawing.Size(116, 13);
            this.chooseSaveLabel.TabIndex = 3;
            this.chooseSaveLabel.Text = "Choose Savefile to use";
            // 
            // gameNameLabel
            // 
            this.gameNameLabel.AutoSize = true;
            this.gameNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameNameLabel.Location = new System.Drawing.Point(11, 6);
            this.gameNameLabel.Name = "gameNameLabel";
            this.gameNameLabel.Size = new System.Drawing.Size(55, 13);
            this.gameNameLabel.TabIndex = 4;
            this.gameNameLabel.Text = "I Wanna";
            // 
            // PromptForSavefile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(249, 73);
            this.Controls.Add(this.gameNameLabel);
            this.Controls.Add(this.chooseSaveLabel);
            this.Controls.Add(this.save3Button);
            this.Controls.Add(this.save2Button);
            this.Controls.Add(this.save1Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PromptForSavefile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Savefile";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save1Button;
        private System.Windows.Forms.Button save2Button;
        private System.Windows.Forms.Button save3Button;
        private System.Windows.Forms.Label chooseSaveLabel;
        private System.Windows.Forms.Label gameNameLabel;
    }
}