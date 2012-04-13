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
    public class StoredUOMsController : Controller
    {
        private In_MgmtContext db = new In_MgmtContext();

        //
        // GET: /StoredUOMs/

        public ViewResult Index()
        {
            return View(db.StoredUOMs.ToList());
        }

        //
        // GET: /StoredUOMs/Details/5

        public ViewResult Details(int id)
        {
            StoredUOM storeduom = db.StoredUOMs.Find(id);
            return View(storeduom);
        }

        //
        // GET: /StoredUOMs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /StoredUOMs/Create

        [HttpPost]
        public ActionResult Create(StoredUOM storeduom)
        {
            if (ModelState.IsValid)
            {
                db.StoredUOMs.Add(storeduom);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(storeduom);
        }
        
        //
        // GET: /StoredUOMs/Edit/5
 
        public ActionResult Edit(int id)
        {
            StoredUOM storeduom = db.StoredUOMs.Find(id);
            return View(storeduom);
        }

        //
        // POST: /StoredUOMs/Edit/5

        [HttpPost]
        public ActionResult Edit(StoredUOM storeduom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeduom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storeduom);
        }

        //
        // GET: /StoredUOMs/Delete/5
 
        public ActionResult Delete(int id)
        {
            StoredUOM storeduom = db.StoredUOMs.Find(id);
            return View(storeduom);
        }

        //
        // POST: /StoredUOMs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            StoredUOM storeduom = db.StoredUOMs.Find(id);
            db.StoredUOMs.Remove(storeduom);
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