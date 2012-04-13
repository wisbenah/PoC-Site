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
    public class ConsumptionUOMsController : Controller
    {
        private In_MgmtContext db = new In_MgmtContext();

        //
        // GET: /ConsumptionUOMs/

        public ViewResult Index()
        {
            return View(db.ConsumptionUOMs.ToList());
        }

        //
        // GET: /ConsumptionUOMs/Details/5

        public ViewResult Details(int id)
        {
            ConsumptionUOM consumptionuom = db.ConsumptionUOMs.Find(id);
            return View(consumptionuom);
        }

        //
        // GET: /ConsumptionUOMs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ConsumptionUOMs/Create

        [HttpPost]
        public ActionResult Create(ConsumptionUOM consumptionuom)
        {
            if (ModelState.IsValid)
            {
                db.ConsumptionUOMs.Add(consumptionuom);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(consumptionuom);
        }
        
        //
        // GET: /ConsumptionUOMs/Edit/5
 
        public ActionResult Edit(int id)
        {
            ConsumptionUOM consumptionuom = db.ConsumptionUOMs.Find(id);
            return View(consumptionuom);
        }

        //
        // POST: /ConsumptionUOMs/Edit/5

        [HttpPost]
        public ActionResult Edit(ConsumptionUOM consumptionuom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumptionuom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consumptionuom);
        }

        //
        // GET: /ConsumptionUOMs/Delete/5
 
        public ActionResult Delete(int id)
        {
            ConsumptionUOM consumptionuom = db.ConsumptionUOMs.Find(id);
            return View(consumptionuom);
        }

        //
        // POST: /ConsumptionUOMs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ConsumptionUOM consumptionuom = db.ConsumptionUOMs.Find(id);
            db.ConsumptionUOMs.Remove(consumptionuom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}