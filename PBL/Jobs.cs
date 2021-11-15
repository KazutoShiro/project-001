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
    public partial class Jobs : Form
    {
        public Jobs()
        {
            InitializeComponent();
        }
       

        private void rButton3_Click(object sender, EventArgs e)
        {
            
            PostingJobs pj = new PostingJobs();
            pj.TopLevel = false;
            pj.Show();
            this.Controls.Add(pj);
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();



        }

        private void Jobs_Load(object sender, EventArgs e)
        {
            string [] CompanyNames;
            string[] CompanyField;
            string[] CompanyCity;
            string[] CompanyCountry;
            string[] postDates;
            using (PBLEntities context = new PBLEntities())
            {
                CompanyNames = context.JOB_POSTING.Select(r => r.COMPANYNAME).ToArray(); // System.Data.Entity.Core.EntityCommandExecutionException ?
                CompanyField = context.JOB_POSTING.Select(r => r.JOBFIELD).ToArray();
                CompanyCity = context.JOB_POSTING.Select(r =>  r.CITY).ToArray();
                CompanyCountry = context.JOB_POSTING.Select(r => r.COUNTRY).ToArray();
                postDates = context.JOB_POSTING.Select(r =>r.POSTDATE.ToString()).ToArray();
                
               
            }

           for(int i = 0; i< CompanyNames.Length; i++)
            {
                JobPosts jp = new JobPosts();
                jp.CompanyName1 = CompanyNames[i];
                jp.FieldName = CompanyField[i];
                jp.Location1 = CompanyCity[i] + ", " + CompanyCountry[i];
                jp.Date = postDates[i];
                panel1.Controls.Add(jp);
            }
                
            

        }
    }
}
