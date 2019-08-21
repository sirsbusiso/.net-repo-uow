using CRUDSEPARATIONOFCONCENTP1.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDSEPARATIONOFCONCENTP1.ViewModels
{
    public class AllStudentViewModel
    {
        [Key]
        public int StudentId { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }
        public bool IsActive { get; set; }
    }
    public class CreateStudentViewModel
    {
        [Key]
        public int StudentId { get; set; }
        [Display(Name = "Course Name")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter surname")]
        public string Surname { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

    }
    public class DetailsStudentViewModel
    {
        [Key]
        public int StudentId { get; set; }
        [Display(Name = "Course Name")]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

    }
    public class GetByIdViewModel
    {
        [Key]
        public int StudentId { get; set; }
        [Display(Name = "Course Name")]
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }
    }
    public class UpdateStudentViewModel
    {
        [Key]
        public int StudentId { get; set; }
        [Display(Name = "Course Name")]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }
    }
    public class DeleteStudentViewModel
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }
    }
}