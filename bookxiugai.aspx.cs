using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

public partial class bookxiugai : System.Web.UI.Page
{
    SqlConnection sqlconn;
    readonly string strCon = "Data Source=DESKTOP-0QPAQJ0;Database=books;Uid=sa;Pwd=123;";
    public string photoname = "";
    public string contentname = "";
    public string photoPath = @"C:\Users\王哲\Documents\Visual Studio 2010\WebSites\WebSite3\";
    public string contentPath = @"C:\Users\王哲\Documents\Visual Studio 2010\WebSites\WebSite3\";
    public string Sdh;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Sdh = Request.QueryString["bk_name"];
            string sqlstr = "select * from book where bk_name='" + Sdh + "'";
            sqlconn = new SqlConnection(strCon);
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlconn);
            DataSet myds = new DataSet();
            myds.Clear();
            sqlconn.Open();
            myda.Fill(myds);
            TextBox1.Text = myds.Tables[0].Rows[0][1].ToString();
            photoPath = photoPath + @myds.Tables[0].Rows[0][7].ToString();
            contentPath = contentPath + @myds.Tables[0].Rows[0][6].ToString();
            sqlconn.Close();
        }
    }

    protected void btnGai_Click(object sender, EventArgs e)
    {
        Sdh = Request.QueryString["bk_name"];
        var autor = TextBox2.Text;
        var synopsis = TextBox3.Text;
        var time = Request.Form["Input"];
        var lei = DropDownList1.SelectedValue;
        var xiu = "";
        int x = 0;
        sqlconn = new SqlConnection(strCon);
        sqlconn.Open();
        string Upbook;
        if (autor != "")
        {
            Upbook = "update book set bk_author ='" + autor + "' where bk_name = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upbook, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if(x>0)
            {
                xiu = "图书作者" + ",";
                x = 0;
            }
        }
        if (synopsis != "")
        {
            Upbook = "update book set bk_synopsis ='" + synopsis + "' where bk_name = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upbook, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if (x > 0)
            {
                xiu = xiu + "图书简介" + ",";
                x = 0;
            }
        }
        if (time != "")
        {
            Upbook = "update book set bk_time ='" + time + "' where bk_name = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upbook, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if (x > 0)
            {
                xiu = xiu + "图书完成日期" + ",";
                x = 0;
            }
        }
        if (lei != "")
        {
            Upbook = "update book set bk_lei ='" + lei + "' where bk_name = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upbook, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if (x > 0)
            {
                xiu = xiu + "图书分类" + ",";
                x = 0;
            }
        }
        if (FileUpload1.HasFile)
        {
            string photo = FileUpload1.PostedFile.FileName;
            FileInfo fiphoto = new FileInfo(photo);
            photoname = fiphoto.Name;//获取图片名称
            string phototype = fiphoto.Extension;//获取图片类型
            if(File.Exists(phototype))
            {
                File.Delete(phototype);
            }
            if (phototype == ".pnp" || phototype == ".jpg" || phototype == ".gif")
            {
                string imagestr = "image/bookImage/";
                string SavePath = Server.MapPath("~/" + imagestr);//保存路径
                string Savefile = SavePath + photoname;
                this.FileUpload1.PostedFile.SaveAs(Savefile);
            }
            Upbook = "update book set bk_photo ='image/bookImage/" + photoname + "' where bk_name = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upbook, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if (x > 0)
            {
                xiu = xiu + "图书图像" + ",";
                x = 0;
            }
        }
        if(FileUpload2.HasFile)
        {
            string content = FileUpload2.PostedFile.FileName;
            FileInfo ficontent = new FileInfo(content);
            contentname = ficontent.Name;
            string contenttype = ficontent.Extension;
            contentPath = contentPath + "/" + contentname;
            if(File.Exists(contentPath))
            {
                File.Delete(contentPath);
            }
            if (contenttype == ".txt" || contenttype == ".jar" || contenttype == ".zip")
            {
                string contentstr = "image/bookcontent/" + "name" + "/";
                string SavePath = Server.MapPath("~/" + contentstr);
                string savefile = SavePath + contentname;
                this.FileUpload2.PostedFile.SaveAs(savefile);
            }
            Upbook = "update book set bk_content ='image/bookcontent/" + Sdh + "' where bk_name = '" + Sdh + "'";
            SqlCommand sqlComm = new SqlCommand(Upbook, sqlconn);
            x = sqlComm.ExecuteNonQuery();
            if (x > 0)
            {
                xiu = xiu + "图书内容" + ",";
                x = 0;
            }
        }
        if(xiu == "")
        {
            Response.Write("<script language=javascript>alert('修改失败，请重新输入数据！');location='javascript:history.go(-1)';</script>");
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
        else
        {
            Response.Write("<script language=javascript>alert('修改成功！" + xiu + "更新完成');location='javascript:history.go(-1)';</script>");
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("bookmanager.aspx");
    }
}