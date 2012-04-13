using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using In_Mgmt.Models;


namespace In_Mgmt.Controllers
{
    public class HomeController : Controller
    {
        public In_MgmtContext db = new In_MgmtContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to INVENTORY MANAGEMENT";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        // ValidateUOMCode
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult ValidateUOMCode(string uom_code, string initialCode, int? uomid)
        {
            var uom2 = db.UOMs.Include("UOM_Type").Any(u => u.UOM_Code == uom_code && u.UOMID != uomid);
            var uom = db.UOMs.Include("UOM_Type").Any(u => u.UOM_Code == uom_code);
            if (uom == true && initialCode == "undefined") //(uom.Equals(uom_code.ToLower()))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else if (initialCode != "undefined" && uom2 == true)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        //ValidateContainerCode
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult ValidateContainerCode(string containercode, string initialCCode, int? containerid)
        {
            //var uom = db.UOMs.Include("UOM_Type").Single(u => u.UOM_Code == uom_code);
                        
            var uom2 = db.Containers.Include("UOM_Code").Any(u => u.ContainerCode == containercode && u.ContainerID != containerid);
            var uom = db.Containers.Include("UOM_Code").Any(u => u.ContainerCode == containercode);

            if (uom == true && containerid == null) //&& uom3 == true
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else if (initialCCode != "undefined" && uom2 == true)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        //ValidateKPICode
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult ValidateKPICode(string kpi_code, string initialKCode, int? kpiid, int? containerid)
        {
            //var uom3 = db.Containers.Any(c => c.ContainerCode != containercode);
            var kpi2 = db.KPIs.Include("Container_Code").Any(u => u.KPI_Code == kpi_code && u.KPIID != kpiid);
            var kpi = db.KPIs.Any(u => u.KPI_Code == kpi_code); //&& u.ContainerID != containerid

            if (kpi == true && containerid == null) // && kpiid == null
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else if (initialKCode != "undefined" && kpi2 == true)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            //else if (kpi == true && initialCID == null)
            //{
            //    return Json(false, JsonRequestBehavior.AllowGet);
            //}
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
