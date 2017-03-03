using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Session版自增 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //每次服务器处理，pageload都会执行
        if (!IsPostBack) //直接进入的才赋初值
        {
            //ASP自带的session处理
            Session["Value"] = 0;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int v = Convert.ToInt32(Session["Value"]);
        v++;
        Session["Value"] = v;
        TextBox1.Text = v.ToString();
    }
}