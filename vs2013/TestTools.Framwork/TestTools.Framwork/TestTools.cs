using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.BLL.Common;
using System.Diagnostics;
using TestTools.Common.Utility;
using System.Collections.Generic;
using TestToos.BLL.Common;

namespace TestTools.Framwork
{
    [TestClass]
    public class TestTools
    {
        public TestTools()
        {
        }
        [TestMethod]
        public void ExportConfigFromDB()
        {
            ExportFromMongoDB exConfig = new ExportFromMongoDB();
            exConfig.ExportConfig();
            //exConfig.ExportConfigBigDataQueryPage();
        }

        [TestMethod]
        public void CompareSysDevGroup()
        {
            //ExportGroupin70 ex70 = new ExportGroupin70();
            //ExportGroupin60 ex60 = new ExportGroupin60();
            //ex60.ExportSystemGroup();
            //ex70.ExportSystemGroup();
            //CompareFile.GetDifferentFile();

            CompareSysDG comSysDG = new CompareSysDG();
            comSysDG.ExportSystemGroup60();
            comSysDG.ExportSystemGroup70();

            //Same data in two version use this.
            //comSysDG.GetDifferentFile();

            //Different data in two version use this
            comSysDG.GetDifferentFileDeleteDifDevs();
        }

        [TestMethod]
        public void CompareDevicesInTwoVersion()
        {
            CompareDevices comDev = new CompareDevices();

            //Stopwatch sw = new Stopwatch();
            //sw.Start(); 
            //comDev.CompareTwoVersionDeivces();
            //sw.Stop();
            //TimeSpan ts = sw.Elapsed;
            //FileHelper.WriteFile(@"C:\time.txt", string.Format("Stopwatch总共花费{0}ms.", ts.TotalMilliseconds));

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            comDev.CompareDevicesUsingList();
            sw2.Stop();
            TimeSpan ts2 = sw2.Elapsed;
            FileHelper.WriteFile(@"C:\time2.txt", string.Format("Stopwatch总共花费{0}ms.", ts2.TotalMilliseconds));
        }

        [TestMethod]
        public void CompareJson()
        {
            CompareJson com = new CompareJson();

            com.SaveDeviceSchemaToCSVFromDB();

            com.SaveDeviceSchmaToCSVFromJsonFile();
        }

    }
}
