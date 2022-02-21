using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Concept.WebApiFromMongoDB.Dto
{
    public class ContentAuthorized
    {
        [BsonId]
        public string ContentId { get; set; }
        public List<DeviceAuthorized> AuthorizedDevices { get; set; } = new List<DeviceAuthorized>();
    }
}
