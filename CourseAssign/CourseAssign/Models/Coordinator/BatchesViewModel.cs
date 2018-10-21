using CourseAssign.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAssign.Models.Coordinator
{
    public class BatchesViewModel
    {
        public IEnumerable<Batch> Batches { set; get; }

    }
}