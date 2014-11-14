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

        public IEnumerable<Track> GetTracks(TimeSpan startHour, double startLatitude, double startLongitude, double stopLatitude, double stopLongitude)
        {
            List<Track> final_tracks = null;

            using (var context = new BestAppContext())
            {
                foreach (var track in context.TrackSet.ToList())
                {
                    if (track.StartHour == startHour)
                        final_tracks.Add(track);
                }

                return final_tracks;

            }

        }

        public IEnumerable<Track> GetTracks([FromUri]SearchRouteModel model)
        {
            using (var context = new BestAppContext())
            {
                return context.TrackSet.Where(track => Matches(track, model)).ToList();
            }
        }

        private bool Matches(Track track, SearchRouteModel model)
        {
            return true;
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

