using BestApp.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestApp.Entities
{
    public class User: BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
