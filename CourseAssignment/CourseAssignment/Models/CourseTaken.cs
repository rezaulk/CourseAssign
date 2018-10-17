using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class CourseTaken
    {
        public int Id { get; set; }

        public string TeacherName { get; set; }

        public string SemesterNo { get; set; }

        public string SemesterName { get; set; }

        public string Batch { get; set; }

        public string SubjectNames { get; set; }

        public string SubjectCodes { get; set; }
    }
}