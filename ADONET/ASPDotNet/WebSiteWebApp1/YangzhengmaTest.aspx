<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YangzhengmaTest.aspx.cs" Inherits="YangzhengmaTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function randomString(len) {
            len = len || 32;
            var $chars = 'ABCDEFGHJKMNPQRSTWXYZabcdefhijkmnprstwxyz2345678';    /****默认去掉了容易混淆的字符oOLl,9gq,Vv,Uu,I1****/
            var maxPos = $chars.length;
            var pwd = '';
            for (i = 0; i < len; i++) {
                pwd += $chars.charAt(Math.floor(Math.random() * maxPos));
            }
            return pwd;
        }
        //document.write(randomString(8));
</script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--onclick 重新请求验证码-->
        <!--<img src="Yanzhengma.ashx" onclick="this.src='Yanzhengma.ashx?44='+ new Date()"/><br />-->
        <img src="Yanzhengma.ashx" onclick="this.src='Yanzhengma.ashx?44='+ randomString(8)"/><br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        
    </div>
    </form>
</body>
</html>
