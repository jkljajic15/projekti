using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataSet FaktureKupaca(int custid)
    {
        SqlConnection Cn = new SqlConnection();
        Cn.ConnectionString = "server=.;integrated security=false;user id=sa;password=Pa$$w0rd;database=TSQL2012";
        SqlCommand Cm = new SqlCommand("SELECT * FROM Sales.Orders WHERE custid = " + custid + ";", Cn);
        SqlDataAdapter Da = new SqlDataAdapter(Cm);
        DataSet Ds = new DataSet();
        Da.Fill(Ds);
        return Ds;
    }
}