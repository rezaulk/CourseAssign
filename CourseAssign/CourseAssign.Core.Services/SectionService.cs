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
    public class SectionService:ISectionService
    {
        DbContext _context;

        public SectionService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Section> GetAll()
        {
            return _context.Set<Section>().ToList();
        }
    }
}
