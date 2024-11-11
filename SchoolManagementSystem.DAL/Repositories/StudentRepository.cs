using SchoolManagementSystem.DAL.Interfaces;
using SchoolManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SchoolManagementSystem.DAL.Repositories
{


    public class StudentRepository : IStudentRepository
    {
        private readonly string _filePath = "students.json";

        public StudentRepository()
        {
            // Create the JSON file if it doesn't exist
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonSerializer.Serialize(new { students = new List<Student>() }));
            }
        }

        public List<Student> LoadStudents()
        {
            // Read students from JSON
            var jsonData = File.ReadAllText(_filePath);
            var data = JsonSerializer.Deserialize<Root>(jsonData);
            return data.Students;
        }

        public void SaveStudents(List<Student> students)
        {
            // Write students to JSON
            var data = new Root { Students = students };
            var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }

        public void AddStudent(Student student)
        {
            var students = LoadStudents();
            students.Add(student);
            SaveStudents(students);
        }

        public List<Student> GetAllStudents()
        {
            return LoadStudents();
        }

        public Student GetStudentByUsername(string username)
        {
            var data = LoadData();
            return data.Students.FirstOrDefault(s => s.Username == username);
        }

        public Student GetStudentByEmailAndName(string email,string firstname)
        {
            var data = LoadData();
            return data.Students.FirstOrDefault(s => s.Email == email && s.FirstName == firstname);
        }

        private Root LoadData()
        {
            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<Root>(jsonData) ?? new Root();
        }
    }

    // Root class to support JSON structure
    public class Root
    {
        public List<Student> Students { get; set; } = new List<Student>();
    }

}