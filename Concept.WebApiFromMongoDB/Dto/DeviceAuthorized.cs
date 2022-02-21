using System.Collections.Generic;

namespace Concept.WebApiFromMongoDB.Dto
{
    public class DeviceAuthorized
    {
        public string DeviceId { get; set; }
        public List<PackageAuthorized> AuthorizedPackages { get; set; } = new List<PackageAuthorized>();
    }
}