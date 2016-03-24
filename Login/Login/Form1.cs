using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        private int errorTime = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usernmae = textBox1.Text;
            string password = textBox2.Text;
            if (usernmae.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "888888")
            {
                MessageBox.Show("Login success!");
            }
            else
            {
                errorTime++;
                if (errorTime > 3)
                {
                    MessageBox.Show("Error more than 3 times, the application will exit later.");
                    Application.Exit();
                }

                MessageBox.Show("Login error!");

            }
        }
    }
}
