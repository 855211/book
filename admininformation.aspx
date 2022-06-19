<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admininformation.aspx.cs" Inherits="admininformation" %>

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
            <div class="panel-heading">管理员个人信息</div>
            <table class="table table-bordered">
                <tr>
                    <td>管理员头像：<img id="image" runat="server" src="image/adminImage/780.jpg" /></td>
                </tr>
                <tr>
                    <td>管理员姓名：<asp:Label ID="label1" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>管理员性别：<asp:Label ID="label2" runat="server"></asp:Label></td>
                </tr>
            </table>
            <asp:Button ID="Button1" Text="修改个人信息" OnClick="btn_xiu" runat="server" />
        </div>
    </form>
</body>
</html>
