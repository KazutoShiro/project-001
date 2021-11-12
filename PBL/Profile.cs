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
            //initialize bunifu buttons


            userEmail = Login.currentEmail;

            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = PBL; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string queryString = "SELECT FIRST_NAME, LAST_NAME, EMAIL, GENDER, CITY, COUNTRY, AGE FROM dbo.USER_ACCOUNTS WHERE EMAIL = @CurrentEmail;";

            SqlParameter CurrentEmailParam = new SqlParameter("@CurrentEmail", userEmail);

            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.Add(CurrentEmailParam);
            var reader = command.ExecuteReader();
            reader.Read();//reads data from the sql select command
            string usrFrstNm = reader["FIRST_NAME"].ToString();
            string usrLstNm = reader["LAST_NAME"].ToString();
            string usrAge = reader["AGE"].ToString();
            string usrGndr = reader["GENDER"].ToString();
            string usrEml = reader["EMAIL"].ToString();
            //Displays the texts into the form profile
            FirstNameLbl.Text = usrFrstNm;
            LastNameLbl.Text = usrLstNm;
            AgeLbl.Text = usrAge;
            GenderLbl.Text = usrGndr;
            EmailTxt.Text = usrEml;
            reader.Close();

            string profiledatastring = "SELECT ABOUT_ME,EDUCATION,WORK,SKILLS,JOB FROM dbo.UserData WHERE EMAIL = @CurrentEmail;";
            
            CurrentEmailParam = new SqlParameter("@CurrentEmail", userEmail);
            command = new SqlCommand(profiledatastring, connection);
            command.Parameters.Add(CurrentEmailParam);
            reader = command.ExecuteReader();
            reader.Read();

            string usrAbout = reader["ABOUT_ME"].ToString();
            string usrEdu = reader["EDUCATION"].ToString();
            string usrWork = reader["WORK"].ToString();
            string usrSkills = reader["SKILLS"].ToString();
            string usrJob = reader["JOB"].ToString();

            if (usrAbout == string.Empty)
            {
                usrAbout = "(edit)";
            }
            if (usrEdu == string.Empty)
            {
                usrEdu = "(edit)";
            }
            if (usrWork == string.Empty)
            {
                usrWork = "(edit)";
            }
            if (usrSkills == string.Empty)
            {
                usrSkills = "(edit)";
            }
            if (usrJob == string.Empty)
            {
                usrJob = "(edit)";
            }

            AboutMeTxt.Text = usrAbout;
            EducationTxt.Text = usrEdu;
            WorkTxt.Text = usrWork;
            SkillsTxt.Text = usrSkills;
            JobTitlLbl.Text = usrJob;

            connection.Close();
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
