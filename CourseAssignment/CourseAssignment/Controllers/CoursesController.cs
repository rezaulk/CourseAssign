using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseAssignment.Models;
using CourseAssignment.ViewModels;

namespace CourseAssignment.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        //public ActionResult Index()
        //{
        //    var courses = db.Courses.Include(c => c.Batch).Include(c => c.Semester);
        //    return View(courses.ToList());
        //}

        // GET: Courses/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Course course = db.Courses.Find(id);
        //    if (course == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(course);
        //}

        // GET: Courses/Create
        public ActionResult Create()
        {
            var season1 = new SeasonViewModel
            {
                Id = 1,
                Name = "Spring"
            };
            var season2 = new SeasonViewModel
            {
                Id = 2,
                Name = "Summer"
            };
            var season3 = new SeasonViewModel
            {
                Id = 3,
                Name = "Fall"
            };
            List<SeasonViewModel> season = new List<SeasonViewModel>();
            season.Add(season1);
            season.Add(season2);
            season.Add(season3);

            var user = User.IsInRole("EveningCoordinator");
            CourseViewModel viewModel;
            if (user == true)
            {
                viewModel = new CourseViewModel
                {
                    Batch = db.Batches.Where(x => x.CoordinatorId == 1).ToList(),
                    Semester = db.Semesters.Where(x => x.CoorinatorId == 1).ToList(),
                    Session = season,
                    WeekDay = db.WeekDays.ToList(),
                    Rooms = db.Rooms.ToList(),
                    ClassTimes = db.ClassTimes.Where(x => x.CoordinatorId == 1).ToList(),
                    FridayClassTimes = db.FridayClassTimes.ToList()

                };
            }
            else {
                viewModel = new CourseViewModel
                { 
                    Batch = db.Batches.Where(x => x.CoordinatorId == 2).ToList(),
                    Semester = db.Semesters.Where(x => x.CoorinatorId == 2).ToList(),
                    Session = season,
                    WeekDay = db.WeekDays.ToList(),
                    Rooms = db.Rooms.ToList(),
                    ClassTimes = db.ClassTimes.Where(x => x.CoordinatorId == 2).ToList()

                };
            }
            
            return View(viewModel);
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        public ActionResult SaveCourse(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                var temp1 = string.Join(",",course.AllClassTime);
                var temp2 = string.Join(",", course.AllWeekDay);
                var temp3 = string.Join(",", course.AllRooms);
                var temp4 = string.Join(",", course.AllFridayClassTimes);

                var newCourse = new Course {
                    BatchId = course.BatchId,
                    SemesterId = course.SemesterId,
                    RoomNo = course.RoomNo,
                    SemesterName = course.SessionName,
                    ClassTimes = temp1,
                    WeekDayIds = temp2,
                    Rooms = temp3,
                    FridayClassTimes = temp4,
                    Campus = course.Campus,
                    Year= Convert.ToString(DateTime.Now.Year)
                };

                var ExistingCourses = db.Courses.ToList();
                
                var NewBatchId = ExistingCourses.Any(x=>x.BatchId==newCourse.BatchId);
                var NewCourseYear = ExistingCourses.Any(x => x.Year == newCourse.Year); 
                var SemesterName = ExistingCourses.Any(x => x.SemesterName == newCourse.SemesterName);

                if (NewBatchId && NewCourseYear && SemesterName)
                {
                    ViewBag.DuplicateCourse = "Course exists";
                    return Content("Course exists");
                }
                else {
                    db.Courses.Add(newCourse);
                    db.SaveChanges();

                    var courseSchedule = new CourseScheduleInfo();
                   
                    for (var x = 0; x < course.AllClassTime.Count(); x++)
                    {
                        courseSchedule.CourseId = newCourse.Id;
                        courseSchedule.Day = course.AllWeekDay[x];
                        courseSchedule.Time = course.AllClassTime[x];
                        courseSchedule.Room = course.AllRooms[x];
                        courseSchedule.isAvailable = true;
                        db.CourseScheduleInfoes.Add(courseSchedule);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Routine", "Courses", new { id = newCourse.Id });
                    //return RedirectToAction("viewRoutine", "RoutineHistory", new { id = newCourse.Id });
                }

                
            }
            else
                return RedirectToAction("Routine", "Courses", new { id = course.BatchId });
           // return View();
        }

        public ActionResult GetRoutine() {
            var courseId = db.Courses.Select(x => x.Id);
            ViewBag.Id = courseId;
            return View();
        }

        public ActionResult Routine(int id) {
            var courses = db.Courses.Include(o=>o.Semester).Include(s=>s.Batch).SingleOrDefault(x => x.Id == id);
            //var weekdays = db.WeekDays;

            string[] classtimes = courses.ClassTimes.Split(',').ToArray();
            string[] fridayclasstimes = courses.FridayClassTimes.Split(',').ToArray();
            //var array1 = courses.ClassTimeIds.Split(',').ToArray();
            //string[] array3 = new string[10];
            //var count = 0;
            //foreach (var item in array1) {

            //    var int1 = Convert.ToInt16(item);
            //    var member = classtime.SingleOrDefault(x => x.Id == int1).Name;
            //    array3[count] = member;
            //    count += 1;
            //}

            var array2 = courses.WeekDayIds.Split(',').ToArray();
            //string[] array4 = new string[array2.Count()];
            //var serial = 0;
            //foreach (var item in array2)
            //{

            //    var int1 = Convert.ToInt16(item);
            //    var member = weekdays.SingleOrDefault(x => x.Id == int1).Name;
            //    array4[serial] = member;
            //    serial += 1;
            //}

            var subjects = db.Subjects.Where(x => x.SemesterId == courses.SemesterId).ToList();
            var academicPlans = db.AcademicPlans.Single(x => x.Season == courses.SemesterName);



            var viewModel = new RoutineViewModel
            {
                Course = courses,
                WeekDays = array2,
                Subjects = subjects,
                AcademicPlans = academicPlans,
                Classtimes = classtimes,
                FridayClassTimes = fridayclasstimes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Routine(FormCollection form,RoutineViewModel viewModel) {

            if (form !=null) {

                List<string> subjects = new List<String>();
                var dbSub = db.Subjects;
                var size = form.Count;
                var c = 0;
                for (var i = 1; i < size + 1; i++) {
                    var element = form[form.GetKey(c)];
                    var temp1 = Convert.ToInt16(element);
                    var newSub = dbSub.SingleOrDefault(x => x.Id == temp1).SubjectName;
                    subjects.Add(newSub);
                    c = c + 1;
                }

                
                var course = db.Courses.SingleOrDefault(x => x.Id == viewModel.Id);

                var semNo = db.Semesters.Single(x => x.Id == course.SemesterId);

                var batchName = db.Batches.Single(x => x.Id == course.BatchId).Name;

                var alldays = db.WeekDays;
                var weekdayIds = course.WeekDayIds.Split(',').ToArray();
                List<string> days = new List<string>();
                //foreach (var item in weekdayIds) {
                //    var temp = Convert.ToInt16(item);
                //    var day = alldays.SingleOrDefault(x => x.Id == temp).Name;
                //    days.Add(day);   
                //}

                var campus = course.Campus;
                var room = course.RoomNo;
                var batch = batchName;
                var semesterName = course.SemesterName;
                var semesterNo = semNo.Name;
                var addedBy = User.Identity.Name;

                string newDays = string.Join(",", weekdayIds);

                string allsubjects = string.Join(",", subjects);
                var history = new RoutineHistory
                {
                    Subjects = allsubjects,
                    Room = room,
                    SemesterName = semesterName,
                    SemesterNo = semesterNo,
                    BatchName = batch,
                    ClassTimes = course.ClassTimes,
                    FridayClassTimes = course.FridayClassTimes,
                    Campus = campus,
                    Days = newDays,
                    year = DateTime.Now.Year.ToString(),
                    AddedBy = addedBy
                };

                db.RoutineHistories.Add(history);
                db.SaveChanges();

                return RedirectToAction("Index", "RoutineHistory", new { id = history.Id});
            }
            return Content("Error");
        }

        // GET: Courses/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Course course = db.Courses.Find(id);
        //    if (course == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.BatchId = new SelectList(db.Batches, "Id", "Name", course.BatchId);
        //   // ViewBag.ClassTimeId = new SelectList(db.ClassTimes, "Id", "Name", course.ClassTimeId);
        //    ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name", course.SemesterId);
          
        //    //ViewBag.WeekDayId = new SelectList(db.WeekDays, "Id", "Name", course.WeekDayId);
        //    return View(course);
        //}

        //// POST: Courses/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,SemesterId,BatchId,Campus,RoomNo,ClassTimeId,WeekDayId")] Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(course).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.BatchId = new SelectList(db.Batches, "Id", "Name", course.BatchId);
        //    //ViewBag.ClassTimeId = new SelectList(db.ClassTimes, "Id", "Name", course.ClassTimeId);
        //    ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name", course.SemesterId);
        //    //ViewBag.WeekDayId = new SelectList(db.WeekDays, "Id", "Name", course.WeekDayId);
        //    return View(course);
        //}

        //// GET: Courses/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Course course = db.Courses.Find(id);
        //    if (course == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(course);
        //}

        //// POST: Courses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Course course = db.Courses.Find(id);
        //    db.Courses.Remove(course);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


    }
}
