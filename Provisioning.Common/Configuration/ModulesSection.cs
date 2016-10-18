using System.Configuration;

namespace Provisioning.Common.Configuration
{
    public class ModulesSection : ConfigurationSection
    {
        [ConfigurationProperty("Modules")]
        public ModuleElementCollection Modules
        {
            get { return ((ModuleElementCollection)(base["Modules"])); }
            set { base["Modules"] = value; }
        }
    }
}
