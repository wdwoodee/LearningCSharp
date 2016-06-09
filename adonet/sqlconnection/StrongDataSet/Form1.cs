using StrongDataSet.DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrongDataSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStrongDS_Click(object sender, EventArgs e)
        {
            T_PersonTableAdapter adapter = new T_PersonTableAdapter();
            StrongDataSet.DataSet.T_PersonDataTable persons = adapter.GetData();
            for (int i = 0; i < persons.Count; i++)
            {
                StrongDataSet.DataSet.T_PersonRow person = persons[i];
                string msg = string.Format("Name: {0}, Age: {1}", person.Name, person.Age);
                MessageBox.Show(msg);
            }
        
        }
    }
}
