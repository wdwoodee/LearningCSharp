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
            StrongDataSet.DataSet.T_PersonDataTable personTable = adapter.GetData();
            for (int i = 0; i < personTable.Count; i++)
            {
                StrongDataSet.DataSet.T_PersonRow person = personTable[i];
                string msg = string.Format("Name: {0}, Age: {1}", person.Name, person.Age);
                MessageBox.Show(msg);
            }
            //personTable[0].Name = "aaa";
            //adapter.Update(personTable);
            //adapter.Insert("xiaoli", 50);
        }
    }
}
