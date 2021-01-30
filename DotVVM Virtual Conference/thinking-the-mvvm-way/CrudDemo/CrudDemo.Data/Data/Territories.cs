using System;
using System.Collections.Generic;

namespace CrudDemo.Data.Data
{
    public partial class Territories
    {
        public Territories()
        {
            EmployeesTerritories = new HashSet<EmployeesTerritories>();
        }

        public long TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public long RegionId { get; set; }

        public virtual Regions Region { get; set; }
        public virtual ICollection<EmployeesTerritories> EmployeesTerritories { get; set; }
    }
}
