/*
 * PrioToolSvc.cs
 * This file contains the actual brains of the program.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
// I will *eventually* thread this, maybe
using System.Threading;
using System.Threading.Tasks;

namespace PrioToolSvc
{
    public class PrioToolSvc
    {
        private bool dryrun = false;
        private bool ruleset_changed = false;
        private bool shutdown_time = false;

        private FileSystemWatcher rule_watcher = new();
        private List<PrioRule> rules = new();


        private void VibeCheck()
        {
            foreach (PrioRule rule in rules)
            {
                rule.Enforce();
            }
        }

        
        private void ServiceLoop()
        {
            while (!shutdown_time)
            {
                VibeCheck();
            }
        }


        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            
        }


        /*
         * It's probably a good time to explain the ruleset format. Each line
         * is a colon-separated list of values. The first value is the
         * "friendly" name, the second is the target process name, the third
         * is the desired priority, and if it's there, the fourth value
         * contains the dependent process name.
         * 
         * It will look something like this:
         * MS Edge:msedge:16384:BattleBit
         * 
         * Priority values are the same as in the ProcessPriorityClass enum.
         */
        private void BuildRuleset()
        {
            // check if ruleset.txt exists, and if not, make it
            if (!File.Exists("ruleset.txt"))
            {
                File.Create("ruleset.txt");
            }

            string[] ruleset = File.ReadAllLines("ruleset.txt");
            foreach (string rule in ruleset)
            {
                string[] rule_parts = rule.Split(':');

                // minimal sanity checking
                if (rule_parts.Length < 3 || rule_parts.Length > 4)
                {
                    Logger.Pebkac($"malformed rule: {rule}");
                    continue;
                }

                if (!Enum.IsDefined(typeof(ProcessPriorityClass), int.Parse(rule_parts[2])))
                {
                    Logger.Pebkac($"nonexistent prio value in rule: {rule}");
                    continue;
                }

                if (rule_parts.Length == 3)
                {
                    this.rules.Add(new PrioRule(rule_parts[1], int.Parse(rule_parts[2])));
                }
                else
                {
                    this.rules.Add(new PrioRule(rule_parts[1], int.Parse(rule_parts[2]), rule_parts[3]));
                }
            }

            // now we set appropriate sleep values to spread out the load over five seconds
            int sleep_time = 5000 / this.rules.Count;
            int leftover = 5000 % this.rules.Count;
            foreach (PrioRule rule in this.rules)
            {
                rule.sleep_time = sleep_time;
                if (leftover > 0)
                {
                    rule.sleep_time++;
                    leftover--;
                }
            }
        }


        public void Start()
        {

            // watch ruleset.txt for changes made by the UI
            this.rule_watcher.Path = Directory.GetCurrentDirectory();
            this.rule_watcher.Filter = "ruleset.txt";
            this.rule_watcher.NotifyFilter = NotifyFilters.LastWrite;
            this.rule_watcher.Changed += new FileSystemEventHandler(OnChanged);
            this.rule_watcher.EnableRaisingEvents = true;

            this.ServiceLoop();
        }


        public void Stop()
        {
            shutdown_time = true;
        }


        public PrioToolSvc(bool dryrun)
        {
            this.dryrun = dryrun;
        }
    }
}
