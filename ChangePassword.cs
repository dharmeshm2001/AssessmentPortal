using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Assessments
{
    public partial class ChangePassword : Form
    {
        SqlConnection con=new SqlConnection();
        public ChangePassword()
        {
            InitializeComponent();
            con.ConnectionString = Settings.ConnectionString;
        }

        private void btnChangepwdCancel_Click(object sender, EventArgs e)
        {

            if (Settings.Role == 1)
            {
                AdminDashBoard db = new AdminDashBoard();
                db.MdiParent = this.MdiParent;
                db.Show();
            }
            else if (Settings.Role == 2)
            {
                StaffDashBoard db = new StaffDashBoard();
                db.MdiParent = this.MdiParent;
                db.Show();
            }
            else if (Settings.Role == 3)
            {
                StudentDashBoard db = new StudentDashBoard();
                db.MdiParent = this.MdiParent;
                db.Show();
            }
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnChangePwdSave_Click(object sender, EventArgs e)
        {
            if(txtCurrentPwd.Text.Trim().Length==0)
            {
                errorProvider1.SetError(txtCurrentPwd, "Enter current Password");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if(txtNewPwd.Text.Trim().Length==0)
            {
                errorProvider1.SetError(txtNewPwd, "Enter New Password");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if(txtConfirmPwd.Text.Trim().Length==0)
            {
                errorProvider1.SetError(txtConfirmPwd, "Enter Current Password");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            //if both new password and the Confirm password is not same 
            if(txtNewPwd.Text.Trim()!=txtConfirmPwd.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPwd, "Password do not match");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            SqlCommand cmdPwd = new SqlCommand();
            cmdPwd.Connection = con;

            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            cmdPwd.CommandText = "select Password from Users where id=" + Settings.UserId;
            SqlDataReader dr = cmdPwd.ExecuteReader();
            dr.Read();

            //checking if the current password is same as in the db
            if (dr[0].ToString().Equals(txtCurrentPwd.Text.Trim()))
            {
                dr.Close();

                cmdPwd.Dispose();
                SqlCommand cmdUpdate =  new SqlCommand("update Users Set Password='"+txtNewPwd.Text.Trim()+"' where Id="+Settings.UserId);
                cmdUpdate.Connection = con;
                if(cmdUpdate.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("Password Changed Successfully");
                    Settings.UserId = -1;
                    Settings.UserName = null;
                    Settings.Role = -1;

                    LoginPage log = new LoginPage();

                    Settings.IsLoggedIn = true;
                    log.MdiParent = this.MdiParent;
                    this.Close();
                    log.Show();
                }
                else
                {
                    lblMsg.Text = "Failed to change Password";
                }
            }
            else
            {
                lblMsg.Text = "Incorrect Password";
            }
            con.Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Settings.UserName;
        }

        // Method button cancel redirecting to the user dashboard based on the role

    }
}
