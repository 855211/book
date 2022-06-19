using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class feedback : System.Web.UI.Page
{
    SqlConnection sqlcon;
    SqlCommand sqlcom;
    readonly string strCon = "Data Source=DESKTOP-0QPAQJ0;Database=books;Uid=sa;Pwd=123;Min Pool Size=5";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    private void Bind()
    {
        string sqlstr = "select * from feedback";
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
            var CommandString = "select * from feedback where fb_name Like '%{0}%';";
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

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Bind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sqlstr = "delete from feedback where fb_name='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        sqlcon = new SqlConnection(strCon);
        sqlcom = new SqlCommand(sqlstr, sqlcon);
        sqlcon.Open();
        sqlcom.ExecuteNonQuery();
        sqlcon.Close();
        Bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DateTime dt = System.DateTime.Now;
        string strTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
        string sinformation = (GridView1.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox).Text.ToString().Trim();
        string sqlstrd = "update feedback set fb_informations = '" + sinformation + "',fb_times = '" + strTime + "' where id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString().Trim() + "'";
        sqlcon = new SqlConnection(strCon);
        sqlcom = new SqlCommand(sqlstrd, sqlcon);
        sqlcon.Open();
        sqlcom.ExecuteNonQuery();
        GridView1.EditIndex = -1;
        sqlcon.Close();
        Bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }
}