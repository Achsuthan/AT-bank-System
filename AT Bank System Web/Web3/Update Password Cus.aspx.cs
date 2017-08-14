using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Web3
{
    public partial class WebForm6 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Label la = this.Master.FindControl("Label1") as System.Web.UI.WebControls.Label;
            la.Text = Session["User"].ToString();

            Label2.Text = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            Label2.Text = "";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string password = TextBox1.Text;
            string password1 = TextBox2.Text;
            string password2 = TextBox3.Text;
            string id = Session["User"].ToString();

            if (TextBox1.Text == "")
            {
                Label2.Text = "Please enter your oldest password";
            }
            else
            {
                if (password1 != password2)
                {
                    Label2.Text = "Check your new password";
                }

                else
                {
                    if (TextBox2.Text!="" && TextBox3.Text!="")
                    {
                        if (TextBox2.Text == TextBox3.Text)
                        {
                           try
                            {
                                string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                                SqlConnection con = new SqlConnection(constr);

                                con.Open();

                                SqlCommand comm1 = con.CreateCommand();
                                comm1.CommandType = CommandType.Text;

                                comm1.CommandText = "select username from [Bank_System].[dbo].[customer_login] where  password='" + TextBox1.Text + "' and username='" + id + "'";

                                SqlDataReader dr = comm1.ExecuteReader();

                                if (dr.HasRows)
                                {
                                    dr.Close();
                                    SqlCommand comm = con.CreateCommand();
                                    comm.CommandType = CommandType.Text;

                                    comm.CommandText = "update  [Bank_System].[dbo].[customer_login] set password='" + TextBox3.Text + "' where username='" + Session["User"].ToString() + "'";
                                    comm.ExecuteNonQuery();
                                    MessageBox.Show(new Form { TopMost=true}, "Password Updated Sucessfully");
                                    Response.Redirect(Request.RawUrl);
                                    
                                }

                                else
                                {
                                    dr.Close();
                                    Label2.Text = "Check your oldest password";
                                }

                            }
                            catch (Exception ex)
                            {
                                Label2.Text = ex.ToString();
                            }
                        }
                        else
                        {
                            Label2.Text = "Check your new password is correct";
                        }
                        
                    }
                    else
                    {
                        Label2.Text = "Insert New passwrod";
                    }
                }
            }
        }
    }
}