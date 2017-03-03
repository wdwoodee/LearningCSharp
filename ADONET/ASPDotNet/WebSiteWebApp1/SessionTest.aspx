<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionTest.aspx.cs" Inherits="SessionTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnSetSession" runat="server" Text="SetSession" OnClick="btnSetSession_Click" />
        <br />
        <asp:Button ID="btnGetSession" runat="server" Text="GetSession" OnClick="btnGetSession_Click" />
        <asp:TextBox ID="dsiplaySession" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
