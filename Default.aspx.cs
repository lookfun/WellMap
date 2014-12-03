using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page
{
    public Single[] jd = new Single[50];
    public Single[] wd = new Single[50];
    public string[] wellname = new string[50];
    public int k = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //SQL
        SqlConnection con = new SqlConnection("server=(local)\\SQLEXPRESS;database=DrillData;uid=sa;pwd=kb134");
      /*  var objdbConn = new ActiveXObject("ADODB.Connection");
        var strdsn = "Driver={SQLOLEDB};SERVER=(local)\\SQLEXPRESS;UID=sa;PWD=kb134;DATABASE=DrillData";      // 需要修改自己的服务器地址,用户名,密码  
        objdbConn.Open(strdsn);
        var objrs = new ActiveXObject("ADODB.Recordset");
        objrs = objdbConn.Execute("SELECT * FROM dbo.Wells"); 
       */
        con.Open();
        SqlCommand cmd1 = new SqlCommand("select * from dbo.Wells  ", con);
        SqlDataReader reader = cmd1.ExecuteReader();
        int k2 = 0;
        int k3 = 0;
        int k4 = 0;
        string namebuf = "";
        Single jdbuf = 0;
        Single wdbuf = 0;
        while (reader.Read())
        {
            //mane
            namebuf = (string)reader["井名"];
            wellname[k2] = namebuf;
            k2++;
            //jd 
            jdbuf = (Single)reader["经度"];
            jd[k3] = jdbuf;
            k3++;
            //wd  
            wdbuf = (Single)reader["纬度"];
            wd[k4] = wdbuf;
            k4++;
        }
        k = k2;
    }
}