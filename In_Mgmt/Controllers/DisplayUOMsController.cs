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
    public class DisplayUOMsController : Controller
    {
        private In_MgmtContext db = new In_MgmtContext();

        //
        // GET: /DisplayUOMs/

        public ViewResult Index()
        {
            return View(db.DisplayUOMs.ToList());
        }

        //
        // GET: /DisplayUOMs/Details/5

        public ViewResult Details(int id)
        {
            DisplayUOM displayuom = db.DisplayUOMs.Find(id);
            return View(displayuom);
        }

        //
        // GET: /DisplayUOMs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /DisplayUOMs/Create

        [HttpPost]
        public ActionResult Create(DisplayUOM displayuom)
        {
            if (ModelState.IsValid)
            {
                db.DisplayUOMs.Add(displayuom);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(displayuom);
        }
        
        //
        // GET: /DisplayUOMs/Edit/5
 
        public ActionResult Edit(int id)
        {
            DisplayUOM displayuom = db.DisplayUOMs.Find(id);
            return View(displayuom);
        }

        //
        // POST: /DisplayUOMs/Edit/5

        [HttpPost]
        public ActionResult Edit(DisplayUOM displayuom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(displayuom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(displayuom);
        }

        //
        // GET: /DisplayUOMs/Delete/5
 
        public ActionResult Delete(int id)
        {
            DisplayUOM displayuom = db.DisplayUOMs.Find(id);
            return View(displayuom);
        }

        //
        // POST: /DisplayUOMs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            DisplayUOM displayuom = db.DisplayUOMs.Find(id);
            db.DisplayUOMs.Remove(displayuom);
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