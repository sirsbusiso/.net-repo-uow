using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDSEPARATIONOFCONCENTP1.Entity
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Student> Students { get; set; }
            
    }
}