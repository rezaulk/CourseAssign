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
    public class BatchService:IBatchService
    {
        DbContext _context;

        public BatchService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Batch> GetAll()
        {
            return _context.Set<Batch>().ToList();
        }
    }
}
