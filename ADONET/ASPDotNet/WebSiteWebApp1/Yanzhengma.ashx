<%@ WebHandler Language="C#" Class="Yanzhengma" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

//在ashx中使用session，就要实现IRequiresSessionState
public class Yanzhengma : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/JPEG";


        //生成图片
        using (Bitmap bitmap = new Bitmap(150, 40))
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                /*
                g.DrawString("验证码123", new System.Drawing.Font("宋体", 20), System.Drawing.Brushes.Red, new System.Drawing.PointF(0,0));
                Pen pen = (Pen)Pens.Yellow.Clone();
                pen.Width = 3;
                g.DrawEllipse(Pens.White, new Rectangle(50, 20, 20, 10));
                g.DrawEllipse(pen, new Rectangle(10, 10, 10, 10));
                bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                 */
                Random rand = new Random();
                int code = rand.Next();
                
                string strCode = code.ToString();
                if (strCode.Length >= 5)
                {
                    strCode = strCode.Substring(0, 5); 
                }
                HttpContext.Current.Session["code"] = strCode;
                g.DrawString(strCode, new Font("宋体", 20), Brushes.Red, new System.Drawing.PointF(0, 0));
                bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            }
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