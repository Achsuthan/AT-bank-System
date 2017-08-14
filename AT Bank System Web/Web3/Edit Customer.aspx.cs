using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Web3
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        string NIC;
        int Age;
        string Gender;
        bool niccheck = false;
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label2.Text = "Customer Details";
                Label3.Text = "";
                Label4.Text = "";

                System.Web.UI.WebControls.Label la = this.Master.FindControl("Label1") as System.Web.UI.WebControls.Label;
                la.Text = Session["User"].ToString();
                id = la.Text;
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);

                    con.Open();

                    SqlCommand comm = con.CreateCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "Select CustomerName,NIC,Address,Income from [Bank_System].[dbo].[customer] where CustomerID='" + la.Text + "'";


                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBox1.Text = "" + dr["CustomerName"];
                            TextBox2.Text = "" + dr["NIC"];
                            TextBox3.Text = "" + dr["Address"];
                            DropDownList1.SelectedValue = "" + dr["Income"];
                        }
                    }

                    dr.Close();

                }
                catch (NotFiniteNumberException ex)
                {
                    Label3.Text = ex.ToString();
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text="";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            NICcheck();
            if (niccheck == true && TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && DropDownList1.SelectedValue!="")
            {
                Label5.Text = TextBox1.Text;
                Label6.Text = TextBox2.Text;
                Label9.Text = TextBox3.Text;
                Label10.Text = DropDownList1.SelectedValue;
                MultiView1.ActiveViewIndex = 1;
                Label2.Text = "Add Customer Details";
            }

            else
            {
                Label3.Text = "Check all inputs";
            }
            

        }

        protected void NICcheck()
        {
            NIC = TextBox2.Text;

            if (NIC.Count() == 10)
            {
                try
                {
                    if (NIC.Substring(9).Equals("V") || NIC.Substring(9).Equals("X") || NIC.Substring(9).Equals("x") || NIC.Substring(9).Equals("v"))
                    {
                        int year = int.Parse(19 + NIC.Substring(0, 2));
                        Age = 2016 - year;
                        Label7.Text = "" + (2016 - year);
                        int total = int.Parse(NIC.Substring(2, 3));
                        niccheck = true;

                        if (total > 500 && total < 866)
                        {
                            Gender = "Female";
                            Label8.Text = Gender;
                            niccheck = true;
                        }
                        else if ((total < 500 || total > 0) && total < 366)
                        {
                            Gender = "Male";
                            Label8.Text = Gender;
                            niccheck = true;
                        }

                        else
                        {
                            Label3.Text="Check your NIC number ";
                            niccheck = false;
                            Label8.Text = "";
                            Label7.Text = "";
                        }
                    }
                    else
                    {
                       Label3.Text="Check Your last charecter";
                        niccheck = false;

                        Label8.Text = "";
                        Label7.Text = "";
                    }
                }
                catch (FormatException)
                {
                    Label3.Text="Check your input charecter formate";
                }

            }
            else
            {
                Label3.Text="Check your NIC input";
                niccheck = false;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            Label2.Text = "Customer Details";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            id = Session["User"].ToString();
            try
            {
                
                string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand comm = con.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "Update [Bank_System].[dbo].[customer] set CustomerName='" +Label5.Text+ "',NIC='" + Label6.Text+ "',Age='"+int.Parse(Label7.Text)+"',Gender='"+Label8.Text+"',Address='"+Label9.Text+"',Income='"+Label10.Text+"' where CustomerID='" + id + "'";
                comm.ExecuteNonQuery();
                MessageBox.Show(new Form { TopMost = true }, "Details Updated Sucessfully");
                Response.Redirect(Request.RawUrl);
               
            }
            catch (Exception ex)
            {
                Label4.Text = ex.ToString();
             }
        }
    }
}