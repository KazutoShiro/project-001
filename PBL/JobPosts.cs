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
    [DefaultEvent("_TextChanged")]
    public partial class JobPosts : UserControl
    {
        public JobPosts()
        {
            InitializeComponent();
        }
        private PictureBox picture;
        private string companyName = "";
        private string fieldName = "";
        private string location = "";
        private string date = "";

        public PictureBox Picture { get => picture; set => picture = value; }
        public string CompanyName1 { get => companyName; set => companyName = value; }
        public string FieldName { get => fieldName; set => fieldName = value; }
        public string Location1 { get => location; set => location = value; }
        public string Date { get => date; set => date = value; }

        private void JobPosts_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
        }
    }
}
