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
    public partial class JOB_DESCRIPTION_AND_REVIEWS : Form
    {
        public JOB_DESCRIPTION_AND_REVIEWS()
        {
            InitializeComponent();
            string[] First_Names_Array;
            string[] Last_Names_Array;
            string[] Comments_Array;
            int[] rating_values_Array;
            Bitmap[] Profile_pics_Array;
            string[] Date_Array;

            SqlConnection Wire = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PBL; Integrated Security = True;");
            Wire.Open();
            SqlCommand count_comments = new SqlCommand("SELECT COUNT(*) FROM REVIEW_PRACTICE;", Wire);
            int count_comments_int = Convert.ToInt32(count_comments.ExecuteScalar());
            First_Names_Array = new string[count_comments_int];
            Last_Names_Array = new string[count_comments_int];
            Comments_Array = new string[count_comments_int];
            rating_values_Array = new int[count_comments_int];
            Profile_pics_Array = new Bitmap[count_comments_int];
            Date_Array = new string[count_comments_int];

            for (int x = 1; x <= count_comments_int; ++x)
            {
                SqlCommand Read_Row = new SqlCommand("SELECT FIRST_NAME, LAST_NAME, RATING_VALUE, PROFILE_PICTURE, COMMENT, DATES FROM REVIEW_PRACTICE WHERE COMMENTNUMBER = " + Convert.ToString(x) + ";", Wire);
                var Execute_Read_Row = Read_Row.ExecuteReader();
                Execute_Read_Row.Read();

                try { First_Names_Array[x - 1] = Convert.ToString(Execute_Read_Row["FIRST_NAME"]); }
                catch (FormatException) { First_Names_Array[x - 1] = string.Empty; }
                if (First_Names_Array[x - 1] == string.Empty) { First_Names_Array[x - 1] = "[FIRST_NAME]"; }

                try { Last_Names_Array[x - 1] = Convert.ToString(Execute_Read_Row["LAST_NAME"]); }
                catch (FormatException) { Last_Names_Array[x - 1] = string.Empty; }
                if (Last_Names_Array[x - 1] == string.Empty) { Last_Names_Array[x - 1] = "[LAST_NAME]"; }

                try { Comments_Array[x - 1] = Convert.ToString(Execute_Read_Row["COMMENT"]); }
                catch (FormatException) { Comments_Array[x - 1] = string.Empty; }
                if (Comments_Array[x - 1] == string.Empty) { Comments_Array[x - 1] = "[COMMENT]"; }

                try { rating_values_Array[x - 1] = Convert.ToInt32(Execute_Read_Row["RATING_VALUE"]); }
                catch (FormatException) { rating_values_Array[x - 1] = -1; }
                if (rating_values_Array[x - 1] <= 0) { rating_values_Array[x - 1] = 1; }
                else if (rating_values_Array[x - 1] > 5) { rating_values_Array[x - 1] = 5; }

                try { Date_Array[x - 1] = Convert.ToString(Execute_Read_Row["DATES"]); }
                catch (FormatException) { Date_Array[x - 1] = string.Empty; }
                if (Date_Array[x - 1] == string.Empty) { Date_Array[x - 1] = "[DATE]"; }
                Execute_Read_Row.Close();

                SqlCommand get_pictures = new SqlCommand("SELECT PROFILE_PICTURE FROM REVIEW_PRACTICE WHERE COMMENTNUMBER = " + Convert.ToString(x) + ";", Wire);
                SqlDataAdapter SDA = new SqlDataAdapter(get_pictures);
                DataSet DS = new DataSet();
                SDA.Fill(DS);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        MemoryStream MS = new MemoryStream((byte[])DS.Tables[0].Rows[0]["PROFILE_PICTURE"]);
                        Bitmap temp_1 = new Bitmap(MS);
                        Profile_pics_Array[x - 1] = temp_1;
                        MS.Dispose();
                    }
                    catch (System.InvalidCastException) { Profile_pics_Array[x - 1] = Properties.Resources.default_profile; }
                    catch (System.ArgumentException) { Profile_pics_Array[x - 1] = Properties.Resources.default_profile; } 
                }
            }

            for (int y = 0; y < count_comments_int; ++y)
            {
                Job_Reviews comment_component = new Job_Reviews();
                comment_component.First_Name = First_Names_Array[y];
                comment_component.Last_Name = Last_Names_Array[y];
                comment_component.Comments = Comments_Array[y];
                comment_component.rating_value = rating_values_Array[y];
                comment_component.profile_pic = Profile_pics_Array[y];
                comment_component.Date = Date_Array[y];
                panel1.Controls.Add(comment_component);
            }
        }

        private void JOB_DESCRIPTION_AND_REVIEWS_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
