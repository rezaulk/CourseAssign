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
    public class ScheduleService:IscheduleService
    {
        DbContext _context;

        public ScheduleService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Schedule> GetAll()
        {
            return _context.Set<Schedule>().ToList();
        }


    }
}
