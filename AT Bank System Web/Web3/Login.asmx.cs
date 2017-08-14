using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Web3
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public int Admin_Login(string username, string password)
        {
            int adminlog = 0;
            int userlog = 0;
            int returnlog = 0;

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();
                SqlCommand comm = con.CreateCommand();
                comm.CommandType = CommandType.Text;

                comm.CommandText = "Select username,password from [Bank_System].[dbo].[admin] where username='" + username + "'";

                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {

                        if (String.Equals(dr["password"], password))
                        {
                            adminlog = 1;
                            break;
                        }
                        else
                        {
                            adminlog = 0;
                        }
                    }
                }
                else
                    adminlog = 0;

                dr.Close();

                if (adminlog == 0)
                {
                    SqlCommand comm1 = con.CreateCommand();
                    comm1.CommandType = CommandType.Text;

                    comm1.CommandText = "Select username,password from [Bank_System].[dbo].[customer_login] where username='" + username + "'";

                    SqlDataReader dr1 = comm1.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            if (String.Equals(dr1["password"], password))
                            {
                                userlog = 1;
                                break;
                            }
                            else
                            {
                                userlog = 0;
                            }
                        }

                    }
                    else
                    {
                        userlog = 0;

                    }
                    dr1.Close();


                }

                if (userlog == 0 && adminlog == 0)
                {
                    returnlog = 0;
                }

                else if (adminlog == 1)
                {
                    returnlog = 1;
                }

                else if (userlog == 1)
                {
                    returnlog = 2;
                }
                else
                {
                    returnlog = 9;
                }

                dr.Close();

            }
            catch (Exception ex)
            {
            }
            return returnlog;
        }
    }
}
