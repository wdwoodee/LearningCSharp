<%@ WebHandler Language="C#" Class="DeleteRow" %>

using System;
using System.Web;

public class DeleteRow : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        string name = context.Request["Name"];
        
        context.Response.Write(name + " has been deleted.");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}