namespace Fangame_Manager
{
    partial class WaitForm
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
            this.pleaseWaitLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pleaseWaitLabel
            // 
            this.pleaseWaitLabel.AutoSize = true;
            this.pleaseWaitLabel.Location = new System.Drawing.Point(13, 13);
            this.pleaseWaitLabel.Name = "pleaseWaitLabel";
            this.pleaseWaitLabel.Size = new System.Drawing.Size(152, 13);
            this.pleaseWaitLabel.TabIndex = 0;
            this.pleaseWaitLabel.Text = "Please wait while pushing data";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(12, 26);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(71, 13);
            this.progressLabel.TabIndex = 1;
            this.progressLabel.Text = "Progress: ?/?";
            // 
            // WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 51);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.pleaseWaitLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Working";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pleaseWaitLabel;
        public System.Windows.Forms.Label progressLabel;
    }
}