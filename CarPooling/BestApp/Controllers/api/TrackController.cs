using BestApp.Entities;
using BestApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BestApp.Controllers
{
    public class TrackController : ApiController
    {
        
        public IEnumerable<Track> GetTracks([FromBody]SearchRouteModel model)
        {
            using (var context= new BestAppContext())
            {
                return context.TrackSet.ToList();

            }

        }
    }
}
