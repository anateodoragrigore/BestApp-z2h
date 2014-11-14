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
            double maxDelayInMinutes=30; 

            using (var context = new BestAppContext())
            {
                var intervalStart = model.StartHour.Add(TimeSpan.FromMinutes(-maxDelayInMinutes));
                var intervalStop = model.StartHour.Add(TimeSpan.FromMinutes(maxDelayInMinutes));
                var tracks = context.TrackSet
                    .Include("UserOwner")
                    .Where(track => intervalStart < track.StartHour && track.StartHour < intervalStop).ToList();
                return tracks;
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

