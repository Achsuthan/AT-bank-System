using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bank_System.testTableAdapters;

namespace Bank_System
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            comboBox1.Items.Clear();

            //Add the all customer ids to combobox1 to get the report 

            DataClasses1DataContext dr1 = new DataClasses1DataContext();
            var items = from i in dr1.GetTable<customer>() select i;

            foreach (var a in items)
            {
                comboBox1.Items.Add(a.CustomerID.ToString());
            }
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Report3 rep = new Report3();
            test ds = new test();

            accountTableAdapter ct = new accountTableAdapter();
            ct.Fill(ds.account);
            rep.SetDataSource(ds);
            rep.SetParameterValue("value2", comboBox1.SelectedItem.ToString());
            crystalReportViewer1.ReportSource = rep;
        }
    }
}
