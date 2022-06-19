using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class userbookshelf : System.Web.UI.Page
{
    SqlConnection sqlcon;
    SqlCommand sqlcom;
    string sd;
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
        sd = Class1.onyou;
        string sqlstr = "select * from " + sd + "bookshelf";
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
        sd = Class1.onyou;
        if (TextBox1.Text == "")
        {
            Bind();
        }
        else
        {
            var CommandString = "select * from " + sd + "bookshelf where bs_name Like '%{0}%';";
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sd = Class1.onyou;
        string sqlstr = "delete from " + sd + "bookshelf where bs_name='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        sqlcon = new SqlConnection(strCon);
        sqlcon.Open();
        sqlcom = new SqlCommand(sqlstr, sqlcon);
        sqlcom.ExecuteNonQuery();
        sqlcon.Close();
        Bind();
    }
}