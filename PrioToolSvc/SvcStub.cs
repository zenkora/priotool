using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace PrioToolSvc
{
    // entry point when launched by SCM
    public class SvcStub : ServiceBase
    {
        private readonly PrioToolSvc svc = new(false);


        protected override void OnStart(string[] args)
        {
            svc.Start();
        }


        protected override void OnStop()
        {
            svc.Stop();
        }
    }
}
