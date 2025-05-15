using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Assessments
{
    public partial class StaffDashBoard : Form
    {
        SqlConnection con = new SqlConnection();
        
        int action = 1;
        public StaffDashBoard()
        {
            con.ConnectionString = Settings.ConnectionString;

            InitializeComponent();
        }

        private void StaffDashBoard_Load(object sender, EventArgs e)
        {

            lblUserName.Text = Settings.UserName;
            comStaffSubjects.DataSource = ListSubjects();
            comStaffSubjects.DisplayMember = "SUbjects";
            comStaffSubjects.ValueMember = "SubjectId";
            


        }


        private void btnAddUpdateQuestion_Click(object sender, EventArgs e)
        {
            QuestionGroupBox.Visible = true;
        }

        //---------------------------- CANCEL THE GROUP BOX----------------------------------------------------------------
        private void btnQuestionGBCancel_Click(object sender, EventArgs e)
        {
            QuestionGroupBox.Visible = false;
            comStaffSubjects.SelectedIndex = 0;
            txtQuestion.Text = "";
            txtOptionA.Text = "";
            txtOptionB.Text = "";
            txtOptionC.Text = "";
            txtOptionD.Text = "";
            lblComSubMsg.Text = "";
            lblInsertQueMsg.Text = "";
            QuestionsGridView.DataSource = null;
            con.Close();
            
        }




        // ----------------------------------- DATABALE TO  LIST  THE SUBJECTS FOR THE CURRENT STAFF-------------------------------------------------------------------------------
        DataTable ListSubjects()
        {
            int currUSer = Convert.ToInt32(Settings.UserId);
            DataTable dtSubjects = new DataTable();
            SqlDataAdapter daSubjects = new SqlDataAdapter("Select * from Subjects where subjectId in (select SubjectId from StaffSubjectAllocation where StaffId=" + currUSer+ ")", con);
            daSubjects.Fill(dtSubjects);
            DataRow r = dtSubjects.NewRow();
            r[0] = -1;
            r[1] = "Choose Subjects";
            dtSubjects.Rows.InsertAt(r, 0);
            comStaffSubjects.DisplayMember = "SubjectName";
            comStaffSubjects.ValueMember = "SubjectId";

            return dtSubjects;
        }

        //------------------------------------- BUTTON STAFF LOGOUT----------------------------------------------------------
        private void btnStaffLogout_Click(object sender, EventArgs e)
        {
            LoginPage log = new LoginPage();
            log.MdiParent = this.MdiParent;
            this.Close();
            //Settings.IsLoggedIn = false;
            //this.Close();

            log.Show();
        }

        //---------------------------------------- LINK CHANGE PASSWORD  --------------------------------------------------------------

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword cpwd = new ChangePassword();
            cpwd.MdiParent = this.MdiParent;
            this.Close();
            cpwd.Show();

        }

        //---------------------------------BUTTON TO SAVE AND UPDATE QUESTION-----------------------------------------------------
        private void btnQuestionSave_Click(object sender, EventArgs e)
        {
            
            int subjectId = Convert.ToInt32(comStaffSubjects.SelectedValue);
            int status = 1;
            SqlCommand cmdStaff = new SqlCommand();
            cmdStaff.Connection = con;
            char correctAns = 'A';

            if (con.State == ConnectionState.Closed)
                con.Open();

            if(subjectId==0)
            {
                StaffPageErrorProvider.SetError(comStaffSubjects,"Select the subject");
                return;
            }
            else
            {
                StaffPageErrorProvider.Clear();
            }


            if (txtQuestion.Text.Length == 0)
            {
                StaffPageErrorProvider.SetError(txtQuestion, "Enter the Question");
                return;
            }
            else
            {
                StaffPageErrorProvider.Clear();
            }


            if (txtOptionA.Text.Length == 0)
                StaffPageErrorProvider.SetError(txtOptionA, "Enter OptionA ");
            else
            {
                StaffPageErrorProvider.Clear();
            }

            if(txtOptionB.Text.Length==0)
            {
                StaffPageErrorProvider.SetError(txtOptionB,"Enter Option B");
                return;
            }
            else
            {
                StaffPageErrorProvider.Clear();
            }

            if(txtOptionC.Text.Length==0)
            {
                StaffPageErrorProvider.SetError(txtOptionC,"Enter Option C");
                return;

            }
            else
            {
                StaffPageErrorProvider.Clear();
            }

            if(txtOptionD.Text.Length==0)
            {
                StaffPageErrorProvider.SetError(txtOptionD,"Enter Option D");
                return;
            }
            else
            {
                StaffPageErrorProvider.Clear();

            }


            if(!radioBtnOptionA.Checked && !radioBtnOptionB.Checked  && !radioBtnOption3.Checked && !radioBtnOptionD.Checked)
            {
                StaffPageErrorProvider.SetError(radioBtnOptionD, "Select the correct option");
                return;
            }

            if (radioBtnOptionB.Checked)
            {
                correctAns = 'B';
            }

            if(radioBtnOption3.Checked)
            {
                correctAns = 'C';
            }

            if(radioBtnOptionD.Checked)
            {
                correctAns = 'D';
            }

            if (chkQueActivate.Checked)
                status = 1;

            if (action == 1)
            {
                //int subId = Convert.ToInt32(comStaffSubjects.SelectedValue);

                
                cmdStaff.CommandText = "insert into QuestionBank values(@SubjectId,@CreatedBy,getdate(),@Question,@OptionA,@OptionB,@OptionC,@OptionD,@CorrectOption,@StatusId)";
               

            }
            if (action == 2)
            {
               
                cmdStaff.CommandText = "Update QuestionBank set subjectId=@SubjectId,CreatedBy=@createdBy,CreatedOn=@createdOn," +
                    "Question=@Question,OptionA=@optionA,OptionC=@OptionC,OptionD=@OptionD,CorrectOption=@CorrectOption ,StatusId=@StatusId where SubjectId=@SubjectId";
                cmdStaff.Parameters.AddWithValue("@SubjecId", subjectId);
            }

            cmdStaff.Parameters.AddWithValue("@SubjectId",subjectId); ;
            cmdStaff.Parameters.AddWithValue("@CreatedBy ", Convert.ToInt32(Settings.UserId));
            
            cmdStaff.Parameters.AddWithValue("@Question", txtQuestion.Text);
            cmdStaff.Parameters.AddWithValue("@OptionA", txtOptionA.Text.Trim());
            cmdStaff.Parameters.AddWithValue("@OptionB", txtOptionB.Text.Trim());
            cmdStaff.Parameters.AddWithValue("@OptionC", txtOptionC.Text.Trim());
            cmdStaff.Parameters.AddWithValue("@OptionD", txtOptionD.Text.Trim());
            cmdStaff.Parameters.AddWithValue("@CorrectOption", correctAns);
            cmdStaff.Parameters.AddWithValue("@StatusId", status);


            if (cmdStaff.ExecuteNonQuery() > 0)
            {
                if (action == 1)
                {
                    lblInsertQueMsg.Text = "Question Uploaded Successfully";
                    lblInsertQueMsg.ForeColor = Color.Green;
                    txtQuestion.Text = "";
                    txtOptionA.Text = "";
                    txtOptionB.Text = "";
                    txtOptionC.Text = "";
                    txtOptionD.Text = "";
                    radioBtnOptionB.Enabled = false;
                    radioBtnOption3.Enabled = false;
                    radioBtnOptionA.Enabled = false;
                    radioBtnOptionD.Enabled = false;
                    chkQueActivate.Checked = false;
                    

                }
                if (action == 2)
                {
                    lblInsertQueMsg.Text = "Question updated Successfully";
                    lblInsertQueMsg.ForeColor = Color.Green;

                }
                QuestionsGridView.DataSource = QueList();
            }
            else
            {
                lblInsertQueMsg.Text = "Failed to upload Question";
                lblInsertQueMsg.ForeColor = Color.Red;
            }

               
                cmdStaff.Dispose();
            
            con.Close();
        }


        //---------------------------------- DATA TABLE FOR DISPLAYING  QUESTION LIST ----------------------------------------------- 
        DataTable QueList()
        {
            DataTable dtQueBank = new DataTable();
            SqlDataAdapter QueDa = new SqlDataAdapter("select Que.Question,Que.OptionA,Que.OptionB,Que.OptionC,Que.OptionD,Que.CorrectOption,Que.StatusId from QuestionBank Que inner join" +
                " StaffSubjectAllocation stf on "+Convert.ToInt32(comStaffSubjects.SelectedValue)+"=Que.SubjectId " +
     " and "+Settings.UserId+"=stf.StaffId", con);
            QueDa.Fill(dtQueBank);
           

            return dtQueBank;
        }

        //------------------------------------- BUTTON SELECT THE SUBJECT--------------------------------------------------
        private void btnSelectSub_Click(object sender, EventArgs e)
        {

            if(comStaffSubjects.SelectedIndex==0)
            {
                StaffPageErrorProvider.SetError(comStaffSubjects, "Choose the subject ");
            }
            int sId = Convert.ToInt32(comStaffSubjects.SelectedValue);

            QuestionsGridView.DataSource = QueList();





        }

        //----------------------------------------------- GRID VIEW SELECTED TO EDIT THE QUESTION-----------------------------------------
        private void QuestionsGridView_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedRow = e.RowIndex;

            txtQuestion.Text = QuestionsGridView.Rows[selectedRow].Cells[0].Value.ToString();
            txtOptionA.Text = QuestionsGridView.Rows[selectedRow].Cells[1].Value.ToString();
            txtOptionB.Text = QuestionsGridView.Rows[selectedRow].Cells[2].Value.ToString();
            txtOptionC.Text = QuestionsGridView.Rows[selectedRow].Cells[3].Value.ToString();
            txtOptionD.Text = QuestionsGridView.Rows[selectedRow].Cells[4].Value.ToString();

            if (QuestionsGridView.Rows[selectedRow].Cells[5].Value.ToString().Equals('A'))
            {
                radioBtnOptionA.Checked = true;
            }
            else if (QuestionsGridView.Rows[selectedRow].Cells[5].ToString().Equals('B'))
            {
                radioBtnOptionB.Checked = true;
            }
            else if (QuestionsGridView.Rows[selectedRow].Cells[5].ToString().Equals('c'))
            {
                radioBtnOptionB.Checked = true;
            }
            else
            {
                radioBtnOptionB.Checked = true;
            }


            if (Convert.ToUInt32(QuestionsGridView.Rows[selectedRow].Cells[6].Value) == 1)
                chkQueActivate.Checked = true;
            else
                chkQueActivate.Checked = false;
        }


        private void comStaffSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //---------------------------------------------- BUTTON CANCEL THE SUBJECT COMBINATION------------------------------------------
        private void btnCancelSub_Click(object sender, EventArgs e)
        {
            comStaffSubjects.SelectedIndex = 0;
            txtQuestion.Text = "";
            txtOptionA.Text = "";
            txtOptionB.Text = "";
            txtOptionC.Text = "";
            txtOptionD.Text = "";
            lblComSubMsg.Text = "";
            lblInsertQueMsg.Text = "";
            QuestionsGridView.DataSource = null;
            
        }
    }
}
