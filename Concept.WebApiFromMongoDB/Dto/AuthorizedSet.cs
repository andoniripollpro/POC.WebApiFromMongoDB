using MongoDB.Driver;
using System;
using System.Linq;

namespace Concept.WebApiFromMongoDB.Dto
{
    public class AuthorizedSet
    {
        public string ContentId { get; private set; }
        public string DeviceId { get; private set; }
        public string PackageId { get; private set; }

        public AuthorizedSet(string contentId, string deviceId, string packageId)
        {
            this.ContentId = contentId.Replace("\"", "");
            this.DeviceId = deviceId.Replace("\"", ""); ;
            this.PackageId = packageId.Replace("\"", ""); ;
        }

        public void AddAuthorizedSetToContentList(ref IMongoCollection<ContentAuthorized> authorizedList)
        {
            ContentAuthorized content = authorizedList.Find(x => x.ContentId == this.ContentId).FirstOrDefault();
            if (content == null)
            {
                content = new ContentAuthorized() { ContentId = this.ContentId };
                authorizedList.InsertOne(content);
            }

            DeviceAuthorized device = content.AuthorizedDevices.Where(x => x.DeviceId == this.DeviceId).FirstOrDefault();
            if (device == null)
            {
                device = new DeviceAuthorized() { DeviceId = this.DeviceId };
                content.AuthorizedDevices.Add(device);
            }

            PackageAuthorized packge = device.AuthorizedPackages.Where(x => x.PackageId == this.PackageId).FirstOrDefault();
            if (packge == null)
            {
                packge = new PackageAuthorized() { PackageId = this.PackageId };
                device.AuthorizedPackages.Add(packge);
            }
            //else nothing to insert

            //string serializedData = Newtonsoft.Json.JsonConvert.SerializeObject(content);
            //Console.WriteLine(serializedData);
            authorizedList.ReplaceOne(x => x.ContentId == content.ContentId, content);
        }
    }
}
