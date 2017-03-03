<%@ WebHandler Language="C#" Class="Download" %>

using System;
using System.Web;

public class Download : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/PNG";
        context.Response.AddHeader("Content-Disposition", "attachment;filename=haha.png");
        context.Response.WriteFile("meinvsmall.png");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}