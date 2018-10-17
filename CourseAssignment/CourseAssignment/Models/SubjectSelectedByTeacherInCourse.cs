using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class SubjectSelectedByTeacherInCourse
    {

        public int Id { get; set; }

        public int CourseId { get; set; }

        public string SubjectName { get; set; }

        public int SemesterNo { get; set; }

        public string SemesterName { get; set; }

        public string BatchName { get; set; }

        public string TeacherName { get; set; }

        public string ClassTime { get; set; }

        public string Day { get; set; }




    }
}