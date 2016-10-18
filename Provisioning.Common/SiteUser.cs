using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Provisioning.Common
{
    /// <summary>
    /// Domain Object for Site Users
    /// </summary>
    [DataContract]
    public class SiteUser
    {   
        /// <summary>
        /// Gets or sets the name. Can be an email address or group name 
        /// </summary>
        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the name. Can be an email address or group name 
        /// </summary>
        [DataMember]
        [JsonProperty(PropertyName = "email")]
        public string Email
        {
            get;
            set;
        }
    }
}
