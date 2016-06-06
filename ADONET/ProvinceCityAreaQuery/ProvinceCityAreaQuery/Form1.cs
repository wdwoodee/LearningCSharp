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

namespace ProvinceCityAreaQuery
{
    public partial class Form1 : Form
    {
        string connString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;           
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Person p1 = new Person();
            p1.name = "tom";
            p1.age = 20;
            //MessageBox.Show(p1.ToString());

            Person p2 = new Person();
            p2.name = "jim";
            p2.age = 22;

            cmbProvince.Items.Add(p1);
            cmbProvince.Items.Add(p2);

            return;
             */
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from province";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProvinceItem item = new ProvinceItem();
                            item.provinceName = reader.GetString(reader.GetOrdinal("name"));
                            item.provinceCode = reader.GetString(reader.GetOrdinal("code"));
                            cmbProvince.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProvinceItem item = (ProvinceItem)cmbProvince.SelectedItem;
            string proCode = item.provinceCode;

            cmbCity.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from city where provincecode=@provinceCode";
                    cmd.Parameters.Add(new SqlParameter("provinceCode", proCode));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CityItem cityItem = new CityItem();
                            cityItem.cityName = reader.GetString(reader.GetOrdinal("name"));
                            cityItem.cityCode = reader.GetString(reader.GetOrdinal("code"));
                            cmbCity.Items.Add(cityItem);
                        }
                    }
                }
            }
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityItem item = (CityItem)cmbCity.SelectedItem;
            string cityCode = item.cityCode;

            cmbArea.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from area where citycode=@cityCode";
                    cmd.Parameters.Add(new SqlParameter("cityCode", cityCode));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AreaItem areaItem = new AreaItem();
                            areaItem.areaName = reader.GetString(reader.GetOrdinal("name"));
                            areaItem.code = reader.GetString(reader.GetOrdinal("code"));
                            cmbArea.Items.Add(areaItem);
                        }
                    }
                }
            }
        }
    }

    public class ProvinceItem
    {
        public int id { get; set; }
        public string provinceName { get; set; }
        public string provinceCode { get; set; }
    }

    public class CityItem
    {
        public int id { get; set; }
        public string cityName {get;set;}
        public  string cityCode{get;set;}
    }

    public class AreaItem
    {
        public int id { get; set; }
        public string areaName { get; set; }
        public string code { get; set; }
    }

    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
