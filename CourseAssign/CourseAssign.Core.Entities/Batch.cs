using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAssign.Core.Entities
{
    public class Batch
    {
        [Key]
        public int Bid { get; set; }
        public string Name { get; set; }
        public string Session { get; set; }
    }
}
