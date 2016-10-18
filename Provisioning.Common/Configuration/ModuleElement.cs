using System.Configuration;

namespace Provisioning.Common.Configuration
{
    public class Module : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
        [ConfigurationProperty("type", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string ModuleType
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }

        [ConfigurationProperty("connectionString", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string ConnectionString
        {
            get { return (string)base["connectionString"]; }
            set { base["connectionString"] = value; }
        }

        [ConfigurationProperty("container", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Container
        {
            get { return (string)base["container"]; }
            set { base["container"] = value; }
        }
    }
}
