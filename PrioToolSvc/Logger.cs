using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrioToolSvc
{
    internal static class Logger
    {
        // rolling list of the last X lines of output
        private static LinkedList<string> log = new();
        private static int log_size = 300;

        private static int log_count = 0;


        private static void LogTicker()
        {
            log_count++;
            if (log_count == 50)
            {
                DumpLog();
                log_count = 0;
            }
        }

        
        public static void Write(string line)
        {
            if (log.Count == log_size)
            {
                log.RemoveFirst();
            }
            log.AddLast(line);
            LogTicker();
        }


        public static void PrioEnforce(string target_proc, string? dependent_proc, ProcessPriorityClass prio)
        {
            string line = $"[{DateTime.Now}] found process ({target_proc}), applying priority {prio}";
            if (dependent_proc is not null)
            {
                line += $" because {dependent_proc} is running";
            }
            Write(line);
        }


        public static void PrioDryEnforce(string target_proc, string? dependent_proc, ProcessPriorityClass prio)
        {
            string line = $"[{DateTime.Now}] found process ({target_proc}), pretending to apply priority {prio}";
            if (dependent_proc is not null)
            {
                line += $" because {dependent_proc} is running";
            }
            Write(line);
        }


        public static void Pebkac(string msg)
        {
            Write($"[{DateTime.Now}] PEBKAC: {msg}");
        }


        // dump the log to log.txt
        public static void DumpLog()
        {
            // try to dump the log, and log the failure if it fails
            try
            {
                File.WriteAllLines("svc_log.txt", log);
            }
            catch (Exception e)
            {
                Write($"[{DateTime.Now}] failed to dump log: {e.Message}");
            }
        }
    }
}
