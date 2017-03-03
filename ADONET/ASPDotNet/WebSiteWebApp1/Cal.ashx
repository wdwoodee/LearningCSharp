<%@ WebHandler Language="C#" Class="Cal" %>

using System;
using System.Web;

public class Cal : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        string ispostback = context.Request["ispostback"];
        string result="";
        string num1 = "";
        string num2 = "";
        if(ispostback == "true")
        {
            num1 = context.Request["num1"];
            num2 = context.Request["num2"];
            result = (Convert.ToInt32(num1) + Convert.ToInt32((num2))).ToString();
        }
        string fullpath = context.Server.MapPath("Cal.html");
        string content = System.IO.File.ReadAllText(fullpath);
        content = content.Replace("@result", result).Replace("@num1", num1).Replace("@num2", num2);
        context.Response.Write(content);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}