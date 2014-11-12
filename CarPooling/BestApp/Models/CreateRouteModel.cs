using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BestApp.Models
{
    public class CreateRouteModel
    {
        [Required(ErrorMessage = "Firstname must be filled out")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number must be filled out")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "E-mail must be filled out")]
        public string Email { get; set; }
        
        [Range(1, 5, ErrorMessage = "Seat numbers must be between 1 and 5")]
        [Display(Name = "Free Seats")]
        public int FreeSeats { get; set; }
        
        public double startLatitude { get; set; }
        public double startLongitude { get; set; }
        public double stopLatitude { get; set; }
        public double stopLongitude { get; set; }
    }
}