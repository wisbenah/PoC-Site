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
    public class UOM_TypesController : Controller
    {
        private In_MgmtContext db = new In_MgmtContext();

        //
        // GET: /UOM_Types/

        public ViewResult Index()
        {
            return View(db.UOM_Types.ToList());
        }

        //
        // GET: /UOM_Types/Details/5

        public ViewResult Details(int id)
        {
            UOM_Type uom_type = db.UOM_Types.Find(id);
            return View(uom_type);
        }

        //
        // GET: /UOM_Types/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UOM_Types/Create

        [HttpPost]
        public ActionResult Create(UOM_Type uom_type)
        {
            if (ModelState.IsValid)
            {
                db.UOM_Types.Add(uom_type);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(uom_type);
        }
        
        //
        // GET: /UOM_Types/Edit/5
 
        public ActionResult Edit(int id)
        {
            UOM_Type uom_type = db.UOM_Types.Find(id);
            return View(uom_type);
        }

        //
        // POST: /UOM_Types/Edit/5

        [HttpPost]
        public ActionResult Edit(UOM_Type uom_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uom_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uom_type);
        }

        //
        // GET: /UOM_Types/Delete/5
 
        public ActionResult Delete(int id)
        {
            UOM_Type uom_type = db.UOM_Types.Find(id);
            return View(uom_type);
        }

        //
        // POST: /UOM_Types/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            UOM_Type uom_type = db.UOM_Types.Find(id);
            db.UOM_Types.Remove(uom_type);
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