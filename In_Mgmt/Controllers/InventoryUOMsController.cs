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
    public class InventoryUOMsController : Controller
    {
        private In_MgmtContext db = new In_MgmtContext();

        //
        // GET: /InventoryUOMs/

        public ViewResult Index()
        {
            return View(db.InventoryUOMs.ToList());
        }

        //
        // GET: /InventoryUOMs/Details/5

        public ViewResult Details(int id)
        {
            InventoryUOM inventoryuom = db.InventoryUOMs.Find(id);
            return View(inventoryuom);
        }

        //
        // GET: /InventoryUOMs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /InventoryUOMs/Create

        [HttpPost]
        public ActionResult Create(InventoryUOM inventoryuom)
        {
            if (ModelState.IsValid)
            {
                db.InventoryUOMs.Add(inventoryuom);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(inventoryuom);
        }
        
        //
        // GET: /InventoryUOMs/Edit/5
 
        public ActionResult Edit(int id)
        {
            InventoryUOM inventoryuom = db.InventoryUOMs.Find(id);
            return View(inventoryuom);
        }

        //
        // POST: /InventoryUOMs/Edit/5

        [HttpPost]
        public ActionResult Edit(InventoryUOM inventoryuom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryuom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryuom);
        }

        //
        // GET: /InventoryUOMs/Delete/5
 
        public ActionResult Delete(int id)
        {
            InventoryUOM inventoryuom = db.InventoryUOMs.Find(id);
            return View(inventoryuom);
        }

        //
        // POST: /InventoryUOMs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            InventoryUOM inventoryuom = db.InventoryUOMs.Find(id);
            db.InventoryUOMs.Remove(inventoryuom);
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