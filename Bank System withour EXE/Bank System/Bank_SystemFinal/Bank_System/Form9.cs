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
    public partial class Form9 : Form
    {
        bool Plogin;
        public Form9()
        {
            InitializeComponent();
        }

        public Form9(bool plogin)
        {
            InitializeComponent();
            Plogin = plogin;
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void CrystalReport21_InitReport(object sender, EventArgs e)
        {

        }

        private void Report_11_InitReport(object sender, EventArgs e)
        {

        }
    }
}
