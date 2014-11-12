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
            Console.WriteLine(model.Name);
            var routePosted = new List<object>();
            routePosted.Add(new { Nume = model.Name, Telefon = model.PhoneNumber, Email = model.Email, 
                        nrLocuri = model.FreeSeats, LatPlecare = model.startLatitude,  longPlecare = model.startLongitude,
                        LatSosire = model.stopLatitude, LongSosire = model.stopLongitude});
           
            //To do : save Route to database
            return Json(routePosted, JsonRequestBehavior.AllowGet); ;// Content(model.Nume);//RedirectToAction("Index", "Home");
           
      }
    }
}