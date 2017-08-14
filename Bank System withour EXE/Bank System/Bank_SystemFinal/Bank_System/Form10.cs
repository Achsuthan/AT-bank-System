using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bank_System.testTableAdapters;
using Bank_System.DataSet1TableAdapters;

namespace Bank_System
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Report2 rep = new Report2();
            DataSet1 ds = new DataSet1();

            DataTable1TableAdapter ct = new DataTable1TableAdapter();
            ct.Fill(ds.DataTable1);
            rep.SetDataSource(ds);
            rep.SetParameterValue("value", comboBox1.SelectedItem.ToString());
            crystalReportViewer1.ReportSource = rep;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
