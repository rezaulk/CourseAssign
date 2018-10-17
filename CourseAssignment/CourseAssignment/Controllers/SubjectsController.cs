using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseAssignment.Models;

namespace CourseAssignment.Controllers
{

    public class SubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subjects
        public ActionResult Index()
        {
            var user = User.IsInRole("EveningCoordinator");

            List<Subject> subjects;
            if (user)
            {
                subjects = db.Subjects.Where(x => x.CoordinatorId == 1).Include(s => s.Semesters).ToList();
            }
            else {
                subjects = db.Subjects.Where(x => x.CoordinatorId == 2).Include(s => s.Semesters).ToList();
            }
            return View(subjects);
        }

        // GET: Subjects/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Subject subject = db.Subjects.Find(id);
        //    if (subject == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subject);
        //}

        // GET: Subjects/Create
        public ActionResult Create()
        {
            var user = User.IsInRole("EveningCoordinator");
            if (user == true)
            {
                ViewBag.Semester = db.Semesters.Where(x => x.CoorinatorId == 1).ToList();
            }
            else {
                ViewBag.Semester = db.Semesters.Where(x => x.CoorinatorId == 2).ToList();
            }
            
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubjectCode,SubjectName,SemesterId", Exclude = "CoordinatorId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                var existingSubject = db.Subjects.Where(x => x.SubjectCode == subject.SubjectCode || x.SubjectName == subject.SubjectName).Any();
                bool user = User.IsInRole("EveningCoordinator"); ;
                if (!existingSubject)
                {
                    if (user == true)
                    {
                        subject.CoordinatorId = 1;
                    }
                    else
                    {
                        subject.CoordinatorId = 2;
                    }

                    db.Subjects.Add(subject);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else {
                    ViewBag.Message = "Can not Enter any Duplicate Value";
                }

                if (user == true)
                {
                    ViewBag.Semester = db.Semesters.Where(x => x.CoorinatorId == 1).ToList();
                }
                else
                {
                    ViewBag.Semester = db.Semesters.Where(x => x.CoorinatorId == 2).ToList();
                }
            }
            
            return View();
        }

        // GET: Subjects/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Subject subject = db.Subjects.Find(id);
        //    ViewBag.Semester = db.Semesters.ToList();
        //    if (subject == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subject);
        //}

        //// POST: Subjects/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,SubjectCode,SubjectName,SemesterId")] Subject subject)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(subject).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(subject);
        //}

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
