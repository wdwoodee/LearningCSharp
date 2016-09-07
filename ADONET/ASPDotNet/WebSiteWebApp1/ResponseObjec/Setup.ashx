<%@ WebHandler Language="C#" Class="Setup" %>

using System;
using System.Web;

public class Setup : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        for (int i = 0; i < 20; i++)
        {
            System.Threading.Thread.Sleep(500);
            context.Response.Write("第" + i + "步执行完毕！<br/>");
            if (i == 10)
            {
                //清楚旧的缓存
                context.Response.Clear(); 
            }
            //实施把缓存写到浏览器
            //context.Response.Flush();
        }
        //context.Response.Write("Hello World");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}