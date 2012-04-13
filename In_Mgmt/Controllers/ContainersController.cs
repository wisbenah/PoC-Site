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
    public class ContainersController : Controller
    {
        private In_MgmtContext db = new In_MgmtContext();

        //
        // GET: /Containers/

        public ViewResult Index()
        {
            var containers = db.Containers.Include(c => c.UOM);
            return View(containers.ToList());
        }

        //
        // GET: /Containers/Details/5

        public ViewResult Details(int id)
        {
            Container container = db.Containers.Find(id);
            return View(container);
        }

        //
        // GET: /Containers/Create

        public ActionResult Create(int? id)
        {
            var ContainerID = id; //added
            var KPIID = id;
            ViewBag.UOMID = new SelectList(db.UOMs, "UOMID", "UOM_Code");
            return View();
        } 

        //
        // POST: /Containers/Create

        [HttpPost]
        public ActionResult Create(Container container)
        {
            if (ModelState.IsValid)
            {
                db.Containers.Add(container);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.UOMID = new SelectList(db.UOMs, "UOMID", "UOM_Code", container.UOMID);
            return View(container);
        }
        
        //
        // GET: /Containers/Edit/5
 
        public ActionResult Edit(int id)
        {
            Container container = db.Containers.Find(id);
            ViewBag.UOMID = new SelectList(db.UOMs, "UOMID", "UOM_Code", container.UOMID);
            return View(container);
        }

        //
        // POST: /Containers/Edit/5

        [HttpPost]
        public ActionResult Edit(Container container)
        {
            if (ModelState.IsValid)
            {
                db.Entry(container).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UOMID = new SelectList(db.UOMs, "UOMID", "UOM_Code", container.UOMID);
            return View(container);
        }

        //
        // GET: /Containers/Delete/5
 
        public ActionResult Delete(int id)
        {
            Container container = db.Containers.Find(id);
            return View(container);
        }

        //
        // POST: /Containers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Container container = db.Containers.Find(id);
            db.Containers.Remove(container);
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