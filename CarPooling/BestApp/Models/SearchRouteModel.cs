using BestApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BestApp.Models
{
    public class SearchRouteModel
    {

        [Display(Name = "Start Hour")]
        [Required]
        public TimeSpan StartHour { get; set; }

        [Display(Name = "User Type")]
        public EnumUserType UserType { get; set; }

        [Required(ErrorMessage = "Set source point on the map!")]
        public string StartLatitude { get; set; }
        public string StartLongitude { get; set; }

        [Required(ErrorMessage = "Set destination point on the map!")]
        public string StopLatitude { get; set; }
        public string StopLongitude { get; set; }
    }
}