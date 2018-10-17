using CourseAssignment.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseAssignment.ViewModels;

namespace CourseAssignment.Controllers
{

    public class CoOrdinatorController : Controller
    {

       private ApplicationDbContext _context;

        public CoOrdinatorController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: CoOrdinator
        public ActionResult Index()
        {
            var routine = _context.RoutineHistories.ToList();
            return View(routine);
        }
    }
}