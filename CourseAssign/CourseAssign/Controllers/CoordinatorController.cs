using CourseAssign.Core.Services.Interfaces;
using CourseAssign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseAssign.Controllers
{
    public class CoordinatorController : Controller
    {
        public ITeacherService _TeacherService;

        public CoordinatorController(ITeacherService Teacher)
        {
            _TeacherService = Teacher;
        }
        // GET: Coordinator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Teachers()
        {
            TeacherViewModel m = new TeacherViewModel();
            m.Teachers = _TeacherService.GetAll();
            return View(m);
        }
    }
}