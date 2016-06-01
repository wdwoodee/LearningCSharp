using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.Common.Utility
{
    public class ParseJsonFromFile
    {
        public static List<T> ConvertJsonToObj<T>(string strJsonFilePath)
        {
            List<T> items = new List<T>();
            
            using (StreamReader r = new StreamReader(strJsonFilePath))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<T>>(json);
            }
            return items;
        }

        public static dynamic ConvertJsonToObj(string strJsonFilePath)
        {
            dynamic items = null;
            using (StreamReader r = new StreamReader(strJsonFilePath))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject(json);
            }
            return items;
        }

        public static void DeserializeJson(string json)
        {
            JObject obj = JObject.Parse("{\"h\":\"Hello world!!!\"}");
            
        }
    }
}
