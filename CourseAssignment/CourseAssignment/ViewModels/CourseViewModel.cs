using CourseAssignment.Models;
using CourseAssignment.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseAssignment.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public IEnumerable<Semester> Semester { get; set; }

        [DisplayName("Semester")]
        public int SemesterId { get; set; }

        public IEnumerable<Batch> Batch { get; set; }
        

        public int BatchId { get; set; }

        [StringLength(50)]
        public string Campus { get; set; }

        [StringLength(50)]
        [DisplayName("Room No")]
        public string RoomNo { get; set; }


        public IEnumerable<FridayClassTimes> FridayClassTimes { get; set; }

        public int FridayClassTimesId { get; set; }

        public IEnumerable<SeasonViewModel> Session { get; set; }
        public string SessionName { get; set; }
        //public IEnumerable<ClassTime> ClassTime { get; set; }

        //public string ClassTimeIds { get; set; }

        public IEnumerable<WeekDay> WeekDay { get; set; }

        public IEnumerable<ClassTime> ClassTimes { get; set; }

        public IEnumerable<Room> Rooms { get; set; }

        

        //public string WeekDayIds { get; set; }

        public string[] AllClassTime { get; set; }

        public string[] AllWeekDay { get; set; }

        public string[] AllRooms { get; set; }
        public string[] AllCampus { get; set; }

        public string[] AllFridayClassTimes { get; set; }


    }
}