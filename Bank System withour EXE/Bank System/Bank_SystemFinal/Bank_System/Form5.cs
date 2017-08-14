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
    public partial class Form5 : Form
    {
        bool Plogin;
        DateTime today;
        string CID="";
        string Name="";
        Int32 Age;
        string Gender;
        string Address;
        string NIC;
        string Income;
        bool niccheck=false;
        bool back = false;
        public Form5()
        {
            InitializeComponent();
            this.labelsf5();

            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");

            construtors();
        }

        public Form5(bool plogin)
        {
            InitializeComponent();
            Plogin = plogin;
            this.labelsf5();

            construtors();

            comboBox3.Text = "achsuthan";
        }

        public Form5(bool plogin,string ID,bool pback)
        {
            InitializeComponent();
            Plogin = plogin;
            this.labelsf5();

            construtors();

            CID = ID;
            back = pback;
            comboBox3.Text = CID;
            tabControl1.SelectedIndex = 2;
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bank_SystemDataSet2.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter1.Fill(this.bank_SystemDataSet2.customer);
           

            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Plogin = false;
            Form1 f1 = new Form1(Plogin);
            f1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Plogin == true && back == true)
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

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            this.label8.Text = time.ToString("hh:mm:ss");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label11.Text = "";
            label12.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            CID = label2.Text;
            NICCheck();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
            NIC = textBox2.Text;
            Address = textBox3.Text;
            Income = comboBox1.Text;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || niccheck==false)
            {
                MessageBox.Show("Check your all Inputs ");
            }

            else
            {
                try
                {
                    using (DataClasses1DataContext dr = new DataClasses1DataContext())
                    {
                        customer c = new customer();
                        c.CustomerID = CID;
                        c.CustomerName = Name;
                        c.Address = Address;
                        c.NIC = NIC;
                        c.Gender = Gender;
                        c.Age = Age;
                        c.Income = Income;
                        dr.customers.InsertOnSubmit(c);
                        dr.SubmitChanges();
                        MessageBox.Show("Data inserted Succcessfully");
                    }

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    label2.Text = "";
                    comboBox1.Text = "";
                    label11.Text = "";
                    label12.Text = "";

                    construtors();

                    // TODO: This line of code loads data into the 'bank_SystemDataSet2.customer' table. You can move, or remove it, as needed.
                    this.customerTableAdapter1.Fill(this.bank_SystemDataSet2.customer);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
            
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            NIC = this.textBox2.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label20.Text = "";
            label22.Text = "";
            textBox6.Text = "";
            comboBox4.Text = "";

            comboBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            label20.Enabled = false;
            label22.Enabled = false;
            textBox6.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            comboBox4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NIC = textBox5.Text;

            label20.Text = Gender;
            label22.Text = Age.ToString();

            if (button5.Text == "Edit" && comboBox3.Text != "" )
            {

                
                Name = textBox4.Text;
                Address = textBox6.Text;
                CID = comboBox3.Text;
                NIC = textBox5.Text;

                Income = comboBox4.Text;

                try
                {

                    DataClasses1DataContext dr = new DataClasses1DataContext();
                    customer c = dr.customers.Single(id => id.CustomerID == CID);
                    c.CustomerID = CID;
                    c.CustomerName = Name;
                    c.NIC = NIC;
                    c.Address = Address;
                    c.Gender = Gender;
                    c.Age = Age;
                    c.Income = Income;
                    dr.SubmitChanges();
                    MessageBox.Show("Data edited Succcessfully");

                    // TODO: This line of code loads data into the 'bank_SystemDataSet2.customer' table. You can move, or remove it, as needed.
                    this.customerTableAdapter1.Fill(this.bank_SystemDataSet2.customer);


                    comboBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    label20.Text = "";
                    label22.Text = "";
                    textBox6.Text = "";
                    comboBox4.Text = "";

                    comboBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    label20.Enabled = false;
                    label22.Enabled = false;
                    textBox6.Enabled = false;
                    comboBox4.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (button5.Text == "Delete" && comboBox2.Text != "")
            {
                CID = comboBox3.Text;

                DialogResult result = MessageBox.Show("Are You sure want to delete it ?", "Conformation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DataClasses1DataContext dr = new DataClasses1DataContext();
                        customer c = dr.customers.Single(id => id.CustomerID == CID);
                        dr.customers.DeleteOnSubmit(c);
                        dr.SubmitChanges();
                        MessageBox.Show("Data deleted Succcessfully");

                        

                        construtors();
                    }
                    catch (Exception )
                    {
                        MessageBox.Show("First Delete the Account");
                    }
                    construtors();

                    comboBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    label20.Text = "";
                    label22.Text = "";
                    textBox6.Text = "";
                    comboBox4.Text = "";

                    comboBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    label20.Enabled = false;
                    label22.Enabled = false;
                    textBox6.Enabled = false;
                    comboBox4.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("Check all inputs");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Edit or Delete the customer
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Select One input");
            }
            else
            {
                if (comboBox2.Text == "Edit")
                {
                    comboBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    label20.Enabled = true;
                    label22.Enabled = true;
                    textBox6.Enabled = true;
                    comboBox4.Enabled = true;
                    button5.Text = "Edit";
                    button5.Enabled = true;
                    button6.Enabled = true;
                }

                else if (comboBox2.Text == "Delete")
                {
                    comboBox3.Enabled = true;
                    button5.Text = "Delete";
                    button5.Enabled = true;
                    button6.Enabled = true;
                }

                else
                {
                    MessageBox.Show("System Error");
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                CID = comboBox3.Text;
                //Delete or Edit the customer 
                DataClasses1DataContext dr = new DataClasses1DataContext();
                var items = from values in dr.GetTable<customer>() where values.CustomerID == comboBox3.Text select values;

                foreach (var i in items)
                {
                    textBox4.Text = i.CustomerName;
                    textBox5.Text = i.NIC;
                    label20.Text = i.Gender;
                    label22.Text = i.Age.ToString();
                    textBox6.Text = i.Address;
                    comboBox4.Text = i.Income;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = dataGridView1.CurrentRow.Cells[0].Value;
            comboBox3.Text = result.ToString();
            tabControl1.SelectedIndex = 2;
        }

        private void construtors()
        {
            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");


            //Get the Last Customer ID

            try
            {
                DataClasses1DataContext dr = new DataClasses1DataContext();
                var branch = (from t in dr.GetTable<customer>() orderby t.CustomerID descending select t.CustomerID).First();

                CID = ((int.Parse(branch)) + 1).ToString();
                label2.Text = CID;


                comboBox3.Items.Clear();

                //Add the all customer ids to combobox3 to edit/delete the banch

                DataClasses1DataContext dr1 = new DataClasses1DataContext();
                var items = from i in dr1.GetTable<customer>() select i;

                foreach (var a in items)
                {
                    comboBox3.Items.Add(a.CustomerID.ToString());
                }


            }
            catch (InvalidOperationException)
            {
                label2.Text = "111111";
                CID = "111111";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // TODO: This line of code loads data into the 'bank_SystemDataSet2.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter1.Fill(this.bank_SystemDataSet2.customer);
           

        }

        private void labelsf5()
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

        private void NICCheck()
        {
            if (NIC.Count() == 10)
            {
                try
                {
                    if (NIC.Substring(9).Equals("V") || NIC.Substring(9).Equals("X") || NIC.Substring(9).Equals("x") || NIC.Substring(9).Equals("v"))
                    {
                        int year = int.Parse(19 + NIC.Substring(0, 2));
                        Age = 2016 - year;
                        label12.Text = "" + (2016 - year);
                        int total = int.Parse(NIC.Substring(2, 3));
                        niccheck = true;

                        if (total > 500 && total < 866)
                        {
                            Gender = "Female";
                            label11.Text = Gender;
                            niccheck = true;
                        }
                        else if ((total < 500 || total > 0) && total < 366)
                        {
                            Gender = "Male";
                            label11.Text = Gender;
                            niccheck = true;
                        }

                        else
                        {
                            MessageBox.Show("Check your NIC number ");
                            niccheck = false;
                            label11.Text = "";
                            label12.Text = "";
                        }

                        if (niccheck == true)
                        {
                            DataClasses1DataContext dr = new DataClasses1DataContext();
                            var item = from i in dr.GetTable<customer>() select i.NIC;

                            if (item.Count() > 0)
                            {
                                niccheck = false;
                                MessageBox.Show("NIC number is already there");
                            }
                            else
                            {
                                niccheck = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Check Your last charecter");
                        niccheck = false;

                        label11.Text = "";
                        label12.Text = "";
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Check your input charecter formate");
                }

            }
            else
            {
                MessageBox.Show("Check your NIC input");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            NIC = this.textBox5.Text;
        }

        private void textBox5_Leave_1(object sender, EventArgs e)
        {

        }

    }
}
