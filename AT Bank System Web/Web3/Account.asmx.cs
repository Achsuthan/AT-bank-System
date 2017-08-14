using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Web3
{
    /// <summary>
    /// Summary description for WebService3
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService3 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable account(string id)
        {
            DataTable dt = new DataTable("My data table");
            dt.Columns.Add("Account Number");
            dt.Columns.Add("Account Type");
            dt.Columns.Add("Interest Rate");
            dt.Columns.Add("Balance");
            dt.Columns.Add("DateOpen");
            dt.Columns.Add("BranchID");
          //  try
            //{
                string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand comm = con.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "Select AccountNumber,AccountType,IntrestRate,DateAccountOpen,AccountBalance,BranchID from [Bank_System].[dbo].[account] where CustomerID='" + id + "'";


                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DataRow dr1 = dt.NewRow();
                        dr1["Account Number"] = "" + dr["AccountNumber"];
                        dr1["Account Type"] = "" + dr["AccountType"];
                        dr1["Interest Rate"] = "" + dr["IntrestRate"];
                        dr1["Balance"] = "" + dr["AccountBalance"];
                        dr1["DateOpen"] = "" + dr["DateAccountOpen"];
                        dr1["BranchID"] = "" + dr["BranchID"];
                        dt.Rows.Add(dr1);
                    }

                }

                dr.Close();

                

          /*  }
            catch (Exception ex)
            {
                
            }
            */
            return dt;
        }
    }
}
