/*
 * EntryPoint.cs
 * This file contains the entry point for the program and figures out whether
 * it's being launched in a console or by SCM.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;

namespace PrioToolSvc // Note: actual namespace depends on the project name.
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
            List<string> args_list = args.ToList();
            bool dryrun = false;
            bool notify = false;

            if (args.Contains("dryrun")) dryrun = true;

            // check if we're starting interactively or as a service
            if (Environment.UserInteractive)
            {
                if (!IsRunningAsAdmin())
                {
                    Console.WriteLine("This program needs admin privileges.");
                    return;
                }
                else
                {
                    PrioToolSvc svc = new(dryrun);
                    svc.Start();
                }
            }
            else
            {
                // if we're here, we're being started by SCM
                System.ServiceProcess.ServiceBase.Run(new SvcStub());
            }
        }
    }
}