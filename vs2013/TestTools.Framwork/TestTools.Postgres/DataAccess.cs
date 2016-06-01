using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;

namespace TestTools.DAL.Postgres
{
    /// <summary>
    /// This class is for test results collection, Test results will be populated into Postgres DB, and then shows in web Portal.
    /// </summary>
    public class DataAccess
    {
        static string connectstr = ConfigurationManager.ConnectionStrings["Pgconnection"].ConnectionString;
        //static string connectstr = "Server=10.10.4.126;Port=5432;UserId=postgres;Password=postgres;Database=WebPortalDB;";

        # region 数据库的增删改方法
        ///
        /// 测试连接PostGreSQL数据库
        ///
        /// Success/Failure
        public static string TestConnection()
        {

            string str = connectstr;
            string strMessage = string.Empty;
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(str);
                conn.Open();
                strMessage = "Success";
                conn.Close();
            }
            catch
            {
                strMessage = "Failure";
            }
            return strMessage;
        }


        /// <summary>
        /// 读取数据表，返回数据集。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteSQL(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectstr))
                {
                    using (NpgsqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            cmd.Parameters.Clear();
                            return dt;
                        }
                    }
                }
            }
            catch
            {
                return dt;
            }
        }

        public static int ExecuteNonQuery(string sql)
        {
            int rowAffected = 0;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectstr))
                {
                    using (NpgsqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        conn.Open();
                        rowAffected = cmd.ExecuteNonQuery();
                        conn.Close();
                        return rowAffected;
                    }
                }
            }
            catch
            {
                return rowAffected;
            }
        }
        #endregion

        #region 公共方法
        public static string GetMachineID(string MachineName)
        {
            string sql = "SELECT \"ServerID\"  FROM \"TestServerInfo\" where \"ServerName\"= '" + MachineName + "'";
            DataTable dt_machine = ExecuteSQL(sql);
            if (dt_machine.Rows.Count > 0)
            {
                return dt_machine.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }

        }

        public static string GetLocalTestMachineID()
        {
            string testMachine = Environment.GetEnvironmentVariable("ComputerName");
            string sql = "SELECT \"ServerID\"  FROM \"TestServerInfo\" where \"ServerName\"= '" + testMachine + "'";
            DataTable dt_machine = ExecuteSQL(sql);
            if (dt_machine.Rows.Count > 0)
            {
                return dt_machine.Rows[0][0].ToString();
            }
            else
            {
                string machineIP = GetLocalIP();
                string version = "6.0";
                string sql_insert = string.Format("INSERT INTO \"TestServerInfo\"(\"ServerName\", \"ServerIP\", \"Version\") VALUES ('{0}', '{1}', '{2}')", testMachine, machineIP, version);
                ExecuteNonQuery(sql_insert);
                DataTable dt = ExecuteSQL(sql);
                return dt.Rows[0][0].ToString();
            }

        }

        private static string GetLocalIP()
        {
            //本机IP地址
            string strLocalIP = "";
            //得到计算机名
            string strPcName = Dns.GetHostName();
            //得到本机IP地址数组
            IPHostEntry ipEntry = Dns.GetHostEntry(strPcName);
            //遍历数组
            foreach (var IPadd in ipEntry.AddressList)
            {
                //判断当前字符串是否为正确IP地址
                if (IsRightIP(IPadd.ToString()))
                {
                    //得到本地IP地址
                    strLocalIP = IPadd.ToString();
                    //结束循环
                    break;
                }
            }
            //返回本地IP地址
            return strLocalIP;
        }
        public static bool IsRightIP(string strIPadd)
        {
            //利用正则表达式判断字符串是否符合IPv4格式
            if (Regex.IsMatch(strIPadd, "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}"))
            {
                //根据小数点分拆字符串
                string[] ips = strIPadd.Split('.');
                if (ips.Length == 4 || ips.Length == 6)
                {
                    //如果符合IPv4规则
                    if (System.Int32.Parse(ips[0]) < 256 && System.Int32.Parse(ips[1]) < 256 & System.Int32.Parse(ips[2]) < 256 & System.Int32.Parse(ips[3]) < 256)
                        //正确
                        return true;
                    //如果不符合
                    else
                        //错误
                        return false;
                }
                else
                    //错误
                    return false;
            }
            else
                //错误
                return false;
        }

        public static string GetRunIDByUniqueID(string UniqueID)
        {
            string sql = "SELECT \"RunID\"  FROM \"TestRunInfo\" where \"Coll_uniqueID\"='" + UniqueID + "'";
            DataTable dt = ExecuteSQL(sql);
            return dt.Rows[0][0].ToString();
        }

        public static string GetIDByComponentName(string ComponentName)
        {
            string sql = "SELECT \"ComponentID\"  FROM \"TestComponents\" where \"ComponentName\"='" + ComponentName + "'";
            DataTable dt = ExecuteSQL(sql);
            return dt.Rows[0][0].ToString();
        }

        public static string GetIDByTestTypeName(string TypeName)
        {
            string sql = "SELECT \"TypeID\"  FROM \"TestType\" where \"TypeName\"='" + TypeName + "'";
            DataTable dt = ExecuteSQL(sql);
            return dt.Rows[0][0].ToString();
        }
        #endregion

        # region 在数据库中插入新的记录
        public static void CreateTestCollectInDB(string UniqueID, string description, string version)
        {
            string starttime = DateTime.Now.ToString();
            string machineID = GetLocalTestMachineID();
            string sql = string.Format("INSERT INTO \"TestRunCollection\"(\"StartTime\", \"TestServerID\", \"Description\", \"Version\", \"Coll_UniqueID\") VALUES ('{0}', '{1}', '{2}','{3}', '{4}')", starttime, machineID, description, version, UniqueID);
            ExecuteNonQuery(sql);
        }

        public static void CreateTestRunInfoInDB(string UniqueID, string componentName, string TestTypeName, string TestURL, string Version, string ResourceMachineName, string TargetMachineName, string description)
        {
            string starttime = DateTime.Now.ToString();
            string ComponentID = GetIDByComponentName(componentName);
            string TypeID = GetIDByTestTypeName(TestTypeName);
            string TestmachineID = GetLocalTestMachineID();
            string ResourceMachineID = GetMachineID(ResourceMachineName);
            string TargetMachienID = GetMachineID(TargetMachineName);
            string status = "In Progress";
            string sql = string.Empty;
            if (ResourceMachineID == "" || TargetMachienID == "")
            {
                sql = string.Format("INSERT INTO \"TestRunInfo\"(\"ComponentID\", \"TypeID\", \"StartTime\", \"TestServerID\", \"TestURL\",  \"Status\", \"Version\", \"Description\", \"Coll_uniqueID\") VALUES ({0}, {1}, '{2}', '{3}', '{4}', '{5}',  '{6}', '{7}', '{8}')", ComponentID, TypeID, starttime, TestmachineID, TestURL, status, Version, description, UniqueID);
            }
            else
            {
                sql = string.Format("INSERT INTO \"TestRunInfo\"(\"ComponentID\", \"TypeID\", \"StartTime\", \"TestServerID\", \"ResourceMachineID\", \"TargetMachineID\", \"TestURL\",  \"Status\", \"Version\", \"Description\", \"Coll_uniqueID\") VALUES ({0}, {1}, '{2}', {3}, {4}, {5},  '{6}', '{7}', '{8}', '{9}', '{10}')", ComponentID, TypeID, starttime, TestmachineID, ResourceMachineID, TargetMachienID, TestURL, status, Version, description, UniqueID);
            }
            ExecuteNonQuery(sql);
        }

        public static void CreateTest_Coll_RunInDB(string UniqueID)
        {
            string sql_TestColl = "SELECT \"TRCOLLID\"  FROM \"TestRunCollection\" where \"Coll_UniqueID\"='" + UniqueID + "'";
            int TRCOLLID = Convert.ToInt32(ExecuteSQL(sql_TestColl).Rows[0][0].ToString());
            string sql_TestRun = "SELECT \"RunID\"  FROM \"TestRunInfo\" where \"Coll_uniqueID\"='" + UniqueID + "'";
            int RunID = Convert.ToInt32(ExecuteSQL(sql_TestRun).Rows[0][0].ToString());
            string sql_IntoTest_Coll_Run = "INSERT INTO \"Test_Coll_Run\"(\"TRCOLLID\", \"RUNID\")  VALUES (" + TRCOLLID + ", " + RunID + ")";
            ExecuteNonQuery(sql_IntoTest_Coll_Run);
        }

        #endregion

        #region 更改数据库中记录

        public static void UpdateTestCollectionFinishTime(string UniqueID)
        {
            string FinishTime = DateTime.Now.ToString();
            string sql = string.Format("UPDATE \"TestRunCollection\"  SET \"FinishTime\"='{0}' WHERE \"Coll_UniqueID\"='{1}'", FinishTime, UniqueID);
            ExecuteNonQuery(sql);
        }

        public static void UpdateTestRunINfoFinishTime(string UniqueID)
        {
            string FinishTime = DateTime.Now.ToString();
            string sql = string.Format("UPDATE \"TestRunInfo\"  SET \"FinishTime\"='{0}',\"Status\"='{1}' WHERE \"Coll_uniqueID\"='{2}'", FinishTime, "Done", UniqueID);
            ExecuteNonQuery(sql);
        }
        #endregion
    }
}
