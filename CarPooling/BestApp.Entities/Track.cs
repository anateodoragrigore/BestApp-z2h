using BestApp.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BestApp.Entities
{
    public class Track:BaseEntity<int>
    {
        //ora la care soferul porneste traseul
        public TimeSpan StartHour { get; set; }
        //punctul de plecare si destinatia
        public DbGeography Start { get; set; }
        public DbGeography Stop { get; set; }
        //nr locuri
        public int CarSeats{ get; set; }
        //datele luate din formular(nu din logarea userului)
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        //userul deja logat care face traseul (soferul)
        public User UserOwner { get; set; }

    }
}
