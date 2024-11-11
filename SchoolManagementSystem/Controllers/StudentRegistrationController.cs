using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Service.Interfaces;
using SchoolManagementSystem.DAL.Models;

namespace SchoolManagementSystem.Controllers
{
    public class StudentRegistrationController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentRegistrationController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            // Clear validation for specific properties
            ModelState.Remove("StudentId");
            var count = student.Qualifications.Count();
            for(int i = 0; i < count;)
            {
                ModelState.Remove("Qualifications["+i+"].QualificationId");
                ModelState.Remove("Qualifications[" + i + "].StudentId");
                i++;
            }
            


            if (ModelState.IsValid)
            {
                var existingStudent = _studentService.CheckStudent(student);
                if (existingStudent != null)
                {
                    // If student exists, add a warning message to the model state
                    ModelState.AddModelError("FirstName", "A student with this Name already exists.");
                    ModelState.AddModelError("Email", "A student with this email id already exists.");
                    return View(student); // Return the same view with the error message
                }

                // If student doesn't exist, proceed with registration
                _studentService.RegisterStudent(student);
                return RedirectToAction("Login");

            }
            
            return View(student);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var student = _studentService.Login(username, password);
            if (student != null)
            {
                return RedirectToAction("StudentList");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }

        public IActionResult StudentList()
        {
            var students = _studentService.GetRegisteredStudents();
            return View(students);
        }
    }
}
