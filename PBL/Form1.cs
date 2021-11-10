using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private Form currentChild;
        private void Form1_Load(object sender, EventArgs e)
        {

            OpenChild(new Dashboard());

           
        }

        private void OpenChild(Form child)
        {
            if(currentChild != null)
            {
                currentChild.Close();
            }
            currentChild = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panel1.Controls.Add(child);
            panel1.Tag = child;
            child.BringToFront();
            child.Show();

        }

        //profile
        private void rButton1_Click(object sender, EventArgs e)
        {
            OpenChild(new Profile());
        }

       
        //exit
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

            OpenChild(new Dashboard());
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            OpenChild(new Jobs());

        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

       
}
