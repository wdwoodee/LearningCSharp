using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTools.DAL.MongoDB;
using TestTools.DAL.DataModules;
using TestTools.Common.Utility;
using System.Data;
using System.Configuration;
using System.IO;


namespace TestTools.BLL.Common
{
    public class CompareJson
    {
        public void SaveDeviceSchemaToCSVFromDB()
        {
            string path = ConfigurationManager.AppSettings["DeviceSchemaCSVPath"] + @"\DeviceSchemaFromDB.csv";
            DataTable dt = GetDeviceSchemaTableFromDB();
            ParseCSV.SaveDataToCSV(dt, path);
        }

        public void SaveDeviceSchmaToCSVFromJsonFile()
        {
            string path = ConfigurationManager.AppSettings["DeviceSchemaCSVPath"] + @"\DeviceSchemaFromJsonFile.csv";
            DataTable dt = GetDeviceSchemaTableFromFile();
            ParseCSV.SaveDataToCSV(dt, path);
        }

        public DataTable GetDeviceSchemaTableFromDB()
        {
            DeviceSchema devSchema = new DeviceSchema();
            DataTable dt = new DataTable();

            dt.Columns.Add("_id", System.Type.GetType("System.String"));
            dt.Columns.Add("displayname", System.Type.GetType("System.String"));
            dt.Columns.Add("shortDisplayname", System.Type.GetType("System.String"));
            dt.Columns.Add("displayOrder", System.Type.GetType("System.String"));
            dt.Columns.Add("isfullsearch", System.Type.GetType("System.String"));
            dt.Columns.Add("isdysearch", System.Type.GetType("System.String"));
            dt.Columns.Add("description", System.Type.GetType("System.String"));
            dt.Columns.Add("usercanmodify", System.Type.GetType("System.String"));
            dt.Columns.Add("key", System.Type.GetType("System.String"));
            dt.Columns.Add("type", System.Type.GetType("System.String"));
            dt.Columns.Add("unit", System.Type.GetType("System.String"));
            dt.Columns.Add("subtype", System.Type.GetType("System.String"));
            dt.Columns.Add("weight", System.Type.GetType("System.String"));
            dt.Columns.Add("applyTo", System.Type.GetType("System.String"));
            dt.Columns.Add("tableName", System.Type.GetType("System.String"));
            dt.Columns.Add("associatedSchema", System.Type.GetType("System.String"));
            dt.Columns.Add("nameTemplate", System.Type.GetType("System.String"));
            dt.Columns.Add("isDisplayInDataview", System.Type.GetType("System.String"));
            dt.Columns.Add("isSeparateShow", System.Type.GetType("System.String"));
            dt.Columns.Add("isStandaloneTable", System.Type.GetType("System.String"));
            dt.Columns.Add("isPermanent", System.Type.GetType("System.String"));
            dt.Columns.Add("isPhantomInterface", System.Type.GetType("System.String"));
            dt.Columns.Add("isdisplay", System.Type.GetType("System.String"));
            dt.Columns.Add("isbuildin", System.Type.GetType("System.String"));
            dt.Columns.Add("isSystem", System.Type.GetType("System.String"));
            dt.Columns.Add("iskey", System.Type.GetType("System.String"));
            var ds = devSchema.GetAllSchemaData();
            if (ds.Count > 0)
            {
                foreach (NgDeviceSchema d in ds)
                {
                    DataRow dr = dt.NewRow();
                    dr["_id"] = d._id;
                    dr["displayname"] = d.displayname;
                    dr["shortDisplayname"] = d.shortDisplayname;
                    dr["displayOrder"] = d.displayOrder;
                    dr["isfullsearch"] = d.isfullsearch;
                    dr["isdysearch"] = d.isdysearch;
                    dr["description"] = d.description;
                    dr["usercanmodify"] = d.usercanmodify;
                    dr["key"] = d.key;
                    dr["type"] = d.type;
                    dr["unit"] = d.unit;
                    dr["subtype"] = d.subtype;
                    dr["weight"] = d.weight;
                    dr["applyTo"] = d.applyTo;
                    dr["tableName"] = d.tableName;
                    dr["associatedSchema"] = d.associatedSchema;
                    dr["nameTemplate"] = d.nameTemplate;
                    dr["isDisplayInDataview"] = d.isDisplayInDataview;
                    dr["isSeparateShow"] = d.isSeparateShow;
                    dr["isStandaloneTable"] = d.isStandaloneTable;
                    dr["isPermanent"] = d.isPermanent;
                    dr["isPhantomInterface"] = d.isPhantomInterface;
                    dr["isdisplay"] = d.isdisplay;
                    dr["isbuildin"] = d.isbuildin;
                    dr["isSystem"] = d.isSystem;
                    dr["iskey"] = d.iskey;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public DataTable GetDeviceSchemaTableFromFile()
        {
            string DeviceSchemaPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\TestTools\Reference" + @"\DeviceSchema.json";
            List<NgDeviceSchema> dsJson = ParseJsonFromFile.ConvertJsonToObj<NgDeviceSchema>(DeviceSchemaPath);

            DataTable dt = new DataTable();

            dt.Columns.Add("_id", System.Type.GetType("System.String"));
            dt.Columns.Add("displayname", System.Type.GetType("System.String"));
            dt.Columns.Add("shortDisplayname", System.Type.GetType("System.String"));
            dt.Columns.Add("displayOrder", System.Type.GetType("System.String"));
            dt.Columns.Add("isfullsearch", System.Type.GetType("System.String"));
            dt.Columns.Add("isdysearch", System.Type.GetType("System.String"));
            dt.Columns.Add("description", System.Type.GetType("System.String"));
            dt.Columns.Add("usercanmodify", System.Type.GetType("System.String"));
            dt.Columns.Add("key", System.Type.GetType("System.String"));
            dt.Columns.Add("type", System.Type.GetType("System.String"));
            dt.Columns.Add("unit", System.Type.GetType("System.String"));
            dt.Columns.Add("subtype", System.Type.GetType("System.String"));
            dt.Columns.Add("weight", System.Type.GetType("System.String"));
            dt.Columns.Add("applyTo", System.Type.GetType("System.String"));
            dt.Columns.Add("tableName", System.Type.GetType("System.String"));
            dt.Columns.Add("associatedSchema", System.Type.GetType("System.String"));
            dt.Columns.Add("nameTemplate", System.Type.GetType("System.String"));
            dt.Columns.Add("isDisplayInDataview", System.Type.GetType("System.String"));
            dt.Columns.Add("isSeparateShow", System.Type.GetType("System.String"));
            dt.Columns.Add("isStandaloneTable", System.Type.GetType("System.String"));
            dt.Columns.Add("isPermanent", System.Type.GetType("System.String"));
            dt.Columns.Add("isPhantomInterface", System.Type.GetType("System.String"));
            dt.Columns.Add("isdisplay", System.Type.GetType("System.String"));
            dt.Columns.Add("isbuildin", System.Type.GetType("System.String"));
            dt.Columns.Add("isSystem", System.Type.GetType("System.String"));
            dt.Columns.Add("iskey", System.Type.GetType("System.String"));

            if (dsJson.Count > 0)
            {
                foreach (NgDeviceSchema d in dsJson)
                {
                    DataRow dr = dt.NewRow();
                    dr["_id"] = d._id;
                    dr["displayname"] = d.displayname;
                    dr["shortDisplayname"] = d.shortDisplayname;
                    dr["displayOrder"] = d.displayOrder;
                    dr["isfullsearch"] = d.isfullsearch;
                    dr["isdysearch"] = d.isdysearch;
                    dr["description"] = d.description;
                    dr["usercanmodify"] = d.usercanmodify;
                    dr["key"] = d.key;
                    dr["type"] = d.type;
                    dr["unit"] = d.unit;
                    dr["subtype"] = d.subtype;
                    dr["weight"] = d.weight;
                    dr["applyTo"] = d.applyTo;
                    dr["tableName"] = d.tableName;
                    dr["associatedSchema"] = d.associatedSchema;
                    dr["nameTemplate"] = d.nameTemplate;
                    dr["isDisplayInDataview"] = d.isDisplayInDataview;
                    dr["isSeparateShow"] = d.isSeparateShow;
                    dr["isStandaloneTable"] = d.isStandaloneTable;
                    dr["isPermanent"] = d.isPermanent;
                    dr["isPhantomInterface"] = d.isPhantomInterface;
                    dr["isdisplay"] = d.isdisplay;
                    dr["isbuildin"] = d.isbuildin;
                    dr["isSystem"] = d.isSystem;
                    dr["iskey"] = d.iskey;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

    }
}
