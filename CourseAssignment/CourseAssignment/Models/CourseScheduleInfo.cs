using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class CourseScheduleInfo
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Day { get; set; }

        public string Time { get; set; }

        public string Room { get; set; }

        public bool isAvailable { get; set; }

        public string SelectedBy { get; set; }


    }
}