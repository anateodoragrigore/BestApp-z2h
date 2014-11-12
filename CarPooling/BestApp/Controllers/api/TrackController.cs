using BestApp.Entities;
using BestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BestApp.Controllers
{
    public class TrackController : ApiController
    {
        public IEnumerable<Track> GetTracks()
        {
            using (var model = new BestAppContext())
            {
                return model.TrackSet.ToList();

            }

        }
    }
}
