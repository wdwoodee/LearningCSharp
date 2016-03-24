using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Operator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string str1 = txtOp1.Text;
            string str2 = txtOp2.Text;
            float i1 = Convert.ToInt32(str1);
            float i2 = Convert.ToInt32(str2);
            float result;
            switch (cbOp.SelectedIndex)
            {
                //+
                case 0:
                    result = i1 + i2; 
                    break;
                case 1:
                    result = i1 - i2; 
                    break;
                case 2:
                    result = i1 * i2; 
                    break;
                case 3:
                    if (i2 < 0)
                    {
                        MessageBox.Show("Divisor cannot be zero!");
                        return;
                    }
                    result = i1 / i2; 
                    break;
                default:
                    throw new Exception("Unkonwn error!");

            }
            txtResult.Text = Convert.ToString(result);
        }
    }
}
