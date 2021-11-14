using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            SqlConnection Wire = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PBL; Integrated Security = True;");
            Wire.Open();
            SqlCommand get_picture = new SqlCommand("SELECT PROFILE_PICTURE FROM USER_DATA_PROFILE WHERE EMAIL ='" + Login.currentEmail + "';", Wire);
            SqlDataAdapter SDA = new SqlDataAdapter(get_picture);
            DataSet DS = new DataSet();
            SDA.Fill(DS);
            if (DS.Tables[0].Rows.Count > 0)
            {
                try
                {
                    MemoryStream MS = new MemoryStream((byte[])DS.Tables[0].Rows[0]["PROFILE_PICTURE"]);
                    rButton1.BackgroundImage = new Bitmap(MS);
                }
                catch (System.InvalidCastException) { rButton1.BackgroundImage = new Bitmap("C:/Users/danielle meer/Documents/Programming_Projects/C#/School/PBL/PBL/bin/Images/profile_pic_placeholder.jfif"); }  // Go to PBL -> bin -> Images and click the address bar to replace the imagelocation
                rButton1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            Wire.Close();
        }


        private Form currentChild;
        private void Form1_Load(object sender, EventArgs e)
        {

            OpenChild(new Dashboard());

           
        }

        public void OpenChild(Form child)
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
