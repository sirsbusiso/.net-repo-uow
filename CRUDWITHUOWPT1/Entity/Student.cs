using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDSEPARATIONOFCONCENTP1.Entity
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Course Course { get; set; }
    }
}