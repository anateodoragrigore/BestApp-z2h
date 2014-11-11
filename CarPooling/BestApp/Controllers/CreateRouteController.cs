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
    }
}