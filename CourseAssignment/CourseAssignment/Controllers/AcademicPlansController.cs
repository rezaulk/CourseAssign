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
    public class AcademicPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AcademicPlans
        public ActionResult Index()
        {
            return View(db.AcademicPlans.ToList());
        }

        // GET: AcademicPlans/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AcademicPlan academicPlan = db.AcademicPlans.Find(id);
        //    if (academicPlan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(academicPlan);
        //}

        // GET: AcademicPlans/Create
        public ActionResult Create()
        {
            var season1 = new SeasonViewModel {
                Id = 1,
                Name="Spring"
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


            ViewBag.Season = season;
            return View();
        }

        // POST: AcademicPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,ClassCommence,Midterm,Final,NextClass,Season")] AcademicPlan academicPlan)
        {
            if (ModelState.IsValid)
            {
                db.AcademicPlans.Add(academicPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicPlan);
        }

        // GET: AcademicPlans/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AcademicPlan academicPlan = db.AcademicPlans.Find(id);
        //    if (academicPlan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(academicPlan);
        //}

        //// POST: AcademicPlans/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,ClassCommence,Midterm,Final,NextClass,Season")] AcademicPlan academicPlan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(academicPlan).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(academicPlan);
        //}

        // GET: AcademicPlans/Delete/5
       

    
    }
}
