using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using TestTools.Common.Utility;
using System.IO;
using TestTools.DAL.Postgres;
using TestTools.DAL.MongoDB;
using TestTools.DAL.DataModules;
using TestTools.BLL.Common;

namespace TestToos.BLL.Common
{
    public class CompareSysDG
    {
        DeviceGroup dgSys = new DeviceGroup();
        Device device = new Device();
        List<NgDeviceGroup> dgSystemGroups = new List<NgDeviceGroup>();
        List<NgDevice> devs = new List<NgDevice>();

        public CompareSysDG()
        {
            dgSystemGroups = dgSys.GetSystemDeviceGroup();
            devs = device.GetAllDevice();
        }

        public void GetDifferentFile()
        {
            string strDifferentfilePath = ConfigurationManager.AppSettings["DifferentCSVPath"];
            string strOriginalFilePath = ConfigurationManager.AppSettings["ExportGroupCSVPath"];
            string groupDeviceCount60 = strOriginalFilePath + @"\SysDeviceCount60.csv";
            string groupDevices60 = strOriginalFilePath + @"\SysDevices60.csv";
            string groupDeviceCount70 = strOriginalFilePath + @"\SysDeviceCount70.csv";
            string groupDevices70 = strOriginalFilePath + @"\SysDevices70.csv";

            string strCountOnlyIn60Path = strDifferentfilePath + @"\SystemGroupCountOnly60.csv";
            string strCountOnlyIn70Path = strDifferentfilePath + @"\SystemGroupCountOnly70.csv";

            string strDevicesOnlyIn60Path = strDifferentfilePath + @"\DeviceOnly60.csv";
            string strDevicesOnlyIn70Path = strDifferentfilePath + @"\DeviceOnly70.csv";

            DataTable count60 = ParseCSV.OpenCSV(groupDeviceCount60);
            DataTable count70 = ParseCSV.OpenCSV(groupDeviceCount70);
            DataTableHelper.CompareTwoDataTable(count60, count70, strCountOnlyIn60Path, strCountOnlyIn70Path);

            DataTable devices60 = ParseCSV.OpenCSV(groupDevices60);
            DataTable devices70 = ParseCSV.OpenCSV(groupDevices70);
            DataTableHelper.CompareTwoDataTable(devices60, devices70, strDevicesOnlyIn60Path, strDevicesOnlyIn70Path);
        }

        public void GetDifferentFileDeleteDifDevs()
        {
            CompareDevices comDevice = new CompareDevices();
            List<string> dev60List = comDevice.Get60Device();
            List<string> dev70List = comDevice.Get70Device();
            List<string> onlyIn60 = dev60List.Except(dev70List).ToList();
            //List<string> onlyIn60 = new List<string>();
            //onlyIn60.Add("123");
            //onlyIn60.Add("456");
            List<string> onlyIn70 = dev70List.Except(dev60List).ToList();

            string strDifferentfilePath = ConfigurationManager.AppSettings["DifferentCSVPath"];
            string strOriginalFilePath = ConfigurationManager.AppSettings["ExportGroupCSVPath"];
            string groupDeviceCount60 = strOriginalFilePath + @"\SysDeviceCount60.csv";
            string groupDevices60 = strOriginalFilePath + @"\SysDevices60.csv";
            string groupDeviceCount70 = strOriginalFilePath + @"\SysDeviceCount70.csv";
            string groupDevices70 = strOriginalFilePath + @"\SysDevices70.csv";

            string strCountOnlyIn60Path = strDifferentfilePath + @"\SystemGroupCountOnly60.csv";
            string strCountOnlyIn70Path = strDifferentfilePath + @"\SystemGroupCountOnly70.csv";

            string strDevicesOnlyIn60Path = strDifferentfilePath + @"\DeviceOnly60.csv";
            string strDevicesOnlyIn70Path = strDifferentfilePath + @"\DeviceOnly70.csv";

            DataTable count60 = ParseCSV.OpenCSV(groupDeviceCount60);
            DataTable count70 = ParseCSV.OpenCSV(groupDeviceCount70);
            DataTableHelper.CompareTwoDataTable(count60, count70, strCountOnlyIn60Path, strCountOnlyIn70Path);

            DataTable devices60 = ParseCSV.OpenCSV(groupDevices60);
            DataTable devices70 = ParseCSV.OpenCSV(groupDevices70);

            DataTable dt60 = DeleteRows(onlyIn60, devices60);
            DataTable dt70 = DeleteRows(onlyIn70, devices70);
            
            DataTableHelper.CompareTwoDataTable(dt60, dt70, strDevicesOnlyIn60Path, strDevicesOnlyIn70Path);
        }

        public void ExportSystemGroup60()
        {
            //test connection
            //Console.WriteLine(DataAccess.TestConnection());
            string filePath = ConfigurationManager.AppSettings["ExportGroupCSVPath"];
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string groupDeviceCount60 = filePath + @"\SysDeviceCount60.csv";
            string groupDevices60 = filePath + @"\SysDevices60.csv";

            //Save Device Count CSV
            DataTable groupDeviceCoun = DataTableHelper.TableSort(GetSystemGroupAndCount(), "groupname");
            ParseCSV.SaveDataToCSV(groupDeviceCoun, groupDeviceCount60);

            //Save Group/Devices CSV
            DataTable groupDevice = DataTableHelper.TableSort(GetSystemGroupAndDevice(), "groupname");
            ParseCSV.SaveDataToCSV(groupDevice, groupDevices60);
            DataTable d = ParseCSV.OpenCSV(groupDevices60);
        }

        public DataTable GetSystemGroupAndCount()
        {
            string sql = "select sys.strname as groupname,count(sysdev.deviceid) as devicecount from systemdevicegroup as sys,systemdevicegroupdevice as sysdev where sys.id=sysdev.systemdevicegroupid group by groupname";
            DataTable groupAndDeviceCount = DataAccess.ExecuteSQL(sql);
            if (groupAndDeviceCount.Rows.Count > 0)
            {
                //Delete from back
                for (int i = groupAndDeviceCount.Rows.Count - 1; i >= 0; i--)
                {
                    if (groupAndDeviceCount.Rows[i][0].ToString().Contains("Island") || groupAndDeviceCount.Rows[i][0].ToString().Contains("Stand Alone"))
                    {
                        groupAndDeviceCount.Rows.RemoveAt(i);
                    }
                }
            }
            return groupAndDeviceCount;
        }

        public DataTable GetSystemGroupAndDevice()
        {
            string sql = "select sys.strname as groupname,dev.strname as devicename from systemdevicegroup as sys,systemdevicegroupdevice as sysdev,devices as dev where sys.id=sysdev.systemdevicegroupid and sysdev.deviceid=dev.id";
            DataTable groupAndDevices = DataAccess.ExecuteSQL(sql);
            if (groupAndDevices.Rows.Count > 0)
            {
                for (int i = groupAndDevices.Rows.Count - 1; i >= 0; i--)
                {
                    if (groupAndDevices.Rows[i][0].ToString().Contains("Island") || groupAndDevices.Rows[i][0].ToString().Contains("Stand Alone"))
                    {
                        groupAndDevices.Rows.RemoveAt(i);
                    }

                }
            }
            return groupAndDevices;
        }

        public void ExportSystemGroup70()
        {
            //test connection
            //Console.WriteLine(DataAccess.TestConnection());
            string filePath = ConfigurationManager.AppSettings["ExportGroupCSVPath"];
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string groupDeviceCount70 = filePath + @"\SysDeviceCount70.csv";
            string groupDevices70 = filePath + @"\SysDevices70.csv";

            //Save Device Count CSV
            DataTable groupDeviceCoun = DataTableHelper.TableSort(SystemGroupDeviceCount(), "groupname");
            ParseCSV.SaveDataToCSV(groupDeviceCoun, groupDeviceCount70);

            //Save Group/Devices CSV
            DataTable groupDevice = DataTableHelper.TableSort(SystemGroupDevices(), "groupname");
            ParseCSV.SaveDataToCSV(groupDevice, groupDevices70);
        }

        /// <summary>
        /// 返回Device group name对应的device count
        /// </summary>
        /// <returns></returns>
        public DataTable SystemGroupDeviceCount()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("groupname", System.Type.GetType("System.String"));
            dt.Columns.Add("devicecount", System.Type.GetType("System.String"));
            if (dgSystemGroups.Count > 0)
            {
                foreach (NgDeviceGroup dg in dgSystemGroups)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = dg.Name;
                    dr[1] = dg.StaticDevices.Count;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        /// <summary>
        /// 返回Device group name对应的device list
        /// </summary>
        /// <returns></returns>
        public DataTable SystemGroupDevices()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("groupname", System.Type.GetType("System.String"));
            dt.Columns.Add("devicename", System.Type.GetType("System.String"));
            //当system device group个数大于0时开始循环
            if (dgSystemGroups.Count > 0)
            {
                foreach (NgDeviceGroup dg in dgSystemGroups)
                {
                    //用于记录在device表中查找到的device个数，当此count等于dynamic device count时结束本次循环。
                    int devcount = 0;
                    if (devs.Count > 0)
                    {
                        foreach (NgDevice dev in devs)
                        {
                            //Create new row
                            DataRow dr = dt.NewRow();
                            //add device group name
                            dr[0] = dg.Name;
                            //在Device表中循环
                            foreach (string deviceid in dg.StaticDevices)
                            {
                                //当device id和dynamic device id相同时，把device name值赋给dr[1]
                                if (deviceid == dev.ID)
                                {
                                    dr[1] = dev.name;
                                    dt.Rows.Add(dr);
                                    devcount++;
                                    //满足条件后结束本次循环，提高性能
                                    if (devcount == dg.StaticDevices.Count)
                                        continue;
                                }
                            }
                        }
                    }
                }
            }
            return dt;
        }

        public DataTable DeleteRows(List<string> deleteKeys, DataTable dt)
        {
            DataTable afterDelete = dt.Copy();
            if (deleteKeys.Count > 0)
            {
                foreach (string key in deleteKeys)
                {
                    for (int i = afterDelete.Rows.Count - 1; i >= 0; i--)
                    {
                        if (key == afterDelete.Rows[i][1].ToString())
                        {
                            afterDelete.Rows.RemoveAt(i);
                        }
                    }
                    //afterDelete = afterDelete.Copy();
                }
            }
            return afterDelete;
        }
    }
}
