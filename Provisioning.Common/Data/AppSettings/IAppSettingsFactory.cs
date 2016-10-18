namespace Provisioning.Common.Data.AppSettings
{
    public interface IAppSettingsFactory
    {
        IAppSettingsManager GetManager();
    }
}
