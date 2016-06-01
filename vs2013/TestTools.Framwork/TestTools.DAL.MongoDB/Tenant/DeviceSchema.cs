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
    public class DeviceSchema
    {
        private string strDbName = string.Empty;
        private string strDtName = string.Empty;
        MongoDB collectionDeviceSchema;
        public DeviceSchema()
        {
            strDbName = ConfigurationManager.AppSettings["DBTenantName"];
            strDtName = "DeviceSchema";
            collectionDeviceSchema = new MongoDB(strDbName, strDtName);
        }
        public List<NgDeviceSchema> GetAllSchemaData()
        {
            var deviceSchema = collectionDeviceSchema.GetAllData<NgDeviceSchema>();
            return deviceSchema;
        }
    }
}
