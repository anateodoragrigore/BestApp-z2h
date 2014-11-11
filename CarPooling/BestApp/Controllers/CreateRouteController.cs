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
            //To do : validate model (daca toate capurile sunt completate> nume telefon...etc)
            //To do : save Route to database
            return RedirectToAction("Index", "Home");
        }
    }
}