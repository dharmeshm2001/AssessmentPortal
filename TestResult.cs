using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;


namespace Assessments
{
    public partial class TestResult : Form
    {

        SqlConnection con = new SqlConnection();
        int index = 0;
        int count = 0;
        int marksView = 0;
        int marks = 0;

        ArrayList storeExamDetails = new ArrayList();


        public TestResult()
        {
            con.ConnectionString = Settings.ConnectionString;
            InitializeComponent();
            comSubjects.DataSource = ComboSubjects();
        }

        //------------------------------------ SUBJECTS COMBO BOX-----------------------------------------------------
        DataTable ComboSubjects()
        {
            SqlDataAdapter daSubjects = new SqlDataAdapter("select * from Subjects", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            DataTable dtSubjects = new DataTable();
            daSubjects.Fill(dtSubjects);
            DataRow newRow = dtSubjects.NewRow();
            newRow[0] = -1;
            newRow[1] = "Choose Subjects";

            dtSubjects.Rows.InsertAt(newRow, 0);
            comSubjects.DisplayMember = "SubjectName";
            comSubjects.ValueMember = "SubjectId";

            return dtSubjects;
        }

        //------------------------------------ METHOD TO STORE THE USER EXAM ATTENDED DETAILS-------------------------------------------
        void ExamAttemptDetails(int index)
        {
            DataTable dtAttempt = new DataTable();
            try
            {


                SqlDataAdapter daAttemtExam = new SqlDataAdapter("select ExamId,SubjectId,DateOfExam from ExamMaster where studentId=" + Settings.UserId +
                    " and SubjectID=" + Convert.ToInt32(comSubjects.SelectedValue) + "order by ExamId desc", con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                daAttemtExam.Fill(dtAttempt);
                count = dtAttempt.Rows.Count;
                if (index <= count)
                {
                    DataRow row = dtAttempt.Rows[index];
                    lblExamId.Text = row["ExamId"].ToString();
                    lblExamDate.Text = row["DateOfExam"].ToString();
                    lblSubjectName.Text = row["SubjectId"].ToString();
                }
                else if (index == -1)
                {
                    index = 0;
                    btnPreviousExamDetails.Enabled = false;
                }
            }
            catch
            {
                comSubjects.Enabled = true;
                comSubjects.SelectedIndex = 0;
                lblExamId.Text = "";
                lblExamDate.Text = "";
                lblSubjectName.Text = "";
                displayQueGroupBox.Visible = false;
                displayTotalMarksGroupBox.Visible = false;
                DialogResult res = MessageBox.Show("You have not taken the test for the The Subject you have selected ", "Alert Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (res == DialogResult.OK)
                {
                    comSubjects.Focus();
                    
                }
            }

        }

        void DisplayMarks(int currIndex)
        {

            SqlDataAdapter daRes = new SqlDataAdapter("select distinct Que.Question,Que.CorrectOption,a.ans as [YourAnswer] from QuestionBank Que inner join " +
                "Answers a on a.Qid=Que.Qid inner join ExamMaster on " + Convert.ToInt32(lblExamId.Text) + "=a.ExamId ", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            DataTable dtResTable = new DataTable();
            daRes.Fill(dtResTable);

            DataRow resRow = dtResTable.Rows[currIndex];

            lblDisplayQuestion.Text =( resRow["Question"].ToString());
            lblCorrectAnswer.Text = resRow["CorrectOption"].ToString();
            lblYourAnswer.Text = resRow["YourAnswer"].ToString();
            daRes.Dispose();
            if ((lblYourAnswer.Text.Trim())!=(lblCorrectAnswer.Text.Trim()))
            {
                lblMarks.Text = 0.ToString();
                lblMarks.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                marks = marks +1;
                lblMarks.Text = 1.ToString();
                lblMarks.ForeColor = System.Drawing.Color.Green;
              

            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentDashBoard studDBoard = new StudentDashBoard();
            studDBoard.MdiParent = this.MdiParent;
            this.Close();
            studDBoard.Show();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            comSubjects.Enabled = true;
            comSubjects.SelectedIndex = 0;
            lblExamId.Text = "";
            lblExamDate.Text = "";
            lblSubjectName.Text = "";
            displayQueGroupBox.Visible = false;
            displayTotalMarksGroupBox.Visible = false;
          
        }

        private void btnSearchSubject_Click(object sender, EventArgs e)
        {
            displayQueGroupBox.Visible = true;

            index = 0;
            ExamAttemptDetails(index);
        }

        private void btnNextExamDetails_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                btnPreviousExamDetails.Visible = false;
            }
            if (index < count && index > 0)
            {
                btnPreviousExamDetails.Visible = true;
            }
            index = index + 1;
            ExamAttemptDetails(index);
        }

        private void btnPreviousExamDetails_Click(object sender, EventArgs e)
        {
            if (index == -1 && index < count)
            {
                index = 0;
                btnPreviousExamDetails.Enabled = false;
                ExamAttemptDetails(index);
            }
            else
            {
                index = index - 1;
                ExamAttemptDetails(index);
            }

        }

        private void btnViewResult_Click(object sender, EventArgs e)
        {

            comSubjects.Enabled = false;
            btnPreviousExamDetails.Enabled = false;
            btnNextExamDetails.Enabled = false;

            displayOprionGroupBox.Visible = true;
            DisplayMarks(marksView);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            marksView = marksView + 1;
            if (marksView < 20)
            {
                DisplayMarks(marksView);
            }
            else if (marksView == 20)
            {
                button1.Enabled = false;
                displayTotalMarksGroupBox.Visible = true;
                lblTotalMarks.Text= marks.ToString();
               
            }
        }

        private void TestResult_Load(object sender, EventArgs e)
        {
            displayQueGroupBox.Visible = false;

        }

    }
}
