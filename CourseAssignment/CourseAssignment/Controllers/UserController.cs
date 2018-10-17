using CourseAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseAssignment.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: User
        public ActionResult Index()
        {

            var courses = _context.Courses.ToList();
            return View();
        }

        public ActionResult TakeCourse() {
            var user = User.Identity.Name;
            var teacher = _context.Teachers.Where(x => x.User.UserName == user).Single();
            var teacherOrder = teacher.TeacherOrder;
            if (teacherOrder == 1) {
                var courses = _context.Courses;
                return View(courses);
            }
            else {
                List<Course> selectedCourses = new List<Course>();
                for (var i = 1; i < teacherOrder; i++)
                {
                    //var tempCourse = _context.Courses.Where(x => x.TakenBy.TeacherOrder == i).Single();
                    //selectedCourses.Add(tempCourse);
                    
                }
                var nonSelectedCourses = _context.Courses.Except(selectedCourses);
                return View(nonSelectedCourses);
            }


            
        }
    }
}