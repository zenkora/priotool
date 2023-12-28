using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrioToolUI
{
    public partial class EditWindow : Form
    {
        public EditWindow(bool new_rule, string rule_name)
        {
            InitializeComponent();

            if (new_rule)
            {
                this.Text = "Add Rule";
                this.FriendlyName.Text = "";
                this.ProcessName.Text = "";
                this.PrioList.Text = "Normal";
                this.DependentProc.Text = "";
            }
            else
            {
                this.Text = "Edit Rule";
                this.FriendlyName.Text = rule_name;
                this.ProcessName.Text = WorkingSet.rules[rule_name].target_proc;
                this.PrioList.Text = WorkingSet.rules[rule_name].prio.ToString();
                this.DependentProc.Text = WorkingSet.rules[rule_name].dependent_proc;
            }
        }


        // get ProcessPriorityClass from the selected item in the dropdown
        private ProcessPriorityClass GetPrio()
        {
            switch (this.PrioList.Text)
            {
                case "Idle":
                    return ProcessPriorityClass.Idle;
                case "BelowNormal":
                    return ProcessPriorityClass.BelowNormal;
                case "Normal":
                    return ProcessPriorityClass.Normal;
                case "AboveNormal":
                    return ProcessPriorityClass.AboveNormal;
                case "High":
                    return ProcessPriorityClass.High;
                case "Realtime":
                    return ProcessPriorityClass.RealTime;
                default:
                    return ProcessPriorityClass.Normal;
            }
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.DependentProc.Text == "")
            {
                WorkingSet.rules[this.FriendlyName.Text] = new PrioRule(this.FriendlyName.Text, this.ProcessName.Text, this.GetPrio());
            }
            else
            {
                WorkingSet.rules[this.FriendlyName.Text] = new PrioRule(this.FriendlyName.Text, this.ProcessName.Text, this.GetPrio(), this.DependentProc.Text);
            }
        }
    }
}
