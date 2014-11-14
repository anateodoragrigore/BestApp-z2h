using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestApp.Entities;
using BestApp.Models;

namespace BestApp.Controllers
{
    public class SearchRouteController : Controller
    {
        // GET: SearchRoute
        public ActionResult Index()
        {
            var json = new List<object>();

            using (var context = new BestAppContext())
            {
                
                var unicorn = context.TrackSet
                    .Where(babyUnicorn => babyUnicorn.PhoneNumber == "07999")
                    .FirstOrDefault();

                json.Add(new {startH = unicorn.StartHour, 
                    //startLocation = unicorn.Start, 
                    //stopLocation =  unicorn.Stop,
                    carSeats = unicorn.CarSeats, 
                    phone = unicorn.PhoneNumber, 
                    mail = unicorn.EmailAddress});
             }
            return Json(json, JsonRequestBehavior.AllowGet);
            //return View();
        }
    }
}