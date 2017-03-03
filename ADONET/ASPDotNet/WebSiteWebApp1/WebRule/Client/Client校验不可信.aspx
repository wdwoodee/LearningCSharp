<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Client校验不可信.aspx.cs" Inherits="WebRule_Client_Client校验不可信" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="取款" OnClientClick="var i = document.getElementById('TextBox1').value; if(isNaN(i)){alert('请输入数字'); return false;} else if(parseInt(i)>100){alert('金额不能大于100');return false;}" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    
    </div>
    </form>
</body>
</html>
