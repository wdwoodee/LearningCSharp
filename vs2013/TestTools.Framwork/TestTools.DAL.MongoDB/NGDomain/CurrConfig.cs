using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTools.DAL.DataModules;
using System.Configuration;
using MongoDB.Bson;
using TestTools.Common.Utility;

namespace TestTools.DAL.MongoDB
{
    public class CurrConfig
    {
        private string strDbName = string.Empty;
        private string strDtName = string.Empty;
        MongoDB collectionCurrConfig;
        public CurrConfig()
        {
            strDbName = ConfigurationManager.AppSettings["DBName"];
            strDtName = "CurrConfig";
            collectionCurrConfig = new MongoDB(strDbName, strDtName);
        }
        public List<NgCurrConfig> GetAllConfig()
        {
            Dictionary<string, int> dic = new Dictionary<string, int> { { "_id", 1 }, { "devName", 1 }, { "content", 1 } };
            var config = collectionCurrConfig.ExecuteQueryGetColumnsAll<NgCurrConfig>(dic);
            return config;
        }

        public void QueryByPage(string strPath, int pageSize)
        {
            Dictionary<string, int> dic = new Dictionary<string, int> { { "_id", 1 }, { "devName", 1 }, { "content", 1 } };
            long count = collectionCurrConfig.GetAllCount();
            if (count > 0)
            {
                for (var i = 0; i <= count / pageSize; i++)
                {
                    var onePage = collectionCurrConfig.ExecuteQueryGetColumnsAllByMultiPages<NgCurrConfig>(dic, i, pageSize);
                    if (onePage != null && onePage.Count > 0)
                    {
                        foreach (var one in onePage)
                        {
                            string name = one.devName;
                            string content = one.content;
                            string strFileName = ConvertFileName.RevertFilenamingrules(name);
                            string filePath = strPath + "\\" + strFileName + ".config";
                            FileHelper.WriteFile(filePath, content);
                        }
                    }
                }
            }
        }

        public void QueryByGroup(int groupSize, string strPath)
        {
            Dictionary<string, int> dicID = new Dictionary<string, int> { { "_id", 1 } };
            Dictionary<string, int> dic = new Dictionary<string, int> { { "_id", 1 }, { "devName", 1 }, { "content", 1 } };
            var id = collectionCurrConfig.ExcuteQueryGetColumnsAll(dicID);
            for (var i = 1; i <= id.Count / groupSize + 1; i++)
            {
                List<string> ids = new List<string>();
                for (var j = groupSize; j >= 1; j--)
                {
                    if ((i * groupSize - j) > id.Count - 1)
                    {
                        break;
                    }
                    ids.Add(id[i * groupSize - j].GetValue("_id").ToString());
                }
                IMongoQuery query = Query.In("_id", new BsonArray(ids));
                var oneGroup = collectionCurrConfig.ExecuteQueryGetColumns<NgCurrConfig>(query, dic);
                if (oneGroup != null && oneGroup.Count > 0)
                {
                    foreach (var one in oneGroup)
                    {
                        string name = one.devName;
                        string content = one.content;
                        string strFileName = ConvertFileName.RevertFilenamingrules(name);
                        string filePath = strPath + "\\" + strFileName + ".config";
                        FileHelper.WriteFile(filePath, content);
                    }
                }
            }
            
        }

        public void ListTest()
        {
            List<int> a = new List<int>();
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            a.AddRange(input);
            //Debug.WriteLine(a[1]);
            for (int i = 1; i <= a.Count / 3 + 1; i++)
            {
                List<int> b = new List<int>();
                for (int j = 3; j >= 1; j--)
                {
                    if ((i * 3 - j) > a.Count - 1)
                    {
                        break;
                    }
                   // Debug.WriteLine(a[i * 3 - j]);
                    //b.Add(a[j * i]);
                }
                //Debug.WriteLine("ok");
            }
        }
    }
}
