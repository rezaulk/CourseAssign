using CourseAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.ViewModels
{
    public class RoutineViewModel
    {

        public int Id { get; set; }

        public Course Course { get; set; }

        public string[] WeekDays { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

        public AcademicPlan AcademicPlans { get; set; }

        public string[] Classtimes { get; set; }

        public string[] FridayClassTimes { get; set; }
    }
}