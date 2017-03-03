<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteRow.aspx.cs" Inherits="RequestResponse_DeleteRow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" >
    <input type="text" />
    <input type="hidden" id="Name" name="Name" />
    <div>
    <table>
            <tr><td>Name</td><td>Age</td><td>Operator</td></tr>
            <!--aspx使用超链接时，没有提交隐藏字段ispostback的viewstate-->
            <tr><td>tom</td><td>20</td><td><a href="DeleteRow.aspx?Name=tom">Delete</a>
                <input type="button" value="Delete" onclick="document.getElementById('Name').value = 'tom'; document.getElementById('form1').submit();" />
                <a href="javascript:document.getElementById('Name').value = 'tom'; document.getElementById('form1').submit();">Delete(submit)</a></td></tr>
            <tr><td>jack</td><td>30</td><td><a href="DeleteRow.aspx?Name=jack">Delete</a><input type="button" value="Delete" onclick="document.getElementById('Name').value = 'jack'; document.getElementById('form1').submit();" /></td></tr>
        </table>
    </div>
    </form>
</body>
</html>
