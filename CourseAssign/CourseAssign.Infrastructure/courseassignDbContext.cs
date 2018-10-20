﻿using CourseAssign.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAssign.Infrastructure
{
    public class courseassignDbContext :DbContext
    {
        public courseassignDbContext():base("AssignCourseDbContext")
        {

        }
        public DbSet<Teacher> Teachers { get; set; }
    }
}