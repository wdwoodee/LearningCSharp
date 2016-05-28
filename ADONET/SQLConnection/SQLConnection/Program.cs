using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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

            Console.WriteLine("Please input username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Please input password:");
            string password = Console.ReadLine();

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

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select count(*) from T_User where UserName = '" + userName + "'" + "and Password='" + password + "'";
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

            Console.ReadKey();
        }
    }
}
