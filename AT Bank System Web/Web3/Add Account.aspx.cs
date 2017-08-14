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
    public partial class WebForm4 : System.Web.UI.Page
    {
        string CID = "";
        string BID = "";
        string ACID = "";
        string ID1 = "";
        string AccountTypeID = "";
        string AccountType = "";
        bool accountstatus = false;
        bool loadstatus = false;
        bool BranchCustomer = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            Label17.Text = "Select Branch";
            Label18.Text = "";
            Label21.Text = "";
            Label20.Text = "";
            Label31.Text = "";
            Load();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Check_Branch_customer();
        }
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
        }

        protected void CheckAccount()
        {

            try
            {

                string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();
                SqlCommand comm1 = con.CreateCommand();
                comm1.CommandType = CommandType.Text;

                comm1.CommandText = "select top 1 AccountNumber from [Bank_System].[dbo].[account] order by ID DESC";
                SqlDataReader dr1 = comm1.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        ACID = "" + dr1["AccountNumber"];
                        ID1 = ((int.Parse(ACID.Substring(5, 8))) + 1).ToString();
                        Label11.Text = ID1;
                    }
                }

                dr1.Close();

                SqlCommand comm2 = con.CreateCommand();
                comm2.CommandType = CommandType.Text;

                comm2.CommandText = "select Rate from [Bank_System].[dbo].[intrest] where Type='"+DropDownList3.SelectedValue+"' ";
                SqlDataReader dr2 = comm2.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        Label9.Text = "" + dr2["Rate"];
                    }
                }

                dr2.Close();
            }
            catch (InvalidOperationException)
            {
                ID1 = "11111111";
            }
            catch (Exception ex)
            {

            }
            BID = DropDownList1.SelectedValue;
            if (DropDownList3.SelectedValue == "Saving")
            {
                AccountTypeID = "101";
                accountstatus = true;
            }
            else if (DropDownList3.SelectedValue == "Current")
            {
                AccountTypeID = "001";
                accountstatus = true;
            }
            else if (DropDownList3.SelectedValue == "Child")
            {
                AccountTypeID = "115";
                accountstatus = true;
            }
            else
            {
                accountstatus = false;
            }
            Label11.Text = BID + "-" + ID1 + "-" + AccountTypeID;

            AccountType = DropDownList3.SelectedValue;

            accountstatus = true;
        }

        protected void Load()
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    DropDownList1.Items.Clear();
                    DropDownList4.Items.Clear();
                    DropDownList1.Items.Add("");
                    DropDownList4.Items.Add("");
                    System.Web.UI.WebControls.Label la = this.Master.FindControl("Label1") as System.Web.UI.WebControls.Label;
                    la.Text = Session["User"].ToString();


                    string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);

                    con.Open();

                    SqlCommand comm = con.CreateCommand();
                    comm.CommandType = CommandType.Text;

                    comm.CommandText = "Select BranchID from [Bank_System].[dbo].[branch]";

                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            DropDownList1.Items.Add("" + dr["BranchID"]);
                        }
                    }
                    dr.Close();

                    SqlCommand comm2 = con.CreateCommand();
                    comm2.CommandType = CommandType.Text;

                    comm2.CommandText = "select CustomerID from [Bank_System].[dbo].[customer]";
                    SqlDataReader dr2 = comm2.ExecuteReader();
                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            DropDownList4.Items.Add("" + dr2["CustomerID"]);
                        }
                    }

                    dr2.Close();


                    SqlCommand comm1 = con.CreateCommand();
                    comm1.CommandType = CommandType.Text;

                    comm1.CommandText = "select top 1 AccountNumber from [Bank_System].[dbo].[account] order by ID DESC";
                    SqlDataReader dr1 = comm1.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            ACID = "" + dr1["AccountNumber"];
                            ID1 = ((int.Parse(ACID.Substring(5, 8))) + 1).ToString();
                            Label11.Text = ID1;
                        }
                    }

                    dr1.Close();
                }
                catch (InvalidOperationException)
                {
                    ID1 = "11111111";
                }
                catch (Exception ex)
                {
                    //Label19.Text = ex.ToString();
                }

            }
                
        }
        protected void Check_Branch_customer()
        {
            CID = DropDownList4.SelectedValue;
            BID = DropDownList1.SelectedValue;

            
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            
            double balance = 0;
            bool bal = false;
            string date = "";
            try
            {
                balance = double.Parse(TextBox1.Text);
                bal = true;
            }
            catch(FormatException ex)
            {
                Label20.Text = "Check Balance";
            }
            date = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
            try
            {

                if (bal == true && date != "")
                {
                    Label25.Text = Label11.Text;
                    Label26.Text = Label9.Text;
                    Label28.Text = DropDownList3.SelectedValue;
                    Label29.Text = balance.ToString();
                    Label30.Text = date;
                    CheckAccount();
                    MultiView1.ActiveViewIndex = 3;
                    Label17.Text = "Check Account";

                    
                }
                else
                {
                    Label20.Text = "Check all inputs";
                }
           }
            catch(FormatException ex)
            {
                Label20.Text = ex.ToString();
            }
            
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue!="")
            {
                try
                {
                    BID = DropDownList1.SelectedValue;
                    string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);

                    con.Open();

                    SqlCommand comm = con.CreateCommand();
                    comm.CommandType = CommandType.Text;

                    comm.CommandText = "Select Name,Address from [Bank_System].[dbo].[branch] where BranchID='" + BID + "'";

                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            Label2.Text = "" + dr["Name"];
                            Label3.Text = "" + dr["Address"];
                        }
                    }
                    MultiView1.ActiveViewIndex = 1;
                    Label17.Text = "Select Customer & Branch Details ";
                    dr.Close();
                }
                catch (Exception ex)
                {
                    Label18.Text = ex.ToString();
                }
            }
            else
            {
                Label18.Text = "Select Branch ID";
            }



        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (DropDownList4.SelectedValue != "")
            {
                try
                {
                    Load();
                    Label11.Text = BID + "-" + ID1 + "-" + DropDownList4.Text;
                    CID = DropDownList4.SelectedValue;
                    CheckAccount();
                    string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);

                    con.Open();
                    SqlCommand comm1 = con.CreateCommand();
                    comm1.CommandType = CommandType.Text;

                    comm1.CommandText = "select CustomerName,NIC,Address,Income from [Bank_System].[dbo].[customer] where CustomerID='" + CID + "'";

                    SqlDataReader dr1 = comm1.ExecuteReader();
                    if (dr1.HasRows)
                    {

                        while (dr1.Read())
                        {
                            Label12.Text = "" + dr1["CustomerName"];
                            Label13.Text = "" + dr1["NIC"];
                            Label14.Text = "" + dr1["Address"];
                            Label15.Text = "" + dr1["Income"];
                            BranchCustomer = true;
                        }

                    }
                    dr1.Close();
                    MultiView1.ActiveViewIndex = 2;
                    Label17.Text = "Input Account Details & Customer Details ";
                }
                catch (Exception ex)
                {
                    Label21.Text = ex.ToString();
                }
            }

            else
            {
                Label21.Text = "Select Customer ID";
            }
      
            
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            Label17.Text = "Select Branch";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            Label17.Text = "Select Customer";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            Label17.Text = "Insert Account Details";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                double balance = 0;
                bool bal = false;
                string date = "";
                try
                {
                    balance = double.Parse(TextBox1.Text);
                    bal = true;
                }
                catch (FormatException ex)
                {
                    Label31.Text = "Check Balance";
                }
                date = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
                BID = DropDownList4.SelectedValue;
                AccountType = DropDownList3.SelectedValue;
                Label11.Text = BID + "-" + ID1 + "-" + DropDownList4.Text;
                CheckAccount();

                string constr = ConfigurationManager.ConnectionStrings["Rad"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand comm = con.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "insert into [Bank_System].[dbo].[account] (AccountNumber,AccountType,IntrestRate,DateAccountOpen,AccountBalance,BranchID,CustomerID) values('" + Label11.Text + "','" + AccountType + "','" + Label9.Text + "','" + date + "','" + balance + "','" + DropDownList1.SelectedValue + "','" + DropDownList4.SelectedValue + "')";
                comm.ExecuteNonQuery();

                string display = "Value inserted Success!";
                ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('" + display + "');", true);

                MessageBox.Show(new Form { TopMost = true }, "Account Added sucessfully");

                MultiView1.ActiveViewIndex = 0;
                Label17.Text = "Select Branch";

                Response.Redirect(Request.RawUrl);

                Load();
                CheckAccount();
            }
            catch (Exception ex)
            {
                Label31.Text = ex.ToString();
            }
        }

        

        
    }
}