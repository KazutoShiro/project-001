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

namespace PBL
{
    public partial class Profile : Form
    {
        private string userEmail;

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
            catch(FormatException) { AboutMeTxt.Text = "(EDIT)"; }
            if (AboutMeTxt.Text == string.Empty) { AboutMeTxt.Text = "(EDIT)"; } 

            try { EducationTxt.Text = Convert.ToString(Execute_User_Data_Profile["EDUCATION"]); }
            catch(FormatException) { EducationTxt.Text = "(EDIT)"; }
            if (EducationTxt.Text == string.Empty) { EducationTxt.Text = "(EDIT)"; }

            try { WorkTxt.Text = Convert.ToString(Execute_User_Data_Profile["WORK"]); }
            catch(FormatException) { WorkTxt.Text = "(EDIT)"; }
            if (WorkTxt.Text == string.Empty) { WorkTxt.Text = "(EDIT)"; }

            try { SkillsTxt.Text = Convert.ToString(Execute_User_Data_Profile["SKILLS"]); }
            catch(FormatException) { SkillsTxt.Text = "(EDIT)"; }
            if (SkillsTxt.Text == string.Empty) { SkillsTxt.Text = "(EDIT)"; }

            try { JobTitlLbl.Text = Convert.ToString(Execute_User_Data_Profile["JOB_TITLE"]); }
            catch(FormatException) { JobTitlLbl.Text = "(EDIT)"; }
            if (JobTitlLbl.Text == string.Empty) { JobTitlLbl.Text = "(EDIT)"; }
            Execute_User_Data_Profile.Close();
        }

        private void EditProfileBTN_Click(object sender, EventArgs e)
        {
            JOBTXTBX.Text = JobTitlLbl.Text;
            ABOUTTXTBX.Text = AboutMeTxt.Text;
            EDUTXTBX.Text = EducationTxt.Text;
            WORKTXTBX.Text = WorkTxt.Text;
            SkillsTXTBX.Text = SkillsTxt.Text;

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

            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = PBL; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string profiledatastring = "UPDATE dbo.UserData SET ABOUT_ME = @ABT,EDUCATION = @EDU,WORK = @WRK,SKILLS = @SKL,JOB = @JOB WHERE EMAIL = @CurrentEmail;";
            SqlParameter updAbout = new SqlParameter("@ABT", ABOUTTXTBX.Text);
            SqlParameter updEducation = new SqlParameter("@EDU", EDUTXTBX.Text);
            SqlParameter updWork = new SqlParameter("@WRK", WORKTXTBX.Text);
            SqlParameter updSkills = new SqlParameter("@SKL", SkillsTXTBX.Text);
            SqlParameter updJob = new SqlParameter("@JOB", JOBTXTBX.Text);
            SqlParameter CurrentEmailParam = new SqlParameter("@CurrentEmail", userEmail);

            SqlCommand Execute = new SqlCommand(profiledatastring, connection);
            Execute.Parameters.Add(updAbout);
            Execute.Parameters.Add(updEducation);
            Execute.Parameters.Add(updWork);
            Execute.Parameters.Add(updSkills);
            Execute.Parameters.Add(updJob);
            Execute.Parameters.Add(CurrentEmailParam);
            Execute.ExecuteNonQuery();
            connection.Close();

            JobTitlLbl.Text = JOBTXTBX.Text;
            AboutMeTxt.Text = ABOUTTXTBX.Text;
            EducationTxt.Text = EDUTXTBX.Text;
            WorkTxt.Text = WORKTXTBX.Text;
            SkillsTxt.Text = SkillsTXTBX.Text;

            SaveChangesBTN.Visible = false;
            CancelBTN.Visible = false;
            JOBTXTBX.Visible = false;
            ABOUTTXTBX.Visible = false;
            EDUTXTBX.Visible = false;
            WORKTXTBX.Visible = false;
            SkillsTXTBX.Visible = false;
            EditProfileBTN.Visible = true;
        }
    }
}
