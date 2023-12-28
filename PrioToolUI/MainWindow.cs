namespace PrioToolUI
{
    public partial class MainWindow : Form
    {
        private void PopulateList()
        {
            foreach (string rule_name in WorkingSet.rules.Keys)
            {
                PrioRule rule = WorkingSet.rules[rule_name];
                ListViewItem item = new ListViewItem(rule_name);
                item.SubItems.Add(rule.target_proc.ToString());

                if (rule.dependent_proc is null)
                {
                    item.SubItems.Add("");
                }
                else
                {
                    item.SubItems.Add(rule.dependent_proc.ToString());
                }

                item.SubItems.Add(rule.prio.ToString());
            }
        }


        public MainWindow()
        {
            InitializeComponent();

            WorkingSet.LoadRuleset();
            this.RuleList.Items.AddRange(WorkingSet.PopulateListView());
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            new EditWindow(true, "").ShowDialog();

            WorkingSet.WriteRuleSet();
            this.RuleList.Items.Clear();
            this.RuleList.Items.AddRange(WorkingSet.PopulateListView());
        }


        private void EditButton_Click(object sender, EventArgs e)
        {
            if (this.RuleList.SelectedItems.Count == 0)
            {
                return;
            }

            string rule_name = this.RuleList.SelectedItems[0].Text;
            new EditWindow(false, rule_name).ShowDialog();

            WorkingSet.WriteRuleSet();
            this.RuleList.Items.Clear();
            this.RuleList.Items.AddRange(WorkingSet.PopulateListView());


        }


        private void AboutButton_Click(object sender, EventArgs e)
        {
            new AboutWindow().ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // delete the selected rule
            if (this.RuleList.SelectedItems.Count == 0)
            {
                return;
            } else
            {
                string rule_name = this.RuleList.SelectedItems[0].Text;
                WorkingSet.rules.Remove(rule_name);
            }

            WorkingSet.WriteRuleSet();
            this.RuleList.Items.Clear();
            this.RuleList.Items.AddRange(WorkingSet.PopulateListView());
        }
    }
}