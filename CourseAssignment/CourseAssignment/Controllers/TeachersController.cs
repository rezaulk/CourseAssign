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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CourseAssignment.Controllers
{
    public class TeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teachers
        public ActionResult Index()
        {
            var teachers = db.Teachers.Include(t => t.User).OrderBy(x=>x.TeacherOrder);

            return View(teachers.ToList());
        }

        public ActionResult notfoundpage()
        {
          
            return View();
        }

        public ActionResult TeacherProfile()
        {
            var teachers = db.Teachers.Include(t => t.User).OrderBy(x => x.TeacherOrder);

            return View(teachers.ToList());
        }

        // GET: Teachers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Teacher teacher = db.Teachers.Find(id);
        //    if (teacher == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(teacher);
        //}

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var user = new ApplicationUser();
                user.Email = viewModel.Email;
                user.UserName = viewModel.Email;
                user.PhoneNumber = viewModel.MobileNo;
                string pass = viewModel.Password;

                var newUser = userManager.Create(user, pass);
                if (newUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Teacher");

                }

                var teacher = new Teacher();
                teacher.Name = viewModel.Name;
                teacher.joiningDate = viewModel.JoiningDate;
                teacher.TeacherShortName = viewModel.TeacherShortName;
                teacher.UserId = user.Id;

                db.Teachers.Add(teacher);
                db.SaveChanges();

                var prevTeacher = db.Teachers.OrderBy(x => x.joiningDate).ToList();
                int count = 0;
                foreach (var item in prevTeacher) {
                    count = count + 1;
                    item.TeacherOrder = count;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Teachers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Teacher teacher = db.Teachers.Find(id);
        //    if (teacher == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UserId = new SelectList(db.Users, "Id", "Email", teacher.UserId);
        //    return View(teacher);
        //}

        //// POST: Teachers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,UserId,Name,joiningDate,TeacherOrder")] Teacher teacher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(teacher).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UserId = new SelectList(db.Users, "Id", "Email", teacher.UserId);
        //    return View(teacher);
        //}

        //// GET: Teachers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Teacher teacher = db.Teachers.Find(id);
        //    if (teacher == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(teacher);
        //}

        //// POST: Teachers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Teacher teacher = db.Teachers.Find(id);
        //    db.Teachers.Remove(teacher);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles ="Teacher")]
        public ActionResult SelectCourse() {
            //load semesterName
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

            ViewBag.semesterName = season.ToList();


            return View();
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult SelectCourse(SelectCourseViewModel viewModel) {

            var userName = User.Identity.Name;

            var model = new TempSelectCourse
            {
                Teacher = userName,
                SemesterName = viewModel.SemsesterName,
                BatchName = viewModel.BatchName
            };

            db.TempSelectedCourses.Add(model);
            db.SaveChanges();
            return RedirectToAction("ChooseCourse",new { id = model.Id});
        }
        public JsonResult GetBatchNames(string semesterName) {
            var batches = db.Courses.Where(x => x.SemesterName == semesterName).Select(x => x.Batch.Name).ToList();
            var batch = db.Batches.ToList();

            List<Batch> selectedbatch = new List<Batch>();

            foreach (var item in batches) {
                var tempbatch = batch.Single(x => x.Name == item);
                selectedbatch.Add(tempbatch);
            }
            return Json(selectedbatch, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult ChooseCourse(int id)
        {
            var tempSelectedCourse = db.TempSelectedCourses.Single(x => x.Id == id);

            var courses = db.Courses.Include(o => o.Semester).Include(s => s.Batch).Where(x => x.SemesterName == tempSelectedCourse.SemesterName && x.Batch.Name == tempSelectedCourse.BatchName).SingleOrDefault();

            var courseSchedule = db.CourseScheduleInfoes.Where(x => x.CourseId == courses.Id && x.isAvailable == true).ToList();
            if (courseSchedule.Count() != 0)
            {
                var ItemId = courseSchedule.Select(x => x.CourseId).Take(1).Single();

                ViewBag.Days = courseSchedule.Select(x => x.Day).ToList();
                //var alldays = new DaysViewModel();
                //List<DaysViewModel> tempDays = new List<DaysViewModel>();
                List<DaysViewModel> day = new List<DaysViewModel>();

                var count = 1;
                foreach (var item in ViewBag.Days)
                {
                    DaysViewModel model1 = new DaysViewModel();
                    model1.Id = count;
                    model1.Name = item;
                    day.Add(model1);
                    count = count + 1;
                }

                ViewBag.Times = courseSchedule.Select(x => x.Time).ToList();


                string[] fridayclasstimes = courses.FridayClassTimes.Split(',').ToArray();



                var AllSubject = db.Subjects.Where(x => x.SemesterId == courses.SemesterId).ToList();
                try
                {
                    var existingSubject = db.SubjectSelectedByTeacherInCourses.Where(x => x.CourseId == courses.Id).Select(y => y.SubjectName).SingleOrDefault();



                    if (existingSubject != null)
                    {
                        string[] existingSubjectArray = existingSubject.Split(',').ToArray();
                        foreach (var item in existingSubjectArray)
                        {
                            var tempSub = AllSubject.Single(x => x.SubjectName == item);
                            if (tempSub != null)
                            {
                                AllSubject.Remove(tempSub);
                            }

                        }
                    }


                    var academicPlans = db.AcademicPlans.Single(x => x.Season == courses.SemesterName);

                    var viewModel = new CourseSelectedbyteacherViewModel
                    {
                        Id = ItemId,
                        Subjects = AllSubject,
                        AllDay = day
                    };

                    //Teachers / TeacherProfile
                    return View(viewModel);
                    //return RedirectToAction("TeacherProfile", "Teachers", new { id = Session["userid"] } );

                }
                catch
                {
                    return RedirectToAction("SelectCourse", "Teachers");
                }

            }
            return RedirectToAction("SelectCourse", "Teachers");
        }


        public JsonResult GetClassTimes(int id, string DayName) {
            var courseSchedule = db.CourseScheduleInfoes.Where(x => x.CourseId == id).ToList();
            if (DayName == "Friday")
            {
                var fridaytimes = db.Courses.Where(x => x.Id == id).Select(x => x.FridayClassTimes).Single();

                string[] allfridayClassTimes = fridaytimes.Split(',').ToArray();
                List<ClassTimesViewModel> classtime = new List<ClassTimesViewModel>();

                foreach (var item in allfridayClassTimes)
                {
                    var model1 = new ClassTimesViewModel();
                    model1.Name = item;
                    classtime.Add(model1);
                }

                return Json(classtime, JsonRequestBehavior.AllowGet);
            }
            else {
                var classTimes = courseSchedule.Where(x => x.Day == DayName && x.isAvailable==true).Select(x => x.Time);

                List<ClassTimesViewModel> classtime = new List<ClassTimesViewModel>();

                foreach (var item in classTimes)
                {
                    var model1 = new ClassTimesViewModel();
                    model1.Name = item;
                    classtime.Add(model1);
                }

                return Json(classtime, JsonRequestBehavior.AllowGet);
            }
           


        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult ChooseCourse(FormCollection form, TempChooseCourseViewModel viewModel) {

            if (form != null)
            {

                List<string> subjects = new List<String>();
                var dbSub = db.Subjects;
                var size = form.Count;
                var c = 0;
                for (var i = 1; i < size + 1; i++)
                {
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
                var filteredsubjects = subjects.Distinct();
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

                return RedirectToAction("Index", "RoutineHistory", new { id = history.Id });
            }
            return Content("Error");

        }


        public ActionResult SaveInfo(DayTimeSelectedViewModel vm) {

            var course = db.Courses.Include(n=>n.Batch).Single(x => x.Id == vm.CourseId);
            string Subject = string.Join(",", vm.AllSubject);
            string time = string.Join(",", vm.AllTimes);
            string day = string.Join(",", vm.Alldays);

            /*for (var x = 0; x < vm.Alldays.Count(); x++)
            {
                var tempSubject = vm.AllSubject[x];
                var temptime = vm.AllTimes[x];
                var tempday = vm.Alldays[x];
                */
                var courseSchedule = db.CourseScheduleInfoes.Where(y => y.CourseId == vm.CourseId).SingleOrDefault();
                courseSchedule.isAvailable = false;
                courseSchedule.SelectedBy = User.Identity.Name;

                db.SaveChanges();

            //}


            var Model = new SubjectSelectedByTeacherInCourse
            {
                CourseId = course.Id,
                SemesterName = course.SemesterName,
                SemesterNo = course.SemesterId,
                TeacherName = User.Identity.Name,
                SubjectName = Subject,
                BatchName = course.Batch.Name,
                ClassTime = time,
                Day = day

            };

            db.SubjectSelectedByTeacherInCourses.Add(Model);
            db.SaveChanges();
            return RedirectToAction("TeacherProfile", "Teachers", new { id = Session["userid"] } );
            //return RedirectToAction("Index", "RoutineHistory", new { id = Session["userid"] });
        }
    }
}
