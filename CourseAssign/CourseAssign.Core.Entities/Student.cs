using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAssign.Core.Entities
{
    public class Student
    {
        [Key]
        public  int SId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ScheduleId { get; set; }


    }
}
