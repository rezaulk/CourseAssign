using System.ComponentModel.DataAnnotations;

namespace CourseAssignment.Models
{
    public class Category
    {

        public int Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }
    }
}