namespace Provisioning.Job
{
    class Program
    {
        static void Main(string[] args)
        {
            var _spj = new SiteProvisioningJob();
            _spj.ProcessSiteRequests();
          
        }
    }
}
