<%@ WebHandler Language="C#" Class="IncVal2" %>

using System;
using System.Web;

public class IncVal2 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string ispostback = context.Request["ispostback"];
        string val = "0";
        
        //只有text，textarea, select等几种element的value才能提交到服务器
        if (ispostback == "true")
        {
            val = context.Request["num1"];
            int i = Convert.ToInt32(val);
            i++;
            val = i.ToString();
        }
        string path = context.Server.MapPath("IncVal2.html");
        string content = System.IO.File.ReadAllText(path);
        content = content.Replace("@value", val);
        context.Response.Write(content);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}