using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAssign.Core.Entities
{
    public class Section
    {
        [Key]
        public int SecId { get; set; }
        public int Cid { get; set; }
        public int Tid { get; set; }
        public string Name { get; set; }

    }
}
