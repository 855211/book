<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bookmanager.aspx.cs" Inherits="Default5" %>

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
            <div class="panel-heading">图书管理</div>
            <p>
                <asp:Button ID="Button2" runat="server" Text="添加" OnClick="Button2_Click" />
            </p>
            <p style="float: right">图书名称：<asp:TextBox ID="TextBox1" runat="server" ToolTip="请输入图书名称搜索"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" /></p>
            <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="bk_name" AllowPaging="True" PageSize="4" EmptyDataText="无记录" ShowHeaderWhenEmpty="True" OnRowDataBound="ListView_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="bk_name" DataNavigateUrlFormatString="Bookmation.aspx?bk_name={0}" DataTextField="bk_name" HeaderText="图书名称" />                
                    <asp:BoundField DataField="bk_author" ItemStyle-CssClass="contents" HeaderText="图书作者" SortExpression="bk_author" />
                    <asp:BoundField DataField="bk_synopsis" HeaderText="图书简介" />
                    <asp:BoundField DataField="bk_lei" HeaderText="图书分类" SortExpression="bk_lei" />
                    <asp:BoundField DataField="bk_time" HeaderText="图书完成日期" SortExpression="bk_time" />
                    <asp:HyperLinkField DataNavigateUrlFields="bk_name" DataNavigateUrlFormatString="View.aspx?bk_name={0}" HeaderText="图书内容" Text="图书内容" />
                    <asp:ImageField HeaderText="图书图像" DataImageUrlField="bk_photo" ControlStyle-Height="60px" ControlStyle-Width="40px">
                        <ControlStyle Height="100px" Width="80px"></ControlStyle>
                    </asp:ImageField>
                    <asp:TemplateField ControlStyle-Width="30px">
                        <ItemTemplate>
                            <asp:LinkButton ID="LBtn_Name" runat="server" PostBackUrl='<%# Eval("bk_name", "bookxiugai.aspx?bk_name={0}") %>' Text="修改"></asp:LinkButton>
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
