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
    public class TeacherService:ITeacherService
    {
        DbContext _context;

        public TeacherService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Set<Teacher>().ToList();
        }

        public bool Insert(Teacher member)
        {
            try
            {
                _context.Entry(member).State = EntityState.Added;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
