using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebFormInc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = "0";//页面直接进入的时候赋值为0
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(Label1.Text);
        i++;
        Label1.Text = i.ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(TextBox1.Text);
        i++;
        TextBox1.Text = i.ToString();
        TextBox1.Width = new Unit(TextBox1.Width.Value + 10);
    }
}