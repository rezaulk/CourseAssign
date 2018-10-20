using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAssign.Core.Services
{
    public class SectionService
    {
        DbContext _context;

        public SectionService(DbContext context)
        {
            _context = context;
        }
    }
}
