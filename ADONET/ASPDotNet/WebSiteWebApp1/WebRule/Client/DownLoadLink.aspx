<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownLoadLink.aspx.cs" Inherits="WebRule_Client_DownLink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

        //按enter键直接触发了向服务器提交form，返回的code没有对downloadLink1做display设置，所以先显示一下后消失
        function enter(op) {
            if (event.keyCode == 13) {
                //alert('Enter');
                IsPwdRight();
            }
            else {
                //alert("is not enter");
                return false;
            }

        }
        function IsPwdRight(){
            var pwd = document.getElementById('pwd1').value;
            if (pwd == '111') {
                document.getElementById('downloadLink1').style.display = '';
            }
            else {
                alert('123'); return false;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" id="pwd1" onkeypress="enter(this)"/><input type="button" value="Login" onclick="IsPwdRight()" />
            <br />
            <div id="downloadLink1" style="display: none"><a href="http://www.baidu.com">点击下载</a></div>
            <br />
            <asp:TextBox ID="txt" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" Visible="False" NavigateUrl="http://www.baidu.com">Download</asp:HyperLink>
        </div>
    </form>
</body>
</html>
