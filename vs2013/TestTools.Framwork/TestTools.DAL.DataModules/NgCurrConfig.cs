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
    public class NgCurrConfig
    {
        [BsonId]
        [JsonProperty("ID", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }

        [BsonElement("content")]
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string content { get; set; }

        [BsonElement("devId")]
        [JsonProperty("devId", NullValueHandling = NullValueHandling.Ignore)]
        public string devId { get; set; }

        [BsonElement("devNmae")]
        [JsonProperty("devNmae", NullValueHandling = NullValueHandling.Ignore)]
        public string devNmae { get; set; }
    }
}
