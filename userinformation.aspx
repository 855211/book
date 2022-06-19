<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userinformation.aspx.cs" Inherits="userxinxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="bootstrap-3.4.1/bootstrap-3.4.1/dist/css/bootstrap.css" rel="stylesheet" />
    <script src="bootstrap-3.4.1/bootstrap-3.4.1/dist/js/bootstrap.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel-info">
            <div class="panel-heading">用户个人信息</div>
            <table class="table table-bordered">
                <tr>
                    <td>用户头像：<img id="image" runat="server" src="image/adminImage/780.jpg" /></td>
                </tr>
                <tr>
                    <td>用户姓名：<asp:Label ID="label1" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>用户性别：<asp:Label ID="label2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>个性签名：<asp:Label ID="label3" runat="server"></asp:Label></td>
                </tr>
            </table>
            <asp:Button ID="Button1" Text="修改个人信息" OnClick="btn_xiu" runat="server" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button2" Text="反馈信息" OnClick="btn_fan" runat="server" />
        </div>
    </form>
</body>
</html>
