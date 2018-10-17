using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CourseAssignment.Models;

namespace CourseAssignment.Controllers.api
{
    public class AcademicPlansController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AcademicPlans
     
        // DELETE: api/AcademicPlans/5
        [ResponseType(typeof(AcademicPlan))]
        public IHttpActionResult DeleteAcademicPlan(int id)
        {
            AcademicPlan academicPlan = db.AcademicPlans.Find(id);
            if (academicPlan == null)
            {
                return NotFound();
            }

            db.AcademicPlans.Remove(academicPlan);
            db.SaveChanges();

            return Ok(academicPlan);
        }

        
    }
}