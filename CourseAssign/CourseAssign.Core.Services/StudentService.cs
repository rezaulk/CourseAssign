using CourseAssign.Core.Entities;
using CourseAssign.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAssign.Core.Services
{
    public class StudentService:IStudentService
    {
        DbContext _context;

        public StudentService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Set<Student>().ToList();
        }
    }
}
