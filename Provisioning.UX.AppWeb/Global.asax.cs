using System;
using System.Web.Http;

namespace Provisioning.UX.AppWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // WebApi support
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}