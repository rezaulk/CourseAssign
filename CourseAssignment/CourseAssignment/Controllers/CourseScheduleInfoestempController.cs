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
    public class CourseScheduleInfoestempController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseScheduleInfoestemp
        public ActionResult Index()
        {
            return View(db.CourseScheduleInfoes.ToList());
        }

        // GET: CourseScheduleInfoestemp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseScheduleInfo courseScheduleInfo = db.CourseScheduleInfoes.Find(id);
            if (courseScheduleInfo == null)
            {
                return HttpNotFound();
            }
            return View(courseScheduleInfo);
        }

        // GET: CourseScheduleInfoestemp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseScheduleInfoestemp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,Day,Time,Room")] CourseScheduleInfo courseScheduleInfo)
        {
            if (ModelState.IsValid)
            {
                db.CourseScheduleInfoes.Add(courseScheduleInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseScheduleInfo);
        }

        // GET: CourseScheduleInfoestemp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseScheduleInfo courseScheduleInfo = db.CourseScheduleInfoes.Find(id);
            if (courseScheduleInfo == null)
            {
                return HttpNotFound();
            }
            return View(courseScheduleInfo);
        }

        // POST: CourseScheduleInfoestemp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,Day,Time,Room")] CourseScheduleInfo courseScheduleInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseScheduleInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseScheduleInfo);
        }

        // GET: CourseScheduleInfoestemp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseScheduleInfo courseScheduleInfo = db.CourseScheduleInfoes.Find(id);
            if (courseScheduleInfo == null)
            {
                return HttpNotFound();
            }
            return View(courseScheduleInfo);
        }

        // POST: CourseScheduleInfoestemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseScheduleInfo courseScheduleInfo = db.CourseScheduleInfoes.Find(id);
            db.CourseScheduleInfoes.Remove(courseScheduleInfo);
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
