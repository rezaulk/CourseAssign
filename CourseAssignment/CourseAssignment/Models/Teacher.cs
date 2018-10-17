using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public DateTime joiningDate { get; set; }

        public int TeacherOrder { get; set; }

        public string TeacherShortName { get; set; }



    }
}