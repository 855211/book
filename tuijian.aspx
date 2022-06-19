<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tuijian.aspx.cs" Inherits="tuijian" %>

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
            <div class="panel-heading">推荐图书</div>
            <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="bs_name" AllowPaging="True" PageSize="4" EmptyDataText="无记录" ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="bs_name" DataNavigateUrlFormatString="Bookmation.aspx?bs_name={0}" DataTextField="bs_name" HeaderText="图书名称" />                
                    <asp:BoundField DataField="bs_lei" HeaderText="图书分类" SortExpression="bs_lei" />
                    <asp:ImageField HeaderText="图书图像" DataImageUrlField="bs_photo" ControlStyle-Height="60px" ControlStyle-Width="40px">
                        <ControlStyle Height="100px" Width="80px"></ControlStyle>
                    </asp:ImageField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
