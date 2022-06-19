<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="feedback" %>

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
            <div class="panel-heading">反馈信息管理</div>
            <p style="float: right">反馈人：<asp:TextBox ID="TextBox1" runat="server" ToolTip="请输入反馈人搜索"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" /></p>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False"
                DataKeyNames="id" AllowPaging="True" PageSize="4" EmptyDataText="无记录" ShowHeaderWhenEmpty="True" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="fb_name" HeaderText="反馈人" ReadOnly="true"/>
                    <asp:BoundField DataField="fb_information" HeaderText="反馈信息" ReadOnly="true" />
                    <asp:BoundField DataField="fb_time" HeaderText="反馈时间" ReadOnly="true" />
                    <asp:BoundField DataField="fb_informations" HeaderText="回复反馈信息" />
                    <asp:BoundField HeaderText="回复反馈时间" DataField="fb_times" ReadOnly="true" />
                    <asp:CommandField ShowEditButton="true" EditText="回复" />
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
