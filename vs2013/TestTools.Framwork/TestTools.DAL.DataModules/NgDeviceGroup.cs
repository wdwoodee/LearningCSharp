using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace TestTools.DAL.DataModules
{
    [BsonIgnoreExtraElements]
    [JsonObject]
    public class NgDeviceGroup
    {
        [BsonId]
        [JsonProperty("ID", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [BsonElement("DynamicDevices")]
        [JsonProperty("DynamicDevices", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DynamicDevices { get; set; }

        [BsonElement("StaticDevices")]
        [JsonProperty("StaticDevices", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> StaticDevices { get; set; }
    }

    //[BsonIgnoreExtraElements]
    //[JsonObject]
    //public class dynamicDevices
    //{
    //    [BsonElement("ID")]
    //    [JsonProperty("ID", NullValueHandling = NullValueHandling.Ignore)]
    //    public string ID { get; set; }
    //}

    //[BsonIgnoreExtraElements]
    //[JsonObject]
    //public class staticDevices
    //{
    //    [BsonElement("ID")]
    //    [JsonProperty("ID", NullValueHandling = NullValueHandling.Ignore)]
    //    public string ID { get; set; }
    //}
}
