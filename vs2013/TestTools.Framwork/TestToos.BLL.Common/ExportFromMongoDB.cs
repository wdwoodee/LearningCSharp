using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTools.Common.Utility;
using TestTools.DAL.DataModules;
using TestTools.DAL.MongoDB;

namespace TestToos.BLL.Common
{
    public class ExportFromMongoDB
    {
        public void ExportConfig()
        {
            string strHostName = string.Empty;
            string strContent = string.Empty;
            string strPath = ConfigurationManager.AppSettings["ConfigPath"];
            CurrConfig curr = new CurrConfig();
            var configList = curr.GetAllConfig();
            if (configList.Count > 0)
            {
                foreach (NgCurrConfig config in configList)
                {
                    strHostName = config.devNmae;
                    strContent = config.content;
                    if (strHostName != null)
                    {
                        string strFileName = ConvertFileName.RevertFilenamingrules(strHostName);
                        string filePath = strPath + "\\" + strFileName + ".config";
                        FileHelper.WriteFile(filePath, strContent);
                    }
                }
            }
        }

        public void ExportConfigBigDataQueryPage()
        {
            string strPath = ConfigurationManager.AppSettings["ConfigPath"];
            CurrConfig curr = new CurrConfig();
            int pageSize = 200;
            curr.QueryByPage(strPath, pageSize);
        }

        public void ExportConfigBigDataQueryGroup()
        {
            string strPath = ConfigurationManager.AppSettings["ConfigPath"];
            CurrConfig curr = new CurrConfig();
            int groupCount = 200;
            curr.QueryByGroup(groupCount, strPath);
        }
    }
}
