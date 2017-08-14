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
using System.Windows.Forms;

namespace Web3
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        ArrayList customer = new ArrayList();
        ArrayList customerlogin = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "";
            System.Web.UI.WebControls.Label la = this.Master.FindControl("Label1") as System.Web.UI.WebControls.Label;
            la.Text = Session["User"].ToString();

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand comm = con.CreateCommand();
                comm.CommandType = CommandType.Text;

                comm.CommandText = "Select CustomerID  from [Bank_System].[dbo].[customer]";

                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        DropDownList1.Items.Add("" + dr["CustomerID"]);
                    }
                }
                dr.Close();

                SqlCommand comm1 = con.CreateCommand();
                comm1.CommandType = CommandType.Text;

                comm1.CommandText = "Select username  from [Bank_System].[dbo].[customer_login]";

                SqlDataReader dr1 = comm1.ExecuteReader();
                if (dr1.HasRows)
                {

                    while (dr1.Read())
                    {
                        DropDownList1.Items.Remove(""+dr1["username"]);
                    }
                }
                dr1.Close();

            }
            catch (Exception ex)
            {
                Label2.Text = ex.ToString();
            }

            
                
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string password1 = TextBox1.Text;
            string password2 = TextBox2.Text;

            string username = DropDownList1.SelectedValue;
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                if (password1 == password2)
                {
                    try
                    {
                        string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                        SqlConnection con = new SqlConnection(constr);

                        con.Open();

                        SqlCommand comm = con.CreateCommand();
                        comm.CommandType = CommandType.Text;

                        comm.CommandText = "insert into   [Bank_System].[dbo].[customer_login] values('" + username + "','" + password1 + "')";
                        comm.ExecuteNonQuery();

                        MessageBox.Show(new Form { TopMost = true }, "User name and Password added");
                        Response.Redirect(Request.RawUrl);
                    }
                    catch (Exception ex)
                    {
                        Label2.Text = ex.ToString();
                    }

                }
                else
                {
                    Label2.Text = "Check your Password";
                }
            }

        }
    }
}