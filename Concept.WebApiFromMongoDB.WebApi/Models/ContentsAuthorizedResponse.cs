using System.Collections.Generic;

namespace Concept.WebApiFromMongoDB.WebApi.Models
{
    public class ContentsAuthorizedResponse
    {
        public List<string> ContentIds { get; set; }
        public long ElapsedMilliseconds { get; internal set; }
    }
}