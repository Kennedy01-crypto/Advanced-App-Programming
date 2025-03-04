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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        //Implement the methods from the console version here, but adapt them to use Windows Forms controls.
        //Example for adding student, you will need to add textboxes and buttons to the designer.
        private void addStudentButton_Click(object sender, EventArgs e)
        {
            string id = studentIdTextBox.Text;
            string name = nameTextBox.Text;
            string course = courseTextBox.Text;

            DataStore.Students[id] = new Student { StudentId = id, Name = name, Course = course};
            DataStore.Users.Add(new User { Username = id, Password = "123", Role = "student", StudentId = id });
            MessageBox.Show("Student Added");
            studentIdTextBox.Text = "";
            nameTextBox.Text = "";
            courseTextBox.Text = "";
            gradeValueTextBox.Text = "";
            gradeCourseTextBox.Text = "";
        }
        //Add similar implementations for EditStudent, EnterGrades, GenerateResultSlip.
        private void editStudentButton_Click(object sender, EventArgs e)
        {
            string id = studentIdTextBox.Text;

            if (DataStore.Students.ContainsKey(id))
            {
                DataStore.Students[id].Name = nameTextBox.Text;
                DataStore.Students[id].Course = courseTextBox.Text;
                MessageBox.Show("Student details updated.");
            }
            else
            {
                MessageBox.Show("Student not found.");
            }
        }
        private void logoutButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
        

        

        private void enterGradesButton_Click(object sender, EventArgs e)
        {
            string id = studentIdTextBox.Text;
            string courseName = gradeCourseTextBox.Text;
            if (int.TryParse(gradeValueTextBox.Text, out int grade))
            {
                if (DataStore.Students.ContainsKey(id))
                {
                    DataStore.Students[id].Grades[courseName] = grade;
                    MessageBox.Show("Grade entered.");
                }
                else
                {
                    MessageBox.Show("Student not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid grade.");
            }
        }

        private void generateSlipButton_Click(object sender, EventArgs e)
        {
            string id = studentIdTextBox.Text;

            if (DataStore.Students.ContainsKey(id))
            {
                Student student = DataStore.Students[id];
                string slip = $"--- Result Slip for {student.Name} ({student.StudentId}) ---\r\n";
                slip += $"Course: {student.Course}\r\n";
                foreach (var grade in student.Grades)
                {
                    slip += $"{grade.Key}: {grade.Value}\r\n";
                }
                MessageBox.Show(slip, "Result Slip");
            }
            else
            {
                MessageBox.Show("Student not found.");
            }
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
