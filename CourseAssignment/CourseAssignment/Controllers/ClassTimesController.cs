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
    public class ClassTimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassTimes
        public ActionResult Index()
        {
            return View(db.ClassTimes.ToList());
        }

        // GET: ClassTimes/Details/5

        // GET: ClassTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name", Exclude = "CoordinatorId")] ClassTime classTime)
        {
            if (ModelState.IsValid)
            {
                var user = User.IsInRole("EveningCoordinator");
                if (user == true)
                {
                    classTime.CoordinatorId = 1;
                }
                else {
                    classTime.CoordinatorId = 2;
                }
                db.ClassTimes.Add(classTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classTime);
        }

        // GET: ClassTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTime classTime = db.ClassTimes.Find(id);
            if (classTime == null)
            {
                return HttpNotFound();
            }
            return View(classTime);
        }

        // POST: ClassTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name", Exclude = "CoordinatorId")] ClassTime classTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classTime);
        }

        // GET: ClassTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTime classTime = db.ClassTimes.Find(id);
            if (classTime == null)
            {
                return HttpNotFound();
            }
            return View(classTime);
        }

        // POST: ClassTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassTime classTime = db.ClassTimes.Find(id);
            db.ClassTimes.Remove(classTime);
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
