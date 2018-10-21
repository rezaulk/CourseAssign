using CourseAssign.Core.Services.Interfaces;
using CourseAssign.Models;
using CourseAssign.Models.Coordinator;
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
        public IBatchService _BatchService;
        public ISectionService _SectionService;
        public ICourseService _CourseService;


        public CoordinatorController(ITeacherService Teacher,IBatchService Batch, ISectionService Section, ICourseService Course)
        {
            _TeacherService = Teacher;
            _BatchService = Batch;
            _SectionService = Section;
            _CourseService = Course;

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


        public ActionResult Batches()
        {
            BatchesViewModel m = new BatchesViewModel();
            m.Batches = _BatchService.GetAll();
            return View(m);
        }


        public ActionResult Courses()
        {
            CourseViewModel m = new CourseViewModel();
            m.Courses= _CourseService.GetAll();
            return View(m);
        }

        public ActionResult Sections()
        {
            SectionViewModel m = new SectionViewModel();
            m.Sections = _SectionService.GetAll();
            return View(m);
        }


    }
}