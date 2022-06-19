using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;


public partial class userxiugai : System.Web.UI.Page
{
    SqlConnection sqlconn;
    readonly string strCon = "Data Source=DESKTOP-0QPAQJ0;Database=books;Uid=sa;Pwd=123;";
    string Sdh;
    int x = 0;
    string xiu = "";
    string photoname;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_xiu(object sender, EventArgs e)
    {
        Sdh = Class1.onyou;
        string password = TextBox1.Text.Trim();
        string name = TextBox2.Text.Trim();
        string sig = TextBox3.Text.Trim();
        string sex = RadioButtonList1.SelectedItem.Text;
        string Upa;
        sqlconn = new SqlConnection(strCon);
        sqlconn.Open();
        if (password != "")
        {
            Upa = "update users set users_password ='" + password + "' where users_id = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upa, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if (x > 0)
            {
                xiu = "用户密码" + ",";
                x = 0;
            }
        }
        if (sig != "")
        {
            Upa = "update users set users_name ='" + name + "' where users_id = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upa, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if (x > 0)
            {
                xiu = xiu + "用户签名" + ",";
                x = 0;
            }
        }
        if (name != "")
        {
            Upa = "update users set users_name ='" + name + "' where users_id = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upa, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if (x > 0)
            {
                xiu = xiu + "用户姓名" + ",";
                x = 0;
            }
        }
        if (sex != "")
        {
            Upa = "update users set users_sex ='" + sex + "' where users_id = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upa, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if (x > 0)
            {
                xiu = xiu + "用户性别" + ",";
                x = 0;
            }
        }
        if (FileUpload1.HasFile)
        {
            string photo = FileUpload1.PostedFile.FileName;
            FileInfo fiphoto = new FileInfo(photo);
            photoname = fiphoto.Name;//获取图片名称
            string phototype = fiphoto.Extension;//获取图片类型
            if (File.Exists(phototype))
            {
                File.Delete(phototype);
            }
            if (phototype == ".pnp" || phototype == ".jpg" || phototype == ".gif")
            {
                string imagestr = "image/userImage/";
                string SavePath = Server.MapPath("~/" + imagestr);//保存路径
                string Savefile = SavePath + photoname;
                this.FileUpload1.PostedFile.SaveAs(Savefile);
            }
            Upa = "update users set users_photo ='image/userImage/" + photoname + "' where users_id = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upa, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if (x > 0)
            {
                xiu = xiu + "用户头像" + ",";
                x = 0;
            }
        }
        if (xiu == "")
        {
            Response.Write("<script language=javascript>alert('修改失败！');location='javascript:history.go(-1)';</script>");
            TextBox2.Text = "";
            TextBox1.Text = "";
        }
        else
        {
            Response.Write("<script language=javascript>alert('修改成功！" + xiu + "更新完成');location='javascript:history.go(-1)';</script>");
            TextBox2.Text = "";
            TextBox1.Text = "";
        }
    }

    protected void btn_hui(object sender, EventArgs e)
    {
        Response.Redirect("userinformation.aspx");
    }
}