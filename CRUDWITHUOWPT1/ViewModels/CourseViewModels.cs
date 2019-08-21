using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDSEPARATIONOFCONCENTP1.ViewModels
{
    public class AllCoursesViewModel
    {
        [Key]
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }

    public class GetCourseByIdViewModel
    {
        [Key]
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }

    public class CreateCourseViewModel
    {
        [Key]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please enter course name")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        public DateTime DateCreated { get;set; }
    }

}