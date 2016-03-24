using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Npgsql;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Data;

namespace PosgresConn
{
    public class Connection
    {
        //static string connectstr = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        static string connectstr = ConfigurationManager.AppSettings["connectString"];
        //static string connectstr = "Server=127.0.0.1;Port=54321;UserId=postgres;Password=postgres;Database=postgres;";
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
        /// <summary>
        /// 读取数据表，返回数据集。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ConvertIP(long mgtIP)
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectstr))
                {
                    using (NpgsqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from convertoip(" + mgtIP + ")";
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

        /// <summary>
        /// 从数据库中查询设备名称作为数据验证的搜索条件。
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDeviceListFromDB()
        {
            DataTable results = new DataTable();
            string con_str = @"select a.strname from devices a where a.id in (select id from devices  where isubtype = a.isubtype  and isubtype not in (1024) order by id desc LIMIT 2) order by id desc LIMIT 30";
            try
            {
                results = ExecuteSQL(con_str);
                return results;
            }
            catch
            {
                return results;
            }
        }

        /// <summary>
        /// 从数据库中IP interface的IP地址作为数据验证的搜索条件。
        /// </summary>
        /// <returns></returns>
        public static DataTable GetIPInterfaceListFromDB()
        {
            DataTable results = new DataTable();
            string con_str = @"select distinct interface_ip from interfacesetting where interface_ip is not null and interface_ip !='0.0.0.0' and interface_ip!='' order by interface_ip limit 50";
            try
            {
                results = ExecuteSQL(con_str);
                return results;
            }
            catch
            {
                return results;
            }
        }



    }
}
