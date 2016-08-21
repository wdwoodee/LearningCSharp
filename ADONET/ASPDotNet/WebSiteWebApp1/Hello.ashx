<%@ WebHandler Language="C#" Class="Hello" %>

using System;
using System.Web;

public class Hello : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";  //plain txt file
        
        //client提交的内容是以name为key，value为值
        string name = context.Request["UserName"]; //取得用户提交过来的name为UserName的表单值
        string msg = "";
        string ispostback = context.Request["ispostback"];
        if (ispostback == "true")
        {
            context.Response.Write("提交进入");
            msg = name + "你好";
        }
        else
        {
            context.Response.Write("直接进入");
            msg = "";
            name = "";
        }
        
        //通过name是否为空来判断是提交进入还是直接进入的       
        //if (string.IsNullOrEmpty(name))
        //{
        //    context.Response.Write("直接进入");
        //}
        //else
        //{
        //    context.Response.Write("提交进入");
        //}
        //获取文件全路径
        string fullpath = context.Server.MapPath("Hello.html");
        //context.Response.Write(fullpath);
        //读取文件内容
        string content = System.IO.File.ReadAllText(fullpath);
        content = content.Replace("@valule", name);
        content = content.Replace("@msg", msg);
        context.Response.Write(content);
        
        //将表单原封不动的重新写会浏览器
        //@符号，处理多行文本
//        context.Response.Write(@"<form action='Hello.ashx'>
//        Name:<input type='text' name='UserName' value='"+name+@"'/>
//        <input type='submit' value='Login' />
//        </form>");
        //context.Response.Write("Hello World"); //将字符串协会到浏览器
        //context.Response.Write(name);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}