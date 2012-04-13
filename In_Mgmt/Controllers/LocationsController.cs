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
    public class LocationsController : Controller
    {
        private In_MgmtContext db = new In_MgmtContext();

        //
        // GET: /Locations/

        public ViewResult Index()
        {
            var locations = db.Locations.Include(l => l.Container);
            return View(locations.ToList());
        }

        //
        // GET: /Locations/Details/5

        public ViewResult Details(int id)
        {
            Location location = db.Locations.Find(id);
            return View(location);
        }

        //
        // GET: /Locations/Create

        public ActionResult Create()
        {
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerCode");
            return View();
        } 

        //
        // POST: /Locations/Create

        [HttpPost]
        public ActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerCode", location.ContainerID);
            return View(location);
        }
        
        //
        // GET: /Locations/Edit/5
 
        public ActionResult Edit(int id)
        {
            Location location = db.Locations.Find(id);
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerCode", location.ContainerID);
            return View(location);
        }

        //
        // POST: /Locations/Edit/5

        [HttpPost]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerCode", location.ContainerID);
            return View(location);
        }
                
        //
        // GET: /Locations/Delete/5
 
        public ActionResult Delete(int id)
        {
            Location location = db.Locations.Find(id);
            return View(location);
        }

        //
        // POST: /Locations/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
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