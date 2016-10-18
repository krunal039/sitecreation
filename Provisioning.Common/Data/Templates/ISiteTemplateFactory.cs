namespace Provisioning.Common.Data.Templates
{
    public interface ISiteTemplateFactory
    {
        /// <summary>
        /// Returns an interface for working Site Templates
        /// </summary>
        /// <returns></returns>
        ISiteTemplateManager GetManager();
    }
}
