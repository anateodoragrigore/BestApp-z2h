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
            if (User.Identity.IsAuthenticated)//if!User.Ide.isAuth..
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                SaveTrackToDatabase(model);
            }
            return View();
        }

        private void SaveTrackToDatabase(CreateRouteModel model)
        {
            using (var context = new BestAppContext())
            {
                User currentuser = context.GetCurrentUser(User.Identity.Name);

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
                    PhoneNumber = model.PhoneNumber,
                    EmailAddress = model.Email,
                    UserOwner = currentuser
                };

                context.TrackSet.Add(newtrack);
                context.SaveChanges();
            }
        }
    }
}