using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using In_Mgmt.Models;
using System.Web.UI;

namespace In_Mgmt.Controllers
{ 
    public class UOMsController : Controller
    {
        private In_MgmtContext db = new In_MgmtContext();

        //
        // GET: /UOMs/

        public ViewResult Index()
        {
            var uoms = db.UOMs.Include(u => u.UOM_Type);
            return View(uoms.ToList());
        }

        //
        // GET: /UOMs/Details/5

        public ViewResult Details(int id)
        {
            UOM uom = db.UOMs.Find(id);
            return View(uom);
        }

        //
        // GET: /UOMs/Create

        public ActionResult Create()
        {
            ViewBag.UOM_TypeID = new SelectList(db.UOM_Types, "UOM_TypeID", "UOM_Type_Name");
            return View();
        } 

        //
        // POST: /UOMs/Create

        [HttpPost]
        public ActionResult Create(UOM uom)
        {
            if (ModelState.IsValid)
            {
                db.UOMs.Add(uom);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.UOM_TypeID = new SelectList(db.UOM_Types, "UOM_TypeID", "UOM_Type_Name", uom.UOM_TypeID);
            return View(uom);
        }
        
        //
        // GET: /UOMs/Edit/5
 
        public ActionResult Edit(int id)
        {
            UOM uom = db.UOMs.Find(id);
            ViewBag.UOM_TypeID = new SelectList(db.UOM_Types, "UOM_TypeID", "UOM_Type_Name", uom.UOM_TypeID);
            return View(uom);
        }

        //
        // POST: /UOMs/Edit/5

        [HttpPost]
        public ActionResult Edit(UOM uom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UOM_TypeID = new SelectList(db.UOM_Types, "UOM_TypeID", "UOM_Type_Name", uom.UOM_TypeID);
            return View(uom);
        }

        //
        // GET: /UOMs/Delete/5
 
        public ActionResult Delete(int id)
        {
            UOM uom = db.UOMs.Find(id);
            return View(uom);
        }

        //
        // POST: /UOMs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            UOM uom = db.UOMs.Find(id);
            db.UOMs.Remove(uom);
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