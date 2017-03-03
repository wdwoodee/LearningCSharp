<%@ WebHandler Language="C#" Class="Picture" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

public class Picture : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/PNG";
        string path = HttpContext.Current.Server.MapPath("meinvsmall.png");
        //string fullpath = context.Server.MapPath("meinvsmall.png");
        using (Bitmap bitmap = new Bitmap(path))
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                //直接打开picture，此处不用操作
                //如果直接访问图片urlreferer就是null,如果直接嵌入到别的网页中的请求，URLreferer就是页面地址
                
                //rulreferrer请求来源
                if (context.Request.UrlReferrer == null)
                {
                    g.Clear(System.Drawing.Color.White);
                    g.DrawString("禁止直接查看图片，请在页面中查看。", new Font("宋体", 10), Brushes.Red, new System.Drawing.PointF(0, 0));
                }
                else if (context.Request.UrlReferrer.Host != "localhost" )
                {
                    g.DrawString("禁止直接查看图片，仅限内部访问查看。", new Font("宋体", 10), Brushes.Red, new System.Drawing.PointF(0, 0));
                }
                else if (context.Request.UserHostAddress == "127.0.0.1")
                {
                    g.Clear(System.Drawing.Color.Blue);
                    g.DrawString("IP禁止", new Font("宋体", 10), Brushes.Red, new System.Drawing.PointF(0, 0));
                }
                g.DrawString("你的IP地址："+ context.Request.UserHostAddress, new Font("宋体", 10), Brushes.Red, new System.Drawing.PointF(0, 0));
            }
            bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}