using System.Collections.Generic;

namespace Concept.WebApiFromMongoDB.Dto
{
    public class Device
    {
        public string DeviceId { get; set; }
        public List<Package> AuthorizedPackages {get; set;}
    }
}