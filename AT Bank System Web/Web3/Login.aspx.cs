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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string option="";
        int status=0;
        string display = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Label4.Text = "";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (TextBox1.Text != "" && TextBox1.Text != "")
                {
                    string username = TextBox1.Text;
                    string password = TextBox2.Text;
                    Label4.Text = password;

                    ServiceReference1.WebService1SoapClient log = new ServiceReference1.WebService1SoapClient();
                    status=log.Admin_Login(username,password);

                    if (status == 1)
                    {
                        MessageBox.Show(new Form { TopMost=true}, "Welcome Admin '"+username+"'");
                        display = "Welcome Admin '" + username + "'";
                        Label4.Text = display;
                        Session["User"] = username;
                        Response.Redirect("~/Admin View.aspx?");
                    }

                    else if (status == 2)
                    {
                        MessageBox.Show(new Form { TopMost = true }, "Welcome Customer '" + username + "'");
                        Session["User"] = username;
                        Response.Redirect("~/Customer View.aspx");
                    }

                    else if (status == 9)
                    {
                        display = "Check your username and password";
                        Label4.Text = display;
                        Session.Clear();
                    }
                    else
                    {
                        display = "Check your username and password1";
                        Label4.Text = display;
                        Session.Clear();
                    }


                }
                else
                {
                    display = "Input all values";
                    Label4.Text = display;
                }
            }
            catch (SqlException ex)
            {
                display = ex.ToString();
                Label4.Text = display;
            }

           










        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

      
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}