using BestApp.Entities;
using BestApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
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
            //validare
            if (!ModelState.IsValid)
                return View();

            else
            {

                //save Route to database
                using (var context = new BestAppContext())
                {


                    var newtrack = new Track()
                    {
                        CarSeats = model.FreeSeats,
                        Start = DbGeography.PointFromText(
                            string.Format("POINT({0} {1})",
                            model.startLatitude,
                            model.startLongitude)
                            , 4326),
                        Stop = DbGeography.PointFromText(
                            string.Format("POINT({0} {1})",
                            model.stopLatitude,
                            model.stopLongitude)
                            , 4326),
                        StartHour = TimeSpan.FromHours(8),
                        UserType = EnumUserType.Driver

                    };

                    context.TrackSet.Add(newtrack);
                    context.SaveChanges();
                }

            }

            //Console.WriteLine(model.Name);
            //var routePosted = new List<object>();
            //routePosted.Add(new { Nume = model.Name, Telefon = model.PhoneNumber, Email = model.Email, 
            //            nrLocuri = model.FreeSeats, LatPlecare = model.startLatitude,  longPlecare = model.startLongitude,
            //            LatSosire = model.stopLatitude, LongSosire = model.stopLongitude});




            return View();

        }
    }
}