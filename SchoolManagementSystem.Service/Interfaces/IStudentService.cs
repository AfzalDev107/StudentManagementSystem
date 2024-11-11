using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.DAL.Models;

namespace SchoolManagementSystem.Service.Interfaces
{
    public interface IStudentService
    {
        public string GenerateStudentId();
        public void RegisterStudent(Student student);
        public List<Student> GetRegisteredStudents();
        public Student Login(string username, string password);
        public Student CheckStudent(Student student);
    }
}
