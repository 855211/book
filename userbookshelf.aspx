<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userbookshelf.aspx.cs" Inherits="userbookshelf" %>

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
            <div class="panel-heading">我的书架</div>
            <p style="float: right">图书名称：<asp:TextBox ID="TextBox1" runat="server" ToolTip="请输入图书名称搜索"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" /></p>
            <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="bs_name" AllowPaging="True" PageSize="4" EmptyDataText="无记录" ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="bs_name" DataNavigateUrlFormatString="Bookmation.aspx?bs_name={0}" DataTextField="bs_name" HeaderText="图书名称" />                
                    <asp:BoundField DataField="bs_lei" HeaderText="图书分类" SortExpression="bs_lei" />
                    <asp:BoundField DataField="bs_number" HeaderText="图书评分" SortExpression="bs_number" />
                    <asp:ImageField HeaderText="图书图像" DataImageUrlField="bs_photo" ControlStyle-Height="60px" ControlStyle-Width="40px">
                        <ControlStyle Height="100px" Width="80px"></ControlStyle>
                    </asp:ImageField>
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
