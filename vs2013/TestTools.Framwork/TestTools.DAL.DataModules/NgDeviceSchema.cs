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
    public class NgDeviceSchema
    {
        [BsonId]
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public string _id { get; set; }

        [BsonElement("displayname")]
        [JsonProperty("displayname", NullValueHandling = NullValueHandling.Ignore)]
        public string displayname { get; set; }

        [BsonElement("shortDisplayname")]
        [JsonProperty("shortDisplayname", NullValueHandling = NullValueHandling.Ignore)]
        public string shortDisplayname { get; set; }

        [BsonElement("usercanmodify")]
        [JsonProperty("usercanmodify", NullValueHandling = NullValueHandling.Ignore)]
        public bool? usercanmodify { get; set; }

        [BsonElement("isdisplay")]
        [JsonProperty("isdisplay", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isdisplay { get; set; }

        [BsonElement("displayOrder")]
        [JsonProperty("displayOrder", NullValueHandling = NullValueHandling.Ignore)]
        public int? displayOrder { get; set; }

        [BsonElement("isDisplayInDataview")]
        [JsonProperty("isDisplayInDataview", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isDisplayInDataview { get; set; }

        [BsonElement("isbuildin")]
        [JsonProperty("isbuildin", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isbuildin { get; set; }

        [BsonElement("isSystem")]
        [JsonProperty("isSystem", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isSystem { get; set; }


        [BsonElement("type")]
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }

        [BsonElement("iskey")]
        [JsonProperty("iskey", NullValueHandling = NullValueHandling.Ignore)]
        public bool? iskey { get; set; }

        [BsonElement("hasCLog")]
        [JsonProperty("hasCLog", NullValueHandling = NullValueHandling.Ignore)]
        public bool? hasCLog { get; set; }

        [BsonElement("isPermanent")]
        [JsonProperty("isPermanent", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isPermanent { get; set; }

        [BsonElement("subtype")]
        [JsonProperty("subtype", NullValueHandling = NullValueHandling.Ignore)]
        public string subtype { get; set; }

        [BsonElement("key")]
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> key { get; set; }

        [BsonElement("description")]
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }

        [BsonElement("isdysearch")]
        [JsonProperty("isdysearch", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isdysearch { get; set; }

        [BsonElement("isfullsearch")]
        [JsonProperty("isfullsearch", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isfullsearch { get; set; }

        [BsonElement("weight")]
        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public int weight { get; set; }


        [BsonElement("applyTo")]
        [JsonProperty("applyTo", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> applyTo { get; set; }

        [BsonElement("isSeparateShow")]
        [JsonProperty("isSeparateShow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isSeparateShow { get; set; }

        [BsonElement("unit")]
        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string unit { get; set; }

        //add for phantom interfaces;

        [BsonElement("isPhantomInterface")]
        [JsonProperty("isPhantomInterface", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isPhantomInterface { get; set; }

        [BsonElement("isCompare")]
        [JsonProperty("isCompare", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isCompare { get; set; }

        [BsonElement("isCompareKey")]
        [JsonProperty("isCompareKey", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isCompareKey { get; set; }

        [BsonElement("isStandaloneTable")]
        [JsonProperty("isStandaloneTable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isStandaloneTable { get; set; }

        [BsonElement("tableName")]
        [JsonProperty("tableName", NullValueHandling = NullValueHandling.Ignore)]
        public string tableName { get; set; }

        [BsonElement("associatedSchema")]
        [JsonProperty("associatedSchema", NullValueHandling = NullValueHandling.Ignore)]
        public string associatedSchema { get; set; }

        [BsonElement("nameTemplate")]
        [JsonProperty("nameTemplate", NullValueHandling = NullValueHandling.Ignore)]
        public string nameTemplate { get; set; }

        [BsonElement("operateInfo")]
        [JsonProperty("operateInfo", NullValueHandling = NullValueHandling.Ignore)]
        public OperateInfo operateInfo { get; set; }
    }

    public class DeviceSchemaSorter : IComparer<BsonDocument>
    {
        public int Compare(BsonDocument b1, BsonDocument b2)
        {
            if (!b1.Contains("displayOrder"))
            {
                return 1;
            }
            else if (!b2.Contains("displayOrder"))
            {
                return -1;
            }
            else
            {
                return (b1.GetValue("displayOrder").IsBsonNull ? 0 : (int)b1.GetValue("displayOrder")) - (b2.GetValue("displayOrder").IsBsonNull ? 0 : (int)b2.GetValue("displayOrder"));
            }
        }
    }
}
