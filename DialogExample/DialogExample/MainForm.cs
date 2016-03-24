using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DialogExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogForm dialogForm = new DialogForm();
           // dialogForm.ShowDialog()调用了dialogform
            DialogResult dia = dialogForm.ShowDialog();
            //if (dialogForm.ShowDialog() == DialogResult.OK) //判断返回值是不是ok
            if(dia == DialogResult.OK)
            {
                labelUserName.Text = dialogForm.UserName;
                labelUserAge.Text = dialogForm.UserAge.ToString();
            }
            //if (dialogForm.ShowDialog() == DialogResult.Cancel)
            //else
            if(dia == DialogResult.Cancel)
            {
                //labelUserName.Text = "You clicked the\"CancelButton\"";
                labelUserName.Text = dialogForm.UserName;
            }
            dialogForm.Dispose();
        }
    }
}
