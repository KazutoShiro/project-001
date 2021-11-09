using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Sql;
using System.IO;

namespace PBL
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
                {
                    panel2.Hide();
                }
        private void rButton1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
        }

        private void rButton2_Click(object sender, EventArgs e)
        {
            string Last_Name = customText8.Texts;
            string First_Name = customText7.Texts;
            string Email = customText5.Texts;
            string Gender = customText3.Texts;
            string City = customText10.Texts;
            string Country = customText11.Texts;
            string Password = customText6.Texts;
            string Confirmed_Password = customText9.Texts;
            bool check_email_address = false;
            bool is_it_digits = false;
            try { MailAddress m = new MailAddress(Email); }
            catch (FormatException) { check_email_address = true; }
            try { int parsetest = Convert.ToInt32(customText4.Texts); }
            catch (FormatException) { is_it_digits = true; }
            if (Last_Name == string.Empty || First_Name == string.Empty || Email == string.Empty || Gender == string.Empty || City == string.Empty || Country == string.Empty || Password == string.Empty || Confirmed_Password == string.Empty || customText4.Texts == string.Empty) { MessageBox.Show("Please Complete the Form", "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (Password != Confirmed_Password) { MessageBox.Show("Confirmation Password does not Match", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if ( check_email_address == true) { MessageBox.Show("This is not a working email address", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error); } 
            else if (is_it_digits == true) { MessageBox.Show("Age input is not applicable", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else 
            {
                int Age = Convert.ToInt32(customText4.Texts);
                Form1 form = new Form1();
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Show();
        }

        private void customText8__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
