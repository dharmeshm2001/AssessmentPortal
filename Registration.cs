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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assessments
{
    public partial class Registration : Form
    {
        SqlConnection con = new SqlConnection();
       
        public Registration()
        {

            InitializeComponent();
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            txtStudentName.Focus();
        }


        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void btnStudentRegister_Click_1(object sender, EventArgs e)
        {

            int studentRole = 3;
            int Status = 1;
            char gender = 'm';

            if (radioBtnFemale.Checked)
            {
                gender = 'f';
            }

            if (chkActivateRegister.Checked)
            {
                studentRole = 3;
            }
            //
            if (txtStudentName.Text.Length == 0)
            {
                RegistrationError.SetError(txtStudentName, " Enter the Name");
                return;

            }
            else
            {
                RegistrationError.Clear();
            }

            //
            if (txtStudentEmail.Text.Length == 0)
            {
                RegistrationError.SetError(txtStudentName, " Enter the Email Address");
                return;

            }
            else
            {
                RegistrationError.Clear();
            }

            //
            if (txtMobile.Text.Length == 0)
            {
                RegistrationError.SetError(txtStudentName, " Enter the Mobile number");
                return;

            }
            else
            {
                RegistrationError.Clear();
            }

            ///
            if (txtStudentName.Text.Length == 0 && txtStudentCnfmPwd.Text.Length == 0)
            {
                RegistrationError.SetError(txtStudentName, " Enter the password ,your mobile number will be your password");
                return;

            }
            else if (txtStudentPwd.Text != txtStudentCnfmPwd.Text)
            {
                RegistrationError.SetError(txtStudentCnfmPwd, "The Password is not Same");
                return;

            }
            else if(txtStudentCnfmPwd.Text != txtMobile.Text)
            {
                RegistrationError.SetError(txtStudentCnfmPwd, "Your Mobile number is your password");
            }
            else
            {
                RegistrationError.Clear();
            }

            //


            if (!radioBtnFemale.Checked && !radioBtnMale.Checked)
            {
                RegistrationError.SetError(radioBtnFemale, "Select the gender");
                return;
            }
            else
            {
                RegistrationError.Clear();
            }

            con.ConnectionString = Settings.ConnectionString;
            SqlCommand cmdReg = new SqlCommand();
            cmdReg.Connection = con;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmdReg.CommandText = "insert into Users values (@name,@email,@mobile,@password,@gender,@RoleID,@status)";

            cmdReg.Parameters.AddWithValue("@name", txtStudentName.Text.Trim());
            cmdReg.Parameters.AddWithValue("@email", txtStudentEmail.Text.Trim());
            cmdReg.Parameters.AddWithValue("@mobile", Convert.ToInt64(txtMobile.Text));
            cmdReg.Parameters.AddWithValue("@password", txtStudentCnfmPwd.Text.Trim());
            cmdReg.Parameters.AddWithValue("@gender", gender);
            cmdReg.Parameters.AddWithValue("@RoleID", studentRole);
            cmdReg.Parameters.AddWithValue("@status", Status);

            if (cmdReg.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("You are successfully registered");
                LoginPage log = new LoginPage();
                log.MdiParent = this.MdiParent;
                this.Close();
                log.Show();

            }
            else
            {
                MessageBox.Show("Failed to Register");
                txtStudentName.Focus();
            }

        }

        private void btnRegisterCancel_Click_1(object sender, EventArgs e)
        {
            LoginPage log = new LoginPage();
            log.MdiParent = this.MdiParent;
            this.Close();


            log.Show();

        }


    }
}
