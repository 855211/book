using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class View : System.Web.UI.Page
{
    SqlConnection sqlcon;
    SqlCommand sqlcom;
    readonly string strCon = "Data Source=DESKTOP-0QPAQJ0;Database=books;Uid=sa;Pwd=123;";
    protected void Page_Load(object sender, EventArgs e)
    {
        string uname = "ony";       
        string selstr = "create table " + uname + "bookshelf";
        selstr += "(";
        selstr += "bs_name nchar,";
        selstr += "bs_photo varchar";
        selstr += ");";
        sqlcon = new SqlConnection(strCon);
        sqlcom = new SqlCommand(selstr, sqlcon);
        sqlcon.Open();
        sqlcom.ExecuteNonQuery();
        sqlcon.Close();
    }
}