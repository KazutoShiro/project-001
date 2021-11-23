using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace PBL
{
    public partial class Job_Reviews : UserControl
    {
        public Job_Reviews()
        {
            InitializeComponent();
        }

        private string First_Name_Private = "";
        private string Last_Name_Private = "";
        private string Comment_Private = "";
        private int rating_value_Private = 0;
        private Bitmap profile_pic_Private;
        private string Date_Private = "";

        public string First_Name { get => First_Name_Private; set { First_Name_Private = value; Firstname.Text = First_Name_Private; } }
        public string Last_Name { get => Last_Name_Private; set { Last_Name_Private = value; LastName.Text = Last_Name_Private; } }
        public string Comments { get => Comment_Private; set { Comment_Private = value;  Comment.Text = Comment_Private;  } }
        public int rating_value { get => rating_value_Private; 
        set 
           { 
                rating_value_Private = value; 
                bunifuRating1.Value = rating_value_Private; 
                bunifuRating1.ReadOnly = true;
            } 
         }
        public Bitmap profile_pic { get => profile_pic_Private; set { profile_pic_Private = value; pictureBox1.Image = profile_pic_Private; pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; } }
        public string Date { get => Date_Private; set { Date_Private = value; Dates.Text = Date_Private; } }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Job_Reviews_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
        }
    }
}
