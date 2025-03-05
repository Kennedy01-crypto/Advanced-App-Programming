namespace SlipManagement
{
    partial class AdminForm
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

        private void InitializeComponent()
        {
            this.studentIdTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.courseTextBox = new System.Windows.Forms.TextBox();
            this.addStudentButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.editStudentButton = new System.Windows.Forms.Button();
            this.enterGradesButton = new System.Windows.Forms.Button();
            this.generateSlipButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.gradeCourseTextBox = new System.Windows.Forms.TextBox();
            this.gradeValueTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // studentIdTextBox
            // 
            this.studentIdTextBox.Location = new System.Drawing.Point(100, 30);
            this.studentIdTextBox.Name = "studentIdTextBox";
            this.studentIdTextBox.Size = new System.Drawing.Size(150, 20);
            this.studentIdTextBox.TabIndex = 0;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(100, 60);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(150, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // courseTextBox
            // 
            this.courseTextBox.Location = new System.Drawing.Point(100, 90);
            this.courseTextBox.Name = "courseTextBox";
            this.courseTextBox.Size = new System.Drawing.Size(150, 20);
            this.courseTextBox.TabIndex = 2;
            // 
            // addStudentButton
            // 
            this.addStudentButton.Location = new System.Drawing.Point(30, 120);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(75, 23);
            this.addStudentButton.TabIndex = 3;
            this.addStudentButton.Text = "Add Student";
            this.addStudentButton.UseVisualStyleBackColor = true;
            this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Student ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Course";
            // 
            // editStudentButton
            // 
            this.editStudentButton.Location = new System.Drawing.Point(110, 120);
            this.editStudentButton.Name = "editStudentButton";
            this.editStudentButton.Size = new System.Drawing.Size(75, 23);
            this.editStudentButton.TabIndex = 7;
            this.editStudentButton.Text = "Edit Student";
            this.editStudentButton.UseVisualStyleBackColor = true;
            this.editStudentButton.Click += new System.EventHandler(this.editStudentButton_Click);
            // 
            // enterGradesButton
            // 
            this.enterGradesButton.Location = new System.Drawing.Point(190, 120);
            this.enterGradesButton.Name = "enterGradesButton";
            this.enterGradesButton.Size = new System.Drawing.Size(80, 23);
            this.enterGradesButton.TabIndex = 8;
            this.enterGradesButton.Text = "Enter Grades";
            this.enterGradesButton.UseVisualStyleBackColor = true;
            this.enterGradesButton.Click += new System.EventHandler(this.enterGradesButton_Click);
            // 
            // generateSlipButton
            // 
            this.generateSlipButton.Location = new System.Drawing.Point(275, 120);
            this.generateSlipButton.Name = "generateSlipButton";
            this.generateSlipButton.Size = new System.Drawing.Size(100, 23);
            this.generateSlipButton.TabIndex = 9;
            this.generateSlipButton.Text = "Generate Slip";
            this.generateSlipButton.UseVisualStyleBackColor = true;
            this.generateSlipButton.Click += new System.EventHandler(this.generateSlipButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(30, 150);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 10;
            this.logoutButton.Text = "Logout";
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // gradeCourseTextBox
            // 
            this.gradeCourseTextBox.Location = new System.Drawing.Point(300, 30);
            this.gradeCourseTextBox.Name = "gradeCourseTextBox";
            this.gradeCourseTextBox.Size = new System.Drawing.Size(100, 20);
            this.gradeCourseTextBox.TabIndex = 11;
            // 
            // gradeValueTextBox
            // 
            this.gradeValueTextBox.Location = new System.Drawing.Point(300, 60);
            this.gradeValueTextBox.Name = "gradeValueTextBox";
            this.gradeValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.gradeValueTextBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Unit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Grade";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 190);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gradeValueTextBox);
            this.Controls.Add(this.gradeCourseTextBox);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.generateSlipButton);
            this.Controls.Add(this.enterGradesButton);
            this.Controls.Add(this.editStudentButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addStudentButton);
            this.Controls.Add(this.courseTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.studentIdTextBox);
            this.Name = "AdminForm";
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.AdminForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

            //#endregion

        private System.Windows.Forms.TextBox studentIdTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox courseTextBox;
        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button editStudentButton;
        private System.Windows.Forms.Button enterGradesButton;
        private System.Windows.Forms.Button generateSlipButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.TextBox gradeCourseTextBox;
        private System.Windows.Forms.TextBox gradeValueTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

            
    }
}