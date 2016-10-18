using Provisioning.Common.Configuration.Application;

namespace Provisioning.Common.Configuration
{
    /// <summary>
    /// Interface that is used by the factory that is responsible for creating objects for IAppSettingsManager and ITemplateFactory
    /// </summary>
    public interface IConfigurationFactory
    {
        /// <summary>
        /// Gets the Object that is responsible for returning the Settings of the Applications
        /// </summary>
        /// <returns></returns>
        IAppSettingsManager GetAppSetingsManager();
      
    }
}
