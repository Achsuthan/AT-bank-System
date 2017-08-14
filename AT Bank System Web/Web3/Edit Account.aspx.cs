using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Web3
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            System.Web.UI.WebControls.Label la = this.Master.FindControl("Label1") as System.Web.UI.WebControls.Label;
            la.Text = Session["User"].ToString();
            Label5.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Edit")
            {
                Button3.Enabled = true;
                TextBox1.Enabled = true;
                Calendar1.Enabled = true;
                Button3.Text = "Edit";
            }

            else if (DropDownList1.SelectedValue == "Delete")
            {
                Button3.Enabled = false;
                TextBox1.Enabled = false;
                Calendar1.Enabled = false;
                Button3.Enabled = true;
                Button3.Text = "Delete";
            }

            else
            {
                Label5.Text = "System Error";
            }

            if ((DropDownList1.SelectedValue == "Edit" || DropDownList1.SelectedValue == "Delete") && DropDownList2.SelectedValue != "")
            {
                try
                {
                    string ID = DropDownList2.SelectedValue;

                    string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);

                    con.Open();

                    SqlCommand comm = con.CreateCommand();
                    comm.CommandType = CommandType.Text;

                    comm.CommandText = "Select AccountType,IntrestRate,DateAccountOpen,AccountBalance  from [Bank_System].[dbo].[account] where AccountNumber='" + ID + "'";

                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            Label2.Text = ID;
                            Label3.Text = "" + dr["AccountType"];
                            Label4.Text = "" + dr["IntrestRate"];
                            TextBox1.Text = "" + dr["AccountBalance"];
                        }
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    Label5.Text = ex.ToString();
                }
            }
            else
            {
                Label5.Text = "Select The option and Account ID";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Enabled = false;
            Calendar1.Enabled = false;
            Button3.Enabled = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string option = DropDownList1.SelectedValue;
                string id = DropDownList2.SelectedValue;

                string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                if (option == "Delete")
                {

                    SqlCommand comm = con.CreateCommand();
                    comm.CommandType = CommandType.Text;

                    comm.CommandText = "delete  [Bank_System].[dbo].[account] where AccountNumber='" + id + "'";
                    comm.ExecuteNonQuery();

                    MessageBox.Show(new Form { TopMost = true }, "Account Deleted sucessfully");
                    Response.Redirect(Request.RawUrl);

                }

                if (option == "Edit")
                {
                    if (Calendar1.SelectedDate != null && TextBox1.Text != "")
                    {
                        SqlCommand comm = con.CreateCommand();
                        comm.CommandType = CommandType.Text;

                        comm.CommandText = "Update [Bank_System].[dbo].[account] set AccountBalance='" + float.Parse(TextBox1.Text) + "',DateAccountOpen='" + Calendar1.SelectedDate.ToString("yyyy/MM/dd") + "' where AccountNumber='"+id+"'";
                        comm.ExecuteNonQuery();

                        MessageBox.Show(new Form { TopMost = true }, "Account Edidted Successfully");
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        Label5.Text = "Input the Account and Date";
                    }
                }
            }
            catch (FormatException)
            {
                Label5.Text = "Check the account Balance";
            }

            catch (Exception ex)
            {
                Label5.Text=ex.ToString();
            }
        }
    
        
    }
}