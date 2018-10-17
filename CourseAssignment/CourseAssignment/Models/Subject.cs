using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Display(Name ="Subject Code")]
        public string SubjectCode { get; set; }

        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        public Semester Semesters { get; set; }

        public int SemesterId { get; set; }

        public int CoordinatorId { get; set; }
    }
}