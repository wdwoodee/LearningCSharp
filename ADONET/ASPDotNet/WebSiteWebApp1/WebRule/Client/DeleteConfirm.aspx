<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteConfirm.aspx.cs" Inherits="WebRule_Client_DeleteConfirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete" OnClientClick="return confirm('Are you sure delete?')" />
        <input type="submit" value="Delete2" name="Delete" onclick="" runat="server"/>
        <asp:Label ID="labmes" runat="server" Text="LabelMsg"></asp:Label>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Server alter" OnClick="Button2_Click" />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="中木马" />
        <br />
        <asp:Button ID="btn4" runat="server" OnClick="btn_Click" Text="Inc" />
        <asp:Label ID="lab" runat="server" Text="0"></asp:Label>
        
    </div>
    </form>
</body>
</html>
