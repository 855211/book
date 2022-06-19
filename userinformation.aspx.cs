using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class userxinxi : System.Web.UI.Page
{
    SqlConnection sqlconn;
    SqlCommand sqlcom;
    readonly string strCon = "Data Source=DESKTOP-0QPAQJ0;Database=books;Uid=sa;Pwd=123;";
    string Sdh;
    int x = 0;
    string xiu = "";
    string photoname;
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
        string sqlstr = "select * from users where users_id='" + Sdh + "'";
        sqlconn = new SqlConnection(strCon);
        SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlconn);
        DataSet myds = new DataSet();
        myds.Clear();
        sqlconn.Open();
        myda.Fill(myds);
        label1.Text = myds.Tables[0].Rows[0][5].ToString();
        label2.Text = myds.Tables[0].Rows[0][3].ToString();
        label3.Text = myds.Tables[0].Rows[0][6].ToString();
        image.Src = myds.Tables[0].Rows[0][4].ToString();
        sqlconn.Close();
    }
    protected void btn_xiu(object sender, EventArgs e)
    {
        Response.Redirect("userxiugai.aspx");
        Bind();
    }

    protected void btn_fan(object sender, EventArgs e)
    {
        Sdh = Class1.onyou;
        var indsad = TextBox1.Text;
        DateTime dt = System.DateTime.Now;
        string strTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
        string sql = "insert into feedback(fb_name,fb_information,fb_time) values ('" + Sdh + "','" + indsad + "','" + strTime + "');";
        sqlconn = new SqlConnection(strCon);
        sqlcom = new SqlCommand(sql, sqlconn);
        sqlconn.Open();
        sqlcom.ExecuteNonQuery();
        sqlconn.Close();
    }
}