using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAssign.Core.Entities
{
    class Teacher
    {
        [Key]
        public string Id { get; set; }
        public int Name { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }

    }
}
