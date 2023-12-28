using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.ServiceProcess;

namespace PrioToolSvc
{
    internal class EntryPoint
    {
        static bool IsRunningAsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }


        static void Main(string[] args)
        {
            bool dryrun = args.Contains("dryrun");
            bool daemon = args.Contains("daemon");

            if (!IsRunningAsAdmin() && !dryrun)
            {
                Console.WriteLine("This program needs admin privileges.");
                Console.ReadLine();
            } else if (dryrun | daemon)
            {
                PrioToolSvc svc = new(dryrun);
                svc.Start();
            } else
            {
                // first make sure there isn't already a daemon running
                Process[] instances = Process.GetProcessesByName("PrioToolSvc");
                if (instances.Length > 1)
                {
                    Console.WriteLine("There is already a daemon running.");
                    Console.ReadLine();
                    return;
                }


                // fork to the background (in the weirdest fucking way)
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe");
                startInfo.Arguments = "daemon";
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.Verb = "runas";

                // Start the process
                Process forked_p = Process.Start(startInfo);

                if (forked_p is not null)
                {
                    int forked_pid = forked_p.Id;
                    Console.WriteLine("Forked to PID:");
                    Console.WriteLine(forked_pid);
                }
            }
        }
    }
}