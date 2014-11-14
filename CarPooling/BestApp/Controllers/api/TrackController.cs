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
        public IEnumerable<Track> GetTracks([FromUri]SearchRouteModel model)
        {
            using (var context = new BestAppContext())
            {
                return context.TrackSet.Where(track => track.EmailAddress=="anna730punct@yahoo.com").ToList();
            }
        }

        public void Post(int id)
        {
            using (var context = new BestAppContext())
            {
                var track = context.TrackSet.Find(id);
                User currentuser = context.GetCurrentUser(User.Identity.Name);
                var userTrack = new UserTrack()
                {
                    User = currentuser,
                    Track = track
                };

                context.UserTrackSet.Add(userTrack);
                context.SaveChanges();

            }
        }
    }
}

