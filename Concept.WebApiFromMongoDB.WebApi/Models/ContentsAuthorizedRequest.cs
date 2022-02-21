using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept.WebApiFromMongoDB.WebApi.Models
{
    public class ContentsAuthorizedRequest
    {
        public List<string> ContentIds { get; set; }
        public List<string> PackageIds { get; set; }
        public string DeviceId { get; set; }
    }
}