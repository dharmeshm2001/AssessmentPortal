using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Assessments
{
    public partial class TakeAssessment : Form
    {

        SqlConnection con = new SqlConnection();

        ArrayList queList = new ArrayList();
        HashSet<string> hashQue = new HashSet<string>();
        Random r = new Random();

        int currIndex = 0;
        int queId = 0;
        int examId = 0;
        char userOptions;

        public TakeAssessment()
        {
            con.ConnectionString = Settings.ConnectionString;
            InitializeComponent();


        }

        private void TakeAssessment_Load(object sender, EventArgs e)
        {
            QuestionGroupBox.Visible = false;
            QuestionNumberGroupBox.Visible = false;
            combTestSub.DataSource = ListSubjects();
        }

        //---------------------------------- DATA TABLE LIST SUBJECTS------------------------------------------------------------------------
        DataTable ListSubjects()
        {
            DataTable dtSub = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter daSub = new SqlDataAdapter("Select * from Subjects", con);
            daSub.Fill(dtSub);
            DataRow dr = dtSub.NewRow();
            dr[0] = -1;
            dr[1] = "Choose Subjects";
            dtSub.Rows.InsertAt(dr, 0);
            combTestSub.DisplayMember = "SubjectName";
            combTestSub.ValueMember = "SubjectId";

            return dtSub;

        }



        //--------------------------------- LINK CANCEL ASSESSMENT PAGE   -----------------------------------------------------
        private void lnkCancelTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentDashBoard studDBoard = new StudentDashBoard();
            studDBoard.MdiParent = this.MdiParent;
            this.Close();
            studDBoard.Show();
        }



        //------------------------------- BUTTON START TEST PAGE --------------------------------------------------------------
        private void btnStartTest_Click(object sender, EventArgs e)
        {

            if (combTestSub.SelectedIndex == 0)
            {
                TestPageErrorProvider.SetError(combTestSub, "Choose the Subject");
                combTestSub.Focus();
                return;
            }
            else
            {
                TestPageErrorProvider.Clear();
            }
            btnTestSubmit.Enabled = false;

            DialogResult res = MessageBox.Show(" INSTRUCTIONS     \n\n" +
                "1.Mandatory to attend all the Questions\n\n" +
                "2.Total 20 Questions for the selected subjects\n\n" +
                "3.No negative maerks\n\n" +
                "4. 1 marks for each correct answer and 0 marks for wrong answer and review option\n\n" +
                "5.You cannot exit or cancel in between in the test \n\n" +
                "All the Best .... : ) \n\n" +
                "Do you want to take the assesment for this Subject ...?", "Attend Assessment ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                QuestionGroupBox.Visible = true;
                QuestionNumberGroupBox.Visible = true;
                btnTestSubmit.Enabled = true;
                combTestSub.Enabled = false;
                btnStartTest.Enabled = false;
                lnkCancelTest.Enabled = false;


                //display the questions randomly until 20 questions complete
                StoreQue(0);
                SqlCommand cmdExamMas = new SqlCommand("insert into ExamMaster values(@SubjectId,@StudentId,getdate())", con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmdExamMas.Parameters.AddWithValue("@SubjectId", Convert.ToInt32(combTestSub.SelectedValue));
                cmdExamMas.Parameters.AddWithValue("@StudentId", Settings.UserId);
                cmdExamMas.ExecuteNonQuery();
                cmdExamMas.Dispose();

                SqlCommand cmdExamId = new SqlCommand("select distinct top 1  ExamId from ExamMaster where subjectId=" + Convert.ToInt32(combTestSub.SelectedValue) + " order by ExamId desc", con);
                examId = Convert.ToInt32(cmdExamId.ExecuteScalar());
                cmdExamMas.Dispose();
            }
        }


        //------------------------------ STORING THE 20 QUESTIONS FROM THE DATA BASE -------------------------------------------------------
        public void StoreQue(int option)
        {

            try
            {
                DataTable dtQue = new DataTable();
                SqlDataAdapter daQue = new SqlDataAdapter("select Question from QuestionBank where SubjectId=" + combTestSub.SelectedValue, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                daQue.Fill(dtQue);

                //------------ ADDING QUESTIONS TABLE TO ARRAY LIST----------------------
                foreach (DataRow roww in dtQue.Rows)
                {
                    foreach (DataColumn c in dtQue.Columns)
                    {
                        queList.Add(roww[c]);
                    }
                }
                daQue.Dispose();
                int count = queList.Count;

                //----------------- ADDING ARRAY LIST TO THE HASH SET ----------------------
                while (hashQue.Count < 20)
                {
                    int index = r.Next(count);
                    hashQue.Add(queList[index].ToString());
                }


                lblQuestion.Text = hashQue.ElementAt(option).ToString();
                btnList(option + 1);
                label6.Text = (option + 1).ToString();
                DataTable dtOptions = new DataTable();
                SqlDataAdapter daOptions = new SqlDataAdapter("select OptionA,OptionB,OptionC,OptionD from QuestionBank where Question='" + hashQue.ElementAt(option).ToString() + "'", con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                daOptions.Fill(dtOptions);

                if (dtOptions.Rows.Count > 0)
                {
                    DataRow rows = dtOptions.Rows[0];
                    lblOptionA.Text = rows["OptionA"].ToString();
                    lblOptionB.Text = rows["OptionB"].ToString();
                    lblOptionC.Text = rows["OptionC"].ToString();
                    lblOptionD.Text = rows["OptionD"].ToString();
                }
                SqlCommand cmdQid = new SqlCommand("select Qid from QuestionBank where Question='" + hashQue.ElementAt(option).ToString() + "'", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                queId = Convert.ToInt32(cmdQid.ExecuteScalar());
                cmdQid.Dispose();
            }
            catch(Exception e)
            {
                DialogResult res = MessageBox.Show("There is no test for this subjects ","Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                
            }
        }



        //----------------------------------------- STORING ANSWERS TO THE DATABASE -----------------------------------------------------------------------

        void storeAnswerToDB(int index, char userOptions)
        {
            SqlCommand cmdId = new SqlCommand("select Qid from Answers where Qid=" + queId, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmdInsert = new SqlCommand("insert into Answers values(@examId,@Qid,@ans)", con);
            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdInsert.Parameters.AddWithValue("@examId", Convert.ToInt32(examId));
            cmdInsert.Parameters.AddWithValue("@QId", Convert.ToInt32(queId));
            cmdInsert.Parameters.AddWithValue("@ans", userOptions);
            cmdInsert.ExecuteNonQuery();

            //lblSaveAndNext.Text = "Answer Saved Successfully ";


            cmdId.Dispose();


        }



        //------------------------- LIST OF GREEN BUTTONS USED WHEN SAVE AND NEXT BUTTON CLICKED--------------------------------------
        void btnListGreen(int value)
        {
            switch (value)
            {
                case 1: btnQue1.BackColor = Color.Green;
                    btnQue1.Enabled = false;    
                    break;
                case 2: btnQue2.BackColor = Color.Green;
                    break;
                case 3: btnQue3.BackColor = Color.Green; break;
                case 4: btnQue4.BackColor = Color.Green; break;
                case 5: btnQue5.BackColor = Color.Green; break;
                case 6: btnQue6.BackColor = Color.Green; break;
                case 7: btnQue7.BackColor = Color.Green; break;
                case 8: btnQue8.BackColor = Color.Green; break;
                case 9: btnQue9.BackColor = Color.Green; break;
                case 10: btnQue10.BackColor = Color.Green; break;
                case 11: btnQue11.BackColor = Color.Green; break;
                case 12: btnQue12.BackColor = Color.Green; break;
                case 13: btnQue13.BackColor = Color.Green; break;
                case 14: btnQue14.BackColor = Color.Green; break;
                case 15: btnQue15.BackColor = Color.Green; break;
                case 16: btnQue16.BackColor = Color.Green; break;
                case 17: btnQue17.BackColor = Color.Green; break;
                case 18: btnQue18.BackColor = Color.Green; break;
                case 19: btnQue19.BackColor = Color.Green; break;
                case 20: btnQue20.BackColor = Color.Green; break;

                default: btnQue1.BackColor = Color.SteelBlue; break;


            }
        }

        //------------------------- BUTTON LIST USED WHEN REVIEW AND NEXT BUTTON CLICKED -------------------------------------------
        void btnList(int value)
        {
            switch (value)
            {
                case 1: btnQue1.BackColor = Color.Orange; break;
                case 2: btnQue2.BackColor = Color.Orange; break;
                case 3: btnQue3.BackColor = Color.Orange; break;
                case 4: btnQue4.BackColor = Color.Orange; break;
                case 5: btnQue5.BackColor = Color.Orange; break;
                case 6: btnQue6.BackColor = Color.Orange; break;
                case 7: btnQue7.BackColor = Color.Orange; break;
                case 8: btnQue8.BackColor = Color.Orange; break;
                case 9: btnQue9.BackColor = Color.Orange; break;
                case 10: btnQue10.BackColor = Color.Orange; break;
                case 11: btnQue11.BackColor = Color.Orange; break;
                case 12: btnQue12.BackColor = Color.Orange; break;
                case 13: btnQue13.BackColor = Color.Orange; break;
                case 14: btnQue14.BackColor = Color.Orange; break;
                case 15: btnQue15.BackColor = Color.Orange; break;
                case 16: btnQue16.BackColor = Color.Orange; break;
                case 17: btnQue17.BackColor = Color.Orange; break;
                case 18: btnQue18.BackColor = Color.Orange; break;
                case 19: btnQue19.BackColor = Color.Orange; break;
                case 20: btnQue20.BackColor = Color.Orange; break;

                default: btnQue1.BackColor = Color.Orange; break;


            }
        }

        //------------------------------------ BUTTON SAVE AND NEXT ---------------------------------------------------------------

        private void btnSaveAndNext_Click(object sender, EventArgs e)
        {

            if (!radioBtnOptionA.Checked && !radioBtnOptionB.Checked && !radioBtnOpitionC.Checked && !radioBtnOptionD.Checked)
            {
                TestPageErrorProvider.SetError(btnSaveAndNext, "Select the option");
                return;
            }
            else
            {
                TestPageErrorProvider.Clear();
            }
            if (radioBtnOptionA.Checked)
            {
                userOptions = 'A';

            }
            else if (radioBtnOptionB.Checked)
            {
                userOptions = 'B';
            }
            else if (radioBtnOpitionC.Checked)
            {
                userOptions = 'C';
            }
            else if (radioBtnOptionD.Checked)
            {
                userOptions = 'D';
            }

            if (currIndex==19)
            {
                btnListGreen(currIndex);
                chkNotAttendedQuestion();
                

            }
            storeAnswerToDB(currIndex, userOptions);
            btnListGreen(currIndex+1);
            currIndex = currIndex + 1;
            StoreQue(currIndex);


            radioBtnOptionD.Checked = false;
            radioBtnOptionA.Checked = false;
            radioBtnOpitionC.Checked = false;
            radioBtnOptionB.Checked = false;

        }


        //------------------------------------------- BUTTON REVIEW AND NEXT ----------------------------------------------------------------
        private void btnReviewAndNext_Click(object sender, EventArgs e)
        {

            if (!radioBtnOptionA.Checked && !radioBtnOptionB.Checked && !radioBtnOpitionC.Checked && !radioBtnOptionD.Checked)
            {
                TestPageErrorProvider.SetError(btnSaveAndNext, "Select the option");
                return;
            }
            else
            {
                TestPageErrorProvider.Clear();
            }
            if (radioBtnOptionA.Checked)
            {
                userOptions = 'A';

            }
            else if (radioBtnOptionB.Checked)
            {
                userOptions = 'B';
            }
            else if (radioBtnOpitionC.Checked)
            {
                userOptions = 'C';
            }
            else if (radioBtnOptionD.Checked)
            {
                userOptions = 'D';
            }

            if (currIndex == 19)
            {
                btnList(currIndex);
                chkNotAttendedQuestion();
                

            }
            storeAnswerToDB(currIndex, userOptions);

            currIndex = currIndex + 1;
            if (currIndex > 19)
            {
                btnList(currIndex);
                chkNotAttendedQuestion();
            }
            else
            {
                StoreQue(currIndex);
                btnList(currIndex);
            }


            radioBtnOptionD.Checked = false;
            radioBtnOptionA.Checked = false;
            radioBtnOpitionC.Checked = false;
            radioBtnOptionB.Checked = false;


        }

        //-----------------------------------   CHECK IF THE OPTION OR BUTTON IS NOT VISITED-------------------------------------
        void chkNotAttendedQuestion()
        {
            if (btnQue1.BackColor == Color.SteelBlue)
            {
                currIndex = 0;
                StoreQue(currIndex);
            }
            else if (btnQue2.BackColor == Color.SteelBlue)
            {
                currIndex = 1;
                StoreQue(currIndex);
             
            }
            else if (btnQue3.BackColor == Color.SteelBlue)
            {
                currIndex = 2;
                StoreQue(currIndex);
                
            }
            else if (btnQue4.BackColor == Color.SteelBlue)
            {
                currIndex = 3;
                StoreQue(currIndex);
               
            }
            else if (btnQue5.BackColor == Color.SteelBlue)
            {
                currIndex = 4;
                StoreQue(currIndex);
                
            }
            else if (btnQue6.BackColor == Color.SteelBlue)
            {
                currIndex = 5;
                StoreQue(currIndex);
              

            }
            else if (btnQue7.BackColor == Color.SteelBlue)
            {
                currIndex = 6;
                StoreQue(currIndex);
               

            }
            else if (btnQue8.BackColor == Color.SteelBlue)
            {
                currIndex = 7;
                StoreQue(currIndex);
                

            }
            else if (btnQue9.BackColor == Color.SteelBlue)
            {
                currIndex = 8;
                StoreQue(currIndex);
             

            }
            else if (btnQue10.BackColor == Color.SteelBlue)
            {
                currIndex = 9;
                StoreQue(currIndex);
              
            }
            else if (btnQue11.BackColor == Color.SteelBlue)
            {
                currIndex = 10;
                StoreQue(currIndex);
               
            }
            else if (btnQue12.BackColor == Color.SteelBlue)
            {
                currIndex = 11;
                StoreQue(currIndex);
               

            }
            else if (btnQue13.BackColor == Color.SteelBlue)
            {
                currIndex = 12;
                StoreQue(currIndex);
              
            }
            else if (btnQue14.BackColor == Color.SteelBlue)
            {
                currIndex = 13;
                StoreQue(currIndex);
              
            }
            else if (btnQue15.BackColor == Color.SteelBlue)
            {
                currIndex = 14;
                StoreQue(currIndex);
            
            }
            else if (btnQue16.BackColor == Color.SteelBlue)
            {
                btnQue16.Focus();
                currIndex = 15;
                StoreQue(currIndex);
             
            }
            else if (btnQue17.BackColor == Color.SteelBlue)
            {
                currIndex = 17;
                StoreQue(currIndex);
               
            }
            else if (btnQue18.BackColor == Color.SteelBlue)
            {
                currIndex = 18;
                StoreQue(currIndex);
               
            }
            else if (btnQue19.BackColor == Color.SteelBlue)
            {
                currIndex = 18;
                StoreQue(currIndex);
                
            }
            else if (btnQue20.BackColor == Color.SteelBlue)
            {
                currIndex = 19;
                StoreQue(currIndex);
            }
            else
            {
                btnListGreen(currIndex + 1);
                DialogResult r = MessageBox.Show("You have attended all the Questions\n Do you want to submit assessment...? ", "Note", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    //currIndex = 0;
                    QuestionNumberGroupBox.Enabled = false;
                    QuestionGroupBox.Enabled = false;
                    btnTestSubmit.Focus();
                }
            }





        }

        //-------------------------------------- BUTTON NUMBERS FROM 1 TO 20------------------------------------------------
        private void btnQue1_Click(object sender, EventArgs e)
        {


            StoreQue(currIndex = 0);
            storeAnswerToDB(currIndex, userOptions);

        }

        private void btnQue2_Click(object sender, EventArgs e)
        {


            StoreQue(currIndex = 1);
        }

        private void btnQue3_Click(object sender, EventArgs e)
        {
            //if (!radioBtnOptionA.Checked && !radioBtnOptionB.Checked && !radioBtnOpitionC.Checked && !radioBtnOptionD.Checked)
            //{
            //    TestPageErrorProvider.SetError(radioBtnOptionA, "Select the option");
            //}

            StoreQue(currIndex = 2);
        }

        private void btnQue4_Click(object sender, EventArgs e)
        {
            //if (!radioBtnOptionA.Checked && !radioBtnOptionB.Checked && !radioBtnOpitionC.Checked && !radioBtnOptionD.Checked)
            //{
            //    TestPageErrorProvider.SetError(radioBtnOptionA, "Select the option");
            //}


            StoreQue(currIndex = 3);
        }

        private void btnQue5_Click(object sender, EventArgs e)
        {
            //if (!radioBtnOptionA.Checked && !radioBtnOptionB.Checked && !radioBtnOpitionC.Checked && !radioBtnOptionD.Checked)
            //{
            //    TestPageErrorProvider.SetError(radioBtnOptionA, "Select the option");
            //}
            StoreQue(currIndex = 4);
        }

        private void btnQue6_Click(object sender, EventArgs e)
        {
            //if (!radioBtnOptionA.Checked && !radioBtnOptionB.Checked && !radioBtnOpitionC.Checked && !radioBtnOptionD.Checked)
            //{
            //    TestPageErrorProvider.SetError(radioBtnOptionA, "Select the option");
            //}
            StoreQue(currIndex = 5);
        }

        private void btnQue7_Click(object sender, EventArgs e)
        {
            //if (!radioBtnOptionA.Checked && !radioBtnOptionB.Checked && !radioBtnOpitionC.Checked && !radioBtnOptionD.Checked)
            //{
            //    TestPageErrorProvider.SetError(radioBtnOptionA, "Select the option");
            //}
            StoreQue(currIndex = 6);
        }

        private void btnQue8_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 7);
        }

        private void btnQue9_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 8);
        }

        private void btnQue10_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 9);
        }

        private void btnQue11_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 10);
        }

        private void btnQue12_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 11);
        }

        private void btnQue13_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 12);
        }

        private void btnQue14_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 13);
        }

        private void btnQue15_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 14);
        }

        private void btnQue16_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 15);
        }

        private void btnQue17_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 16);
        }

        private void btnQue18_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 17);
        }

        private void btnQue19_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 18);
        }

        private void btnQue20_Click(object sender, EventArgs e)
        {
            StoreQue(currIndex = 19);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btnTestSubmit_Click(object sender, EventArgs e)
        {

            DialogResult Submit = MessageBox.Show(" once you click on Yes The assessment website will be Closed\n Are you Sure Want to submit the Assessment ", "Submit Assessment ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Submit == DialogResult.Yes)
            {
                StudentDashBoard Stud = new StudentDashBoard();
                Stud.MdiParent = this.MdiParent;
                this.Close();
                Stud.Show();
            }
        }
    }
}
