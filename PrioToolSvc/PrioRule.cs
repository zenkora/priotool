using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace PrioToolSvc
{
    public class PrioRule
    {
        public readonly string friendly_name;
        public readonly string target_proc;
        public readonly string? dependent_proc;
        public readonly ProcessPriorityClass prio;
        public readonly ProcessPriorityClass original_prio;
        public int sleep_time = 0;

        // some core processes we shoudn't allow the user to fuck with
        /*public static readonly List<string> core_procs = new()
        {
            "wininit.exe",
            "winlogon.exe",
            "csrss.exe",
            "smss.exe",
            "services.exe",
            "lsass.exe",
            "svchost.exe",
            "spoolsv.exe",
            "taskhost.exe",
            "taskhostw.exe",
            "dwm.exe",
            "explorer.exe"
        };*/

        public void Enforce()
        {
            // get all instances of target_proc
            Process[] instances = Process.GetProcessesByName(this.target_proc);
            // is this a dependent rule?
            if (this.dependent_proc is not null)
            {
                // check if dependent_proc is running
                if (Process.GetProcessesByName(this.target_proc).Length == 0) return;
            }

            // now we can go through and apply the desired prio to all instances
            foreach (Process p in instances)
            {
                p.PriorityClass = this.prio;
                Logger.PrioEnforce(this.target_proc, this.dependent_proc, this.prio);
            }

            Thread.Sleep(this.sleep_time);
        }


        public void Cleanup()
        {
            // we're just gonna assume every instance started with normal prio
            foreach (Process p in Process.GetProcessesByName(this.target_proc))
            {
                p.PriorityClass = this.original_prio;
            }
        }


        public PrioRule(string tgt, int pri)
        {
            this.target_proc = tgt;
            this.prio = (ProcessPriorityClass) pri;
            this.dependent_proc = null;
        }


        public PrioRule(string tgt, int pri, string? dep)
        {
            this.target_proc = tgt;
            this.prio = (ProcessPriorityClass)pri;
            this.dependent_proc = dep;

            Process[] instances = Process.GetProcessesByName(this.target_proc);
            if (instances.Length > 0) this.original_prio = instances[0].PriorityClass;
            else this.original_prio = ProcessPriorityClass.Normal;
        }
    }
}
