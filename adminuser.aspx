<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminuser.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="bootstrap-3.4.1/bootstrap-3.4.1/dist/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="bootstrap-3.4.1/bootstrap-3.4.1/dist/js/bootstrap.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel-info">
            <div class="panel-heading">用户管理</div>
            <p style="float: right">用户名称：<asp:TextBox ID="TextBox1" runat="server" ToolTip="请输入用户名称搜索"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" /></p>
            <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="users_id" AllowPaging="True" PageSize="4" EmptyDataText="无记录"
                ShowHeaderWhenEmpty="True" OnRowDataBound="ListView_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:ImageField HeaderText="用户头像" DataImageUrlField="users_photo" ControlStyle-Height="60px" ControlStyle-Width="40px">
                        <ControlStyle Height="100px" Width="80px"></ControlStyle>
                    </asp:ImageField>
                    <asp:BoundField DataField="users_id" HeaderText="用户账户" SortExpression="users_id" ReadOnly="True" />
                    <asp:BoundField DataField="users_password" ItemStyle-CssClass="contents" HeaderText="用户密码" ReadOnly="true" />
                    <asp:BoundField DataField="users_sex" HeaderText="用户性别" />
                    <asp:BoundField DataField="users_name" HeaderText="用户名称" SortExpression="users_sex" />
                    <asp:BoundField DataField="users_sig" HeaderText="用户签名" />
                    <asp:TemplateField ControlStyle-Width="30px">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('您确认删除该记录吗?');" Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle Width="30px"></ControlStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
