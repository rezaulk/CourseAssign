using System.ComponentModel.DataAnnotations;

namespace CourseAssignment.Models
{
    public class Batch
    {
        public int Id { get; set; }

        [StringLength(15)]
        public string Name { get; set; }

        public int CoordinatorId { get; set; }
    }
}