using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrioToolUI
{
    internal static class WorkingSet
    {
        public static Dictionary<string, PrioRule> rules = new Dictionary<string, PrioRule>();

        public static void LoadRuleset()
        {
            // check if ruleset.txt exists, and if not, make it
            if (!File.Exists("ruleset.txt"))
            {
                File.Create("ruleset.txt").Close();
            }

            string[] ruleset = File.ReadAllLines("ruleset.txt");
            foreach (string rule in ruleset)
            {
                // skip empty lines
                if (string.IsNullOrWhiteSpace(rule))
                {
                    continue;
                }

                // trim whitespace
                string[] rule_parts = rule.Split(':');
                for (int i = 0; i < rule_parts.Length; i++)
                {
                    rule_parts[i] = rule_parts[i].Trim();
                }

                // sanity checking
                if (rule_parts.Length < 3 || rule_parts.Length > 4)
                {
                    continue;
                }

                if (!Enum.IsDefined(typeof(ProcessPriorityClass), int.Parse(rule_parts[2])))
                {
                    continue;
                }

                if (rule_parts.Length == 3)
                {
                    rules[rule_parts[0]] = new PrioRule(rule_parts[0], rule_parts[1], (ProcessPriorityClass) int.Parse(rule_parts[2]));
                }
                else
                {
                    rules[rule_parts[0]] = new PrioRule(rule_parts[0], rule_parts[1], (ProcessPriorityClass) int.Parse(rule_parts[2]), rule_parts[3]);
                }
            }
        }

        public static void WriteRuleSet()
        {
            List<string> ruleset = new List<string>();

            foreach (string rule_name in rules.Keys)
            {
                ruleset.Add(rules[rule_name].GenRuleText());
            }

            File.WriteAllLines("ruleset.txt", ruleset);
        }

        public static ListViewItem[] PopulateListView()
        {
            List<ListViewItem> ruleset = new List<ListViewItem>();

            foreach (string rule_name in rules.Keys)
            {
                ruleset.Add(rules[rule_name].GenListItem());
            }

            return ruleset.ToArray();
        }
    }
}
