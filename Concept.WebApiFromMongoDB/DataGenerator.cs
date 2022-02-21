using Concept.WebApiFromMongoDB.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Concept.WebApiFromMongoDB
{
    public class DataGenerator
    {
        public static List<ContentAuthorized> GetContents()
        {
            List<ContentAuthorized> contentsInDb = new List<ContentAuthorized>();

            return contentsInDb;
        }

        public List<ContentAuthorized> GetAllContents()
        {
            List<ContentAuthorized> allContents = new List<ContentAuthorized>();

            allContents.Add(new ContentAuthorized() { ContentId = "123456", AuthorizedDevices = GetAllDevices().Where(x => x.DeviceId != "ipad2").ToList() } );
            allContents.Add(new ContentAuthorized() { ContentId = "223456", AuthorizedDevices = GetAllDevices() });
            allContents.Add(new ContentAuthorized() { ContentId = "323456", AuthorizedDevices = GetAllDevices() });
            allContents.Add(new ContentAuthorized() { ContentId = "423456", AuthorizedDevices = GetAllDevices() });
            allContents.Add(new ContentAuthorized() { ContentId = "523456", AuthorizedDevices = GetAllDevices() });
            allContents.Add(new ContentAuthorized() { ContentId = "623456", AuthorizedDevices = GetAllDevices() });
            allContents.Add(new ContentAuthorized() { ContentId = "723456", AuthorizedDevices = GetAllDevices() });
            allContents.Add(new ContentAuthorized() { ContentId = "823456", AuthorizedDevices = GetAllDevices() });
            allContents.Add(new ContentAuthorized() { ContentId = "923456", AuthorizedDevices = GetAllDevices() });
            allContents.Add(new ContentAuthorized() { ContentId = "913456", AuthorizedDevices = GetAllDevices().Where(x => x.DeviceId != "lg").ToList() });
            
            return allContents;
        }

        public List<DeviceAuthorized> GetAllDevices()
        {
            List<DeviceAuthorized> allDevices = new List<DeviceAuthorized>();
            
            allDevices.Add(new DeviceAuthorized() { DeviceId = "ipad2", AuthorizedPackages = GetAllPackages().Where(x => x.PackageId != "MSERIES" && x.PackageId != "MOVFAM").ToList()});
            allDevices.Add(new DeviceAuthorized() { DeviceId = "android.tablet", AuthorizedPackages = GetAllPackages() });
            allDevices.Add(new DeviceAuthorized() { DeviceId = "iphone2", AuthorizedPackages = GetAllPackages() });
            allDevices.Add(new DeviceAuthorized() { DeviceId = "android.cell", AuthorizedPackages = GetAllPackages() });
            allDevices.Add(new DeviceAuthorized() { DeviceId = "webplayer", AuthorizedPackages = GetAllPackages().Where(x => x.PackageId != "PAQEXT" && x.PackageId != "MOVFAM").ToList() });
            allDevices.Add(new DeviceAuthorized() { DeviceId = "samsung", AuthorizedPackages = GetAllPackages().Where(x => x.PackageId != "MSERIES" && x.PackageId != "PAQEXT").ToList() });
            allDevices.Add(new DeviceAuthorized() { DeviceId = "lg", AuthorizedPackages = GetAllPackages().Where(x => x.PackageId != "PAQEXT" ).ToList() });
            allDevices.Add(new DeviceAuthorized() { DeviceId = "ps3", AuthorizedPackages = GetAllPackages().Where(x => x.PackageId != "PAQEXT").ToList() });
            allDevices.Add(new DeviceAuthorized() { DeviceId = "ps4", AuthorizedPackages = GetAllPackages().Where(x => x.PackageId != "PAQEXT" ).ToList() });
            allDevices.Add(new DeviceAuthorized() { DeviceId = "android.tv", AuthorizedPackages = GetAllPackages() });
            allDevices.Add(new DeviceAuthorized() { DeviceId = "yplus", AuthorizedPackages = GetAllPackages() });
            allDevices.Add(new DeviceAuthorized() { DeviceId = "xbox360", AuthorizedPackages = GetAllPackages().Where(x => x.PackageId != "MSERIES" && x.PackageId != "MOVFAM").ToList() });

            return allDevices;
        }

        public List<PackageAuthorized> GetAllPackages()
        {
            List<PackageAuthorized> allPackages = new List<PackageAuthorized>();
            allPackages.Add(new PackageAuthorized() { PackageId = "MSERIES" });
            allPackages.Add(new PackageAuthorized() { PackageId = "MOVFAM" });
            allPackages.Add(new PackageAuthorized() { PackageId = "MFUTBO" });
            allPackages.Add(new PackageAuthorized() { PackageId = "MDEPOR" });
            allPackages.Add(new PackageAuthorized() { PackageId = "MCINE" });
            allPackages.Add(new PackageAuthorized() { PackageId = "PAQPRE" });
            allPackages.Add(new PackageAuthorized() { PackageId = "PAQEXT" });
            allPackages.Add(new PackageAuthorized() { PackageId = "PAQTOT" });
            allPackages.Add(new PackageAuthorized() { PackageId = "TDT" });
            allPackages.Add(new PackageAuthorized() { PackageId = "OTOROS" });
            allPackages.Add(new PackageAuthorized() { PackageId = "OUEFALI" });
            return allPackages;
        }  
    }
}
