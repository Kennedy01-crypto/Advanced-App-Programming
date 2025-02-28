using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVIMS
{
    public partial class Form1 : Form
    {
        private List<Voter> voters = new List<Voter>();
        private TextBox voterCardIDTextBox, nationalIDTextBox, firstNameTextBox, middleNameTextBox, surnameTextBox, pollingStationTextBox, dobTextBox, genderTextBox;
        private Button addButton, displayButton, ClearButton;
        private TextBox displayTextBox;
        public Form1()
        {   // Form properties
            this.Text = "Voter Management System";
            this.ClientSize = new Size(600, 400);
            // Initialize the user interface elements
            InitializeUI();
        }

        //private void Form1_Load(object sender, EventArgs e)
        private void InitializeUI()
        {

            // Labels and TextBoxes
            Label voterCardIDLabel = new Label { Text = "Voter Card ID:", Location = new Point(10, 10), Size = new Size(100, 20) };
            voterCardIDTextBox = new TextBox { Location = new Point(120, 10), Size = new Size(150, 20) };

            Label nationalIDLabel = new Label { Text = "National ID:", Location = new Point(10, 40), Size = new Size(100, 20) };
            nationalIDTextBox = new TextBox { Location = new Point(120, 40), Size = new Size(150, 20) };

            Label firstNameLabel = new Label { Text = "First Name:", Location = new Point(10, 70), Size = new Size(100, 20) };
            firstNameTextBox = new TextBox { Location = new Point(120, 70), Size = new Size(150, 20) };

            Label middleNameLabel = new Label { Text = "Middle Name:", Location = new Point(10, 100), Size = new Size(100, 20) };
            middleNameTextBox = new TextBox { Location = new Point(120, 100), Size = new Size(150, 20) };

            Label surnameLabel = new Label { Text = "Surname:", Location = new Point(10, 130), Size = new Size(100, 20) };
            surnameTextBox = new TextBox { Location = new Point(120, 130), Size = new Size(150, 20) };

            Label pollingStationLabel = new Label { Text = "Polling Station:", Location = new Point(10, 160), Size = new Size(100, 20) };
            pollingStationTextBox = new TextBox { Location = new Point(120, 160), Size = new Size(150, 20) };

            Label dobLabel = new Label { Text = "Date of Birth (dd-MM-yyyy):", Location = new Point(10, 190), Size = new Size(150, 20) };
            dobTextBox = new TextBox { Location = new Point(170, 190), Size = new Size(100, 20) };

            Label genderLabel = new Label { Text = "Gender:", Location = new Point(10, 220), Size = new Size(100, 20) };
            genderTextBox = new TextBox { Location = new Point(120, 220), Size = new Size(150, 20) };

            // Buttons
            addButton = new Button { Text = "Add Voter", Location = new Point(10, 250), Size = new Size(100, 30) };
            displayButton = new Button { Text = "Display Voters", Location = new Point(120, 250), Size = new Size(100, 30) };
            ClearButton = new Button { Text = "Clear Voters", Location = new Point(10,300), Size = new Size(100, 30) };

            // Display TextBox
            displayTextBox = new TextBox { Location = new Point(300, 10), Size = new Size(280, 380), Multiline = true, ScrollBars = ScrollBars.Vertical };

            // Add controls to the form
            this.Controls.AddRange(new Control[] {
            voterCardIDLabel, voterCardIDTextBox,
            nationalIDLabel, nationalIDTextBox,
            firstNameLabel, firstNameTextBox,
            middleNameLabel, middleNameTextBox,
            surnameLabel, surnameTextBox,
            pollingStationLabel, pollingStationTextBox,
            dobLabel, dobTextBox,
            genderLabel, genderTextBox,
            addButton, displayButton, ClearButton,
            displayTextBox
            });

            // Event handlers
            addButton.Click += addButton_Click;
            displayButton.Click += displayButton_Click;
            ClearButton.Click += ClearButton_Click;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DateTime dateOfBirth;
            if (!DateTime.TryParseExact(dobTextBox.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOfBirth))
            {
                MessageBox.Show("Invalid date format. Please use dd-mm-yyyy.");
                return;
            }

            Voter newVoter = new Voter(
                voterCardIDTextBox.Text,
                nationalIDTextBox.Text,
                firstNameTextBox.Text,
                middleNameTextBox.Text,
                surnameTextBox.Text,
                pollingStationTextBox.Text,
                dateOfBirth,
                genderTextBox.Text
            );

            voters.Add(newVoter);
            MessageBox.Show("Voter added successfully!");
            //ClearForm();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            displayTextBox.Clear();
            if (voters.Count == 0)
            {
                displayTextBox.Text = "No voters registered.";
                return;
            }

            foreach (Voter voter in voters)
            {
                displayTextBox.AppendText($"Voter Card ID: {voter.VoterCardID}\r\n");
                displayTextBox.AppendText($"National ID Number: {voter.NationalID}\r\n");
                displayTextBox.AppendText($"First Name: {voter.FirstName}\r\n");
                displayTextBox.AppendText($"Middle Name: {voter.MiddleName}\r\n");
                displayTextBox.AppendText($"Surname: {voter.Surname}\r\n");
                displayTextBox.AppendText($"Polling Station: {voter.PollingStation}\r\n");
                displayTextBox.AppendText($"Date of Birth: {voter.DateOfBirth.ToString("dd-MM-yyyy")}\r\n");
                displayTextBox.AppendText($"Gender: {voter.Gender}\r\n");
                displayTextBox.AppendText("------------------------\r\n");
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Clear the list of voters
            voters.Clear();

            // Clear the display TextBox
            displayTextBox.Clear();
            displayTextBox.Text = "Voter list cleared."; // Optional message

            // Clear the input textboxes (optional - if you want to clear the form as well)
            voterCardIDTextBox.Clear();
            nationalIDTextBox.Clear();
            firstNameTextBox.Clear();
            middleNameTextBox.Clear();
            surnameTextBox.Clear();
            pollingStationTextBox.Clear();
            dobTextBox.Clear();
            genderTextBox.Clear(); // Or reset the ComboBox if you're using one

            MessageBox.Show("Voter data cleared."); // Optional confirmation message
        }

    }
    public class Voter
    {
        public string VoterCardID { get; set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string PollingStation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public Voter(string voterCardID, string nationalID, string firstName, string middleName, string surname, string pollingStation, DateTime dateOfBirth, string gender)
        {
            VoterCardID = voterCardID;
            NationalID = nationalID;
            FirstName = firstName;
            MiddleName = middleName;
            Surname = surname;
            PollingStation = pollingStation;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }
    }
}
