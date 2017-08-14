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
    public partial class Form2 : Form
    {
        bool Plogin;
        DateTime today;
        public Form2()
        {
            InitializeComponent();

            this.labelsf2();

            //----------------------------set the time and date----------------------------
            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");

        }
        public Form2(bool plogin)
        {
            InitializeComponent();
            Plogin=plogin;

            this.labelsf2();

            

            //set the time and date 
            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(Plogin);
            f1.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            this.labelsf2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Plogin = false;
            Form1 f1 = new Form1(Plogin);
            f1.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            this.label8.Text = time.ToString("hh:mm:ss");
        }

        private void labelsf2()
        {

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;

            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
