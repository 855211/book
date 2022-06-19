using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class tuijian : System.Web.UI.Page
{
    SqlConnection sqlcon;
    SqlCommand sqlcom;
    string sd;
    readonly string strCon = "Data Source=DESKTOP-0QPAQJ0;Database=books;Uid=sa;Pwd=123;";
    Class1 inds = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    private void Bind()
    {
        inds.Conn("DESKTOP-0QPAQJ0", "sa", "123", "books");
        string[] ind = inds.tuijian();
        string mingzi = ind[0];
        string lei = ind[1];
        sd = Class1.onyou;
        string sqlstr = "select * from " + mingzi + "bookshelf where bs_lei = '" + lei + "'and bs_number > 7";
        sqlcon = new SqlConnection(strCon);
        SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet myds = new DataSet();
        sqlcon.Open();
        myda.Fill(myds);
        GridView1.DataSource = myds;
        GridView1.DataBind();
        sqlcon.Close();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }
}