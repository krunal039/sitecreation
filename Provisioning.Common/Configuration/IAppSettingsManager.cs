namespace Provisioning.Common.Configuration.Application
{
    /// <summary>
    /// Used to return an Instance of AppSettings
    /// </summary>
    public interface IAppSettingsManager
    {
        /// <summary>
        /// Returns an Instance of AppSettings
        /// </summary>
        /// <returns></returns>
        AppSettings GetAppSettings();
    }
}
