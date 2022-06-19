using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Bookmation : System.Web.UI.Page
{
    SqlConnection sqlcon;
    SqlCommand sqlcom;
    readonly string strCon = "Data Source=DESKTOP-0QPAQJ0;Database=books;Uid=sa;Pwd=123;";
    public string Sdh;
    static string photoPath;
    static string lei;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        Sdh = Request.QueryString["bk_name"];
        string sqlstr = "select * from book where bk_name='" + Sdh + "'";
        sqlcon = new SqlConnection(strCon);
        SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet myds = new DataSet();
        myds.Clear();
        sqlcon.Open();
        myda.Fill(myds);
        label1.Text = myds.Tables[0].Rows[0][1].ToString();
        label2.Text = myds.Tables[0].Rows[0][2].ToString();
        label3.Text = myds.Tables[0].Rows[0][3].ToString();
        lei = myds.Tables[0].Rows[0][4].ToString();
        label4.Text = myds.Tables[0].Rows[0][4].ToString();
        label5.Text = myds.Tables[0].Rows[0][5].ToString();
        photoPath = myds.Tables[0].Rows[0][7].ToString();
        image.Src = myds.Tables[0].Rows[0][7].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string name = Class1.onyou;
        string country = Request.Form["score"].ToString();
        Sdh = Request.QueryString["bk_name"];
        string selectstr = "select * from " + name + "bookshelf where bs_name = '" + Sdh + "'";
        sqlcon = new SqlConnection(strCon);
        SqlDataAdapter mads = new SqlDataAdapter();
        DataSet myds = new DataSet();
        sqlcon.Open();
        mads.SelectCommand = new SqlCommand(selectstr, sqlcon);
        myds.Clear();
        mads.Fill(myds);
        if (myds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script language=javascript>alert('请先收藏本图书！');location='javascript:history.go(-1)';</script>");
            sqlcon.Close();
            return;
        }
        string insertstr = "update " + name + "bookshelf set bs_number = '" + country + "' where bs_name = '" + Sdh + "'";
        sqlcom = new SqlCommand(insertstr, sqlcon);
        sqlcom.ExecuteNonQuery();
        sqlcon.Close();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string name = Class1.onyou;
        Sdh = Request.QueryString["bk_name"];
        string selectstr = "select * from " + name + "bookshelf where bs_name = '" + Sdh + "'";
        sqlcon = new SqlConnection(strCon);
        SqlDataAdapter mads = new SqlDataAdapter();
        DataSet myds = new DataSet();
        sqlcon.Open();
        mads.SelectCommand = new SqlCommand(selectstr, sqlcon);
        myds.Clear();
        mads.Fill(myds);
        if (myds.Tables[0].Rows.Count != 0)
        {
            Response.Write("<script language=javascript>alert('图书已收藏！');location='javascript:history.go(-1)';</script>");
            sqlcon.Close();
            return;
        }
        string insertstr = "insert into " + name + "bookshelf(bs_name,bs_photo,bs_lei) values(@bs_name,@bs_photo,@bs_lei)";
        sqlcom = new SqlCommand(insertstr, sqlcon);
        sqlcom.Parameters.AddWithValue("@bs_name", Sdh);
        sqlcom.Parameters.AddWithValue("@bs_photo", photoPath);
        sqlcom.Parameters.AddWithValue("@bs_lei", lei);
        if (sqlcom.ExecuteNonQuery() > 0)
        {
            Response.Write("<script language=javascript>alert('图书收藏成功！');location='javascript:history.go(-1)';</script>");
            sqlcon.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("bookshelf.aspx");
    }
}