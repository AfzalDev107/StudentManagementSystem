using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.DAL.Models
{
    // Student.cs
    //public class Student
    //{
    //    public string StudentId { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public int Age { get; set; }
    //    public DateTime DOB { get; set; }
    //    public string Gender { get; set; }
    //    public string Email { get; set; }
    //    public string Phone { get; set; }
    //    public string Username { get; set; }
    //    public string Password { get; set; }
    //    public List<Qualification> Qualifications { get; set; }
    //}

    //// Qualification.cs
    //public class Qualification
    //{
    //    public int QualificationId { get; set; }
    //    public string StudentId { get; set; }
    //    public string CourseName { get; set; }
    //    public string University { get; set; }
    //    public int Year { get; set; }
    //    public decimal Percentage { get; set; }
    //}

    // Student.cs
    public class Student
    {
        public string StudentId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }


        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Range(5, 100, ErrorMessage = "Age must be between 5 and 100.")]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 20 characters.")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        public List<Qualification> Qualifications { get; set; }
    }

    // Qualification.cs
    public class Qualification
    {
        public int QualificationId { get; set; }

        public string StudentId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
        public string CourseName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "University name cannot exceed 100 characters.")]
        public string University { get; set; }

        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int Year { get; set; }

        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
        public decimal Percentage { get; set; }
    }

    //public class Student_Add
    //{

    //    [Required]
    //    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    //    public string FirstName { get; set; }


    //    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    //    public string LastName { get; set; }

    //    [Range(5, 100, ErrorMessage = "Age must be between 5 and 100.")]
    //    public int Age { get; set; }

    //    [Required]
    //    [DataType(DataType.Date)]
    //    public DateTime DOB { get; set; }

    //    [Required]
    //    [StringLength(10)]
    //    public string Gender { get; set; }

    //    [Required]
    //    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    //    public string Email { get; set; }

    //    [Required]
    //    [Phone(ErrorMessage = "Invalid Phone Number.")]
    //    public string Phone { get; set; }

    //    [Required]
    //    [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 20 characters.")]
    //    public string Username { get; set; }

    //    [Required]
    //    [DataType(DataType.Password)]
    //    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
    //    public string Password { get; set; }

    //    public List<Qualification> Qualifications { get; set; }
    //}

    //// Qualification.cs
    //public class Qualification_Add
    //{
    //    public int QualificationId { get; set; }

    //    public string StudentId { get; set; }

    //    [Required]
    //    [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
    //    public string CourseName { get; set; }

    //    [Required]
    //    [StringLength(100, ErrorMessage = "University name cannot exceed 100 characters.")]
    //    public string University { get; set; }

    //    [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
    //    public int Year { get; set; }

    //    [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
    //    public decimal Percentage { get; set; }
    //}

}
