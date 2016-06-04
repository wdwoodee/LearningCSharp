using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSQL
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void IncErrorTimes()
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\")
                || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = System.IO.Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }
            string connString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand updateCmd = conn.CreateCommand())
                {
                    updateCmd.CommandText = "update T_User Set ErrorTimes=ErrorTimes+1 where Name=@UName";
                    updateCmd.Parameters.Add(new SqlParameter("UName", txtUsername.Text));
                    updateCmd.ExecuteNonQuery();
                }
            }
        }

        private void ResetErrorTimes()
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\")
                || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = System.IO.Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }
            string connString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand updateCmd = conn.CreateCommand())
                {
                    updateCmd.CommandText = "update T_User Set ErrorTimes=0 where Name=@UName";
                    updateCmd.Parameters.Add(new SqlParameter("UName", txtUsername.Text));
                    updateCmd.ExecuteNonQuery();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\")
                || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = System.IO.Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }
            string connString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from T_User where Name=@UserN";
                    cmd.Parameters.Add(new SqlParameter("UserN", txtUsername.Text));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int errorTimes = reader.GetInt32(reader.GetOrdinal("ErrorTimes"));
                            if (errorTimes > 3)
                            {
                                MessageBox.Show("Login more than there time, can't login again.");
                                return;
                            }
                            string dbPassword = reader.GetString(reader.GetOrdinal("Password"));
                            if (dbPassword == txtPassword.Text)
                            {
                                ResetErrorTimes();
                                MessageBox.Show("Login Successfully.");
                            }
                            else
                            {
                                IncErrorTimes();
                                MessageBox.Show("Login Failed, please try again.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("User is not exist.");
                        }
                    }
                }
            }

        }
    }
}
