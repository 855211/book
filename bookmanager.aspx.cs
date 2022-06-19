using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public partial class Default5 : System.Web.UI.Page
{
    SqlConnection sqlcon;
    SqlCommand sqlcom;
    readonly string strCon = "Data Source=DESKTOP-0QPAQJ0;Database=books;Uid=sa;Pwd=123;";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    private void Bind()
    {
        string sqlstr = "select * from book";
        sqlcon = new SqlConnection(strCon);
        SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet myds = new DataSet();
        sqlcon.Open();
        myda.Fill(myds);
        GridView1.DataSource = myds;
        GridView1.DataBind();
        sqlcon.Close();
    }
    //查询
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            Bind();
        }
        else
        {
            var CommandString = "select * from book where bk_name Like '%{0}%';";
            CommandString = string.Format(CommandString, TextBox1.Text.Trim());
            sqlcon = new SqlConnection(strCon);
            SqlDataAdapter mads = new SqlDataAdapter(CommandString, sqlcon);
            DataSet mada = new DataSet();
            sqlcon.Open();
            mads.Fill(mada);
            GridView1.DataSource = mada;
            GridView1.DataBind();
            sqlcon.Close();
        }
    }
    protected void ListView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)//判断数据类型
        {
            if (e.Row.Cells[2].Text.Length > 6)//第3列（从0开始）是需要的数据，控制长度为20
            {
                e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 30) + "...";
            }
            e.Row.Cells[4].Text = e.Row.Cells[4].Text.Substring(0, 4);
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("booktianjia.aspx");
        Bind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sqlstr = "delete from book where bk_name='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        string selstrs = "select * from book where bk_name='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        sqlcon = new SqlConnection(strCon);
        SqlDataAdapter myda = new SqlDataAdapter();
        DataSet myds = new DataSet();
        sqlcon.Open();
        myda.SelectCommand = new SqlCommand(selstrs, sqlcon);
        myds.Clear();
        myda.Fill(myds);
        string phototype = @"C:\Users\王哲\Documents\Visual Studio 2010\WebSites\WebSite3\" + myds.Tables[0].Rows[0][7].ToString();
        string dirPath = @"C:\Users\王哲\Documents\Visual Studio 2010\WebSites\WebSite3\image\bookcontent" + @"\" + @GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (Directory.Exists(dirPath))
        {
            Directory.Delete(dirPath, true);
        }
        if (File.Exists(phototype))
        {
            File.Delete(phototype);
        }
        sqlcom = new SqlCommand(sqlstr, sqlcon);
        sqlcom.ExecuteNonQuery();
        sqlcon.Close();
        Bind();
    }
}