<%@ Page Language="C#" AutoEventWireup="true" CodeFile="booktianjia.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="bootstrap-3.4.1/bootstrap-3.4.1/dist/css/bootstrap.css" rel="stylesheet" />
    <script src="bootstrap-3.4.1/bootstrap-3.4.1/dist/js/bootstrap.js"></script>
    <title></title>
    <style type="text/css">
        .stye1 {
            width: 201px;
        }
        .stye2 {
            width: 323px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel-info">
            <div class="panel-heading">添加图书信息</div>
                <table class="table table-bordered">
                    <tr>
                        <td class="stye2">图书名称：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="stye2">图书作者：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="style1">图书简介：<asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>图书完成日期：<input type="date" name="Input" min="1900-01-01" max="202-01-01" /></td>
                    </tr>
                    <tr>
                        <td class="stye2">上传图书内容：<asp:FileUpload ID="FileUpload2" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="stye2">上传图像：<asp:FileUpload ID="FileUpload1" runat="server" /></td>
                        </tr>
                    <tr>
                        <td class="stye1">图书分类：<asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>哲理类</asp:ListItem>
                            <asp:ListItem>小说类</asp:ListItem>
                            <asp:ListItem>文学类</asp:ListItem>
                            <asp:ListItem>历史类</asp:ListItem>
                        </asp:DropDownList></td>
                        <td colspan="3">
                            <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="btn btn-default" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnEdit" runat="server" Text="返回" CssClass="btn btn-default" OnClick="btnEdit_Click" />
                        </td>
                    </tr>
                </table>
        </div>
    </form>
</body>
</html>
