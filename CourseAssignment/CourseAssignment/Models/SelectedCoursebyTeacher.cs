using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class SelectedCoursebyTeacher
    {
        public int Id { get; set; }

        public string TeacherName { get; set; }

        public string SubjectName { get; set; }

        public string SubjectId { get; set; }

        public string SemesterName { get; set; }

        public string BatchName { get; set; }

        public string SemesterNo { get; set; }

        public string TakenYear { get; set; }
    }
}