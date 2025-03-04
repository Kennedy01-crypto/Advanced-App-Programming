using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlipManagement
{
    public partial class StudentForm : Form
    {
        private string studentId;

        public StudentForm(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
        }

        private void viewDetailsButton_Click(object sender, EventArgs e)
        {
            if (DataStore.Students.ContainsKey(studentId))
            {
                Student student = DataStore.Students[studentId];
                detailsTextBox.Text = $"Name: {student.Name}\r\nCourse: {student.Course}\r\n ";
            }
            else
            {
                detailsTextBox.Text = "Student information not found.";
            }
        }

        private void viewResultsButton_Click(object sender, EventArgs e)
        {
            if (DataStore.Students.ContainsKey(studentId))
            {
                Student student = DataStore.Students[studentId];
                resultsTextBox.Clear();
                foreach (var grade in student.Grades)
                {
                    resultsTextBox.AppendText($"{grade.Key}: {grade.Value}\r\n");
                }
            }
            else
            {
                resultsTextBox.Text = "Student information not found.";
            }
        }

        private void viewAttendanceButton_Click(object sender, EventArgs e)
        {
            if (DataStore.Students.ContainsKey(studentId))
            {
                Student student = DataStore.Students[studentId];
                attendanceTextBox.Clear();
                foreach (var attendance in student.Attendance)
                {
                    attendanceTextBox.AppendText($"{attendance.Key.ToShortDateString()}: {(attendance.Value ? "Present" : "Absent")}\r\n");
                }
            }
            else
            {
                attendanceTextBox.Text = "Student information not found.";
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
