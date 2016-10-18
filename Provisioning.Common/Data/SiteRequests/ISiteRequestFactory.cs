namespace Provisioning.Common.Data.SiteRequests
{

    public interface ISiteRequestFactory
    {
        /// <summary>
        /// Returns an interface for working with the Site Request Repository
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Provisioning.Common.Data.DataStoreException">Exception that occurs when interacting with the Site Request Repository</exception>
        ISiteRequestManager GetSiteRequestManager();
    }
      

}
