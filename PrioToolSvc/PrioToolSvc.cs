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
    internal class PrioToolSvc
    {
        private readonly bool dryrun = false;
        private bool ruleset_changed = false;
        private bool shutdown_time = false;

        private FileSystemWatcher rule_watcher;
        private List<PrioRule> rules;


        private void ServiceLoop()
        {
            while (!this.shutdown_time && !this.ruleset_changed)
            {
                foreach (PrioRule rule in this.rules)
                {
                    rule.Enforce(this.dryrun);
                }
            }

            if (this.ruleset_changed)
            {
                this.ruleset_changed = false;
                this.Restart();
            }

            foreach (PrioRule rule in this.rules)
            {
                rule.Cleanup();
            }
        }


        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            this.ruleset_changed = true;
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
                FileStream stream = File.Create("ruleset.txt");
                stream.Close();
            }

            string[] ruleset = File.ReadAllLines("ruleset.txt");
            foreach (string rule in ruleset)
            {
                // skip empty lines
                if (rule == "")
                {
                    continue;
                }

                string[] rule_parts = rule.Split(':');
                for (int i = 0; i < rule_parts.Length; i++)
                {
                    rule_parts[i] = rule_parts[i].Trim();
                }

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
                    this.rules.Add(new PrioRule(rule_parts[0], rule_parts[1], (ProcessPriorityClass) int.Parse(rule_parts[2])));
                }
                else
                {
                    this.rules.Add(new PrioRule(rule_parts[0], rule_parts[1], (ProcessPriorityClass) int.Parse(rule_parts[2]), rule_parts[3]));
                }
            }

            // now we set appropriate sleep values to spread out the work over five seconds
            int sleep_time = this.rules.Count > 0 ? 5000 / this.rules.Count : 0;
            int leftover = this.rules.Count > 0 ? 5000 % this.rules.Count : 0;
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


        public void Restart()
        {
            foreach (PrioRule rule in this.rules)
            {
                rule.Cleanup();
            }

            this.rules.Clear();
            this.BuildRuleset();
            this.ServiceLoop();
        }


        public void Start()
        {
            // Set process priority to below normal
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;

            // watch ruleset.txt for changes made by the UI
            this.rule_watcher.Path = Directory.GetCurrentDirectory();
            this.rule_watcher.Filter = "ruleset.txt";
            this.rule_watcher.NotifyFilter = NotifyFilters.LastWrite;
            this.rule_watcher.Changed += new FileSystemEventHandler(OnChanged);
            this.rule_watcher.EnableRaisingEvents = true;

            this.BuildRuleset();
            this.ServiceLoop();
        }


        public void Stop()
        {
            shutdown_time = true;
        }


        public PrioToolSvc(bool dryrun)
        {
            this.dryrun = dryrun;
            this.rule_watcher = new FileSystemWatcher();
            this.rules = new List<PrioRule>();
        }
    }
}
