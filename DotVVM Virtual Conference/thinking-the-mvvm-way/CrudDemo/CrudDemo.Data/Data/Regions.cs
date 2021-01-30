using System;
using System.Collections.Generic;

namespace CrudDemo.Data.Data
{
    public partial class Regions
    {
        public Regions()
        {
            Territories = new HashSet<Territories>();
        }

        public long RegionId { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<Territories> Territories { get; set; }
    }
}
