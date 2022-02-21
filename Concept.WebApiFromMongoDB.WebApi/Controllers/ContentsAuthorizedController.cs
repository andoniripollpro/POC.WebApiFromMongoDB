using Concept.WebApiFromMongoDB.WebApi.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Concept.WebApiFromMongoDB.WebApi.Controllers
{
    [RoutePrefix("ContentsAuthorized")]
    public class ContentsAuthorizedController : ApiController
    {
        private readonly Stopwatch stopwatch = Stopwatch.StartNew();
        private readonly MongoGateway mongoGateway = MongoGateway.Singleton;

        [HttpGet]
        [ActionName("alive")]
        public string Alive()
        {
            return string.Format("The service is ALIVE. Version: {0}. Evironment: CONCEPTO", Assembly.GetExecutingAssembly()?.GetName()?.Version);
        }

        [HttpPost]
        [ActionName("areContentsAuthorized")]
        public ContentsAuthorizedResponse areContentsAuthorized([FromBody] ContentsAuthorizedRequest request)
        {
            stopwatch.Stop();

            var contentsList = request.ContentIds.ToList();

            List<string> contentsAuthorized
                = this.mongoGateway.GetContentAuthorizedFiltered(
                    request.ContentIds.ToList(), request.DeviceId, request.PackageIds);

            ContentsAuthorizedResponse response = new ContentsAuthorizedResponse() { ContentIds = contentsAuthorized.ToList() };
            response.ElapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            return response;
        }
    }
}
