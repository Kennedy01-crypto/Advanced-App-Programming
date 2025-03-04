namespace SlipManagement
{
    partial class StudentForm
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
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.attendanceTextBox = new System.Windows.Forms.TextBox();
            this.viewDetailsButton = new System.Windows.Forms.Button();
            this.viewResultsButton = new System.Windows.Forms.Button();
            this.viewAttendanceButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.Location = new System.Drawing.Point(12, 12);
            this.detailsTextBox.Multiline = true;
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.ReadOnly = true;
            this.detailsTextBox.Size = new System.Drawing.Size(200, 100);
            this.detailsTextBox.TabIndex = 0;
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Location = new System.Drawing.Point(220, 12);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ReadOnly = true;
            this.resultsTextBox.Size = new System.Drawing.Size(200, 100);
            this.resultsTextBox.TabIndex = 1;
            // 
            // attendanceTextBox
            // 
            this.attendanceTextBox.Location = new System.Drawing.Point(428, 12);
            this.attendanceTextBox.Multiline = true;
            this.attendanceTextBox.Name = "attendanceTextBox";
            this.attendanceTextBox.ReadOnly = true;
            this.attendanceTextBox.Size = new System.Drawing.Size(200, 100);
            this.attendanceTextBox.TabIndex = 2;
            // 
            // viewDetailsButton
            // 
            this.viewDetailsButton.Location = new System.Drawing.Point(12, 118);
            this.viewDetailsButton.Name = "viewDetailsButton";
            this.viewDetailsButton.Size = new System.Drawing.Size(75, 23);
            this.viewDetailsButton.TabIndex = 3;
            this.viewDetailsButton.Text = "View Details";
            this.viewDetailsButton.UseVisualStyleBackColor = true;
            this.viewDetailsButton.Click += new System.EventHandler(this.viewDetailsButton_Click);
            // 
            // viewResultsButton
            // 
            this.viewResultsButton.Location = new System.Drawing.Point(220, 118);
            this.viewResultsButton.Name = "viewResultsButton";
            this.viewResultsButton.Size = new System.Drawing.Size(80, 23);
            this.viewResultsButton.TabIndex = 4;
            this.viewResultsButton.Text = "View Results";
            this.viewResultsButton.UseVisualStyleBackColor = true;
            this.viewResultsButton.Click += new System.EventHandler(this.viewResultsButton_Click);
            // 
            // viewAttendanceButton
            // 
            this.viewAttendanceButton.Location = new System.Drawing.Point(428, 118);
            this.viewAttendanceButton.Name = "viewAttendanceButton";
            this.viewAttendanceButton.Size = new System.Drawing.Size(100, 23);
            this.viewAttendanceButton.TabIndex = 5;
            this.viewAttendanceButton.Text = "View Attendance";
            this.viewAttendanceButton.UseVisualStyleBackColor = true;
            this.viewAttendanceButton.Click += new System.EventHandler(this.viewAttendanceButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(12, 147);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 180);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.viewAttendanceButton);
            this.Controls.Add(this.viewResultsButton);
            this.Controls.Add(this.viewDetailsButton);
            this.Controls.Add(this.attendanceTextBox);
            this.Controls.Add(this.resultsTextBox);
            this.Controls.Add(this.detailsTextBox);
            this.Name = "StudentForm";
            this.Text = "Student Panel";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

            //#endregion

            private System.Windows.Forms.TextBox detailsTextBox;
            private System.Windows.Forms.TextBox resultsTextBox;
            private System.Windows.Forms.TextBox attendanceTextBox;
            private System.Windows.Forms.Button viewDetailsButton;
            private System.Windows.Forms.Button viewResultsButton;
            private System.Windows.Forms.Button viewAttendanceButton;
            private System.Windows.Forms.Button logoutButton;
        
        
    }
}