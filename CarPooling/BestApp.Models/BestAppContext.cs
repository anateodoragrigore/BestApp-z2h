using BestApp.Entities;
using BestApp.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BestApp.Models
{
    public class BestAppContext:DbContext
    {
        public BestAppContext() : base("BestAppContext")
        {

        }
        public virtual DbSet<Track> TrackSet { get; set; }
        public virtual DbSet<User> UserSet { get; set; }
        public virtual DbSet<UserTrack> UserTrackSet{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());
            modelBuilder.Configurations.Add(new UserTrackConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public Entities.User GetCurrentUser(string userName)
        {
            User currentUser = null;
            if (!UserSet.Any(o => o.Name == userName))
            {
                var newuser = new User()
                {
                    Name = userName
                };
                UserSet.Add(newuser);
                currentUser = newuser;
            }
            else
            {
                currentUser = UserSet.Single(o => o.Name == userName);
            }
            return currentUser;
        }
    }
}
