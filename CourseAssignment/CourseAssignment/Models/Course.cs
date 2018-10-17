using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseAssignment.Models
{
    public class Course
    {
        public int Id { get; set; }

        public Semester Semester { get; set; }

        public int SemesterId { get; set; }

        public Batch Batch { get; set; }

        public int BatchId { get; set; }

        [StringLength(50)]
        public string Campus { get; set; }

        [StringLength(50)]
        public string RoomNo { get; set; }

        public string SemesterName { get; set; }

        public string WeekDayIds { get; set; }

        public string Rooms { get; set; }

        public string ClassTimes { get; set; }

        public string FridayClassTimes { get; set; }

        public string Year { get; set; }



    }
}