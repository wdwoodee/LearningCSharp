/*********************************************************

 * File Name: MongoBase
 * Description:创建数据连接，完成增删改查等功能
 * Author：DWang
 * Revision History: 2015/11/2 修改Insert, Update, Delete等函数的返回类型
*********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;
using System.Data;
using Newtonsoft.Json;
using MongoDB.Bson.IO;
using System.Configuration;

namespace TestTools.DAL.MongoDB
{
    #region class MongoBase
    public class MongoBase
    {
        #region Veriable

        protected string mongoDBConnStr = ConfigurationManager.ConnectionStrings["MongoDBStr"].ConnectionString;
        protected MongoServer mongoServer = null;
        protected MongoDatabase mongoDatabase = null;
        protected string mongoDbName = null;
        #endregion

        #region Attribute
        public string DBName { get { return mongoDbName; } set { mongoDbName = value; } }
        public string ConnectionString { get { return mongoDBConnStr; } set { mongoDBConnStr = value; } }
        #endregion

        #region Constructor
        //mongodb://[username:password@]host1[:port1][,host2[:port2],...[,hostN[:portN]]][/[database][?options]]
        public MongoBase(string dbname)
        {
            //string connectString = mongoDBConnStr;
            mongoDbName = dbname;
            // Create a MongoClient object by using the connection string
            MongoClient mclient = new MongoClient(ConnectionString);

            //Use the MongoClient to access the server
            mongoServer = mclient.GetServer();

            //MongoServer = MongoDB.Driver.MongoClientExtensions.GetServer(mclient);
            mongoServer.Connect();

            // Use the server to access the 'test'pupu database
            mongoDatabase = mongoServer.GetDatabase(mongoDbName);
        }
        #endregion

        #region Destructor
        ~MongoBase()
        {
        }
        #endregion

        #region GetAllDBName
        //Get all DataBase table name
        public string[] GetAllDBNames()
        {
            if (mongoServer == null)
                return null;
            return mongoServer.GetDatabaseNames().ToArray();
        }
        #endregion

        #region GetAllCollNames
        //Get all collections name in database.
        public string[] GetAllCollNames()
        {
            if (mongoDatabase == null)
                return null;
            List<string> lsRet = new List<string>();
            foreach (string strDB in mongoDatabase.GetCollectionNames())
            {
                if (strDB.Length > 7 && strDB.Substring(0, 7) == "system.")
                    continue;
                lsRet.Add(strDB);
            }

            return lsRet.ToArray();
        }
        #endregion

        #region Disconntion to DB
        //To dispose the connection to MongoServer.
        public void Disconnection()
        {
            mongoServer.Disconnect();
        }
        #endregion
    }
    #endregion

    #region Class NetbrainDB
    public class MongoDB : MongoBase
    {
        #region Veriable
        protected MongoCollection mongoCollection = null;
        #endregion

        #region Constructor
        public MongoDB(string dbName, string collectionName)
            : base(dbName)
        {
            mongoCollection = mongoDatabase.GetCollection<BsonDocument>(collectionName);
        }
        #endregion

        #region Destructor
        ~MongoDB()
        {
        }
        #endregion

        #region GetCollection
        public MongoCollection GetCollection()
        {
            return mongoCollection;
        }
        #endregion

        #region GetAllData
        //Get All data of collection.
        public List<BsonDocument> GetAllData()
        {
            List<BsonDocument> allData = mongoCollection.FindAllAs<BsonDocument>().ToList();
            return allData;
        }

        public long GetAllCount()
        {
            long count = mongoCollection.FindAllAs<BsonDocument>().Count();
            return count;
        }

        /// <summary>
        /// Get All data of collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetAllData<T>()
        {
            List<T> allData = mongoCollection.FindAllAs<T>().ToList();
            return allData;
        }
        #endregion

        #region GetOneData
        //Get one data of collection which is the first matching.
        public BsonDocument GetOneData(string column, string value)
        {
            return mongoCollection.FindOneAs<BsonDocument>(Query.EQ(column, value));
        }

        /// <summary>
        /// Get one data T module
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public T GetOneData<T>(string column, string value)
        {
            return mongoCollection.FindOneAs<T>(Query.EQ(column, value));
        }

        /// <summary>
        /// Get one data of T module
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetOneData<T>(IMongoQuery query)
        {
            return mongoCollection.FindOneAs<T>(query);
        }
        #endregion

        #region IsExistAttribute
        /// <summary>
        /// To check the key whether exist or not.
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public bool IsExistAttribute(string strKey)
        {
            BsonDocument doc = mongoCollection.FindOneAs<BsonDocument>(Query.Exists(strKey));
            return (doc != null);
        }
        #endregion

        #region ExcuteQuery
        /// <summary>
        /// Excute query to get values.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<BsonDocument> ExcuteQuery(IMongoQuery query)
        {
            try
            {
                List<BsonDocument> results = mongoCollection.FindAs<BsonDocument>(query).ToList();
                Debug.WriteLine("Mongo Query successfully.");
                return results;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }
        #endregion

        #region ExecuteQuery: Using object
        public List<T> ExecuteQuery<T>(IMongoQuery query)
        {
            try
            {
                List<T> results = mongoCollection.FindAs<T>(query).ToList();
                Debug.WriteLine("Mongo Query successfully.");
                return results;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }
        #endregion

        #region ExcuteQueryGetPartialColumns
        /// <summary>
        /// Get the column value in your dictionary.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public List<BsonDocument> ExcuteQueryGetColumns(IMongoQuery query, IDictionary dic)
        {
            try
            {
                FieldsDocument fd = new FieldsDocument();
                //fieldsdocument fd = new fieldsdocument { { "name", 1 }, { "maintype", 1 } };                
                fd.AddRange(dic);
                //fd.Add("mainType", 1);
                List<BsonDocument> results = mongoCollection.FindAs<BsonDocument>(query).SetSortOrder().SetFields(fd).AsQueryable().ToList();
                Debug.WriteLine("Mongo Query successfully.");
                return results;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 以Bosn类型返回的所有表中数据，dic中满足的列
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public List<BsonDocument> ExcuteQueryGetColumnsAll(IDictionary dic)
        {
            try
            {
                FieldsDocument fd = new FieldsDocument();
                //fieldsdocument fd = new fieldsdocument { { "name", 1 }, { "maintype", 1 } };                
                fd.AddRange(dic);
                //fd.Add("mainType", 1);
                List<BsonDocument> results = mongoCollection.FindAllAs<BsonDocument>().SetSortOrder().SetFields(fd).AsQueryable().ToList();
                Debug.WriteLine("Mongo Query successfully.");
                return results;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }
        #endregion

        #region ExecuteQueryGetObjectListPartialColumns
        /// <summary>
        /// Execute query to get partial columns of collection, and change to object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public List<T> ExecuteQueryGetColumns<T>(IMongoQuery query, IDictionary dic)
        {
            List<T> t = new List<T>();
            //List<T> 
            try
            {
                FieldsDocument fd = new FieldsDocument();
                //fieldsdocument fd = new fieldsdocument { { "name", 1 }, { "maintype", 1 } };                
                fd.AddRange(dic);
                //fd.Add("mainType", 1);
                //t = mongoCollection.FindAs<T>(query).SetSortOrder().SetFields(fd).AsQueryable().ToList();
                t = mongoCollection.FindAs<T>(query).SetFields(fd).ToList();
                return t;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 以object类型返回的所有表中数据，dic中满足的列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic"></param>
        /// <returns></returns>
        public List<T> ExecuteQueryGetColumnsAllByMultiPages<T>(IDictionary dic,int pageIndex=0,int pageSize=1)
        {
            List<T> t = new List<T>();
            try
            {
                FieldsDocument fd = new FieldsDocument();
                //fieldsdocument fd = new fieldsdocument { { "name", 1 }, { "maintype", 1 } };                
                fd.AddRange(dic);
                //fd.Add("mainType", 1);
                //t = mongoCollection.FindAllAs<T>().SetSortOrder().SetFields(fd).AsQueryable().ToList();
                t = mongoCollection.FindAllAs<T>().SetFields(fd).Skip(pageIndex*pageSize).Take(pageSize).ToList();
                return t;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

        public List<T> ExecuteQueryGetColumnsAll<T>(IDictionary dic)
        {
            List<T> t = new List<T>();
            try
            {
                FieldsDocument fd = new FieldsDocument();
                //fieldsdocument fd = new fieldsdocument { { "name", 1 }, { "maintype", 1 } };                
                fd.AddRange(dic);
                //fd.Add("mainType", 1);
                //t = mongoCollection.FindAllAs<T>().SetSortOrder().SetFields(fd).AsQueryable().ToList();
                t = mongoCollection.FindAllAs<T>().SetFields(fd).ToList();
                return t;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

        #endregion



        #region ExecuteQueryGetObjectList
        /// <summary>
        /// T is your DB object. Such as DBDevice. Query is your mongoquery.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        //public List<T> ExecuteQueryGetObjectList<T>(IMongoQuery query)
        //{
        //    try
        //    {
        //        List<T> t = new List<T>();
        //        //List<T> 
        //        t = ExecuteQuery<T>(query);
        //        return t;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Error:" + ex.Message);
        //        return null;
        //    }
        //}
        #endregion

        //#region ExecuteQueryAndGetDBDevice
        //public List<MongoDevice> ExecuteQueryGetDBDevice(IMongoQuery query)
        //{
        //    List<MongoDevice> device = new List<MongoDevice>();

        //    List<BsonDocument> re = ExcuteQuery(query);
        //    foreach (BsonDocument c in re)
        //    {
        //        string jsonResult = c.ToJson(new JsonWriterSettings() { OutputMode = JsonOutputMode.Strict });
        //        MongoDevice jsonT = Newtonsoft.Json.JsonConvert.DeserializeObject<MongoDevice>(jsonResult);
        //        device.Add(jsonT);
        //    }
        //    return device;
        //}
        //#endregion

        #region Insert

        /// <summary>
        /// 非强类型，插入对象文档。
        /// </summary>
        /// <param name="bsonDoc">插入的bsondocument</param>
        /// <returns></returns>
        public void ExecuteInsertBsonDocument(BsonDocument bsonDoc)
        {
            try
            {
                mongoCollection.Insert(bsonDoc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 非强类型，特定表中批量插入document
        /// </summary>
        /// <param name="batch">批量插入document</param>
        /// <param name="option">插入过程出现错误时，继续插入后面的元素。</param>
        /// <returns></returns>
        public void ExecuteBatchInsertBsonDocument(IEnumerable<BsonDocument> batch, bool option)
        {
            try
            {
                if (option == true)
                {
                    MongoInsertOptions options = new MongoInsertOptions
                    {
                        Flags = InsertFlags.ContinueOnError
                    };
                    mongoCollection.InsertBatch(batch, options);
                }
                else
                {
                    mongoCollection.InsertBatch(batch);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 强类型，特定表中批量插入特定类型的objectlist,如：List<MongoDevice>
        /// </summary>
        /// <typeparam name="T">Model Data, such as:MongoDevice</typeparam>
        /// <param name="tList">List<MongoDevice></param>
        /// <param name="option">控制部分数据出错是不是继续insert后继数据</param>
        /// <returns></returns>
        public void ExecuteBatchInsert<T>(List<T> tList, bool option) where T : class
        {
            try
            {
                if (option == true)
                {
                    MongoInsertOptions options = new MongoInsertOptions
                    {
                        Flags = InsertFlags.ContinueOnError
                    };
                    mongoCollection.InsertBatch(tList, options);
                }
                else
                    mongoCollection.InsertBatch<T>(tList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 强类型，特定表中批量插入特定类型的object
        /// </summary>
        /// <typeparam name="T">Model Data, Such as: MongoDevice</typeparam>
        /// <param name="t">object</param>
        /// <returns></returns>
        public bool ExecuteInsert<T>(T t) where T : class
        {
            try
            {
                mongoCollection.Insert<T>(t);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete all data of collection
        /// </summary>
        /// <returns></returns>
        public void ExecuteDeleteAll()
        {
            try
            {
                mongoCollection.RemoveAll();
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete the data as query
        /// </summary>
        /// <param name="query">Your query</param>
        /// <returns></returns>
        public void ExecuteDeleteByQuery(IMongoQuery query)
        {
            try
            {
                mongoCollection.Remove(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update


        /// <summary>
        /// 只更新一个满足query的document
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public void ExecuteUpdateSingle(FindAndModifyArgs args)
        {
            try
            {
                mongoCollection.FindAndModify(args);
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 仅仅update一条满足条件的document
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="query"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public void ExecuteUpdateSingle<T>(IMongoQuery query, IMongoUpdate update)
        {
            try
            {
                //定义更新文档
                mongoCollection.Update(query, update);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 近更新一条满足条件的document
        /// </summary>
        /// <param name="query"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public void ExecuteUpdateSingle(IMongoQuery query, IMongoUpdate update)
        {
            try
            {
                //定义更新文档
                mongoCollection.Update(query, update);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 更新所有满足条件的document
        /// </summary>
        /// <param name="query"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public void ExecuteUpdateAll(IMongoQuery query, IMongoUpdate update)
        {
            try
            {
                //定义更新文档
                mongoCollection.Update(query, update, UpdateFlags.Multi);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 更新一条满足条件的document
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public void ExecuteUpdateAll<T>(IMongoQuery query, IMongoUpdate update)
        {
            try
            {
                //定义更新文档
                mongoCollection.Update(query, update, UpdateFlags.Multi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
    #endregion
}
