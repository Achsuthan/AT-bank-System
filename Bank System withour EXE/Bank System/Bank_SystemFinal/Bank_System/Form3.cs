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
    public partial class Form3 : Form
    {
        bool Plogin;
        DateTime today;
        public Form3()
        {
            InitializeComponent();

            this.labelsf3();

            //set the time and date 
            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");
        }

        public Form3(bool plogin)
        {
            InitializeComponent();
            Plogin = plogin;

            this.labelsf3();
            
            //set the time and date 
            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            textBox2.PasswordChar = '*';
            this.labelsf3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(Plogin);
            f1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            this.label8.Text = time.ToString("hh:mm:ss");
        }


        private void labelsf3()
        {
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;

            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Check your Inputs");
            }

            else
            {
                try
                {
                    string username = textBox1.Text;
                    string password = textBox2.Text;

                    DataClasses1DataContext dr = new DataClasses1DataContext();
                    var user = from t in dr.GetTable<admin>() select t;



                    foreach (var b in user)
                    {
                        if (username == b.username && password == b.password)
                        {
                            Plogin = true;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            break;
                        }
                        else
                        {
                            Plogin = false;
                        }
                    }

                    if(Plogin==true)
                    {
                        Form1 f1 = new Form1(Plogin);
                        f1.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Check your Username and Password");
                        Plogin = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
