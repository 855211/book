using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    SqlConnection sqlconm;
    readonly string strCon = "Data Source=DESKTOP-0QPAQJ0;Database=books;Uid=sa;Pwd=123;";
    string photoname = "";
    string contentname = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var name = TextBox2.Text;
        var autor = TextBox3.Text;
        var synopsis = TextBox5.Text;
        var time = Request.Form["Input"];
        var lei = DropDownList2.SelectedValue;
        string verystr = "select * from book where bk_name='" + name + "'";
        sqlconm = new SqlConnection(strCon);
        SqlDataAdapter myda = new SqlDataAdapter();
        DataSet myds = new DataSet();
        sqlconm.Open();
        myda.SelectCommand = new SqlCommand(verystr, sqlconm);
        myds.Clear();
        myda.Fill(myds);
        if (TextBox2.Text == "")
        {
            Response.Write("<script language=javascript>alert('请重新输入数据！');location='javascript:history.go(-1)';</script>");
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox5.Text = "";
            return;
        }
        if (myds.Tables[0].Rows.Count != 0)
        {
            Response.Write("<script language=javascript>alert('图书已存在！');location='javascript:history.go(-1)';</script>");
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox5.Text = "";
            sqlconm.Close();
            return;
        }
        sqlconm.Close();
        //上传图片
        if (FileUpload1.HasFile)
        {
            string photo = FileUpload1.PostedFile.FileName;
            FileInfo fiphoto = new FileInfo(photo);
            photoname = fiphoto.Name;//获取图片名称
            string phototype = fiphoto.Extension;//获取图片类型
            if (phototype == ".pnp" || phototype == ".jpg" || phototype == ".gif")
            {
                string imagestr = "image/bookImage/";
                string SavePath = Server.MapPath("~/" + imagestr);//保存路径
                string Savefile = SavePath + photoname;
                this.FileUpload1.PostedFile.SaveAs(Savefile);
            }
        }
        //创建文件夹
        string dirPath = @"C:\Users\王哲\Documents\Visual Studio 2010\WebSites\WebSite3\image\bookcontent" + @"\" + @name;
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        //上传文件
        if (FileUpload2.HasFile)
        {
            string content = FileUpload2.PostedFile.FileName;
            FileInfo ficontent = new FileInfo(content);
            contentname = ficontent.Name;
            string contenttype = ficontent.Extension;
            if (contenttype == ".txt" || contenttype == ".jar" || contenttype == ".zip")
            {
                string contentstr = "image/bookcontent/"+"name"+"/";
                string SavePath = Server.MapPath("~/" + contentstr);
                string savefile = SavePath + contentname;
                this.FileUpload2.PostedFile.SaveAs(savefile);
            }
        }
        var CommandString = "insert into book(bk_name,bk_author,bk_synopsis,bk_time,bk_content,bk_photo,bk_lei) values('" + name + "','" + autor + "','" + synopsis + "','" + time + "','image/bookcontent/" + name + "','image/bookImage/" + photoname + "','" + lei + "');";
        sqlconm = new SqlConnection(strCon);
        SqlCommand cmd = new SqlCommand(CommandString, sqlconm);
        sqlconm.Open();
        int a = cmd.ExecuteNonQuery();
        sqlconm.Close();
        if (a > 0)
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox5.Text = "";
            Response.Write("<script language=javascript>alert('添加成功！');location='javascript:history.go(-1)';</script>");
        }
        else
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox5.Text = "";
            Response.Write("<script language=javascript>alert('添加失败，请重新输入数据！');location='javascript:history.go(-1)';</script>"); 
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("bookmanager.aspx");
    }
}