using System.Runtime.Serialization;

namespace Provisioning.UX.AppWeb.Models
{
    [DataContract]
    public class SitePolicyResults
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; } 
    }
}