using System.ServiceProcess;
using System.Threading.Tasks;

namespace PrioToolSvc
{
    public class SvcStub : ServiceBase
    {
        private readonly PrioToolSvc svc;

        public SvcStub()
        {
            svc = new PrioToolSvc(false);
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() => svc.Start());
        }

        protected override void OnStop()
        {
            svc.Stop();
        }
    }
}
