using System;
using System.Threading;

namespace Provisioning.Job
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Thread.Sleep(10000);
            var _spj = new SiteProvisioningJob();
            _spj.ProcessSiteRequests();

            goto start;
        }
    }
}
