using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessments
{
    public partial class StudentDashBoard : Form
    {
        SqlConnection con = new SqlConnection();
        public StudentDashBoard()
        {
            con.ConnectionString = Settings.ConnectionString;
            
            InitializeComponent();
        }


        private void StudentDashBoard_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Settings.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TakeAssessment test = new TakeAssessment();
            test.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestResult resultPage = new TestResult();
            resultPage.Show();
            this.Close();
        }

        private void btnStudentLogout_Click(object sender, EventArgs e)
        {
            LoginPage login = new LoginPage();
            login.MdiParent = this.MdiParent;
            login.Show();
            this.Close();
        }

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword pwd= new ChangePassword();
            pwd.MdiParent= this.MdiParent;
            pwd.Show();
            this.Close();
        }
    }
}
