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
    public class NgDevice
    {
        [BsonId]
        [JsonProperty("ID", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }

        [BsonElement("name")]
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
    }
}
