using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using In_Mgmt.Models;

namespace In_Mgmt.Controllers
{ 
    public class KPIsController : Controller
    {
        private In_MgmtContext db = new In_MgmtContext();
        
        //
        // GET: /KPIs/

        public ViewResult Index()
        {
            var kpis = db.KPIs.Include(k => k.Container); //added s
            return View(kpis.ToList());
        }

        //
        // GET: /KPIs/Details/5

        public ViewResult Details(int id)
        {
            KPI kpi = db.KPIs.Find(id);
            return View(kpi);
        }

        //
        // GET: /KPIs/Create

        public ActionResult Create(int? id)
        {
            var ContainerID = id; //added
            var KPIID = id;
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerCode");
            return View();
        } 

        //
        // POST: /KPIs/Create

        [HttpPost]
        public ActionResult Create(KPI kpi)
        {            
            if (ModelState.IsValid)
            {
                db.KPIs.Add(kpi);
                db.SaveChanges();
                return RedirectToAction("../Containers/Index");  
            }

            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerCode", kpi.ContainerID);
            return View(kpi);
        }
        
        //
        // GET: /KPIs/Edit/5
 
        public ActionResult Edit(int id)
        {            
            KPI kpi = db.KPIs.Find(id);
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerCode", kpi.ContainerID);
            return View(kpi);
        }

        //
        // POST: /KPIs/Edit/5

        [HttpPost]
        public ActionResult Edit(KPI kpi)
        {            
            if (ModelState.IsValid)
            {
                db.Entry(kpi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Containers/Index");
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerCode", kpi.ContainerID);
            return View(kpi);
        }

        //
        // GET: /KPIs/Delete/5
 
        public ActionResult Delete(int id)
        {
            KPI kpi = db.KPIs.Find(id);
            return View(kpi);
        }

        //
        // POST: /KPIs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            KPI kpi = db.KPIs.Find(id);
            db.KPIs.Remove(kpi);
            db.SaveChanges();
            return RedirectToAction("../Containers/Index");
        }

        //----------------------------------
        public ViewResult ViewKPI(int? id)
        {
            var kpi = db.KPIs.Include(c => c.Container).Where(k => k.ContainerID == id);
            return View(kpi.ToList());
        }

        //---------------------------------------



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}