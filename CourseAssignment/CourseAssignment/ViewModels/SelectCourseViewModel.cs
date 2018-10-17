using CourseAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.ViewModels
{
    public class SelectCourseViewModel
    {
        public int Id { get; set; }

        public string SemsesterName { get; set; }

        public string BatchName { get; set; }

        public IEnumerable<Batch> Batch { get; set; }

    }
}