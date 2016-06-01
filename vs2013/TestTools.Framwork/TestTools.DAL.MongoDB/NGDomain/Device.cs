using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TestTools.DAL.DataModules;

namespace TestTools.DAL.MongoDB
{
    public class Device
    {
        private string strDbName = string.Empty;
        private string strDtName = string.Empty;
        MongoDB collectionDevice;
        public Device()
        {
            strDbName = ConfigurationManager.AppSettings["DBName"];
            strDtName = "Device";
            collectionDevice = new MongoDB(strDbName, strDtName);
        }
        public List<NgDevice> GetAllDevice()
        {
            Dictionary<string, int> dic = new Dictionary<string, int> { { "_id", 1 }, { "name", 1 }};
            var devices = collectionDevice.ExecuteQueryGetColumnsAll<NgDevice>(dic);
            return devices;
        }
       
    }
}
