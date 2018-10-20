using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAssign.Core.Services
{
    public class LoginService
    {
        DbContext _context;

        public LoginService(DbContext context)
        {
            _context = context;
        }



      
    }
}
