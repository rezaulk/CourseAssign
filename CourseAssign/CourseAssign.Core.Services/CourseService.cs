using CourseAssign.Core.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseAssign.Core.Services.Interfaces;
using CourseAssign.Core.Entities;

namespace CourseAssign.Core.Services
{
    public class CourseService: ICourseService
    {
        DbContext _context;

        public CourseService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Set<Course>().ToList();
        }

    }
}
