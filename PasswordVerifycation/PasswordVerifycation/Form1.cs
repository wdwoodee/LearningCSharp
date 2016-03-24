using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordVerifycation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void butModify_Click(object sender, EventArgs e)
        {
            string oldpassword = textBox1.Text;
            string newpassword = textBox2.Text;
            string newpassword2 = textBox3.Text;
            if (oldpassword != "888888")
            {
                MessageBox.Show("Old password error!");
                return;
            }
            if (newpassword != newpassword2)
            {
                MessageBox.Show("Your twice input is not equal!");
                return;
            }
            if (newpassword == oldpassword)
            {
                MessageBox.Show("New password should be not equal to old password!");
                return;
            }
            MessageBox.Show("Congulations! Modify password is ok!");
        }
    }
}
