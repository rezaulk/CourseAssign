﻿using CourseAssign.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAssign.Core.Services.Interfaces
{
    public interface IBatchService
    {
        IEnumerable<Batch> GetAll();

    }
}
