using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Class1 logobj = new Class1();
    //登录
    protected void Button1_Click(object sender, EventArgs e)
    {
        logobj.Conn("DESKTOP-0QPAQJ0", "sa", "123", "books");
        string identity = RadioButtonList1.SelectedItem.Text;
        if (identity == "用户")
        {
            int flag = logobj.Verifylogin1(TextBox1.Text, TextBox2.Text);
            if (flag == 1)
            {
                Class1.onyou = TextBox1.Text;
                Response.Redirect("main.htm");
               
            }
            else
            {
                Label1.Text = "登录信息不正确!";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox1.Focus();
            }

        }
        else
        {
            int flag = logobj.Verifylogin(TextBox1.Text, TextBox2.Text);
            if (flag == 1)
            {
                Class1.onyou = TextBox1.Text;
                Response.Redirect("mainadmin.htm");
                
            }
            else
            {
                Label1.Text = "登录信息不正确!";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox1.Focus();
            }
        }
    }
    //关闭
    protected void Button2_Click(object sender, EventArgs e)
    {
        logobj.Conn("DESKTOP-0QPAQJ0", "sa", "123", "books");
        logobj.Sname = TextBox1.Text;
        logobj.Ssex = TextBox2.Text;
        //logobj.conn();
        string identity = RadioButtonList1.SelectedItem.Text;
        if (identity == "用户")
        {
            int flag = logobj.Inststu1(TextBox1.Text, TextBox2.Text);
            if (flag == 0)
            {
                Response.Write("<script language=javascript>alert('注册成功！');location='javascript:history.go(-1)';</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('注册失败！用户名"+TextBox1.Text+"已存在');location='javascript:history.go(-1)';</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox1.Focus();
            }
        }
        else
        {
            int flag = logobj.Inststu(TextBox1.Text, TextBox2.Text);
            if (flag == 0)
            {
                Response.Write("<script language=javascript>alert('注册成功！');location='javascript:history.go(-1)';</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('注册失败！');location='javascript:history.go(-1)';</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox1.Focus();
            }
        }
    }
}