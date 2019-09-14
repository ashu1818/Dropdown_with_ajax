using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cas_cading.Models;


namespace Cas_cading.Controllers
{
    public class LocationController : Controller
    {
        Cas_dbEntities cd = new Cas_dbEntities();
        // GET: Location
        public ActionResult Index()
        {
            ViewBag.Country = new SelectList(cd.CountryMasters.ToList(), "CountryId", "CountryName");
            ViewBag.State = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "", Value="Select State"
                }
            };
            ViewBag.City = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "", Value="Select City"
                }
            };
            return View();
        }

        //json : Location/getStatesByCountryId/1
        public JsonResult getStatesByCountryId(int id)
        {
            return Json(cd.StateMasters.Where(a => a.RefCountryId == id).Select(b => new { b.StateName,b.StateId }).ToList(),JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCitiesByStateId(int id)
        {
            return Json(cd.CityMasters.Where(a => a.RefStateId == id).Select(b => new { b.CityName, b.CityId }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}