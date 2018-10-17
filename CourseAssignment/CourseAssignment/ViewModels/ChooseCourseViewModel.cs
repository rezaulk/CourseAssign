using CourseAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.ViewModels
{
    public class ChooseCourseViewModel
    {
        public int Id { get; set; }

        public List<string> AllSubjects { get; set; }

        public List<string> SubjectCode { get; set; }

        public string[] ClassTimes { get; set; }

        public string[] FridayClassTimes { get; set; }

        public List<string> Days { get; set; }

        public RoutineHistory routineHistory { get; set; }

        public AcademicPlan AcaPlan { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }


    }
}