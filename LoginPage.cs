using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Assessments
{
    
    public partial class LoginPage : Form
    {
        SqlConnection con = new SqlConnection();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            
        }

        // Method for button login and direct to the dashboard based on their role  
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text.Trim().Length==0)
            {
               errorProvider1.SetError(txtEmail, "Enter Email Id");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if(txtPassword.Text.Trim().Length==0)
            {
                errorProvider1.SetError(txtPassword, "Enter Password");
                return;

            }
            else
            {
                errorProvider1.Clear();
            }

            con.ConnectionString = Settings.ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            
            cmd.CommandText = "select Id,Name,Password,RoleId from Users where email= '"
                +txtEmail.Text.Trim()+"'";
            SqlDataReader dr = cmd.ExecuteReader();

            //If datarows has records
            if(dr.HasRows)
            {
                dr.Read();

                //Checking if the entered password is same or not 
                if (dr[2].ToString().Equals(txtPassword.Text.Trim()))
                {

                    Settings.UserName = dr[1].ToString();
                    Settings.UserId = Convert.ToInt32(dr[0]);
                    
                    Settings.Role = Convert.ToInt32(dr[3]);

                    ///Role based dashboard navigation
                    if (Convert.ToInt32(dr[3])==1)
                    {

                        AdminDashBoard admin = new AdminDashBoard();
                        admin.MdiParent = this.MdiParent;

                        admin.Show();
                        this.Close();
                    }
                    else if(Convert.ToInt32(dr[3]) == 2)
                    {
                        StaffDashBoard staff = new StaffDashBoard();
                        staff.MdiParent = this.MdiParent;

                        staff.Show();
                        this.Close();

                    }
                    else if(Convert.ToInt32(dr[3]) == 3)
                    {
                        StudentDashBoard student = new StudentDashBoard();
                        student.MdiParent = this.MdiParent;

                        student.Show();
                        this.Close();
                    }
                }
                else
                {
                    lblMsg.Text = "Authentication Failed";
                }
            }
            else
            {
                lblMsg.Text = "Authentication Failed";
            }

            con.Close();
        }

        // Method for Cancel button 
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Settings.IsLoggedIn = false;
            this.Close();
        }

        // Method for leable message to display message if the user has entered wrong paassword or EmailId
        private void lblMsg_Click(object sender, EventArgs e)
        {


        }

        // method for Email text box
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        // method for password text if
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnkStudentRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration Studentreg = new Registration();
            Studentreg.MdiParent = this.MdiParent;
            Studentreg.Show();
            this.Close();
        }
    }
}
