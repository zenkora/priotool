using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrioToolUI
{
    internal class PrioRule
    {
        public readonly string friendly_name;
        public readonly string target_proc;
        public readonly string? dependent_proc;
        public readonly ProcessPriorityClass prio;


        /*
         * Time to explain the ruleset format.
         * 
         * Each line is a colon-separated list of values. The first value is
         * the "friendly" name, the second is the target process name, the
         * third is the desired priority, and if it's there, the fourth value
         * contains the dependent process name.
         * 
         * It will look something like this:
         * MS Edge:msedge:16384:BattleBit
         * 
         * Priority values are the same as in the ProcessPriorityClass enum.
         */
        public string GenRuleText()
        {
            if (this.dependent_proc is null)
            {
                return $"{this.friendly_name}:{this.target_proc}:{(int)this.prio}";
            } else
            {
                return $"{this.friendly_name}:{this.target_proc}:{(int)this.prio}:{this.dependent_proc}";
            }
        }


        public ListViewItem GenListItem()
        {
            ListViewItem list_item = new ListViewItem(this.friendly_name);
            list_item.SubItems.Add(this.target_proc);
            list_item.SubItems.Add(this.prio.ToString());

            if (this.dependent_proc is null)
            {
                list_item.SubItems.Add("false");
                list_item.SubItems.Add("");
            } else
            {
                list_item.SubItems.Add("true");
                list_item.SubItems.Add(this.dependent_proc);
            }

            return list_item;
        }


        public PrioRule(string friendly, string tgt, ProcessPriorityClass pri)
        {
            this.friendly_name = friendly;
            this.target_proc = tgt;
            this.prio = pri;
            this.dependent_proc = null;
        }


        public PrioRule(string friendly, string tgt, ProcessPriorityClass pri, string dep)
        {
            this.friendly_name = friendly;
            this.target_proc = tgt;
            this.prio = pri;
            this.dependent_proc = dep;
        }
    }
}
