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
            {
                Console.WriteLine(model.StartLatitude);
                Console.WriteLine(model.StopLatitude);

                return View();
            }
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
                            model.StartLatitude,
                            model.StartLongitude)
                            , 4326),
                        Stop = DbGeography.PointFromText(
                            string.Format("POINT({0} {1})",
                            model.StopLatitude,
                            model.StopLongitude)
                            , 4326),
                        StartHour = model.StartHour,
                        UserType = EnumUserType.Driver
                    };

                    context.TrackSet.Add(newtrack);
                    context.SaveChanges();

                    var newuser = new User()
                    {
                        PhoneNumber = model.PhoneNumber,
                        EmailAddress = model.Email,
                        Name = model.Name
                    };
                    context.UserSet.Add(newuser);
                    context.SaveChanges();
                }
            }

          
            return View();

        }
    }
}