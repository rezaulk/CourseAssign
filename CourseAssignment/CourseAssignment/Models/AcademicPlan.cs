using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class AcademicPlan
    {
        public int Id { get; set; }

        [Display(Name="Class Commence" )]
        public string ClassCommence { get; set; }

        [Display(Name = "Mid Term")]
        public  string Midterm { get; set; }

        [Display(Name = "Final")]
        public string Final { get; set; }

        [Display(Name = "Next Class")]
        public string NextClass { get; set; }

        [Display(Name = "Semester Name")]
        public string Season { get; set; }

    }
}