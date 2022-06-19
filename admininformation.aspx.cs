using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admininformation : System.Web.UI.Page
{
    SqlConnection sqlconn;
    readonly string strCon = "Data Source=DESKTOP-0QPAQJ0;Database=books;Uid=sa;Pwd=123;";
    string Sdh;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    private void Bind()
    {
        Sdh = Class1.onyou;
        string sqlstr = "select * from admin where Bos_id='" + Sdh + "'";
        sqlconn = new SqlConnection(strCon);
        SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlconn);
        DataSet myds = new DataSet();
        myds.Clear();
        sqlconn.Open();
        myda.Fill(myds);
        label1.Text = myds.Tables[0].Rows[0][4].ToString();
        label2.Text = myds.Tables[0].Rows[0][3].ToString();
        image.Src = myds.Tables[0].Rows[0][5].ToString();
        sqlconn.Close();
    }
    protected void btn_xiu(object sender, EventArgs e)
    {
        Response.Redirect("adminxinxi.aspx");
        Bind();
    }
}