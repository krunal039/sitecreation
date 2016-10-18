using System.Runtime.Serialization;

namespace Provisioning.UX.AppWeb.Models
{
    [DataContract]
    public class UserPermissionsCheckRequest
    {
        [DataMember]
        public bool DoesUserHavePermissions { get; set; }

       
    }
}