using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace Assessments
{
    public partial class AdminDashBoard : Form
    {
        SqlConnection con = new SqlConnection();
        
        
        SqlCommand cmdSubMan = new SqlCommand();
        
        
        //int optionSelected = 0;
        int action = 1;
        //int saveAction = 1;
        int subjectToBeEdited = -1;
        public AdminDashBoard()
        {
            con.ConnectionString = Settings.ConnectionString;
            InitializeComponent();
        }

      
       /// collecting username from the login page
        private void AdminDashBoard_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Settings.UserName;
            DisplayAllotedSubjects();
            SubjectGridView.DataSource =ListSubjects();
            ListStaff();
        }

        //// naviation link for the change password 
        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword cpwd = new ChangePassword();
            cpwd.MdiParent = this.MdiParent;
            this.Close();
            cpwd.Show();
           

        }
        private void btnAdminLogout_Click(object sender, EventArgs e)
        {
            LoginPage log = new LoginPage();
            log.MdiParent = this.MdiParent;
            this.Close();
            //Settings.IsLoggedIn = false;
            //this.Close();
            
            log.Show();
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {

            SubjectManagementGB.Visible = true;
            StaffManageGB.Visible = false;
            comboSubjectList.DataSource = ListSubjects();
            comStaffList.DataSource = ListStaff();
            btnStaffManagement.Enabled = false;

        }
       
        private void btnStaffManagement_Click(object sender, EventArgs e)
        {
            SubjectManagementGB.Visible = false;
            StaffManageGB.Visible = true;
            lblUSerId.Text = UserId().ToString();
            comRoles.DataSource =GetRoles();
            comRoles.DisplayMember = "Role";
            comRoles.ValueMember = "RoleId";
            btnAddSubject.Enabled = false;
        }


        //---------------------------------------------- STAFF MANAGEMENT ----------------------------------------------------
        int UserId()
        {
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmdUserId = new SqlCommand("Select max(id)+1 from Users",con);
            
            return Convert.ToInt32(cmdUserId.ExecuteScalar());
        }
        DataTable GetRoles()
        {
            DataTable dtRoles = new DataTable();
            SqlDataAdapter daRoles = new SqlDataAdapter("Select * from Roles where roleId in (1,2)", con);
            daRoles.Fill(dtRoles);

            // insertind an empty row to the table 
            DataRow r = dtRoles.NewRow();
            r[0] = -1;
            r[1] = "Choose User Role";
            dtRoles.Rows.InsertAt(r, 0);
            return dtRoles;
        }

        private void btnStaffSave_Click(object sender, EventArgs e)
        {
            int Status = 2;
            char gender = 'm';

            if (radioBtnFemale.Checked)
            {
                gender = 'f';
            }
            if(chkActivate.Checked)
            {
                Status = 1;
            }
            if(comRoles.SelectedIndex==0)
            {
                AdminErrorProvider.SetError(comRoles, "Choose the User Roles");
                return;
            }
            else
            {
                AdminErrorProvider.Clear();
            }

            if(!radioBtnFemale.Checked && !radioBtnMale.Checked)
            {
                AdminErrorProvider.SetError(radioBtnFemale, "Select Gender");
                return;
            }
            else
            {
                AdminErrorProvider.Clear();
            }

            SqlCommand cmdAdmin = new SqlCommand();
            cmdAdmin.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (action==1)
            {
                
                cmdAdmin.CommandText = "insert into Users values (@name,@email,@mobile,@password,@gender,@roleid,@status)";
                cmdAdmin.Parameters.AddWithValue("@password", txtMobile.Text.Trim());
                
            }
            else if(action==2)
            {
                cmdAdmin.CommandText = "update Users set name= @name, email=@email, mobile=@mobile,  roleid=@roleid, status=@status, gender=@gender where user=@userId ";
                cmdAdmin.Parameters.AddWithValue("@userid",Convert.ToInt32(lblUSerId.Text));
            
            }
            cmdAdmin.Parameters.AddWithValue("@name", txtStaffName.Text.Trim());
            cmdAdmin.Parameters.AddWithValue("@email", txtStaffEmail.Text.Trim());
            cmdAdmin.Parameters.AddWithValue("@mobile",Convert.ToInt64(txtMobile.Text));
            cmdAdmin.Parameters.AddWithValue("gender", gender);
            cmdAdmin.Parameters.AddWithValue("roleid",Convert.ToInt32(comRoles.SelectedValue) );
            cmdAdmin.Parameters.AddWithValue("status", Status);

            if (cmdAdmin.ExecuteNonQuery() > 0)
            {



                if (action == 1)
                {
                    lblStaffAddMsg.Text = "User Details added Successfully";
                    lblStaffAddMsg.ForeColor = Color.Green;
                    btnStaffSave.Enabled = false;
                }
                if (action == 2)
                {
                    lblStaffAddMsg.Text = "User Details Updated Successfully";
                    lblStaffAddMsg.ForeColor = Color.Green;

                    SqlDataAdapter da = new SqlDataAdapter("Select id ,name,email,mobile, gender,roleid,status from Users where name like '%" + txtStaffSearch.Text.Trim() + "%'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    StaffManageGridView.DataSource = dt;
                    lblStaffSearchMsg.Text = dt.Rows.Count + " record(s) found";
                    lblStaffSearchMsg.ForeColor = Color.Blue;
                }
            }
            else
            {
                lblStaffAddMsg.Text = "User details not captured";
                lblStaffAddMsg.ForeColor = Color.Red;
            }
            
           
            con.Close();
        }

        private void btnStaffCancelClear_Click(object sender, EventArgs e)
        {
            action = 1;
            lblUSerId.Text = UserId().ToString();
            txtStaffEmail.Text = "";
            txtStaffName.Text = "";
            txtMobile.Text = "";
            comRoles.SelectedIndex = 0;
            radioBtnFemale.Checked = false;
            radioBtnMale.Checked = false;
            chkActivate.Checked = false;
            lblStaffAddMsg.Text = "";
            btnStaffSave.Enabled = true;
            txtStaffName.Focus();
        }

        private void bnStaffSearchS_Click(object sender, EventArgs e)
        {
            if(txtStaffSearch.Text.Trim().Length==0)
            {
                lblStaffSearchMsg.Text = "Enter the Name to Search by";
                lblStaffSearchMsg.ForeColor = Color.Red;
                return;
            }
            SqlDataAdapter da = new SqlDataAdapter("select id,name,email,mobile,gender,Roleid,status from Users where name like '%"+txtStaffSearch.Text.Trim()+"%' and roleid in(1,2)",con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count==0)
            {
                lblStaffSearchMsg.Text = "No Records Found";
                lblStaffSearchMsg.ForeColor = Color.Red;
                StaffManageGridView.DataSource = null;
                return;
            }
            else
            {
                StaffManageGridView.DataSource = dt;
                lblStaffSearchMsg.Text = dt.Rows.Count + " record(s) found";
                lblStaffSearchMsg.ForeColor = Color.Blue;
            }
        }

        private void btnCancelStaffSearch_Click(object sender, EventArgs e)
        {
            lblStaffSearchMsg.Text = "";
            txtStaffSearch.Text = "";
            action = 1;
            StaffManageGridView.DataSource = null;

            lblUSerId.Text = UserId().ToString();
            txtStaffEmail.Text = "";
            txtMobile.Text = "";
            txtStaffName.Text = "";
            comRoles.SelectedValue = 0;
            lblStaffAddMsg.Text = "";

        }

        private void StaffManageGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selected = e.RowIndex;

            lblUSerId.Text = StaffManageGridView.Rows[selected].Cells[0].Value.ToString();
            txtStaffName.Text = StaffManageGridView.Rows[selected].Cells[1].Value.ToString();
            txtStaffEmail.Text = StaffManageGridView.Rows[selected].Cells[2].Value.ToString();

            if (StaffManageGridView.Rows[selected].Cells[4].Value.ToString().Equals('m'))
                radioBtnMale.Checked = true;
            else if (StaffManageGridView.Rows[selected].Cells[4].Value.ToString().Equals('f'))
                radioBtnFemale.Checked = true;

            if (Convert.ToInt32(StaffManageGridView.Rows[selected].Cells[5].Value) == 1)
                comRoles.SelectedValue = 1;
            else if (Convert.ToInt32(StaffManageGridView.Rows[selected].Cells[5].Value) == 2)
                comRoles.SelectedValue = 2;

            if (Convert.ToInt32(StaffManageGridView.Rows[selected].Cells[6].Value) == 1)
                chkActivate.Checked = true;
            else
                chkActivate.Checked = false;

            action = 2;
        }
        private void linStaffGBCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaffManageGB.Visible = false;
            btnAddSubject.Enabled = true;   
        }


        //-------------------------------------------------------- SUBJECT MANAGEMENT ------------------------------------------------------


 

        DataTable ListStaff()
        {
            DataTable dtStaffList = new DataTable();
            SqlDataAdapter daStaffList = new SqlDataAdapter("select id,name from Users where roleId=2", con);
            daStaffList.Fill(dtStaffList);
            DataRow r = dtStaffList.NewRow();
            r[0] = -1;
            r[1] = "Choose Staff";
            dtStaffList.Rows.InsertAt(r, 0);
            comStaffList.DataSource = dtStaffList;
            comStaffList.DisplayMember = "Name";
            comStaffList.ValueMember = "id";

            return dtStaffList;
        }

        DataTable ListSubjects()
        {
            int selectedStaffId = Convert.ToInt32(comStaffList.SelectedValue);
            DataTable dtSubjeccts = new DataTable();
            SqlDataAdapter daSub = new SqlDataAdapter("select * from Subjects  where SubjectId not in (select SubjectId from StaffSubjectAllocation where StaffId="+ selectedStaffId + ")",con);
            daSub.Fill(dtSubjeccts);
            DataRow dr = dtSubjeccts.NewRow();
            dr[0] = -1;
            dr[1] = "Choose Subject ";
            dtSubjeccts.Rows.InsertAt(dr, 0);
            comboSubjectList.DataSource = dtSubjeccts;
            comboSubjectList.DisplayMember = "SubjectName";
            comboSubjectList.ValueMember = "SubjectID";

            return dtSubjeccts;
        }

        private void comStaffList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedStaffId = Convert.ToInt32(comStaffList.SelectedValue);
                DataTable dtSubjects = new DataTable();
                SqlDataAdapter daSubjects = new SqlDataAdapter("select * from Subjects where subjectId not in (select subjectId from StaffSubjectAlloction where StaffId="+selectedStaffId+")" ,con);
                daSubjects.Fill(dtSubjects);

                DataRow r = dtSubjects.NewRow();
                r[0] = -1;
                r[1] = "Choose Subjects";
                dtSubjects.Rows.InsertAt(r, 0);
                comboSubjectList.DataSource = dtSubjects;
                comboSubjectList.DisplayMember = "SubjectName";
                comboSubjectList.ValueMember = "SubjectId";
            }
            catch
            {

            }
        }



        ///--------------Allot Subject to the Staff button
        private void btnAllot_Click(object sender, EventArgs e)
        {
            if(comStaffList.SelectedIndex==0)
            {
                AdminErrorProvider.SetError(comStaffList, "Choose Staff");
                return;
            }
            else
            {
                AdminErrorProvider.Clear();
            }

            if(comboSubjectList.SelectedIndex==0)
            {
                AdminErrorProvider.SetError(comboSubjectList, "Choose Subject to be allot ");
                return;
            }
            else
            {
                AdminErrorProvider.Clear();
            }

            SqlCommand cmdAllot = new SqlCommand();
            cmdAllot.Connection = con;
            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAllot.CommandText = "Insert into StaffSubjectAllocation values(@staffId,@subjectId,getDate(),@allotedBy)";
            cmdAllot.Parameters.AddWithValue("@StaffId", Convert.ToInt32(comStaffList.SelectedValue));
            cmdAllot.Parameters.AddWithValue("@subjectId", Convert.ToInt32(comboSubjectList.SelectedValue));
            cmdAllot.Parameters.AddWithValue("@allotedBy",Settings.UserId);

            if(cmdAllot.ExecuteNonQuery() > 0)
            {
                lblAllotSubMsg.Text = comboSubjectList.Text + " is alloted to " + comStaffList.Text;
                lblAllotSubMsg.ForeColor = Color.Green;
                DisplayAllotedSubjects();
                
                
            }
            else
            {
                lblAllotSubMsg.Text = "Failed to allot subject to " + comStaffList.Text;
                lblAllotSubMsg.ForeColor = Color.Red;
            }
        }

        void DisplayAllotedSubjects()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            DataTable dtSub = new DataTable();
            SqlDataAdapter daStfSub = new SqlDataAdapter("select s.Name as [staff],sub.SubjectName as [AllotedSubject] ,ad.Name as [AdminName] from Users s inner join StaffSubjectAllocation as sa on s.id= sa.StaffId inner join subjects sub on sub.SubjectId = sa.SubjectId inner join Users ad on ad.Id=sa.allotedBy", con);
            daStfSub.Fill(dtSub);
            AllocationGridView.DataSource = dtSub;
        }

        //-------------- Save and update Subject button--------------------
        private void btnSubjectSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmdSave = new SqlCommand();
            cmdSave.Connection = con;
            if(txtSubSearch.Text.Length==0)
            {
                AdminErrorProvider.SetError(txtSubSearch, "Enter the subject ");
                return;

            }
            else
            {
                AdminErrorProvider.Clear();
            }
            if (con.State == ConnectionState.Closed)
                con.Open();

            if (action == 1)
            {

                cmdSave.CommandText = "insert into Subjects values('" + txtSubSearch.Text.Trim() + "')";
            }
            else if (action == 2)
            {
                cmdSave.CommandText = "Update subjects sat subjectName='" + txtSubSearch.Text.Trim() + "' where subjectId=" + subjectToBeEdited;
            }

            try
            {
                if (cmdSave.ExecuteNonQuery() > 0)
                {
                    SubjectGridView.DataSource = ListSubjects();
                    if (action == 1)
                    {
                        lblSubjectMsg.Text = "Subject is Added";
                        lblSubjectMsg.ForeColor = Color.Green;
                    }
                    else if (action==2)
                    {
                        lblSubjectMsg.Text = "Subject is Updated";
                        lblSubjectMsg.ForeColor = Color.Green;
                    }
                    
                }
                else 
                {
                    lblSubjectMsg.Text = "Subject is not added or Modified";
                    lblSubjectMsg.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Violation of Unique key constraint "))
                {
                    MessageBox.Show("The Subject is already Exist");
                    
                }
            }
        }

        //------------------  Subject  cancel button----------------
        private void btnStudentSearchCancel_Click(object sender, EventArgs e)
        {
            txtSubSearch.Text = "";
            btnSubjectSearch.Enabled = true;
            action = 1;
            subjectToBeEdited = -1;
            SubjectGridView.DataSource = null ;
            lblSubjectMsg.Text = "";

        }

        //---------Cancel Allot button-------------------------

        private void btnCancelAllot_Click(object sender, EventArgs e)
        {
            lblAllotSubMsg.Text = "";
            AllocationGridView.DataSource = null;
            comboSubjectList.SelectedIndex = 0;
            comboSubjectList.SelectedIndex = 0;

        }

        private void lnkSubGBCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SubjectManagementGB.Visible = false;
            btnStaffManagement.Enabled = true;
        }

        private void comboSubjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedStaffId = Convert.ToInt32(comStaffList.SelectedValue);
                DataTable dtSubjects = new DataTable();
                SqlDataAdapter daSubjects = new SqlDataAdapter("select * from Subjects where subjectId not in (select subjectId from StaffSubjectAlloction where staffId=" + selectedStaffId + ")", con);
                daSubjects.Fill(dtSubjects);

                DataRow r = dtSubjects.NewRow();
                r[0] = -1;
                r[1] = "Choose Subjects";
                dtSubjects.Rows.InsertAt(r, 0);
                comboSubjectList.DataSource = dtSubjects;
                comboSubjectList.DisplayMember = "SubjectName";
                comboSubjectList.ValueMember = "SubjectId";
            }
            catch
            {

            }

        }

        private void SubjectManagementGB_Enter(object sender, EventArgs e)
        {

        }
    }
}
