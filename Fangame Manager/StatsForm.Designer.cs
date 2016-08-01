using System;

namespace Fangame_Manager
{
    partial class StatsForm
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
            this.numbersPanel = new System.Windows.Forms.Panel();
            this.framesHoldedLabel = new System.Windows.Forms.Label();
            this.millisLabel = new System.Windows.Forms.Label();
            this.zAverageLabel = new System.Windows.Forms.Label();
            this.numbersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // numbersPanel
            // 
            this.numbersPanel.Controls.Add(this.framesHoldedLabel);
            this.numbersPanel.Controls.Add(this.millisLabel);
            this.numbersPanel.Controls.Add(this.zAverageLabel);
            this.numbersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numbersPanel.Location = new System.Drawing.Point(0, 0);
            this.numbersPanel.Name = "numbersPanel";
            this.numbersPanel.Size = new System.Drawing.Size(98, 43);
            this.numbersPanel.TabIndex = 21;
            // 
            // framesHoldedLabel
            // 
            this.framesHoldedLabel.AutoSize = true;
            this.framesHoldedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.framesHoldedLabel.Location = new System.Drawing.Point(3, 3);
            this.framesHoldedLabel.Name = "framesHoldedLabel";
            this.framesHoldedLabel.Size = new System.Drawing.Size(30, 31);
            this.framesHoldedLabel.TabIndex = 6;
            this.framesHoldedLabel.Text = "0";
            // 
            // millisLabel
            // 
            this.millisLabel.AutoSize = true;
            this.millisLabel.Location = new System.Drawing.Point(47, 21);
            this.millisLabel.Name = "millisLabel";
            this.millisLabel.Size = new System.Drawing.Size(32, 13);
            this.millisLabel.TabIndex = 10;
            this.millisLabel.Text = "ms: 0";
            // 
            // zAverageLabel
            // 
            this.zAverageLabel.AutoSize = true;
            this.zAverageLabel.Location = new System.Drawing.Point(47, 6);
            this.zAverageLabel.Name = "zAverageLabel";
            this.zAverageLabel.Size = new System.Drawing.Size(24, 13);
            this.zAverageLabel.TabIndex = 11;
            this.zAverageLabel.Text = "z: 0";
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(98, 43);
            this.Controls.Add(this.numbersPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stats";
            this.TopMost = true;
            this.numbersPanel.ResumeLayout(false);
            this.numbersPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel numbersPanel;
        private System.Windows.Forms.Label framesHoldedLabel;
        private System.Windows.Forms.Label millisLabel;
        private System.Windows.Forms.Label zAverageLabel;
    }
}