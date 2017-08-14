using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace Web3
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "";
            Label3.Text = "Update Password";
            Label5.Text = "";

            System.Web.UI.WebControls.Label la = this.Master.FindControl("Label1") as System.Web.UI.WebControls.Label;
            la.Text = Session["User"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string username = DropDownList1.SelectedValue;
            string password = TextBox1.Text;

            if (TextBox1.Text != "")
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);

                    con.Open();

                    SqlCommand comm = con.CreateCommand();
                    comm.CommandType = CommandType.Text;

                    comm.CommandText = "select password from [Bank_System].[dbo].[customer_login] where username='"+username+"'";

                    SqlDataReader dr = comm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (password.Equals(dr["password"]))
                            {
                                MultiView1.ActiveViewIndex = 1;
                                Label3.Text = "Add new Password";
                            }
                            else
                            {
                                Label2.Text = "Check Your password";
                            }
                        }
                    }
                    dr.Close();
                    Label4.Text = DropDownList1.Text;
                }
                catch (Exception ex)
                {
                    Label2.Text = ex.ToString();
                }
            }

            else
            {
                Label2.Text = "Check All inputs";
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            if (TextBox2.Text != "" && TextBox3.Text != "")
            {
                if (TextBox2.Text == TextBox3.Text)
                {
                    try
                    {
                        string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                        SqlConnection con = new SqlConnection(constr);

                        con.Open();

                        SqlCommand comm = con.CreateCommand();
                        comm.CommandType = CommandType.Text;

                        comm.CommandText = "update  [Bank_System].[dbo].[customer_login] set password='" + TextBox3.Text + "' where username='" + DropDownList1.SelectedValue + "'";
                        comm.ExecuteNonQuery();
                        MessageBox.Show(new Form { TopMost=true}, "Username and Password Update sucessfully");
                        Response.Redirect(Request.RawUrl);
                    }
                    catch (Exception ex)
                    {
                        Label5.Text = ex.ToString();
                    }
                }
                else
                {
                    Label5.Text = "Check the Password";
                }
            }

            else
            {
                Label5.Text = "Check the Password";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            Label3.Text = "Check the oldest Password";

        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            Label2.Text = "Check the oldest Password";
        }
    }
}