using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.DAL.Models;

namespace SchoolManagementSystem.DAL.Interfaces
{
    public interface IStudentRepository
    {

        public void AddStudent(Student student);
        public List<Student> GetAllStudents();
        public List<Student> LoadStudents();
        public void SaveStudents(List<Student> students);
        public Student GetStudentByUsername(string username);
        public Student GetStudentByEmailAndName(string email, string firstname);


    }
}
