using SchoolManagementSystem.DAL.Repositories;
using SchoolManagementSystem.DAL.Models;
using SchoolManagementSystem.Service.Interfaces;
using SchoolManagementSystem.DAL.Interfaces;

namespace SchoolManagementSystem.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public string GenerateStudentId()
        {
            return "ST" + new Random().Next(100000).ToString();
        }

        public Student CheckStudent(Student student)
        {
            var student_data = _repository.GetStudentByEmailAndName(student.Email, student.FirstName);
            if (student_data == null)
            {
                return null;
            }
            return  student_data;

        }


        public void RegisterStudent(Student student)
        {
            
                student.StudentId = GenerateStudentId();
                _repository.AddStudent(student);
                       
        }

        public List<Student> GetRegisteredStudents()
        {
            return _repository.GetAllStudents();
        }

        public Student Login(string username, string password)
        {
            var student = _repository.GetStudentByUsername(username);
            return student != null && student.Password == password ? student : null;
        }
    }

}