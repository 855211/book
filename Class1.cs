using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Class1
{
    //定义ADO.net对象  
    public static string onyou;//登录信息
    public static string s;
    SqlConnection mycon = new SqlConnection();
    SqlDataAdapter myadpt = new SqlDataAdapter();
    DataSet myds = new DataSet();
    DataTable myda = new DataTable();
    SqlCommand cmd = new SqlCommand();
    string[] stuinfo = new string[4];//存储返回的单条记录
    string selstr, indstr;   //存储SQL命令
    public object dt; //存放DataSet中的表
    public string df; //存放字段名
    public int renshu;
    public string Sname { get; set; }
    public string Ssex { get; set; }
    public void Conn(string srvname, string idf, string pwd, string dbname)
    {
        mycon.ConnectionString = "Data Source=" + srvname + ";User ID=" + idf + ";Password=" + pwd + ";Initial Catalog=" + dbname;
    }
    public void Opendbini()
    {
        myadpt.SelectCommand = new SqlCommand
        {
            Connection = mycon,
            CommandText = "select * from admin"
        };
        myadpt.Fill(myds);
        //
        dt = myds.Tables[0];
        df = "Bos_id";
        //以下代码将数据集(DataSet)中的字段信息赋予各属性
    }
    //验证管理员登录
    public int Verifylogin(string uname, string pword)
    {
        mycon.Open();
        string verystr = "select * from admin where Bos_id='" + uname + "' and Bos_password='" + pword + "'";
        myadpt.SelectCommand = new SqlCommand(verystr, mycon);
        myadpt.Fill(myds);
        if (myds.Tables[0].Rows.Count != 0)
        {
            mycon.Close();
            myds.Clear();
            return 1;   //登录成功
        }
        else
        {
            mycon.Close();
            myds.Clear();
            return 0;   //登录失败
        }
    }
    //验证用户登录
    public int Verifylogin1(string uname, string pword)
    {
        mycon.Open();
        string verystr = "select * from users where users_id='" + uname + "' and users_password='" + pword + "'";
        myadpt.SelectCommand = new SqlCommand(verystr, mycon);
        myds.Clear();
        myadpt.Fill(myds);
        if (myds.Tables[0].Rows.Count != 0)
        {
            mycon.Close();
            myds.Clear();
            return 1;   //登录成功
        }
        else
        {
            mycon.Close();
            myds.Clear();
            return 0;   //登录失败
        }
    }

    //添加管理员数据
    public int Inststu(string uname, string pword)
    {
        mycon.Open();
        string verystr = "select * from admin where Bos_id='" + uname + "'";
        myadpt.SelectCommand = new SqlCommand(verystr, mycon);
        myadpt.Fill(myds);
        if (myds.Tables[0].Rows.Count != 0)
        {
            mycon.Close();
            return 1;   //注册失败
        }
        indstr = "insert into admin([Bos_id],[Bos_password],[Bos_photo]) values(@Bos_id,@Bos_password,@Bos_photo)";
        //打开数据
        if (mycon.State == ConnectionState.Open)
        {
            //创建命令对象
            SqlCommand sqlComm = new SqlCommand(indstr, mycon);
            sqlComm.Parameters.AddWithValue("@Bos_id", uname);
            sqlComm.Parameters.AddWithValue("@Bos_password", pword);
            sqlComm.Parameters.AddWithValue("@Bos_photo", @"image\adminImage\780.jpg");
            sqlComm.ExecuteNonQuery();
        }
        myds.Clear();
        mycon.Close();
        return 0;   //注册成功

    }
    //添加用户数据
    public int Inststu1(string uname, string pword)
    {
        mycon.Open();
        string verystr = "select * from users where users_id='" + uname + "'";
        myadpt.SelectCommand = new SqlCommand(verystr, mycon);
        myadpt.Fill(myds);
        if (myds.Tables[0].Rows.Count != 0)
        {
            mycon.Close();
            return 1;   //注册失败
        }
        indstr = "insert into users ([users_id],[users_password],[users_photo]) values(@users_id,@users_password,@users_photo)";
        //打开数据
        if (mycon.State == ConnectionState.Open)
        {
            //创建命令对象
            SqlCommand sqlComm = new SqlCommand(indstr, mycon);
            sqlComm.Parameters.AddWithValue("@users_id", uname);
            sqlComm.Parameters.AddWithValue("@users_password", pword);
            sqlComm.Parameters.AddWithValue("@users_photo", @"image\userImage\780.jpg");
            sqlComm.ExecuteNonQuery();
        }
        selstr = "create table " + uname + "bookshelf(bs_name nchar(10),bs_photo varchar(50),bs_number int,bs_lei nchar(10));";
        SqlCommand da = new SqlCommand(selstr, mycon);
        da.ExecuteNonQuery();
        myds.Clear();
        mycon.Close();
        return 0;   //注册成功
    }
    public string[] tuijianyonghu()
    {
        int x = 0;
        string sele = "select * from users";
        myadpt.SelectCommand = new SqlCommand(sele, mycon);
        mycon.Open();
        myda.Clear();
        myadpt.Fill(myda);
        string[] xingm = new string[myda.Rows.Count];
        for (; x < myda.Rows.Count; x++)
        {
            xingm[x] = myda.Rows[x][1].ToString();
        }
        mycon.Close();
        for (int i = myda.Rows.Count - 1; i >= 0; i--)
        {
            myda.Rows.RemoveAt(i);
        }
        return xingm;
    }
    public string[] tuijian()
    {
        string[] mingz = { };
        mingz = tuijianyonghu();
        string[] ds = { "文学类", "历史类", "哲理类", "小说类" };
        string[] shu = new string[2];
        int yunsuan = 0;
        int o = 0;
        int y = 0;
        //确认用户人数
        for (int j = 0; j < mingz.Length; j++)
        {
            if (mingz[j] != null)
            {
                y++;
            }
        }
        renshu = y;
        int[,] yun = new int[y, ds.Length];
        y = y - 1;//配合数组从0开始
        mycon.Open();
        //对用户的评分进行平均统计
        for (; y >= 0; --y)
        {
            for (int i = 0; i < ds.Length; ++i)
            {
                string un = "select * from " + mingz[y] + "bookshelf where bs_lei =  '" + ds[i] + "';";
                myadpt.SelectCommand = new SqlCommand(un, mycon);
                myda.Clear();
                myadpt.Fill(myda);
                if (myda.Rows.Count == 0)
                {
                    continue;
                }
                for (; o < myda.Rows.Count; o++)
                {
                    if (yunsuan == 0)
                    {
                        yunsuan += int.Parse(myda.Rows[o][9].ToString());
                        continue;
                    }
                    yunsuan = (yunsuan + int.Parse(myda.Rows[o][9].ToString())) / 2;
                }
                yun[y, i] = yunsuan;
                yunsuan = 0;
                o = 0;
            }
        }
        mycon.Close();
        //将登录用户的数据调出
        int z = 0;
        int[] me = new int[ds.Length];
        for (int j = 0; j < mingz.Length; j++)
        {
            if (mingz[j] == onyou)
            {
                z = j;
                for (; o < ds.Length; ++o)
                {
                    me[o] = yun[z, o];
                }
            }
        }
        double[] xiangshi = new double[renshu];//存储相似度
        //计算sim(x1,x2)
        double shang = 0;
        double xia1 = 0;
        double xia2 = 0;
        for (int j = 0; j < mingz.Length; j++)
        {
            if (mingz[j] == onyou)
                continue;
            for (int t = 0; t < ds.Length; ++t)
            {
                shang += me[t] * yun[j, t];
                xia1 += me[t] * me[t];
                xia2 += yun[j, t] * yun[j, t];
            }
            xia1 = Math.Sqrt(xia1);
            xia2 = Math.Sqrt(xia2);
            xiangshi[j] = shang / (xia1 * xia2);
            xia1 = 0;
            xia2 = 0;
            shang = 0;
        }
        //最相似的人
        for (int p = 0; p < renshu -1; ++p)
        {
            if (xiangshi[p] > xiangshi[p + 1])
                shu[0] = mingz[p];
        }
        //图书分类
        double[] tushulei = new double[ds.Length];
        double lei = 0;
        double xia = 0;
        for (int d = 0; d < ds.Length; ++d)
        {
            for (int j = 0; j < mingz.Length; j++)
            {
                if (mingz[j] == onyou)
                {
                    continue;
                }
                shang += yun[j, d] * xiangshi[j];
                xia += xiangshi[j];
            }
            lei = shang / xia;
            tushulei[d] = lei;
            shang = 0;
            xia = 0;
            lei = 0;
        }
        for(int j = 0;j<ds.Length-1;j++)
        {
            if (tushulei[j] > tushulei[j + 1])
                shu[1] = ds[j];
        }
        return shu;
    }
}