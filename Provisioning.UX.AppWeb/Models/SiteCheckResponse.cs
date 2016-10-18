using System.Runtime.Serialization;

namespace Provisioning.UX.AppWeb.Models
{
    [DataContract]
    public class SiteCheckResponse
    {
        [DataMember(Name = "doesExist")]
        public bool DoesExist { get; set; }
    }
}