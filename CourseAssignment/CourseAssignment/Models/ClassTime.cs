using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class ClassTime
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CoordinatorId { get; set; }
    }
}