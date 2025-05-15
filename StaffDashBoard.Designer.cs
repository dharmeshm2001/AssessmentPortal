namespace Assessments
{
    partial class StaffDashBoard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lnkChangePassword = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStaffLogout = new System.Windows.Forms.Button();
            this.btnAddUpdateQuestion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnQuestionGBCancel = new System.Windows.Forms.Button();
            this.QuestionGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBoxAddUpdateQuestions = new System.Windows.Forms.GroupBox();
            this.lblSubId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkQueActivate = new System.Windows.Forms.CheckBox();
            this.lblInsertQueMsg = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuestionSave = new System.Windows.Forms.Button();
            this.radioBtnOptionD = new System.Windows.Forms.RadioButton();
            this.radioBtnOption3 = new System.Windows.Forms.RadioButton();
            this.radioBtnOptionB = new System.Windows.Forms.RadioButton();
            this.radioBtnOptionA = new System.Windows.Forms.RadioButton();
            this.txtOptionD = new System.Windows.Forms.TextBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtOptionC = new System.Windows.Forms.TextBox();
            this.txtOptionA = new System.Windows.Forms.TextBox();
            this.txtOptionB = new System.Windows.Forms.TextBox();
            this.QuestionsLIstGroupBox = new System.Windows.Forms.GroupBox();
            this.QuestionsGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxSubjectSelection = new System.Windows.Forms.GroupBox();
            this.lblComSubMsg = new System.Windows.Forms.Label();
            this.btnCancelSub = new System.Windows.Forms.Button();
            this.btnSelectSub = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comStaffSubjects = new System.Windows.Forms.ComboBox();
            this.StaffPageErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.QuestionGroupBox.SuspendLayout();
            this.groupBoxAddUpdateQuestions.SuspendLayout();
            this.QuestionsLIstGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionsGridView)).BeginInit();
            this.groupBoxSubjectSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StaffPageErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.lnkChangePassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStaffLogout);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1611, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(157, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 28);
            this.lblUserName.TabIndex = 1;
            // 
            // lnkChangePassword
            // 
            this.lnkChangePassword.AutoSize = true;
            this.lnkChangePassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkChangePassword.Location = new System.Drawing.Point(1240, 25);
            this.lnkChangePassword.Name = "lnkChangePassword";
            this.lnkChangePassword.Size = new System.Drawing.Size(157, 24);
            this.lnkChangePassword.TabIndex = 0;
            this.lnkChangePassword.TabStop = true;
            this.lnkChangePassword.Text = "Change password";
            this.lnkChangePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChangePassword_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome: ";
            // 
            // btnStaffLogout
            // 
            this.btnStaffLogout.BackColor = System.Drawing.Color.Red;
            this.btnStaffLogout.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffLogout.ForeColor = System.Drawing.Color.White;
            this.btnStaffLogout.Location = new System.Drawing.Point(1458, 15);
            this.btnStaffLogout.Name = "btnStaffLogout";
            this.btnStaffLogout.Size = new System.Drawing.Size(135, 44);
            this.btnStaffLogout.TabIndex = 0;
            this.btnStaffLogout.Text = "Logout";
            this.btnStaffLogout.UseVisualStyleBackColor = false;
            this.btnStaffLogout.Click += new System.EventHandler(this.btnStaffLogout_Click);
            // 
            // btnAddUpdateQuestion
            // 
            this.btnAddUpdateQuestion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddUpdateQuestion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUpdateQuestion.Location = new System.Drawing.Point(10, 13);
            this.btnAddUpdateQuestion.Name = "btnAddUpdateQuestion";
            this.btnAddUpdateQuestion.Size = new System.Drawing.Size(240, 77);
            this.btnAddUpdateQuestion.TabIndex = 3;
            this.btnAddUpdateQuestion.Text = "Add/Update Questions";
            this.btnAddUpdateQuestion.UseVisualStyleBackColor = false;
            this.btnAddUpdateQuestion.Click += new System.EventHandler(this.btnAddUpdateQuestion_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.btnAddUpdateQuestion);
            this.groupBox2.Location = new System.Drawing.Point(12, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 96);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnQuestionGBCancel
            // 
            this.btnQuestionGBCancel.BackColor = System.Drawing.Color.Red;
            this.btnQuestionGBCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuestionGBCancel.ForeColor = System.Drawing.Color.White;
            this.btnQuestionGBCancel.Location = new System.Drawing.Point(1118, 30);
            this.btnQuestionGBCancel.Name = "btnQuestionGBCancel";
            this.btnQuestionGBCancel.Size = new System.Drawing.Size(198, 36);
            this.btnQuestionGBCancel.TabIndex = 3;
            this.btnQuestionGBCancel.Text = "Cancel";
            this.btnQuestionGBCancel.UseVisualStyleBackColor = false;
            this.btnQuestionGBCancel.Click += new System.EventHandler(this.btnQuestionGBCancel_Click);
            // 
            // QuestionGroupBox
            // 
            this.QuestionGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.QuestionGroupBox.Controls.Add(this.btnQuestionGBCancel);
            this.QuestionGroupBox.Controls.Add(this.groupBoxAddUpdateQuestions);
            this.QuestionGroupBox.Controls.Add(this.QuestionsLIstGroupBox);
            this.QuestionGroupBox.Controls.Add(this.groupBoxSubjectSelection);
            this.QuestionGroupBox.Location = new System.Drawing.Point(278, 109);
            this.QuestionGroupBox.Name = "QuestionGroupBox";
            this.QuestionGroupBox.Size = new System.Drawing.Size(1345, 732);
            this.QuestionGroupBox.TabIndex = 5;
            this.QuestionGroupBox.TabStop = false;
            this.QuestionGroupBox.Visible = false;
            // 
            // groupBoxAddUpdateQuestions
            // 
            this.groupBoxAddUpdateQuestions.Controls.Add(this.lblSubId);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.label9);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.chkQueActivate);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.lblInsertQueMsg);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.label8);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.label7);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.label6);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.label5);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.label4);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.label3);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.btnQuestionSave);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.radioBtnOptionD);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.radioBtnOption3);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.radioBtnOptionB);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.radioBtnOptionA);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.txtOptionD);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.txtQuestion);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.txtOptionC);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.txtOptionA);
            this.groupBoxAddUpdateQuestions.Controls.Add(this.txtOptionB);
            this.groupBoxAddUpdateQuestions.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAddUpdateQuestions.Location = new System.Drawing.Point(20, 173);
            this.groupBoxAddUpdateQuestions.Name = "groupBoxAddUpdateQuestions";
            this.groupBoxAddUpdateQuestions.Size = new System.Drawing.Size(496, 541);
            this.groupBoxAddUpdateQuestions.TabIndex = 2;
            this.groupBoxAddUpdateQuestions.TabStop = false;
            this.groupBoxAddUpdateQuestions.Text = "Add/Update Question";
            // 
            // lblSubId
            // 
            this.lblSubId.AutoSize = true;
            this.lblSubId.Location = new System.Drawing.Point(138, 49);
            this.lblSubId.Name = "lblSubId";
            this.lblSubId.Size = new System.Drawing.Size(0, 21);
            this.lblSubId.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 428);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 21);
            this.label9.TabIndex = 20;
            this.label9.Text = "Activate";
            // 
            // chkQueActivate
            // 
            this.chkQueActivate.AutoSize = true;
            this.chkQueActivate.Location = new System.Drawing.Point(142, 432);
            this.chkQueActivate.Name = "chkQueActivate";
            this.chkQueActivate.Size = new System.Drawing.Size(18, 17);
            this.chkQueActivate.TabIndex = 19;
            this.chkQueActivate.UseVisualStyleBackColor = true;
            // 
            // lblInsertQueMsg
            // 
            this.lblInsertQueMsg.AutoSize = true;
            this.lblInsertQueMsg.Location = new System.Drawing.Point(33, 479);
            this.lblInsertQueMsg.Name = "lblInsertQueMsg";
            this.lblInsertQueMsg.Size = new System.Drawing.Size(0, 21);
            this.lblInsertQueMsg.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 385);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 21);
            this.label8.TabIndex = 17;
            this.label8.Text = "Correct Option";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "Option D";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "Option C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 21);
            this.label5.TabIndex = 14;
            this.label5.Text = "Option B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "Option A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Question";
            // 
            // btnQuestionSave
            // 
            this.btnQuestionSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnQuestionSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuestionSave.ForeColor = System.Drawing.Color.White;
            this.btnQuestionSave.Location = new System.Drawing.Point(232, 419);
            this.btnQuestionSave.Name = "btnQuestionSave";
            this.btnQuestionSave.Size = new System.Drawing.Size(239, 44);
            this.btnQuestionSave.TabIndex = 11;
            this.btnQuestionSave.Text = "Save";
            this.btnQuestionSave.UseVisualStyleBackColor = false;
            this.btnQuestionSave.Click += new System.EventHandler(this.btnQuestionSave_Click);
            // 
            // radioBtnOptionD
            // 
            this.radioBtnOptionD.AutoSize = true;
            this.radioBtnOptionD.Location = new System.Drawing.Point(375, 381);
            this.radioBtnOptionD.Name = "radioBtnOptionD";
            this.radioBtnOptionD.Size = new System.Drawing.Size(41, 25);
            this.radioBtnOptionD.TabIndex = 10;
            this.radioBtnOptionD.TabStop = true;
            this.radioBtnOptionD.Text = "D";
            this.radioBtnOptionD.UseVisualStyleBackColor = true;
            // 
            // radioBtnOption3
            // 
            this.radioBtnOption3.AutoSize = true;
            this.radioBtnOption3.Location = new System.Drawing.Point(305, 383);
            this.radioBtnOption3.Name = "radioBtnOption3";
            this.radioBtnOption3.Size = new System.Drawing.Size(40, 25);
            this.radioBtnOption3.TabIndex = 9;
            this.radioBtnOption3.TabStop = true;
            this.radioBtnOption3.Text = "C";
            this.radioBtnOption3.UseVisualStyleBackColor = true;
            // 
            // radioBtnOptionB
            // 
            this.radioBtnOptionB.AutoSize = true;
            this.radioBtnOptionB.Location = new System.Drawing.Point(232, 383);
            this.radioBtnOptionB.Name = "radioBtnOptionB";
            this.radioBtnOptionB.Size = new System.Drawing.Size(40, 25);
            this.radioBtnOptionB.TabIndex = 8;
            this.radioBtnOptionB.TabStop = true;
            this.radioBtnOptionB.Text = "B";
            this.radioBtnOptionB.UseVisualStyleBackColor = true;
            // 
            // radioBtnOptionA
            // 
            this.radioBtnOptionA.AutoSize = true;
            this.radioBtnOptionA.Location = new System.Drawing.Point(160, 383);
            this.radioBtnOptionA.Name = "radioBtnOptionA";
            this.radioBtnOptionA.Size = new System.Drawing.Size(41, 25);
            this.radioBtnOptionA.TabIndex = 7;
            this.radioBtnOptionA.TabStop = true;
            this.radioBtnOptionA.Text = "A";
            this.radioBtnOptionA.UseVisualStyleBackColor = true;
            // 
            // txtOptionD
            // 
            this.txtOptionD.Location = new System.Drawing.Point(142, 335);
            this.txtOptionD.Name = "txtOptionD";
            this.txtOptionD.Size = new System.Drawing.Size(264, 28);
            this.txtOptionD.TabIndex = 6;
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(142, 83);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(329, 65);
            this.txtQuestion.TabIndex = 2;
            // 
            // txtOptionC
            // 
            this.txtOptionC.Location = new System.Drawing.Point(142, 282);
            this.txtOptionC.Name = "txtOptionC";
            this.txtOptionC.Size = new System.Drawing.Size(264, 28);
            this.txtOptionC.TabIndex = 5;
            // 
            // txtOptionA
            // 
            this.txtOptionA.Location = new System.Drawing.Point(142, 172);
            this.txtOptionA.Name = "txtOptionA";
            this.txtOptionA.Size = new System.Drawing.Size(264, 28);
            this.txtOptionA.TabIndex = 4;
            // 
            // txtOptionB
            // 
            this.txtOptionB.Location = new System.Drawing.Point(142, 224);
            this.txtOptionB.Name = "txtOptionB";
            this.txtOptionB.Size = new System.Drawing.Size(264, 28);
            this.txtOptionB.TabIndex = 3;
            // 
            // QuestionsLIstGroupBox
            // 
            this.QuestionsLIstGroupBox.Controls.Add(this.QuestionsGridView);
            this.QuestionsLIstGroupBox.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionsLIstGroupBox.Location = new System.Drawing.Point(540, 173);
            this.QuestionsLIstGroupBox.Name = "QuestionsLIstGroupBox";
            this.QuestionsLIstGroupBox.Size = new System.Drawing.Size(787, 533);
            this.QuestionsLIstGroupBox.TabIndex = 1;
            this.QuestionsLIstGroupBox.TabStop = false;
            this.QuestionsLIstGroupBox.Text = "Questions List";
            // 
            // QuestionsGridView
            // 
            this.QuestionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuestionsGridView.Location = new System.Drawing.Point(2, 49);
            this.QuestionsGridView.Name = "QuestionsGridView";
            this.QuestionsGridView.RowHeadersWidth = 51;
            this.QuestionsGridView.RowTemplate.Height = 24;
            this.QuestionsGridView.Size = new System.Drawing.Size(774, 478);
            this.QuestionsGridView.TabIndex = 0;
            this.QuestionsGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.QuestionsGridView_RowHeaderMouseDoubleClick_1);
            // 
            // groupBoxSubjectSelection
            // 
            this.groupBoxSubjectSelection.Controls.Add(this.lblComSubMsg);
            this.groupBoxSubjectSelection.Controls.Add(this.btnCancelSub);
            this.groupBoxSubjectSelection.Controls.Add(this.btnSelectSub);
            this.groupBoxSubjectSelection.Controls.Add(this.label2);
            this.groupBoxSubjectSelection.Controls.Add(this.comStaffSubjects);
            this.groupBoxSubjectSelection.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSubjectSelection.Location = new System.Drawing.Point(162, 30);
            this.groupBoxSubjectSelection.Name = "groupBoxSubjectSelection";
            this.groupBoxSubjectSelection.Size = new System.Drawing.Size(937, 130);
            this.groupBoxSubjectSelection.TabIndex = 0;
            this.groupBoxSubjectSelection.TabStop = false;
            this.groupBoxSubjectSelection.Text = "Subject Selection";
            // 
            // lblComSubMsg
            // 
            this.lblComSubMsg.AutoSize = true;
            this.lblComSubMsg.Location = new System.Drawing.Point(212, 93);
            this.lblComSubMsg.Name = "lblComSubMsg";
            this.lblComSubMsg.Size = new System.Drawing.Size(0, 21);
            this.lblComSubMsg.TabIndex = 4;
            // 
            // btnCancelSub
            // 
            this.btnCancelSub.BackColor = System.Drawing.Color.Red;
            this.btnCancelSub.ForeColor = System.Drawing.Color.White;
            this.btnCancelSub.Location = new System.Drawing.Point(770, 41);
            this.btnCancelSub.Name = "btnCancelSub";
            this.btnCancelSub.Size = new System.Drawing.Size(113, 42);
            this.btnCancelSub.TabIndex = 3;
            this.btnCancelSub.Text = "Cancel";
            this.btnCancelSub.UseVisualStyleBackColor = false;
            this.btnCancelSub.Click += new System.EventHandler(this.btnCancelSub_Click);
            // 
            // btnSelectSub
            // 
            this.btnSelectSub.BackColor = System.Drawing.Color.Blue;
            this.btnSelectSub.ForeColor = System.Drawing.Color.White;
            this.btnSelectSub.Location = new System.Drawing.Point(641, 40);
            this.btnSelectSub.Name = "btnSelectSub";
            this.btnSelectSub.Size = new System.Drawing.Size(113, 43);
            this.btnSelectSub.TabIndex = 2;
            this.btnSelectSub.Text = "Select";
            this.btnSelectSub.UseVisualStyleBackColor = false;
            this.btnSelectSub.Click += new System.EventHandler(this.btnSelectSub_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose Subject";
            // 
            // comStaffSubjects
            // 
            this.comStaffSubjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comStaffSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comStaffSubjects.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comStaffSubjects.FormattingEnabled = true;
            this.comStaffSubjects.Location = new System.Drawing.Point(275, 42);
            this.comStaffSubjects.MaxDropDownItems = 10;
            this.comStaffSubjects.Name = "comStaffSubjects";
            this.comStaffSubjects.Size = new System.Drawing.Size(282, 29);
            this.comStaffSubjects.TabIndex = 0;
            // 
            // StaffPageErrorProvider
            // 
            this.StaffPageErrorProvider.ContainerControl = this;
            // 
            // StaffDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1648, 853);
            this.ControlBox = false;
            this.Controls.Add(this.QuestionGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1666, 900);
            this.Name = "StaffDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffDashBoard";
            this.Load += new System.EventHandler(this.StaffDashBoard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.QuestionGroupBox.ResumeLayout(false);
            this.groupBoxAddUpdateQuestions.ResumeLayout(false);
            this.groupBoxAddUpdateQuestions.PerformLayout();
            this.QuestionsLIstGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuestionsGridView)).EndInit();
            this.groupBoxSubjectSelection.ResumeLayout(false);
            this.groupBoxSubjectSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StaffPageErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.LinkLabel lnkChangePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStaffLogout;
        private System.Windows.Forms.Button btnAddUpdateQuestion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxSubjectSelection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox QuestionsLIstGroupBox;
        private System.Windows.Forms.TextBox txtOptionD;
        private System.Windows.Forms.TextBox txtOptionC;
        private System.Windows.Forms.TextBox txtOptionA;
        private System.Windows.Forms.TextBox txtOptionB;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.GroupBox groupBoxAddUpdateQuestions;
        private System.Windows.Forms.RadioButton radioBtnOptionD;
        private System.Windows.Forms.RadioButton radioBtnOption3;
        private System.Windows.Forms.RadioButton radioBtnOptionB;
        private System.Windows.Forms.RadioButton radioBtnOptionA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuestionSave;
        private System.Windows.Forms.Button btnQuestionGBCancel;
        private System.Windows.Forms.DataGridView QuestionsGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblInsertQueMsg;
        private System.Windows.Forms.CheckBox chkQueActivate;
        private System.Windows.Forms.ErrorProvider StaffPageErrorProvider;
        private System.Windows.Forms.Button btnCancelSub;
        private System.Windows.Forms.Button btnSelectSub;
        private System.Windows.Forms.Label lblSubId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox QuestionGroupBox;
        private System.Windows.Forms.ComboBox comStaffSubjects;
        private System.Windows.Forms.Label lblComSubMsg;
    }
}