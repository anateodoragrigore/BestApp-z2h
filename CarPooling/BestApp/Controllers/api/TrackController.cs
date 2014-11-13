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

        private void SaveTrackToDatabase(CreateRouteModel model)
        {
            using (var context = new BestAppContext())
            {
                var newtrack = new Track()
                {
                    CarSeats = model.FreeSeats,
                    Start = DbGeography.PointFromText(
                        string.Format("POINT({0} {1})",
                        model.StartLatitude,
                        model.StartLongitude)
                        , 4326),
                    Stop = DbGeography.PointFromText(
                        string.Format("POINT({0} {1})",
                        model.StopLatitude,
                        model.StopLongitude)
                        , 4326),
                    StartHour = model.StartHour
                };

            }
        }

        public IEnumerable<Track> GetTracks()
        {
            using (var model = new BestAppContext())
            {
                return model.TrackSet.ToList();

            }

        }
    }
}
