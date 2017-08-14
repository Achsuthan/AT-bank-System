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
    public partial class Form8 : Form
    {
        bool Plogin;
        Form9 f9;
        Form10 f10;
        Form11 f11;
        bool f9bool=false;
        bool f10bool=false;
        bool f11bool=false;
        public Form8()
        {
            InitializeComponent();
        }

        public Form8(bool plogin)
        {
            InitializeComponent();
            Plogin = plogin;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(Plogin);
            f7.Show();
            this.Close();
        }

        private void report1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void report2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(f10bool)
                f10.Close();
            if(f11bool)
                f11.Close();
            f9 = new Form9();
            f9.MdiParent = this;
            f9.Show();
            f9bool = true;
            
        }

        private void report2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(f9bool)
                f9.Close();
            if(f11bool)
                f11.Close();
            f10 = new Form10();
            f10.MdiParent=this;
            f10.Show();
            f10bool = true;
            
        }

        private void report3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(f9bool)
                f9.Close();
            if(f10bool)
                f10.Close();
            f11 = new Form11();
            f11.MdiParent = this;
            f11.Show();
            f11bool = true;
        }
    }
}
