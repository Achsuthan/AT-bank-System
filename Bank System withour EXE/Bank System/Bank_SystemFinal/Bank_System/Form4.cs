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
    public partial class Form4 : Form
    {
        bool Plogin;
        DateTime today;
        string BID = "";

        string Name;
        string Address ;
        bool back=false;
        public Form4()
        {

            InitializeComponent();

            this.labelsf4();
            this.constructors();

            this.labelsf4();
        }

        public Form4(bool plogin)
        {
            InitializeComponent();

            Plogin = plogin;
            this.labelsf4();

            this.constructors();

        }

        public Form4(bool plogin,string Pid,bool pback)
        {
            InitializeComponent();

            Plogin = plogin;

            back = pback;
            this.labelsf4();

            this.constructors();


            comboBox2.Text = Pid;
            tabControl1.SelectedIndex = 2;
            BID = Pid;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Show the times

            DateTime time = DateTime.Now;
            this.label8.Text = time.ToString("hh:mm:ss");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bank_SystemDataSet.branch' table. You can move, or remove it, as needed.
            this.branchTableAdapter.Fill(this.bank_SystemDataSet.branch);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Plogin = false;
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();       
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (Plogin==true && back==true)
            {
                Form7 f7=new Form7(Plogin);
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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Add the Values to the data base 
            Name=textBox1.Text;
            Address = textBox2.Text;

            if(textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("Check your all inputs");
            }
            else
            {
                try
                {
                    using (DataClasses1DataContext dr = new DataClasses1DataContext())
                    {
                        branch b = new branch();
                        b.BranchID = BID;
                        b.Name = Name;
                        b.Address = Address;
                        dr.branches.InsertOnSubmit(b);
                        dr.SubmitChanges();
                        MessageBox.Show("Data inserted Succcessfully");
                    }

                    textBox1.Text = "";
                    textBox2.Text = "";
                    label2.Text = "";

                    constructors();

                    // TODO: This line of code loads data into the 'bank_SystemDataSet.branch' table. You can move, or remove it, as needed.
                    this.branchTableAdapter.Fill(this.bank_SystemDataSet.branch);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Edit or Delete the Branch
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select One input");
            }
            else
            {
                if (comboBox1.Text == "Edit")
                {
                    comboBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button5.Text = "Edit";
                }

                else if (comboBox1.Text == "Delete")
                {
                    comboBox2.Enabled = true;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button5.Text = "Delete";
                }

                else
                {
                    MessageBox.Show("System Error");
                }
            }
               
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Edit" && comboBox2.Text != "")
            {
                try
                {
                    Name = textBox3.Text;
                    Address = textBox4.Text;
                    BID = comboBox2.Text;
                    DataClasses1DataContext dr = new DataClasses1DataContext();
                    branch b = dr.branches.Single(id => id.BranchID == BID);
                    b.Name = Name;
                    b.Address = Address;
                    dr.SubmitChanges();
                    MessageBox.Show("Data edited Succcessfully");


                    // TODO: This line of code loads data into the 'bank_SystemDataSet.branch' table. You can move, or remove it, as needed.
                    this.branchTableAdapter.Fill(this.bank_SystemDataSet.branch);

                    comboBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";

                    comboBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (button5.Text == "Delete" && comboBox2.Text != "")
            {
                
                Name = textBox3.Text;
                Address = textBox4.Text;
                BID = comboBox2.Text;

                DialogResult result = MessageBox.Show("Are You sure want to delete it ?","Conformation",MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                   try
                    {

                        DataClasses1DataContext dr = new DataClasses1DataContext();
                        branch b = dr.branches.Single(id => id.BranchID == BID);
                        dr.branches.DeleteOnSubmit(b);
                        dr.SubmitChanges();
                        MessageBox.Show("Data deleted Succcessfully");

                        // TODO: This line of code loads data into the 'bank_SystemDataSet.branch' table. You can move, or remove it, as needed.
                        this.branchTableAdapter.Fill(this.bank_SystemDataSet.branch);


                        constructors();

                        comboBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";

                        comboBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("First Delete the Account");
                    }

                    
                }
                
            }
            else
            {
                MessageBox.Show("Select the Branch ID");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Delete or Edit the customer 
                DataClasses1DataContext dr = new DataClasses1DataContext();
                var items = from values in dr.GetTable<branch>() where values.BranchID == comboBox2.Text select values;

                foreach (var i in items)
                {
                    textBox3.Text = i.Name;
                    textBox4.Text = i.Address;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = dataGridView1.CurrentRow.Cells[0].Value;
            comboBox2.Text = result.ToString();
            tabControl1.SelectedIndex = 2;
            BID = result.ToString();
        }

        private void constructors()
        {
            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");

            //Get the Last Branch ID

            try
            {
                DataClasses1DataContext dr = new DataClasses1DataContext();
                var branch = (from t in dr.GetTable<branch>() orderby t.BranchID descending select t.BranchID).First();

                BID = ((int.Parse(branch)) + 1).ToString();
                label2.Text = BID;

                comboBox2.Items.Clear();

                //Add the all branch ids to combobox2 to edit/delete the banch

                DataClasses1DataContext dr1 = new DataClasses1DataContext();
                var items = from i in dr1.GetTable<branch>() select i;

                foreach (var a in items)
                {
                    comboBox2.Items.Add(a.BranchID.ToString());
                }


            }
            catch (InvalidOperationException)
            {
                label2.Text = "1111";
                BID = "1111";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void labelsf4()
        {
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;

            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

   

    }
}
