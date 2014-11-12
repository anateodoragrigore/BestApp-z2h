using BestApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BestApp.Models
{
    public class BestAppContext:DbContext
    {
        public BestAppContext()
            : base("BestAppContext")
        {

        }
        public virtual DbSet<Track> TrackSet {get;set;}
        public virtual  DbSet<User> UserSet { get; set; }
    }
}
