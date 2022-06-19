<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userxiugai.aspx.cs" Inherits="userxiugai" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="bootstrap-3.4.1/bootstrap-3.4.1/dist/css/bootstrap.css" rel="stylesheet" />
    <script src="bootstrap-3.4.1/bootstrap-3.4.1/dist/js/bootstrap.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel-info">
            <div class="panel-heading">修改个人信息</div>
            <table class="table table-bordered">
                <tr>
                    <td>修改头像：<asp:FileUpload ID="FileUpload1" runat="server" /></td>
                </tr>
                <tr>
                    <td>修改名称：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>修改性别：<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                        Width="400px">
                        <asp:ListItem Value="0" Selected="True">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>修改签名：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>修改密码：<asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
            </table>
            <asp:Button ID="Button1" Text="修改" OnClick="btn_xiu" runat="server" />
            <asp:Button ID="Button2" Text="返回" OnClick="btn_hui" runat="server" />
        </div>
    </form>
</body>
</html>
