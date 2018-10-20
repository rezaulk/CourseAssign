using CourseAssign.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssign.Models
{
    public class TeacherViewModel
    {
        public IEnumerable<Teacher> Teachers { set; get; }

    }
}