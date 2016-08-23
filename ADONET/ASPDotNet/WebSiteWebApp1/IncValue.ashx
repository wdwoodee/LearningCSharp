<%@ WebHandler Language="C#" Class="IncValue" %>

using System;
using System.Web;

public class IncValue : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //IncValue.html是模板，是不允许用户访问的，应当把incvalue.asxh设为起始页
        context.Response.ContentType = "text/html";

        string numb = context.Request["number"];//通过表单得到的数据都是string类型的
        string ispostback = context.Request["ispostback"];
        if (ispostback == "true") //说明是通过点击自增button进入的，需要把当前数据自增
        {
            int i = Convert.ToInt32(numb);
            i++;
            numb = i.ToString();
        }
        else
        {
            numb = "0";
        }

        string fullPath = context.Server.MapPath("IncValue.html");
        string content = System.IO.File.ReadAllText(fullPath);
        content = content.Replace("@value", numb);
        context.Response.Write(content);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}