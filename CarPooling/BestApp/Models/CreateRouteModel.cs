using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BestApp.Models
{
    public class CreateRouteModel
    {
        [Required(ErrorMessage = "Campul Nume este obligatoriu")]
        public string Nume { get; set; }
        
        [Required(ErrorMessage = "Campul Prenume este obligatoriu")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Campul Telefon este obligatoriu")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Numar de telefon invalid")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Adresa de e-mail este obligatorie")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Adresa de e-mail invalida")]
        public string Email { get; set; }
        
        [Range(1, 5, ErrorMessage = "Numarul de locuri intre 1-5")]
        public int NrLocuri { get; set; }
        
        public double LatPlecare { get; set; }
        public double LongPlecare { get; set; }
        public double LatSosire { get; set; }
        public double LongSosire { get; set; }
    }
}