using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YangzhengmaTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string rightYZM = Convert.ToString(Session["code"]);
        if (rightYZM == TextBox1.Text)
        {
            Context.Response.Write("Right");
        }
        else
        {
            Context.Response.Write("wrong");
        }
    }
}