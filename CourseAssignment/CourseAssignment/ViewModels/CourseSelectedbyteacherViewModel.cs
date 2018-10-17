using CourseAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.ViewModels
{
    public class CourseSelectedbyteacherViewModel
    {
        public int Id { get; set; }

        //public IEnumerable<CourseScheduleInfo> courseSchedeuleInfo { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

        //public List<string> Time { get; set; }

        public IEnumerable<DaysViewModel> AllDay { get; set; }

        public string Times { get; set; }

        public string Subject { get; set; }

        public string Day { get; set; }



    }
}