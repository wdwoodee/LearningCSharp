using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportImportData
{
    public partial class ImportExportTest : Form
    {
        public ImportExportTest()
        {
            InitializeComponent();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
            /*
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                if (ofdImport.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = File.OpenRead(ofdImport.FileName))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            string strLine = null;
                            while ((strLine = sr.ReadLine()) != null)
                            {
                                string[] strs = strLine.Split('|');
                                string name = strs[0];
                                int age = Convert.ToInt32(strs[1]);
                                using (SqlCommand cmd = conn.CreateCommand())
                                {
                                    cmd.CommandText = "insert into T_Person(Name,Age) valuse(@Name,@Age)";
                                    cmd.Parameters.Add("Name", name);
                                    cmd.Parameters.Add("Age", age);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
               */

            if (ofdImport.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            using (FileStream fs = File.OpenRead(ofdImport.FileName))
            {

                using (StreamReader sr = new StreamReader(fs))
                {
                    //代码优化，只创建一个数据库连接，创建数据库连接是比较耗时的
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "insert into T_Person(Name,Age) values(@Name,@Age)";
                            
                            string strLine = null;
                            while ((strLine = sr.ReadLine()) != null)
                            {
                                string[] strs = strLine.Split('|');
                                string name = strs[0];
                                int age = Convert.ToInt32(strs[1]);
                                cmd.Parameters.Clear();//清除参数，参数不能重复添加，一个while语句中一直使用的是一个sqlcommand对象
                                cmd.Parameters.Add("Name", name);
                                cmd.Parameters.Add("Age", age);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                MessageBox.Show("Import Successfully.");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string sql = "select * from T_Person";
            DataTable dt = DBHelper.ExecuteSQL(sql);
            
            if(dt.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                
                //string localFilePath = "", fileNameExt= "", newFileName= "", FilePath = "";

                sfd.Filter = "txt files(*.txt)|*.txt|xls files(*.xls)|*.xls|All files(*.*)|*.*";
                sfd.FileName = DateTime.Now.ToString("yyyyMMddhhmmss");
                sfd.DefaultExt = "txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //localFilePath = sfd.FileName.ToString();
                    //fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
                    //FilePath =  localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));
                    //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

                    using (FileStream fs = (System.IO.FileStream)sfd.OpenFile())
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string name = dt.Rows[i]["Name"].ToString();
                                string age = dt.Rows[i]["Age"].ToString();
                                sw.WriteLine(name + "|" + age);
                            }
                        }
                    }
                }
                MessageBox.Show("Export Successfully.");
            }
            else
            {
                MessageBox.Show("There is no data in dababase.");
            }
            
            
        }

    }
}
