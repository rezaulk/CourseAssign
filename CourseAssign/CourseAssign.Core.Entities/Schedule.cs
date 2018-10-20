using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAssign.Core.Entities
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int TeacherId { get; set; }
        public int SecId { get; set; }
        public int Room { get; set; }
        public DateTime DateTime { get; set; }
        public int CourseId { get; set; }

    }
}
