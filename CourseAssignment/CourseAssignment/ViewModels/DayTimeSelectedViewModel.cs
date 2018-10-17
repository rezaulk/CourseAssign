using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.ViewModels
{
    public class DayTimeSelectedViewModel
    {
        public int CourseId { get; set; }

        public string[] Alldays { get; set; }

        public string[] AllTimes { get; set; }

        public string[] AllSubject { get; set; }
    }
}