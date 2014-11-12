using BestApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestApp.Models.Configuration
{
    public class UserTrackConfiguration: EntityTypeConfiguration<UserTrack>
    {
        public UserTrackConfiguration()
        {
            HasKey(p => p.Id);
        }
    }
}
