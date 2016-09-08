using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResponseObjec_EndTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string q = Request["q"];
        if (q == "1")
        {
            Response.Write("One");
        }
        else if (q == "2")
        {
            //此种是server内部的跳转，页面url不会改变，只发出一个请求，并且该跳转至的页面能够获取到参数
            Server.Transfer("Hello.aspx");
        }
        else if (string.IsNullOrEmpty(q))
        {
            Response.Write("请输入问题");
        }
        else
        {
            //与Transfer刚好相反
            Response.Redirect("Hello.aspx");
            Response.Redirect("http://www.baidu.com");
        }
    }
}