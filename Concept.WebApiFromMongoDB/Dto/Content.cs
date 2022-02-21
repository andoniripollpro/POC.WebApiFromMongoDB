using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Concept.WebApiFromMongoDB.Dto
{
    public class Content
    {
        [BsonId]
        public string ContentId { get; set; }
        public List<Device> AuthorizedDevices { get; set; }
    }
}
