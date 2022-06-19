<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bookmation.aspx.cs" Inherits="Bookmation" %>

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
            <div class="panel-heading">图书信息</div>
            <table class="table table-bordered">
                <tr>
                    <td>
                        <img id="image" runat="server" src="image/adminImage/780.jpg" width="250" height="300" /></td>
                </tr>
                <tr>
                    <td>图书名称：<asp:Label ID="label1" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>作者：<asp:Label ID="label2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>简介：<asp:Label ID="label3" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>图书分类：<asp:Label ID="label4" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>完成时间：<asp:Label ID="label5" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>图书评分：<select ID="score" runat="server">
                        <option>0</option>
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                        <option>6</option>
                        <option>7</option>
                        <option>8</option>
                        <option>9</option>
                        <option>10</option>
                    </select>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提交分数"/>
                    </td>
                </tr>
            </table>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="收藏" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" />
        </div>
    </form>
</body>
</html>
