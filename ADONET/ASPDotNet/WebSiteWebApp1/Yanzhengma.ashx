<%@ WebHandler Language="C#" Class="Yanzhengma" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
public class Yanzhengma : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/JPEG";
        using (Bitmap bitmap = new Bitmap(130,40))
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawString("验证码123", new System.Drawing.Font("宋体", 20), System.Drawing.Brushes.Red, new System.Drawing.PointF(0,0));
                Pen pen = (Pen)Pens.Yellow.Clone();
                pen.Width = 3;
                g.DrawEllipse(Pens.White, new Rectangle(50, 20, 20, 10));
                g.DrawEllipse(pen, new Rectangle(10, 10, 10, 10));
                bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            } 
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}