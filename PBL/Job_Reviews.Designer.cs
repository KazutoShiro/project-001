
namespace PBL
{
    partial class Job_Reviews
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Firstname = new System.Windows.Forms.Label();
            this.bunifuRating1 = new Bunifu.UI.WinForms.BunifuRating();
            this.LastName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Comment = new System.Windows.Forms.Label();
            this.Dates = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 65);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Firstname
            // 
            this.Firstname.AutoSize = true;
            this.Firstname.Location = new System.Drawing.Point(107, 56);
            this.Firstname.Name = "Firstname";
            this.Firstname.Size = new System.Drawing.Size(78, 17);
            this.Firstname.TabIndex = 1;
            this.Firstname.Text = "First_name";
            // 
            // bunifuRating1
            // 
            this.bunifuRating1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuRating1.DisabledEmptyFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.bunifuRating1.DisabledRatedFillColor = System.Drawing.Color.DarkGray;
            this.bunifuRating1.EmptyBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.bunifuRating1.EmptyFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.bunifuRating1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.bunifuRating1.HoverFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.bunifuRating1.InnerRadius = 2F;
            this.bunifuRating1.Location = new System.Drawing.Point(627, 21);
            this.bunifuRating1.Name = "bunifuRating1";
            this.bunifuRating1.OuterRadius = 10F;
            this.bunifuRating1.RatedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.bunifuRating1.RatedFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.bunifuRating1.ReadOnly = false;
            this.bunifuRating1.RightClickToClear = true;
            this.bunifuRating1.Size = new System.Drawing.Size(121, 22);
            this.bunifuRating1.TabIndex = 2;
            this.bunifuRating1.Text = "bunifuRating1";
            this.bunifuRating1.Value = 2;
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Location = new System.Drawing.Point(107, 87);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(80, 17);
            this.LastName.TabIndex = 3;
            this.LastName.Text = "Last_Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Comment);
            this.panel1.Location = new System.Drawing.Point(18, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 146);
            this.panel1.TabIndex = 4;
            // 
            // Comment
            // 
            this.Comment.AutoSize = true;
            this.Comment.Location = new System.Drawing.Point(21, 35);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(67, 17);
            this.Comment.TabIndex = 0;
            this.Comment.Text = "Comment";
            // 
            // Dates
            // 
            this.Dates.AutoSize = true;
            this.Dates.Location = new System.Drawing.Point(574, 268);
            this.Dates.Name = "Dates";
            this.Dates.Size = new System.Drawing.Size(38, 17);
            this.Dates.TabIndex = 5;
            this.Dates.Text = "Date";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Chocolate;
            this.panel2.Controls.Add(this.Dates);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(804, 300);
            this.panel2.TabIndex = 6;
            // 
            // Job_Reviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.bunifuRating1);
            this.Controls.Add(this.Firstname);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Name = "Job_Reviews";
            this.Size = new System.Drawing.Size(804, 300);
            this.Load += new System.EventHandler(this.Job_Reviews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Firstname;
        private Bunifu.UI.WinForms.BunifuRating bunifuRating1;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Comment;
        private System.Windows.Forms.Label Dates;
        private System.Windows.Forms.Panel panel2;
    }
}
