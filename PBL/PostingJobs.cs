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
    
    public partial class PostingJobs : Form
    {
        
        public PostingJobs()
        {
            InitializeComponent();

        }

        private void PostingJobs_Load(object sender, EventArgs e)
        {
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new PBLEntities();
            var post = new JOB_POSTING
            {
                COMPANYNAME = customText1.Texts,
                JOBFIELD = customText2.Texts,
                CITY = customText3.Texts,
                COUNTRY = customText4.Texts,
                SALARY = int.Parse(customText5.Texts),
                DESCIPT = customText6.Texts,
                QUALI = customText7.Texts,
                DETAILS = customText8.Texts,
                POSTDATE = DateTime.Now
            };
            context.JOB_POSTING.Add(post);
            context.SaveChanges();
            MessageBox.Show("Job Added", "SUccessfully added"+customText2.Texts, MessageBoxButtons.OK);
        }
    }
}
