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
    public partial class Form7 : Form
    {
        DateTime today;
        bool Plogin;
        public Form7()
        {
            InitializeComponent();
            this.labelsf7();

            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");
        }

        public Form7(bool plogin)
        {
            InitializeComponent();
            Plogin = plogin;

            this.labelsf7();

            today = DateTime.Today;
            timer1.Start();
            label7.Text = "" + today.ToString("D");
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'bank_SystemDataSet10.intrest' table. You can move, or remove it, as needed.
                this.intrestTableAdapter.Fill(this.bank_SystemDataSet10.intrest);
                // TODO: This line of code loads data into the 'bank_SystemDataSet8.account' table. You can move, or remove it, as needed.
                this.accountTableAdapter.Fill(this.bank_SystemDataSet8.account);
                // TODO: This line of code loads data into the 'bank_SystemDataSet7.customer' table. You can move, or remove it, as needed.
                this.customerTableAdapter.Fill(this.bank_SystemDataSet7.customer);
                // TODO: This line of code loads data into the 'bank_SystemDataSet6.branch' table. You can move, or remove it, as needed.
                this.branchTableAdapter.Fill(this.bank_SystemDataSet6.branch);
                this.labelsf7();
                this.FormBorderStyle = FormBorderStyle.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void labelsf7()
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

        private void button2_Click(object sender, EventArgs e)
        {
            Plogin = false;
            Form1 f1 = new Form1(Plogin);
            f1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1=new Form1(Plogin);
            f1.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = dataGridView1.CurrentRow.Cells[0].Value;
            Form4 f4 = new Form4(Plogin, result.ToString(), true);
            f4.Show();
            this.Close();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = dataGridView2.CurrentRow.Cells[0].Value;
            Form5 f5 = new Form5(Plogin, result.ToString(), true);
            f5.Show();
            this.Close();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = dataGridView3.CurrentRow.Cells[0].Value;
            Form6 f6 = new Form6(Plogin, result.ToString(), true);
            f6.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(Plogin);
            f8.Show();
            this.Close();
        }
    }
}
