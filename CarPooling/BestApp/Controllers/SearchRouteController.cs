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
            return View();
        }
    }
}