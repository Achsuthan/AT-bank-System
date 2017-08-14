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
    public partial class Form1 : Form
    {
        bool LoginStatus;
        DateTime today;
        public Form1()
        {
            InitializeComponent();

            this.labelsf1();

            //---------------------------set the time and date-----------------------------
            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");

            //--------------------------check the logout button----------------------------
            if (LoginStatus == false)
                button1.Enabled = false;
            else
                button1.Enabled = true;



            toolTip1.SetToolTip(label1, "Login Page");
            toolTip1.SetToolTip(label2, "Branch Page");
            toolTip1.SetToolTip(label3, "Customer Page");
            toolTip1.SetToolTip(label4, "Account Page");
            toolTip1.SetToolTip(label5, "Database Page");
            toolTip1.SetToolTip(label6, "Developer Page");
           
        }

        public Form1(bool plogin)
        {
            
            InitializeComponent();
            LoginStatus = plogin;
            this.labelsf1();

            //----------------------------set the time and date---------------------------- 
            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");

            //------------------------check the logout button-------------------------------
            if (LoginStatus == false)
                button1.Enabled = false;
            else
                button1.Enabled = true;

            toolTip1.SetToolTip(label1, "Login Page");
            toolTip1.SetToolTip(label2, "Branch Page");
            toolTip1.SetToolTip(label3, "Customer Page");
            toolTip1.SetToolTip(label4, "Account Page");
            toolTip1.SetToolTip(label5, "Database Page");
            toolTip1.SetToolTip(label6, "Developer Page");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;


            this.labelsf1();
            
            //-----------------------------set the time and date----------------------------- 
            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");

            //------------------------------check the logout button----------------------------
            if (LoginStatus == false)
                button1.Enabled = false;
            else
                button1.Enabled = true;
             
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(LoginStatus);
            f2.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            if (LoginStatus == true)
            {
                Form7 f7 = new Form7(LoginStatus);
                f7.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You can't access this\n Login first");
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            if (LoginStatus != true)
            {
                Form3 f3 = new Form3(LoginStatus);
                f3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are already Loged in");
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            if (LoginStatus == true)
            {
                Form6 f6 = new Form6(LoginStatus);
                f6.Show();
                this.Hide();
            }
            else
                MessageBox.Show("You can't access this\n Login first");
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            if (LoginStatus == true)
            {
                Form4 f4 = new Form4(LoginStatus);
                f4.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You can't access this\n Login first");
            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            if (LoginStatus == true)
            {
                Form5 f5 = new Form5(LoginStatus);
                f5.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You can't access this\n Login first");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginStatus = false;
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            this.label8.Text = time.ToString("hh:mm:ss");
        }

        private void labelsf1()
        {
            label1.Text = "        ";
            label2.Text = "        ";
            label3.Text = "        ";
            label4.Text = "        ";
            label5.Text = "        ";
            label6.Text = "        ";
            label7.Text = "        ";
            label8.Text = "        ";

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;

            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;

            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;

            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f4 = new Form6(LoginStatus);
            f4.Show();
            this.Hide();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }
    }
}
