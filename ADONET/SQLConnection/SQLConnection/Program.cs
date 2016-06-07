using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace SQLConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\")
                || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = System.IO.Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }
            string connString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;

            #region executenonquery
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DBTest.mdf;Integrated Security=True");
            //using(SqlConnection conn = new SqlConnection(connString))
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = "Insert into Student(Name, Age) values('wangjunfang',25)";
            //        cmd.ExecuteNonQuery();
            //        Console.WriteLine("Insert is ok!");
            //    }
            //}
            //Console.WriteLine("DataBase connection success!");
            #endregion

            Console.WriteLine("Please input username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Please input password:");
            string password = Console.ReadLine();

            #region sqldatareader
            //using (SqlConnection conn = new SqlConnection(connString))
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = "select * from T_User where UserName = '" + userName + "'";
            //        using (SqlDataReader reader = cmd.ExecuteReader())
            //        {
            //            bool flag = reader.Read();
            //            Console.WriteLine(flag);
            //            if (flag)
            //            {
            //                string dbPassword = reader.GetString(reader.GetOrdinal("Password"));
            //                if (dbPassword == password)
            //                {
            //                    Console.WriteLine("Login sucessfully.");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Username or assword is wrong, please check again.");
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Username is not exisit.");
            //            }
            //        }
            //    }
            #endregion

            #region executescalar
            //using (SqlConnection conn = new SqlConnection(connString))
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = "select count(*) from T_User where UserName = '" + userName + "'" + "and Password='" + password + "'";
            //        int i = Convert.ToInt32(cmd.ExecuteScalar());
            //        if (i > 0)
            //        {
            //            Console.WriteLine("Login sucessfully.");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Username or assword is wrong, please check again.");
            //        }
            //    }
            //}
            #endregion

            #region parameter
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select count(*) from T_User where UserName =@un and password=@pwd";
                    cmd.Parameters.Add(new SqlParameter("un", userName));
                    cmd.Parameters.Add(new SqlParameter("pwd", password));
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    if (i > 0)
                    {
                        Console.WriteLine("Login sucessfully.");
                    }
                    else
                    {
                        Console.WriteLine("Username or assword is wrong, please check again.");
                    }
                }
            }
            
            #endregion

            #region Encapsulation Test

            #region ExecuteNonQuery
            //string sql = "insert T_User(UserName,Password) values(@un,@pwd)";
            //SQLHelper.ExecuteNonQuery(sql, new SqlParameter("un", "tom"), new SqlParameter("pwd", "123456789"));
            #endregion

            #region ExecuteScalar
            string sql = "select count(*) from T_User where UserName =@un and password=@pwd";
            object result = SQLHelper.ExecuteScalar(sql, new SqlParameter("un", "tom"), new SqlParameter("pwd", "123456789"));
            Console.WriteLine(Convert.ToInt32(result));

            object result2 = SQLHelper.ExecuteScalar("select count(*) from T_User");
            Console.WriteLine(Convert.ToInt32(result2));

            #endregion

            #region DataSet
            string sql3 = "select * from T_User";
            DataSet ds = SQLHelper.ExecuteQueryDataSet(sql3);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string name = Convert.ToString(row["UserName"]);
                string pasd = Convert.ToString(row["UserName"]);
                Console.WriteLine(string.Format("Name: {0}, Password: {1}",name, pasd));
            }
            #endregion

            #endregion

            Console.ReadKey();
        }
    }
}
