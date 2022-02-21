using Concept.WebApiFromMongoDB.Dto;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Concept.WebApiFromMongoDB
{
    public class MongoGateway: IDisposable
    {
        private MongoClient client;
        private IMongoDatabase database;

        public static MongoGateway Singleton = new MongoGateway();

        public IMongoDatabase Database
        {
            get
            {
                return database;
            }

            set
            {
                database = value;
            }
        }

        public MongoGateway()
        {
            this.client = new MongoClient();
            this.Database = this.client.GetDatabase("ConceptWebApiFromMongoDB");
        }
                
        void IDisposable.Dispose()
        {
            //Nothing to do...  O_o
        }

        public List<string> GetContentAuthorizedFiltered(List<string> contentIds, string deviceId, List<string> packageIds)
        {
            var filteredContentAuthorized = new List<ContentAuthorized>();

            foreach (string oneContentId in contentIds)
            {
                var oneFilteredContentId = this.Database.GetCollection<ContentAuthorized>("contents")
                    .Find(x => x.ContentId == oneContentId).ToList();
                if (oneFilteredContentId.Count > 0)
                {
                    ContentAuthorized preFiltered = oneFilteredContentId[0];
                    var device = preFiltered.AuthorizedDevices.Where(y => y.DeviceId == deviceId).FirstOrDefault();
                    if (device != null)
                        if (device.AuthorizedPackages.Exists(x => packageIds.Contains(x.PackageId)))
                            filteredContentAuthorized.Add(oneFilteredContentId[0]);
                }
            }
            
            List<string> filteredContentIds = filteredContentAuthorized.Select(x => x.ContentId).ToList();
            return filteredContentIds;
        }
    }
}
