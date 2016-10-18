using System.Collections.Generic;

namespace Provisioning.Common.Data.AppSettings
{
    public interface IAppSettingsManager
    {
        ICollection<AppSetting> GetAppSettings();
    }
}
