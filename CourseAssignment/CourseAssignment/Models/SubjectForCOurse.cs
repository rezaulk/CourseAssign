using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class SubjectForCOurse
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string SubjectName { get; set; }

        public string SubjectCode { get; set; }

        public string TeacherName { get; set; }
    }
}