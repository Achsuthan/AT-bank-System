using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Web3
{
    /// <summary>
    /// Summary description for WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {

        [WebMethod]
        public ArrayList getdetails(string Id)
        {
            ArrayList cust = new ArrayList();


            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand comm = con.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "Select CustomerName,NIC,Address,Income,Age,Gender from [Bank_System].[dbo].[customer] where CustomerID='" + Id + "'";

                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {

                        cust.Add( "" + dr["CustomerName"]);
                        cust.Add("" + dr["NIC"]);
                        cust.Add( "" + dr["Address"]);
                        cust.Add("" + dr["Age"]);
                        cust.Add("" + dr["Gender"]);
                        cust.Add("" + dr["Income"]);
                    }


                }
                dr.Close();



            }
            catch (Exception ex)
            {
                
            }


            return cust;
        }
    }
}
