namespace PrioToolUI
{
    partial class EditWindow
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            FriendlyName = new TextBox();
            ProcessName = new TextBox();
            PrioList = new ComboBox();
            DependentProc = new TextBox();
            SaveButton = new Button();
            WarningLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Friendly Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 1;
            label2.Text = "Process Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 2;
            label3.Text = "Priority";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 96);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 3;
            label4.Text = "Dependent Process";
            // 
            // FriendlyName
            // 
            FriendlyName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FriendlyName.Location = new Point(252, 6);
            FriendlyName.Name = "FriendlyName";
            FriendlyName.Size = new Size(240, 23);
            FriendlyName.TabIndex = 4;
            // 
            // ProcessName
            // 
            ProcessName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ProcessName.Location = new Point(252, 35);
            ProcessName.Name = "ProcessName";
            ProcessName.Size = new Size(240, 23);
            ProcessName.TabIndex = 5;
            // 
            // PrioList
            // 
            PrioList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PrioList.DropDownStyle = ComboBoxStyle.DropDownList;
            PrioList.FormattingEnabled = true;
            PrioList.Items.AddRange(new object[] { "Idle", "BelowNormal", "Normal", "AboveNormal", "High", "Realtime" });
            PrioList.Location = new Point(252, 64);
            PrioList.Name = "PrioList";
            PrioList.Size = new Size(240, 23);
            PrioList.TabIndex = 6;
            // 
            // DependentProc
            // 
            DependentProc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DependentProc.Location = new Point(252, 93);
            DependentProc.Name = "DependentProc";
            DependentProc.Size = new Size(240, 23);
            DependentProc.TabIndex = 8;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.Location = new Point(417, 156);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 9;
            SaveButton.Text = "Save Rule";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // WarningLabel
            // 
            WarningLabel.AutoSize = true;
            WarningLabel.Location = new Point(12, 120);
            WarningLabel.Name = "WarningLabel";
            WarningLabel.Size = new Size(339, 45);
            WarningLabel.TabIndex = 10;
            WarningLabel.Text = "Warning:\r\nIdle prio will cause a process to be preempted by everything.\r\nRealtime process will preempt everything, including user input.\r\n";
            // 
            // EditWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 191);
            Controls.Add(WarningLabel);
            Controls.Add(SaveButton);
            Controls.Add(DependentProc);
            Controls.Add(PrioList);
            Controls.Add(ProcessName);
            Controls.Add(FriendlyName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(520, 230);
            MinimizeBox = false;
            MinimumSize = new Size(520, 230);
            Name = "EditWindow";
            Text = "Add/Edit Rule";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox FriendlyName;
        private TextBox ProcessName;
        private ComboBox PrioList;
        private TextBox DependentProc;
        private Button SaveButton;
        private Label WarningLabel;
    }
}