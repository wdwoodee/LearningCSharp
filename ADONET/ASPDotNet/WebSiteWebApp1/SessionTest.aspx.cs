using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SessionTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["MySessionId"] == null)
        {
            string sessionId = Guid.NewGuid().ToString();
            Response.SetCookie(new HttpCookie("MySessionId", sessionId));
        }
    }
    protected void btnSetSession_Click(object sender, EventArgs e)
    {
        string sessionId = Request.Cookies["MySessionId"].Value;
        IDictionary<string, object> session = SessionMgr.GetSession(sessionId);
        session["服务器端的数据"] = "123456789" + DateTime.Now.ToString();//向和这个客户端关联的服务器添加键值对
        session["name"] = "dddd";
    }
    protected void btnGetSession_Click(object sender, EventArgs e)
    {
        string sessionId = Request.Cookies["MySessionId"].Value;
        IDictionary<string, object> session = SessionMgr.GetSession(sessionId);
        if (session.Count > 0)
        {
            dsiplaySession.Text = Convert.ToString(session["服务器端的数据"]) + Convert.ToString(session["name"]);
        }
        else
            dsiplaySession.Text = "None session";
        
    }
}