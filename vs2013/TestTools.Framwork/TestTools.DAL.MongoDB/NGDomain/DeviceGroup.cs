using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTools.DAL.DataModules;
using System.Configuration;

namespace TestTools.DAL.MongoDB
{
    public class DeviceGroup
    {
        private string strDbName = string.Empty;
        private string strDtName = string.Empty;
        NetBrainDB collectionDeviceGroup;
        public DeviceGroup()
        {
            strDbName = ConfigurationManager.AppSettings["DBName"];
            strDtName = "DeviceGroup";
            collectionDeviceGroup = new NetBrainDB(strDbName, strDtName);
        }
        public List<NgDeviceGroup> GetSystemDeviceGroup()
        {
            IMongoQuery qPartial = Query.EQ("Type", 2);
            //IEnumerable<BsonElement> elements = {'a','b'};
            Dictionary<string, int> dic = new Dictionary<string, int> { { "_id", 1 }, { "Name", 1 }, { "DynamicDevices", 1 }, {"StaticDevices", 1 } };
            var sysGroupList = collectionDeviceGroup.ExecuteQueryGetColumns<NgDeviceGroup>(qPartial,dic);
            return sysGroupList;
        }
    }
}
