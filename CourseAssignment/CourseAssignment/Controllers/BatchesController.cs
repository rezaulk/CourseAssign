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

    public class BatchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Batches
        public ActionResult Index()
        {
            return View(db.Batches.ToList());
        }

        // GET: Batches/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Batch batch = db.Batches.Find(id);
        //    if (batch == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(batch);
        //}

        // GET: Batches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name",Exclude = "CoordinatorId")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                var duplicateBatch = db.Batches.Where(x => x.Name == batch.Name).Any();
                if (!duplicateBatch)
                {
                    var user = User.IsInRole("EveningCoordinator");
                    if (user == true)
                    {
                        batch.CoordinatorId = 1;
                    }
                    else
                    {
                        batch.CoordinatorId = 2;
                    }

                    db.Batches.Add(batch);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else {
                    ViewBag.Message = "Duplicate Batch Name. Please enter Different Batch Name";
                }
               
            }

            return View(batch);
        }

        // GET: Batches/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Batch batch = db.Batches.Find(id);
        //    if (batch == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(batch);
        //}

        //// POST: Batches/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name", Exclude = "CoordinatorId")] Batch batch)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(batch).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(batch);
        //}

        // GET: Batches/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Batch batch = db.Batches.Find(id);
        //    if (batch == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(batch);
        //}

        // POST: Batches/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Batch batch = db.Batches.Find(id);
            db.Batches.Remove(batch);
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
