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
    public partial class Profile : Form
    {
        private string userEmail;
        public string Image_Location = "";
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            //initialize bunifu button
            userEmail = Login.currentEmail;
            SqlConnection Wire = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PBL; Integrated Security = True;");
            Wire.Open();
            SqlCommand check_if_account_has_user_data_records = new SqlCommand("SELECT COUNT(*) FROM USER_DATA_PROFILE WHERE EMAIL ='" + userEmail + "';", Wire);
            int check_account_records_int = Convert.ToInt32(check_if_account_has_user_data_records.ExecuteScalar());
            if (check_account_records_int == 0) 
            {
                SqlCommand account_create_user_data_records = new SqlCommand("INSERT INTO USER_DATA_PROFILE(EMAIL) VALUES('" + userEmail + "');", Wire);
                account_create_user_data_records.ExecuteNonQuery();
            }

            SqlCommand command_1 = new SqlCommand("SELECT FIRST_NAME, LAST_NAME, EMAIL, GENDER, CITY, COUNTRY, AGE FROM USER_ACCOUNTS WHERE EMAIL ='" + userEmail + "';", Wire);
            var Execute_User_Accounts = command_1.ExecuteReader();
            Execute_User_Accounts.Read();

            try { FirstNameLbl.Text = Convert.ToString(Execute_User_Accounts["FIRST_NAME"]); }
            catch(FormatException) { FirstNameLbl.Text = "(FIRST_NAME)"; }

            try { LastNameLbl.Text = Convert.ToString(Execute_User_Accounts["LAST_NAME"]); }
            catch(FormatException) { LastNameLbl.Text = "(LAST_NAME)"; }

            try { AgeLbl.Text = Convert.ToString(Execute_User_Accounts["AGE"]); }
            catch(FormatException) { AgeLbl.Text = "(AGE)"; }

            try { GenderLbl.Text = Convert.ToString(Execute_User_Accounts["GENDER"]); }
            catch(FormatException) { GenderLbl.Text = "(GENDER)"; }

            try { EmailTxt.Text = Convert.ToString(Execute_User_Accounts["EMAIL"]); }
            catch(FormatException) { EmailTxt.Text = "(EMAIL)"; }
            Execute_User_Accounts.Close();

            SqlCommand command_2 = new SqlCommand("SELECT ABOUT_ME, EDUCATION, WORK, SKILLS, JOB_TITLE, PROFILE_PICTURE FROM USER_DATA_PROFILE WHERE EMAIL ='" + userEmail + "';", Wire);
            var Execute_User_Data_Profile = command_2.ExecuteReader();
            Execute_User_Data_Profile.Read();

            try { AboutMeTxt.Text = Convert.ToString(Execute_User_Data_Profile["ABOUT_ME"]); }
            catch(FormatException) { AboutMeTxt.Text = string.Empty; }
            if (AboutMeTxt.Text == string.Empty) { AboutMeTxt.Text = "(EDIT)"; } 

            try { EducationTxt.Text = Convert.ToString(Execute_User_Data_Profile["EDUCATION"]); }
            catch(FormatException) { EducationTxt.Text = string.Empty; }
            if (EducationTxt.Text == string.Empty) { EducationTxt.Text = "(EDIT)"; }

            try { WorkTxt.Text = Convert.ToString(Execute_User_Data_Profile["WORK"]); }
            catch(FormatException) { WorkTxt.Text = string.Empty; }
            if (WorkTxt.Text == string.Empty) { WorkTxt.Text = "(EDIT)"; }

            try { SkillsTxt.Text = Convert.ToString(Execute_User_Data_Profile["SKILLS"]); }
            catch(FormatException) { SkillsTxt.Text = string.Empty; }
            if (SkillsTxt.Text == string.Empty) { SkillsTxt.Text = "(EDIT)"; }

            try { JobTitlLbl.Text = Convert.ToString(Execute_User_Data_Profile["JOB_TITLE"]); }
            catch(FormatException) { JobTitlLbl.Text = string.Empty; }
            if (JobTitlLbl.Text == string.Empty) { JobTitlLbl.Text = "(EDIT)"; }
            Execute_User_Data_Profile.Close();

            SqlCommand get_picture = new SqlCommand("SELECT PROFILE_PICTURE FROM USER_DATA_PROFILE WHERE EMAIL ='" + userEmail + "';", Wire);
            SqlDataAdapter SDA = new SqlDataAdapter(get_picture);
            DataSet DS = new DataSet();
            SDA.Fill(DS);
            if (DS.Tables[0].Rows.Count > 0) 
            {
                MemoryStream MS = new MemoryStream((byte[])DS.Tables[0].Rows[0]["PROFILE_PICTURE"]);
                pictureBox1.Image = new Bitmap(MS);
            }
            Wire.Close();
        }
       
        private void EditProfileBTN_Click(object sender, EventArgs e)
        {
            JOBTXTBX.Text = JobTitlLbl.Text;
            ABOUTTXTBX.Text = AboutMeTxt.Text;
            EDUTXTBX.Text = EducationTxt.Text;
            WORKTXTBX.Text = WorkTxt.Text;
            SkillsTXTBX.Text = SkillsTxt.Text;

            Change_Profile_Photo_BTN.Visible = true;
            SaveChangesBTN.Visible = true;
            CancelBTN.Visible = true;
            JOBTXTBX.Visible = true;
            ABOUTTXTBX.Visible = true;
            EDUTXTBX.Visible = true;
            WORKTXTBX.Visible = true;
            SkillsTXTBX.Visible = true;
            EditProfileBTN.Visible = false;
 
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Change_Profile_Photo_BTN.Visible = false;
            SaveChangesBTN.Visible = false;
            CancelBTN.Visible = false;
            JOBTXTBX.Visible = false;
            ABOUTTXTBX.Visible = false;
            EDUTXTBX.Visible = false;
            WORKTXTBX.Visible = false;
            SkillsTXTBX.Visible = false;
            EditProfileBTN.Visible = true;
        }

        private void SaveChangesBTN_Click(object sender, EventArgs e)
        {
            SqlConnection Wire_2 = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PBL; Integrated Security = True;");
            Wire_2.Open();

            string query_1 = "UPDATE USER_DATA_PROFILE SET ABOUT_ME = @ABOUT_ME_INPUT, EDUCATION = @EDUCATION_INPUT, WORK = @WORK_INPUT, SKILLS = @SKILLS_INPUT, JOB_TITLE = @JOB_TITLE WHERE EMAIL ='" + userEmail + "';";

            SqlParameter ABOUT_ME_PARAMETER = new SqlParameter();
            ABOUT_ME_PARAMETER.ParameterName = "@ABOUT_ME_INPUT";
            ABOUT_ME_PARAMETER.Value = ABOUTTXTBX.Text;

            SqlParameter EDUCATION_PARAMETER = new SqlParameter();
            EDUCATION_PARAMETER.ParameterName = "@EDUCATION_INPUT";
            EDUCATION_PARAMETER.Value = EDUTXTBX.Text;

            SqlParameter WORK_PARAMETER = new SqlParameter();
            WORK_PARAMETER.ParameterName = "@WORK_INPUT";
            WORK_PARAMETER.Value = WORKTXTBX.Text;

            SqlParameter SKILLS_PARAMETER = new SqlParameter();
            SKILLS_PARAMETER.ParameterName = "@SKILLS_INPUT";
            SKILLS_PARAMETER.Value = SkillsTXTBX.Text;

            SqlParameter JOB_TITLE_PARAMETER = new SqlParameter();
            JOB_TITLE_PARAMETER.ParameterName = "@JOB_TITLE";
            JOB_TITLE_PARAMETER.Value = JOBTXTBX.Text;

            SqlCommand Execute = new SqlCommand(query_1, Wire_2);
            Execute.Parameters.Add(ABOUT_ME_PARAMETER);
            Execute.Parameters.Add(EDUCATION_PARAMETER);
            Execute.Parameters.Add(WORK_PARAMETER);
            Execute.Parameters.Add(SKILLS_PARAMETER);
            Execute.Parameters.Add(JOB_TITLE_PARAMETER);
            Execute.ExecuteNonQuery();

            SqlCommand command_3 = new SqlCommand("SELECT ABOUT_ME, EDUCATION, WORK, SKILLS, JOB_TITLE, PROFILE_PICTURE FROM USER_DATA_PROFILE WHERE EMAIL ='" + userEmail + "';", Wire_2);
            var Execute_User_Data_Profile_2 = command_3.ExecuteReader();
            Execute_User_Data_Profile_2.Read();

            try { JobTitlLbl.Text = Convert.ToString(Execute_User_Data_Profile_2["JOB_TITLE"]); }
            catch (FormatException) { JobTitlLbl.Text = string.Empty; }
            if (JobTitlLbl.Text == string.Empty) { JobTitlLbl.Text = "(EDIT)"; }

            try { AboutMeTxt.Text = Convert.ToString(Execute_User_Data_Profile_2["ABOUT_ME"]); }
            catch (FormatException) { AboutMeTxt.Text = string.Empty; }
            if (AboutMeTxt.Text == string.Empty) { AboutMeTxt.Text = "(EDIT)"; }

            try { EducationTxt.Text = Convert.ToString(Execute_User_Data_Profile_2["EDUCATION"]); }
            catch (FormatException) { EducationTxt.Text = string.Empty; }
            if (EducationTxt.Text == string.Empty) { EducationTxt.Text = "(EDIT)"; }

            try { WorkTxt.Text = Convert.ToString(Execute_User_Data_Profile_2["WORK"]); }
            catch (FormatException) { WorkTxt.Text = string.Empty; }
            if (WorkTxt.Text == string.Empty) { WorkTxt.Text = "(EDIT)"; }

            try { SkillsTxt.Text = Convert.ToString(Execute_User_Data_Profile_2["SKILLS"]); }
            catch (FormatException) { SkillsTxt.Text = string.Empty; }
            if (SkillsTxt.Text == string.Empty) { SkillsTxt.Text = "(EDIT)"; }
            Execute_User_Data_Profile_2.Close();
            Wire_2.Close();

            //JobTitlLbl.Text = JOBTXTBX.Text;
            //AboutMeTxt.Text = ABOUTTXTBX.Text;
            //EducationTxt.Text = EDUTXTBX.Text;
            //WorkTxt.Text = WORKTXTBX.Text;
            //SkillsTxt.Text = SkillsTXTBX.Text;

            Change_Profile_Photo_BTN.Visible = false;
            SaveChangesBTN.Visible = false;
            CancelBTN.Visible = false;
            JOBTXTBX.Visible = false;
            ABOUTTXTBX.Visible = false;
            EDUTXTBX.Visible = false;
            WORKTXTBX.Visible = false;
            SkillsTXTBX.Visible = false;
            EditProfileBTN.Visible = true;
        }

        private void Change_Profile_Photo_BTN_Click(object sender, EventArgs e)
        {
            Image_Location = "";
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choose an Image";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                Image_Location = Convert.ToString(OFD.FileName);
                pictureBox1.ImageLocation = Image_Location;
                byte[] byte_img = null;
                FileStream FS = new FileStream(Image_Location, FileMode.Open, FileAccess.Read);
                BinaryReader BR = new BinaryReader(FS);
                byte_img = BR.ReadBytes(Convert.ToInt32(FS.Length));

                SqlConnection Wire_3 = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PBL; Integrated Security = True;");
                Wire_3.Open();
                string query_2 = "UPDATE USER_DATA_PROFILE SET PROFILE_PICTURE = @PROFILE_PICTURE_INPUT WHERE EMAIL ='" + userEmail + "';";

                SqlParameter PROFILE_PICTURE_PARAMETER = new SqlParameter();
                PROFILE_PICTURE_PARAMETER.ParameterName = "@PROFILE_PICTURE_INPUT";
                PROFILE_PICTURE_PARAMETER.Value = byte_img;

                SqlCommand Execute_2 = new SqlCommand(query_2, Wire_3);
                Execute_2.Parameters.Add(PROFILE_PICTURE_PARAMETER);
                Execute_2.ExecuteNonQuery();
                Wire_3.Close();
            }
        }
    }
}
