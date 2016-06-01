using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TestTools.DAL.DataModules
{
    [BsonIgnoreExtraElements]
    [JsonObject]
    public class OperateInfo
    {
        /// <summary>
        /// OperateUserName
        /// </summary>
        [BsonElement("opUser")]
        [JsonProperty("operateUserName", NullValueHandling = NullValueHandling.Ignore)]
        public string OperateUserName { get; set; }

        /// <summary>
        /// OperateTime
        /// </summary>
        [BsonElement("opTime")]
        [JsonProperty("operateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime OperateTime { get; set; }
    }
}
