using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bank_System
{
    public partial class Form6 : Form
    {
        DateTime today;
        bool Plogin;
        bool back;

        string CID="";
        string BID="";
        string ID1 = "";

        string AccountID="";
        string AccountTypeID="";
        string AccountType="";
        string Date="";
        string IntrestRate;

        float AccountBalance=0;

       // bool branch = false;
        //bool customer = false;
        public Form6()
        {
            InitializeComponent();

            this.labelsf6();

            constructors();
        }

        public Form6(bool plogin)
        {
            InitializeComponent();
            this.labelsf6();

            Plogin = plogin;
            constructors();
            
        }

        public Form6(bool plogin,string ID,bool pback)
        {
            InitializeComponent();
            this.labelsf6();

            Plogin = plogin;
            back = pback;
            AccountID = ID;
            constructors();


            comboBox7.Text = ID;
            tabControl1.SelectedIndex = 3;

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bank_SystemDataSet5.account' table. You can move, or remove it, as needed.
            this.accountTableAdapter.Fill(this.bank_SystemDataSet5.account);
            // TODO: This line of code loads data into the 'bank_SystemDataSet4.branch' table. You can move, or remove it, as needed.
            this.branchTableAdapter.Fill(this.bank_SystemDataSet4.branch);
            // TODO: This line of code loads data into the 'bank_SystemDataSet3.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.bank_SystemDataSet3.customer);
            this.FormBorderStyle = FormBorderStyle.None;
            this.labelsf6();
        }

        private void labelsf6()
        {
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;

            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            this.label8.Text = time.ToString("hh:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (back == true && Plogin == true)
            {
                Form7 f7 = new Form7(Plogin);
                f7.Show();
                this.Close();
            }
            else if (Plogin == true)
            {
                Form1 f1 = new Form1(Plogin);
                f1.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Plogin = false;
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            label16.Enabled = false;
            comboBox3.Enabled = false;
            label19.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox1.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = false;
        }


        private void getvalues()
        {
            if (comboBox1.SelectedIndex > -1)
            {
                //Get the Branch Details
                DataClasses1DataContext dr = new DataClasses1DataContext();
                var items = from values in dr.GetTable<branch>() where values.BranchID == comboBox1.Text select values;

                foreach (var i in items)
                {
                    label10.Text = i.BranchID;
                    BID = i.BranchID;
                    label22.Text = i.Address;
                    
                }
            }

            if (comboBox2.SelectedIndex > -1)
            {
                //Get the Customers
                DataClasses1DataContext dr = new DataClasses1DataContext();
                var items = from values in dr.GetTable<customer>() where values.CustomerID == comboBox2.Text select values;

                foreach (var i in items)
                {
                    CID = i.CustomerID;
                    label9.Text = i.CustomerName;
                    label13.Text = i.NIC;
                    label29.Text = i.Address;
                    label24.Text = i.Income;
                    label27.Text = i.Age.ToString();
                    label25.Text = i.Gender;
                }
            }
            if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1)
            {
                label16.Enabled = true;
                comboBox3.Enabled = true;
                label19.Enabled = true;
                dateTimePicker1.Enabled = true;
                textBox1.Enabled = true;
                button4.Enabled = true;
                button3.Enabled = true;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getvalues();
            label16.Text = comboBox1.Text + "-" + ID1 + "-" + AccountTypeID;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            getvalues();
            CID = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Check your Account Type");
            }

            else
            {
                if (comboBox3.Text == "Saving")
                {
                    AccountTypeID = "101";
                }
                else if (comboBox3.Text == "Current")
                {
                    AccountTypeID = "001";
                }
                else if (comboBox3.Text == "Child")
                {
                    AccountTypeID = "115";
                }

                AccountType = comboBox3.Text;
            }
          
            label16.Text = comboBox1.Text + "-"+ID1+"-"+AccountTypeID;

            //get the rate

            if (comboBox3.SelectedIndex > -1)
            {
                //Get the Branch Details
                DataClasses1DataContext dr = new DataClasses1DataContext();
                var items = from values in dr.GetTable<intrest>() where values.Type == comboBox3.Text select values;

                foreach (var i in items)
                {
                    label19.Text = i.Rate;
                    IntrestRate = i.Rate;
                    
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AccountID = label16.Text;
            Date = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            try
            {
                AccountBalance = float.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Check your Account balance");
            }
            if (comboBox3.Text == "" || AccountID == "" || IntrestRate == "" || textBox1.Text == "" || Date == DateTime.Today.ToString("yyyy/MM/dd"))
            {
                MessageBox.Show("Check All Inputs");
            }

            else
            {
                try
                {
                    AccountID = label16.Text;
                    using (DataClasses1DataContext dr = new DataClasses1DataContext())
                    {

                        account a = new account();
                        a.AccountNumber = AccountID;
                        a.AccountBalance = AccountBalance;
                        a.AccountType = AccountType;
                        a.DateAccountOpen = Date;
                        a.CustomerID = CID;
                        a.BranchID = BID;
                        a.IntrestRate = IntrestRate;
                        dr.accounts.InsertOnSubmit(a);
                        dr.SubmitChanges();
                        MessageBox.Show("Data inserted Succcessfully");
                    }

                    getvalues();

                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    label10.Text = "";
                    label22.Text = "";
                    label9.Text = "";
                    label13.Text = "";
                    label29.Text = "";
                    label24.Text = "";
                    label25.Text = "";
                    label27.Text = "";

                    label16.Text = "";
                    comboBox3.Text = "";
                    label19.Text = "";
                    dateTimePicker1.Value = DateTime.Today;
                    textBox1.Text = "";

                    label16.Enabled = false;
                    comboBox3.Enabled = false;
                    label19.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    textBox1.Enabled = false;
                    button4.Enabled = false;
                    button3.Enabled = false;


                    // TODO: This line of code loads data into the 'bank_SystemDataSet5.account' table. You can move, or remove it, as needed.
                    this.accountTableAdapter.Fill(this.bank_SystemDataSet5.account);

                    //Get the Last account number

                    DataClasses1DataContext dr1 = new DataClasses1DataContext();
                    var acid = (from t in dr1.GetTable<account>() orderby t.AccountNumber descending select t.AccountNumber).First();

                    ID1 = ((int.Parse(acid.Substring(5, 8))) + 1).ToString();
                    label16.Text = ID1;

                    comboBox7.Items.Clear();

                    //Add the all customer ids to combobox2 to edit/delete the banch

                    DataClasses1DataContext dr2 = new DataClasses1DataContext();
                    var items = from i in dr2.GetTable<account>() select i;

                    foreach (var a in items)
                    {
                        comboBox7.Items.Add(a.AccountNumber.ToString());
                    }

                }
                catch (InvalidOperationException)
                {
                    label16.Text = "-11111111-";
                    AccountID = "-11111111-";

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
           
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AccountID = comboBox7.Text;

                //Get the Branch Details
                DataClasses1DataContext dr = new DataClasses1DataContext();
                var items = from values in dr.GetTable<account>() where values.AccountNumber == comboBox7.Text select values;

                foreach (var i in items)
                {
                    CID = i.CustomerID;
                    label36.Text = CID;

                    BID = i.BranchID;
                    label32.Text = BID;


                    AccountType = i.AccountType;

                    label44.Text = i.IntrestRate;

                    dateTimePicker2.Value = DateTime.Parse(i.DateAccountOpen);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void getvalues2()
        {
            try
            {
                if (comboBox1.SelectedIndex > -1)
                {
                    //Get the Branch Details
                    DataClasses1DataContext dr = new DataClasses1DataContext();
                    var items = from values in dr.GetTable<branch>() where values.BranchID == comboBox1.Text select values;

                    foreach (var i in items)
                    {
                        label10.Text = i.BranchID;
                        BID = i.BranchID;
                        label22.Text = i.Address;


                    }
                }

                if (comboBox2.SelectedIndex > -1)
                {
                    //Get the Customers
                    DataClasses1DataContext dr = new DataClasses1DataContext();
                    var items = from values in dr.GetTable<customer>() where values.CustomerID == comboBox2.Text select values;

                    foreach (var i in items)
                    {
                        CID = i.CustomerID;
                        label9.Text = i.CustomerName;
                        label13.Text = i.NIC;
                        label29.Text = i.Address;
                        label24.Text = i.Income;
                        label27.Text = i.Age.ToString();
                        label25.Text = i.Gender;
                    }
                }
                if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1)
                {
                    label16.Enabled = true;
                    comboBox3.Enabled = true;
                    label19.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    textBox1.Enabled = true;
                    button4.Enabled = true;
                    button3.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Edit or Delete the account
            if (comboBox6.Text == "")
            {
                MessageBox.Show("Select One input");
            }
            else
            {
                if (comboBox6.Text == "Edit")
                {
                    label47.Enabled = true;
                    label44.Enabled = true;
                    textBox2.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    button5.Text = "Edit";
                    button5.Enabled = true;
                    button6.Enabled = true;
                    comboBox7.Enabled = true;
                }

                else if (comboBox6.Text == "Delete")
                {
                    label47.Enabled = false;
                    label44.Enabled = false;
                    textBox2.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    button5.Text = "Delete";
                    button5.Enabled = true;
                    button6.Enabled = true;
                    comboBox7.Enabled = false;
                }

                else
                {
                    MessageBox.Show("System Error");
                }
            }
        }

        private void comboBox7_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                //Delete or Edit the account 
                DataClasses1DataContext dr = new DataClasses1DataContext();
                var items = from values in dr.GetTable<account>() where values.AccountNumber == comboBox7.Text select values;

                foreach (var i in items)
                {
                    label32.Text = i.BranchID;
                    BID = i.BranchID;
                    CID = i.CustomerID;
                    AccountType = i.AccountType;
                    IntrestRate = i.IntrestRate;
                    Date = i.DateAccountOpen;
                    AccountID = i.AccountNumber;

                    label36.Text = i.CustomerID;
                    AccountType = i.AccountType;
                    label47.Text = i.AccountType;

                    label44.Text = i.IntrestRate;
                    textBox2.Text = i.AccountBalance.ToString();
                    dateTimePicker2.Value = DateTime.Parse(i.DateAccountOpen);
                }


                //----------------------Get Branch and Customer Details---------------------------------

                DataClasses1DataContext dr2 = new DataClasses1DataContext();
                var item1 = from values in dr.GetTable<customer>() where values.CustomerID == CID select values;
                var item2 = from values in dr.GetTable<branch>() where values.BranchID == BID select values;


                foreach (var i in item2)
                {
                    label34.Text = i.Name;
                }
                foreach (var j in item1)
                {
                    label38.Text = j.CustomerName;
                    label40.Text = j.NIC;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
                {
                if (button5.Text == "Edit" && comboBox7.Text != "")
                {
                
                    AccountBalance = float.Parse(textBox2.Text);
                    Date = dateTimePicker2.Value.ToString("yyyy/MM/dd");



                    DataClasses1DataContext dr = new DataClasses1DataContext();
                    account a = dr.accounts.Single(id => id.AccountNumber == AccountID);
                    a.AccountNumber = AccountID;
                    a.CustomerID = CID;
                    a.BranchID = BID;
                    a.AccountBalance = AccountBalance;
                    a.IntrestRate = IntrestRate;
                    a.DateAccountOpen = Date;
                    a.AccountType = AccountType;
                    dr.SubmitChanges();
                    MessageBox.Show("Data edited Succcessfully");

                    // TODO: This line of code loads data into the 'bank_SystemDataSet5.account' table. You can move, or remove it, as needed.
                    this.accountTableAdapter.Fill(this.bank_SystemDataSet5.account);

                    comboBox7.Items.Clear();

                    //Get all customer id to combobox3 to edit/delete branch
                    var items = from i in dr.GetTable<account>() select i;

                    foreach (var i in items)
                    {
                        comboBox7.Items.Add(i.AccountNumber.ToString());
                    }

                    comboBox6.Text = "";
                    textBox2.Text = "";
                    label44.Text = "";
                    dateTimePicker2.Value = DateTime.Today;
                    comboBox7.Text = "";
                    label32.Text = "";
                    label34.Text = "";
                    label36.Text = "";
                    label38.Text = "";
                    label40.Text = "";

                    label47.Enabled = false;
                    label44.Enabled = false;
                    textBox2.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    comboBox7.Enabled = false;


                }
                else if (button5.Text == "Delete" && comboBox7.Text != "")
                {
                    CID = comboBox3.Text;

                    DialogResult result = MessageBox.Show("Are You sure want to delete it ?", "Conformation", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        DataClasses1DataContext dr = new DataClasses1DataContext();
                        account a = dr.accounts.Single(id => id.AccountNumber == AccountID);
                        dr.accounts.DeleteOnSubmit(a);
                        dr.SubmitChanges();
                        MessageBox.Show("Data deleted Succcessfully");

                        // TODO: This line of code loads data into the 'bank_SystemDataSet5.account' table. You can move, or remove it, as needed.
                        this.accountTableAdapter.Fill(this.bank_SystemDataSet5.account);

                        constructors(); 

                        comboBox7.Items.Clear();

                        //Get all branch id to combobox2 to edit/delete branch
                        var items = from i in dr.GetTable<account>() select i;

                        foreach (var i in items)
                        {
                            comboBox7.Items.Add(i.AccountNumber.ToString());
                        }

                        comboBox6.Text = "";
                        textBox2.Text = "";
                        label44.Text = "";
                        dateTimePicker2.Value = DateTime.Today;
                        comboBox7.Text = "";
                        label32.Text = "";
                        label34.Text = "";
                        label36.Text = "";
                        label38.Text = "";
                        label40.Text = "";

                        label47.Enabled = false;
                        label44.Enabled = false;
                        textBox2.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        comboBox7.Enabled = false;
                    }

                }
                else
                {
                    MessageBox.Show("Select the Account Number");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label47.Text = "";
            textBox2.Text = "";
            label44.Text = "";
            dateTimePicker2.Value = DateTime.Today;
            comboBox7.Text = "";
            label32.Text = "";
            label34.Text = "";
            label36.Text = "";
            label38.Text = "";
            label40.Text = "";

            label47.Enabled = false;
            label44.Enabled = false;
            textBox2.Enabled = false;
            dateTimePicker2.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            comboBox7.Enabled = false;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = dataGridView3.CurrentRow.Cells[0].Value;
            comboBox7.Text = result.ToString();
            tabControl1.SelectedIndex = 3;
        }

        private void constructors()
        {
            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");

            dateTimePicker1.MaxDate = DateTime.Today;
            //Get the Last Customer ID

            try
            {


                comboBox2.Items.Clear();

                //Add the all customer ids to combobox2 to edit/delete the banch

                DataClasses1DataContext dr1 = new DataClasses1DataContext();
                var items = from i in dr1.GetTable<customer>() select i;

                foreach (var a in items)
                {
                    comboBox2.Items.Add(a.CustomerID.ToString());
                }



                comboBox1.Items.Clear();

                //Add the all customer ids to combobox2 to edit/delete the banch

                var item = from i in dr1.GetTable<branch>() select i;

                foreach (var b in item)
                {
                    comboBox1.Items.Add(b.BranchID.ToString());
                }


                //Get the Last Account ID

                //Get the Last account number

                DataClasses1DataContext dr = new DataClasses1DataContext();
                int  id = (from t in dr.GetTable<account>() select t.ID).Max();
                
                DataClasses1DataContext dr3= new DataClasses1DataContext();

                var ac = from i in dr3.GetTable<account>() where i.ID == id select i;


                string acid="";

                foreach (var j in ac)
                {
                    acid = j.AccountNumber.ToString();
                }


                ID1 = ((int.Parse(acid.Substring(5, 8))) + 1).ToString();
                label16.Text = ID1;

                comboBox7.Items.Clear();

                //Add the all customer ids to combobox2 to edit/delete the banch

                DataClasses1DataContext dr2 = new DataClasses1DataContext();
                var items1 = from i in dr2.GetTable<account>() select i;

                foreach (var a in items1)
                {
                    comboBox7.Items.Add(a.AccountNumber.ToString());
                }


            }
            catch (InvalidOperationException)
            {
                ID1 = "11111111";
            }
         /*  catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           */ 
            // TODO: This line of code loads data into the 'bank_SystemDataSet5.account' table. You can move, or remove it, as needed.
            this.accountTableAdapter.Fill(this.bank_SystemDataSet5.account);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
