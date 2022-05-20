using Sonal_DropDown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonal_DropDown.Controllers
{
    public class CascadeController : Controller
    {
        CascadeDDL dB = new CascadeDDL();
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult GetCountry()
        {
            var countries = dB.GetCountries();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetState(int id)
        {
            var states = dB.GetStates(id);
            return Json(states, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCity(int id)
        {
            var cities = dB.GetCities(id);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }


    }
}