using BestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BestApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private BestAppContext db = new BestAppContext();

        // GET: Tracks
        public ActionResult MyTracks()
        {
            var myTracks = db.TrackSet.Where
                (
                  track => track.UserOwner.Name == User.Identity.Name
                ).ToList();

            //var myTracks = db.UserTrackSet.Include(t => t.User).Include(t => t.Track).
            //    Where(p => p.User.Name == User.Identity.Name).Select(t=>t.Track);

            //return View(myTracks);
            
        }
    }
}