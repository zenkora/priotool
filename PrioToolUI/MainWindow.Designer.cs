namespace PrioToolUI
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RuleList = new ListView();
            FriendlyName = new ColumnHeader();
            Process = new ColumnHeader();
            Prio = new ColumnHeader();
            IsDep = new ColumnHeader();
            DepProcess = new ColumnHeader();
            AboutButton = new Button();
            AddButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            SuspendLayout();
            // 
            // RuleList
            // 
            RuleList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RuleList.Columns.AddRange(new ColumnHeader[] { FriendlyName, Process, Prio, IsDep, DepProcess });
            RuleList.GridLines = true;
            RuleList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            RuleList.Location = new Point(12, 41);
            RuleList.Name = "RuleList";
            RuleList.Size = new Size(560, 408);
            RuleList.TabIndex = 0;
            RuleList.UseCompatibleStateImageBehavior = false;
            RuleList.View = View.Details;
            // 
            // FriendlyName
            // 
            FriendlyName.Text = "Friendly Name";
            FriendlyName.Width = 110;
            // 
            // Process
            // 
            Process.Text = "Process";
            Process.Width = 110;
            // 
            // Prio
            // 
            Prio.Text = "Prio";
            Prio.Width = 110;
            // 
            // IsDep
            // 
            IsDep.Text = "Is Dep";
            IsDep.Width = 110;
            // 
            // DepProcess
            // 
            DepProcess.Text = "Dep Process";
            DepProcess.Width = 110;
            // 
            // AboutButton
            // 
            AboutButton.Location = new Point(497, 12);
            AboutButton.Name = "AboutButton";
            AboutButton.Size = new Size(75, 23);
            AboutButton.TabIndex = 2;
            AboutButton.Text = "About";
            AboutButton.UseVisualStyleBackColor = true;
            AboutButton.Click += AboutButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(12, 12);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 3;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(93, 12);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(75, 23);
            EditButton.TabIndex = 4;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(174, 12);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 461);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(AboutButton);
            Controls.Add(RuleList);
            MaximumSize = new Size(600, 10000);
            MinimumSize = new Size(600, 500);
            Name = "MainWindow";
            Text = "Prio Tool UI";
            ResumeLayout(false);
        }

        #endregion

        private ListView RuleList;
        private Button AboutButton;
        private ColumnHeader FriendlyName;
        private ColumnHeader Process;
        private ColumnHeader Prio;
        private ColumnHeader IsDep;
        private ColumnHeader DepProcess;
        private Button AddButton;
        private Button EditButton;
        private Button DeleteButton;
    }
}