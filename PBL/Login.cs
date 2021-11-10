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
            string Login_Email = customText1.Texts;
            string Login_Password = customText2.Texts;
            SqlConnection Wire_2 = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PBL; Integrated Security = True;"); // Create a local database called PBL and inside a table Called USER_ACCOUNTS Parameters Below //
            Wire_2.Open();
            SqlCommand check_if_account_is_valid = new SqlCommand("SELECT COUNT(*) FROM USER_ACCOUNTS WHERE EMAIL ='" + Login_Email + "' AND PASSWARD ='" + Login_Password + "';", Wire_2);
            int check_account_int = Convert.ToInt32(check_if_account_is_valid.ExecuteScalar());
            if (check_account_int == 0) { MessageBox.Show("Incorrect Password or Email", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error); Wire_2.Close(); }
            else
            {
                Form1 form = new Form1();
                this.Hide();
                form.ShowDialog();
                this.Close();
                Wire_2.Close();
            }
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
                SqlConnection Wire = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PBL; Integrated Security = True;"); // Create a local database called PBL and inside a table Called USER_ACCOUNTS Parameters Below //
                Wire.Open();
                SqlCommand check_Email_is_Available = new SqlCommand("SELECT COUNT(*) FROM USER_ACCOUNTS WHERE EMAIL = '" + Email + "';", Wire);
                int UserExist = Convert.ToInt32(check_Email_is_Available.ExecuteScalar());
                if (UserExist == 1) { MessageBox.Show("Email Is being used", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error); Wire.Close(); }
                else
                {
                    string query_1 = "INSERT INTO USER_ACCOUNTS VALUES(@FIRST_NAME, @LAST_NAME, @EMAIL, @GENDER, @CITY, @COUNTRY, @PASSWARD, @CONFIRMED_PASSWARD, @AGE);"; // Copy the Parameters [VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, INT];

                    SqlParameter SQL_FIRST_NAME_PARAMETER = new SqlParameter();
                    SQL_FIRST_NAME_PARAMETER.ParameterName = "@FIRST_NAME";
                    SQL_FIRST_NAME_PARAMETER.Value = First_Name;

                    SqlParameter SQL_LAST_NAME_PARAMETER = new SqlParameter();
                    SQL_LAST_NAME_PARAMETER.ParameterName = "@LAST_NAME";
                    SQL_LAST_NAME_PARAMETER.Value = Last_Name;

                    SqlParameter SQL_EMAIL_PARAMETER = new SqlParameter();
                    SQL_EMAIL_PARAMETER.ParameterName = "@EMAIL";
                    SQL_EMAIL_PARAMETER.Value = Email;

                    SqlParameter SQL_GENDER_PARAMETER = new SqlParameter();
                    SQL_GENDER_PARAMETER.ParameterName = "@GENDER";
                    SQL_GENDER_PARAMETER.Value = Gender;

                    SqlParameter SQL_CITY_PARAMETER = new SqlParameter();
                    SQL_CITY_PARAMETER.ParameterName = "@CITY";
                    SQL_CITY_PARAMETER.Value = City;

                    SqlParameter SQL_COUNTRY_PARAMETER = new SqlParameter();
                    SQL_COUNTRY_PARAMETER.ParameterName = "@COUNTRY";
                    SQL_COUNTRY_PARAMETER.Value = Country;

                    SqlParameter SQL_PASSWORD_PARAMETER = new SqlParameter();
                    SQL_PASSWORD_PARAMETER.ParameterName = "@PASSWARD";
                    SQL_PASSWORD_PARAMETER.Value = Password;

                    SqlParameter SQL_CONFIRMED_PASSWORD_PARAMETER = new SqlParameter();
                    SQL_CONFIRMED_PASSWORD_PARAMETER.ParameterName = "@CONFIRMED_PASSWARD";
                    SQL_CONFIRMED_PASSWORD_PARAMETER.Value = Confirmed_Password;

                    SqlParameter SQL_AGE_PARAMETER = new SqlParameter();
                    SQL_AGE_PARAMETER.ParameterName = "@AGE";
                    SQL_AGE_PARAMETER.Value = Age;

                    SqlCommand Execute = new SqlCommand(query_1, Wire);
                    Execute.Parameters.Add(SQL_FIRST_NAME_PARAMETER);
                    Execute.Parameters.Add(SQL_LAST_NAME_PARAMETER);
                    Execute.Parameters.Add(SQL_EMAIL_PARAMETER);
                    Execute.Parameters.Add(SQL_GENDER_PARAMETER);
                    Execute.Parameters.Add(SQL_CITY_PARAMETER);
                    Execute.Parameters.Add(SQL_COUNTRY_PARAMETER);
                    Execute.Parameters.Add(SQL_PASSWORD_PARAMETER);
                    Execute.Parameters.Add(SQL_CONFIRMED_PASSWORD_PARAMETER);
                    Execute.Parameters.Add(SQL_AGE_PARAMETER);
                    Execute.ExecuteNonQuery();
                    Form1 form = new Form1();
                    Wire.Close();
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                }
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
