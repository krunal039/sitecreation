using System.Runtime.Serialization;

namespace Provisioning.UX.AppWeb.Models
{
    [DataContract]
    public class SiteUrlCheckRequest
    {
        [DataMember]
        public bool UsesCustomProvider { get; set; }

       
    }
}