using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

class Student
{
    public string StudentID { get; private set; }
    public string Name { get; private set; }
    public Dictionary<string, double> Results { get; private set; }
    public double TotalMarks => Results.Values.Sum();
    public double Average => Results.Count > 0 ? TotalMarks / Results.Count : 0;
    public string Grade => CalculateGrade(Average);

    public static readonly string[] TechnicalSubjects = new string[]
    {
        "Programming",
        "Database Systems",
        "Networking",
        "Web Development",
        "Software Engineering",
        "Operating Systems",
        "Computer Architecture",
        "Cybersecurity"
    };

    public Student(string studentID, string name)
    {
        StudentID = studentID;
        Name = name;
        Results = new Dictionary<string, double>();
    }

    public bool AddResult(string subject, double score)
    {
        if (!TechnicalSubjects.Contains(subject))
        {
            Console.WriteLine("Invalid subject. Please choose from the following subjects:");
            foreach (var validSubject in TechnicalSubjects)
            {
                Console.WriteLine($"- {validSubject}");
            }
            return false;
        }

        if (score < 0 || score > 100)
        {
            Console.WriteLine("Score must be between 0 and 100");
            return false;
        }

        Results[subject] = score;
        return true;
    }

    private string CalculateGrade(double average)
    {
        if (average >= 70) return "A";
        if (average >= 60) return "B";
        if (average >= 50) return "C";
        if (average >= 40) return "D";
        return "F";
    }

    public void DisplayResultSlip()
    {
        Console.WriteLine($"\nResult Slip for {Name} (ID: {StudentID})");
        Console.WriteLine("-----------------------------------");
        foreach (var result in Results)
        {
            Console.WriteLine($"{result.Key}: {result.Value}");
        }
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Total Marks: {TotalMarks}");
        Console.WriteLine($"Average: {Average:F2}");
        Console.WriteLine($"Grade: {Grade}\n");
    }
}

class ResultManagementSystem
{
    private Dictionary<string, Student> students = new Dictionary<string, Student>();
    
    public void Start()
    {
        while (true)
        {
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. Add Student Result");
            Console.WriteLine("3. View Student Result Slip");
            Console.WriteLine("4. Generate PDF Result Slip");
            Console.WriteLine("5. Edit Student Result");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RegisterStudent();
                    break;
                case "2":
                    AddResult();
                    break;
                case "3":
                    ViewResultSlip();
                    break;
                case "4":
                    GeneratePDFResultSlip();
                    break;
                case "5":
                    EditResult();
                    break;
                case "6":
                    Console.WriteLine("Exiting system. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.\n");
                    break;
            }
        }
    }

    private void RegisterStudent()
    {
        Console.Write("Enter Student ID: ");
        string studentID = Console.ReadLine();
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();
        
        if (!students.ContainsKey(studentID))
        {
            students[studentID] = new Student(studentID, name);
            Console.WriteLine("Student registered successfully!\n");
        }
        else
        {
            Console.WriteLine("Student ID already exists.\n");
        }
    }

    private void AddResult()
    {
        Console.Write("Enter Student ID: ");
        string studentID = Console.ReadLine();
        if (students.ContainsKey(studentID))
        {
            Student student = students[studentID];
            Console.WriteLine($"\nEntering marks for student: {student.Name} (ID: {studentID})");
            Console.WriteLine("Enter marks for each subject (0-100). Press Enter after each mark.\n");

            foreach (string subject in Student.TechnicalSubjects)
            {
                bool validScore = false;
                while (!validScore)
                {
                    Console.Write($"{subject}: ");
                    string input = Console.ReadLine();
                    
                    if (double.TryParse(input, out double score))
                    {
                        if (score >= 0 && score <= 100)
                        {
                            student.AddResult(subject, score);
                            validScore = true;
                        }
                        else
                        {
                            Console.WriteLine("Score must be between 0 and 100. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
                    }
                }
            }
            
            Console.WriteLine("\nAll marks have been entered successfully!");
            Console.WriteLine("Here's the summary:");
            student.DisplayResultSlip();
        }
        else
        {
            Console.WriteLine("Student not found.\n");
        }
    }

    private void ViewResultSlip()
    {
        Console.Write("Enter Student ID: ");
        string studentID = Console.ReadLine();
        if (students.ContainsKey(studentID))
        {
            students[studentID].DisplayResultSlip();
        }
        else
        {
            Console.WriteLine("Student not found.\n");
        }
    }

    private void GeneratePDFResultSlip()
    {
        Console.Write("Enter Student ID: ");
        string studentID = Console.ReadLine();
        if (!students.ContainsKey(studentID))
        {
            Console.WriteLine("Student not found.\n");
            return;
        }

        Student student = students[studentID];
        string fileName = $"ResultSlip_{studentID}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                document.Open();

                try
                {
                    
                    if (File.Exists("logo.png"))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("logo.png");
                       
                        float desiredWidth = 200f;
                        float scale = desiredWidth / logo.Width;
                        logo.ScalePercent(scale * 100);
                        
                        logo.Alignment = Element.ALIGN_CENTER;
                        document.Add(logo);
                        
                        document.Add(new Paragraph("\n"));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Warning: Could not add logo to PDF: {ex.Message}");
                }

               
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                document.Add(new Paragraph("Student Result Slip", titleFont) { Alignment = Element.ALIGN_CENTER });
                document.Add(new Paragraph($"\nStudent Name: {student.Name}", normalFont));
                document.Add(new Paragraph($"Student ID: {student.StudentID}\n\n", normalFont));

       
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;

               
                table.AddCell(new PdfPCell(new Phrase("Subject", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Score", headerFont)));

                
                foreach (var result in student.Results)
                {
                    table.AddCell(new PdfPCell(new Phrase(result.Key, normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(result.Value.ToString(), normalFont)));
                }

                document.Add(table);

                
                document.Add(new Paragraph($"\nTotal Marks: {student.TotalMarks}", normalFont));
                document.Add(new Paragraph($"Average: {student.Average:F2}", normalFont));
                document.Add(new Paragraph($"Final Grade: {student.Grade}", headerFont));

                document.Close();
                Console.WriteLine($"PDF generated successfully: {fileName}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error generating PDF: {ex.Message}\n");
        }
    }

    private void EditResult()
    {
        Console.Write("Enter Student ID: ");
        string studentID = Console.ReadLine();
        
        if (!students.ContainsKey(studentID))
        {
            Console.WriteLine("Student not found.\n");
            return;
        }

        Student student = students[studentID];
        Console.WriteLine($"\nEditing marks for student: {student.Name} (ID: {studentID})");
        
        
        student.DisplayResultSlip();

        
        Console.WriteLine("\nSelect subject to edit:");
        for (int i = 0; i < Student.TechnicalSubjects.Length; i++)
        {
            string subject = Student.TechnicalSubjects[i];
            string currentMark = student.Results.ContainsKey(subject) 
                ? student.Results[subject].ToString() 
                : "Not set";
            Console.WriteLine($"{i + 1}. {subject} (Current mark: {currentMark})");
        }

        Console.Write("\nEnter subject number (1-8): ");
        if (int.TryParse(Console.ReadLine(), out int subjectIndex) && 
            subjectIndex >= 1 && 
            subjectIndex <= Student.TechnicalSubjects.Length)
        {
            string selectedSubject = Student.TechnicalSubjects[subjectIndex - 1];
            bool validScore = false;
            
            while (!validScore)
            {
                Console.Write($"Enter new mark for {selectedSubject} (0-100): ");
                if (double.TryParse(Console.ReadLine(), out double newScore))
                {
                    if (newScore >= 0 && newScore <= 100)
                    {
                        student.AddResult(selectedSubject, newScore);
                        validScore = true;
                        Console.WriteLine("\nMark updated successfully!");
                        Console.WriteLine("Updated results:");
                        student.DisplayResultSlip();
                    }
                    else
                    {
                        Console.WriteLine("Score must be between 0 and 100. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid subject number.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        ResultManagementSystem system = new ResultManagementSystem();
        system.Start();
    }
}
