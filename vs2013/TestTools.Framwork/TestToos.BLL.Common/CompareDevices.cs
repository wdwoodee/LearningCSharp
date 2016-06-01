using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTools.DAL.MongoDB;
using TestTools.DAL.DataModules;
using TestTools.Common.Utility;
using System.Configuration;
using System.Data;
using TestTools.DAL.Postgres;

namespace TestTools.BLL.Common
{
    public class CompareDevices
    {

        Device device = new Device();

        public DataTable GetDevicesFrom70DB()
        {
            List<NgDevice> devsList = new List<NgDevice>();

            DataTable dt = new DataTable();
            dt.Columns.Add("devicename", System.Type.GetType("System.String"));
            devsList = device.GetAllDevice();
            if (devsList.Count > 0)
            {
                foreach (NgDevice dg in devsList)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = dg.name;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public DataTable GetDeviceFrom60DB()
        {
            string sql = "select strname as devicename from devices";
            DataTable devs = DataAccess.ExecuteSQL(sql);
            return devs;
        }

        //Data table
        public void CompareTwoVersionDeivces()
        {
            //string strDifferentfilePath = ConfigurationManager.AppSettings["ExportDevicePath"];
            string strOriginalFilePath = ConfigurationManager.AppSettings["ExportDevicePath"];
            string Devices60 = strOriginalFilePath + @"\Devices60.csv";
            string Devices70 = strOriginalFilePath + @"\Devices70.csv";

            string strDevicesOnlyIn60Path = strOriginalFilePath + @"\DevicesOnly60.csv";
            string strDevicesOnlyIn70Path = strOriginalFilePath + @"\DevicesOnly70.csv";

            DataTable dv60 = DataTableHelper.TableSort(GetDeviceFrom60DB(), "devicename");
            DataTable dv70 = DataTableHelper.TableSort(GetDevicesFrom70DB(), "devicename");
            ParseCSV.SaveDataToCSV(dv60, Devices60);
            ParseCSV.SaveDataToCSV(dv60, Devices70);
            //DataTable count60 = ParseCSV.OpenCSV(groupDeviceCount60);
            //DataTable count70 = ParseCSV.OpenCSV(groupDeviceCount70);
            DataTableHelper.CompareTwoDataTable(dv60, dv70, strDevicesOnlyIn60Path, strDevicesOnlyIn70Path);
        }

        public void CompareDevicesUsingList()
        {
            string strOriginalFilePath = ConfigurationManager.AppSettings["ExportDevicePath"];
            string Devices60 = strOriginalFilePath + @"\Devices60.csv";
            string Devices70 = strOriginalFilePath + @"\Devices70.csv";

            string strDevicesOnlyIn60Path = strOriginalFilePath + @"\DevicesOnly60.csv";
            string strDevicesOnlyIn70Path = strOriginalFilePath + @"\DevicesOnly70.csv";

            var dev60List = Get60Device();
            var dev70List = Get70Device();

            List<string> onlyIn60 = dev60List.Except(dev70List).ToList();
            List<string> onlyIn70 = dev70List.Except(dev60List).ToList();

            string strDevs60 = String.Join(",\r\n", dev60List.ToArray());
            string strDevs70 = String.Join(",\r\n", dev70List.ToArray());
            string stronlyIn60 = String.Join(",\r\n", onlyIn60.ToArray());
            string stronlyIn70 = String.Join(",\r\n", onlyIn70.ToArray());

            FileHelper.WriteFile(Devices60, strDevs60);
            FileHelper.WriteFile(Devices70, strDevs70);
            FileHelper.WriteFile(strDevicesOnlyIn60Path, stronlyIn60);
            FileHelper.WriteFile(strDevicesOnlyIn70Path, stronlyIn70);
        }

        public List<string> Get60Device()
        {
            List<string> dev60List = new List<string>();
            string sql = "select strname as devicename from devices";
            DataTable devs = DataAccess.ExecuteSQL(sql);
            if (devs.Rows.Count > 0)
            {
                for (int i = 0; i < devs.Rows.Count; i++)
                {
                    dev60List.Add(devs.Rows[i][0].ToString());
                }
            }

            dev60List.Sort();
            return dev60List;
        }

        public List<string> Get70Device()
        {
            List<NgDevice> devsList = new List<NgDevice>();
            List<string> dev70List = new List<string>();
            devsList = device.GetAllDevice();
            if (devsList.Count > 0)
            {
                foreach (NgDevice dg in devsList)
                {
                    dev70List.Add(dg.name);
                }
            }
            dev70List.Sort();
            return dev70List;
        }
    }
}
