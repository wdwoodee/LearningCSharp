using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebRule_Client_Client校验不可信 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //客户端校验不安全，http请求可以修改，并且禁用js也有影响

        string jine = TextBox1.Text.Trim();
        int result;
        if (isNumbericReg(jine, out result))
        {
            //string tt = "<script>alert('匹配成功，转换后的整数为" + result + "')</script>";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "", tt);
            //Response.Write("<script>alert('匹配成功，转换后的整数为" + result + "')</script>");
            Label1.Text = "取款成功，金额： " + jine;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请输入数字2！')</script>");
        }
    }

    protected bool isNumberic(string message, out int result)
    {
        //判断是否为整数字符串
        //是的话则将其转换为数字并将其设为out类型的输出值、返回true, 否则为false
        result = -1;   //result 定义为out 用来输出值
        try
        {
            //当数字字符串的为是少于4时，以下三种都可以转换，任选一种
            //如果位数超过4的话，请选用Convert.ToInt32() 和int.Parse()

            //result = int.Parse(message);
            //result = Convert.ToInt16(message);
            result = Convert.ToInt32(message);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected bool isNumbericReg(string message, out int result)
    {
        System.Text.RegularExpressions.Regex rex =
        new System.Text.RegularExpressions.Regex(@"^\d+$");
        result = -1;
        if (!String.IsNullOrEmpty(message) && rex.IsMatch(message))
        {
            result = int.Parse(message);
            return true;
        }
        else
            return false;
    }
}