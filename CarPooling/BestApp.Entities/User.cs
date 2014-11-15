using BestApp.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestApp.Entities
{
    public class User: BaseEntity<int>
    {
        [StringLength(250)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
