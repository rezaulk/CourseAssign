using CourseAssign.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseAssign.Core.Services;
using CourseAssign.Core.Entities;

namespace Test
{
    class CourseAssignDatabaseCodefirst
    {
        public void CreateDB()
        {
            courseassignDbContext e = new courseassignDbContext();
            TeacherService ms = new TeacherService(e);

            Teacher m1 = new Teacher();
            m1.Email = "rajesh@gmail.com";
            m1.Name = "reza";
            m1.Nickname = "karim";
            m1.PhoneNo = "018398493";
            
          
            Console.WriteLine(ms.Insert(m1));
        }
    }
}
