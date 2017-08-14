using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Web3
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label la = this.Master.FindControl("Label1") as Label;
            la.Text = Session["User"].ToString();

            Label2.Text = "";

           // DataTable dt = new DataTable();
            

            string id = la.Text;
            //ServiceReference5.WebService3SoapClient acc = new ServiceReference5.WebService3SoapClient();
            //acc.account(id,dt);
            //ServiceReference5.WebService3SoapClient acc = new ServiceReference5.WebService3SoapClient();
            ServiceReference3.WebService3SoapClient acc = new ServiceReference3.WebService3SoapClient();
            DataTable dt = acc.account(id);
            GridView1.DataSource = dt;
            GridView1.DataBind();


            

        }
    }
}