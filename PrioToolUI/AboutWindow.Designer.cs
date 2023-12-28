namespace PrioToolUI
{
    partial class AboutWindow
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(255, 105);
            label1.TabIndex = 0;
            label1.Text = "Prio Tool v1\r\n©2023 Jesse Jones\r\n\r\nFor support, email 'helpdesk@elden.cloud'\r\n\r\nThis software is free and open source under the\r\nGNU General Public License, version 3.\r\n";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // AboutWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 151);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(280, 190);
            Name = "AboutWindow";
            Text = "About Prio Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}