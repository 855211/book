<%@ Page Language="C#" AutoEventWireup="true" CodeFile="denglu.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>登录</title>
    <style type="text/css">
        .style2 {
            height: 32px;
            width: 167px;
        }

        .style3 {
            height: 32px;
            width: 167px;
        }

        .style4 {
            height: 32px;
            width: 395px;
        }

        .style5 {
            width: 395px;
        }

        .style6 {
            width: 167px;
            height: 30px;
        }

        .style7 {
            width: 395px;
            height: 30px;
        }

        .style8 {
            height: 22px;
        }
    </style>
</head>
<body background="image/old/bgp.bmp">
    <div>
        <form id="form1" runat="server" style="font-family: 隶书; font-size: xx-large; font-weight: bold; color: #0000FF;">
            <table style="border: thin solid #0000FF; width: 700px; position: fixed; top: 40%; left: 36%; bottom: 60%; right: 28%;">
                <tr>
                    <td style="width: 1613px; height: 33px">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                            Width="400px">
                            <asp:ListItem Selected="True" Value="0">管理员</asp:ListItem>
                            <asp:ListItem Value="1">用户</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="style2" style="font-size: xx-large">
                        <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"
                            Text="用户名："></asp:Label>
                    </td>
                    <td class="style4" style="font-size: xx-large">
                        <asp:TextBox ID="TextBox1" runat="server" onblur="javascript:checkName();void(0);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3" style="font-size: xx-large">
                        <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"
                            Text="密码："></asp:Label>
                    </td>
                    <td class="style5" style="font-size: xx-large">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" onblur="javascript:checkPassword();void(0);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style9" style="font-size: xx-large" colspan="1">
                        <asp:Label ID="Label5" runat="server" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style8" style="font-size: xx-large" colspan="2">
                        <asp:Label ID="Label1" runat="server" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="font-size: xx-large">
                        <asp:Button ID="Button1" runat="server" Text="登录" Width="93px" OnClick="Button1_Click" />
                    </td>
                    <td class="style7" style="font-size: xx-large">
                        <asp:Button ID="Button2" runat="server" Text="注册" Width="102px" OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
    <marquee>
        欢迎使用个性化图书推荐系统！</marquee>
<%--    <script language="javascript" type="text/javascript" defer="defer">  
        function checkName() {
            var name = document.getElementById( " <%=TextBox1.ClientID %> ");
            document.getElementById(" errorMsg ").style.display = " block ";
            document.getElementById(" errorMsg ").style.color = " red ";
            document.getElementById(" errorMsg ").innerText = Test.CheckUserName(parseInt(id)).value;
        }

        function checkPassword() {
            var age = document.getElementById( " <%=TextBox2.ClientID %> ");
            document.getElementById(" errorMsg1 ").style.display = " block ";
            document.getElementById(" errorMsg1 ").style.color = " red ";
            document.getElementById(" errorMsg1 ").innerText = Test.CheckUserPassword(parseInt(password)).value;

        }
</script>--%>
</body>
</html>
