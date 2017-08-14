using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections; 

namespace Web3
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        ArrayList cust = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label2.Text = "";
                Label la = this.Master.FindControl("Label1") as Label;
                la.Text = Session["User"].ToString();

                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("NIC");
                dt.Columns.Add("Address");
                dt.Columns.Add("Income");
                dt.Columns.Add("Age");
                dt.Columns.Add("Gender");
                
                string id = la.Text;

                ServiceReference2.WebService2SoapClient cus = new ServiceReference2.WebService2SoapClient();
                foreach (var i in cus.getdetails(id))
                {
                    cust.Add(i);
                }
                if (cust.Count > 0)
                {
                    Label3.Text = "" + cust[0];
                    Label4.Text = "" + cust[1];
                    Label5.Text = "" + cust[2];
                    Label6.Text = "" + cust[3];
                    Label7.Text = "" + cust[4];
                    Label8.Text = "" + cust[5];
                }
                else
                {
                    Label2.Text = "System Error";
                }

            }
        }
    }
}