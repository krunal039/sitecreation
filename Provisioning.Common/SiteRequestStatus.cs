namespace Provisioning.Common
{
    /// <summary>
    /// Enum for SiteRequestStatus
    /// </summary>
    public enum SiteRequestStatus
    {
        Complete,
        CompleteWithErrors,
        Exception,
        New,
        Processing,
        Pending,
        Approved,
        Partially
    }
}
