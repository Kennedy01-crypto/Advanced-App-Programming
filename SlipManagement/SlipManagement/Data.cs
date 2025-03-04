// Data.cs or Models.cs
using System;
using System.Collections.Generic;

public class Student
{
    public string StudentId { get; set; }
    public string Name { get; set; }
    public string Course { get; set; }

    public Dictionary<string, int> Grades { get; set; } = new Dictionary<string, int>();
    public Dictionary<DateTime, bool> Attendance { get; set; } = new Dictionary<DateTime, bool>();
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } // "admin" or "student"
    public string StudentId { get; set; } // student id if the user is a student.
}

public static class DataStore
{
    public static Dictionary<string, Student> Students = new Dictionary<string, Student>();
    //public static Dictionary<string, int> Students = new Dictionary<string, int>();
    public static List<User> Users = new List<User>();

    static DataStore()
    {
        // Initialize admin user
        Users.Add(new User { Username = "admin", Password = "123", Role = "admin" });
        //AppDomainInitializer a default student account
        //Users.Add(new User { Username = "jim", Password= "password", Role = "student" });
    }
}