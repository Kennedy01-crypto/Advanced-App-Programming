# Slip Management Solution

## Overview

The Slip Management Solution is a Windows Forms application designed to manage student records, including their details, grades, and attendance. The application provides functionalities for both administrators and students.

## Features

- **User Authentication:**

  - Users can log in as either an admin or a student.
  - Admins have access to manage student records, while students can view their own details and results.

- **Admin Functionalities:**

  - Add new students to the system.
  - Edit existing student details.
  - Enter grades for students.
  - Generate result slips for students.

- **Student Functionalities:**
  - View personal details, including name and course.
  - View grades for each course.
  - Check attendance records.

## Data Models

- **Student:**
  - Properties: `StudentId`, `Name`, `Course`, `Grades`, `Attendance`.
- **User:**
  - Properties: `Username`, `Password`, `Role` (admin or student), `StudentId`.

## Getting Started

1. Clone the repository.
2. Ensure you have .NET Framework installed.
3. Open the solution in Visual Studio.
4. Build the project and run the application.

## Usage

- Launch the application and log in using the provided credentials.
- Admins can manage student records through the Admin interface.
- Students can view their details and results through the Student interface.

## License

This project is licensed under the MIT License.
