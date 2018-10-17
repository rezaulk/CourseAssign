using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class RoutineHistory
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string SemesterName { get; set; }

        [StringLength(10)]
        public string SemesterNo { get; set; }

        [StringLength(10)]
        public string BatchName { get; set; }

        [StringLength(10)]
        public string year { get; set; }

        [StringLength(10)]
        public string Room { get; set; }

        [StringLength(20)]
        public string Campus { get; set; }

        public string ClassTimes { get; set; }

        public string FridayClassTimes { get; set; }

        public string Days { get; set; }

        public string Teachers { get; set; }

        public string Subjects { get; set; }

        [StringLength(50)]
        public string AddedBy { get; set; }
    }
}