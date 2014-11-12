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

        public TimeSpan StartHour { get; set; }
        public  DbGeography Start { get; set; }
        public DbGeography Stop { get; set; }
        public int CarSeats{ get; set; }
        public EnumUserType UserType { get; set; }

    }
}
