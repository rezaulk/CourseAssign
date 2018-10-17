using CourseAssignment.Models;
using CourseAssignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace CourseAssignment.Controllers
{
    public class RoutineHistoryController : Controller
    {
        private ApplicationDbContext _context;

        public RoutineHistoryController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: RoutineHistory
        public ActionResult Index(int id)
        {
            
            var routine = _context.RoutineHistories.SingleOrDefault(x=>x.Id == id);

            var tempdays = routine.Days.Split(',').ToList();

            var classtimes = routine.ClassTimes.Split(',').ToArray();
            var fridayClassTimes = routine.FridayClassTimes.Split(',').ToArray();

            var season = routine.SemesterName;
            var academicPlan = _context.AcademicPlans.SingleOrDefault(x => x.Season == season);

            var sub = routine.Subjects;

            var semesterId = _context.Semesters.Single(x => x.Name == routine.SemesterNo).Id;
            var allsubjecs = _context.Subjects.Where(x => x.SemesterId == semesterId).ToList();

            List<string> tempSub = new List<string>();
            tempSub = sub.Split(',').ToList();

            List<string> tempCode = new List<string>();
            var subCode = _context.Subjects.ToList();
            foreach (var item in tempSub) {
                var element = subCode.Where(x => x.SubjectName == item)
                    .Select(y => y.SubjectCode).Single();
                tempCode.Add(element);
            }
            var viewModel = new RoutineHistoryViewModel
            {
                AllSubjects = tempSub,
                SubjectCode = tempCode,
                routineHistory = routine,
                ClassTimes = classtimes,
                FridayClassTimes = fridayClassTimes,
                Days = tempdays,
                AcaPlan = academicPlan,
                Subjects = allsubjecs
            };
            return View(viewModel);
        }

        public ActionResult viewRoutine()
        {

            var courses = _context.Courses.Include(r=>r.Batch).ToList();

            ViewBag.Batches = courses.Select(x => x.Batch).ToList();

            var SemesterName = courses.Select(x => x.SemesterName).Distinct().ToList();

            var Year = courses.Select(x => x.Year).Distinct().ToList();

            var viewModel1 = new List<YearRoutineViewModel>();
            foreach (var item in Year) {
                var tempModel = new YearRoutineViewModel();
                tempModel.Year = item;
                viewModel1.Add(tempModel);
            }

            var viewModel2 = new List<SemesterRoutineViewModel>();
            foreach (var item in SemesterName)
            {
                var tempModel = new SemesterRoutineViewModel();
                tempModel.SemesterName = item;
                viewModel2.Add(tempModel);
            }

            ViewBag.Year = viewModel1;
            ViewBag.SemesterName = viewModel2;


            return View();
        }

        [HttpPost]
        public ActionResult viewRoutine(FormCollection form) {

            var batch = form["Batch"];
            var batchId = Convert.ToInt16(batch);
            var semseter = form["SemesterName"];
            var Year = form["Year"];
            try
            {
                var course = _context.Courses.Where(x => x.BatchId == batchId && x.SemesterName == semseter && x.Year == Year).Single();
                return RedirectToAction("Routine", "Courses", new { id = course.Id });

            }
            catch
            {
               return RedirectToAction("viewRoutine", "RoutineHistory");
   
            }
          

        }

        public ActionResult FinalRoutine() {

            var routineId = _context.Courses.SingleOrDefault(x=>x.Id == 55);

            var subjectSelectedbyTeachers = _context.SubjectSelectedByTeacherInCourses.Where(x => x.CourseId == routineId.Id);

            subjectSelectedbyTeachers.Distinct().ToList();

            return View();
        }
    }
}