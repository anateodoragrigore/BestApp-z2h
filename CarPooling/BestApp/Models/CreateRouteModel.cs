using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestApp.Models
{
    public class CreateRouteModel
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int NrLocuri { get; set; }
        public double LatPlecare { get; set; }
        public double LongPlecare { get; set; }
        public double LatSosire { get; set; }
        public double LongSosire { get; set; }
    }
}