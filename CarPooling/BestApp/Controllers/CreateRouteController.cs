using BestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BestApp.Controllers
{
    public class CreateRouteController : Controller
    {
        // GET: CreateRoute
        public ActionResult Index()
        { 
            CreateRouteModel model = new CreateRouteModel();
            return View(model);
        }

        // POST: CreateRoute
        [HttpPost]
        public ActionResult Index(CreateRouteModel model)
        {
            Console.WriteLine(model.Nume);
            var routePosted = new List<object>();
            routePosted.Add(new { Nume = model.Nume, Prenume = model.Prenume, Telefon = model.Telefon, Email = model.Email, 
                        nrLocuri = model.NrLocuri, LatPlecare = model.LatPlecare,  longPlecare = model.LongPlecare,
                        LatSosire = model.LatSosire, LongSosire = model.LongSosire});
           
            //To do : save Route to database
            return Json(routePosted, JsonRequestBehavior.AllowGet); ;// Content(model.Nume);//RedirectToAction("Index", "Home");
           
      }
    }
}