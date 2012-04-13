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
    public class ItemsController : Controller
    {
        private In_MgmtContext db = new In_MgmtContext();

        //
        // GET: /Items/

        public ViewResult Index()
        {
            var items = db.Items.Include(i => i.ConsumptionUOM).Include(i => i.InventoryUOM).Include(i => i.StoredUOMs).Include(i => i.DisplayUOMs);
            return View(items.ToList());
        }

        //
        // GET: /Items/Details/5

        public ViewResult Details(int id)
        {
            Item item = db.Items.Find(id);
            return View(item);
        }

        //
        // GET: /Items/Create

        public ActionResult Create()
        {
            ViewBag.CUOMID = new SelectList(db.ConsumptionUOMs, "CUOMID", "CUOM_Name");
            ViewBag.IUOMID = new SelectList(db.InventoryUOMs, "IUOMID", "IUOM_Name");
            ViewBag.SUOMID = new SelectList(db.StoredUOMs, "SUOMID", "SUOM_Name");
            ViewBag.DUOMID = new SelectList(db.DisplayUOMs, "DUOMID", "DUOM_Name");
            return View();
        } 

        //
        // POST: /Items/Create

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CUOMID = new SelectList(db.ConsumptionUOMs, "CUOMID", "CUOM_Name", item.CUOMID);
            ViewBag.IUOMID = new SelectList(db.InventoryUOMs, "IUOMID", "IUOM_Name", item.IUOMID);
            ViewBag.SUOMID = new SelectList(db.StoredUOMs, "SUOMID", "SUOM_Name", item.SUOMID);
            ViewBag.DUOMID = new SelectList(db.DisplayUOMs, "DUOMID", "DUOM_Name", item.DUOMID);
            return View(item);
        }
        
        //
        // GET: /Items/Edit/5
 
        public ActionResult Edit(int id)
        {
            Item item = db.Items.Find(id);
            ViewBag.CUOMID = new SelectList(db.ConsumptionUOMs, "CUOMID", "CUOM_Name", item.CUOMID);
            ViewBag.IUOMID = new SelectList(db.InventoryUOMs, "IUOMID", "IUOM_Name", item.IUOMID);
            ViewBag.SUOMID = new SelectList(db.StoredUOMs, "SUOMID", "SUOM_Name", item.SUOMID);
            ViewBag.DUOMID = new SelectList(db.DisplayUOMs, "DUOMID", "DUOM_Name", item.DUOMID);
            return View(item);
        }

        //
        // POST: /Items/Edit/5

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUOMID = new SelectList(db.ConsumptionUOMs, "CUOMID", "CUOM_Name", item.CUOMID);
            ViewBag.IUOMID = new SelectList(db.InventoryUOMs, "IUOMID", "IUOM_Name", item.IUOMID);
            ViewBag.SUOMID = new SelectList(db.StoredUOMs, "SUOMID", "SUOM_Name", item.SUOMID);
            ViewBag.DUOMID = new SelectList(db.DisplayUOMs, "DUOMID", "DUOM_Name", item.DUOMID);
            return View(item);
        }

        //
        // GET: /Items/Delete/5
 
        public ActionResult Delete(int id)
        {
            Item item = db.Items.Find(id);
            return View(item);
        }

        //
        // POST: /Items/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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