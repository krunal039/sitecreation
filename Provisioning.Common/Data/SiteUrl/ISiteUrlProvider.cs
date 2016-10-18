using Provisioning.Common.Data.Templates;

namespace Provisioning.Common.Data.SiteUrl
{
    public interface ISiteUrlProvider
    {
        string GenerateSiteUrl(SiteInformation siteRequest, Template template, bool avoidDuplicateUrls = false);
    }
}
