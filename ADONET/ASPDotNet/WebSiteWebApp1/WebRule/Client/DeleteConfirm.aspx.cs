using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebRule_Client_DeleteConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        labmes.Text = "Delete at" + DateTime.Now;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script type='text/javascript'>alert('click on me')</script>");
        //不会阻塞服务端代码
        int i = 0;
        i++;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //其实写到的是服务器端的
        File.WriteAllText("d:/a.txt", "木马(){dd}");
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(lab.Text);
        i++;
        lab.Text = i.ToString();
    }
}