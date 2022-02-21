using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Concept.WebApiFromMongoDB.Dto;
using MongoDB.Driver;
using System.Text;
using System.Linq;

namespace Concept.WebApiFromMongoDB
{
    class Program
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger("log4net");

        static void Main(string[] args)
        {
            new Program().LoadFromFileData();
        }

        private void CountData()
        {
            var mongoGateWay = new MongoGateway();

            Console.WriteLine("Start: " + DateTime.Now);

            var collection = mongoGateWay.Database.GetCollection<ContentAuthorized>("contents");
            var countData = collection.Count(x => true);

            Console.WriteLine("Stop: " + DateTime.Now + " Count: " + countData);

            Console.ReadLine();   
        }

        private void ShowData()
        {
            var mongoGateWay = new MongoGateway();
            
            Console.WriteLine("Start: " + DateTime.Now);

            var collection = mongoGateWay.Database.GetCollection<ContentAuthorized>("contents");
            List<ContentAuthorized> data = collection.Find(x => x.ContentId != "kaka").ToList();

            Console.WriteLine("Stop: " + DateTime.Now);

            Console.ReadLine();

            int i = 0;
            foreach (var oneData in data)
            {
                if (i > 5) break;
                string serializedData = JsonConvert.SerializeObject(oneData);
                Console.WriteLine(serializedData);
                i++;
            }
            Console.ReadLine();
        }
        private void LoadGeneratedData()
        { 
            var dataGenerator = new DataGenerator();
            var mongoGateWay = new MongoGateway();

            List<ContentAuthorized> data = dataGenerator.GetAllContents();

            foreach (var oneData in data)
            {
                string serializedData = JsonConvert.SerializeObject(oneData);
                Console.WriteLine(serializedData);
            }

            Console.WriteLine("Start: " + DateTime.Now);

            var collection = mongoGateWay.Database.GetCollection<ContentAuthorized>("contents");            
            collection.InsertMany(data);

            Console.WriteLine("Stop: " + DateTime.Now);
            
            Console.ReadLine();
        }
        private void EmptyData()
        {
            var dataGenerator = new DataGenerator();
            var mongoGateWay = new MongoGateway();

            //List<ContentAuthorized> data = dataGenerator.GetAllContents();

            Console.WriteLine("Start: " + DateTime.Now);

            var collection = mongoGateWay.Database.GetCollection<ContentAuthorized>("contents");
            var deleteCount = collection.DeleteMany(x => true).DeletedCount;

            Console.WriteLine("Stop: " + DateTime.Now + " Borrados: " + deleteCount);

            Console.ReadLine();
        }
        private void LoadFromFileData()
        {
            var dataGenerator = new DataGenerator();
            var mongoGateWay = new MongoGateway();
              
            Console.WriteLine("Start: " + DateTime.Now);

            var fileStream = System.IO.File.OpenRead("..\\..\\..\\Data\\export_andoni.csv");
            //var strBuilding = new StringBuilder (System.IO.File.ReadAllText(".\\.\\Data\\export_andoni.csv"));
            var strBuilding = new StringBuilder();
                         
            while (fileStream.Position != fileStream.Length) {
                char oneChar = (char)fileStream.ReadByte();
                strBuilding.Append(oneChar);
            }
            fileStream.Dispose();

            List<AuthorizedSet> authorizedSet = ExtractAuthorizedSetFromCommaSeparated(strBuilding);

            var collection = mongoGateWay.Database.GetCollection<ContentAuthorized>("contents");

            authorizedSet.ForEach(x => x.AddAuthorizedSetToContentList(ref collection));
            
            Console.WriteLine("Stop: " + DateTime.Now);

            Console.ReadLine();
        }

        private List<AuthorizedSet> ExtractAuthorizedSetFromCommaSeparated(StringBuilder strBuilding)
        {
            List<AuthorizedSet> result = new List<AuthorizedSet>();
            var peazoObjeto = strBuilding.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            peazoObjeto.ToList().ForEach(x =>
            {
                var set = x.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    result.Add(new AuthorizedSet(set[0], set[1], set[2]));
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            });

            return result;
        }
    }
}
