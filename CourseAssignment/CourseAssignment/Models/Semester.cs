using System.ComponentModel.DataAnnotations;

namespace CourseAssignment.Models
{
    public class Semester
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        public int CoorinatorId { get; set; }
    }
}