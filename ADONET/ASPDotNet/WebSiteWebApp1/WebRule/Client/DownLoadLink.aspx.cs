using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebRule_Client_DownLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            
            //Response.Write("<div id='downloadLink1'><a href='http://www.baidu.com'>点击下载</a></div>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txt.Text == "123")
        {
            HyperLink1.Visible = true;
        }
    }
}