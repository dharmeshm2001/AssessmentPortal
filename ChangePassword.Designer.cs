namespace Assessments
{
    partial class ChangePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblNewPwd = new System.Windows.Forms.Label();
            this.lblExistingPwd = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnChangePwdSave = new System.Windows.Forms.Button();
            this.btnChangepwdCancel = new System.Windows.Forms.Button();
            this.txtConfirmPwd = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtCurrentPwd = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(777, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Red;
            this.lblUserName.Location = new System.Drawing.Point(166, 27);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 28);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.lblMsg);
            this.groupBox2.Controls.Add(this.lblNewPwd);
            this.groupBox2.Controls.Add(this.lblExistingPwd);
            this.groupBox2.Controls.Add(this.lblEmail);
            this.groupBox2.Controls.Add(this.btnChangePwdSave);
            this.groupBox2.Controls.Add(this.btnChangepwdCancel);
            this.groupBox2.Controls.Add(this.txtConfirmPwd);
            this.groupBox2.Controls.Add(this.txtNewPwd);
            this.groupBox2.Controls.Add(this.txtCurrentPwd);
            this.groupBox2.Location = new System.Drawing.Point(18, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 319);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(276, 271);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 21);
            this.lblMsg.TabIndex = 17;
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.AutoSize = true;
            this.lblNewPwd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPwd.Location = new System.Drawing.Point(59, 136);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(161, 24);
            this.lblNewPwd.TabIndex = 16;
            this.lblNewPwd.Text = "Confirm Password";
            // 
            // lblExistingPwd
            // 
            this.lblExistingPwd.AutoSize = true;
            this.lblExistingPwd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExistingPwd.Location = new System.Drawing.Point(89, 79);
            this.lblExistingPwd.Name = "lblExistingPwd";
            this.lblExistingPwd.Size = new System.Drawing.Size(131, 24);
            this.lblExistingPwd.TabIndex = 15;
            this.lblExistingPwd.Text = "New Password";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(62, 30);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(158, 24);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Current Password";
            // 
            // btnChangePwdSave
            // 
            this.btnChangePwdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnChangePwdSave.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePwdSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnChangePwdSave.Location = new System.Drawing.Point(535, 183);
            this.btnChangePwdSave.Name = "btnChangePwdSave";
            this.btnChangePwdSave.Size = new System.Drawing.Size(147, 59);
            this.btnChangePwdSave.TabIndex = 13;
            this.btnChangePwdSave.Text = "Save";
            this.btnChangePwdSave.UseVisualStyleBackColor = false;
            this.btnChangePwdSave.Click += new System.EventHandler(this.btnChangePwdSave_Click);
            // 
            // btnChangepwdCancel
            // 
            this.btnChangepwdCancel.BackColor = System.Drawing.Color.Red;
            this.btnChangepwdCancel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangepwdCancel.ForeColor = System.Drawing.Color.Transparent;
            this.btnChangepwdCancel.Location = new System.Drawing.Point(276, 183);
            this.btnChangepwdCancel.Name = "btnChangepwdCancel";
            this.btnChangepwdCancel.Size = new System.Drawing.Size(151, 59);
            this.btnChangepwdCancel.TabIndex = 12;
            this.btnChangepwdCancel.Text = "Cancel";
            this.btnChangepwdCancel.UseVisualStyleBackColor = false;
            this.btnChangepwdCancel.Click += new System.EventHandler(this.btnChangepwdCancel_Click);
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPwd.Location = new System.Drawing.Point(276, 128);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.PasswordChar = '*';
            this.txtConfirmPwd.Size = new System.Drawing.Size(406, 32);
            this.txtConfirmPwd.TabIndex = 11;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPwd.Location = new System.Drawing.Point(276, 79);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(406, 32);
            this.txtNewPwd.TabIndex = 10;
            // 
            // txtCurrentPwd
            // 
            this.txtCurrentPwd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPwd.Location = new System.Drawing.Point(276, 27);
            this.txtCurrentPwd.Name = "txtCurrentPwd";
            this.txtCurrentPwd.PasswordChar = '*';
            this.txtCurrentPwd.Size = new System.Drawing.Size(406, 32);
            this.txtCurrentPwd.TabIndex = 9;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(816, 487);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNewPwd;
        private System.Windows.Forms.Label lblExistingPwd;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnChangePwdSave;
        private System.Windows.Forms.Button btnChangepwdCancel;
        private System.Windows.Forms.TextBox txtConfirmPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtCurrentPwd;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}