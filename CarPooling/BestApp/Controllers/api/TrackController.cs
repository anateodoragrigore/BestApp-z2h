﻿using BestApp.Entities;
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
            double maxDelayInMinutes = 30;
            double maxDistanceInMetres = 2000;

            using (var context = new BestAppContext())
            {
                var intervalStart = model.StartHour.Add(TimeSpan.FromMinutes(-maxDelayInMinutes));
                var intervalStop = model.StartHour.Add(TimeSpan.FromMinutes(maxDelayInMinutes));

                var startPoint = DbGeography.PointFromText(string.Format("POINT({0} {1})", 
                                        model.StartLatitude, model.StartLongitude), 4326);
                var stopPoint = DbGeography.PointFromText(string.Format("POINT({0} {1})",
                                        model.StopLatitude, model.StopLongitude), 4326);

                return context.TrackSet
                    .Include("UserOwner")
                    .Where(
                    track => intervalStart < track.StartHour && 
                    track.StartHour < intervalStop &&
                    track.Start.Distance(startPoint) <= maxDistanceInMetres &&
                    track.Stop.Distance(stopPoint) <= maxDistanceInMetres
                    
                    ).ToList();
               
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

